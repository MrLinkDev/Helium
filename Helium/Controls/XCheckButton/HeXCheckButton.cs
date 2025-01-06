using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Helium.Controls.Button;
using Helium.Resources;

namespace Helium.Controls.XCheckButton;

public class HeXCheckButton : System.Windows.Controls.RadioButton {
    
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
    
    #region IsActive

    public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
        nameof(IsActive),
        typeof(bool),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(false,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public bool IsActive {
        get => (bool)GetValue(IsActiveProperty);
        set {
            SetValue(IsActiveProperty, value);
            IsActiveCommand?.Execute((Id, value));

            if (!value) IsChecked = false;
        }
    }

    #endregion
    
    #region Text

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(string.Empty));

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion

    #region IsActiveCommand

    public static readonly DependencyProperty IsActiveCommandProperty = DependencyProperty.Register(
        nameof(IsActiveCommand),
        typeof(ICommand),
        typeof(HeXCheckButton),
        new FrameworkPropertyMetadata(null));

    public ICommand? IsActiveCommand {
        get => (ICommand?)GetValue(IsActiveCommandProperty);
        set => SetValue(IsActiveCommandProperty, value);
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
        Checked += (sender, args) => IsCheckedCommand?.Execute((Id, true));
        Unchecked += (sender, args) => IsCheckedCommand?.Execute((Id, false));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        if (GetTemplateChild("CheckButton") is not HeButton button) return;
        button.Click += OnCheckButtonClick;

        if (GetTemplateChild("Indicator") is not Border indicator) return;

        Click += (sender, args) => {
            if (indicator.IsMouseOver) IsActive = !IsActive;
        };
    }

    private void OnCheckButtonClick(object sender, RoutedEventArgs routedEventArgs) {
        if (!IsActive) IsActive = true;
        IsChecked = true;
    }
}
