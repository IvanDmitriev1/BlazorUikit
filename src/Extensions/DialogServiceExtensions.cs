using System.Diagnostics.CodeAnalysis;
using BlazorUiKit.Abstractions.Dialog;

namespace BlazorUiKit.Extensions;

public static class DialogServiceExtensions
{
	public static async Task ShowAsyncWithResult(this IDialogService dialogService, DialogDisplayOptions options, RenderFragment renderFragment, CancellationToken cancellationToken = default)
	{
		try
		{
			var dialogReference = await dialogService.ShowAsync(options, renderFragment);
			await using var cancellationTokenRegistration = cancellationToken.Register(dialogReference.Cancel);

			await dialogReference.CompletionTask;
		}
		catch (TaskCanceledException)
		{
			
		}
	}

	public static async Task ShowAsyncWithResult<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog>
		(this IDialogService dialogService, DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters, CancellationToken cancellationToken = default)
		where TDialog : DialogBase
	{
		try
		{
			var dialogReference = await dialogService.ShowAsync(options, dialogParameters);
			await using var cancellationTokenRegistration = cancellationToken.Register(dialogReference.Cancel);

			await dialogReference.CompletionTask;
		}
		catch (TaskCanceledException)
		{
			
		}
	}

	public static async Task<TResult?> ShowAsyncWithResult<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult>
		(this IDialogService dialogService, DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters, CancellationToken cancellationToken = default)
		where TDialog : DialogBase<TDialog, TResult>
	{
		try
		{
			var dialogReference = await dialogService.ShowAsync<TDialog, TResult>(options, dialogParameters);
			await using var cancellationTokenRegistration = cancellationToken.Register(dialogReference.Cancel);

			return await dialogReference.CompletionTask;
		}
		catch (TaskCanceledException)
		{
			return default;
		}
	}
}