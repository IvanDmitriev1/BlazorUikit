export default class DOMCleanup {
    static observers = new Map();

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
        this.observers.set(targetElement, observer);
    }

    /**
     * Disconnect and delete a specific MutationObserver.
     * @param {Element} targetElement - The target element associated with the observer to disconnect.
     */
    static disconnectObserver(targetElement) {
        if (this.observers.has(targetElement)) {
            const observer = this.observers.get(targetElement);
            observer.disconnect();
            this.observers.delete(targetElement);
        }
    }
}