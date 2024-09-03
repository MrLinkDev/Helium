using System.Windows;

namespace Helium.Controls.ImageButton;

public class HeImageButtonFlatTransparent : HeImageButtonBase {
    
    static HeImageButtonFlatTransparent() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonFlatTransparent),
            new FrameworkPropertyMetadata(typeof(HeImageButtonFlatTransparent)));
    }
}
