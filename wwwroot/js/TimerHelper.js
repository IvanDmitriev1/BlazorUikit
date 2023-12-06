import domCleanup from "./DomCleanup.js"

export default class TimerHelper {
    static TimersDictionary = new Map();

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
                domCleanup.disconnectObserver(element);
                return;
            }
            
            onTickFunction();
        }, interval);
        this.TimersDictionary.set(element, timerId);

        domCleanup.createObserver(element, deleteTimerWithCleanUp);
    }
    
    static deleteTimer(element)
    {
        const timerId = this.TimersDictionary.get(element);
        this.TimersDictionary.delete(element);

        clearInterval(timerId);
    }
}