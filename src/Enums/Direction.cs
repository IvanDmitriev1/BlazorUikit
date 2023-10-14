namespace BlazorUiKit.Enums;

public enum Direction
{
    Row,
    RowReverse,
    Column,
    ColumnReverse
}

public static class DirectionExtensions
{
    public static ReadOnlySpan<char> ToTailwindCss(this Direction direction) => direction switch
    {
        Direction.Row           => "flex-row",
        Direction.RowReverse    => "flex-row-reverse",
        Direction.Column        => "flex-col",
        Direction.ColumnReverse => "flex-col-reverse",
        _                       => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
    };
}