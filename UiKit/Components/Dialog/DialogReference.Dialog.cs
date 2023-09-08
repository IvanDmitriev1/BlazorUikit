using UiKit.Abstractions.Dialog;

namespace UiKit.Components.Dialog
{
	internal sealed class DialogReference<TDialog> : DialogReference, IDialogReference<TDialog>
		where TDialog : DialogBase
	{
		public DialogReference()
		{
			InitializeContentRenderFragment<TDialog>();
		}
	}
}
