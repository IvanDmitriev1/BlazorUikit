namespace BlazorUiKit.Components;

internal record struct BreadcrumbBarBuilderParameters
	(string Title, string Href, NavLinkMatch LinkMatch);

public sealed class BreadcrumbBarBuilder
{
	private readonly List<BreadcrumbBarBuilderParameters> _parameters = new(1);
	private TablerIcon _icon;

	public void SetIcon(TablerIcon icon)
	{
		_icon = icon;
	}

	public void AddParent<T>() where T : IBreadcrumbBarStaticPage
	{
		T.ConfigureBreadcrumbs(this);
	}

	public void AddItem(string title, string href, NavLinkMatch linkMatch = NavLinkMatch.Prefix)
	{
		_parameters.Add(new BreadcrumbBarBuilderParameters(title, href, linkMatch));
	}

	public RenderFragment[] Build()
	{
		var separationIconRenderFragment = UiKitIcon.IconRenderFragment((_icon, Size.Small.ToIconSize()));
		RenderFragment[] fragments = new RenderFragment[_parameters.Count * 2 - 1];

		int renderFragmentsIndex = 0;
		foreach (var parameter in _parameters)
		{
			fragments[renderFragmentsIndex] = LinkRenderFragment(parameter);
			renderFragmentsIndex += 2;
		}

		for (int i = 1; i < fragments.Length; i += 2)
		{
			fragments[i] = separationIconRenderFragment;
		}

		return fragments;
	}

	private static readonly RenderFragment<BreadcrumbBarBuilderParameters> LinkRenderFragment = parameters => builder =>
	{
		int seq = 0;

		builder.OpenComponent<UiLink>(seq++);
		builder.AddComponentParameter(seq++, nameof(UiLink.Href), parameters.Href);
		builder.AddComponentParameter(seq++, nameof(UiLink.Typo), Typo.Header);
		builder.AddComponentParameter(seq++, nameof(UiLink.Match), parameters.LinkMatch);
		builder.AddComponentParameter(seq++, nameof(UiLink.ChildContent), StringToRenderFragment(parameters.Title));
		builder.CloseComponent();
	};

	private static readonly RenderFragment<string> StringToRenderFragment = value => builder =>
	{
		builder.AddContent(0, value);
	};
}