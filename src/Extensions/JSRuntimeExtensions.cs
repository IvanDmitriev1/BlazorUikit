using Microsoft.JSInterop;

namespace BlazorUiKit.Extensions;

public static class JsRuntimeExtensions
{
    public static ValueTask ReplaceClass(this IJSRuntime jsRuntime, ElementReference element, string oldClass,
        string newClass) =>
        jsRuntime.InvokeVoidAsync("ReplaceClass", element, oldClass, newClass);
}