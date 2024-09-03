using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Helium.ImageButton;

public class HeImageButtonFlat : HeImageButtonBase {
    
    static HeImageButtonFlat() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonFlat),
            new FrameworkPropertyMetadata(typeof(HeImageButtonFlat)));
    }
}
