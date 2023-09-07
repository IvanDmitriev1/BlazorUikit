using UiKit.Components;

namespace UiKit.Abstractions.Dialog;

public interface IDialogReferenceBase
{
    Guid Id { get; }
    IDictionary<string, object> Parameters { get; init; }
    DialogDisplayOptions DisplayOptions { get; init; }

    RenderFragment DialogContent { get; }
    DialogBase? ActualDialog { get; set; }

    void Cancel();
}

public interface IDialogReference<TDialog> : IDialogReferenceBase
{
    Task CompletionTask { get; }

    void Close();
}

public interface IDialogReference<TDialog, TResult> : IDialogReferenceBase
{
    Task<TResult> CompletionTask { get; }

    void Close(TResult result);
}