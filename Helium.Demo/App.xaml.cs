using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace HeliumDemo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application {
    private void App_OnStartup(object sender, StartupEventArgs e) {
        Window window = Keyboard.Modifiers == ModifierKeys.Control ? new MainWindow() : new OpenGLDemo();

        MainWindow = window;
        MainWindow.Show();
    }
}