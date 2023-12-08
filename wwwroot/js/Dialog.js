export function LockScroll() {
    document.body.style.overflow = "hidden";
}

export function UnlockScroll() {
    document.body.style.overflow = "auto";
}

export function OpenModalDialog(dialog, preventDismissOnOverlayClick)
{
    if (dialog.open)
        return;

    dialog.showModal();
    LockScroll();

    if (preventDismissOnOverlayClick)
        return;

    dialog.addEventListener("click",
        e => {
            const dialogDimensions = dialog.getBoundingClientRect();

            if (
                e.clientX < dialogDimensions.left ||
                    e.clientX > dialogDimensions.right ||
                    e.clientY < dialogDimensions.top ||
                    e.clientY > dialogDimensions.bottom
            ) {
                UnlockScroll();
                dialog.close();
            }
        });
}

export function OpenModalDialogById(dialogId) {
    const dialog = document.getElementById(dialogId);
    OpenModalDialog(dialog, false);
}

window.OpenModalDialogById = OpenModalDialogById;