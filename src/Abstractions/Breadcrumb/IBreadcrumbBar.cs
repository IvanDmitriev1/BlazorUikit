namespace BlazorUiKit.Abstractions.Breadcrumb;

public interface IBreadcrumbBarStaticPage
{
    static abstract void ConfigureBreadcrumbs(BreadcrumbBarConfigurationBuilder configurationBuilder);
}

public interface IBreadcrumbBarInteractivePage
{
    void ConfigureBreadcrumbs(BreadcrumbBarConfigurationBuilder builder);
}
