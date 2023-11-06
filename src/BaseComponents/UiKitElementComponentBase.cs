namespace BlazorUiKit.BaseComponents;

public abstract class UiKitElementComponentBase : UiKitComponentBase
{
	public ElementReference ElementReference { get; private set; }
	protected string ElementTag { get; set; } = "div";

	protected virtual void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq) { }

	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
		int seq = 0;

		builder.OpenElement(seq++, ElementTag);
		builder.AddAttribute(seq++, "class", ComponentCss);

		// StopPropagation
		// the order matters. This has to be before content is added
		if (ElementTag == "button")
			builder.AddEventStopPropagationAttribute(seq++, "onclick", true);

		OnBuildingRenderTree(builder, ref seq);

		builder.AddElementReferenceCapture(seq++, ElementReferenceCaptureAction);
		builder.CloseElement();
	}

	private void ElementReferenceCaptureAction(ElementReference obj)
	{
		ElementReference = obj;
	}
}