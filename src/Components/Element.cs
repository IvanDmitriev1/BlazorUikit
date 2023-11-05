namespace BlazorUiKit.Components;

public sealed class Element : UiKitElementComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? UserAttributes { get; set; }

    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder) { }

    protected override void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq)
    {
        builder.AddMultipleAttributes(seq++, UserAttributes);
        builder.AddContent(seq++, ChildContent);
    }
}
