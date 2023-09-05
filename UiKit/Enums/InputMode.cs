namespace UiKit.Enums;

public enum InputMode
{
	None,
	Text,
	Decimal,
	Numeric,
	Tel,
	Search,
	Email,
	Url
}

public static class InputModeExtensions
{
	public static string? ToHtml(this InputMode inputMode) => inputMode switch
	{
		InputMode.None    => "none",
		InputMode.Text    => "text",
		InputMode.Decimal => "decimal",
		InputMode.Numeric => "numeric",
		InputMode.Tel     => "tel",
		InputMode.Search  => "search",
		InputMode.Email   => "email",
		InputMode.Url     => "url",
		_                 => throw new ArgumentOutOfRangeException(nameof(inputMode), inputMode, null)
	};
}