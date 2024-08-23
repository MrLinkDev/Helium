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
    
    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
        nameof(ImageSource),
        typeof(ImageSource),
        typeof(HeImageButtonBase),
        new PropertyMetadata(null));
    
    public ImageSource ImageSource {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
    
    public static readonly DependencyProperty ImageSourceDisabledProperty = DependencyProperty.Register(
        nameof(ImageSourceDisabled),
        typeof(ImageSource),
        typeof(HeImageButtonBase),
        new PropertyMetadata(null));
    
    public ImageSource ImageSourceDisabled {
        get {
            var imageSource = (ImageSource)GetValue(ImageSourceDisabledProperty);
            if (imageSource == null) {
                imageSource = (ImageSource)GetValue(ImageSourceProperty);
            }

            return imageSource;
        }
        set => SetValue(ImageSourceDisabledProperty, value);
    }

    static HeImageButtonBase() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonBase),
            new FrameworkPropertyMetadata(typeof(HeImageButtonBase)));
    }
}
