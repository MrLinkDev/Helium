using System.Windows;
using System.Windows.Controls;

namespace Helium.Controls.VerticalTabControl;

public class HeVerticalTabItem : System.Windows.Controls.TabItem {
    
    #region IsPressed

    public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register(
        nameof(IsPressed),
        typeof(bool),
        typeof(HeVerticalTabItem),
        new FrameworkPropertyMetadata(false));

    public bool IsPressed {
        get => (bool)GetValue(IsPressedProperty);
        set => SetValue(IsPressedProperty, value);
    }

    #endregion

    #region Level

    public static readonly DependencyProperty LevelProperty = HeVerticalTabControl.LevelProperty.AddOwner(
            typeof(HeVerticalTabItem), 
            new FrameworkPropertyMetadata());

    public int Level {
        get => (int)GetValue(LevelProperty);
        set => SetValue(LevelProperty, value);
    }

    #endregion
    
    static HeVerticalTabItem() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeVerticalTabItem),
            new FrameworkPropertyMetadata(typeof(HeVerticalTabItem)));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        Grid grid = (Grid)GetTemplateChild("Root");
        
        grid.PreviewMouseLeftButtonDown += (sender, args) => {
            IsPressed = true;
            
            // if (Level == 0 && IsSelected) {
            //     IsSelected = !IsSelected;
            //     args.Handled = true;
            // }

        };
        grid.PreviewMouseLeftButtonUp += (sender, args) => {
            IsPressed = false;
        };
        
        grid.MouseLeave += (sender, args) => IsPressed = false;
    }
    
    
}
