export function OpenModalDialog(dialog, preventDismissOnOverlayClick)
{
    if (dialog.open)
        return;

    dialog.showModal();

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
                dialog.close();
            }
        });
}

export function OpenModalDialogById(dialogId) {
    const dialog = document.getElementById(dialogId);
    OpenModalDialog(dialog, false);
}

window.OpenModalDialogById = OpenModalDialogById;