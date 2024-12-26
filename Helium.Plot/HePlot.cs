using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Amethyst;

namespace Helium.Plot;

public class HePlot : GlWindow {
    private bool isUpdateEnabled = true;

    public bool IsUpdateEnabled {
        get => isUpdateEnabled;
        set => isUpdateEnabled = value;
    }

    private DispatcherTimer updateTimer = new DispatcherTimer();

    private IntPtr screenPtr;
    private IntPtr containerPtr;

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
        
        unsafe {
            screenPtr = (IntPtr)screen;
            containerPtr = AmethystApi.GetTraceContainerPtr(screenPtr);
        }

        SizeChangedInfo info = new SizeChangedInfo(this, new Size(), true, true);
        
        OnRenderSizeChanged(info);
        
        UpdateScreen();
        updateTimer.Start();
    }

    public void UpdateScreen() {
        if (!IsUpdateEnabled) return;
        AmethystApi.SetScreenUpdated(screenPtr);
        InvalidateVisual();
    }

    #region TraceRegion

    public float[] AddTrace(int traceId, uint size, float startX, float startY, float stopX, float stopY) {
        if (plotDataDict.TryGetValue(traceId, out PlotData? value)) return value.Data;

        plotDataDict[traceId] = new PlotData(size);
        AmethystApi.AddTrace(containerPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);
        
        AmethystApi.SetStartStopX(containerPtr, traceId, startX, stopX);
        AmethystApi.SetStartStopY(containerPtr, traceId, startY, stopY);
        
        UpdateScreen();
        
        return plotDataDict[traceId].Data;
    }
    
    public void AddTrace(int traceId, float[] data) {
        plotDataDict[traceId] = new PlotData(data);
        AmethystApi.AddTrace(containerPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);

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
        
        AmethystApi.SetStartStopX(containerPtr, traceId, startX, stopX);
        AmethystApi.SetStartStopY(containerPtr, traceId, startY, stopY);
        
        UpdateScreen();
    }

    public void SelectTrace(int traceId) {
        AmethystApi.SelectTrace(containerPtr, traceId);
        UpdateScreen();
    }

    public void RemoveTrace(int traceId) {
        AmethystApi.RemoveTrace(containerPtr, traceId);
        UpdateScreen();
        
        plotDataDict[traceId].Dispose();
        plotDataDict.Remove(traceId);
    }

    public void SetData(int traceId, float[] data) {
        PlotData oldData = plotDataDict[traceId];
        
        plotDataDict[traceId] = new PlotData(data);
        AmethystApi.SetData(containerPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);
        
        UpdateScreen();
        
        oldData.Dispose();
    }

    public void SetStartStopX(int traceId, float startX, float stopX) {
        AmethystApi.SetStartStopX(containerPtr, traceId, startX, stopX);
        UpdateScreen();
    }
    
    public void SetStartStopY(int traceId, float startY, float stopY) {
        AmethystApi.SetStartStopY(containerPtr, traceId, startY, stopY);
        UpdateScreen();
    }

    #endregion

    #region MarkerRegion

    public void AddMarker(int traceId, int markerId, float x) {
        AmethystApi.AddMarker(containerPtr, traceId, markerId, x);
        UpdateScreen();
    }

    public void SelectMarker(int traceId, int markerId) {
        AmethystApi.SelectMarker(containerPtr, traceId, markerId);
        UpdateScreen();
    }
    
    public void RemoveMarker(int traceId, int markerId) {
        AmethystApi.RemoveMarker(containerPtr, traceId, markerId);
        UpdateScreen();
    }

    public void SetMarkerX(int traceId, int markerId, float x) {
        AmethystApi.SetMarkerX(containerPtr, traceId, markerId, x);
        UpdateScreen();
    }
    
    #endregion
}
