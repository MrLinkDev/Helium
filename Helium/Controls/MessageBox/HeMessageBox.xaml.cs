using System.Windows;
using Helium.Controls.Window;

namespace Helium.Controls.MessageBox;

public partial class HeMessageBox : HeDialogWindow {

    public string MessageBoxTitle { get; }
    
    public string MessageBoxMessage { get; }
    
    private HeMessageBox(string title, string message, System.Windows.Window? owner) {
        MessageBoxTitle = title;
        MessageBoxMessage = message;

        if (owner != null) {
            Owner = owner;
        }
        
        InitializeComponent();
        DataContext = this;
        
    }

    public static void Show(string title, string message, System.Windows.Window? owner = null) {
        HeMessageBox box = new HeMessageBox(title, message, owner);
        box.ShowDialog();
    }

    private void CloseWindow(object sender, RoutedEventArgs e) {
        Close();
    }
}

