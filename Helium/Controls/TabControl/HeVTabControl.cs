using System.Windows;
using System.Windows.Input;

namespace Helium.Controls.TabControl;

public class HeVTabControl : System.Windows.Controls.TabControl {
    
    #region HeVTabPanelPosition

    public static readonly DependencyProperty TabPanelPositionProperty = DependencyProperty.Register(
        nameof(TabPanelPosition),
        typeof(HeVTabPanelPosition),
        typeof(HeVTabControl),
        new FrameworkPropertyMetadata(HeVTabPanelPosition.Right));

    public HeVTabPanelPosition TabPanelPosition {
        get => (HeVTabPanelPosition)GetValue(TabPanelPositionProperty);
        set => SetValue(TabPanelPositionProperty, value);
    }

    #endregion
    
    static HeVTabControl() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeVTabControl),
            new FrameworkPropertyMetadata(typeof(HeVTabControl)));
    }
    
    
}
