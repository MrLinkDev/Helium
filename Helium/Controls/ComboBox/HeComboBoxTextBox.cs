using System.Windows;
using System.Windows.Controls;

namespace Helium.Controls.ComboBox;

public class HeComboBoxTextBox : TextBox {
    static HeComboBoxTextBox() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeComboBoxTextBox),
            new FrameworkPropertyMetadata(typeof(HeComboBoxTextBox)));
    }
}
