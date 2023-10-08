using UiKit.Abstractions.List;

namespace UiKit.BaseComponents;

public abstract class UiListItemBase<T> : UiKitRenderComponentBase, IUiListItem<T>
    where T : notnull
{
    [Parameter, EditorRequired]
    public T Value { get; set; } = default!;

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
        }
    }

    private bool _selected;
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);

        List?.UnRegisterListItem(this);
    }
    
    protected override void OnFirstRender()
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