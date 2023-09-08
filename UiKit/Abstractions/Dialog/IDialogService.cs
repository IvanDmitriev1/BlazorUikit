using UiKit.Components;

namespace UiKit.Abstractions.Dialog;

/// <summary>
/// The IDialogService interface provides methods for displaying dialogs in an application.
/// </summary>
/// <remarks>
/// This interface defines two methods for showing dialogs. The ShowAsync method displays a dialog of a specified type with given display options and parameters. 
/// The second method, also named ShowAsync, additionally returns the result of the dialog.
/// Both methods are asynchronous and return a Task representing the ongoing operation.
/// </remarks>
public interface IDialogService
{
	internal void RegisterHandlers(Func<IDialogReferenceBase, ValueTask> addDialogHandler, Action<Guid> removeDialogHandler);
	internal void ClearAllHandlers();

	void RemoveDialog(Guid id);


	ValueTask<IDialogReference> ShowAsync
		(DialogDisplayOptions options, RenderFragment renderFragment);

	ValueTask<IDialogReference<TDialog>> ShowAsync<TDialog>
	(DialogDisplayOptions options,
	 DialogParameters<TDialog> dialogParameters
	)
		where TDialog : DialogBase;

	ValueTask<IDialogReference<TDialog, TResult>> ShowAsync<TDialog, TResult>
	(DialogDisplayOptions options,
	 DialogParameters<TDialog> dialogParameters
	)
		where TDialog : DialogBase<TDialog, TResult>;
}
