import { AttachInputTextChangeEventForAllInputs } from "./js/InputHasText.js"
import { OpenModalDialog } from "./js/Dialog.js"

export function beforeWebStart() {
    AttachInputTextChangeEventForAllInputs();
    openDialogsIfNeeded();
}

export function afterWebStarted(blazor) {
    window.previousPathName = window.location.pathname;
    blazor.addEventListener('enhancedload', onEnhancedLoad);

    const customScript = document.createElement('script');
    customScript.setAttribute('src', '_content/BlazorUiKit/js/ssr.js');
    document.body.appendChild(customScript);

    const dialogModule = document.createElement('script');
    dialogModule.setAttribute('type', 'module');
    dialogModule.setAttribute('src', './_content/BlazorUiKit/js/Dialog.js');
    document.body.appendChild(dialogModule);
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

function openDialogsIfNeeded() {
    const dialogs = document.querySelectorAll('dialog[data-open="true"]');
    dialogs.forEach(dialog => OpenModalDialog(dialog, false));
}