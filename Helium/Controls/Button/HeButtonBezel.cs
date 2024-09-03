using System.Windows;

namespace Helium.Controls.Button;

public class HeButtonBezel : HeButtonBase {

    static HeButtonBezel() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButtonBezel),
            new FrameworkPropertyMetadata(typeof(HeButtonBezel)));
    }
}
