using System;
using System.Linq;
using System.Windows;

namespace Lab_rab3_KutlubaevA.D._БПИ_23_02
{
    public partial class App : Application
    {
        private const string LightPath = "Themes/LightTheme.xaml";
        private const string DarkPath = "Themes/DarkTheme.xaml";

        public void SetTheme(string themeName)
        {
            var dicts = Resources.MergedDictionaries;

            var toRemove = dicts.Where(d =>
            {
                var s = d.Source?.ToString() ?? "";
                return s.EndsWith("LightTheme.xaml", StringComparison.OrdinalIgnoreCase)
                    || s.EndsWith("DarkTheme.xaml", StringComparison.OrdinalIgnoreCase);
            }).ToList();

            foreach (var d in toRemove) dicts.Remove(d);

            var newUri = new Uri(themeName.Equals("Dark", StringComparison.OrdinalIgnoreCase) ? DarkPath : LightPath, UriKind.Relative);
            var newDict = new ResourceDictionary() { Source = newUri };
            dicts.Add(newDict);
        }

        public void ToggleTheme()
        {
            bool isDark = Resources.MergedDictionaries.Any(d => (d.Source?.ToString() ?? "").EndsWith("DarkTheme.xaml", StringComparison.OrdinalIgnoreCase));
            SetTheme(isDark ? "Light" : "Dark");
        }
    }
}
