using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Lithium;

namespace Helium.Controls.Window;

public class HeWindow : System.Windows.Window {

    private bool inDragMode = false;

    #region DependencyProperties

    public static readonly DependencyProperty ToolbarBackgroundProperty = DependencyProperty.Register(
        nameof(ToolbarBackground),
        typeof(Brush),
        typeof(HeWindow),
        new PropertyMetadata(Brushes.White));
    
    public static readonly DependencyProperty BodyBackgroundProperty = DependencyProperty.Register(
        nameof(BodyBackground),
        typeof(Brush),
        typeof(HeWindow),
        new PropertyMetadata(new SolidColorBrush(Color.FromRgb(33, 33, 33))));

    #endregion

    #region Properties

    public Brush ToolbarBackground {
        get => (Brush)GetValue(ToolbarBackgroundProperty);
        set => SetValue(ToolbarBackgroundProperty, value);
    }
    
    public Brush BodyBackground {
        get => (Brush)GetValue(BodyBackgroundProperty);
        set => SetValue(BodyBackgroundProperty, value);
    }

    #endregion
    
    static HeWindow() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeWindow),
            new FrameworkPropertyMetadata(typeof(HeWindow)));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        if (GetTemplateChild("WindowToolbar") is DockPanel panel) SetupWindowToolbar(panel);
    }

    private void SetupWindowToolbar(DockPanel panel) {
        panel.DragEnter += OnDragEnter;
        panel.DragLeave += OnDragLeave;
        panel.MouseMove += OnMouseMove;
    }

    private void OnDragEnter(object sender, DragEventArgs e) {
        Log.D("Drag mode enabled");
        inDragMode = true;
    }
    
    private void OnDragLeave(object sender, DragEventArgs e) {
        Log.D("Drag mode disabled");
        inDragMode = false;
    }

    private void OnMouseMove(object sender, MouseEventArgs e) {
        Log.D("On mouse move");
        if (e.LeftButton == MouseButtonState.Pressed) DragMove();
    }
}
