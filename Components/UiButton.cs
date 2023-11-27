namespace BlazorUiKit.Components;

public class UiButton : UiKitElementComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? UserAttributes { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public HrefTarget HrefTarget { get; set; } = HrefTarget.Self;

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Button;

    [Parameter]
    public Color Color { get; set; } = Color.Primary;

    [Parameter]
    public Variant Variant { get; set; } = Variant.Filled;

    [Parameter]
    public Size Size { get; set; } = Size.Medium;

    [Parameter]
    public TablerIcon Icon { get; set; } = TablerIcon.None;

    [Parameter]
    public ButtonIconPosition IconPosition { get; set; } = ButtonIconPosition.Content;


    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        cssBuilder.AddClass("inline-flex justify-center items-center");
        cssBuilder.AddClass("focus:ring focus:outline-none");
        cssBuilder.AddClass("transition duration-300");
        cssBuilder.AddClass("select-none rounded");
        cssBuilder.AddClass(Size switch
        {
            Size.Custom => string.Empty,
            Size.Small => "py-2.5 px-3",
            Size.Medium => "py-4 px-5 font-bold",
            Size.Large => "py-5 px-6 font-bold text-header",
            _ => throw new ArgumentOutOfRangeException()
        }, IconPosition != ButtonIconPosition.Content || Icon == TablerIcon.None);

        cssBuilder.AddClass("p-1.5", Icon != TablerIcon.None && IconPosition == ButtonIconPosition.Content);

        cssBuilder.AddClass(ThemeManager.ThemeProvider.BackgroundDisabledCss);
        cssBuilder.AddClass(ThemeManager.ThemeProvider.TextDisabledCss);

        var swappedColor = Color == Color.Primary ? Color.Secondary : Color;

        cssBuilder.AddClass("border shadow-sm", Variant == Variant.Filled);
        cssBuilder.AddClass("hover:shadow-sm", Variant == Variant.Text);
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToBackgroundCss(Color), Variant == Variant.Filled);
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToBorderCss(Color.Primary), Variant == Variant.Filled);
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToBackgroundHoverCss(swappedColor));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToBackgroundActiveCss(Color));

        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToRingFocusCss(Color));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToTextCss(Color));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToTextHoverCss(swappedColor));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToTextActiveCss(Color));
    }

    protected override void OnInitialized()
    {
        if (Disabled)
        {
            ElementTag = "button";
            Href = null;
            return;
        }

        ElementTag = !string.IsNullOrWhiteSpace(Href) ? "a" : "button";
    }

    protected override void OnElementRenderTree(RenderTreeBuilder builder, ref int seq)
    {
        builder.AddMultipleAttributes(seq++, UserAttributes);
        builder.AddAttribute(seq++, "type", Type.ToHtml());
        builder.AddAttribute(seq++, "href", Href);
        builder.AddAttribute(seq++, "target", HrefTarget.ToHtml());
        builder.AddAttribute(seq++, "disabled", Disabled);

        builder.AddContent(seq++, ContentRenderFragment());
    }

    private RenderFragment ContentRenderFragment() => builder =>
    {
        int seq = 0;
        var icon = IconRenderFragment();

        if (IconPosition == ButtonIconPosition.Left)
        {
            builder.AddContent(seq++, icon);
        }

        if (IconPosition == ButtonIconPosition.Content && Icon != TablerIcon.None)
        {
            builder.AddContent(seq++, icon);
        }
        else
        {
            builder.AddContent(seq++, ChildContent);
        }

        if (IconPosition == ButtonIconPosition.Right)
        {
            builder.AddContent(seq++, icon);
        }
    };

    private RenderFragment IconRenderFragment() => builder =>
    {
        int seq = 0;

        var iconPositionCss = IconPosition switch
        {
            ButtonIconPosition.Content => null,
            ButtonIconPosition.Left => "mr-2.5",
            ButtonIconPosition.Right => "ml-2.5",
            _ => throw new ArgumentOutOfRangeException()
        };

        using var cssBuilder = new CssBuilder(stackalloc char[55]);
        cssBuilder.AddClass(iconPositionCss);
        cssBuilder.AddClass(Size.ToIconSize());

        builder.OpenElement(seq++, "span");

        builder.AddAttribute(seq++, "class", cssBuilder.ToString());
        builder.AddContent(seq++, Icon.ToRenderFragment());

        builder.CloseElement();
    };
}