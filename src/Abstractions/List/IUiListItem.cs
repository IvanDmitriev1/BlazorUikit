namespace UiKit.Abstractions.List;

public interface IUiListItem<T> : IDisposable
    where T : notnull
{
    T Value { get; set; }
    RenderFragment ChildContent { get; set; }

    void SetSelected();
    void SetUnselected();
}