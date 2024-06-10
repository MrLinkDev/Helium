using System.Windows;

namespace Helium.Window;

public class HeWindow : System.Windows.Window {
    static HeWindow() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeWindow),
            new FrameworkPropertyMetadata(typeof(HeWindow)));
    }
}
