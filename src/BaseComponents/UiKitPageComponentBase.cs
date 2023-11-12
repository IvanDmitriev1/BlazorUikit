namespace BlazorUiKit.BaseComponents;

public abstract class UiKitPageComponentBase : ComponentBase, IDisposable
{
    [Inject]
    protected PersistentComponentState ApplicationState { get; set; } = null!;

    protected CancellationToken CancellationToken => _cts?.Token ?? CancellationToken.None;

    private CancellationTokenSource? _cts;
    private PersistingComponentStateSubscription _persistingSubscription;

    protected virtual void OnDispose() { }
    protected virtual Task OnPersistData() => Task.CompletedTask;

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        try
        {
            _persistingSubscription.Dispose();
            _cts?.Cancel();

            OnDispose();
        }
        finally
        {
            _cts?.Dispose();
        }
    }

    protected override void OnInitialized()
    {
        _persistingSubscription = ApplicationState.RegisterOnPersisting(OnPersistData);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            _cts = new CancellationTokenSource();
        }
    }
}

public abstract class UiKitPageComponentBase<T> : UiKitPageComponentBase
    where T : IBreadcrumbBarStaticPage
{
    [CascadingParameter]
    protected IBreadcrumbService BreadcrumbService { get; set; } = null!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        BreadcrumbService.Set<T>();
    }
}
