class DOMCleanup {
    static #observers = new Map();

    /**
     * Create a MutationObserver to watch for element removal.
     * @param {Element} targetElement - The element to watch for removal.
     * @param {Function} cleanupFunction - The function to call when the element is removed.
     */
    static createObserver(targetElement, cleanupFunction) {
        const observer = new MutationObserver((mutations) => {
            const targetRemoved = mutations.some((mutation) =>
                Array.from(mutation.removedNodes).includes(targetElement)
            );

            if (targetRemoved) {
                cleanupFunction();
                this.disconnectObserver(targetElement);
            }
        });

        observer.observe(targetElement.parentNode, { childList: true });
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
    
    static createTimer(element, interval, onTickFunction)
    {
        const timerId = setInterval(onTickFunction, interval);
        this.#TimersDictionary.set(element, timerId);
        
        const timersDictionary = this.#TimersDictionary;

        DOMCleanup.createObserver(element, function ()
        {
            const timerId = timersDictionary.get(element);
            timersDictionary.delete(element);

            clearInterval(timerId);
        });
    }
}
window.TimerHelper = TimerHelper;

function RegisterNumericInputEvent(inputElement) {
    const eventListener = function (event) {
        const inputValue = event.target.value;
        const numericValue = inputValue.replace(/[^0-9.,]|([.,][0-9]+)[.,]/g, '$1');
        
        if (inputValue === numericValue) {
            return;
        }

        event.target.value = numericValue;
    };

    inputElement.addEventListener('input', eventListener);
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
    overlayElement.addEventListener('click', function(event) {
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


function SetUpImageGalleryTimer(dotnetIdentifier, element, interval)
{
    TimerHelper.createTimer(element, interval, async function () {
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

function ReplaceClass(element, oldClas, newClass) {
    element.classList.replace(oldClas, newClass);
}