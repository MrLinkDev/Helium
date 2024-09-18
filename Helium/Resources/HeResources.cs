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
    
    public static Color RedColor50 => (Color)ColorConverter.ConvertFromString("#fcf4f4");
    public static Color RedColor100 => (Color)ColorConverter.ConvertFromString("#fae6e6");
    public static Color RedColor200 => (Color)ColorConverter.ConvertFromString("#f7d1d1");
    public static Color RedColor300 => (Color)ColorConverter.ConvertFromString("#f0b1b1");
    public static Color RedColor400 => (Color)ColorConverter.ConvertFromString("#e68383");
    public static Color RedColor500 => (Color)ColorConverter.ConvertFromString("#d85b5b");
    public static Color RedColor600 => (Color)ColorConverter.ConvertFromString("#c43e3e");
    public static Color RedColor700 => (Color)ColorConverter.ConvertFromString("#a43131");
    public static Color RedColor800 => (Color)ColorConverter.ConvertFromString("#832a2a");
    public static Color RedColor900 => (Color)ColorConverter.ConvertFromString("#722a2a");
    public static Color RedColor950 => (Color)ColorConverter.ConvertFromString("#3d1212");
    
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
    
    public static Color GreenColor50 => (Color)ColorConverter.ConvertFromString("#f2fbf5");
    public static Color GreenColor100 => (Color)ColorConverter.ConvertFromString("#e2f8e9");
    public static Color GreenColor200 => (Color)ColorConverter.ConvertFromString("#c3efd1");
    public static Color GreenColor300 => (Color)ColorConverter.ConvertFromString("#94e1ae");
    public static Color GreenColor400 => (Color)ColorConverter.ConvertFromString("#5eca82");
    public static Color GreenColor500 => (Color)ColorConverter.ConvertFromString("#38af61");
    public static Color GreenColor600 => (Color)ColorConverter.ConvertFromString("#29904c");
    public static Color GreenColor700 => (Color)ColorConverter.ConvertFromString("#24713f");
    public static Color GreenColor800 => (Color)ColorConverter.ConvertFromString("#215a36");
    public static Color GreenColor900 => (Color)ColorConverter.ConvertFromString("#1d4a2e");
    public static Color GreenColor950 => (Color)ColorConverter.ConvertFromString("#0b2816");
    
    public static Color OrangeColor50 => (Color)ColorConverter.ConvertFromString("#fff9eb");
    public static Color OrangeColor100 => (Color)ColorConverter.ConvertFromString("#feedc7");
    public static Color OrangeColor200 => (Color)ColorConverter.ConvertFromString("#fdd98a");
    public static Color OrangeColor300 => (Color)ColorConverter.ConvertFromString("#fdc763");
    public static Color OrangeColor400 => (Color)ColorConverter.ConvertFromString("#fca623");
    public static Color OrangeColor500 => (Color)ColorConverter.ConvertFromString("#f6830a");
    public static Color OrangeColor600 => (Color)ColorConverter.ConvertFromString("#da5e05");
    public static Color OrangeColor700 => (Color)ColorConverter.ConvertFromString("#b53f08");
    public static Color OrangeColor800 => (Color)ColorConverter.ConvertFromString("#93300d");
    public static Color OrangeColor900 => (Color)ColorConverter.ConvertFromString("#78290f");
    public static Color OrangeColor950 => (Color)ColorConverter.ConvertFromString("#451203");
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
    
    public static SolidColorBrush RedBrush50 => new SolidColorBrush(HeColors.RedColor50);
    public static SolidColorBrush RedBrush100 => new SolidColorBrush(HeColors.RedColor100);
    public static SolidColorBrush RedBrush200 => new SolidColorBrush(HeColors.RedColor200);
    public static SolidColorBrush RedBrush300 => new SolidColorBrush(HeColors.RedColor300);
    public static SolidColorBrush RedBrush400 => new SolidColorBrush(HeColors.RedColor400);
    public static SolidColorBrush RedBrush500 => new SolidColorBrush(HeColors.RedColor500);
    public static SolidColorBrush RedBrush600 => new SolidColorBrush(HeColors.RedColor600);
    public static SolidColorBrush RedBrush700 => new SolidColorBrush(HeColors.RedColor700);
    public static SolidColorBrush RedBrush800 => new SolidColorBrush(HeColors.RedColor800);
    public static SolidColorBrush RedBrush900 => new SolidColorBrush(HeColors.RedColor900);
    public static SolidColorBrush RedBrush950 => new SolidColorBrush(HeColors.RedColor950);
    
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
    
    public static SolidColorBrush GreenBrush50 => new SolidColorBrush(HeColors.GreenColor50);
    public static SolidColorBrush GreenBrush100 => new SolidColorBrush(HeColors.GreenColor100);
    public static SolidColorBrush GreenBrush200 => new SolidColorBrush(HeColors.GreenColor200);
    public static SolidColorBrush GreenBrush300 => new SolidColorBrush(HeColors.GreenColor300);
    public static SolidColorBrush GreenBrush400 => new SolidColorBrush(HeColors.GreenColor400);
    public static SolidColorBrush GreenBrush500 => new SolidColorBrush(HeColors.GreenColor500);
    public static SolidColorBrush GreenBrush600 => new SolidColorBrush(HeColors.GreenColor600);
    public static SolidColorBrush GreenBrush700 => new SolidColorBrush(HeColors.GreenColor700);
    public static SolidColorBrush GreenBrush800 => new SolidColorBrush(HeColors.GreenColor800);
    public static SolidColorBrush GreenBrush900 => new SolidColorBrush(HeColors.GreenColor900);
    public static SolidColorBrush GreenBrush950 => new SolidColorBrush(HeColors.GreenColor950);
    
    public static SolidColorBrush OrangeBrush50 => new SolidColorBrush(HeColors.OrangeColor50);
    public static SolidColorBrush OrangeBrush100 => new SolidColorBrush(HeColors.OrangeColor100);
    public static SolidColorBrush OrangeBrush200 => new SolidColorBrush(HeColors.OrangeColor200);
    public static SolidColorBrush OrangeBrush300 => new SolidColorBrush(HeColors.OrangeColor300);
    public static SolidColorBrush OrangeBrush400 => new SolidColorBrush(HeColors.OrangeColor400);
    public static SolidColorBrush OrangeBrush500 => new SolidColorBrush(HeColors.OrangeColor500);
    public static SolidColorBrush OrangeBrush600 => new SolidColorBrush(HeColors.OrangeColor600);
    public static SolidColorBrush OrangeBrush700 => new SolidColorBrush(HeColors.OrangeColor700);
    public static SolidColorBrush OrangeBrush800 => new SolidColorBrush(HeColors.OrangeColor800);
    public static SolidColorBrush OrangeBrush900 => new SolidColorBrush(HeColors.OrangeColor900);
    public static SolidColorBrush OrangeBrush950 => new SolidColorBrush(HeColors.OrangeColor950);
}
