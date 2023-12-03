namespace BlazorUiKit.BaseComponents;

public abstract class UiListItemBase<T> : UiKitRenderComponentBase, IUiListItem<T>
    where T : notnull
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter, EditorRequired]
    public T Value { get; set; } = default!;

    [Parameter]
    public bool Disabled { get; set; }

    [CascadingParameter]
    protected IUiList<T>? List { get; set; }

    [CascadingParameter]
    protected IExplicitHideComponent? ExplicitHide { get; set; }

    protected bool Selected
    {
        get => _selected;
        private set
        {
            if (_selected == value)
                return;

            _selected = value;
            AllowRender();
            StateHasChanged();
        }
    }

    private bool _selected;

    protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
    {
        cssBuilder.AddClass("transition");
        cssBuilder.AddClass("rounded");
        cssBuilder.AddClass("select-none");

        cssBuilder.AddClass("cursor-pointer");
        cssBuilder.AddClass("aria-disabled:cursor-not-allowed");
        cssBuilder.AddClass(ThemeManager.ThemeProvider.TextDisabledCss);

        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToBackgroundActiveCss(Color.Primary));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToTextActiveCss(Color.Primary));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToBackgroundHoverCss(Color.Primary));
        cssBuilder.AddClass(ThemeManager.ThemeProvider.ToTextCss(Color.Primary));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        List?.UnRegisterListItem(this);
    }

    protected override void OnInitialized()
    {
        List?.RegisterListItem(this);
    }

    public void SetSelected()
    {
        Selected = true;
    }

    public void SetUnselected()
    {
        Selected = false;
    }

    protected void OnClickHandler()
    {
        if (!Disabled && !Selected)
        {
            List?.SetSelectedValue(Value);
        }

        if (Selected && ExplicitHide is not null)
        {
            ExplicitHide.ExplicitHide();
        }
    }
}