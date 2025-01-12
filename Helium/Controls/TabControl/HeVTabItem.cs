using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Helium.Resources;

namespace Helium.Controls.TabControl;

public class HeVTabItem : System.Windows.Controls.TabItem {
    
    #region IsPressed

    public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register(
        nameof(IsPressed),
        typeof(bool),
        typeof(HeVTabItem),
        new FrameworkPropertyMetadata(false));

    public bool IsPressed {
        get => (bool)GetValue(IsPressedProperty);
        set => SetValue(IsPressedProperty, value);
    }

    #endregion

    #region Level

    public static readonly DependencyProperty LevelProperty = HeVTabControl.LevelProperty.AddOwner(
            typeof(HeVTabItem), 
            new FrameworkPropertyMetadata());

    public int Level {
        get => (int)GetValue(LevelProperty);
        set => SetValue(LevelProperty, value);
    }

    #endregion
    
    static HeVTabItem() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeVTabItem),
            new FrameworkPropertyMetadata(typeof(HeVTabItem)));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        Grid grid = (Grid)GetTemplateChild("Root");
        
        grid.PreviewMouseLeftButtonDown += (sender, args) => {
            IsPressed = true;
            
            if (Level == 0 && IsSelected) {
                IsSelected = !IsSelected;
                args.Handled = true;
            }

        };
        grid.PreviewMouseLeftButtonUp += (sender, args) => {
            IsPressed = false;
        };
        
        grid.MouseLeave += (sender, args) => IsPressed = false;
    }
    
    
}
