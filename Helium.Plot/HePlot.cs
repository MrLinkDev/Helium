using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;

namespace Helium.Plot;

public class HePlot : Decorator {
    private DispatcherTimer updateTimer = new DispatcherTimer();
    
    #region FrameRate

    public static readonly DependencyProperty FrameRateProperty = DependencyProperty.Register(
        nameof(FrameRate),
        typeof(int),
        typeof(HePlot),
        new FrameworkPropertyMetadata(60));
    
    public int FrameRate {
        get => (int)GetValue(FrameRateProperty);
        set => SetValue(FrameRateProperty, value);
    }

    #endregion
    
    static HePlot() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HePlot),
            new FrameworkPropertyMetadata(typeof(HePlot)));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();
        
    }

    public override void BeginInit() {
        Loaded += OnLoaded;
        
        updateTimer.Interval = new TimeSpan(TimeSpan.TicksPerSecond / FrameRate);
        updateTimer.Tick += Tick;
        updateTimer.Start();
        
        base.BeginInit();
    }
    private void Tick(object sender, EventArgs e) {
        if (Child != null) {
            Child.InvalidateVisual();
        }
    }

    private void OnLoaded(object sender, RoutedEventArgs e) {
        HwndHost host = new Amethyst.GlWindow();
        Child = host;
    }
    
}
