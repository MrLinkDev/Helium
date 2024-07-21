using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Helium.ImageButton;


public class HeImageButton : ButtonBase {
    static HeImageButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButton),
            new FrameworkPropertyMetadata(typeof(HeImageButton)));
    }
}
