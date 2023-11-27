namespace BlazorUiKit.Components;

public sealed class FlexGridItem : UiKitElementComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter] public int Xs { get; set; }
    [Parameter] public int Sm { get; set; }
    [Parameter] public int Md { get; set; }
    [Parameter] public int Lg { get; set; }
    [Parameter] public int Xl { get; set; }


    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        cssBuilder.AddClass("box-border");
        cssBuilder.AddClass("flex-1");

        cssBuilder.AddClass(GetXsFlexBias(Xs));
        cssBuilder.AddClass(GetSmFlexBias(Sm));
        cssBuilder.AddClass(GetMdFlexBias(Md));
        cssBuilder.AddClass(GetLgFlexBias(Lg));
        cssBuilder.AddClass(GetXlFlexBias(Xl));
    }

    protected override void OnElementRenderTree(RenderTreeBuilder builder, ref int seq)
    {
        builder.AddContent(seq++, ChildContent);
    }

    private static string GetXsFlexBias(int value) => value switch
    {
        0 => string.Empty,
        1 => "basis-1/12",
        2 => "basis-2/12",
        3 => "basis-3/12",
        4 => "basis-4/12",
        5 => "basis-5/12",
        6 => "basis-6/12",
        7 => "basis-7/12",
        8 => "basis-8/12",
        9 => "basis-9/12",
        10 => "basis-10/12",
        11 => "basis-11/12",
        12 => "basis-full",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    private static string GetSmFlexBias(int value) => value switch
    {
        0 => string.Empty,
        1 => "sm:basis-1/12",
        2 => "sm:basis-2/12",
        3 => "sm:basis-3/12",
        4 => "sm:basis-4/12",
        5 => "sm:basis-5/12",
        6 => "sm:basis-6/12",
        7 => "sm:basis-7/12",
        8 => "sm:basis-8/12",
        9 => "sm:basis-9/12",
        10 => "sm:basis-10/12",
        11 => "sm:basis-11/12",
        12 => "sm:basis-full",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    private static string GetMdFlexBias(int value) => value switch
    {
        0 => string.Empty,
        1 => "md:basis-1/12",
        2 => "md:basis-2/12",
        3 => "md:basis-3/12",
        4 => "md:basis-4/12",
        5 => "md:basis-5/12",
        6 => "md:basis-6/12",
        7 => "md:basis-7/12",
        8 => "md:basis-8/12",
        9 => "md:basis-9/12",
        10 => "md:basis-10/12",
        11 => "md:basis-11/12",
        12 => "md:basis-full",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    private static string GetLgFlexBias(int value) => value switch
    {
        0 => string.Empty,
        1 => "lg:basis-1/12",
        2 => "lg:basis-2/12",
        3 => "lg:basis-3/12",
        4 => "lg:basis-4/12",
        5 => "lg:basis-5/12",
        6 => "lg:basis-6/12",
        7 => "lg:basis-7/12",
        8 => "lg:basis-8/12",
        9 => "lg:basis-9/12",
        10 => "lg:basis-10/12",
        11 => "lg:basis-11/12",
        12 => "lg:basis-full",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    private static ReadOnlySpan<char> GetXlFlexBias(int value) => value switch
    {
        0 => string.Empty,
        1 => "xl:basis-1/12",
        2 => "xl:basis-2/12",
        3 => "xl:basis-3/12",
        4 => "xl:basis-4/12",
        5 => "xl:basis-5/12",
        6 => "xl:basis-6/12",
        7 => "xl:basis-7/12",
        8 => "xl:basis-8/12",
        9 => "xl:basis-9/12",
        10 => "xl:basis-10/12",
        11 => "xl:basis-11/12",
        12 => "xl:basis-full",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
}