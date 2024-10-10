using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using Helium.Controls.Window;
using Helium.Plot;

namespace HeliumDemo;

public partial class OpenGLDemo : HeWindow {

    public OpenGLDemo() {
        InitializeComponent();
    }

    private void OnValueChangedRed(object sender, RoutedPropertyChangedEventArgs<double> e) {
    }
    
    private void OnValueChangedGreen(object sender, RoutedPropertyChangedEventArgs<double> e) {
    }
    
    private void OnValueChangedBlue(object sender, RoutedPropertyChangedEventArgs<double> e) {
    }

    private void GetPtr(object sender, RoutedEventArgs e) {
    }

    private void FrameRateChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
        Plot.FrameRate = (int) e.NewValue;
    }
}

