namespace BlazorUiKit.Components;

public interface IBreadcrumbBarStaticPage
{
    static abstract void ConfigureBreadcrumbs(BreadcrumbBarConfigurationBuilder configurationBuilder);
}

public interface IBreadcrumbBarInteractivePage
{
    void ConfigureBreadcrumbs(BreadcrumbBarConfigurationBuilder builder);
}
