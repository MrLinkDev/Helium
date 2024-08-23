using System.Windows;
using System.Windows.Controls.Primitives;

namespace Helium.Button;

public class HeButtonBezel : HeButtonBase {

    static HeButtonBezel() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButtonBezel),
            new FrameworkPropertyMetadata(typeof(HeButtonBezel)));
    }
}
