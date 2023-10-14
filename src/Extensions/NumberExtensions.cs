using System.Numerics;

namespace BlazorUiKit.Extensions;

public static class NumberExtensions
{
    public static int GetDigitsCount<TNum>(this TNum number) where TNum : INumber<TNum>
    {
        if (number == TNum.Zero)
            return 1;

        int digits = 0;
        var ten = TNum.CreateTruncating(10);

        while (number != TNum.Zero)
        {
            number /= ten;
            digits++;
        }

        return digits;
    }
}