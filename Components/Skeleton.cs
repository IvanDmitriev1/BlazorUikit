namespace BlazorUiKit.Components;

public sealed class Skeleton : UiKitElementComponentBase
{
    [Parameter]
    public bool FullWidth { get; set; }

    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        cssBuilder.AddClass("rounded");
        cssBuilder.AddClass("animate-pulse");
        cssBuilder.AddClass("w-full", FullWidth);
    }

    protected override void OnElementRenderTree(RenderTreeBuilder builder, ref int seq)
    {

    }

    protected override bool ShouldRender() => !IsJsRuntimeAvailable;
}