using System.Windows;
using System.Windows.Controls;

namespace Helium.Controls.VerticalTabControl;

public class HeVerticalTabControl : System.Windows.Controls.TabControl {

    private Border? contentBorder;
    private bool initSelectionChangedEvent = true;
    
    #region HeVTabPanelPosition

    public static readonly DependencyProperty TabPanelPositionProperty = DependencyProperty.Register(
        nameof(TabPanelPosition),
        typeof(HeVerticalTabPanelPosition),
        typeof(HeVerticalTabControl),
        new FrameworkPropertyMetadata(HeVerticalTabPanelPosition.Left));

    public HeVerticalTabPanelPosition TabPanelPosition {
        get => (HeVerticalTabPanelPosition)GetValue(TabPanelPositionProperty);
        set => SetValue(TabPanelPositionProperty, value);
    }

    #endregion
    
    #region Level

    public static readonly DependencyProperty LevelProperty = DependencyProperty.RegisterAttached(
        nameof(Level),
        typeof(int),
        typeof(HeVerticalTabControl),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Inherits));

    public static int GetIsTransparent(HeVerticalTabControl element) {
        return (int)element.GetValue(LevelProperty);
    }

    public static void SetIsTransparent(HeVerticalTabControl element, int value) {
        element.SetValue(LevelProperty, value);
    }

    public int Level {
        get => (int)GetValue(LevelProperty);
        set => SetValue(LevelProperty, value);
    }

    #endregion
    
    static HeVerticalTabControl() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeVerticalTabControl),
            new FrameworkPropertyMetadata(typeof(HeVerticalTabControl)));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        contentBorder = (Border)GetTemplateChild("Border");
    }

    protected override void OnSelectionChanged(SelectionChangedEventArgs e) {
        base.OnSelectionChanged(e);

        if (Level == 0) {
            if (initSelectionChangedEvent) {
                initSelectionChangedEvent = false;
                SelectedIndex = 0;
            }
            
            contentBorder!.Visibility = SelectedIndex == -1 ? Visibility.Collapsed : Visibility.Visible;
        }
        
    }
}
