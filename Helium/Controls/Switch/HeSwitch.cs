using System.Collections;
using System.Windows;
using System.Windows.Controls;
using Helium.Controls.Button;
using Helium.Controls.Switch.Utilities;

namespace Helium.Controls.Switch;

public class HeSwitch : Control {
    
    #region Values

    public static readonly DependencyProperty ValuesProperty = DependencyProperty.Register(
        nameof(Values),
        typeof(List<string>),
        typeof(HeSwitch),
        new FrameworkPropertyMetadata(new List<string>()));
    
    public List<string> Values {
        get => (List<string>)GetValue(ValuesProperty);
        set => SetValue(ValuesProperty, value);
    }

    #endregion
    
    #region Position

    public static readonly DependencyProperty PositionProperty = DependencyProperty.Register(
        nameof(Position),
        typeof(int),
        typeof(HeSwitch),
        new FrameworkPropertyMetadata(0));
    
    public int Position {
        get => (int)GetValue(PositionProperty);
        set => SetValue(PositionProperty, value);
    }

    #endregion
    
    static HeSwitch() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeSwitch),
            new FrameworkPropertyMetadata(typeof(HeSwitch)));
    }
    
    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        Grid? container = GetTemplateChild("HeSwitchContainer") as Grid;
        if (container == null) return;
        
        container.Children.Clear();
        container.ColumnDefinitions.Clear();

        for (int i = 0; i < Values.Count; ++i) {
            container.ColumnDefinitions.Add(new ColumnDefinition());

            HeSwitchToggle button = new HeSwitchToggle(i) {
                Width = Double.NaN,
                Height = Double.NaN,
                
                Text = Values[i],
                IsChecked = i == Position
            };

            button.Checked += (sender, args) => Position = button.Index;

            if (i == 0) {
                button.HeSwitchTogglePosition = HeSwitchTogglePosition.Left;
                button.Margin = new Thickness(0, 0, -1, 0);
            }
            else if (i == Values.Count - 1) {
                button.HeSwitchTogglePosition = HeSwitchTogglePosition.Right;
                button.Margin = new Thickness(-1, 0, 0, 0);
            }
            else button.Margin = new Thickness(-1, 0, -1, 0);
            
            container.Children.Add(button);
            Grid.SetColumn(button, i);
        }
        
        Values.Clear();
    }
    
    
}
