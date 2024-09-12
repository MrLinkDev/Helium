using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Helium.Controls.Button;
using Helium.Resources;
using Helium.Utilities;

namespace Helium.Controls.XButton;

public class HeXValueButton : ButtonBase {
    
    private bool isPressed = false;
    
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

    #region Text

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(HeXValueButton),
        new FrameworkPropertyMetadata(string.Empty,
            FrameworkPropertyMetadataOptions.AffectsRender));

    public string Text {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
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
        popup.Closed += PopupOnClosed;
    }

    private void HandleMouseDown(object sender, MouseButtonEventArgs e) {
        e.Handled = true;
    }

    private void PopupOnClosed(object? sender, EventArgs e) {
        IsPopupOpened = false;
    }
}
