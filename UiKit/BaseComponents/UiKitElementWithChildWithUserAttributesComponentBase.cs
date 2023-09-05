using Microsoft.AspNetCore.Components.Rendering;

namespace UiKit.BaseComponents;

public abstract class UiKitElementWithChildWithUserAttributesComponentBase : UiKitElementWithChildComponentBase
{
	/// <summary>
	/// UserAttributes carries all attributes you add to the component that don't match any of its parameters.
	/// They will be splatted onto the underlying HTML tag.
	/// </summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object> UserAttributes { get; set; } = new();

	protected override void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq)
	{
		//splatted attributes
		builder.AddMultipleAttributes(seq++, UserAttributes);

		base.OnBuildingRenderTree(builder, ref seq);
	}
}