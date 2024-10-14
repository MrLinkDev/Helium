using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;

using Amethyst;

namespace Helium.Plot;

public class HePlot : Decorator {
    
    private DispatcherTimer updateTimer = new DispatcherTimer();
    
    public Action OnReady { get; set; }
    public Action OnUpdate { get; set; }

    public IntPtr ActivityPtr;
    public IntPtr ScreenPtr;

    public uint currentTraceId = 0;
    
    #region FrameRate

    public static readonly DependencyProperty FrameRateProperty = DependencyProperty.Register(
        nameof(FrameRate),
        typeof(int),
        typeof(HePlot),
        new FrameworkPropertyMetadata(10));
    
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
        OnUpdate.Invoke();
    }

    private void OnLoaded(object sender, RoutedEventArgs e) {
        GlWindow window = new GlWindow();
        Child = window;
        
        unsafe {
            ActivityPtr = (IntPtr) window.activity;
            ScreenPtr = AmethystApi.GetScreenPtr(ActivityPtr);
        }
        
        OnReady.Invoke();
    }

    public void AddTrace(uint traceId, IntPtr dataPtr, uint points) {
        AmethystApi.AddTrace(ScreenPtr, traceId, dataPtr, points);
    }
    
    public void RemoveTrace(uint traceId) {
        AmethystApi.RemoveTrace(ScreenPtr, traceId);
    }

    public void AddMarker(uint traceId, uint markerId, float x, float y) {
        AmethystApi.AddMarker(ScreenPtr, traceId, markerId, x, y);
    }

    public void SetMarkerX(uint traceId, uint markerId, float x) {
        AmethystApi.SetMarkerX(ScreenPtr, traceId, markerId, x);
    }

    public void SetMarkerY(uint traceId, uint markerId, float y) {
        AmethystApi.SetMarkerY(ScreenPtr, traceId, markerId, y);
    }

    public void PlaceMarker(uint traceId, uint markerId, float x, float y) {
        AmethystApi.PlaceMarker(ScreenPtr, traceId, markerId, x, y);
    }

    public void RemoveMarker(uint traceId, uint markerId) {
        AmethystApi.RemoveMarker(ScreenPtr, traceId, markerId);
    }
}
