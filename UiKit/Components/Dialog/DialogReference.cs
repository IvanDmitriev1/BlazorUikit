using UiKit.Abstractions.Dialog;

namespace UiKit.Components.Dialog;

internal abstract class DialogReferenceBase : IDialogReferenceBase
{
	protected DialogReferenceBase(Type dialogType)
	{
		DialogType = dialogType;
	}

	public Type DialogType { get; }
	public Guid Id { get; } = Guid.NewGuid();
	public required DialogDisplayOptions DisplayOptions { get; init; }
	public required IDictionary<string, object> Parameters { get; init; }
	public required DialogProvider DialogProvider { get; init; }

	public RenderFragment InstanceRenderFragment { get; protected set; } = null!;
	public DialogBase? ActualDialog { get; set; }

	public abstract void Cancel();
}

internal abstract class DialogReferenceBase<TDialog> : DialogReferenceBase
{
	protected DialogReferenceBase() : base(typeof(TDialog))
	{
		RenderFragment dialogRenderFragment = new RenderFragment(builder =>
		{
			builder.OpenComponent<DialogInstance>(0);
			builder.SetKey(Id);
			builder.CloseComponent();
		});

		InstanceRenderFragment = dialogRenderFragment;
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