using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Helium.ImageButton;


public class HeImageButtonBase : ButtonBase {
    
    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeImageButtonBase),
        new PropertyMetadata(new CornerRadius(2)));
    
    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    
    static HeImageButtonBase() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonBase),
            new FrameworkPropertyMetadata(typeof(HeImageButtonBase)));
    }
}
