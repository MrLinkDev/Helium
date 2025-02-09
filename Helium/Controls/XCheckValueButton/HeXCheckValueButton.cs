using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Helium.Controls.Button;
using Helium.Controls.XValueButton;
using Helium.Controls.XValueButton.Utilities;

namespace Helium.Controls.XCheckValueButton;

public class HeXCheckValueButton : System.Windows.Controls.RadioButton {
    
    #region CornerRadius

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeXCheckValueButton),
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
        typeof(HeXCheckValueButton),
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
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(false,
            FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool IsActive {
        get => (bool)GetValue(IsActiveProperty);
        set {
            SetValue(IsActiveProperty, value);
            IsActiveCommand?.Execute((Id, value));

            if (!value) IsChecked = false;
        }
    }

    #endregion

    #region IsActiveCommand

    public static readonly DependencyProperty IsActiveCommandProperty = DependencyProperty.Register(
        nameof(IsActiveCommand),
        typeof(ICommand),
        typeof(HeXCheckValueButton),
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
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(null));

    public ICommand? IsCheckedCommand {
        get => (ICommand?)GetValue(IsCheckedCommandProperty);
        set => SetValue(IsCheckedCommandProperty, value);
    }

    #endregion
    
    #region SetValueCommand

    public static readonly DependencyProperty SetValueCommandProperty = DependencyProperty.Register(
        nameof(SetValueCommand),
        typeof(ICommand),
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(null));

    public ICommand? SetValueCommand {
        get => (ICommand?)GetValue(SetValueCommandProperty);
        set => SetValue(SetValueCommandProperty, value);
    }

    #endregion
    
    #region XValueType

    public static readonly DependencyProperty XValueTypeProperty = DependencyProperty.Register(
        nameof(XValueType),
        typeof(HeXValueType),
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(HeXValueType.NONE));

    public HeXValueType XValueType {
        get => (HeXValueType)GetValue(XValueTypeProperty);
        set => SetValue(XValueTypeProperty, value);
    }

    #endregion
    
    #region ValueName

    public static readonly DependencyProperty ValueNameProperty = DependencyProperty.Register(
        nameof(ValueName),
        typeof(string),
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(string.Empty,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public string ValueName {
        get => (string)GetValue(ValueNameProperty);
        set => SetValue(ValueNameProperty, value);
    }

    #endregion

    #region FullValueName

    public static readonly DependencyProperty FullValueNameProperty = DependencyProperty.Register(
        nameof(FullValueName),
        typeof(string),
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(string.Empty,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public string FullValueName {
        // TODO: Разобраться, почему не работает
        get {
            var fullValueName = (string)GetValue(FullValueNameProperty);
            if (string.IsNullOrEmpty(fullValueName)) {
                fullValueName = (string)GetValue(ValueNameProperty);
            }

            return fullValueName + ":";
        }
        set => SetValue(FullValueNameProperty, value);
    }

    #endregion
    
    #region Value

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value),
        typeof(double),
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(
            0.0,
            FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
            ValuePropertyChangedCallback));

    private static void ValuePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        HeXCheckValueButton button = (HeXCheckValueButton)d;
        button.Value = (double)e.NewValue;
    }

    public double Value {
        get => (double)GetValue(ValueProperty);
        set {
            SetValue(ValueProperty, value);
            SetXButtonValue(value);
        
            SetValueCommand?.Execute((Id, value));
        }
    }

    #endregion

    #region MinValue

    public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
        nameof(MinValue),
        typeof(double),
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(double.NegativeInfinity,
            FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    
    public double MinValue {
        get => (double)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    #endregion

    #region MaxValue

    public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
        nameof(MaxValue),
        typeof(double),
        typeof(HeXCheckValueButton),
        new FrameworkPropertyMetadata(double.PositiveInfinity,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public double MaxValue {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    #endregion

    static HeXCheckValueButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXCheckValueButton),
            new FrameworkPropertyMetadata(typeof(HeXCheckValueButton)));
    }

    public HeXCheckValueButton() {
        Checked += (sender, args) => IsCheckedCommand?.Execute((Id, true));
        Unchecked += (sender, args) => IsCheckedCommand?.Execute((Id, false));
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        if (GetTemplateChild("CheckButton") is HeXCheckValueButtonPart button) {
            button.Click += OnCheckButtonClick;
            button.ValueUpdated += value => SetValue(ValueProperty, value);
        }

        if (GetTemplateChild("Indicator") is Border indicator) {
            Click += (sender, args) => {
                if (indicator.IsMouseOver) IsActive = !IsActive;
            };
        }

    }

    private void SetXButtonValue(double value) {
        if (GetTemplateChild("CheckButton") is HeXCheckValueButtonPart button) {
            button.Value = value;
        }
    }

    private void OnCheckButtonClick(object sender, RoutedEventArgs routedEventArgs) {
        if (!IsActive) IsActive = true;
        IsChecked = true;
    }
}
