using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Helium.Controls.Button;
using Helium.Controls.EditText;
using Helium.Resources;
using Helium.Utilities;

namespace Helium.Controls.XButton;

public class HeXValueButton : ButtonBase {
    
    private bool isPressed = false;
    
    private HeEditText editText;
    
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
    
    #region Value

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value),
        typeof(string),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(string.Empty,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public string Value {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
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
    
    #region MinValue

    public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
        nameof(MinValue),
        typeof(double),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(0.0,
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
        new FrameworkPropertyMetadata(0.0,
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

        if (GetTemplateChild("ButtonClose") is HeButton buttonClose) buttonClose.Click += (sender, args) => ClosePopup();
        if (GetTemplateChild("ButtonClear") is HeButton buttonClear) buttonClear.Click += (sender, args) => Clear();
        if (GetTemplateChild("ButtonBackspace") is HeButton buttonBackspace) buttonBackspace.Click += (sender, args) => Backspace();
        ConnectNumberButtons();
        if (GetTemplateChild("ButtonDot") is HeButton buttonDot) buttonDot.Click += (sender, args) => AddDot();
        if (GetTemplateChild("ButtonSign") is HeButton buttonSign) buttonSign.Click += (sender, args) => ChangeSign();
    }

    private void ClosePopup() {
        IsPopupOpened = false;
    }

    private void Clear() {
        Value = string.Empty;
    }

    private void Backspace() {
        if (editText.SelectionStart == 0 && editText.SelectionLength == Value.Length) {
            Value = string.Empty;
        } else {
            Value = Value[..^1];
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
        if (GetTemplateChild("Button9") is HeButton buttonNine) buttonNine.Click += (sender, args) =>AddValue('9');
    }

    private void AddDot() {
        if (editText.SelectionStart == 0 && editText.SelectionLength == Value.Length || Value.Length == 0) {
            Value = ".";
            
            MoveCursorToEnd();
            return;
        }

        Value = Value.Replace(".", "") + '.';
        MoveCursorToEnd();
    }

    private void ChangeSign() {
        if (editText.SelectionStart == 0 && editText.SelectionLength == Value.Length || Value.Length == 0) {
            Value = "-";
            
            MoveCursorToEnd();
            return;
        }

        if (Value[0] == '-') {
            Value = Value[1..];
        } else {
            Value = '-' + Value;
        }
        
        MoveCursorToEnd();
    }

    private void AddValue(char value) {
        if (editText.SelectionStart == 0 && editText.SelectionLength == Value.Length) {
            Value = string.Empty;
        }
        
        Value += value;
        
        MoveCursorToEnd();
    }

    private void MoveCursorToEnd() {
        editText.SelectionStart = Value.Length;
        editText.SelectionLength = 0;
    }

    private void HandleMouseDown(object sender, MouseButtonEventArgs e) {
        e.Handled = true;
    }

    private void PopupOnOpened(object? sender, EventArgs e) {
        editText.Focus();
        
        editText.SelectionStart = 0;
        editText.SelectionLength = Value.Length;
    }
    
    private void PopupOnClosed(object? sender, EventArgs e) {
        IsPopupOpened = false;
    }
}
