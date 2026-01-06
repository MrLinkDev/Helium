using System.Drawing;
using System.Windows;
using Helium.Resources;

namespace HeliumDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
///

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        DataContext = this;
    }
}
