namespace BlazorUiKit.Enums;

public enum TextOverflow
{
    None,
    Truncate,
}

public static class TextOverflowExtensions
{
    public static string ToTailwindCss(this TextOverflow textOverflow) => textOverflow switch
    {
        TextOverflow.None => string.Empty,
        TextOverflow.Truncate => "truncate",
        _ => throw new ArgumentOutOfRangeException(nameof(textOverflow), textOverflow, null)
    };
}