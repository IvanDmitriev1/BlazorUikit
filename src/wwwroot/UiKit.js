var eventListeners = {};
function RegisterInputEvent(inputId, dotnetIdentifier) {
    // Get the input element
    var inputElement = document.getElementById(inputId);
    // Check if the input element exists
    if (!inputElement) {
        console.error('No element found with ID:', inputId);
        return;
    }
    // Get the maxlength attribute
    var maxLength = inputElement.getAttribute('maxlength');
    // Check if the maxlength attribute exists
    if (!maxLength) {
        console.error('No maxlength attribute found for element with ID:', inputId);
        return;
    }
    // Define the event listener
    var eventListener = async function(event) {
        // Get the input value
        var inputValue = event.target.value;
        // Replace non-numeric characters
        var numericValue = inputValue.replace(/\D/g, '');
        // Check if the input value has changed
        if (inputValue !== numericValue) {
            // Update the input value
            event.target.value = numericValue;
        }
        // Call the .NET method
        await dotnetIdentifier.invokeMethodAsync('UpdateTextFromJs', numericValue);
    };
    // Add the event listener
    inputElement.addEventListener('input', eventListener);
    // Store the event listener
    eventListeners[inputId] = eventListener;
}

function UnRegisterInputEvent(inputId) {
    // Get the input element
    var inputElement = document.getElementById(inputId);
    // Get the event listener
    var eventListener = eventListeners[inputId];
    // Check if the input element and event listener exist
    if (inputElement && eventListener) {
        // Remove the event listener
        inputElement.removeEventListener('input', eventListener);
    }

    if (eventListener) {
        // Remove the event listener from the object
        delete eventListeners[inputId];
    }
}


function LockScroll() {
    document.body.style.overflow = "hidden";
}

function UnlockScroll() {
    document.body.style.overflow = "auto";
}