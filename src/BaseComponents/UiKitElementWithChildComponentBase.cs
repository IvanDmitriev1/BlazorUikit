namespace BlazorUiKit.BaseComponents;

public abstract class UiKitElementWithChildComponentBase : UiKitElementComponentBase
{
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	protected override void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq)
	{
		//Content
		builder.AddContent(seq++, ChildContent);
	}
}