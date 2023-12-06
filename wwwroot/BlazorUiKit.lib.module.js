import { AttachInputTextChangeEventForAllInputs } from "./js/InputHasText.js"

export function beforeWebStart() {
    console.log("before");

    AttachInputTextChangeEventForAllInputs();
}

export function afterWebStarted(blazor) {
    console.log("after");

    window.previousPathName = window.location.pathname;
    blazor.addEventListener('enhancedload', onEnhancedLoad);

    var customScript = document.createElement('script');
    customScript.setAttribute('src', '_content/BlazorUiKit/js/ssr.js');
    document.body.appendChild(customScript);
}

function onEnhancedLoad() {

    moveScrollPositionIfPageNavigates();
    AttachInputTextChangeEventForAllInputs();

    try {
        ApplyTheme();
    } catch (e) {

    }

    
}

function moveScrollPositionIfPageNavigates() {

    const isChanged = window.location.pathname !== window.previousPathName;
    window.previousPathName = window.location.pathname;

    if (isChanged) {
        window.scrollTo({ top: 0, left: 0, behavior: 'instant' });
    }
}
