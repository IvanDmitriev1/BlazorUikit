namespace BlazorUiKit.Enums;

public enum DialogPosition
{
    Custom,
    Center,
    Left
}

public static class DialogPositionExtensions
{
    public static ReadOnlySpan<char> ToCss(this DialogPosition dialogPosition) => dialogPosition switch
    {
        DialogPosition.Custom => string.Empty,
        DialogPosition.Center => $"{ThemeManager.ThemeProvider.ToDisplayCss(Display.Flex)} {ThemeManager.ThemeProvider.ToAlignCss(Align.Center)}",
        DialogPosition.Left   => $"{ThemeManager.ThemeProvider.ToDisplayCss(Display.Flex)} {ThemeManager.ThemeProvider.ToAlignCss(Align.Left)}",
        _                     => throw new ArgumentOutOfRangeException(nameof(dialogPosition), dialogPosition, null)
    };
}