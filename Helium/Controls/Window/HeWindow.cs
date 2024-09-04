using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Helium.Controls.Button;
using Helium.Controls.ImageButton;

namespace Helium.Controls.Window;

public class HeWindow : System.Windows.Window {
    private Thickness maximizedWindowThickness = new Thickness(8);
    private Thickness normalWindowThickness = new Thickness(0);

    private HeImageButtonBase? maximizeButton;

    private BitmapImage maximizeIcon;
    private BitmapImage normalizeIcon;

    private bool doubleClick = false;

    #region DependencyProperties

    public static readonly DependencyProperty AppIconProperty = DependencyProperty.Register(
        nameof(AppIcon),
        typeof(ImageSource),
        typeof(HeWindow),
        new FrameworkPropertyMetadata(
            new BitmapImage(
                new Uri("pack://application:,,,/Helium;component/Resources/Icons/app_icon.png"))));

    public static readonly DependencyProperty ToolbarAccentProperty = DependencyProperty.Register(
        nameof(ToolbarAccent),
        typeof(Color),
        typeof(HeWindow),
        new FrameworkPropertyMetadata(ColorConverter.ConvertFromString("#41528c")));

    public static readonly DependencyProperty BodyBackgroundProperty = DependencyProperty.Register(
        nameof(BodyBackground),
        typeof(Brush),
        typeof(HeWindow),
        new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(33, 33, 33))));
    
    public static readonly DependencyProperty ToolbarContentProperty = DependencyProperty.Register(
        nameof(ToolbarContent),
        typeof(object),
        typeof(HeWindow),
        new FrameworkPropertyMetadata(null));

    #endregion

    #region Properties

    public ImageSource AppIcon {
        get => (ImageSource)GetValue(AppIconProperty);
        set => SetValue(AppIconProperty, value);
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

    static HeWindow() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeWindow),
            new FrameworkPropertyMetadata(typeof(HeWindow)));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        maximizeIcon = new BitmapImage(
            new Uri("pack://application:,,,/Helium;component/Resources/Icons/maximize_icon.png"));
        normalizeIcon = new BitmapImage(
            new Uri("pack://application:,,,/Helium;component/Resources/Icons/default_icon.png"));

        DockPanel? panel = GetTemplateChild("WindowToolbar") as DockPanel;

        maximizeButton = GetTemplateChild("MaximizeButton") as HeImageButtonBase;
        HeImageButtonBase? minimizeButton = GetTemplateChild("MinimizeButton") as HeImageButtonBase;
        HeImageButtonBase? closeButton = GetTemplateChild("CloseButton") as HeImageButtonBase;
        
        SizeChanged += OnSizeChanged;

        if (panel != null && minimizeButton != null && maximizeButton != null && closeButton != null)
            SetupWindowToolbar(panel, minimizeButton, maximizeButton, closeButton);
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs e) {
        if (WindowState == WindowState.Maximized) {
            BorderThickness = maximizedWindowThickness;
            maximizeButton!.ImageSource = normalizeIcon;
        } else if (WindowState == WindowState.Normal) {
            BorderThickness = normalWindowThickness;
            maximizeButton!.ImageSource = maximizeIcon;
        }
    }

    private void SetupWindowToolbar(DockPanel panel, HeImageButtonBase minimizeButton, HeImageButtonBase maximizeButton,
        HeImageButtonBase closeButton) {
        panel.MouseLeftButtonDown += OnMouseDown;
        
        panel.MouseMove += OnMouseMove;

        minimizeButton.Click += MinimizeButtonOnClick;
        maximizeButton.Click += MaximizeButtonOnClick;
        closeButton.Click += CloseButtonOnClick;
    }

    private void MinimizeButtonOnClick(object sender, RoutedEventArgs e) {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeButtonOnClick(object sender, RoutedEventArgs e) {
        if (WindowState == WindowState.Maximized) WindowState = WindowState.Normal;
        else WindowState = WindowState.Maximized;
    }

    private void CloseButtonOnClick(object sender, RoutedEventArgs e) {
        Close();
    }

    private void OnMouseDown(object sender, MouseButtonEventArgs e) {
        doubleClick = false;
        
        if (e.ClickCount == 2) {
            doubleClick = true;
            
            switch (WindowState) {
                case WindowState.Normal:
                    WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    WindowState = WindowState.Normal;
                    break;
            }
        }
    }

    private void OnMouseMove(object sender, MouseEventArgs e) {
        if (e.LeftButton != MouseButtonState.Pressed) return;
        Console.WriteLine("Move");

        if (WindowState == WindowState.Maximized && !doubleClick) {
            WindowState = WindowState.Normal;

            var pointerPosition = e.GetPosition(this);

            var x = pointerPosition.X - RestoreBounds.Width / 2;
            if (x < 0) x = 0;

            Left = x;
            Top = pointerPosition.Y - 24;
        }

        DragMove();
    }
}
