using System.Windows;

namespace HeliumDemo;

public partial class GlExternalWindow : Window {
    private Timer? timer;
    
    public GlExternalWindow(bool autoClose = false) {
        InitializeComponent();

        if (autoClose) {
            timer = new Timer(CloseInt, null, 400, 0);
        }
    }

    private void CloseInt(object? o) {
        Application.Current.Dispatcher.Invoke(Close);
    }
}

