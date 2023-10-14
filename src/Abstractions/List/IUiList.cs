namespace BlazorUiKit.Abstractions.List;

public interface IUiList<T>
    where T : notnull
{
    void RegisterListItem(IUiListItem<T> item);
    void UnRegisterListItem(IUiListItem<T> item);

    void SetSelectedValue(T value);
}