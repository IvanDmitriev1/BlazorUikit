namespace BlazorUiKit.Components;

public sealed class FlexGrid : UiKitElementComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public Justify Justify { get; set; } = Justify.Start;

    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        cssBuilder.AddClass("flex flex-wrap");
        cssBuilder.AddClass(Justify.ToTailwindCss());
    }

    protected override void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq)
    {
        builder.AddContent(seq++, ChildContent);
    }
}