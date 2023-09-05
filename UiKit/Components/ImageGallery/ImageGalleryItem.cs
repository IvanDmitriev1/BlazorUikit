namespace UiKit.Components;

public sealed class ImageGalleryItem<T> : UiListItem<T>
	where T : notnull
{
	protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
	{
		cssBuilder.AddClass("cursor-pointer");
	}
}