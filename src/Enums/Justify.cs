namespace BlazorUiKit.Enums;

public enum Justify
{
    None,
    Start,
    Center,
    End,
    SpaceBetween,
    SpaceAround,
    SpaceEvenly
}

public static class JustifyExtensions
{
    public static ReadOnlySpan<char> ToTailwindCss(this Justify justify) => justify switch
    {
        Justify.None => string.Empty,
        Justify.Start => "justify-start",
        Justify.Center => "justify-center",
        Justify.End => "justify-end",
        Justify.SpaceBetween => "justify-between",
        Justify.SpaceAround => "justify-around",
        Justify.SpaceEvenly => "justify-evenly",
        _ => throw new ArgumentOutOfRangeException(nameof(justify), justify, null)
    };
}