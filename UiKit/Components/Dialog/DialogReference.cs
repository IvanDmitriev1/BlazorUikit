using UiKit.Abstractions.Dialog;

namespace UiKit.Components.Dialog;

internal abstract class DialogReferenceBase : IDialogReferenceBase
{
	public Guid Id { get; } = Guid.NewGuid();
	public required DialogDisplayOptions DisplayOptions { get; init; }
	public required IDictionary<string, object> Parameters { get; init; }
	public required DialogProvider DialogProvider { get; init; }

	public RenderFragment DialogContent { get; protected set; } = null!;
	public DialogBase? ActualDialog { get; set; }

	public abstract void Cancel();
}

internal abstract class DialogReferenceBase<TDialog> : DialogReferenceBase
{
	protected DialogReferenceBase()
	{
		RenderFragment dialogRenderFragment = new RenderFragment(builder =>
		{
			builder.OpenComponent(0, typeof(TDialog));
			builder.CloseComponent();
		});

		DialogContent = dialogRenderFragment;
	}
}

internal sealed class DialogReference<TDialog> : DialogReferenceBase<TDialog>, IDialogReference<TDialog>
	where TDialog : DialogBase
{
	public Task CompletionTask => _tcs.Task;

	private readonly TaskCompletionSource _tcs = new();

	public override void Cancel()
	{
		_tcs.TrySetCanceled();
		DialogProvider.RemoveDialog(Id);
	}

	public void Close()
	{
		if (ActualDialog?.OnClosing() == false)
		{
			return;
		}

		DialogProvider.RemoveDialog(Id);
		_tcs.TrySetResult();
	}
}

internal sealed class DialogReference<TDialog, TResult> : DialogReferenceBase<TDialog>, IDialogReference<TDialog, TResult>
	where TDialog : DialogBase<TDialog, TResult>
{
	public Task<TResult> CompletionTask => _tcs.Task;

	private readonly TaskCompletionSource<TResult> _tcs = new();

	public override void Cancel()
	{
		_tcs.TrySetCanceled();
		DialogProvider.RemoveDialog(Id);
	}

	public void Close(TResult result)
	{
		if (ActualDialog?.OnClosing() == false)
		{
			return;
		}

		DialogProvider.RemoveDialog(Id);
		_tcs.TrySetResult(result);
	}
}

internal sealed class RenderFragmentDialogReference : DialogReferenceBase
{
	public RenderFragmentDialogReference(RenderFragment renderFragment)
	{
		DialogContent = renderFragment;
	}

	public Task CompletionTask => _tcs.Task;
	private readonly TaskCompletionSource _tcs = new();

	public override void Cancel()
	{
		_tcs.TrySetCanceled();
		DialogProvider.RemoveDialog(Id);
	}
}