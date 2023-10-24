using BlazorUiKit.Abstractions.List;

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
}