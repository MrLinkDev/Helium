using System.Windows;
using System.Windows.Controls.Primitives;
using Helium.Utilities;

namespace Helium.Controls.Button;

public class HeButton : ButtonBase {
    
    #region HeType

    public static readonly DependencyProperty HeTypeProperty = DependencyProperty.Register(
        nameof(HeType),
        typeof(HeType),
        typeof(HeButton),
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
        typeof(HeButton),
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
        typeof(HeButton),
        new FrameworkPropertyMetadata(new CornerRadius(2), 
            FrameworkPropertyMetadataOptions.AffectsRender));
    
    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion

    #region Text

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(HeButton),
        new FrameworkPropertyMetadata(string.Empty, 
            FrameworkPropertyMetadataOptions.AffectsRender));
    
    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion
    
    static HeButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButton),
            new FrameworkPropertyMetadata(typeof(HeButton)));
    }
}
