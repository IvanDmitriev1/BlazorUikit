namespace UiKit.Components.Dialog;

internal sealed class RenderFragmentDialogReference : DialogReference
{
	public RenderFragmentDialogReference(RenderFragment renderFragment)
	{
		DialogContent = renderFragment;
	}
}