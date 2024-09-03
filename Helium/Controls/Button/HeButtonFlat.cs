using System.Windows;

namespace Helium.Controls.Button;

public class HeButtonFlat : HeButtonBase {
    
    static HeButtonFlat() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButtonFlat),
            new FrameworkPropertyMetadata(typeof(HeButtonFlat)));
    }
}
