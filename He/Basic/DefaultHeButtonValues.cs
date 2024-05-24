using System.Windows;

namespace Basic;

public sealed class DefaultHeButtonValues {
    public static CornerRadius CornerRadius2Px { get; } = new CornerRadius(2);

    public static readonly CornerRadius CornerRadius4Px = new (4);
    
    public static readonly CornerRadius CornerRadius8Px = new (8);
    
    public static readonly CornerRadius CornerRadius16Px = new (16);
}
