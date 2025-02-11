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
        Window window;
        
        if (e.Args.Length > 0 && e.Args[0] == "-gl")
            window = new OpenGLDemo();
        else {
            window = new MainWindow();
        }

        MainWindow = window;
        MainWindow.Show();
    }
}