
/// <method name="ToolStripButton_OnClick">
/// <summary>
///
/// </summary>
/// <param name="strGuid">The tool strip Button guid.</param>
/// <param name="objWindow">Javascript window</param>
function ToolStripButton_OnClick(strGuid, objWindow, objEvent)
{
    // Check if the relevant parameters are passed
    if (!Aux_IsNullOrEmpty(strGuid) && objWindow)
    {
        // Get the Relevant tool strip button node from XML
        var objToolStripButtonNode = Data_GetNode(strGuid);
        if (objToolStripButtonNode)
        {
            // Determine the current button's checked state
            var blnChecked = Xml_IsAttribute(objToolStripButtonNode, "Attr.Checked", "1");

            // Set the buttons new state according to the old one
            Xml_SetAttribute(objToolStripButtonNode, "Attr.Checked", blnChecked ? "0" : "1");

            // Redraw the control for the user to see the changes
            Controls_RedrawControlByNode(objWindow, objToolStripButtonNode, false);

            // Create a 'queued' event to changed the button's state
            var objVwgEvent = Events_CreateEvent(strGuid, "CheckedChange", null, true);

            // Set event parameter to the current state
            Events_SetEventAttribute(objVwgEvent, "Attr.Checked", blnChecked ? "false" : "true");

            // Check if the control has a critical event attached to it
            Web_OnClick(objEvent, objWindow, Data_IsCriticalEvent(strGuid, "Event.CheckedChange"), Web_GetElementByDataId(strGuid, objWindow));
        }
    }
}
/// <method
