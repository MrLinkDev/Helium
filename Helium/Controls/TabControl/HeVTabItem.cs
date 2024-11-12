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
    
    static HeVTabItem() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeVTabItem),
            new FrameworkPropertyMetadata(typeof(HeVTabItem)));
    }

    public HeVTabItem() {
        Width = 70;
        Height = 44;

        //Background = HeBrushes.PrimaryBrush500;
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
        base.OnMouseLeftButtonDown(e);

        
    }

    protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e) {
        base.OnPreviewMouseLeftButtonDown(e);

        IsPressed = true;
    }

    protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e) {
        base.OnPreviewMouseLeftButtonUp(e);
        
        IsPressed = false;
    }
    
    
}
