namespace BlazorUiKit.Enums;

public enum Align
{
    Inherit,
    Left,
    Center,
    Right,
    Justify,
    Start,
    End,
}

public static class AlignExtensions
{
    public static string ToTailwindCss(this Align align) => align switch
    {
        Align.Inherit => string.Empty,
        Align.Left => "text-left",
        Align.Center => "text-center",
        Align.Right => "text-right",
        Align.Justify => "text-justify",
        Align.Start => "text-start",
        Align.End => "text-end",
        _ => throw new ArgumentOutOfRangeException(nameof(align), align, null)
    };
}