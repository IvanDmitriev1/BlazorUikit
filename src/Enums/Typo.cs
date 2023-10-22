namespace BlazorUiKit.Enums;

public enum Typo
{
	H1,
	H2,
	H3,
	H4,
	H5,
	H6,
	Header,
	Regular,
	Small,
	Heading
}

public static class TypoExtensions
{
	public static string ToHtmlTag(this Typo typo) => typo switch
	{
		Typo.H1      => "h1",
		Typo.H2      => "h2",
		Typo.H3      => "h3",
		Typo.H4      => "h4",
		Typo.H5      => "h5",
		Typo.H6      => "h6",
		Typo.Header  => "p",
		Typo.Regular => "p",
		Typo.Small   => "span",
		Typo.Heading => "span",
		_            => throw new ArgumentOutOfRangeException(nameof(typo), typo, null)
	};
}