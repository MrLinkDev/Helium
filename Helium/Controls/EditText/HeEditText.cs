using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Helium.Resources;

namespace Helium.Controls.EditText;

public class HeEditText : TextBox {
    
    #region EditTextBorder

    public static readonly DependencyProperty EditTextBorderProperty = DependencyProperty.Register(
        nameof(EditTextBorder),
        typeof(Brush),
        typeof(HeEditText),
        new FrameworkPropertyMetadata(HeBrushes.BlackBrush500));
    
    public Brush EditTextBorder {
        get => (Brush)GetValue(EditTextBorderProperty);
        set => SetValue(EditTextBorderProperty, value);
    }
    
    #endregion
    
    #region EditTextHint

    public static readonly DependencyProperty EditTextHintProperty = DependencyProperty.Register(
        nameof(EditTextHint),
        typeof(string),
        typeof(HeEditText),
        new FrameworkPropertyMetadata(string.Empty));
    
    public string EditTextHint {
        get => (string)GetValue(EditTextHintProperty);
        set => SetValue(EditTextHintProperty, value);
    }
    
    #endregion
    
    static HeEditText() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeEditText),
            new FrameworkPropertyMetadata(typeof(HeEditText)));
    }
}
