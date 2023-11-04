namespace BlazorUiKit.Interfaces;

public interface IBreadcrumbService
{
    void SetBreadcrumbNavigation(BreadcrumbNavigation breadcrumbNavigation);

    void Set<T>(TablerIcon separationIcon) where T : IBreadcrumbBarStaticPage;
    void Set<T>(T value, TablerIcon separationIcon) where T : IBreadcrumbBarInteractivePage;
}