/// <method name="DataGridViewHeaderFilterComboBox_HandleEvents">
/// <summary>
/// Handles combo's mouse and touch events.
/// </summary>
function DataGridViewHeaderFilterComboBox_HandleEvents(objElement, strType, objWindow, objEvent)
{
    // Call infrastructure which handles styling of the element.
    Web_SetStyle(objElement, strType, objWindow, objEvent);

    // Check if mouse down handling.
    if(strType=="mousedown")
    {
        // Get element's VWG ancestor element.
        var objVwgSourceElement = Web_GetVwgElement(objElement);
        if(objVwgSourceElement)
        {
            // Get element VWG id.
            var strDataId = Data_GetDataId(objVwgSourceElement.id);
            if(!Aux_IsNullOrEmpty(strDataId))
            {
                // Get element's XML node.
                var objSourceNode = Data_GetNode(strDataId);
                if(objSourceNode)
                {
                    // Check custom filter attribute.
                    var strIsCustomFilter = Xml_GetAttribute(objSourceNode, "Attr.IsCustomFilter", "");

                    // Check that no custom filter has been defined.
                    if(strIsCustomFilter=="" || strIsCustomFilter=="0")
                    {
                        // Call combobox toggling infrastructure.
                        mobjApp.ComboBox_ToggleDropDown(strDataId,objWindow);
                    }
                }
            }
        }
    }
}
/// </method>