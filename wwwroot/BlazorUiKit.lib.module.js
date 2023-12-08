import { AttachInputTextChangeEventForAllInputs } from "./js/InputHasText.js"
import { OpenModalDialog } from "./js/Dialog.js"

export function beforeWebStart() {
    AttachInputTextChangeEventForAllInputs();
    openDialogsIfNeeded();
}

export function afterWebStarted(blazor) {
    window.previousPathName = window.location.pathname;
    blazor.addEventListener('enhancedload', onEnhancedLoad);

    loadModule('Dialog.js');
    loadModule('Drawer.js');
}

function loadModule(fileName) {
    const basePath = './_content/BlazorUiKit/js';

    const module = document.createElement('script');
    module.setAttribute('type', 'module');
    module.setAttribute('src', `${basePath}/${fileName}`);
    document.body.appendChild(module);
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