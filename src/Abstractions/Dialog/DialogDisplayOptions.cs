namespace BlazorUiKit.Abstractions.Dialog;

public sealed class DialogDisplayOptions
{
	public bool DismissOnBackdropClick { get; init; } = true;
	public Breakpoint Breakpoint { get; set; } = Breakpoint.Sm;
	public DialogPosition DialogPosition { get; set; } = DialogPosition.Center;
}