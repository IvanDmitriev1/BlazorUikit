namespace BlazorUiKit.Utilities;

public class DefaultThemeProvider : IThemeProvider
{
    private DefaultThemeProvider() {}

    public static IThemeProvider Instance { get; } = new DefaultThemeProvider();
    
    #region Background

    public string ToBackgroundCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "bg-inherit",
        Color.Primary => "bg-white dark:bg-dark-gray",
        Color.Error => "bg-error",
        Color.Successful => "bg-successful",
        Color.Warning => "bg-warning",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToBackgroundHoverCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "hover:bg-inherit",
        Color.Primary => "hover:bg-black/15 dark:hover:bg-dark-gray-15",
        Color.Error => "hover:bg-error-light",
        Color.Successful => "hover:bg-successful-light",
        Color.Warning => "hover:bg-warning-light",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToBackgroundActiveCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "active:bg-inherit",
        Color.Primary => "active:bg-black/15 dark:active:bg-dark-gray-15",
        Color.Error => "active:bg-error-dark",
        Color.Successful => "active:bg-successful-dark",
        Color.Warning => "active:bg-warning-dark",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToBackgroundDisabledCss() => "bg-black/5 dark:bg-dark-gray-5";

    #endregion

    #region Text

    public string ToTextCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "text-inherit",
        Color.Primary => "text-black dark:text-white",
        Color.Error => "text-error-light",
        Color.Successful => "text-successful",
        Color.Warning => "text-warning",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToTextHoverCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "hover:text-inherit",
        Color.Primary => "hover:text-white dark:hover:text-black",
        Color.Error => "text-white",
        Color.Successful => "text-white",
        Color.Warning => "text-white",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToTextActiveCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "active:text-inherit",
        Color.Primary => "active:text-white dark:active:text-black",
        Color.Error => "text-white",
        Color.Successful => "text-white",
        Color.Warning => "text-white",
        _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
    };

    public string ToTextDisabledCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        _ => "text-black/20 dark:text-dark-gray-20"
    };

    public string ToTextPlaceholderCss() => "text-black/30 dark:text-dark-gray-30";

    #endregion

    public string ToBorderCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "border-inherit",
        _ => "border-black/5 dark:border-dark-gray-5"
    };

    public string ToRingCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "ring-inherit",
        _ => "ring-black/5 dark:ring-dark-gray-5"
    };

    public string ToRingFocusWithinCss(Color color) => color switch
    {
        Color.Custom => string.Empty,
        Color.Inherit => "focus-within:ring-inherit",
        _ => "focus-within:ring-black/5 dark:focus-within:ring-dark-gray-5"
    };

    #region Enums

    public string ToDisplayCss(Display value) => value switch
    {
        Display.Block => "block",
        Display.Flex => "flex",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    
    public string ToAlignCss(Align value) => value switch
    {
        Align.Inherit => string.Empty,
        Align.Left => "text-left",
        Align.Center => "text-center",
        Align.Right => "text-right",
        Align.Justify => "text-justify",
        Align.Start => "text-start",
        Align.End => "text-end",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    public string ToAlignItemsCss(AlignItems value) => value switch
    {
        AlignItems.None => string.Empty,
        AlignItems.Baseline => "items-baseline",
        AlignItems.Center => "items-center",
        AlignItems.Start => "items-start",
        AlignItems.End => "items-end",
        AlignItems.Stretch => "items-stretch",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    public string ToBreakpointCss(Breakpoint value) => value switch
    {
        Breakpoint.Sm => "max-w-screen-sm",
        Breakpoint.Md => "max-w-screen-md",
        Breakpoint.Lg => "max-w-screen-lg",
        Breakpoint.Xl => "max-w-screen-xl",
        Breakpoint.XxL => "max-w-screen-2xl",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    public string ToDirectionCss(Direction value) => value switch
    {
        Direction.Row => "flex-row",
        Direction.RowReverse => "flex-row-reverse",
        Direction.Column => "flex-col",
        Direction.ColumnReverse => "flex-col-reverse",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    public string ToJustifyCss(Justify value) => value switch
    {
        Justify.None => string.Empty,
        Justify.Start => "justify-start",
        Justify.Center => "justify-center",
        Justify.End => "justify-end",
        Justify.SpaceBetween => "justify-between",
        Justify.SpaceAround => "justify-around",
        Justify.SpaceEvenly => "justify-evenly",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    public string ToObjectFitCss(ObjectFit value) => value switch
    {
        ObjectFit.Contain => "object-contain",
        ObjectFit.Cover => "object-cover",
        ObjectFit.Fill => "object-fill",
        ObjectFit.None => "object-none",
        ObjectFit.ScaleDown => "object-scale-down",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    public string ToTextOverflow(TextOverflow value) => value switch
    {
        TextOverflow.None => string.Empty,
        TextOverflow.Truncate => "truncate",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    public string ToTypoCss(Typo value) => value switch
    {
        Typo.H1 => string.Empty,
        Typo.H2 => string.Empty,
        Typo.H3 => string.Empty,
        Typo.H4 => string.Empty,
        Typo.H5 => string.Empty,
        Typo.H6 => string.Empty,
        Typo.Header => "text-header",
        Typo.Regular => "text-regular",
        Typo.Small => "text-small",
        Typo.Heading => "text-heading",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    #endregion
    
    public string ToSizeCss(Size value) => value switch
    {
        Size.Custom => string.Empty,
        Size.Small => "py-2.5 px-3",
        Size.Medium => "py-4 px-5 font-bold",
        Size.Large => "py-5 px-6 font-bold",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    public string ToIconSizeCss(Size value) => value switch
    {
        Size.Custom => string.Empty,
        Size.Small => "text-[1.5rem]",
        Size.Medium => "text-[2rem]",
        Size.Large => "text-[2.5rem]",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
}