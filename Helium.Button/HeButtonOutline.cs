using System.Windows;
using System.Windows.Controls.Primitives;

namespace Helium.Button;

public class HeButtonOutline : HeButtonBase {

    static HeButtonOutline() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButtonOutline),
            new FrameworkPropertyMetadata(typeof(HeButtonOutline)));
    }
}
