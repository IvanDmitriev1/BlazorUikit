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
        DialogPosition.Center => "flex items-center",
        DialogPosition.Left   => "flex items-left",
        _                     => throw new ArgumentOutOfRangeException(nameof(dialogPosition), dialogPosition, null)
    };
}