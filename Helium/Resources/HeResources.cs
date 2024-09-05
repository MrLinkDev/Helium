using System.Windows.Media;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace Helium.Resources;


public static class HeColors {
    public static Color PrimaryColor50 => (Color)ColorConverter.ConvertFromString("#f3f6fb");
    public static Color PrimaryColor100 => (Color)ColorConverter.ConvertFromString("#e3ebf6");
    public static Color PrimaryColor200 => (Color)ColorConverter.ConvertFromString("#ceddef");
    public static Color PrimaryColor300 => (Color)ColorConverter.ConvertFromString("#adc5e3");
    public static Color PrimaryColor400 => (Color)ColorConverter.ConvertFromString("#85a8d5");
    public static Color PrimaryColor500 => (Color)ColorConverter.ConvertFromString("#688cc9");
    public static Color PrimaryColor600 => (Color)ColorConverter.ConvertFromString("#5574bb");
    public static Color PrimaryColor700 => (Color)ColorConverter.ConvertFromString("#4a62aa");
    public static Color PrimaryColor800 => (Color)ColorConverter.ConvertFromString("#41528c");
    public static Color PrimaryColor900 => (Color)ColorConverter.ConvertFromString("#384670");
    public static Color PrimaryColor950 => (Color)ColorConverter.ConvertFromString("#262d45");
    
    public static Color AttentionColor50 => (Color)ColorConverter.ConvertFromString("#fcf4f4");
    public static Color AttentionColor100 => (Color)ColorConverter.ConvertFromString("#fae6e6");
    public static Color AttentionColor200 => (Color)ColorConverter.ConvertFromString("#f7d1d1");
    public static Color AttentionColor300 => (Color)ColorConverter.ConvertFromString("#f0b1b1");
    public static Color AttentionColor400 => (Color)ColorConverter.ConvertFromString("#e68383");
    public static Color AttentionColor500 => (Color)ColorConverter.ConvertFromString("#d85b5b");
    public static Color AttentionColor600 => (Color)ColorConverter.ConvertFromString("#c43e3e");
    public static Color AttentionColor700 => (Color)ColorConverter.ConvertFromString("#a43131");
    public static Color AttentionColor800 => (Color)ColorConverter.ConvertFromString("#832a2a");
    public static Color AttentionColor900 => (Color)ColorConverter.ConvertFromString("#722a2a");
    public static Color AttentionColor950 => (Color)ColorConverter.ConvertFromString("#3d1212");
    
    public static Color BlackColor50 => (Color)ColorConverter.ConvertFromString("#f6f6f6");
    public static Color BlackColor100 => (Color)ColorConverter.ConvertFromString("#e7e7e7");
    public static Color BlackColor200 => (Color)ColorConverter.ConvertFromString("#d1d1d1");
    public static Color BlackColor300 => (Color)ColorConverter.ConvertFromString("#b0b0b0");
    public static Color BlackColor400 => (Color)ColorConverter.ConvertFromString("#888888");
    public static Color BlackColor500 => (Color)ColorConverter.ConvertFromString("#6d6d6d");
    public static Color BlackColor600 => (Color)ColorConverter.ConvertFromString("#5d5d5d");
    public static Color BlackColor700 => (Color)ColorConverter.ConvertFromString("#4f4f4f");
    public static Color BlackColor800 => (Color)ColorConverter.ConvertFromString("#454545");
    public static Color BlackColor900 => (Color)ColorConverter.ConvertFromString("#3d3d3d");
    public static Color BlackColor950 => (Color)ColorConverter.ConvertFromString("#212121");
}

public static class HeBrushes {
    public static SolidColorBrush PrimaryBrush50 => new SolidColorBrush(HeColors.PrimaryColor50);
    public static SolidColorBrush PrimaryBrush100 => new SolidColorBrush(HeColors.PrimaryColor100);
    public static SolidColorBrush PrimaryBrush200 => new SolidColorBrush(HeColors.PrimaryColor200);
    public static SolidColorBrush PrimaryBrush300 => new SolidColorBrush(HeColors.PrimaryColor300);
    public static SolidColorBrush PrimaryBrush400 => new SolidColorBrush(HeColors.PrimaryColor400);
    public static SolidColorBrush PrimaryBrush500 => new SolidColorBrush(HeColors.PrimaryColor500);
    public static SolidColorBrush PrimaryBrush600 => new SolidColorBrush(HeColors.PrimaryColor600);
    public static SolidColorBrush PrimaryBrush700 => new SolidColorBrush(HeColors.PrimaryColor700);
    public static SolidColorBrush PrimaryBrush800 => new SolidColorBrush(HeColors.PrimaryColor800);
    public static SolidColorBrush PrimaryBrush900 => new SolidColorBrush(HeColors.PrimaryColor900);
    public static SolidColorBrush PrimaryBrush950 => new SolidColorBrush(HeColors.PrimaryColor950);
    
    public static SolidColorBrush AttentionBrush50 => new SolidColorBrush(HeColors.AttentionColor50);
    public static SolidColorBrush AttentionBrush100 => new SolidColorBrush(HeColors.AttentionColor100);
    public static SolidColorBrush AttentionBrush200 => new SolidColorBrush(HeColors.AttentionColor200);
    public static SolidColorBrush AttentionBrush300 => new SolidColorBrush(HeColors.AttentionColor300);
    public static SolidColorBrush AttentionBrush400 => new SolidColorBrush(HeColors.AttentionColor400);
    public static SolidColorBrush AttentionBrush500 => new SolidColorBrush(HeColors.AttentionColor500);
    public static SolidColorBrush AttentionBrush600 => new SolidColorBrush(HeColors.AttentionColor600);
    public static SolidColorBrush AttentionBrush700 => new SolidColorBrush(HeColors.AttentionColor700);
    public static SolidColorBrush AttentionBrush800 => new SolidColorBrush(HeColors.AttentionColor800);
    public static SolidColorBrush AttentionBrush900 => new SolidColorBrush(HeColors.AttentionColor900);
    public static SolidColorBrush AttentionBrush950 => new SolidColorBrush(HeColors.AttentionColor950);
    
    public static SolidColorBrush BlackBrush50 => new SolidColorBrush(HeColors.BlackColor50);
    public static SolidColorBrush BlackBrush100 => new SolidColorBrush(HeColors.BlackColor100);
    public static SolidColorBrush BlackBrush200 => new SolidColorBrush(HeColors.BlackColor200);
    public static SolidColorBrush BlackBrush300 => new SolidColorBrush(HeColors.BlackColor300);
    public static SolidColorBrush BlackBrush400 => new SolidColorBrush(HeColors.BlackColor400);
    public static SolidColorBrush BlackBrush500 => new SolidColorBrush(HeColors.BlackColor500);
    public static SolidColorBrush BlackBrush600 => new SolidColorBrush(HeColors.BlackColor600);
    public static SolidColorBrush BlackBrush700 => new SolidColorBrush(HeColors.BlackColor700);
    public static SolidColorBrush BlackBrush800 => new SolidColorBrush(HeColors.BlackColor800);
    public static SolidColorBrush BlackBrush900 => new SolidColorBrush(HeColors.BlackColor900);
    public static SolidColorBrush BlackBrush950 => new SolidColorBrush(HeColors.BlackColor950);
}
