namespace UiKit.Components;

public sealed class FlexGrid : UiKitElementWithChildComponentBase
{
	[Parameter]
	public Justify Justify { get; set; } = Justify.Start;

	protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
	{
		cssBuilder.AddClass("flex flex-wrap");
		cssBuilder.AddClass(Justify.ToTailwindCss());
	}

	protected override void OnInitialized()
	{
		CacheCss = true;
	}
}