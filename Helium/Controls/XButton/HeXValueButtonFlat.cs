using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Helium.Controls.Window;

namespace Helium.Controls.XButton;

public class HeXValueButtonFlat : HeXValueButtonBase {
    private bool IsMouseInside = false;
    private new bool IsPressed = false;
    
    static HeXValueButtonFlat() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXValueButtonFlat),
            new FrameworkPropertyMetadata(typeof(HeXValueButtonFlat)));
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
        Console.WriteLine("OnMouseLeftButtonDown");
        if (IsPopupOpened) {
            e.Handled = true;
            return;
        }

        IsPressed = true;
    }

    protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e) {
        Console.WriteLine("OnPreviewMouseLeftButtonDown");
        base.OnPreviewMouseLeftButtonDown(e);
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
        Console.WriteLine("OnMouseLeftButtonUp");
        base.OnMouseLeftButtonUp(e);
        
        if (!IsPressed) return;
        
        IsPopupOpened = true;
        IsPressed = false;
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();
        
        Popup? popup = GetTemplateChild("XButtonPopup") as Popup;
        
        if (popup == null) return;

        popup.MouseLeftButtonDown += HandlePopupClick;
        popup.MouseLeftButtonUp += HandlePopupClick;
        
        popup.Closed += PopupOnClosed;
    }
    
    private void PopupOnClosed(object? sender, EventArgs e) {
        Console.WriteLine("PopupOnClosed");
        IsPopupOpened = false;
    }

    private void HandlePopupClick(object sender, MouseButtonEventArgs e) {
        Console.WriteLine("HandlePopupClick");
        e.Handled = true;
    }
}
