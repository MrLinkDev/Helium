using System.Windows;

namespace Helium.ImageButton;

public class HeImageButtonBezel : HeImageButtonBase {
    
    static HeImageButtonBezel() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonBezel),
            new FrameworkPropertyMetadata(typeof(HeImageButtonBezel)));
    }
}
