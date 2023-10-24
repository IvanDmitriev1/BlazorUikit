namespace BlazorUiKit.Utilities;

public interface IThemeProvider
{
    public string PageBackgroundCss { get; }
    public string PageTextCss { get; }
    
    public string ToBackgroundCss(Color color);
    public string ToBackgroundHoverCss(Color color);
    public string ToBackgroundActiveCss(Color color, bool active = true);
    public string BackgroundDisabledCss { get; }
    
    public string ToTextCss(Color color);
    public string ToTextHoverCss(Color color);
    public string ToTextActiveCss(Color color, bool active = true);
    public string TextDisabledCss { get; }
    public string TextPlaceholderCss { get; }

    public string ToBorderCss(Color color);
    public string ToBorderFocusWithinCss(Color color);
    
    public string ToRingCss(Color color);
    public string ToRingFocusCss(Color color);
    public string ToRingFocusWithinCss(Color color);
}