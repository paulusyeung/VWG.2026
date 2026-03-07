/// <method name="DockedHiddenZonesPanel_ChangeStyle">
/// <summary>
/// 
/// </summary>
function DockedTabControl_AfterCreateTabControlEvents(objWindow, objEvent, strSource, strType, strTarget)
{
    // Change the header of the zone according to the tab page's header text
    if (strType == "ValueChange")
    {
        // Get the tab control node
        var objDockedTabControlNode = Data_GetNode(strSource);
        if (objDockedTabControlNode)
        {
            // Get the tab control's parent node (Zone)
            var objDockedTabControlParentNode = objDockedTabControlNode.parentNode;
            if (objDockedTabControlParentNode)
            {
                // Get the tab's selected index
                var strSelectedIndex = Xml_GetAttribute(objDockedTabControlNode, "Attr.Selected", null);
                if (strSelectedIndex)
                {
                    // Get the selected tab page
                    var objSelectedTabPageNode = Data_GetNodeByAttribute(objDockedTabControlParentNode, "Attr.Id", strSelectedIndex);
                    if (objSelectedTabPageNode)
                    {
                        // Get the tab page's selected attribute
                        var strSelectedTabPageText = Xml_GetAttribute(objSelectedTabPageNode, "Attr.Text", null);
                        
                        // Set header toolTip to empty
                        var strSelectedWindowHeaderToolTip = "";
                        
                        // Get the tabNode's child node (Must be DockedWindow)
                        var objWindowNode = Xml_SelectSingleNode("WC:Tags.UserControl", objSelectedTabPageNode);

                        if (objWindowNode)
                        {
                            // Get the header tool tip if exists
                            strSelectedWindowHeaderToolTip = Xml_GetAttribute(objWindowNode, "Attr.ZoneHeaderToolTip", "");
                        }

                        if (strSelectedTabPageText)
                        {
                            // Get the zone's label
                            var objLabelNode = Data_GetNodeByAttribute(objDockedTabControlParentNode, "Attr.CustomStyle", "ZoneHeaderLabelSkin");
                            if (objLabelNode)
                            {                                
                                // Set the label's text
                                Xml_SetAttribute(objLabelNode, "Attr.Text", strSelectedTabPageText);

                                // Set the label's ToolTip
                                Xml_SetAttribute(objLabelNode, "Attr.ToolTip", strSelectedWindowHeaderToolTip);

                                // Redraw the label
                                Controls_RedrawControlByNode(objWindow, objLabelNode);
                            }
                        }
                    }
                }
            }
        }
    }
}
/// </method>