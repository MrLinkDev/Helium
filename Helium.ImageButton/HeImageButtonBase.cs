using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Helium.ImageButton;


public class HeImageButtonBase : ButtonBase {
    
    /**

    #region DependencyProperties

    public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
        nameof(Image),
        typeof(ImageSource),
        typeof(HeImageButtonBase),
        new FrameworkPropertyMetadata(null));

    #endregion

    #region Properties

    public ImageSource Image {
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    #endregion
    
    */
    
    static HeImageButtonBase() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeImageButtonBase),
            new FrameworkPropertyMetadata(typeof(HeImageButtonBase)));
    }
}
