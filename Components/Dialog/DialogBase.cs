using System.Runtime.CompilerServices;

namespace BlazorUiKit.Components;

public abstract class DialogBase : ComponentBase, IDisposable
{
    [CascadingParameter]
    protected IDialogReferenceBase DialogReferenceBase { get; set; } = null!;

    public bool CanClose { get; set; } = true;

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        DialogReferenceBase.ActualDialog = null;
        DialogReferenceBase.Cancel();

        OnDispose();
    }

    protected virtual void OnDispose() { }

    protected override void OnInitialized()
    {
        DialogReferenceBase.ActualDialog = this;
    }

    public virtual void OnClosing() { }
}

public abstract class DialogBase<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TSelf> : DialogBase
{
    protected IDialogReference<TSelf> DialogReference => Unsafe.As<IDialogReference<TSelf>>(DialogReferenceBase);
}

public abstract class DialogBase<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TSelf, TResult> : DialogBase
{
    protected IDialogReference<TSelf, TResult> DialogReference => Unsafe.As<IDialogReference<TSelf, TResult>>(DialogReferenceBase);
}