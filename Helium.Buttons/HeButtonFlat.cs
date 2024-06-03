using System.Windows;
using System.Windows.Controls.Primitives;

namespace Helium.Buttons;

public class HeButtonFlat : HeButtonBase {
    
    static HeButtonFlat() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButtonFlat),
            new FrameworkPropertyMetadata(typeof(HeButtonFlat)));
    }
}
