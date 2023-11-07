namespace BlazorUiKit.Enums;

public enum Size
{
	Custom,
	Small,
	Medium,
	Large,
}

public static class SizeExtensions
{
	public static string ToIconSize(this Size size) => size switch
	{
		Size.Custom => string.Empty,
		Size.Small  => "text-[1.5rem]",
		Size.Medium => "text-[2rem]",
		Size.Large  => "text-[2.5rem]",
		_           => throw new ArgumentOutOfRangeException()
	};
}