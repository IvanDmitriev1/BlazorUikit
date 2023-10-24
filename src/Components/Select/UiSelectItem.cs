namespace BlazorUiKit.Components;

public sealed class UiSelectItem<T> : UiListItem<T>
	where T : notnull
{
	[CascadingParameter]
	private UiSelect<T> Select { get; set; } = null!;

	protected override void OnInitialized()
	{
		base.OnInitialized();
		
		OnClick = new EventCallbackFactory().Create(this, OnClickHandler);
	}

	private async Task OnClickHandler()
	{
		List?.SetSelectedValue(Value);
		await Select.Focus();
	}
}