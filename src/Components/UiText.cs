namespace BlazorUiKit.Components;

public class UiText : UiKitElementComponentBase
{
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Parameter]
	public Typo Typo { get; set; } = Typo.Regular;

	[Parameter]
	public Color Color { get; set; } = Color.Primary;

	[Parameter]
	public Align Align { get; set; }

	[Parameter]
	public TextOverflow TextOverflow { get; set; }

	protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
	{
		cssBuilder.AddClass(Typo.ToTailwindCss());
		cssBuilder.AddClass(ThemeManager.ThemeProvider.ToTextCss(Color));
		cssBuilder.AddClass(Align.ToTailwindCss());
		cssBuilder.AddClass(TextOverflow.ToTailwindCss());
	}

	protected override void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq)
	{
		builder.AddContent(seq++, ChildContent);
	}

	protected override void OnInitialized()
	{
		CacheCss = true;
	}

	protected override void OnParametersSet()
	{
		HtmlTag = Typo.ToHtmlTag();
	}

	protected override bool ShouldRender() => !IsJsRuntimeAvailable;
}