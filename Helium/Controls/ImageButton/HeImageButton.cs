using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Helium.Utilities;

namespace Helium.Controls.ImageButton;


public class HeImageButton : ButtonBase {
    
    #region HeType

    public static readonly DependencyProperty HeTypeProperty = DependencyProperty.Register(
        nameof(HeType),
        typeof(HeType),
        typeof(HeImageButton),
        new FrameworkPropertyMetadata(HeType.Flat));
    
    public HeType HeType {
        get => (HeType)GetValue(HeTypeProperty);
        set => SetValue(HeTypeProperty, value);
    }
    
    #endregion
    
    #region HeTheme

    public static readonly DependencyProperty HeThemeProperty = DependencyProperty.Register(
        nameof(HeTheme),
        typeof(HeTheme),
        typeof(HeImageButton),
        new FrameworkPropertyMetadata(HeTheme.Default));
    
    public HeTheme HeTheme {
        get => (HeTheme)GetValue(HeThemeProperty);
        set => SetValue(HeThemeProperty, value);
    }
    
    #endregion

    #region CornerRadius

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeImageButton),
        new PropertyMetadata(new CornerRadius(2)));
    
    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion

    #region ImageSource

    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
        nameof(ImageSource),
        typeof(ImageSource),
        typeof(HeImageButton),
        new PropertyMetadata(null));
    
    public ImageSource ImageSource {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    #endregion

    #region ImageSourceDisabled

    public static readonly DependencyProperty ImageSourceDisabledProperty = DependencyProperty.Register(
        nameof(ImageSourceDisabled),
        typeof(ImageSource),
        typeof(HeImageButton),
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

    #endregion

    #region ImageWidth

    public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register(
        nameof(ImageWidth),
        typeof(double),
        typeof(HeImageButton),
        new PropertyMetadata(0.0));
    
    public double ImageWidth {
        get => (double)GetValue(ImageWidthProperty);
        set => SetValue(ImageWidthProperty, value);
    }

    #endregion
    
    #region ImageHeight

    public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register(
        nameof(ImageHeight),
        typeof(double),
        typeof(HeImageButton),
        new PropertyMetadata(0.0));
    
    public double ImageHeight {
        get => (double)GetValue(ImageHeightProperty);
        set => SetValue(ImageHeightProperty, value);
    }

    #endregion

    static HeImageButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButton),
            new FrameworkPropertyMetadata(typeof(HeImageButton)));
    }
}
