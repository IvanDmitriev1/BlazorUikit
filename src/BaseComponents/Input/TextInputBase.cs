namespace BlazorUiKit.BaseComponents.Input;

public abstract class TextInputBase<T> : InputBase<T>
{
	[Parameter]
	public string? Placeholder { get; set; }

	[Parameter]
	public int MaxLength { get; set; } = 524288;

	[Parameter]
	public int Lines { get; set; } = 1;
	
	[Parameter]
	public InputMode InputMode { get; set; } = InputMode.Text;
	

	[Parameter]
	public string? Text { get; set; }

	[Parameter]
	public EventCallback<string?> TextChanged { get; set; }

	protected string? CurrentText
	{
		get => Text;
		set
		{
			var hasChanged = !EqualityComparer<string>.Default.Equals(value, Text);
			if (!hasChanged)
				return;

			Text = value;
			_ = TextChanged.InvokeAsync(value);
			OnTextChanged();
		}
	}

	protected virtual void OnTextChanged() { }
}