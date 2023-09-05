namespace UiKit.Enums;

public enum Breakpoint
{
	Sm,
	Md,
	Lg,
	Xl,
	XxL
}

public static class BreakpointExtensions
{
	public static string ToTailwindCssMaxWidth(this Breakpoint breakpoint) => breakpoint switch
	{
		Breakpoint.Sm  => "max-w-screen-sm",
		Breakpoint.Md  => "max-w-screen-md",
		Breakpoint.Lg  => "max-w-screen-lg",
		Breakpoint.Xl  => "max-w-screen-xl",
		Breakpoint.XxL => "max-w-screen-2xl",
		_              => throw new ArgumentOutOfRangeException(nameof(breakpoint), breakpoint, null)
	};
}