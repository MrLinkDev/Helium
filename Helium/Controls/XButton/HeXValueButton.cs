using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Helium.Controls.Button;
using Helium.Controls.EditText;
using Helium.Controls.ImageButton;
using Helium.Controls.XButton.Utilities;
using Helium.Resources;
using Helium.Utilities;

namespace Helium.Controls.XButton;

public class HeXValueButton : ButtonBase {
    private bool isPressed = false;

    private HeEditText editText;
    
    #region XValueType

    public static readonly DependencyProperty XValueTypeProperty = DependencyProperty.Register(
        nameof(XValueType),
        typeof(HeXValueType),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(HeXValueType.NONE));

    public HeXValueType XValueType {
        get => (HeXValueType)GetValue(XValueTypeProperty);
        set => SetValue(XValueTypeProperty, value);
    }

    #endregion

    #region HeType

    public static readonly DependencyProperty HeTypeProperty = DependencyProperty.Register(
        nameof(HeType),
        typeof(HeType),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(HeType.Flat));

    public HeType HeType {
        get => (HeType)GetValue(HeTypeProperty);
        set => SetValue(HeTypeProperty, value);
    }

    #endregion

    #region HeTheme

    public static readonly DependencyProperty HeThemeProperty = DependencyProperty.Register(
        nameof(HeTheme),
        typeof(HeTheme),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(HeTheme.Default));

    public HeTheme HeTheme {
        get => (HeTheme)GetValue(HeThemeProperty);
        set => SetValue(HeThemeProperty, value);
    }

    #endregion

    #region IsPopupOpened

    public static readonly DependencyProperty IsPopupOpenedProperty = DependencyProperty.Register(
        nameof(IsPopupOpened),
        typeof(bool),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(
            false,
            FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            null,
            null,
            false,
            UpdateSourceTrigger.PropertyChanged));

    public bool IsPopupOpened {
        get => (bool)GetValue(IsPopupOpenedProperty);
        set => SetValue(IsPopupOpenedProperty, value);
    }

    #endregion

    #region PopupPlacement

    public static readonly DependencyProperty PopupPlacementProperty = DependencyProperty.Register(
        nameof(PopupPlacement),
        typeof(PlacementMode),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(
            PlacementMode.Left,
            FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            null,
            null,
            false,
            UpdateSourceTrigger.PropertyChanged));

    public PlacementMode PopupPlacement {
        get => (PlacementMode)GetValue(PopupPlacementProperty);
        set => SetValue(PopupPlacementProperty, value);
    }

    #endregion

