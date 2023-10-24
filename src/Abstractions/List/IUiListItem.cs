namespace BlazorUiKit.Abstractions.List;

public interface IUiListItem<T> : IDisposable
    where T : notnull
{
    RenderFragment? ChildContent { get; set; }
    T Value { get; set; }
    
    void SetSelected();
    void SetUnselected();
}
