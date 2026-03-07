/// <method name="NativeComboBox_ValueChanged">
/// <summary>
///  Native ComboBox value change handler.
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objNode"></param>
/// <param name="intSelectedIndex"></param>
/// <param name="objWindow"></param>
function NativeComboBox_ValueChanged(strGuid, intSelectedIndex, objWindow)
{
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        // Get selected option node.
        var objOptionNode = ComboBox_GetOptionByPosition(objNode, intSelectedIndex);
        if (objOptionNode != null)
        {
            // Get selected index.
            var intIndex = Xml_GetAttribute(objOptionNode, "Attr.Index", "");
            if (!Aux_IsNullOrEmpty(intIndex))
            {
                // Get text from option.
                var strText = Xml_GetAttribute(objOptionNode, "Attr.Text", "");

                // Check if index has been changed.
                var blnValueChanged = !Xml_IsAttribute(objNode, "Attr.Value", intIndex);
                if (blnValueChanged)
                {
                    // Update data behind.
                    Xml_SetAttribute(objNode, "Attr.Value", intIndex);
                    Xml_SetAttribute(objNode, "Attr.Text", strText);

                    // Fire ValueChange event.
                    ComboBox_FireValueChange(objWindow, strGuid, objNode, intIndex);
                }
            }
        }
    }
}
/// </method>