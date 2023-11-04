namespace BlazorUiKit.Abstractions.Breadcrumb;

public interface IBreadcrumbService
{
    void AddBreadcrumbNavigation(BreadcrumbNavigation breadcrumbNavigation);
    void RemoveBreadcrumbNavigation();

    void Set<T>() where T : IBreadcrumbBarPage;
}