Blazor.addEventListener('enhancedload', () => {
    ApplayTheme();

    window.scrollTo({ top: 0, left: 0, behavior: 'instant' });
});

function ApplayTheme()
{
    const isDarkTheme = localStorage.theme === 'dark' || (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches);

    if (isDarkTheme)
    {
        document.documentElement.classList.add('dark');
    }
    else
    {
        document.documentElement.classList.remove('dark');
    }
}


class DOMCleanup {
    static #observers = new Map();

    /**
     * Create a MutationObserver to watch for element removal.
     * @param {Element} targetElement - The element to watch for removal.
     * @param {Function} cleanupFunction - The function to call when the element is removed.
     */
    static createObserver(targetElement, cleanupFunction) {
        const callback = function (mutations)
        {
            const targetRemoved = mutations.some((mutation) =>
                Array.from(mutation.removedNodes).includes(targetElement)
            );

            if (targetRemoved) {
                cleanupFunction();
                DOMCleanup.disconnectObserver(targetElement);
            }
        };
        
        const observer = new MutationObserver(callback);
        const config = { childList: true, subtree: true };
        
        observer.observe(targetElement.parentNode, config);
        this.#observers.set(targetElement, observer);
    }

    /**
     * Disconnect and delete a specific MutationObserver.
     * @param {Element} targetElement - The target element associated with the observer to disconnect.
     */
    static disconnectObserver(targetElement) {
        if (this.#observers.has(targetElement)) {
            const observer = this.#observers.get(targetElement);
            observer.disconnect();
            this.#observers.delete(targetElement);
        }
    }
}
window.DOMCleanup = DOMCleanup;


class TimerHelper {
    static #TimersDictionary = new Map();

    static createTimer(element, interval, onTickFunction, onCleanup = null)
    {
        const deleteTimerWithCleanUp = () =>
        {
            TimerHelper.deleteTimer(element);

            if(onCleanup !== null)
            {
                onCleanup();
            }
        }
        
        const timerId = setInterval(() =>
        {
            //Why MutationObserver not working
            if(!document.body.contains(element))
            {
                deleteTimerWithCleanUp();
                DOMCleanup.disconnectObserver(element);
                return;
            }
            
            onTickFunction();
        }, interval);
        this.#TimersDictionary.set(element, timerId);

        const timersDictionary = this.#TimersDictionary;
        DOMCleanup.createObserver(element, deleteTimerWithCleanUp);
    }
    
    static deleteTimer(element)
    {
        const timerId = this.#TimersDictionary.get(element);
        this.#TimersDictionary.delete(element);

        clearInterval(timerId);
    }
}
window.TimerHelper = TimerHelper;



window.InputDebounceDictionary = new Map();
function SetUpInputDebounceInterval(element, interval, dotnetIdentifier)
{
    TimerHelper.createTimer(element, interval, async () =>
    {
        console.log('Timer tick!');
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

function RegisterNumericInputEvent(inputElement) {
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

function RegisterEnterKeyEvent(element, dotnetIdentifier) {
    element.addEventListener('keydown', async (event) =>
    {
        if (event.key === 'Enter' || event.key === 'Done' || event.keyCode === 13)
        {
            await dotnetIdentifier.invokeMethodAsync('OnEnterKey', element.value);
        }
    });
}



function LockScroll() {
    document.body.style.overflow = "hidden";
}

function UnlockScroll() {
    document.body.style.overflow = "auto";
}


function DisplayDrawer(drawerRootId)
{
    const element = document.getElementById(drawerRootId);
    
    if (element == null)
    {
        console.error(`Cannot find ${drawerRootId}!`);
    }
    
    const overlayElement = element.children[0];
    overlayElement.classList.replace("hidden", "flex");
    overlayElement.addEventListener('click', (event) => {
        event.stopPropagation();
        CloseDrawer(drawerRootId);
    });

    const drawerElement = element.children[1];
    drawerElement.classList.remove("translate-x-[-1000%]");
}


function CloseDrawer(drawerRootId)
{
    const element = document.getElementById(drawerRootId);

    if (element == null)
    {
        console.error(`Cannot find ${drawerRootId}!`);
    }

    const overlayElement = element.children[0];
    overlayElement.classList.replace("flex", "hidden");

    const drawerElement = element.children[1];
    drawerElement.classList.add("translate-x-[-1000%]");
}


function SetUpImageGalleryTimer(element, interval, dotnetIdentifier)
{
    TimerHelper.createTimer(element, interval, async () => {
        //console.log('Timer tick!');
        await dotnetIdentifier.invokeMethodAsync('InvokeNextFromJs');
    });
}


function OpenModalDialog(dialog, preventDismissOnOverlayClick)
{
    if (dialog.open)
        return;

    dialog.showModal();

    if (preventDismissOnOverlayClick)
        return;
    
    dialog.addEventListener("click", e => {
        const dialogDimensions = dialog.getBoundingClientRect()
        if (
            e.clientX < dialogDimensions.left ||
            e.clientX > dialogDimensions.right ||
            e.clientY < dialogDimensions.top ||
            e.clientY > dialogDimensions.bottom
        ) {
            dialog.close()
        }
    });
}
