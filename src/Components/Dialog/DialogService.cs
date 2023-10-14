using System.Diagnostics.CodeAnalysis;
using BlazorUiKit.Abstractions.Dialog;

namespace BlazorUiKit.Components;

internal class DialogService : IDialogService
{
	public IReadOnlyDictionary<Guid, IDialogReferenceBase> DialogsById => _dialogsById;

	private static readonly IDictionary<string, object> EmptyParameters = new Dictionary<string, object>();

	private readonly Dictionary<Guid, IDialogReferenceBase> _dialogsById = new();
	private DialogProvider? _dialogProvider;

	public void AddDialogProvider(DialogProvider dialogProvider)
	{
		_dialogProvider = dialogProvider;
	}

	public void RemoveDialog(Guid id)
	{
		if (!_dialogsById.ContainsKey(id))
			return;

		_dialogsById.Remove(id);
		_dialogProvider?.Refresh();
	}

	public async ValueTask<IDialogReference> ShowAsync(DialogDisplayOptions options, RenderFragment renderFragment)
	{
		ArgumentNullException.ThrowIfNull(_dialogProvider);

		var dialogReference = new RenderFragmentDialogReference(renderFragment)
		{
			DialogService = this,
			DialogPosition = _dialogsById.Count + 1,
			DisplayOptions = options,
			Parameters = EmptyParameters
		};

		_dialogsById.Add(dialogReference.Id, dialogReference);
		await _dialogProvider.RefreshAsync();

		return dialogReference;
	}

	public async ValueTask<IDialogReference<TDialog>> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog>(DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters) where TDialog : DialogBase
	{
		ArgumentNullException.ThrowIfNull(_dialogProvider);

		var dialogReference = new DialogReference<TDialog>
		{
			DialogService = this,
			DialogPosition = _dialogsById.Count + 1,
			DisplayOptions = options,
			Parameters = dialogParameters,
		};

		_dialogsById.Add(dialogReference.Id, dialogReference);
		await _dialogProvider.RefreshAsync();

		return dialogReference;
	}

	public async ValueTask<IDialogReference<TDialog, TResult>> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult>(DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters) where TDialog : DialogBase<TDialog, TResult>
	{
		ArgumentNullException.ThrowIfNull(_dialogProvider);

		var dialogReference = new DialogReference<TDialog, TResult>
		{
			DialogService = this,
			DialogPosition = _dialogsById.Count + 1,
			DisplayOptions = options,
			Parameters = dialogParameters
		};

		_dialogsById.Add(dialogReference.Id, dialogReference);
		await _dialogProvider.RefreshAsync();

		return dialogReference;
	}
}