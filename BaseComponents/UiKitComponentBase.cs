namespace BlazorUiKit.BaseComponents;

public abstract class UiKitComponentBase : ComponentBase
{
    [Parameter]
    public string? Class { get; set; }

    protected bool IsJsRuntimeAvailable { get; private set; }
    protected bool IncludeClassCss { get; set; } = true;
    protected string ComponentCss => BuildComponentCss();

    private string? _componentCss;

    protected abstract void AddComponentCssClasses(ref CssBuilder cssBuilder);

    protected virtual void OnFirstRender() { }
    protected virtual Task OnFirstRenderAsync() => Task.CompletedTask;

    protected override void OnAfterRender(bool firstRender)
    {
        if (!firstRender)
            return;

        IsJsRuntimeAvailable = true;
        OnFirstRender();
    }

    protected override Task OnAfterRenderAsync
        (bool firstRender) => firstRender ? OnFirstRenderAsync() : Task.CompletedTask;

    private string BuildComponentCss()
    {
        if (!string.IsNullOrWhiteSpace(_componentCss))
        {
            return _componentCss;
        }

        var cssBuilder = new CssBuilder(stackalloc char[455]);

        try
        {
            if (Class is not null && IncludeClassCss)
                cssBuilder.AddClass(Class);

            AddComponentCssClasses(ref cssBuilder);

            return _componentCss = cssBuilder.ToString();
        }
        finally
        {
            cssBuilder.Dispose();
        }
    }
}