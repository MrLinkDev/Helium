using System.Resources;
using System.Windows;
using System.Windows.Media;
using Helium.Resources;

namespace Helium.Controls.CheckBox;

public class HeCheckBox : System.Windows.Controls.CheckBox {
    
    #region CheckBoxStroke

    public static readonly DependencyProperty CheckBoxStrokeProperty = DependencyProperty.Register(
        nameof(CheckBoxStroke),
        typeof(Brush),
        typeof(HeCheckBox),
        new FrameworkPropertyMetadata(HeBrushes.PrimaryBrush500));
    
    public Brush CheckBoxStroke {
        get => (Brush)GetValue(CheckBoxStrokeProperty);
        set => SetValue(CheckBoxStrokeProperty, value);
    }

    #endregion
    
    #region CheckBoxFill

    public static readonly DependencyProperty CheckBoxFillProperty = DependencyProperty.Register(
        nameof(CheckBoxFill),
        typeof(Brush),
        typeof(HeCheckBox),
        new FrameworkPropertyMetadata(HeBrushes.BlackBrush950));
    
    public Brush CheckBoxFill {
        get => (Brush)GetValue(CheckBoxFillProperty);
        set => SetValue(CheckBoxFillProperty, value);
    }

    #endregion
    
    #region CheckBoxFigureFill

    public static readonly DependencyProperty CheckBoxFigureFillProperty = DependencyProperty.Register(
        nameof(CheckBoxFigureFill),
        typeof(Brush),
        typeof(HeCheckBox),
        new FrameworkPropertyMetadata(Brushes.Transparent));
    
    public Brush CheckBoxFigureFill {
        get => (Brush)GetValue(CheckBoxFigureFillProperty);
        set => SetValue(CheckBoxFigureFillProperty, value);
    }

    #endregion
    
    #region Content

    public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(object),
        typeof(HeCheckBox),
        new FrameworkPropertyMetadata(null));
    
    public new object? Content {
        get => (object?)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    #endregion
    
    static HeCheckBox() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeCheckBox),
            new FrameworkPropertyMetadata(typeof(HeCheckBox)));
    }
}
