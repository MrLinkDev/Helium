using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;
using Amethyst;

namespace Helium.Plot;

public class HePlot : Decorator {
    
    private DispatcherTimer updateTimer = new DispatcherTimer();

    public IntPtr ActivityPtr;
    public IntPtr ScreenPtr;
    
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
    }

    private void OnLoaded(object sender, RoutedEventArgs e) {
        GlWindow window = new GlWindow();
        Child = window;
        
        unsafe {
            ActivityPtr = (IntPtr) window.activity;
        }
    }
    
    
}
