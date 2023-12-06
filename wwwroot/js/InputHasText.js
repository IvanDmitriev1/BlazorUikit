export function AttachInputTextChangeEventForAllInputs() {
    const textInputs = document.querySelectorAll('input[type="text"]');
    textInputs.forEach(input => AttachInputTextChangeEventListener(input));
}

export function AttachInputTextChangeEventListener(input) {
    if (input.hasAttribute('data-event-added')) {
        return;
    }

    applyClass(input);

    input.setAttribute('data-event-added', 'true');
    input.addEventListener('input', (e) => applyClass(e.target));
}

function applyClass(target) {
    const isValueEmpty = target.value.trim() !== '';
    const isDefaultValueEmpty = target.defaultValue.trim() !== '';

    if (isValueEmpty || isDefaultValueEmpty) {
        target.classList.add("has-text");
    } else {
        target.classList.remove("has-text");
    }
}