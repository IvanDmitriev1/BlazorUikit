using System.Diagnostics.CodeAnalysis;
using UiKit.Abstractions.Dialog;

namespace UiKit.Components.Dialog;

internal class DialogService : IDialogService
{
	private static readonly IDictionary<string, object> Empty = new Dictionary<string, object>();
	private DialogProvider? _dialogProvider;

	public void AddDialogProvider(DialogProvider dialogProvider)
	{
		_dialogProvider = dialogProvider;
	}

	public void RemoveDialog(Guid id)
	{
		_dialogProvider?.RemoveDialog(id);
	}

	public async ValueTask<IDialogReference> ShowAsync
		(DialogDisplayOptions options, RenderFragment renderFragment)
	{
		ArgumentNullException.ThrowIfNull(_dialogProvider);

		var dialogReference = new RenderFragmentDialogReference(renderFragment)
		{
			DialogService = this,
			DisplayOptions = options,
			Parameters = Empty
		};

		await _dialogProvider.AddDialog(dialogReference);
		return dialogReference;
	}

	public async ValueTask<IDialogReference<TDialog>> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog>
	(DialogDisplayOptions options,
	 DialogParameters<TDialog> dialogParameters
	)
		where TDialog : DialogBase
	{
		ArgumentNullException.ThrowIfNull(_dialogProvider);

		var dialogReference = new DialogReference<TDialog>
		{
			DialogService = this,
			DisplayOptions = options,
			Parameters = dialogParameters
		};

		await _dialogProvider.AddDialog(dialogReference);
		return dialogReference;
	}

	public async ValueTask<IDialogReference<TDialog, TResult>> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult>
	(DialogDisplayOptions options,
	 DialogParameters<TDialog> dialogParameters
	)
		where TDialog : DialogBase<TDialog, TResult>
	{
		ArgumentNullException.ThrowIfNull(_dialogProvider);

		var dialogReference = new DialogReference<TDialog, TResult>
		{
			DialogService = this,
			DisplayOptions = options,
			Parameters = dialogParameters
		};

		await _dialogProvider.AddDialog(dialogReference);
		return dialogReference;
	}
}