namespace UiKit.Abstractions.Dialog;

public sealed class DialogDisplayOptions
{
	public bool DismissOnBackdropClick { get; init; } = true;
	public Breakpoint Breakpoint { get; set; } = Breakpoint.Sm;
}