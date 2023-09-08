using UiKit.Abstractions.Dialog;

namespace UiKit.Components.Dialog;

internal class DialogService : IDialogService
{
	private static readonly IDictionary<string, object> Empty = new Dictionary<string, object>();
	private Func<IDialogReferenceBase, ValueTask>? _addDialogHandler;
	private Action<Guid>? _removeDialogHandler;

	public void RegisterHandlers(Func<IDialogReferenceBase, ValueTask> addDialogHandler, Action<Guid> removeDialogHandler)
	{
		_addDialogHandler = addDialogHandler;
		_removeDialogHandler = removeDialogHandler;
	}

	public void ClearAllHandlers()
	{
		_addDialogHandler = null;
		_removeDialogHandler = null;
	}

	public void RemoveDialog(Guid id)
	{
		Action<Guid>? handler = _removeDialogHandler;
		handler?.Invoke(id);
	}

	public async ValueTask<IDialogReference> ShowAsync
		(DialogDisplayOptions options, RenderFragment renderFragment)
	{
		var dialogReference = new RenderFragmentDialogReference(renderFragment)
		{
			DialogService = this,
			DisplayOptions = options,
			Parameters = Empty
		};

		await InvokeAddDialogHandler(dialogReference);
		return dialogReference;
	}

	public async ValueTask<IDialogReference<TDialog>> ShowAsync<TDialog>
	(DialogDisplayOptions options,
	 DialogParameters<TDialog> dialogParameters
	)
		where TDialog : DialogBase
	{
		var dialogReference = new DialogReference<TDialog>
		{
			DialogService = this,
			DisplayOptions = options,
			Parameters = dialogParameters
		};

		await InvokeAddDialogHandler(dialogReference);
		return dialogReference;
	}

	public async ValueTask<IDialogReference<TDialog, TResult>> ShowAsync<TDialog, TResult>
	(DialogDisplayOptions options,
	 DialogParameters<TDialog> dialogParameters
	)
		where TDialog : DialogBase<TDialog, TResult>
	{
		var dialogReference = new DialogReference<TDialog, TResult>
		{
			DialogService = this,
			DisplayOptions = options,
			Parameters = dialogParameters
		};

		await InvokeAddDialogHandler(dialogReference);
		return dialogReference;
	}

	private ValueTask InvokeAddDialogHandler(IDialogReferenceBase reference)
	{
		Func<IDialogReferenceBase, ValueTask>? handler = _addDialogHandler;
		return handler?.Invoke(reference) ?? ValueTask.CompletedTask;
	}
}