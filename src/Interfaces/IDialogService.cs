namespace BlazorUiKit.Interfaces;

public interface IDialogService
{
    void AddDialogProvider(DialogProvider dialogProvider);
    void RemoveDialog(Guid id);

    IDialogReference Show
        (DialogDisplayOptions options, RenderFragment renderFragment);

    IDialogReference<TDialog> Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog>
    (DialogDisplayOptions options,
     DialogParameters<TDialog> dialogParameters
    )
        where TDialog : DialogBase;

    IDialogReference<TDialog, TResult> Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult>
    (DialogDisplayOptions options,
     DialogParameters<TDialog> dialogParameters
    )
        where TDialog : DialogBase<TDialog, TResult>;
}
