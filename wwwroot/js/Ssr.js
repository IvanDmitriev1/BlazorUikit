
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
