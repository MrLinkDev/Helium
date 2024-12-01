using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Helium.Resources;

namespace Helium.Controls.XCheckButton;

public class HeXCheckButton : System.Windows.Controls.RadioButton {

    private bool skipOnMouseLeftButtonUpEvent = false;
    
    #region CornerRadius

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(new CornerRadius(2),
            FrameworkPropertyMetadataOptions.AffectsRender));

    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion
    
    #region IsOn

    public static readonly DependencyProperty IsOnProperty = DependencyProperty.Register(
        nameof(IsOn),
        typeof(bool),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(false,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public bool IsOn {
        get => (bool)GetValue(IsOnProperty);
        set => SetValue(IsOnProperty, value);
    }

    #endregion

    #region Content

    public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(object),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(null));

    public new object? Content {
        get => (object?)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    #endregion

    static HeXCheckButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXCheckButton),
            new FrameworkPropertyMetadata(typeof(HeXCheckButton)));
    }

    protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e) {
        base.OnPreviewMouseLeftButtonUp(e);

        if (!IsChecked.HasValue) return;

        if (!IsOn) {
            IsOn = true;
            return;
        }
        
        if (IsOn && IsChecked.Value) {
            skipOnMouseLeftButtonUpEvent = true;
        }
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
        base.OnMouseLeftButtonUp(e);

        if (skipOnMouseLeftButtonUpEvent) {
            IsChecked = false;
            IsOn = false;

            skipOnMouseLeftButtonUpEvent = false;
        }
    }
}
