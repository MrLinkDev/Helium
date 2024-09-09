using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Helium.Controls.Button;
using Helium.Controls.ImageButton;

namespace Helium.Controls.Window;

public class HeXWindow : System.Windows.Window {

    static HeXWindow() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXWindow),
            new FrameworkPropertyMetadata(typeof(HeXWindow)));
    }
}
