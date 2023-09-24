namespace UiKit.Enums;

public enum Size
{
	Custom,
	Small,
	Medium,
	Large,
}

public static class SizeExtensions
{
	public static string ToTailwindCss(this Size size) => size switch
	{
		Size.Custom => string.Empty,
		Size.Small  => "py-2.5 px-3",
		Size.Medium => "py-4 px-5 font-bold",
		Size.Large  => "py-5 px-6 font-bold",
		_           => throw new ArgumentOutOfRangeException(nameof(size), size, null)
	};

	public static string ToTailwindCssIcon(this Size size) => size switch
	{
		Size.Custom => string.Empty,
		Size.Small  => "text-[1.5rem]",
		Size.Medium => "text-[2rem]",
		Size.Large  => "text-[2.5rem]",
		_           => throw new ArgumentOutOfRangeException(nameof(size), size, null)
	};
}