namespace BlazorUiKit.Components;

internal sealed class RenderFragmentDialogReference : DialogReference
{
	public RenderFragmentDialogReference(RenderFragment renderFragment)
	{
		DialogContent = renderFragment;
	}
}