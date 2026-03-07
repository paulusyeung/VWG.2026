/// <method name="MdiClient_OnScroll">
/// <summary>
/// 
/// </summary>
function MdiClient_OnScroll(objEvent,objMdiClientlement)
{
    // Validate recieved arguments.
    if(objEvent && objMdiClientlement)
    {
        // Cancel bubble.
        Web_EventCancelBubble(objEvent);
        
        // Initialize scroll position.
        objMdiClientlement.scrollTop = 0;
        objMdiClientlement.scrollLeft = 0;
    }
}
/// </method>