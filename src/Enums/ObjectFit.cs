namespace UiKit.Enums;

public enum ObjectFit
{
    Contain,
    Cover,
    Fill,
    None,
    ScaleDown
}

public static class ObjectFitExtensions
{
    public static string ToTailwindCss(this ObjectFit objectFit) => objectFit switch
    {
        ObjectFit.Contain => "object-contain",
        ObjectFit.Cover =>"object-cover",
        ObjectFit.Fill => "object-fill",
        ObjectFit.None => "object-none",
        ObjectFit.ScaleDown => "object-scale-down",
        _ => throw new ArgumentOutOfRangeException(nameof(objectFit), objectFit, null)
    };
}