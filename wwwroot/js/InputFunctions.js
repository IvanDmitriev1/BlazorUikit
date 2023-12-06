import timeHelper from "./TimerHelper.js"

window.InputDebounceDictionary = new Map();
export function SetUpInputDebounceInterval(element, interval, dotnetIdentifier)
{
    timeHelper.createTimer(element, interval, async () =>
        {
            const inputValue = element.value;
            const previouseValue = window.InputDebounceDictionary.get(element);
        
            if (inputValue === null || inputValue === "" || previouseValue === inputValue) {
                return;
            }

            window.InputDebounceDictionary.set(element, inputValue);
            await dotnetIdentifier.invokeMethodAsync('ChangeCurrentText', inputValue);
        }, () =>
        {
            window.InputDebounceDictionary.delete(element);
        });
}

export function RegisterNumericInput(inputElement) {
    const eventListener = (event) =>
    {
        const inputValue = event.target.value;
        const numericValue = inputValue.replace(/[^0-9.,]|([.,][0-9]+)[.,]/g, '$1');
        
        if (inputValue === numericValue) {
            return;
        }

        event.target.value = numericValue;
    };

    inputElement.addEventListener('input', eventListener);
}

export function RegisterEnterKeyEvent(element, dotnetIdentifier) {
    element.addEventListener('keydown', async (event) =>
    {
        if (event.key === 'Enter' || event.key === 'Done' || event.keyCode === 13)
        {
            await dotnetIdentifier.invokeMethodAsync('OnEnterKey', element.value);
        }
    });
}
