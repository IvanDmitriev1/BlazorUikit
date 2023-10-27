function RegisterNumericInputEvent(inputId, dotnetIdentifier) {
    const inputElement = document.getElementById(inputId);
    if (!inputElement) {
        console.error('No element found with ID:', inputId);
        return;
    }
    
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



const imageGalleryTimersDictionary = new Map();
function RegisterImageGalleryTimer(dotnetIdentifier, interval)
{
    const timerId = setInterval(async () => {
        //console.log('Timer tick!');

        await dotnetIdentifier.invokeMethodAsync('InvokeNextFromJs');
    }, interval);

    imageGalleryTimersDictionary.set(dotnetIdentifier._id, timerId);
}

function UnRegisterImageGalleryTimer(dotnetIdentifier)
{
    const timerId = imageGalleryTimersDictionary.get(dotnetIdentifier._id);
    imageGalleryTimersDictionary.delete(dotnetIdentifier);

    clearInterval(timerId);
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

function HideElement(element) {
    element.classList.replace("display", "hidden");
}

function DisplayElement(element) {
    element.classList.replace("hidden", "display");
}