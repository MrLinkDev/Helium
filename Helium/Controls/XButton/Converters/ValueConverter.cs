using System.Globalization;
using System.Windows.Data;

namespace Helium.Controls.XButton.Converters;

public class ValueConverter : IValueConverter {
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
        return $"{value:0.###}";
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
        if (value == null) return 0;

        return double.Parse((string)value, CultureInfo.InvariantCulture);
    }
}
