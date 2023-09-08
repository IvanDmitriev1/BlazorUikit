using System.Diagnostics.CodeAnalysis;
using UiKit.Abstractions.Dialog;

namespace UiKit.Components.Dialog
{
	internal sealed class DialogReference<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog> : DialogReference, IDialogReference<TDialog>
		where TDialog : DialogBase
	{
		public DialogReference()
		{
			InitializeContentRenderFragment<TDialog>();
		}
	}
}
