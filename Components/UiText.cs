namespace BlazorUiKit.Components;

public class UiText : UiKitElementComponentBase
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
    public Typo Typo { get; set; } = Typo.Regular;

    [Parameter]
    public Color Color { get; set; } = Color.Primary;

    [Parameter]
    public Align Align { get; set; }

    [Parameter]
    public TextOverflow TextOverflow { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToTextCss(Color));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.TextDisabledCss);
        cssBuilder.AddClass(Typo.ToTailwindCss());
        cssBuilder.AddClass(Align.ToTailwindCss());
        cssBuilder.AddClass(TextOverflow.ToTailwindCss());
        cssBuilder.AddClass("aria-disabled:select-none");
    }

    protected override void OnElementRenderTree(RenderTreeBuilder builder, ref int seq)
    {
        if (Disabled)
        {
            builder.AddAttribute(seq++, "aria-disabled", "true");
        }

        builder.AddContent(seq++, ChildContent);
    }

    protected override void OnParametersSet()
    {
        ElementTag = Typo.ToHtmlTag();
    }
}