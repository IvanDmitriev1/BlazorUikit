namespace BlazorUiKit.Utilities;

public class DefaultThemeProvider : IThemeProvider
{
    private DefaultThemeProvider() {}

    public static IThemeProvider Instance { get; } = new DefaultThemeProvider();
    
    #region Background

    public string PageBackgroundCss { get; } = "bg-main-light-background dark:bg-main-dark-background";
    public string PageTextCss { get; } = "text-black dark:text-white text-regular font-inter";

    public string ToBackgroundCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "bg-inherit",
        Color.Primary => "bg-white dark:bg-dark-gray",
        Color.Secondary => "bg-black/90 dark:bg-white",
        Color.Error => "bg-error",
        Color.Successful => "bg-successful",
        Color.Warning => "bg-warning",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToBackgroundHoverCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "hover:bg-inherit",
        Color.Primary => "hover:bg-black/15 dark:hover:bg-dark-gray-15",
        Color.Secondary => "hover:bg-black/90 dark:hover:bg-white",
        Color.Error => "hover:bg-error-light",
        Color.Successful => "hover:bg-successful-light",
        Color.Warning => "hover:bg-warning-light",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToBackgroundActiveCss(Color color, bool active = true)
    {
        if (active)
        {
            return color switch
            {
                Color.Custom => string.Empty,
                Color.Inherit => "active:bg-inherit",
                Color.Primary => "active:bg-black/90 dark:active:bg-white",
                Color.Secondary => "active:bg-white dark:active:bg-dark-gray",
                Color.Error => "active:bg-error-dark",
                Color.Successful => "active:bg-successful-dark",
                Color.Warning => "active:bg-warning-dark",
                _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
            };
        }
        
        return color switch
        {
            Color.Custom => string.Empty,
            Color.Inherit => "bg-inherit",
            Color.Primary => "bg-black/90 dark:bg-white",
            Color.Secondary => "bg-white dark:bg-dark-gray",
            Color.Error => "bg-error-dark",
            Color.Successful => "bg-successful-dark",
            Color.Warning => "bg-warning-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
    }

    public string BackgroundDisabledCss { get; } = "bg-black/5 dark:bg-dark-gray-5";

    #endregion

    #region Text

    public string ToTextCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "text-inherit",
        Color.Primary => "text-black dark:text-white",
        Color.Secondary => "text-white dark:text-black",
        Color.Error => "text-error-light",
        Color.Successful => "text-successful",
        Color.Warning => "text-warning",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToTextHoverCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "hover:text-inherit",
        Color.Primary => "hover:text-black dark:hover:text-white",
        Color.Secondary => "hover:text-white dark:hover:text-black",
        Color.Error => "text-white",
        Color.Successful => "text-white",
        Color.Warning => "text-white",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToTextActiveCss(Color color, bool active = true)
    {
        if (active)
        {
            return color switch
            {
                Color.Custom => string.Empty,
                Color.Inherit => "active:text-inherit",
                Color.Primary => "active:text-white dark:active:text-black",
                Color.Secondary => "active:text-black dark:active:text-white",
                Color.Error => "text-white",
                Color.Successful => "text-white",
                Color.Warning => "text-white",
                _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
            };
        }
        
        return color switch
        {
            Color.Custom => string.Empty,
            Color.Inherit => "text-inherit",
            Color.Primary => "text-white dark:text-black",
            Color.Secondary => "text-black dark:text-white",
            Color.Error => "text-white",
            Color.Successful => "text-white",
            Color.Warning => "text-white",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
    }

    public string TextDisabledCss { get; } = "text-black/20 dark:text-dark-gray-20";
    public string TextPlaceholderCss { get; } = "text-black/30 dark:text-dark-gray-30";

    #endregion

    public string ToBorderCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "border-inherit",
        Color.Primary => "border-black/5 dark:border-dark-gray-5",
        Color.Secondary => "border-black/40 dark:border-dark-gray",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToBorderFocusWithinCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "focus-within:border-inherit",
        _ => "focus-within:border-black/5 dark:focus-within:border-dark-gray-5"
    };

    public string ToRingCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "ring-inherit",
        _ => "ring-black/5 dark:ring-dark-gray-5"
    };

    public string ToRingFocusCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "focus:ring-inherit",
        Color.Primary => "focus:ring-black/5 dark:focus:ring-dark-gray-5",
        Color.Secondary => "focus:ring-black/5 dark:focus:ring-dark-gray-5",
        Color.Error => "focus:ring-error-dark/20",
        Color.Successful => "focus:ring-successful-dark/20",
        Color.Warning => "focus:ring-warning-dark/20",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToRingFocusWithinCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "focus-within:ring-inherit",
        _ => "focus-within:ring-black/5 dark:focus-within:ring-dark-gray-5"
    };
}