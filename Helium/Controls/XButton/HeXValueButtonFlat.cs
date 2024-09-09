using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Helium.Controls.Window;

namespace Helium.Controls.XButton;

public class HeXValueButtonFlat : HeXValueButtonBase {
    static HeXValueButtonFlat() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXValueButtonFlat),
            new FrameworkPropertyMetadata(typeof(HeXValueButtonFlat)));
    }
    
    protected override void OnClick() {
        base.OnClick();

        IsPopupOpened = false;
        IsPopupOpened = true;
    }
}
