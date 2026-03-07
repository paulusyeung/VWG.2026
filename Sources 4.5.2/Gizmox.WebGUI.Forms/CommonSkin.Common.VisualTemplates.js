/// <method name="VisualTempalte_CreateEvent">
/// <summary>
/// 
/// </summary>
/// <param name="strSource">The ID of the event source.</param>
/// <param name="blnUnique">Indicates whether an event should be unique</param>
/// <param name="blnTypeOnlyUnique">Indicates whether an event should be unique by type only</param>
function VisualTempalte_CreateEvent(strSource, blnUnique, blnTypeOnlyUnique, blnSuspendEnqueue)
{
    var objVisualTemplateEvent = Events_CreateEvent(strSource, "VisualTemplate", null, blnUnique, blnTypeOnlyUnique, blnSuspendEnqueue);

    return objVisualTemplateEvent;
}
/// </method>