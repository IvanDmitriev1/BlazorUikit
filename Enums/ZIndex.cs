namespace BlazorUiKit.Enums;

public enum ZIndex
{
    Custom = 0,
    Auto,
    None,
    One,
    Two,
    Ten,
    Twenty,
    Thirty,
    Forty,
    Fifty,
}

public static class ZIndexExtensions
{
    public static string ToTailwindCss(this ZIndex zIndex) => zIndex switch
    {
        ZIndex.Custom => string.Empty,
        ZIndex.Auto   => "z-auto",
        ZIndex.None   => "z-0",
        ZIndex.One    => "z-[1]",
        ZIndex.Two    => "z-[2]",
        ZIndex.Ten    => "z-10",
        ZIndex.Twenty => "z-20",
        ZIndex.Thirty => "z-30",
        ZIndex.Forty  => "z-40",
        ZIndex.Fifty  => "z-50",
        _             => throw new ArgumentOutOfRangeException(nameof(zIndex), zIndex, null)
    };
}