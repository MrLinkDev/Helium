using System.Windows;
using System.Windows.Controls;

namespace Helium.CardView;


public class HeCardView : ContentControl {

    static HeCardView() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeCardView),
            new FrameworkPropertyMetadata(typeof(HeCardView)));
    }
}
