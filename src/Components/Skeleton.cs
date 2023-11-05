namespace BlazorUiKit.Components;

public sealed class Skeleton : UiKitElementComponentBase
{
	[Parameter]
	public bool FullWidth { get; set; }

	protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
	{
		cssBuilder.AddClass("block");
		cssBuilder.AddClass("bg-dark-gray-5");
		cssBuilder.AddClass("rounded");
		cssBuilder.AddClass("w-full", FullWidth);
	}

	protected override void OnInitialized()
	{
		HtmlTag = "span";
		CacheCss = true;
	}

	protected override bool ShouldRender() => !IsJsRuntimeAvailable;
}