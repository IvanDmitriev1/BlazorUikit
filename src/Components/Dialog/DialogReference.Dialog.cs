using System.Diagnostics.CodeAnalysis;
using BlazorUiKit.Abstractions.Dialog;

namespace BlazorUiKit.Components;

internal sealed class DialogReference<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog> : DialogReference, IDialogReference<TDialog>
	where TDialog : DialogBase
{
	public DialogReference()
	{
		InitializeContentRenderFragment<TDialog>();
	}
}