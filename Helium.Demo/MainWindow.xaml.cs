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
using Helium.Controls.Window;

namespace HeliumDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : HeWindow, INotifyPropertyChanged {
    public bool IsPressed { get; set; } = true;

    private double doubleData;

    public double DoubleData {
        get => doubleData;
        set => SetField(ref doubleData, value);
    }

    public MainWindow() {
        InitializeComponent();
        DataContext = this;

        ValidationErrorEnabled.Text = "Validation err enabled";
        ValidationErrorDisabled.Text = "Validation err disabled";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null) {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}