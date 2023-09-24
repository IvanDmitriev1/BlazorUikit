namespace UiKit.Enums;

public enum Color
{
    Custom,
    Inherit,
    Primary,
    PrimaryAlternative,
    Error,
    Successful,
    Warning,
}

public static class ColorExtensions
{
    public const string MainBackgroundColor = "bg-main-light-background dark:bg-main-dark-background";

    public const string BackgroundPrimaryHoverButtonColor = "hover:bg-black/90 dark:hover:bg-white";
    public const string BackgroundPrimaryAlternativeHoverButtonColor = "hover:bg-white dark:hover:bg-dark-gray";

    public const string BackgroundPrimaryActiveButtonColor = "active:bg-black/90 dark:active:bg-white";
    public const string BackgroundPrimaryAlternativeActiveButtonColor = "active:bg-white dark:active:bg-dark-gray";

    public const string FullBorderColor = "border-black/40 dark:border-dark-gray";

    public static ReadOnlySpan<char> ToTextCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "text-inherit",
        Color.Primary            => "text-black dark:text-white",
        Color.PrimaryAlternative => "text-white dark:text-black",
        Color.Error              => "text-error-light",
        Color.Successful         => "text-successful",
        Color.Warning            => "text-warning",
        _                        => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static ReadOnlySpan<char> ToTextHoverCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "hover:text-inherit",
        Color.Primary            => "hover:text-white dark:hover:text-black",
        Color.PrimaryAlternative => "hover:text-black dark:hover:text-white",
        Color.Error              => "text-white",
        Color.Successful         => "text-white",
        Color.Warning            => "text-white",
        _                        => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static ReadOnlySpan<char> ToTextActiveCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "active:text-inherit",
        Color.Primary            => "active:text-white dark:active:text-black",
        Color.PrimaryAlternative => "active:text-black dark:active:text-white",
        Color.Error              => "text-white",
        Color.Successful         => "text-white",
        Color.Warning            => "text-white",
        _                        => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static ReadOnlySpan<char> ToTextDisabledCss(this Color color) => color switch
    {
        Color.Custom => string.Empty,
        _            => "text-black/20 dark:text-dark-gray-20"
    };

    public static ReadOnlySpan<char> ToTextPlaceholderCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => string.Empty,
        Color.Primary            => "text-black/30 dark:text-dark-gray-30",
        Color.PrimaryAlternative => string.Empty,
        Color.Error              => string.Empty,
        Color.Successful         => string.Empty,
        Color.Warning            => string.Empty,
        _                        => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static ReadOnlySpan<char> ToBackgroundCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "bg-inherit",
        Color.Primary            => "bg-white dark:bg-dark-gray",
        Color.PrimaryAlternative => "bg-black/90 dark:bg-white",
        Color.Error              => "bg-error",
        Color.Successful         => "bg-successful",
        Color.Warning            => "bg-warning",
        _                        => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static ReadOnlySpan<char> ToBackgroundHoverCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "hover:bg-inherit",
        Color.Primary            => "hover:bg-black/15 dark:hover:bg-dark-gray-15",
        Color.PrimaryAlternative => string.Empty,
        Color.Error              => "hover:bg-error-light",
        Color.Successful         => "hover:bg-successful-light",
        Color.Warning            => "hover:bg-warning-light",
        _                        => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static ReadOnlySpan<char> ToBackgroundActiveCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "active:bg-inherit",
        Color.Primary            => "active:bg-black/15 dark:active:bg-dark-gray-15",
        Color.PrimaryAlternative => string.Empty,
        Color.Error              => "active:bg-error-dark",
        Color.Successful         => "active:bg-successful-dark",
        Color.Warning            => "active:bg-warning-dark",
        _                        => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static ReadOnlySpan<char> ToBackgroundDisabledCss(this Color color) => color switch
    {
        Color.Custom  => string.Empty,
        Color.Inherit => string.Empty,
        _             => "bg-black/5 dark:bg-dark-gray-5"
    };

    public static ReadOnlySpan<char> ToRingCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "ring-inherit",
        _                        => "ring-black/5 dark:ring-dark-gray-5"
    };

    public static ReadOnlySpan<char> ToRingFocusWithinCss(this Color color) => color switch
    {
        Color.Custom  => string.Empty,
        Color.Inherit => "focus-within:ring-inherit",
        _             => "focus-within:ring-black/5 dark:focus-within:ring-dark-gray-5"
    };

    public static ReadOnlySpan<char> ToRingFocusCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "focus:ring-inherit",
        Color.Primary            => "focus:ring-black/5 dark:focus:ring-dark-gray-5",
        Color.PrimaryAlternative => "focus:ring-black/5 dark:focus:ring-dark-gray-5",
        Color.Error              => "focus:ring-error-dark/20",
        Color.Successful         => "focus:ring-successful-dark/20",
        Color.Warning            => "focus:ring-warning-dark/20",
        _                        => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public static string ToBorderCss(this Color color) => color switch
    {
        Color.Custom             => string.Empty,
        Color.Inherit            => "border-inherit",
        _                        => "border-black/5 dark:border-dark-gray-5"
    };

    public static ReadOnlySpan<char> ToBorderFocusWithinCss(this Color color) => color switch
    {
        Color.Custom  => string.Empty,
        Color.Inherit => "focus-within:border-inherit",
        _             => "focus-within:border-black/5 dark:focus-within:border-dark-gray-5"
    };
}
