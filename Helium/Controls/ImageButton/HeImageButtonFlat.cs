using System.Windows;

namespace Helium.Controls.ImageButton;

public class HeImageButtonFlat : HeImageButtonBase {
    
    static HeImageButtonFlat() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonFlat),
            new FrameworkPropertyMetadata(typeof(HeImageButtonFlat)));
    }
}
