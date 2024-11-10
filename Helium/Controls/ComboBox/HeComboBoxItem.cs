using System.Windows;
using System.Windows.Controls;

namespace Helium.Controls.ComboBox;

public class HeComboBoxItem : ComboBoxItem {
    static HeComboBoxItem() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeComboBoxItem),
            new FrameworkPropertyMetadata(typeof(HeComboBoxItem)));
    }
}
