using LinkDotNet.StringBuilder;

namespace UiKit.Utilities;

public ref struct CssBuilder
{
	public CssBuilder(Span<char> initialBuffer)
	{
		_stringBuilder = new ValueStringBuilder(initialBuffer);
	}

	public CssBuilder()
	{
		throw new MethodAccessException();
	}

	private ValueStringBuilder _stringBuilder;

	public void Dispose() => _stringBuilder.Dispose();

	public override string ToString()
	{
		_stringBuilder.Trim();
		return _stringBuilder.ToString();
	}

	public void AddClass(scoped ReadOnlySpan<char> value)
	{
		if (value.IsEmpty)
			return;

		_stringBuilder.Append(' ');
		_stringBuilder.Append(value);
	}

	public void AddClass(scoped ReadOnlySpan<char> value, bool condition)
	{
		if (condition)
		{
			AddClass(value);
		}
	}
}