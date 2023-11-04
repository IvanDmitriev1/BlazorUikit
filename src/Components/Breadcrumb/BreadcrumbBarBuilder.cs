using System.Buffers;
using Blazor.TablerIcons;
using BlazorUiKit.Abstractions.Breadcrumb;
using CommunityToolkit.HighPerformance.Buffers;

namespace BlazorUiKit.Components;

public sealed class BreadcrumbBarBuilder
{
	private record struct BreadcrumbBarBuilderParameters
		(string Title, string Href, NavLinkMatch LinkMatch);

	private readonly List<BreadcrumbBarBuilderParameters> _parameters = new();
	private TablerIcon _icon = TablerIcon.None;

	public void AddBase<T>() where T : IBreadcrumbBarPage
	{
		T.ConfigureBreadcrumbs(this);
	}

	public void SetSeparationIcon(TablerIcon icon)
	{
		_icon = icon;
	}

	public void AddBreadcrumbItem(string title, string href, NavLinkMatch linkMatch = NavLinkMatch.Prefix)
	{
		_parameters.Add(new BreadcrumbBarBuilderParameters(title, href, linkMatch));
	}

	public RenderFragment[] Build()
	{
		var separationIconRenderFragment = SeparationIconRenderFragment(_icon);
		var fragments = new RenderFragment[_parameters.Count * 2 - 1];

		for (int i = 0; i < _parameters.Count; i++)
		{
			fragments[i * 2] = TitleRenderFragment(_parameters[i]);
		}

		for (int i = 1; i < fragments.Length; i += 2)
		{
			fragments[i] = separationIconRenderFragment;
		}

		return fragments;
	}

	private static readonly RenderFragment<BreadcrumbBarBuilderParameters> TitleRenderFragment = parameters => builder =>
	{
		int seq = 0;

		builder.OpenComponent<UiLink>(seq++);
		builder.AddComponentParameter(seq++, nameof(UiLink.Href), parameters.Href);
		builder.AddComponentParameter(seq++, nameof(UiLink.Typo), Typo.Header);
		builder.AddComponentParameter(seq++, nameof(UiLink.Match), parameters.LinkMatch);
		builder.AddComponentParameter(seq++, nameof(UiLink.ChildContent), StringToRenderFragment(parameters.Title));
		builder.CloseComponent();
	};

	private static readonly RenderFragment<TablerIcon> SeparationIconRenderFragment = icon => builder =>
	{
		int seq = 0;

		builder.OpenComponent<UiKitIcon>(seq++);
		builder.AddComponentParameter(seq++, nameof(UiKitIcon.Icon), icon);
		builder.AddComponentParameter(seq++, nameof(UiKitIcon.Size), Size.Small);
		builder.CloseComponent();
	};

	private static readonly RenderFragment<string> StringToRenderFragment = value => builder =>
	{
		builder.AddContent(0, value);
	};
}
