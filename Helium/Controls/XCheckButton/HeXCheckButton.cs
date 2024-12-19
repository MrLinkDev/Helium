using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Helium.Resources;

namespace Helium.Controls.XCheckButton;

public class HeXCheckButton : System.Windows.Controls.RadioButton {

    private bool skipOnMouseLeftButtonUpEvent = false;
    
    #region CornerRadius

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(new CornerRadius(2),
            FrameworkPropertyMetadataOptions.AffectsRender));

    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion
    
    #region Id

    public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
        nameof(Id),
        typeof(int),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(-1,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public int Id {
        get => (int)GetValue(IdProperty);
        set => SetValue(IdProperty, value);
    }

    #endregion
    
    #region IsOn

    public static readonly DependencyProperty IsOnProperty = DependencyProperty.Register(
        nameof(IsOn),
        typeof(bool),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(false,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public bool IsOn {
        get => (bool)GetValue(IsOnProperty);
        set {
            SetValue(IsOnProperty, value);
            IsOnCommand?.Execute(value);
        }
    }

    #endregion
    
    #region Content

    public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(object),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(null));

    public new object? Content {
        get => (object?)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    #endregion

    #region IsOnCommand

    public static readonly DependencyProperty IsOnCommandProperty = DependencyProperty.Register(
        nameof(IsOnCommand),
        typeof(ICommand),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(null));

    public ICommand? IsOnCommand {
        get => (ICommand?)GetValue(IsOnCommandProperty);
        set => SetValue(IsOnCommandProperty, value);
    }

    #endregion
    
    #region IsCheckedCommand

    public static readonly DependencyProperty IsCheckedCommandProperty = DependencyProperty.Register(
        nameof(IsCheckedCommand),
        typeof(ICommand),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(null));

    public ICommand? IsCheckedCommand {
        get => (ICommand?)GetValue(IsCheckedCommandProperty);
        set => SetValue(IsCheckedCommandProperty, value);
    }

    #endregion

    static HeXCheckButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXCheckButton),
            new FrameworkPropertyMetadata(typeof(HeXCheckButton)));
    }

    public HeXCheckButton() {
        Checked += (sender, args) => IsCheckedCommand?.Execute(true);
        Unchecked += (sender, args) => IsCheckedCommand?.Execute(false);
    }

    protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e) {
        base.OnPreviewMouseLeftButtonUp(e);

        if (!IsChecked.HasValue) return;

        if (!IsOn) {
            IsOn = true;
            return;
        }
        
        if (IsOn && IsChecked.Value) {
            skipOnMouseLeftButtonUpEvent = true;
        }
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
        base.OnMouseLeftButtonUp(e);

        if (skipOnMouseLeftButtonUpEvent) {
            IsChecked = false;
            IsCheckedCommand?.Execute(IsChecked);
            
            IsOn = false;

            skipOnMouseLeftButtonUpEvent = false;
        }
    }
}
