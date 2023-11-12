namespace BlazorUiKit.Components;

public sealed class DialogDisplayOptions
{
    public bool PreventDismissOnOverlayClick { get; init; }
    public bool HeadLess { get; init; }
    public bool ShowDismiss { get; init; } = true;
    public string Title { get; init; } = string.Empty;
    public Breakpoint Breakpoint { get; init; } = Breakpoint.Sm;
}