﻿using UiKit.Abstractions.Dialog;

namespace UiKit.Components.Dialog;

internal class DialogService : IDialogService
{
	private DialogProvider? _dialogProvider;

	public void AddDialogProvider(DialogProvider provider)
	{
		_dialogProvider = provider;
	}


	/// <inheritdoc />
	public async Task ShowAsync<TDialog>(DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters)
		where TDialog : DialogBase
	{
		ArgumentNullException.ThrowIfNull(_dialogProvider);

		var dialogReference = new DialogReference<TDialog>
		{
			DisplayOptions = options,
			DialogProvider = _dialogProvider,
			Parameters = dialogParameters
		};

		await _dialogProvider.ShowAsync(dialogReference);

		try
		{
			await dialogReference.CompletionTask;
		}
		catch (TaskCanceledException)
		{
		}
	}

	/// <inheritdoc />
	public async Task<TResult?> ShowAsync<TDialog, TResult>(DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters)
		where TDialog : DialogBase<TDialog, TResult>
	{
		ArgumentNullException.ThrowIfNull(_dialogProvider);

		var dialogReference = new DialogReference<TDialog, TResult>
		{
			DisplayOptions = options,
			DialogProvider = _dialogProvider,
			Parameters = dialogParameters
		};

		await _dialogProvider.ShowAsync(dialogReference);

		try
		{
			return await dialogReference.CompletionTask;
		}
		catch (TaskCanceledException)
		{
			return default;
		}
	}
}