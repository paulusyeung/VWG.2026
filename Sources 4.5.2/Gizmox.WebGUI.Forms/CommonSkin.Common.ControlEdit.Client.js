function ControlEditing_CreateEditingEvent(strID, objParameters, objWindow)
{
    // If the editing is being suspended, don't create any additional events.
    if (!ControlEditing_IsCancellingEdit(strID, objWindow))
    {
        var objEvent = Events_CreateEvent(strID, "Attr.ControlEditMode", null, true);

        if (typeof objParameters === "object")
        {
            for (var strParameter in objParameters)
            {
                Events_SetEventAttribute(objEvent, strParameter, objParameters[strParameter].toString());
            }
        }
        else
        {
            Events_SetEventAttribute(objEvent, "value", objParameters.toString());
        }

        return objEvent;
    }

    return null;
}

function ControlEditing_CancelEditing(strID, blnExitEditMode, objWindow)
{
    if (!ControlEditing_IsCancellingEdit(strID, objWindow))
    {
        var objEvent = ControlEditing_CreateEditingEvent(strID, { "Attr.CancelEditingMode": "1" }, objWindow);

        if (blnExitEditMode)
        {
            Data_SetAttribute(strID, "Attr.ControlEditMode", "0");
        }

        ControlEditing_SuspentEditingEvents(strID, objWindow, function ()
        {
            Controls_RedrawControlById(objWindow, strID);
        });
    }
}

function ControlEditing_SuspentEditingEvents(strID, objWindow, fncOperation)
{
    var objVwgElement = Web_GetElementByDataId(strID, objWindow);
    if (objVwgElement)
    {
        try
        {
            // Some events may be raised when redawing the control, we need to prevent them from creating a 'ControlEditMode' event
            // So we set an attribute.
            Web_SetAttribute(objVwgElement, "suspentEdit", "1");
            fncOperation();
        }
        finally
        {
            Web_SetAttribute(objVwgElement, "suspentEdit", "0");
        }
    }
}

function ControlEditing_IsCancellingEdit(strID, objWindow)
{
    return Web_GetAttribute(Web_GetElementByDataId(strID, objWindow), "suspentEdit") === "1";
}