using System.Windows;
using System.Windows.Media;
using Helium.Controls.CheckBox;
using Helium.Resources;

namespace Helium.Controls.XPushButton;

public class HeXPushButton : System.Windows.Controls.CheckBox {
    
    #region Content

    public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(object),
        typeof(HeXPushButton),
        new FrameworkPropertyMetadata(null));
    
    public new object? Content {
        get => (object?)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    #endregion
    
    static HeXPushButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXPushButton),
            new FrameworkPropertyMetadata(typeof(HeXPushButton)));
    }
}
