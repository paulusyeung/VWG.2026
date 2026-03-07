/// <method name="ComboBox_GetOptionByText">
/// <summary>
/// Gets a combobox option by text
/// </summary>
/// <param name="objNode">The control node.</param>
/// <param name="strText">The current text value.</param>
function ComboBox_GetOptionByText(objNode,strText)
{
    // Get options
    return ComboBox_DoGetOptionsByText(objNode,strText);  
}
/// </method>