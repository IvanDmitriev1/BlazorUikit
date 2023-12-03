using System.Linq.Expressions;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorUiKit.Components;

public sealed class UiKitValidationMessage<TValue> : ComponentBase, IDisposable
{
    public UiKitValidationMessage()
	{
		_validationStateChangedHandler = (_, _) => StateHasChanged();
	}

	/// <summary>
	/// Specifies the field for which validation messages should be displayed.
	/// </summary>
	[Parameter]
	public Expression<Func<TValue>>? For { get; set; }

	[CascadingParameter]
	private EditContext? CurrentEditContext { get; set; }

	private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
	private EditContext? _previousEditContext;
	private Expression<Func<TValue>>? _previousFieldAccessor;
	private FieldIdentifier _fieldIdentifier;

    public void Dispose()
	{
		DetachValidationStateChangedListener();
	}

	protected override void OnParametersSet()
	{
		if (For == null) // Not possible except if you manually specify T
		{
			throw new InvalidOperationException($"{GetType()} requires a value for the " +
												$"{nameof(For)} parameter.");
		}

		if (For != _previousFieldAccessor)
		{            
			_fieldIdentifier = FieldIdentifier.Create(For);
			_previousFieldAccessor = For;
		}

		if (CurrentEditContext == _previousEditContext || CurrentEditContext is null)
			return;

		DetachValidationStateChangedListener();
		CurrentEditContext.OnValidationStateChanged += _validationStateChangedHandler;
		_previousEditContext = CurrentEditContext;
	}

	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
		if (CurrentEditContext is null)
		{
			return;
		}

		int seq = 0;

		builder.OpenElement(seq++, "div");
		builder.AddAttribute(seq++, "class", "mt-1");

		foreach (var message in CurrentEditContext.GetValidationMessages(_fieldIdentifier))
		{
			builder.OpenElement(seq++, "p");
			builder.AddAttribute(seq++, "class", ThemeManager.ThemeProvider.ToTextCss(Color.Error));
			builder.AddContent(seq++, message);
			builder.CloseElement();
		}

		builder.CloseElement();
	}

	private void DetachValidationStateChangedListener()
	{
		if (_previousEditContext is not null)
		{
			_previousEditContext.OnValidationStateChanged -= _validationStateChangedHandler;
		}
	}
}