namespace UiKit.Abstractions.List;

public interface IUiList<T>
    where T : notnull
{
    T? SelectedValue { get; set; }
    EventCallback<T?> SelectedValueChanged { get; set; }

    IUiListItem<T>? SelectedItem { get; set; }
    EventCallback<IUiListItem<T>?> SelectedItemChanged { get; set; }

    void RegisterListItem(IUiListItem<T> item);
    void UnRegisterListItem(IUiListItem<T> item);

    void SetSelectedValue(T value);
}