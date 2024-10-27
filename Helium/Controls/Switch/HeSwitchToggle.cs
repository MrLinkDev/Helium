using System.Windows;
using System.Windows.Controls.Primitives;
using Helium.Controls.Switch.Utilities;

namespace Helium.Controls.Switch;

public class HeSwitchToggle : System.Windows.Controls.RadioButton {

    public int Index {
        private set;
        get;
    }
    
    #region HeSwitchTogglePosition

    public static readonly DependencyProperty HeSwitchTogglePositionProperty = DependencyProperty.Register(
        nameof(HeSwitchTogglePosition),
        typeof(HeSwitchTogglePosition),
        typeof(HeSwitchToggle),
        new FrameworkPropertyMetadata(HeSwitchTogglePosition.Center, FrameworkPropertyMetadataOptions.AffectsRender));
    
    public HeSwitchTogglePosition HeSwitchTogglePosition {
        get => (HeSwitchTogglePosition)GetValue(HeSwitchTogglePositionProperty);
        set => SetValue(HeSwitchTogglePositionProperty, value);
    }
    
    #endregion
    
    #region CornerRadius

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeSwitchToggle),
        new FrameworkPropertyMetadata(new CornerRadius(0.0), 
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
        typeof(HeSwitchToggle),
        new FrameworkPropertyMetadata(string.Empty, 
            FrameworkPropertyMetadataOptions.AffectsRender));
    
    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion
    
    static HeSwitchToggle() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeSwitchToggle),
            new FrameworkPropertyMetadata(typeof(HeSwitchToggle)));
    }

    public HeSwitchToggle(int index) {
        Index = index;
    }
}
