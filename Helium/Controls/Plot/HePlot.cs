using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;
using Amethyst;
using Helium.Controls.Plot.Api;

namespace Helium.Controls.Plot;

public class HePlot : AmethystPlot2D {
    public int Id { get; set; }
    
    public delegate void OnMarkerCoordsUpdated(int traceId, int markerId, float value);
    
    public event OnMarkerCoordsUpdated? MarkerXUpdated;
    public event OnMarkerCoordsUpdated? MarkerYUpdated;
    
    private OnMarkerCoordsUpdated markerXUpdatedDelegate;
    private OnMarkerCoordsUpdated markerYUpdatedDelegate;
    
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
        markerXUpdatedDelegate = InvokeMarkerXUpdatedEvent;
        markerYUpdatedDelegate = InvokeMarkerYUpdatedEvent;
        
        Loaded += OnLoaded;
        Unloaded += (sender, args) => { Dispose(); };
        
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

        AmethystApi.SetMarkerCoordsUpdatedDelegate(
            screenPtr, 
            Marshal.GetFunctionPointerForDelegate(markerXUpdatedDelegate),
            Marshal.GetFunctionPointerForDelegate(markerYUpdatedDelegate));
        
        updateTimer.Start();
    }

    private void UpdateScreen() {
        if (!IsUpdateEnabled) return;
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
    }

    public void SelectTrace(int traceId) {
        AmethystApi.SelectTrace(screenPtr, traceId);
    }

    public float[] GetTrace(int traceId) {
        return plotDataDict[traceId].Data;
    }

    public void RemoveTrace(int traceId) {
        AmethystApi.RemoveTrace(screenPtr, traceId);
        
        if (!plotDataDict.ContainsKey(traceId)) return;
        plotDataDict[traceId].Dispose();
        plotDataDict.Remove(traceId);
    }

    public void SetData(int traceId, float[] data) {
        PlotData oldData = plotDataDict[traceId];
        
        plotDataDict[traceId] = new PlotData(data);
        AmethystApi.SetData(screenPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);
        
        oldData.Dispose();
    }

    public void AutoScale(int traceId) {
        AmethystApi.AutoScale(screenPtr, traceId);
    }

    public void SetStartStopX(int traceId, float startX, float stopX) {
        AmethystApi.SetStartStopX(screenPtr, traceId, startX, stopX);
    }
    
    public void SetStartStopY(int traceId, float startY, float stopY) {
        AmethystApi.SetStartStopY(screenPtr, traceId, startY, stopY);
    }

    public (float, float) GetStartStopX(int traceId) {
        return (AmethystApi.GetStartX(screenPtr, traceId), AmethystApi.GetStopX(screenPtr, traceId));
    }

    public (float, float) GetStartStopY(int traceId) {
        return (AmethystApi.GetStartY(screenPtr, traceId), AmethystApi.GetStopY(screenPtr, traceId));
    }

    public void SetUnits(int traceId, int unitsX, int unitsY) {
        AmethystApi.SetUnits(screenPtr, traceId, unitsX, unitsY);
    }

    public void SetUnitsX(int traceId, int units) {
        AmethystApi.SetUnitsX(screenPtr, traceId, units);
    }

    public void SetUnitsY(int traceId, int units) {
        AmethystApi.SetUnitsY(screenPtr, traceId, units);
    }

    public void ReverseDraw(bool reverse) {
        AmethystApi.SetIsDrawReversed(screenPtr, reverse);
    }

    #endregion

    #region MarkerRegion

    public void AddMarker(int traceId, int markerId) {
        AmethystApi.AddMarkerWTrace(screenPtr, traceId, markerId);
    }

    public void AddMarker(int markerId) {
        AmethystApi.AddMarker(screenPtr, markerId);
    }

    public void SelectMarker(int traceId, int markerId) {
        AmethystApi.SelectMarkerWTrace(screenPtr, traceId, markerId);
    }

    public void SelectMarker(int markerId) {
        AmethystApi.SelectMarker(screenPtr, markerId);
    }
    
    public void RemoveMarker(int traceId, int markerId) {
        AmethystApi.RemoveMarkerWTrace(screenPtr, traceId, markerId);
    }
    
    public void RemoveMarker(int markerId) {
        AmethystApi.RemoveMarker(screenPtr, markerId);
    }

    public void SetMarkerX(int traceId, int markerId, float x) {
        AmethystApi.SetMarkerXWTrace(screenPtr, traceId, markerId, x);
    }

    public void SetMarkerX(int markerId, float x) {
        AmethystApi.SetMarkerX(screenPtr, markerId, x);
    }

    public float GetMarkerX(int traceId, int markerId) {
        return AmethystApi.GetMarkerXWTrace(screenPtr, traceId, markerId);
    }

    public float GetMarkerX(int markerId) {
        return AmethystApi.GetMarkerX(screenPtr, markerId);
    }

    public void SetMarkerY(int traceId, int markerId, float y) {
        AmethystApi.SetMarkerYWTrace(screenPtr, traceId, markerId, y);
    }

    public void SetMarkerY(int markerId, float y) {
        AmethystApi.SetMarkerY(screenPtr, markerId, y);
    }

    public float GetMarkerY(int traceId, int markerId) {
        return AmethystApi.GetMarkerYWTrace(screenPtr, traceId, markerId);
    }

    public float GetMarkerY(int markerId) {
        return AmethystApi.GetMarkerY(screenPtr, markerId);
    }

    public void SetMarkerFunction(int traceId, int markerId, int type) {
        AmethystApi.SetMarkerFunctionWTrace(screenPtr, traceId, markerId, type);
    }

    public void SetMarkerFunction(int markerId, int type) {
        AmethystApi.SetMarkerFunction(screenPtr, markerId, type);
    }

    public void RemoveMarkerFunction(int traceId, int markerId) {
        AmethystApi.RemoveMarkerFunctionWTrace(screenPtr, traceId, markerId);
    }

    public void RemoveMarkerFunction(int markerId) {
        AmethystApi.RemoveMarkerFunction(screenPtr, markerId);
    }

    private void InvokeMarkerXUpdatedEvent(int traceId, int markerId, float value) {
        MarkerXUpdated?.Invoke(traceId, markerId, value);
    }

    private void InvokeMarkerYUpdatedEvent(int traceId, int markerId, float value) {
        MarkerYUpdated?.Invoke(traceId, markerId, value);
    }
    
    #endregion
}
