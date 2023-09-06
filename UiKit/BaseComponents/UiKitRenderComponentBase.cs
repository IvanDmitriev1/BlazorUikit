namespace UiKit.BaseComponents;

public abstract class UiKitRenderComponentBase : UiKitComponentBase
{
	private bool _forceRender;
	private bool _firstRendered;

	protected override bool ShouldRender()
	{
		if (!_firstRendered)
			return true;

		if (!_forceRender)
			return false;

		_forceRender = false;
		return true;
	}

	protected override void OnAfterRender(bool firstRender)
	{
		if (firstRender)
			_firstRendered = true;

		base.OnAfterRender(firstRender);
	}

	protected virtual void ToggleRender()
	{
		_forceRender = true;
	}

	protected void StateHasChangedWithRendering()
	{
		ToggleRender();
		StateHasChanged();
	}
}