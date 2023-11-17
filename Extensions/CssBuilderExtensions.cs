using System.Numerics;

namespace BlazorUiKit.Extensions;

public static class CssBuilderExtensions
{
    public static void AddClassAndJoinNumber<TNum>(this ref CssBuilder cssBuilder, scoped ReadOnlySpan<char> firstValue, TNum number) where TNum : INumber<TNum>
    {
        Span<char> numberSpan = stackalloc char[4];

        if (!number.TryFormat(numberSpan, out int charsWritten, default, default))
        {
            throw new InvalidOperationException("Failed to formant number");
        }

        numberSpan = numberSpan.Slice(0, charsWritten);

        Span<char> newValue = stackalloc char[numberSpan.Length + firstValue.Length];
        firstValue.CopyTo(newValue);

        int j = 0;
        for (int i = firstValue.Length; i < newValue.Length; i++)
        {
            newValue[i] = numberSpan[j];
            j++;
        }

        cssBuilder.AddClass(newValue);
    }

    public static void AddClassAndJoinNumber<TNum>(this ref CssBuilder cssBuilder, scoped ReadOnlySpan<char> firstValue, TNum number, bool condition) where TNum : INumber<TNum>
    {
        if (condition)
        {
            cssBuilder.AddClassAndJoinNumber(firstValue, number);
        }
    }
}