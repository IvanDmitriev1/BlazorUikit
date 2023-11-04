namespace BlazorUiKit.Services;

internal class DialogService : IDialogService
{
    private static readonly IDictionary<string, object> EmptyParameters = new Dictionary<string, object>();
    private DialogProvider? _dialogProvider;

    public void AddDialogProvider(DialogProvider dialogProvider)
    {
        _dialogProvider = dialogProvider;
    }

    public void RemoveDialog(Guid id)
    {
        _dialogProvider?.RemoveDialog(id);
    }

    public IDialogReference Show(DialogDisplayOptions options, RenderFragment renderFragment)
    {
        ArgumentNullException.ThrowIfNull(_dialogProvider);

        var dialogReference = new RenderFragmentDialogReference(renderFragment)
        {
            DialogService = this,
            DialogPosition = _dialogProvider.DisplayedDialogs + 1,
            DisplayOptions = options,
            Parameters = EmptyParameters
        };

        _dialogProvider.AddDialog(dialogReference);
        return dialogReference;
    }

    public IDialogReference<TDialog> Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog>(DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters) where TDialog : DialogBase
    {
        ArgumentNullException.ThrowIfNull(_dialogProvider);

        var dialogReference = new DialogReference<TDialog>
        {
            DialogService = this,
            DialogPosition = _dialogProvider.DisplayedDialogs + 1,
            DisplayOptions = options,
            Parameters = dialogParameters,
        };

        _dialogProvider.AddDialog(dialogReference);
        return dialogReference;
    }

    public IDialogReference<TDialog, TResult> Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult>(DialogDisplayOptions options, DialogParameters<TDialog> dialogParameters) where TDialog : DialogBase<TDialog, TResult>
    {
        ArgumentNullException.ThrowIfNull(_dialogProvider);

        var dialogReference = new DialogReference<TDialog, TResult>
        {
            DialogService = this,
            DialogPosition = _dialogProvider.DisplayedDialogs + 1,
            DisplayOptions = options,
            Parameters = dialogParameters
        };

        _dialogProvider.AddDialog(dialogReference);
        return dialogReference;
    }
}