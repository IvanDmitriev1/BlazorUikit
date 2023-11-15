namespace BlazorUiKit.Components;

public sealed class UiLink : UiText
{
    [Parameter, EditorRequired]
    public string Href { get; set; } = null!;

    [Parameter]
    public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

    [Parameter]
    public Underline Underline { get; set; } = Underline.Hover;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;


    private bool _isActive;

    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        base.AddComponentCssClasses(ref cssBuilder);

        cssBuilder.AddClass("font-normal");
        cssBuilder.AddClass("hover:underline underline-offset-4", Underline == Underline.Hover);
        cssBuilder.AddClass("aria-currentPage:font-semibold");
        cssBuilder.AddClass("aria-currentPage:no-underline");
    }

    protected override void OnParametersSet()
    {
        ElementTag = "a";

        _isActive = MatchIsActive();
    }

    protected override void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq)
    {
        builder.AddAttribute(seq++, "href", Href);

        if (_isActive)
        {
            builder.AddAttribute(seq++, "aria-current", "page");
        }

        base.OnBuildingRenderTree(builder, ref seq);
    }


    private bool MatchIsActive()
    {
        var absoluteHref = NavigationManager.ToAbsoluteUri(Href).AbsoluteUri;
        var currentUriAbsolute = NavigationManager.Uri;

        if (EqualsHrefExactlyOrIfTrailingSlashAdded(currentUriAbsolute, absoluteHref))
            return true;

        if (Match == NavLinkMatch.Prefix && IsStrictlyPrefixWithSeparator(currentUriAbsolute, absoluteHref))
            return true;

        return false;
    }

    private static bool EqualsHrefExactlyOrIfTrailingSlashAdded(string currentUriAbsolute, string absoluteHref)
    {
        if (string.Equals(currentUriAbsolute, absoluteHref, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (currentUriAbsolute.Length != absoluteHref.Length - 1)
            return false;

        // Special case: highlight links to http://host/path/ even if you're
        // at http://host/path (with no trailing slash)
        //
        // This is because the router accepts an absolute URI value of "same
        // as base URI but without trailing slash" as equivalent to "base URI",
        // which in turn is because it's common for servers to return the same page
        // for http://host/vdir as they do for host://host/vdir/ as it's no
        // good to display a blank page in that case.
        return absoluteHref[^1] == '/' &&
               absoluteHref.StartsWith(currentUriAbsolute, StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsStrictlyPrefixWithSeparator(string value, string prefix)
    {
        var prefixLength = prefix.Length;
        if (value.Length <= prefixLength)
            return false;

        return value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)
               && (
                   // Only match when there's a separator character either at the end of the
                   // prefix or right after it.
                   // Example: "/abc" is treated as a prefix of "/abc/def" but not "/abcdef"
                   // Example: "/abc/" is treated as a prefix of "/abc/def" but not "/abcdef"
                   prefixLength == 0
                   || !char.IsLetterOrDigit(prefix[prefixLength - 1])
                   || !char.IsLetterOrDigit(value[prefixLength])
               );
    }
}