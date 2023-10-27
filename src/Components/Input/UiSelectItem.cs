namespace BlazorUiKit.Components;

public sealed class UiSelectItem<T> : UiListItem<T>
	where T : notnull
{
	[CascadingParameter]
	private UiSelect<T> Select { get; set; } = null!;

	protected override void OnClickHandler()
	{
		if (Selected)
		{
			Select.ExplicitHide();
		}
		
		base.OnClickHandler();
	}
}