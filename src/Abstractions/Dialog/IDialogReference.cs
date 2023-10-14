using System.Diagnostics.CodeAnalysis;

namespace BlazorUiKit.Abstractions.Dialog;

public interface IDialogReferenceBase
{
    Guid Id { get; }
    IDictionary<string, object> Parameters { get; init; }
    DialogDisplayOptions DisplayOptions { get; init; }
    int DialogPosition { get; init; }

    RenderFragment DialogContent { get; }
    DialogBase? ActualDialog { get; set; }

    void Cancel();
}

public interface IDialogReference : IDialogReferenceBase
{
    Task CompletionTask { get; }
    void Close();
}

public interface IDialogReference<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog> : IDialogReference
{
    
}

public interface IDialogReference<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TDialog, TResult> : IDialogReferenceBase
{
    Task<TResult> CompletionTask { get; }
    void Close(TResult result);
}