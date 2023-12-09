namespace BlazorUiKit.Extensions;

internal static class CssBuilderExtensions
{
    public static void AddDialogInstanceStyle(this ref CssBuilder cssBuilder)
    {
        cssBuilder.AddClass("container p-5");
        cssBuilder.AddClass("rounded border-2 drop-shadow-md");
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToBorderCss(Color.Secondary));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.PageBackgroundCss);
        cssBuilder.AddClass(ThemeManager.ThemeProvider.PageTextCss);
        cssBuilder.AddClass("backdrop:bg-main-dark-background/60"); //TODO
    }
}