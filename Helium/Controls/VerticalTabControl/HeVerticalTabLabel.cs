using System.Windows;
using System.Windows.Controls;

namespace Helium.Controls.VerticalTabControl;

public class HeVerticalTabLabel : TabItem {
    
    #region Header
    
    public new static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(Header),
        typeof(string),
        typeof(HeVerticalTabLabel),
        new FrameworkPropertyMetadata(string.Empty));
    
    public new string Header {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
    
    #endregion
    
    static HeVerticalTabLabel() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeVerticalTabLabel),
            new FrameworkPropertyMetadata(typeof(HeVerticalTabLabel)));
    }
}
