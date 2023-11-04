namespace BlazorUiKit.Components;

internal class BreadcrumbService : IBreadcrumbService
{
	private BreadcrumbNavigation? _breadcrumbNavigation;

	public void SetBreadcrumbNavigation(BreadcrumbNavigation breadcrumbNavigation)
	{
		_breadcrumbNavigation = breadcrumbNavigation;
	}

	public void Set<T>(TablerIcon separationIcon) where T : IBreadcrumbBarStaticPage
	{
		if (_breadcrumbNavigation is null)
			return;

		var renderFragments = BreadcrumbBarBuilder.GetOrCreate<T>(separationIcon);
		_breadcrumbNavigation.Add(renderFragments);
	}

	public void Set<T>(T value, TablerIcon separationIcon) where T : IBreadcrumbBarInteractivePage
	{
		if (_breadcrumbNavigation is null)
			return;

		var renderFragments = BreadcrumbBarBuilder.Create(value, separationIcon);
		_breadcrumbNavigation.Add(renderFragments);
	}
}