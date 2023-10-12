namespace UiKit.Enums;

public enum HrefTarget
{
    Self,
    Blank,
    Parent,
    Top
}

public static class HrefTargetExtensions
{
    public static string ToHtml(this HrefTarget hrefTarget) => hrefTarget switch
    {
        HrefTarget.Self   => "_self",
        HrefTarget.Blank  => "_blank",
        HrefTarget.Parent => "_parent",
        HrefTarget.Top    => "_top",
        _                       => throw new ArgumentOutOfRangeException(nameof(hrefTarget), hrefTarget, null)
    };
}