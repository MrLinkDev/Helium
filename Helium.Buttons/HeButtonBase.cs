using System.Windows;
using System.Windows.Controls.Primitives;

namespace Helium.Buttons;

public class HeButtonBase : ButtonBase {
    
    #region DependencyProperties

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeButtonBase),
        new PropertyMetadata(new CornerRadius(2)));

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(HeButtonBase),
        new PropertyMetadata(string.Empty));

    #endregion

    #region Properties

    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion
    
}
