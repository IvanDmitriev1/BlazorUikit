namespace BlazorUiKit.Extensions;

public static class BoolExtensions
{
    private const string True = "true";
    private const string False = "false";

    public static string ToHtml(this bool value) => value ? True : False;
}