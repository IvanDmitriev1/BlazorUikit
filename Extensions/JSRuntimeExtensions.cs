using Microsoft.JSInterop;

namespace BlazorUiKit.Extensions;

public static class MyJsRuntimeExtensions
{
	private const string LibraryPath = "./_content/BlazorUiKit";
	private const string JsPath = $"{LibraryPath}/js";
	internal const string ComponentsPath = $"{LibraryPath}/Components";

	public static async ValueTask
		SetUpInputDebounceInterval<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>
		(this IJSRuntime js,
		 ElementReference element,
		 TimeSpan interval,
		 DotNetObjectReference<T> objRef
		)
		where T : class, IComponent
	{
		var module = await js.InvokeAsync<IJSObjectReference>("import", $"{JsPath}/InputFunctions.js");
		await module.InvokeVoidAsync("SetUpInputDebounceInterval", element, interval.TotalMilliseconds, objRef);
	}

	public static async ValueTask
		RegisterEnterKeyEvent<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>
		(this IJSRuntime js,
		 ElementReference element,
		 DotNetObjectReference<T> objRef
		)
		where T : class, IComponent
	{
		var module = await js.InvokeAsync<IJSObjectReference>("import", $"{JsPath}/InputFunctions.js");
		await module.InvokeVoidAsync("RegisterEnterKeyEvent", element, objRef);
	}

	public static async ValueTask
		RegisterNumericInput(this IJSRuntime js, ElementReference element)
	{
		var module = await js.InvokeAsync<IJSObjectReference>("import", $"{JsPath}/InputFunctions.js");
		await module.InvokeVoidAsync("RegisterNumericInput", element);
	}
}