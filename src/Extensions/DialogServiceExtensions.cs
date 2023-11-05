using Fody;

namespace BlazorUiKit.Extensions;

[ConfigureAwait(false)]
public static class DialogServiceExtensions
{
	public static async Task ShowAsyncWithResult(this IDialogService dialogService, DialogDisplayOptions options, RenderFragment renderFragment, CancellationToken cancellationToken = default)
	{
		try
		{
			var dialogReference = dialogService.Show(options, renderFragment);
			await using var cancellationTokenRegistration =
				cancellationToken.Register(dialogReference.Cancel, false);

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
			var dialogReference = dialogService.Show(options, dialogParameters);
			await using var cancellationTokenRegistration =
				cancellationToken.Register(dialogReference.Cancel, false);

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
			var dialogReference = dialogService.Show<TDialog, TResult>(options, dialogParameters);
			await using var cancellationTokenRegistration =
				cancellationToken.Register(dialogReference.Cancel, false);

			return await dialogReference.CompletionTask;
		}
		catch (TaskCanceledException)
		{
			return default;
		}
	}
}