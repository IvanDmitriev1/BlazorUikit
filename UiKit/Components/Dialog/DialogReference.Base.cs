using System.Diagnostics.CodeAnalysis;
using UiKit.Abstractions.Dialog;

namespace UiKit.Components.Dialog;

internal abstract class DialogReferenceBase : IDialogReferenceBase
{
	public Guid Id { get; } = Guid.NewGuid();
	public required DialogDisplayOptions DisplayOptions { get; init; }
	public required IDictionary<string, object> Parameters { get; init; }
	public required IDialogService DialogService { get; init; }

	public RenderFragment DialogContent { get; private set; } = null!;
	public DialogBase? ActualDialog { get; set; }

	public abstract void Cancel();

	protected void InitializeContentRenderFragment<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog>()
	{
		RenderFragment dialogRenderFragment = new RenderFragment(builder =>
		{
			builder.OpenComponent(0, typeof(TDialog));
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
		_tcs.TrySetCanceled();
		DialogService.RemoveDialog(Id);
	}

	public void Close()
	{
		if (ActualDialog?.OnClosing() == false)
		{
			return;
		}

		DialogService.RemoveDialog(Id);
		_tcs.TrySetResult();
	}
}