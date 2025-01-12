using System.Windows;
using System.Windows.Controls;

namespace Helium.Controls.TabControl;

public class HeVTabLabel : TabItem {
    
    #region Header
    
    public new static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        nameof(Header),
        typeof(string),
        typeof(HeVTabLabel),
        new FrameworkPropertyMetadata(string.Empty));
    
    public new string Header {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
    
    #endregion
    
    static HeVTabLabel() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HeVTabLabel),
            new FrameworkPropertyMetadata(typeof(HeVTabLabel)));
    }
}
