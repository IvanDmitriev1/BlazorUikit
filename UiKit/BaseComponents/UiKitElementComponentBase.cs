using Microsoft.AspNetCore.Components.Rendering;

namespace UiKit.BaseComponents;

public abstract class UiKitElementComponentBase : UiKitComponentBase
{
	[Parameter]
	public string HtmlTag { get; set; } = "div";

	protected virtual void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq) { }

	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
		int seq = 0;

		//Open
		builder.OpenElement(seq++, HtmlTag);

		//Class
		builder.AddAttribute(seq++, "class", ComponentCss);

		// StopPropagation
		// the order matters. This has to be before content is added
		if (HtmlTag == "button")
			builder.AddEventStopPropagationAttribute(seq++, "onclick", true);

		OnBuildingRenderTree(builder, ref seq);

		//Close
		builder.CloseElement();
	}
}