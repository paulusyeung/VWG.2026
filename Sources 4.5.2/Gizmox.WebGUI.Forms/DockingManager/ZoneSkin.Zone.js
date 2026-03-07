/// <method name="Zone_DockDrop">
/// <summary>
/// 
/// </summary>
function Zone_DockDrop(objElement)
{
    if (objElement && mobjDragSubject)
    {
        // Get the VWG source element.
        var objVwgDragSubject = Web_GetVwgElement(mobjDragSubject, true, false, true);

        if (objVwgDragSubject)
        {
            // Get the VWG source element id.
            var strSourceFormId = Data_GetDataId(Web_GetId(objVwgDragSubject));

            if (strSourceFormId)
            {
                // Get the relation from the zone
                var strRelation = Web_GetAttribute(objElement, "vwgRelation");

                // Get the target zone's ID
                var strTargetZoneId = Web_GetAttribute(objElement, "vwgOwnerId");

                if (strRelation && strTargetZoneId)
                {
                    // Create the DragDrop event
                    var objVwgEvent = Events_CreateEvent(strTargetZoneId, "AddForm", null, true);

                    // Fill up relevant attributes.
                    Events_SetEventAttribute(objVwgEvent, "Attr.DragSource", strSourceFormId);
                    Events_SetEventAttribute(objVwgEvent, "Attr.Relation", strRelation);

                    // This event is ALWAYS critical
                    Events_RaiseEvents();
                }
            }
        }
    }
}
/// </method>

/// <method name="Zone_DockHover">
/// <summary>
/// 
/// </summary>
function Zone_DockHover(objElement)
{
    if (objElement.className.indexOf("_Hover") == -1)
    {
        Zone_ResetIndicators();
        objElement.className = objElement.className + "_Hover";
    }
}
/// </method>

/// <method name="Zone_ResetIndicators">
/// <summary>
/// 
/// </summary>
function Zone_ResetIndicators()
{
    $("table[data-vwgZoneIndicatorsContainer]  tr td div[class$=_Hover]").each(function ()
    {
        this.className = this.className.replace("_Hover", "");
    });
}
/// </method>