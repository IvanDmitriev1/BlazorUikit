using Blazor.TablerIcons;
using BlazorUiKit.Abstractions.Breadcrumb;

namespace BlazorUiKit.Components;

internal class BreadcrumbService : IBreadcrumbService
{
	private static readonly Dictionary<Type, RenderFragment[]> RenderFragmentsByBreadcrumbBarType = new();

	private BreadcrumbNavigation? _breadcrumbNavigation;

	public void SetBreadcrumbNavigation(BreadcrumbNavigation breadcrumbNavigation)
	{
		_breadcrumbNavigation = breadcrumbNavigation;
	}

	public void RemoveBreadcrumbNavigation()
	{
		_breadcrumbNavigation = null;
	}

	public void Set<T>(TablerIcon separationIcon) where T : IBreadcrumbBarStaticPage
	{
		if (_breadcrumbNavigation is null)
			return;

		if (RenderFragmentsByBreadcrumbBarType.TryGetValue(typeof(T), out var renderFragments))
		{
			_breadcrumbNavigation.Add(renderFragments);
			return;
		}

		var configuration = BreadcrumbBarConfigurationBuilder.GetOrCreateConfiguration<T>();
		renderFragments = BreadcrumbBarBuilder.GetOrCreateRenderFragmentFromStaticBreadcrumb(configuration, separationIcon);
		RenderFragmentsByBreadcrumbBarType.Add(typeof(T), renderFragments);

		_breadcrumbNavigation.Add(renderFragments);
	}

	public void Set<T>(T value, TablerIcon separationIcon) where T : IBreadcrumbBarInteractivePage
	{
		if (_breadcrumbNavigation is null)
			return;

		var configuration = BreadcrumbBarConfigurationBuilder.CreateConfiguration(value);
		var renderFragments = BreadcrumbBarBuilder.CreateRenderFragments(configuration, separationIcon);

		_breadcrumbNavigation.Add(renderFragments);
	}
}