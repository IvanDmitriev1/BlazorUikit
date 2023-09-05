namespace UiKit.Enums;

public enum InputType
{
	Text,
	Password,
	Email,
}

public static class InputTypeExtensions
{
	public static string ToHtml(this InputType inputType) => inputType switch
	{
		InputType.Text     => "text",
		InputType.Password => "password",
		InputType.Email    => "email",
		_                  => throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null)
	};
}