    #region CornerRadius

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
        nameof(CornerRadius),
        typeof(CornerRadius),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(new CornerRadius(2),
            FrameworkPropertyMetadataOptions.AffectsRender));

    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    #endregion

    #region ValueName

    public static readonly DependencyProperty ValueNameProperty = DependencyProperty.Register(
        nameof(ValueName),
        typeof(string),
        typeof(HeXValueButton),
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
        typeof(HeXValueButton),
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

    #region DisplayedValue

    public static readonly DependencyProperty DisplayedValueProperty = DependencyProperty.Register(
        nameof(DisplayedValue),
        typeof(string),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(string.Empty,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public string DisplayedValue {
        get => (string)GetValue(DisplayedValueProperty);
        set => SetValue(DisplayedValueProperty, value);
    }

    #endregion

    #region TempValue

    public static readonly DependencyProperty TempValueProperty = DependencyProperty.Register(
        nameof(TempValue),
        typeof(string),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(
            string.Empty,
            FrameworkPropertyMetadataOptions.AffectsRender,
            null,
            null,
            false,
            UpdateSourceTrigger.PropertyChanged));

    public string TempValue {
        get => (string)GetValue(TempValueProperty);
        private set => SetValue(TempValueProperty, value);
    }

    #endregion

    #region Value

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value),
        typeof(double),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(0.0,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public double Value {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    #endregion

    #region MinValue

    public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
        nameof(MinValue),
        typeof(double),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(double.NegativeInfinity,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public double MinValue {
        get => (double)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    #endregion

    #region MaxValue

    public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
        nameof(MaxValue),
        typeof(double),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(double.PositiveInfinity,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public double MaxValue {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    #endregion

    #region ValueBackground

    public static readonly DependencyProperty ValueBackgroundProperty = DependencyProperty.Register(
        nameof(ValueBackground),
        typeof(Brush),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(HeBrushes.PrimaryBrush700));

    public Brush ValueBackground {
        get => (Brush)GetValue(ValueBackgroundProperty);
        set => SetValue(ValueBackgroundProperty, value);
    }

    #endregion

    static HeXValueButton() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeXValueButton),
            new FrameworkPropertyMetadata(typeof(HeXValueButton)));
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
        base.OnMouseLeftButtonDown(e);

        if (!IsPopupOpened) isPressed = true;
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
        base.OnMouseLeftButtonUp(e);

        if (!isPressed) return;

        IsPopupOpened = true;
        isPressed = false;
    }

    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        Popup? popup = GetTemplateChild("XButtonPopup") as Popup;
        if (popup == null) return;

        popup.MouseLeftButtonDown += HandleMouseDown;

        popup.Opened += PopupOnOpened;
        popup.Closed += PopupOnClosed;

        editText = (HeEditText)GetTemplateChild("EditText");
        editText.KeyDown += EditTextOnPreviewKeyDown;

        ProcessExpButtons();
        ConnectButtons();
    }
    
    #region EditText

    private void EditTextOnPreviewKeyDown(object sender, KeyEventArgs e) {
        if (!((e.Key >= Key.D0 && e.Key <= Key.D9) ||
              (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
              e.Key == Key.Decimal ||
              e.Key == Key.OemPeriod ||
              e.Key == Key.Subtract ||
              e.Key == Key.OemMinus ||
              e.Key == Key.Enter)) {
            e.Handled = true;
            return;
        }

        Console.WriteLine($"Key = {e.Key}");

        if (e.Key == Key.Decimal || e.Key == Key.OemPeriod) {
            AddDot();
            e.Handled = true;
        }

        if (e.Key == Key.Subtract || e.Key == Key.OemMinus) {
            ChangeSign();
            e.Handled = true;
        }

        if (e.Key == Key.Enter) {
            EnterValue();
            e.Handled = true;
        }
    }
    
    private void MoveCursorToEnd() {
        editText.SelectionStart = TempValue.Length;
        editText.SelectionLength = 0;
    }

    #endregion

    #region Buttons

    private void ProcessExpButtons() {
        var units = XValueType.GetUnits();
        var exp = XValueType.GetExp();
        
        for (int i = 0; i < exp.Length; i++) {
            if (GetTemplateChild($"ButtonExp{i + 1}") is not HeButton button) continue;
            
            button.Visibility = Visibility.Visible;
                
            if (units.Length > 0) button.Text = units[i];
            else button.Text = $"{exp[i]:0.##}";

            var expValue = exp[i];
            button.Click += (sender, args) => EnterValue(expValue);
        }
    }

    private void ConnectButtons() {
        if (GetTemplateChild("ButtonClose") is HeButton buttonClose) 
            buttonClose.Click += (sender, args) => Close();
        if (GetTemplateChild("ButtonClear") is HeButton buttonClear) 
            buttonClear.Click += (sender, args) => Clear();
        if (GetTemplateChild("ButtonBackspace") is HeImageButton buttonBackspace) 
            buttonBackspace.Click += (sender, args) => Backspace();

        ConnectNumberButtons();

        if (GetTemplateChild("ButtonDot") is HeButton buttonDot) 
            buttonDot.Click += (sender, args) => AddDot();
        if (GetTemplateChild("ButtonSign") is HeButton buttonSign) 
            buttonSign.Click += (sender, args) => ChangeSign();

        if (GetTemplateChild("ButtonEnter") is HeButton buttonEnter) 
            buttonEnter.Click += (sender, args) => EnterValue();
    }

    private void Close() {
        IsPopupOpened = false;
    }

    private void Clear() {
        TempValue = string.Empty;
    }

    private void Backspace() {
        if (editText.SelectionStart == 0 && editText.SelectionLength == TempValue.Length) {
            TempValue = string.Empty;
        } else {
            TempValue = TempValue[..^1];
        }

        MoveCursorToEnd();
    }

    private void ConnectNumberButtons() {
        if (GetTemplateChild("Button0") is HeButton buttonZero) buttonZero.Click += (sender, args) => AddValue('0');
        if (GetTemplateChild("Button1") is HeButton buttonOne) buttonOne.Click += (sender, args) => AddValue('1');
        if (GetTemplateChild("Button2") is HeButton buttonTwo) buttonTwo.Click += (sender, args) => AddValue('2');
        if (GetTemplateChild("Button3") is HeButton buttonThree) buttonThree.Click += (sender, args) => AddValue('3');
        if (GetTemplateChild("Button4") is HeButton buttonFour) buttonFour.Click += (sender, args) => AddValue('4');
        if (GetTemplateChild("Button5") is HeButton buttonFive) buttonFive.Click += (sender, args) => AddValue('5');
        if (GetTemplateChild("Button6") is HeButton buttonSix) buttonSix.Click += (sender, args) => AddValue('6');
        if (GetTemplateChild("Button7") is HeButton buttonSeven) buttonSeven.Click += (sender, args) => AddValue('7');
        if (GetTemplateChild("Button8") is HeButton buttonEight) buttonEight.Click += (sender, args) => AddValue('8');
        if (GetTemplateChild("Button9") is HeButton buttonNine) buttonNine.Click += (sender, args) => AddValue('9');
    }

    private void AddDot() {
        if (editText.SelectionStart == 0 && editText.SelectionLength == TempValue.Length || TempValue.Length == 0) {
            TempValue = ".";

            MoveCursorToEnd();
            return;
        }

        TempValue = TempValue.Replace(".", "") + '.';
        MoveCursorToEnd();
    }

    private void ChangeSign() {
        if (editText.SelectionStart == 0 && editText.SelectionLength == TempValue.Length || TempValue.Length == 0) {
            TempValue = "-";

            MoveCursorToEnd();
            return;
        }

        if (TempValue[0] == '-') {
            TempValue = TempValue[1..];
        } else {
            TempValue = '-' + TempValue;
        }

        MoveCursorToEnd();
    }

    private void AddValue(char value) {
        if (editText.SelectionStart == 0 && editText.SelectionLength == TempValue.Length) {
            TempValue = string.Empty;
        }

        TempValue += value;

        MoveCursorToEnd();
    }

    private void EnterValue(double exp = 1) {
        double value;
        try {
            value = double.Parse(TempValue);
            value *= exp;

            if (value < MinValue) {
                value = MinValue;
            } else if (value > MaxValue) {
                value = MaxValue;
            }
        } catch (Exception e) {
            value = MinValue;
        }

        DisplayedValue = $"{value:0.###}";
        Close();
    }

    #endregion

    #region Popup

    private void HandleMouseDown(object sender, MouseButtonEventArgs e) {
        e.Handled = true;
    }

    private void PopupOnOpened(object? sender, EventArgs e) {
        TempValue = DisplayedValue;

        editText.Focus();

        editText.SelectionStart = 0;
        editText.SelectionLength = DisplayedValue.Length;
    }

    private void PopupOnClosed(object? sender, EventArgs e) {
        IsPopupOpened = false;
    }

    #endregion
}
