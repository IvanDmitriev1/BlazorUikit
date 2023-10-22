namespace BlazorUiKit.Utilities;

public interface IThemeProvider
{
    public string ToBackgroundCss(Color color);
    public string ToBackgroundHoverCss(Color color);
    public string ToBackgroundActiveCss(Color color);
    public string ToBackgroundDisabledCss();
    
    public string ToTextCss(Color color);
    public string ToTextHoverCss(Color color);
    public string ToTextActiveCss(Color color);
    public string ToTextDisabledCss(Color color);
    public string ToTextPlaceholderCss();

    public string ToBorderCss(Color color);
    
    public string ToRingCss(Color color);
    public string ToRingFocusWithinCss(Color color);


    public string ToDisplayCss(Display value);
    public string ToAlignCss(Align value);
    public string ToAlignItemsCss(AlignItems value);
    public string ToBreakpointCss(Breakpoint value);
    public string ToDirectionCss(Direction value);
    public string ToJustifyCss(Justify value);
    public string ToObjectFitCss(ObjectFit value);
    public string ToTextOverflow(TextOverflow value);
    public string ToTypoCss(Typo value);

    public string ToSizeCss(Size value);
    public string ToIconSizeCss(Size value);
}