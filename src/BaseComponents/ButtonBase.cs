namespace BlazorUiKit.BaseComponents;

public abstract class ButtonBase : UiKitComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public bool HrefOutside { get; set; }

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
    public bool TextCenter { get; set; } = true;

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }
    
    [Parameter]
    public string? OnClickJs { get; set; }

    protected string HtmlTag { get; set; } = "button";

    protected override void OnParametersSet()
    {
        if (Disabled)
        {
            HtmlTag = "button";
            Href = null;
            return;
        }

        if (!string.IsNullOrWhiteSpace(Href))
        {
            HtmlTag = "a";
        }
    }

    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        cssBuilder.AddClass("rounded");
        cssBuilder.AddClass("focus:ring focus:outline-none");
        cssBuilder.AddClass("transition duration-300");
        cssBuilder.AddClass("text-center", TextCenter);

        cssBuilder.AddClass(Color.ToTextDisabledCss(), Disabled);
        cssBuilder.AddClass(Color.ToBackgroundDisabledCss(), Disabled);

        if (Disabled)
        {
            return;
        }

        cssBuilder.AddClass(Color.ToRingFocusCss());
        cssBuilder.AddClass(Color.ToTextCss());
        cssBuilder.AddClass(Color.ToTextActiveCss());
        cssBuilder.AddClass(Color.ToTextHoverCss());
        
        cssBuilder.AddClass(Color.ToBackgroundCss(), Variant == Variant.Filled);

        cssBuilder.AddClass(Color switch
        {
            Color.Primary            => ColorExtensions.BackgroundPrimaryHoverButtonColor,
            Color.PrimaryAlternative => ColorExtensions.BackgroundPrimaryAlternativeHoverButtonColor,
            _                        => Color.ToBackgroundHoverCss()
        });

        cssBuilder.AddClass(Color switch
        {
            Color.Primary            => ColorExtensions.BackgroundPrimaryActiveButtonColor,
            Color.PrimaryAlternative => ColorExtensions.BackgroundPrimaryAlternativeActiveButtonColor,
            _                        => Color.ToBackgroundActiveCss()
        });
    }
}