using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Basic;

public class HeButton : Control {

    #region DependencyProperties

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeButton),
        new PropertyMetadata(new CornerRadius(2)));

    #endregion

    #region Properties

    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion
    
    static HeButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeButton),
            new FrameworkPropertyMetadata(typeof(HeButton)));
    }
}
