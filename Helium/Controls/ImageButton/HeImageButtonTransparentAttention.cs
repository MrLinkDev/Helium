using System.Windows;

namespace Helium.Controls.ImageButton;

public class HeImageButtonFlatTransparentAttention : HeImageButtonBase {
    
    static HeImageButtonFlatTransparentAttention() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonFlatTransparentAttention),
            new FrameworkPropertyMetadata(typeof(HeImageButtonFlatTransparentAttention)));
    }
}
