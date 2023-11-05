namespace BlazorUiKit.Components;

public record struct BreadcrumbBarBuilderParameters
	(string Title, string Href, NavLinkMatch LinkMatch);

public record BreadcrumbBarConfiguration
(
	IReadOnlyList<BreadcrumbBarBuilderParameters> Parameters,
	BreadcrumbBarConfiguration? ParentBarConfiguration
);

public sealed class BreadcrumbBarConfigurationBuilder
{
	private BreadcrumbBarConfigurationBuilder() { }

	private static readonly Dictionary<Type, BreadcrumbBarConfiguration> BreadcrumbBarConfigurations = new();

	private readonly List<BreadcrumbBarBuilderParameters> _parameters = new(1);
	private BreadcrumbBarConfiguration? _parentBarConfiguration;

	public static BreadcrumbBarConfiguration GetOrCreateConfiguration<T>() where T : IBreadcrumbBarStaticPage
	{
		if (BreadcrumbBarConfigurations.TryGetValue(typeof(T), out var configuration))
			return configuration;

		var builder = new BreadcrumbBarConfigurationBuilder();
		T.ConfigureBreadcrumbs(builder);

		configuration = builder.Build();
		BreadcrumbBarConfigurations.Add(typeof(T), configuration);

		return configuration;
	}

	public static BreadcrumbBarConfiguration CreateConfiguration<T>(T value) where T : IBreadcrumbBarInteractivePage
	{
		var builder = new BreadcrumbBarConfigurationBuilder();
		value.ConfigureBreadcrumbs(builder);

		return builder.Build();
	}

	public void SetParent<T>() where T : IBreadcrumbBarStaticPage
	{
		_parentBarConfiguration = GetOrCreateConfiguration<T>();
	}

	public void AddItem(string title, string href, NavLinkMatch linkMatch = NavLinkMatch.Prefix)
	{
		_parameters.Add(new BreadcrumbBarBuilderParameters(title, href, linkMatch));
	}

	public BreadcrumbBarConfiguration Build() => new(_parameters, _parentBarConfiguration);
}