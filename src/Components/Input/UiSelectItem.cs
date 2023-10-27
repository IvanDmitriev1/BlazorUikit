namespace BlazorUiKit.Components;

public sealed class UiSelectItem<T> : UiListItem<T>
	where T : notnull
{
	[CascadingParameter]
	private UiSelect<T> Select { get; set; } = null!;

	protected override EventCallback InitializeOnClickCallback()
	{
		return new EventCallbackFactory().Create(this, OnClickHandler);
	}
	
	private Task OnClickHandler()
	{
		if (!Disabled)
		{
			List?.SetSelectedValue(Value);
		}

		return Select.Focus().AsTask();
	}
}