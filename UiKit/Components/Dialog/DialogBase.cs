using System.Runtime.CompilerServices;
using UiKit.Abstractions.Dialog;

namespace UiKit.Components;

public abstract class DialogBase : ComponentBase, IDisposable
{
    protected IDialogReferenceBase DialogReferenceBase { get; set; } = null!;

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        DialogReferenceBase.ActualDialog = null;
        OnDispose();
    }

    protected virtual void OnDispose() { }

    protected override void OnInitialized()
    {
        DialogReferenceBase.ActualDialog = this;
    }

    public virtual bool OnClosing() => true;
}

public abstract class DialogBase<TSelf> : DialogBase
{
    protected IDialogReference<TSelf> DialogReference => Unsafe.As<IDialogReference<TSelf>>(DialogReferenceBase);
}

public abstract class DialogBase<TSelf, TResult> : DialogBase
{
    protected IDialogReference<TSelf, TResult> DialogReference => Unsafe.As<IDialogReference<TSelf, TResult>>(DialogReferenceBase);
}