namespace BlazorUiKit.Interfaces;

public interface IBreadcrumbService
{
    void SetBreadcrumbNavigation(BreadcrumbNavigation breadcrumbNavigation);

    void Set<T>() where T : IBreadcrumbBarStaticPage;
    void Set<T>(T value) where T : IBreadcrumbBarInteractivePage;
}