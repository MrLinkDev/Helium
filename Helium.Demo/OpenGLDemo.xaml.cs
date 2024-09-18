using System.Windows;
using System.Windows.Input;
using Helium.Controls.Window;

namespace HeliumDemo;

public partial class OpenGLDemo : HeWindow {
    public OpenGLDemo() {
        InitializeComponent();
    }

    private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
        Console.WriteLine("Pressed");
    }
}

