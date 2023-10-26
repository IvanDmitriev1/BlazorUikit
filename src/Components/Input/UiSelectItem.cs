namespace BlazorUiKit.Components;

public sealed class UiSelectItem<T> : UiListItem<T>
	where T : notnull
{
	[CascadingParameter]
	private UiSelect<T> Select { get; set; } = null!;

	protected override EventCallback InitializeOnClickCallback()
	{
		if (Disabled)
		{
			return new EventCallbackFactory().Create(this, OnClickDisabledHandler);
		}

		return new EventCallbackFactory().Create(this, OnClickHandler);
	}
	
	private Task OnClickHandler()
	{
		List?.SetSelectedValue(Value);
		return Select.Focus().AsTask();
	}

	private Task OnClickDisabledHandler() => Select.Focus().AsTask();
}