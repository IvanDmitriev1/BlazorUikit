namespace BlazorUiKit.Enums;

public enum BorderRadius
{
    Default,
    None,
    Sm,
    Md,
    Lg,
}

public static class BorderRadiusExtensions
{
    public static string ToTailwindcss(this BorderRadius radius) => radius switch
    {
        BorderRadius.None => "rounded-none",
        BorderRadius.Sm => "rounded-sm",
        BorderRadius.Default => "rounded",
        BorderRadius.Md => "rounded-md",
        BorderRadius.Lg => "rounded-lg",
        _ => throw new ArgumentOutOfRangeException(nameof(radius), radius, null)
    };
}