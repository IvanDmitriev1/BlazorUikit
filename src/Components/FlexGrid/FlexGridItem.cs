namespace BlazorUiKit.Components;

public sealed class FlexGridItem : UiKitElementComponentBase
{
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Parameter] public int Xs { get; set; }
	[Parameter] public int Sm { get; set; }
	[Parameter] public int Md { get; set; }
	[Parameter] public int Lg { get; set; }
	[Parameter] public int Xl { get; set; }


	protected override void AddComponentCssClasses(ref CssBuilder cssBuilder)
	{
		cssBuilder.AddClass("box-border");
		cssBuilder.AddClass("grow-0");

		cssBuilder.AddClass(GetXsFlexBias(Xs));
		cssBuilder.AddClass(GetSmFlexBias(Sm));
		cssBuilder.AddClass(GetMdFlexBias(Md));
		cssBuilder.AddClass(GetLgFlexBias(Lg));
		cssBuilder.AddClass(GetXlFlexBias(Xl));
	}

	protected override void OnBuildingRenderTree(RenderTreeBuilder builder, ref int seq)
	{
		builder.AddContent(seq++, ChildContent);
	}

	protected override void OnInitialized()
	{
		CacheCss = true;
	}

	private static string GetXsFlexBias(int value) => value switch
	{
		0  => string.Empty,
		1  => "basis-1/12 w-1/12",
		2  => "basis-2/12 w-2/12",
		3  => "basis-3/12 w-3/12",
		4  => "basis-4/12 w-4/12",
		5  => "basis-5/12 w-5/12",
		6  => "basis-6/12 w-6/12",
		7  => "basis-7/12 w-7/12",
		8  => "basis-8/12 w-8/12",
		9  => "basis-9/12 w-9/12",
		10 => "basis-10/12 w-10/12",
		11 => "basis-11/12 w-11/12",
		12 => "basis-full w-full",
		_  => throw new ArgumentOutOfRangeException(nameof(value), value, null)
	};

	private static string GetSmFlexBias(int value) => value switch
	{
		0  => string.Empty,
		1  => "sm:basis-1/12 sm:w-1/12",
		2  => "sm:basis-2/12 sm:w-2/12",
		3  => "sm:basis-3/12 sm:w-3/12",
		4  => "sm:basis-4/12 sm:w-4/12",
		5  => "sm:basis-5/12 sm:w-5/12",
		6  => "sm:basis-6/12 sm:w-6/12",
		7  => "sm:basis-7/12 sm:w-7/12",
		8  => "sm:basis-8/12 sm:w-8/12",
		9  => "sm:basis-9/12 sm:w-9/12",
		10 => "sm:basis-10/12 sm:w-10/12",
		11 => "sm:basis-11/12 sm:basis-11/12",
		12 => "sm:basis-full sm:w-full",
		_  => throw new ArgumentOutOfRangeException(nameof(value), value, null)
	};

	private static string GetMdFlexBias(int value) => value switch
	{
		0  => string.Empty,
		1  => "md:basis-1/12 md:w-1/12",
		2  => "md:basis-2/12 md:w-2/12",
		3  => "md:basis-3/12 md:w-3/12",
		4  => "md:basis-4/12 md:w-4/12",
		5  => "md:basis-5/12 md:w-5/12",
		6  => "md:basis-6/12 md:w-6/12",
		7  => "md:basis-7/12 md:w-7/12",
		8  => "md:basis-8/12 md:w-8/12",
		9  => "md:basis-9/12 md:w-9/12",
		10 => "md:basis-10/12 md:w-10/12",
		11 => "md:basis-11/12 md:basis-11/12",
		12 => "md:basis-full md:w-full",
		_  => throw new ArgumentOutOfRangeException(nameof(value), value, null)
	};

	private static string GetLgFlexBias(int value) => value switch
	{
		0  => string.Empty,
		1  => "lg:basis-1/12 lg:w-1/12",
		2  => "lg:basis-2/12 lg:w-2/12",
		3  => "lg:basis-3/12 lg:w-3/12",
		4  => "lg:basis-4/12 lg:w-4/12",
		5  => "lg:basis-5/12 lg:w-5/12",
		6  => "lg:basis-6/12 lg:w-6/12",
		7  => "lg:basis-7/12 lg:w-7/12",
		8  => "lg:basis-8/12 lg:w-8/12",
		9  => "lg:basis-9/12 lg:w-9/12",
		10 => "lg:basis-10/12 lg:w-10/12",
		11 => "lg:basis-11/12 lg:w-11/12",
		12 => "lg:basis-full lg:w-full",
		_  => throw new ArgumentOutOfRangeException(nameof(value), value, null)
	};

	private static ReadOnlySpan<char> GetXlFlexBias(int value) => value switch
	{
		0  => string.Empty,
		1  => "xl:basis-1/12 xl:w-1/12",
		2  => "xl:basis-2/12 xl:w-2/12",
		3  => "xl:basis-3/12 xl:w-3/12",
		4  => "xl:basis-4/12 xl:w-4/12",
		5  => "xl:basis-5/12 xl:w-5/12",
		6  => "xl:basis-6/12 xl:w-6/12",
		7  => "xl:basis-7/12 xl:w-7/12",
		8  => "xl:basis-8/12 xl:w-8/12",
		9  => "xl:basis-9/12 xl:w-9/12",
		10 => "xl:basis-10/12 xl:w-10/12",
		11 => "xl:basis-11/12 xl:w-11/12",
		12 => "xl:basis-full xl:w-full",
		_  => throw new ArgumentOutOfRangeException(nameof(value), value, null)
	};
}