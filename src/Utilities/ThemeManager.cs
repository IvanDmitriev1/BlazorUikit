namespace BlazorUiKit.Utilities;

public static class ThemeManager
{
    public static IThemeProvider ThemeProvider { get; set; } = DefaultThemeProvider.Instance;
}