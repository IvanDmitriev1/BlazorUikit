namespace BlazorUiKit.Extensions;

internal static class BoolExtensions
{
    private const string True = "true";
    private const string False = "false";

    public static string ToHtml(this bool value) => value ? True : False;
}

internal static class ObjectExtensions
{
    public static string ConvertToString<T>(this T? value)
    {
        if (value is string valueStr)
            return valueStr;

        return value?.ToString() ?? string.Empty;
    }
}