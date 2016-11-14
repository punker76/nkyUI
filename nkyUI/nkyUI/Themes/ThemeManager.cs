using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nkyUI.Themes
{
    public enum KYUITheme
    {
        BaseLight,
        BaseDark
    }

    public enum KYUIAccent
    {
        Blue,
        Red
    }

    public class ThemeManager
    {
        private static string[] _themeNames = { nameof(KYUITheme.BaseLight), nameof(KYUITheme.BaseDark) };
        private static string[] _accentNames = { nameof(KYUIAccent.Blue), nameof(KYUIAccent.Red) };

        public static IList<KYUIStyle> Themes { get; } = new List<KYUIStyle>();
        public static IList<KYUIStyle> Accents { get; } = new List<KYUIStyle>();

        static ThemeManager()
        {
            var loader = new AvaloniaXamlLoader();
            foreach (var themeName in _themeNames)
            {
                var themeAddress = new Uri($"resm:nkyUI.Themes.{themeName}.xaml?assembly=nkyUI");
                var themeStyle = (IStyle)loader.Load(themeAddress);
                Themes.Add(new KYUIStyle { Name = themeName, Style = themeStyle });
            }
            foreach (var accentName in _accentNames)
            {
                var themeAddress = new Uri($"resm:nkyUI.Themes.Accents.{accentName}.xaml?assembly=nkyUI");
                var themeStyle = (IStyle)loader.Load(themeAddress);
                Accents.Add(new KYUIStyle { Name = accentName, Style = themeStyle });
            }
        }

        public static void SetTheme(KYUITheme newTheme, Application currentApp)
        {
            var newThemeName = newTheme.ToString();
            if (!_themeNames.Contains(newThemeName)) throw new ArgumentException("Theme was not found.");
            var theme = Themes.FirstOrDefault(t => t.Name == newThemeName);
            currentApp.Styles.RemoveAll(Themes.Select(t => t.Style));
            currentApp.Styles.Add(theme.Style);
        }

        public static void SetAccent(KYUIAccent newAccent, Application currentApp)
        {
            var newAccentName = newAccent.ToString();
            if (!_accentNames.Contains(newAccentName)) throw new ArgumentException("Accent was not found.");
            var accent = Accents.FirstOrDefault(t => t.Name == newAccentName);
            currentApp.Styles.RemoveAll(Accents.Select(t => t.Style));
            currentApp.Styles.Add(accent.Style);
        }
    }
}