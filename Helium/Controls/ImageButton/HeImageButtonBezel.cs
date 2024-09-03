using System.Windows;

namespace Helium.Controls.ImageButton;

public class HeImageButtonBezel : HeImageButtonBase {
    
    static HeImageButtonBezel() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonBezel),
            new FrameworkPropertyMetadata(typeof(HeImageButtonBezel)));
    }
}
