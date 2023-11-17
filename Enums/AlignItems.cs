namespace BlazorUiKit.Enums;

public enum AlignItems
{
    None,
    Baseline,
    Center,
    Start,
    End,
    Stretch
}

public static class AlignItemsExtensions
{
    public static string ToTailwindCss(this AlignItems alignItems) => alignItems switch
    {
        AlignItems.None => string.Empty,
        AlignItems.Baseline => "items-baseline",
        AlignItems.Center => "items-center",
        AlignItems.Start => "items-start",
        AlignItems.End => "items-end",
        AlignItems.Stretch => "items-stretch",
        _ => throw new ArgumentOutOfRangeException(nameof(alignItems), alignItems, null)
    };
}