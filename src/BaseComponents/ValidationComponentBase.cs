using System.Linq.Expressions;
using Microsoft.AspNetCore.Components.Forms;

namespace UiKit.BaseComponents;

public abstract class ValidationComponentBase<T> : UiKitRenderComponentBase, IAsyncDisposable
{
	[CascadingParameter]
    private EditContext? CascadedEditContext { get; set; }

    protected Expression<Func<T>>? For { get; set; }

    protected IReadOnlyList<string> Errors => _errors;
    protected string? ErrorCss { get; private set; }

    private EditContext? _currentEditContext;
    private bool _hasInitializedParameters;
    private FieldIdentifier _fieldIdentifier;
    private readonly List<string> _errors = new(1);

    protected virtual ValueTask OnDispose() => ValueTask.CompletedTask;

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        await OnDispose();

        if (_currentEditContext is null)
            return;

        _currentEditContext.OnValidationRequested -= OnValidationRequested;
        _currentEditContext.OnFieldChanged -= OnFieldChanged;
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (_hasInitializedParameters || For is null || CascadedEditContext is null)
            return;

        _hasInitializedParameters = true;

        _fieldIdentifier = FieldIdentifier.Create(For);
        _currentEditContext = CascadedEditContext;
        _currentEditContext.OnValidationRequested += OnValidationRequested;
        _currentEditContext.OnFieldChanged += OnFieldChanged;
    }

    protected void NotifyEditContext()
    {
        _currentEditContext?.NotifyFieldChanged(_fieldIdentifier);
    }

    private void OnValidationRequested(object? sender, ValidationRequestedEventArgs e) => OnValidate();

    private void OnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        if (_currentEditContext is null || !_currentEditContext.IsModified(_fieldIdentifier))
            return;

        OnValidate();
    }

    private void OnValidate()
    {
        if (_currentEditContext is null || _fieldIdentifier.Equals(default))
            return;

        _errors.Clear();

        foreach (var validationMessage in _currentEditContext.GetValidationMessages(_fieldIdentifier))
        {
            _errors.Add(validationMessage);
        }

        if (_currentEditContext?.FieldCssClass(_fieldIdentifier) is { } fieldCssClass)
        {
            ErrorCss = fieldCssClass;
        }

        AllowRender();
    }
}