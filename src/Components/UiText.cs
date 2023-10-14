namespace BlazorUiKit.Components;

public class UiText : UiKitElementWithChildComponentBase
{
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
		cssBuilder.AddClass(Color.ToTextCss());
		cssBuilder.AddClass(Align.ToTailwindCss());
		cssBuilder.AddClass(TextOverflow.ToTailwindCss());
	}

	protected override void OnParametersSet()
	{
		HtmlTag = Typo.ToHtmlTag();
	}
}