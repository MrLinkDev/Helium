using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Helium.Controls.TabControl;

public class HeVTabControl : System.Windows.Controls.TabControl {

    private Border? contentBorder;
    private bool initSelectionChangedEvent = true;
    
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
    
    #region Level

    public static readonly DependencyProperty LevelProperty = DependencyProperty.RegisterAttached(
        nameof(Level),
        typeof(int),
        typeof(HeVTabControl),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Inherits));

    public static int GetIsTransparent(HeVTabControl element) {
        return (int)element.GetValue(LevelProperty);
    }

    public static void SetIsTransparent(HeVTabControl element, int value) {
        element.SetValue(LevelProperty, value);
    }

    public int Level {
        get => (int)GetValue(LevelProperty);
        set => SetValue(LevelProperty, value);
    }

    #endregion
    
    static HeVTabControl() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeVTabControl),
            new FrameworkPropertyMetadata(typeof(HeVTabControl)));
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
                SelectedIndex = -1;
            }
            
            contentBorder!.Visibility = SelectedIndex == -1 ? Visibility.Collapsed : Visibility.Visible;
        }
        
    }
}
