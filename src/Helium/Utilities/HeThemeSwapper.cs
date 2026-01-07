using System.Windows;

namespace Helium.Utilities;

public static class HeThemeSwapper {
    private static bool isDark = true;

    public static void Swap() {
        isDark = !isDark;

        Application.Current.Resources.Clear();

        if (isDark)
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() {Source = new Uri("pack://application:,,,/Alexander.Gorbunov.Helium;component/Themes/GenericDark.xaml")});
        else
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() {Source = new Uri("pack://application:,,,/Alexander.Gorbunov.Helium;component/Themes/GenericLight.xaml")});

    }
}
