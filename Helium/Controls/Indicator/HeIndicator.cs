using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Helium.Controls.Button;
using Helium.Controls.Indicator.Utilities;
using Helium.Utilities;

namespace Helium.Controls.Indicator;

public class HeIndicator : Control {
    
    #region HeIndicatorType

    public static readonly DependencyProperty HeIndicatorTypeProperty = DependencyProperty.Register(
        nameof(HeIndicatorType),
        typeof(HeIndicatorType),
        typeof(HeIndicator),
        new FrameworkPropertyMetadata(HeIndicatorType.Connection));
    
    public HeIndicatorType HeIndicatorType {
        get => (HeIndicatorType)GetValue(HeIndicatorTypeProperty);
        set => SetValue(HeIndicatorTypeProperty, value);
    }
    
    #endregion
    
    #region HeTheme

    public static readonly DependencyProperty HeThemeProperty = DependencyProperty.Register(
        nameof(HeTheme),
        typeof(HeTheme),
        typeof(HeIndicator),
        new FrameworkPropertyMetadata(HeTheme.Default));
    
    public HeTheme HeTheme {
        get => (HeTheme)GetValue(HeThemeProperty);
        set => SetValue(HeThemeProperty, value);
    }
    
    #endregion
    
    #region State

    public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
        nameof(State),
        typeof(Enum),
        typeof(HeIndicator),
        new FrameworkPropertyMetadata(ConnectionState.None));
    
    public Enum State {
        get => (Enum)GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }
    
    #endregion
    
    static HeIndicator() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeIndicator),
            new FrameworkPropertyMetadata(typeof(HeIndicator)));
    }
}
