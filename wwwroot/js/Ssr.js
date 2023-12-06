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

function OpenModalDialog(dialog, preventDismissOnOverlayClick)
{
    if (dialog.open)
        return;

    dialog.showModal();

    if (preventDismissOnOverlayClick)
        return;
    
    dialog.addEventListener("click", e => {
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