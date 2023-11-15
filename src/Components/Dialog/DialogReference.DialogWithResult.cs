namespace BlazorUiKit.Components;

internal sealed class DialogReference<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult> : DialogReferenceBase, IDialogReference<TDialog, TResult>
    where TDialog : DialogBase<TDialog, TResult>
{
    public DialogReference()
    {
        InitializeContentRenderFragment<TDialog>();
    }

    public Task<TResult> CompletionTask => _tcs.Task;

    private readonly TaskCompletionSource<TResult> _tcs = new();

    public override void Cancel()
    {
        if (IsCanceledOrClosed)
            return;

        IsCanceledOrClosed = true;
        _tcs.SetCanceled();
        DialogService.RemoveDialog(Id);
    }

    public void Close(TResult result)
    {
        if (IsCanceledOrClosed)
            return;

        ActualDialog?.OnClosing();

        if (ActualDialog?.CanClose != true)
            return;

        _tcs.SetResult(result);
        DialogService.RemoveDialog(Id);
        IsCanceledOrClosed = true;
    }
}