using System.Windows;

namespace Helium.Controls.XButton;

public class HeXValueButtonFlat : HeXValueButtonBase {
    
    static HeXValueButtonFlat() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXValueButtonFlat),
            new FrameworkPropertyMetadata(typeof(HeXValueButtonFlat)));
    }
}
