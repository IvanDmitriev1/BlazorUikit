namespace UiKit.BaseComponents;

public abstract class UiKitComponentBase : ComponentBase
{
    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public bool CacheCss { get; set; }

    protected bool IncludeClassCss { get; set; } = true;
    protected string ComponentCss => GetComponentCss();

    private string? _componentCss;

    protected abstract void AddComponentCssClasses(ref CssBuilder cssBuilder);

    private string GetComponentCss()
    {
        if (CacheCss && !string.IsNullOrWhiteSpace(_componentCss))
        {
            return _componentCss;
        }

        return _componentCss = BuildComponentCss();
    }

    private string BuildComponentCss()
    {
        var cssBuilder = new CssBuilder(stackalloc char[456]);

        try
        {
            AddComponentCssClasses(ref cssBuilder);

            if (Class is not null && IncludeClassCss)
                cssBuilder.AddClass(Class);

            return cssBuilder.ToString();
        }
        finally
        {
            cssBuilder.Dispose();
        }
    }
}