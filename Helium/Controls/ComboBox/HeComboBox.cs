using System.Windows;

namespace Helium.Controls.ComboBox;

public class HeComboBox : System.Windows.Controls.ComboBox {
    static HeComboBox() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeComboBox),
            new FrameworkPropertyMetadata(typeof(HeComboBox)));
    }
}
