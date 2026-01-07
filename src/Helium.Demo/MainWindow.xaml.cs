using System.Drawing;
using System.Windows;
using Helium.Resources;
using Helium.Utilities;

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

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
        HeThemeSwapper.Swap();
    }
}
