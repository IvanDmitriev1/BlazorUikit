﻿namespace BlazorUiKit.Components;

public static class BreadcrumbBarBuilder
{
	private static readonly Dictionary<BreadcrumbBarConfiguration, RenderFragment[]> RenderFragments = new();

	public static RenderFragment[] GetOrCreate<T>(TablerIcon separationIcon) where T : IBreadcrumbBarStaticPage
	{
		var config = BreadcrumbBarConfigurationBuilder.GetOrCreateConfiguration<T>();
		return GetOrCreateInternal(config, separationIcon);
	}

	public static RenderFragment[] Create<T>(T value, TablerIcon separationIcon) where T : IBreadcrumbBarInteractivePage
	{
		var config = BreadcrumbBarConfigurationBuilder.CreateConfiguration(value);
		return CreateInternal(config, separationIcon);
	}

	private static RenderFragment[] GetOrCreateInternal
		(BreadcrumbBarConfiguration configuration, TablerIcon separationIcon)
	{
		if (RenderFragments.TryGetValue(configuration, out var renderFragments))
			return renderFragments;

		renderFragments = CreateInternal(configuration, separationIcon);

		RenderFragments.Add(configuration, renderFragments);
		return renderFragments;
	}

	private static RenderFragment[] CreateInternal
		(BreadcrumbBarConfiguration configuration, TablerIcon separationIcon)
	{
		RenderFragment[]? parentRenderFragments = null;
		if (configuration.ParentBarConfiguration is not null)
		{
			parentRenderFragments =
				GetOrCreateInternal(configuration.ParentBarConfiguration, separationIcon);
		}

		var separationIconRenderFragment = SeparationIconRenderFragment(separationIcon);
		RenderFragment[] renderFragments;

		if (parentRenderFragments is not null)
		{
			renderFragments = new RenderFragment[parentRenderFragments.Length + 1 + (configuration.Parameters.Count * 2 - 1)];
			Array.Copy(parentRenderFragments, renderFragments, parentRenderFragments.Length);

			renderFragments[parentRenderFragments.Length] = separationIconRenderFragment;
		}
		else
		{
			renderFragments = new RenderFragment[configuration.Parameters.Count * 2 - 1];
		}

		int startingIndex = parentRenderFragments?.Length > 0 ? parentRenderFragments.Length + 1 : 0;

		int renderFragmentsIndex = startingIndex;
		foreach (var parameter in configuration.Parameters)
		{
			renderFragments[renderFragmentsIndex] = LinkRenderFragment(parameter);
			renderFragmentsIndex += 2;
		}

		for (int i = startingIndex + 1; i < renderFragments.Length; i += 2)
		{
			renderFragments[i] = separationIconRenderFragment;
		}

		return renderFragments;
	}


	private static readonly RenderFragment<BreadcrumbBarBuilderParameters> LinkRenderFragment = parameters => builder =>
	{
		int seq = 0;
		const string linkClass = "leading-4";

		builder.OpenComponent<UiLink>(seq++);
		builder.AddAttribute(seq++, "class", linkClass);
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