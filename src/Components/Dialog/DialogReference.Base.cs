using BlazorUiKit.Abstractions.Dialog;

namespace BlazorUiKit.Components;

internal abstract class DialogReferenceBase : IDialogReferenceBase
{
	public Guid Id { get; } = Guid.NewGuid();
	public required DialogDisplayOptions DisplayOptions { get; init; }
	public required int DialogPosition { get; init; }
	public required IDictionary<string, object> Parameters { get; init; }
	public required IDialogService DialogService { get; init; }

	public RenderFragment DialogContent { get; protected set; } = null!;
	public DialogBase? ActualDialog { get; set; }
	
	protected bool IsCanceledOrClosed { get; set; }

	public abstract void Cancel();

	protected void InitializeContentRenderFragment<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog>()
	{
		RenderFragment dialogRenderFragment = new RenderFragment(builder =>
		{
			builder.OpenComponent(0, typeof(TDialog));
			builder.AddMultipleAttributes(1, Parameters);
			builder.CloseComponent();
		});

		DialogContent = dialogRenderFragment;
	}
}

internal abstract class DialogReference : DialogReferenceBase, IDialogReference
{
	public Task CompletionTask => _tcs.Task;

	private readonly TaskCompletionSource _tcs = new();

	public override void Cancel()
	{
		if (IsCanceledOrClosed)
			return;

		_tcs.SetCanceled();
		DialogService.RemoveDialog(Id);
		IsCanceledOrClosed = true;
	}

	public void Close()
	{
		if (IsCanceledOrClosed)
			return;

		ActualDialog?.OnClosing();

		if (ActualDialog?.CanClose != true)
			return;

		_tcs.TrySetResult();
		DialogService.RemoveDialog(Id);
		IsCanceledOrClosed = true;
	}
}