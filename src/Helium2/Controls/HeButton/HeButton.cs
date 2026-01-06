using System.Windows;
using System.Windows.Controls;

namespace Helium2.Controls;

public class HeButton : Button {

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

    static HeButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButton),
            new FrameworkPropertyMetadata(typeof(HeButton)));
    }
}
