namespace BlazorUiKit.Components;

public sealed class ImageGalleryItem<T> : UiListItem<T>
	where T : notnull
{
	protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
	{
		cssBuilder.AddClass("cursor-pointer");
		cssBuilder.AddClass("p-1.5");
	}

	protected override void OnInitialized()
	{
		CacheCss = true;
	}
}