namespace UiKit.BaseComponents.Input;

public abstract class InputBase<T> : ValidationComponentBase<T>
{
    /// <summary>
    /// UserAttributes carries all attributes you add to the component that don't match any of its parameters.
    /// They will be splatted onto the underlying HTML tag.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> UserAttributes { get; set; } = new();

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public bool ReadOnly { get; set; }

    [Parameter]
    public string? Label { get; set; }
}