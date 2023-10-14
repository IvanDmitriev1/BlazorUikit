namespace BlazorUiKit.Components;

public sealed class UiSelectItem<T> : UiListItem<T>
	where T : notnull
{
	[CascadingParameter]
	private UiSelect<T> Select { get; set; } = null!;

	protected override async Task OnClick()
	{
		await base.OnClick();

		await Select.Focus();
	}
}