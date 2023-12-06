namespace BlazorUiKit.Enums;

public enum ZIndex
{
    Custom = 0,
    None,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
}

public static class ZIndexExtensions
{
    public static string ToTailwindCss(this ZIndex zIndex) => zIndex switch
    {
        ZIndex.Custom => string.Empty,
        ZIndex.None   => "z-0",
        ZIndex.One    => "z-[1]",
        ZIndex.Two    => "z-[2]",
        ZIndex.Three  => "z-[3]",
        ZIndex.Four   => "z-[4]",
        ZIndex.Five   => "z-[5]",
        ZIndex.Six    => "z-[6]",
        ZIndex.Seven  => "z-[7]",
        ZIndex.Eight  => "z-[8]",
        ZIndex.Nine   => "z-[9]",
        ZIndex.Ten    => "z-10",
        _             => throw new ArgumentOutOfRangeException(nameof(zIndex), zIndex, null)
    };
}