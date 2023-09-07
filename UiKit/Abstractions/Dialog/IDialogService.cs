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
    internal void AddDialogProvider(DialogProvider provider);

	/// <summary>
	/// Asynchronously displays a dialog of type <typeparamref name="TDialog"/> with the specified display options and dialog parameters.
	/// </summary>
	/// <typeparam name="TDialog">The type of the dialog to be displayed. This type must inherit from <see cref="DialogBase"/>.</typeparam>
	/// <param name="options">An instance of <see cref="DialogDisplayOptions"/> specifying the display options for the dialog.</param>
	/// <param name="dialogParameters">An instance of <see cref="DialogParameters{TDialog}"/> containing the parameters for the dialog.</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	/// <remarks>
	/// It awaits the completion of the dialog reference's CompletionTask. If the task is canceled, the method catches the resulting <see cref="TaskCanceledException"/> and continues execution.
	/// </remarks>
    Task ShowAsync<TDialog>(DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters)
		where TDialog : DialogBase;

	/// <summary>
	/// Asynchronously displays a dialog of type <typeparamref name="TDialog"/> with the specified display options and dialog parameters, and returns the result of the dialog.
	/// </summary>
	/// <typeparam name="TDialog">The type of the dialog to be displayed. This type must inherit from <see cref="DialogBase{TDialog, TResult}"/>.</typeparam>
	/// <typeparam name="TResult">The type of the result returned by the dialog.</typeparam>
	/// <param name="options">An instance of <see cref="DialogDisplayOptions"/> specifying the display options for the dialog.</param>
	/// <param name="dialogParameters">An instance of <see cref="DialogParameters{TDialog}"/> containing the parameters for the dialog.</param>
	/// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result is the result returned by the dialog.</returns>
	/// <remarks>
	/// This method displays the dialog and awaits the completion of the dialog reference's CompletionTask. If the task is canceled, the method catches the resulting <see cref="TaskCanceledException"/> and continues execution, returning the default value of <typeparamref name="TResult"/>.
	/// </remarks>
    Task<TResult?> ShowAsync<TDialog, TResult>(DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters)
        where TDialog : DialogBase<TDialog, TResult>;

	/// <summary>
	/// Asynchronously displays a dialog using the specified display options and a render fragment.
	/// </summary>
	/// <param name="options">An instance of <see cref="DialogDisplayOptions"/> specifying the display options for the dialog.</param>
	/// <param name="renderFragment">A <see cref="RenderFragment"/> that represents the content of the dialog.</param>
	/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
	/// <remarks>
	/// This method displays the dialog and awaits the completion of the dialog reference's CompletionTask. If the task is canceled, the method catches the resulting <see cref="TaskCanceledException"/> and continues execution.
	/// </remarks>
	Task ShowAsync(DialogDisplayOptions options, RenderFragment renderFragment);
}
