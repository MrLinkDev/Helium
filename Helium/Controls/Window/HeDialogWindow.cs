using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Helium.Controls.Button;
using Helium.Controls.ImageButton;

namespace Helium.Controls.Window;

public class HeDialogWindow : System.Windows.Window {
    #region DependencyProperties

    public static readonly DependencyProperty AppIconProperty = DependencyProperty.Register(
        nameof(AppIcon),
        typeof(ImageSource),
        typeof(HeDialogWindow),
        new FrameworkPropertyMetadata(
            new BitmapImage(
                new Uri("pack://application:,,,/Alexander.Gorbunov.Helium;component/Resources/Icons/app_icon.png"))));

    public static readonly DependencyProperty WindowTitleProperty = DependencyProperty.Register(
        nameof(WindowTitle),
        typeof(string),
        typeof(HeDialogWindow),
        new FrameworkPropertyMetadata("Helium Window"));

    public static readonly DependencyProperty ToolbarAccentProperty = DependencyProperty.Register(
        nameof(ToolbarAccent),
        typeof(Color),
        typeof(HeDialogWindow),
        new FrameworkPropertyMetadata(ColorConverter.ConvertFromString("#41528c")));

    public static readonly DependencyProperty BodyBackgroundProperty = DependencyProperty.Register(
        nameof(BodyBackground),
        typeof(Brush),
        typeof(HeDialogWindow),
        new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(33, 33, 33))));

    public static readonly DependencyProperty ToolbarContentProperty = DependencyProperty.Register(
        nameof(ToolbarContent),
        typeof(object),
        typeof(HeDialogWindow),
        new FrameworkPropertyMetadata(null));

    #endregion

    #region Properties

    public ImageSource AppIcon {
        get => (ImageSource)GetValue(AppIconProperty);
        set => SetValue(AppIconProperty, value);
    }

    public string WindowTitle {
        get => (string)GetValue(WindowTitleProperty);
        set => SetValue(WindowTitleProperty, value);
    }

    public Color ToolbarAccent {
        get => (Color)GetValue(ToolbarAccentProperty);
        set => SetValue(ToolbarAccentProperty, value);
    }

    public Brush BodyBackground {
        get => (Brush)GetValue(BodyBackgroundProperty);
        set => SetValue(BodyBackgroundProperty, value);
    }

    public object? ToolbarContent {
        get => (object?)GetValue(ToolbarContentProperty);
        set => SetValue(ToolbarContentProperty, value);
    }

    #endregion

    static HeDialogWindow() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeDialogWindow),
            new FrameworkPropertyMetadata(typeof(HeDialogWindow)));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        DockPanel? panel = GetTemplateChild("WindowToolbar") as DockPanel;
        HeImageButton? closeButton = GetTemplateChild("CloseButton") as HeImageButton;

        if (panel != null && closeButton != null)
            SetupWindowToolbar(panel, closeButton);
    }

    private void SetupWindowToolbar(DockPanel panel, HeImageButton closeButton) {
        panel.MouseLeftButtonDown += OnMouseDown;
        
        closeButton.Click += CloseButtonOnClick;
    }

    private void CloseButtonOnClick(object sender, RoutedEventArgs e) {
        Close();
    }

    private void OnMouseDown(object sender, MouseButtonEventArgs e) {
        if (e.ClickCount == 1) {
            DragMove();
        }
    }
}