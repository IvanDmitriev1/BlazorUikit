namespace UiKit.BaseComponents;

public abstract class UiKitRenderComponentBase : UiKitComponentBase
{
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