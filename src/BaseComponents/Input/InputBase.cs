namespace BlazorUiKit.BaseComponents.Input;

public abstract class InputBase<T> : ValidationComponentBase<T>
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool ReadOnly { get; set; }

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public string? Placeholder { get; set; }
}