using Microsoft.JSInterop;

namespace BlazorUiKit.JsInterop;

internal class VisibilityJsInterop
{
    public VisibilityJsInterop(IJSRuntime  jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    
    private readonly IJSRuntime _jsRuntime;

    public ValueTask HideElement(ElementReference reference) => _jsRuntime.InvokeVoidAsync("HideElement", reference);

    public ValueTask DisplayElement(ElementReference reference) => _jsRuntime.InvokeVoidAsync("DisplayElement", reference);
}