/// <method name="ComboBox_GetOptionByText">
/// <summary>
/// Gets a combobox option by text
/// </summary>
/// <param name="objNode">The control node.</param>
/// <param name="strText">The current text value.</param>
function ComboBox_GetOptionByText(objNode,strText)
{
    // Preserve selection language from node's owner document.
    var strPreviousSelectionLanguage = objNode.ownerDocument.getProperty("SelectionLanguage");

    // Set xml namespace on node's owner document.
    objNode.ownerDocument.setProperty("SelectionNamespaces","Context.XmlNamespaces");
    
    // Set selection language on node's owner document.
    objNode.ownerDocument.setProperty("SelectionLanguage", "XPath");    
    
    // Get options by text.
    var objOption = ComboBox_DoGetOptionsByText(objNode,strText);
    
    // Set previous selection language on node's owner document.
    objNode.ownerDocument.setProperty("SelectionLanguage", strPreviousSelectionLanguage);
    
    // Return result.
    return objOption;
}
/// </method>