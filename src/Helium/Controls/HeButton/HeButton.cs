using System.Windows;
using System.Windows.Controls;
using Helium.Utilities;

namespace Helium.Controls;

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

    #region HeType

    public static readonly DependencyProperty HeTypeProperty = DependencyProperty.Register(
        nameof(HeType),
        typeof(HeType),
        typeof(HeButton),
        new FrameworkPropertyMetadata(HeType.Normal,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public HeType HeType {
        get => (HeType)GetValue(HeTypeProperty);
        set => SetValue(HeTypeProperty, value);
    }

    #endregion

    static HeButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButton),
            new FrameworkPropertyMetadata(typeof(HeButton)));
    }
}
