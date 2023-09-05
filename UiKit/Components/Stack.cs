namespace UiKit.Components;

public sealed class Stack : UiKitElementWithChildComponentBase
{
	[Parameter]
	public Direction Direction { get; set; } = Direction.Row;

	[Parameter]
	public Justify Justify { get; set; } = Justify.None;

	[Parameter]
	public AlignItems AlignItems { get; set; } = AlignItems.None;

	[Parameter]
	public bool FullWidth { get; set; }

	protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
	{
		cssBuilder.AddClass("flex");
		cssBuilder.AddClass(Direction.ToTailwindCss());
		cssBuilder.AddClass(Justify.ToTailwindCss());
		cssBuilder.AddClass(AlignItems.ToTailwindCss());
		cssBuilder.AddClass("w-full", FullWidth);
	}
}