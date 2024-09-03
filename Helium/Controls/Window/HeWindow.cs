using System.Windows;
using System.Windows.Media;

namespace Helium.Controls.Window;

public class HeWindow : System.Windows.Window {

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
}
