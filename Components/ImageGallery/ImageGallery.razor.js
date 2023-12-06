import timerHelper from "./../../js/TimerHelper.js"

export function SetUpTimer(element, interval, dotnetIdentifier)
{
    timerHelper.createTimer(element, interval, async () => {
        await dotnetIdentifier.invokeMethodAsync('InvokeNextFromJs');
    });
}