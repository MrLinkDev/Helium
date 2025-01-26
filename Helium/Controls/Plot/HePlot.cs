using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;
using Amethyst;

namespace Helium.Controls.Plot;

public class HePlot : AmethystPlot2D {
    private bool isUpdateEnabled = true;

    public bool IsUpdateEnabled {
        get => isUpdateEnabled;
        set => isUpdateEnabled = value;
    }

    private DispatcherTimer updateTimer = new DispatcherTimer(DispatcherPriority.Render);

    private IntPtr screenPtr;

    private Dictionary<int, PlotData> plotDataDict;
    
    #region FrameRate

    public static readonly DependencyProperty FrameRateProperty = DependencyProperty.Register(
        nameof(FrameRate),
        typeof(int),
        typeof(HePlot),
        new FrameworkPropertyMetadata(30));
    
    public int FrameRate {
        get => (int)GetValue(FrameRateProperty);
        set {
            SetValue(FrameRateProperty, value);
            updateTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / FrameRate);
        }
    }

    #endregion

    public HePlot() {
        Loaded += OnLoaded;
        
        unsafe {
            screenPtr = (IntPtr)screen;
        }
    }

    public override void BeginInit() {
        updateTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / FrameRate);
        updateTimer.Tick += Tick;

        plotDataDict = new Dictionary<int, PlotData>();
        
        base.BeginInit();
    }

    private void Tick(object? sender, EventArgs e) {
        UpdateScreen();
    }

    public override void OnLoaded(object sender, RoutedEventArgs args) {
        base.OnLoaded(sender, args);

        SizeChangedInfo info = new SizeChangedInfo(this, new Size(), true, true);
        OnRenderSizeChanged(info);
        
        //UpdateScreen();
        updateTimer.Start();
    }

    public void UpdateScreen() {
        if (!IsUpdateEnabled) return;
        //AmethystApi.SetScreenUpdated(screenPtr);
        InvalidateVisual();
    }

    #region TraceRegion

    public float[] AddTrace(int traceId, int points, float startX, float startY, float stopX, float stopY) {
        if (plotDataDict.TryGetValue(traceId, out PlotData? value)) return value.Data;

        plotDataDict[traceId] = new PlotData(points);
        AmethystApi.AddTrace(screenPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);
        
        AmethystApi.SetStartStopX(screenPtr, traceId, startX, stopX);
        AmethystApi.SetStartStopY(screenPtr, traceId, startY, stopY);
        
        UpdateScreen();
        
        return plotDataDict[traceId].Data;
    }
    
    public void AddTrace(int traceId, float[] data) {
        plotDataDict[traceId] = new PlotData(data);
        AmethystApi.AddTrace(screenPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);

        float[] x = new float[data.Length / 2];
        float[] y = new float[data.Length / 2];
        
        for (int i = 0, j = 0; i < data.Length; i += 2, j += 1) {
            x[j] = data[i];
            y[j] = data[i + 1];
        }

        float startX = x.Min();
        float stopX = x.Max();
        
        float startY = y.Min();
        float stopY = y.Max();

        float dY = MathF.Abs((stopY - startY) * 0.1f);
        if (dY == 0) dY = 0.1f;
        
        startY -= dY;
        stopY += dY;
        
        AmethystApi.SetStartStopX(screenPtr, traceId, startX, stopX);
        AmethystApi.SetStartStopY(screenPtr, traceId, startY, stopY);
        
        UpdateScreen();
    }

    public void SelectTrace(int traceId) {
        AmethystApi.SelectTrace(screenPtr, traceId);
        UpdateScreen();
    }

    public float[] GetTrace(int traceId) {
        return plotDataDict[traceId].Data;
    }

    public void RemoveTrace(int traceId) {
        AmethystApi.RemoveTrace(screenPtr, traceId);
        UpdateScreen();
        
        if (!plotDataDict.ContainsKey(traceId)) return;
        plotDataDict[traceId].Dispose();
        plotDataDict.Remove(traceId);
    }

    public void SetData(int traceId, float[] data) {
        PlotData oldData = plotDataDict[traceId];
        
        plotDataDict[traceId] = new PlotData(data);
        AmethystApi.SetData(screenPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);
        
        UpdateScreen();
        
        oldData.Dispose();
    }

    public void SetStartStopX(int traceId, float startX, float stopX) {
        AmethystApi.SetStartStopX(screenPtr, traceId, startX, stopX);
        UpdateScreen();
    }
    
    public void SetStartStopY(int traceId, float startY, float stopY) {
        AmethystApi.SetStartStopY(screenPtr, traceId, startY, stopY);
        UpdateScreen();
    }

    #endregion

    #region MarkerRegion

    public float AddMarker(int markerId) {
        float x = AmethystApi.AddMarker(screenPtr, markerId);
        UpdateScreen();

        return x;
    }

    public void SelectMarker(int markerId) {
        AmethystApi.SelectMarker(screenPtr, markerId);
        UpdateScreen();
    }
    
    public void RemoveMarker(int markerId) {
        AmethystApi.RemoveMarker(screenPtr, markerId);
        UpdateScreen();
    }

    public void SetMarkerX(int markerId, float x) {
        AmethystApi.SetMarkerX(screenPtr, markerId, x);
        UpdateScreen();
    }

    public float GetMarkerX(int markerId) {
        return AmethystApi.GetMarkerX(screenPtr, markerId);
        UpdateScreen();
    }
    
    #endregion
}
