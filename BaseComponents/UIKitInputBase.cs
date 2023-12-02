using Microsoft.AspNetCore.Components.Forms;

namespace BlazorUiKit.BaseComponents;

public abstract class UIKitInputBase<T> : InputBase<T>
{
	[Parameter]
	public string Class { get; set; } = string.Empty;

	[Parameter]
	public bool Disabled { get; set; }

	[Parameter]
	public bool ReadOnly { get; set; }

	[Parameter]
	public string? Label { get; set; }

	[Parameter]
	public string? Placeholder { get; set; }

	private bool _render;
	private bool _firstRendered;

	protected override bool ShouldRender()
	{
		if (!_firstRendered)
			return true;

		if (!_render)
			return false;

		_render = false;
		return true;
	}

	protected override void OnAfterRender(bool firstRender)
	{
		if (firstRender)
			_firstRendered = true;

		base.OnAfterRender(firstRender);
	}

	protected void AllowRender()
	{
		_render = true;
	}

	protected void StateHasChangedWithRendering()
	{
		if (_render)
			return;

		AllowRender();
		StateHasChanged();
	}
}