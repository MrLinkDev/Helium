using System.Resources;
using System.Windows;
using System.Windows.Media;
using Helium.Resources;

namespace Helium.Controls.RadioButton;

public class HeRadioButton : System.Windows.Controls.RadioButton {
    
    #region EllipseStroke

    public static readonly DependencyProperty EllipseStrokeProperty = DependencyProperty.Register(
        nameof(EllipseStroke),
        typeof(Brush),
        typeof(HeRadioButton),
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
        typeof(HeRadioButton),
        new FrameworkPropertyMetadata(HeBrushes.BlackBrush950));
    
    public Brush EllipseFill {
        get => (Brush)GetValue(EllipseFillProperty);
        set => SetValue(EllipseFillProperty, value);
    }

    #endregion

    #region EllipseInnerFill

    public static readonly DependencyProperty EllipseInnerFillProperty = DependencyProperty.Register(
        nameof(EllipseInnerFill),
        typeof(Brush),
        typeof(HeRadioButton),
        new FrameworkPropertyMetadata(HeBrushes.BlackBrush950));
    
    public Brush EllipseInnerFill {
        get => (Brush)GetValue(EllipseInnerFillProperty);
        set => SetValue(EllipseInnerFillProperty, value);
    }

    #endregion
    
    #region Content

    public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(object),
        typeof(HeRadioButton),
        new FrameworkPropertyMetadata(null));
    
    public new object? Content {
        get => (object?)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    #endregion
    
    static HeRadioButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeRadioButton),
            new FrameworkPropertyMetadata(typeof(HeRadioButton)));
    }
}
