using System.Resources;
using System.Windows;
using System.Windows.Media;
using Helium.Resources;
using Helium.Utilities;

namespace Helium.Controls.XRadioButton;

public class HeXRadioButton : System.Windows.Controls.RadioButton {
    
    #region HeType

    public static readonly DependencyProperty HeTypeProperty = DependencyProperty.Register(
        nameof(HeType),
        typeof(HeType),
        typeof(HeXRadioButton),
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
        typeof(HeXRadioButton),
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
        typeof(HeXRadioButton),
        new FrameworkPropertyMetadata(new CornerRadius(2), 
            FrameworkPropertyMetadataOptions.AffectsRender));
    
    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion
    
    #region EllipseStroke

    public static readonly DependencyProperty EllipseStrokeProperty = DependencyProperty.Register(
        nameof(EllipseStroke),
        typeof(Brush),
        typeof(HeXRadioButton),
        new FrameworkPropertyMetadata(HeBrushes.PrimaryBrush500));
    
    public Brush EllipseStroke {
        get => (Brush)GetValue(EllipseStrokeProperty);
        set => SetValue(EllipseStrokeProperty, value);
    }

    #endregion
    
    #region EllipseFill

    public static readonly DependencyProperty EllipseFillProperty = DependencyProperty.Register(
        nameof(EllipseFill),
        typeof(Brush),
        typeof(HeXRadioButton),
        new FrameworkPropertyMetadata(HeBrushes.BlackBrush950));
    
    public Brush EllipseFill {
        get => (Brush)GetValue(EllipseFillProperty);
        set => SetValue(EllipseFillProperty, value);
    }

    #endregion

    #region StrokeFill

    public static readonly DependencyProperty StrokeFillProperty = DependencyProperty.Register(
        nameof(StrokeFill),
        typeof(Brush),
        typeof(HeXRadioButton),
        new FrameworkPropertyMetadata(HeBrushes.BlackBrush950));
    
    public Brush StrokeFill {
        get => (Brush)GetValue(StrokeFillProperty);
        set => SetValue(StrokeFillProperty, value);
    }

    #endregion
    
    #region Content

    public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(string),
        typeof(HeXRadioButton),
        new FrameworkPropertyMetadata(string.Empty));
    
    public new string Content {
        get => (string)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    #endregion
    
    static HeXRadioButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXRadioButton),
            new FrameworkPropertyMetadata(typeof(HeXRadioButton)));
    }
}
