namespace BlazorUiKit.Interfaces;

public interface IDialogService
{
    void SetDialogProvider(DialogProvider dialogProvider);
    void RemoveDialog(string id);

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
