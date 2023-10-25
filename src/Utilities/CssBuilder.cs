using CommunityToolkit.HighPerformance.Buffers;
using LinkDotNet.StringBuilder;
using System.Runtime.CompilerServices;

namespace BlazorUiKit.Utilities;

public ref struct CssBuilder
{
	public CssBuilder(Span<char> initialBuffer)
	{
		_stringBuilder = new ValueStringBuilder(initialBuffer);
	}

	public CssBuilder()
	{
		_stringBuilder = new ValueStringBuilder();
	}

	private ValueStringBuilder _stringBuilder;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly void Dispose() => _stringBuilder.Dispose();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override string ToString()
	{
		return StringPool.Shared.GetOrAdd(_stringBuilder.AsSpan());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddClass(scoped ReadOnlySpan<char> value)
	{
		if (value.IsEmpty)
			return;

		_stringBuilder.Append(' ');
		_stringBuilder.Append(value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddClass(scoped ReadOnlySpan<char> value, bool condition)
	{
		if (!condition || value.IsEmpty)
			return;

		_stringBuilder.Append(' ');
		_stringBuilder.Append(value);
	}
}