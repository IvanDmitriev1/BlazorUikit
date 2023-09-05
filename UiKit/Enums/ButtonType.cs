namespace UiKit.Enums;

public enum ButtonType
{
    Button,
    Submit
}

public static class ButtonTypeExtensions
{
    public static string ToHtml(this ButtonType buttonType) => buttonType switch
    {
        ButtonType.Button => "button",
        ButtonType.Submit => "submit",
        _                 => throw new ArgumentOutOfRangeException(nameof(buttonType), buttonType, null)
    };
}