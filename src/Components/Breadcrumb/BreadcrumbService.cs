using BlazorUiKit.Abstractions.Breadcrumb;

namespace BlazorUiKit.Components;

internal class BreadcrumbService : IBreadcrumbService
{
	private static readonly Dictionary<Type, RenderFragment[]> RenderFragmentsByBreadcrumbBarType = new();

	private BreadcrumbNavigation? _breadcrumbNavigation;

	public void AddBreadcrumbNavigation(BreadcrumbNavigation breadcrumbNavigation)
	{
		_breadcrumbNavigation = breadcrumbNavigation;
	}

	public void RemoveBreadcrumbNavigation()
	{
		_breadcrumbNavigation = null;
	}

	public void Set<T>() where T : IBreadcrumbBarPage
	{
		if (_breadcrumbNavigation is null)
			return;

		if (RenderFragmentsByBreadcrumbBarType.TryGetValue(typeof(T), out var renderFragments))
		{
			_breadcrumbNavigation.Add(renderFragments);
			return;
		}

		var builder = new BreadcrumbBarBuilder();
		T.ConfigureBreadcrumbs(builder);

		renderFragments = builder.Build();
		RenderFragmentsByBreadcrumbBarType.Add(typeof(T), renderFragments);

		_breadcrumbNavigation.Add(renderFragments);
	}
}