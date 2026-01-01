using System.ComponentModel;
using System.Runtime.CompilerServices;
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
using Helium.Controls.Indicator.Utilities;
using Helium.Controls.MessageBox;
using Helium.Controls.Window;

namespace HeliumDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
///

public partial class MainWindow : HeWindow {
    

    public MainWindow() {
        InitializeComponent();
        DataContext = this;
    }
}