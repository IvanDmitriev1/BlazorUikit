namespace BlazorUiKit.Components;

public sealed class Stack : UiKitElementComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string HtmlTag
    {
        get => ElementTag;
        set => ElementTag = value;
    }

    [Parameter]
    public Direction Direction { get; set; } = Direction.Row;

    [Parameter]
    public Justify Justify { get; set; } = Justify.None;

    [Parameter]
    public AlignItems AlignItems { get; set; } = AlignItems.None;

    [Parameter]
    public bool FullWidth { get; set; }

    [Parameter]
    public bool AsCard { get; set; }

    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        if (!cssBuilder.Contains("hidden") || cssBuilder.Contains("block"))
        {
            cssBuilder.AddClass("flex");
        }

        cssBuilder.AddClass(Direction.ToTailwindCss());
        cssBuilder.AddClass(Justify.ToTailwindCss());
        cssBuilder.AddClass(AlignItems.ToTailwindCss());
        cssBuilder.AddClass("w-full", FullWidth);

        cssBuilder.AddClass(ThemeManager.ThemeProvider.BackgroundCardCss, AsCard);
        cssBuilder.AddClass("rounded border border-dark-gray shadow", AsCard);
    }

    protected override void OnElementRenderTree(RenderTreeBuilder builder, ref int seq)
    {
        builder.AddContent(seq++, ChildContent);
    }
}