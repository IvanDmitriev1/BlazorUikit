using System.Diagnostics.CodeAnalysis;
using BlazorUiKit.Abstractions.Dialog;

namespace BlazorUiKit.Components;

internal sealed class DialogReference<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult> : DialogReferenceBase, IDialogReference<TDialog, TResult>
	where TDialog : DialogBase<TDialog, TResult>
{
	public DialogReference()
	{
		InitializeContentRenderFragment<TDialog>();
	}

	public Task<TResult> CompletionTask => _tcs.Task;

	private readonly TaskCompletionSource<TResult> _tcs = new();

	public override void Cancel()
	{
		_tcs.TrySetCanceled();
		DialogService.RemoveDialog(Id);
	}

	public void Close(TResult result)
	{
		if (ActualDialog?.OnClosing() == false)
		{
			return;
		}

		DialogService.RemoveDialog(Id);
		_tcs.TrySetResult(result);
	}
}