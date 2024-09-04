using System.Windows;

namespace Helium.Controls.RadioButton;

public class HeRadioButton : System.Windows.Controls.RadioButton {
    static HeRadioButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeRadioButton),
            new FrameworkPropertyMetadata(typeof(HeRadioButton)));
    }
}
