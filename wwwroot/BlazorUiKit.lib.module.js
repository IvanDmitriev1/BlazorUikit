import { AttachInputTextChangeEventForAllInputs } from "./js/InputHasText.js"

export function beforeWebStart() {
    console.log("before");

    AttachInputTextChangeEventForAllInputs();
}

export function afterWebStarted(blazor) {
    console.log("after");

    blazor.addEventListener('enhancedload', onEnhancedLoad);

    var customScript = document.createElement('script');
    customScript.setAttribute('src', '_content/BlazorUiKit/js/ssr.js');
    document.body.appendChild(customScript);
}

function onEnhancedLoad() {

    AttachInputTextChangeEventForAllInputs();

    try {
        ApplyTheme();
    } catch (e) {

    } 
}