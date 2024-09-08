using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Helium.Resources;

namespace Helium.Controls.XButton;

public class HeXValueButtonBase : ButtonBase {

    private bool isInValueInputMode = false;
    
    #region CornerRadius

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeXValueButtonBase),
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
        typeof(HeXValueButtonBase),
        new FrameworkPropertyMetadata(string.Empty, 
            FrameworkPropertyMetadataOptions.AffectsRender));

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion
    
    #region ValueBackground

    public static readonly DependencyProperty ValueBackgroundProperty = DependencyProperty.Register(
        nameof(ValueBackground),
        typeof(Brush),
        typeof(HeXValueButtonBase),
        new FrameworkPropertyMetadata(HeBrushes.PrimaryBrush700));

    public Brush ValueBackground {
        get => (Brush)GetValue(ValueBackgroundProperty);
        set => SetValue(ValueBackgroundProperty, value);
    }

    #endregion

    protected override void OnClick() {
        base.OnClick();

        isInValueInputMode = !isInValueInputMode;
        if (isInValueInputMode) {
            
        } else {
            
        }
    }
}
