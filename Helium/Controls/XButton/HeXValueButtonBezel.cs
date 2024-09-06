using System.Windows;

namespace Helium.Controls.XButton;

public class HeXValueButtonBezel : HeXValueButtonBase {

    static HeXValueButtonBezel() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXValueButtonBezel),
            new FrameworkPropertyMetadata(typeof(HeXValueButtonBezel)));
    }
}
