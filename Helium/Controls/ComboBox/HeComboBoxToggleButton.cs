using System.Windows;
using System.Windows.Controls.Primitives;

namespace Helium.Controls.ComboBox;

public class HeComboBoxToggleButton : ToggleButton {
    static HeComboBoxToggleButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeComboBoxToggleButton),
            new FrameworkPropertyMetadata(typeof(HeComboBoxToggleButton)));
    }
}
