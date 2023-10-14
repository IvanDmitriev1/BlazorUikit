using System.Linq.Expressions;

namespace BlazorUiKit.BaseComponents.Input;

public abstract class ValueInputBase<T> : TextInputBase<T>
{
    protected ValueInputBase(T defaultValue)
    {
        Value = defaultValue;
    }

    [Parameter]
    public T Value { get; set; }

    [Parameter]
    public EventCallback<T> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets an expression that identifies the bound value.
    /// </summary>
    [Parameter]
    public Expression<Func<T>>? ValueExpression { get; set; }

    protected T CurrentValue
    {
        get => Value;
        set
        {
            var hasValueChanged = !EqualityComparer<T>.Default.Equals(value, Value);
            if (!hasValueChanged)
                return;

            Value = value;
            _ = ValueChanged.InvokeAsync(value);

            NotifyEditContext();
            CurrentText = ConvertValueToString();

            OnValueChanged();
        }
    }

    protected abstract void RefreshValueOrText();
    protected abstract string? ConvertValueToString();

    protected virtual void OnValueChanged() { }

    protected override void OnParametersSet()
    {
        For = ValueExpression;

        base.OnParametersSet();

        RefreshValueOrText();
    }
}