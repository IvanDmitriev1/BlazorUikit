namespace BlazorUiKit.Components;

public interface IBreadcrumbBarStaticPage
{
    static abstract void ConfigureBreadcrumbs(BreadcrumbBarBuilder builder);
}

public interface IBreadcrumbBarInteractivePage
{
    void ConfigureBreadcrumbs(BreadcrumbBarBuilder builder);
}
