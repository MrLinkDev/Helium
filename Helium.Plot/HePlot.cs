using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;

using Amethyst;

namespace Helium.Plot;

public class HePlot : Decorator {
    
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
    
    static HePlot() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HePlot),
            new FrameworkPropertyMetadata(typeof(HePlot)));
    }

    public override void BeginInit() {
        Loaded += OnLoaded;
        
        updateTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / FrameRate);
        updateTimer.Tick += Tick;
        updateTimer.Start();
        
        base.BeginInit();
    }
    
    private void Tick(object? sender, EventArgs e) {
        Child?.InvalidateVisual();
        UpdateScreen();
    }

    private void OnLoaded(object sender, RoutedEventArgs e) {
        GlWindow window = new GlWindow();
        Child = window;
        
        unsafe {
            screenPtr = (IntPtr) window.screen;
            containerPtr = AmethystApi.GetTraceContainerPtr(screenPtr);
        }

        plotDataDict = new Dictionary<int, PlotData>();
    }

    private void UpdateScreen() {
        AmethystApi.SetScreenUpdated(screenPtr);
    }

    #region TraceRegion

    public float[] AddTrace(int traceId, uint size) {
        if (plotDataDict.TryGetValue(traceId, out PlotData? value)) return value.Data;

        plotDataDict[traceId] = new PlotData(size);
        AmethystApi.AddTrace(containerPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);
        
        UpdateScreen();
        
        return plotDataDict[traceId].Data;
    }
    
    public void AddTrace(int traceId, float[] data) {
        plotDataDict[traceId] = new PlotData(data);
        AmethystApi.AddTrace(containerPtr, traceId, plotDataDict[traceId].Pointer, plotDataDict[traceId].Points);
        
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
        AmethystApi.AddMarker(containerPtr, traceId, markerId, x, 0);
    }

    public void SelectMarker(int traceId, int markerId) {
        AmethystApi.SelectMarker(containerPtr, traceId, markerId);
    }
    
    public void RemoveMarker(int traceId, int markerId) {
        AmethystApi.RemoveMarker(containerPtr, traceId, markerId);
    }
    
    #endregion
}
