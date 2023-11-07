namespace BlazorUiKit.Components;

internal class BreadcrumbService : IBreadcrumbService
{
	private static readonly Dictionary<Type, RenderFragment[]> StaticBreadcrumbBars = new();

	private BreadcrumbNavigation? _breadcrumbNavigation;

	public void SetBreadcrumbNavigation(BreadcrumbNavigation breadcrumbNavigation)
	{
		_breadcrumbNavigation = breadcrumbNavigation;
	}

	public void Set<T>() where T : IBreadcrumbBarStaticPage
	{
		if (_breadcrumbNavigation is null)
			return;

		if (StaticBreadcrumbBars.TryGetValue(typeof(T), out var renderFragments))
		{
			_breadcrumbNavigation.Add(renderFragments);
			return;
		}

		var builder = new BreadcrumbBarBuilder();
		T.ConfigureBreadcrumbs(builder);

		renderFragments = builder.Build();
		StaticBreadcrumbBars.Add(typeof(T), renderFragments);
		_breadcrumbNavigation.Add(renderFragments);
	}

	public void Set<T>(T value) where T : IBreadcrumbBarInteractivePage
	{
		if (_breadcrumbNavigation is null)
			return;

		var builder = new BreadcrumbBarBuilder();
		value.ConfigureBreadcrumbs(builder);
		var renderFragments = builder.Build();
		_breadcrumbNavigation.Add(renderFragments);
	}
}