using System.Diagnostics.CodeAnalysis;
using UiKit.Components;

namespace UiKit.Abstractions.Dialog;

public interface IDialogService
{
	IReadOnlyDictionary<Guid, IDialogReferenceBase> DialogsById { get; }

	void AddDialogProvider(DialogProvider dialogProvider);
	void RemoveDialog(Guid id);

	ValueTask<IDialogReference> ShowAsync
		(DialogDisplayOptions options, RenderFragment renderFragment);

	ValueTask<IDialogReference<TDialog>> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog>
	(DialogDisplayOptions options,
	 DialogParameters<TDialog> dialogParameters
	)
		where TDialog : DialogBase;

	ValueTask<IDialogReference<TDialog, TResult>> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult>
	(DialogDisplayOptions options,
	 DialogParameters<TDialog> dialogParameters
	)
		where TDialog : DialogBase<TDialog, TResult>;
}
