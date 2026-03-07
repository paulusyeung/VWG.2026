/// <method name="DataGridViewVisualTemplate_SetCurrentDisplayedContainer">
/// <summary>
///	Will set the current display on the grid node, to be kepts for further correct rendering.
/// </summary>
/// <param name="objDataGridView">The grid XML NODE</param>
/// <param name="strContainerName">The name of the view</param>
/// <param name="blnIsAdded">if the view is added or removed (and moved back to the previous view.</param>
function DataGridViewVisualTemplate_SetCurrentDisplayedContainer(objDataGridView, strContainerName, blnIsAdded)
{
    if (objDataGridView && strContainerName)
    {
        if (blnIsAdded)
        {
            Data_SetNodeAttribute(objDataGridView, "VWGVTCURRENTCONTAINER", strContainerName);
        }
        else
        {
            Data_SetNodeAttribute(objDataGridView, "VWGVTCURRENTCONTAINER", "");
        }
    }
}
/// </method>

/// <method name="DataGridViewVisualTemplate_ShowSortContainer">
function DataGridViewVisualTemplate_ShowContainer(strGridId, strBaseClassName, strContainerName, objWindow, objEvent)
{
    if (strGridId && objWindow)
    {
        var objDataGridViewNode = Data_GetNode(strGridId);
        var objSortContainerElement = Web_GetElementById(strContainerName + strGridId, objWindow);

        DataGridViewVisualTemplate_SetCurrentDisplayedContainer(objDataGridViewNode, strContainerName, true);

        var objSortContainerObject = $(objSortContainerElement);

        objSortContainerObject.removeClass(strBaseClassName + "_Hidden");
    }
}
/// </method>

/// <method name="DataGridViewVisualTemplate_ShowSortContainer">
function DataGridViewVisualTemplate_HideContainer(strGridId, strBaseClassName,strContainerName, objWindow, objEvent)
{
    if (strGridId && objWindow)
    {
        var objDataGridViewNode = Data_GetNode(strGridId);
        var objSortContainerElement = Web_GetElementById(strContainerName + strGridId, objWindow);

        DataGridViewVisualTemplate_SetCurrentDisplayedContainer(objDataGridViewNode, strContainerName, false);

        var objSortContainerObject = $(objSortContainerElement);

        objSortContainerObject.addClass(strBaseClassName + "_Hidden");
    }
}
/// </method>

/// <method name="DataGridViewVisualTemplate_ShowFilterForColumnContainer">
/// <summary>
///	Will set the option page of the current filter chosen..
/// </summary>
function DataGridViewVisualTemplate_ShowFilterForColumnContainer(strGridId, strMemberId,strBaseClassName, strFilterForColumnContainer, objWindow, objEvent)
{
    if (strGridId && strMemberId)
    {
        //DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseOne(strGridId, strMemberId, strBaseClassName, strFilterForColumnContainer, objWindow, objEvent);
        //return;
        var objDataGridViewNode = Data_GetNode(strGridId);

        // Check for validity
        if (objDataGridViewNode)
        {
            // Get the node related to the filter by the strMemeberId
            // Define an xpath which will search for the node.
            var strXPath = "WG:Tags.DataGridViewRow[@Attr.FilterRow=\"1\"]/WG:Tags.DataGridViewCell[@Attr.MemberID=\"" + strMemberId  + "\"]";

            // Exectue xpath.
            var objOptionNodes = Xml_SelectNodes(strXPath, objDataGridViewNode);

            if (objOptionNodes && objOptionNodes.length == 1)
            {
                Xml_SetAttribute(objDataGridViewNode, "VTFUNCTION", "on");

                // Transform the received component's xml into html.
                var strViewByTagName = Xml_TransformToHTML(objOptionNodes[0]);

                Xml_SetAttribute(objDataGridViewNode, "VTFUNCTION", "");

                // Get the DIV that will display the current content.
                var objFilterRowContainer = DataGridViewVisualTemplate_GetFilterForColumnContainer(strGridId, strFilterForColumnContainer, objWindow);

                if (!Aux_IsNullOrEmpty(strViewByTagName) && objFilterRowContainer)
                {
                    // Set the dragged over floating element inner html.
                    Web_SetInnerHtml(objFilterRowContainer, strViewByTagName);

                    DataGridViewVisualTemplate_ShowContainer(strGridId, strBaseClassName, strFilterForColumnContainer, objWindow, objEvent);
                }
            }
        }
    }
}
/// </method>

/// <method name="DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainer">
/// <summary>
///	Will get the option page of the current filter functions..
/// </summary>
function DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseOne(strGridId, strMemberId, strBaseClassName, strFilterForColumnContainer, objWindow, objEvent)
{
    // Create event and raise if critical
    var objVisualTemplateEvent = VisualTempalte_CreateEvent(strGridId, false, false, false);

    Events_SetEventAttribute(objVisualTemplateEvent, "Attr.Member", strMemberId);

    var objDataGridViewNode = Data_GetNode(strGridId);
    if (objDataGridViewNode)
    {
        Xml_SetAttribute(objDataGridViewNode, "VTCURRENTMEMBERID", strMemberId);
    }

    Events_SetEventAttribute(objVisualTemplateEvent, "EventAction", "ShowFilterOptions");

    Events_RaiseEvents(new Aux_CallbackDelegate(function () { mobjApp.DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseTwo(strGridId, strMemberId, strBaseClassName, strFilterForColumnContainer, objWindow, objEvent); }));
}
/// </method>

/// <method name="DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseTwo">
/// <summary>
///	Will set the option page of the current filter fucntion chosen..
/// </summary>
function DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseTwo(strGridId, strMemberId, strBaseClassName, strFilterForColumnContainer, objWindow, objEvent)
{
    DataGridViewVisualTemplate_ShowContainer(strGridId, strBaseClassName, strFilterForColumnContainer, objWindow, objEvent);
}
/// </method>

/// <method name="DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseThree">
/// <summary>
///	Will set the filter column data after the filter function was chosen.
/// </summary>
function DataGridViewVisualTemplate_ShowFilterColumnFunctionsContainerPhaseThree(strGridId, strMemberId, strFilterFunctionIndex, strBaseClassName, strFilterForColumnContainer, strFilterOperatorsContainer, objWindow, objEvent)
{
    // Create an event to set the filter clicked
    var objVisualTemplateEvent = VisualTempalte_CreateEvent(strGridId, false, false, false);

    Events_SetEventAttribute(objVisualTemplateEvent, "Attr.Member", strMemberId);

    Events_SetEventAttribute(objVisualTemplateEvent, "Attr.Value", strFilterFunctionIndex);

    Events_SetEventAttribute(objVisualTemplateEvent, "EventAction", "SetFilterOption");

    // Bring the column options for values.
    DataGridViewVisualTemplate_ShowFilterForColumnContainer(strGridId, strMemberId, strBaseClassName, strFilterForColumnContainer, objWindow, objEvent);

    // Hide the filter functions container.
    DataGridViewVisualTemplate_HideContainer(strGridId, strBaseClassName, strFilterOperatorsContainer, objWindow, objEvent);

    var objDataGridViewNode = Data_GetNode(strGridId);
    if (objDataGridViewNode)
    {
        Xml_SetAttribute(objDataGridViewNode, "VTCURRENTMEMBERID", "");
    }
}
/// </method>

/// <method name="DataGridViewVisualTemplate_GetFilterForColumnContainer">
/// <summary>
/// 
/// </summary>
function DataGridViewVisualTemplate_GetFilterForColumnContainer(strGridId, strFilterForColumnContainer,  objWindow)
{
    if (objWindow)
    {
        return Web_GetElementById(strFilterForColumnContainer + strGridId, objWindow);
    }

    return null;
}
/// </method>

/// <method name="DataGridViewVisualTemplate_SetFilterValue">
/// <summary>
/// 
/// </summary>
function DataGridViewVisualTemplate_SetFilterValue(strComboBoxFilterId, strValue, strBaseClassName, strFilterForColumnContainer, objWindow, objEvent)
{
    var objNode = Data_GetNode(strComboBoxFilterId);

    if (objNode)
    {
        // Create event and raise if critical
        var objEvent = Events_CreateTraceableEvent(objWindow, null, strComboBoxFilterId, "ValueChange", null, true);

        Events_SetEventAttribute(objEvent, "Attr.Value", strValue);

        // Raise if critical
        if (Data_IsCriticalEvent(objNode, "Event.ValueChange", true))
        {
            Events_RaiseEvents();
        }
    }
}
/// </method>

/// <method name="DataGridViewVisualTemplate_ToggleDisplayLayout">
/// <summary>
/// Toggles DataGridView Diplay Layout between List and Table layouts.
/// </summary>
function DataGridViewVisualTemplate_ToggleDisplayLayout(strGridId, strClickedButtonName, objWindow, objEvent)
{
    var objListLayoutButton = Web_GetWebElement("VWG_LLB_" + strGridId, objWindow);
    var objTableLayoutButton = Web_GetWebElement("VWG_TLB_" + strGridId, objWindow);

    if (objListLayoutButton && objTableLayoutButton)
    {
        if (objListLayoutButton.className.indexOf("_Disabled") > -1 && strClickedButtonName == "ListLayoutButton")
        {
            objListLayoutButton.className = objListLayoutButton.className.replace("_Disabled", "");
            objTableLayoutButton.className = objTableLayoutButton.className + "_Disabled";
        }
        else if (objTableLayoutButton.className.indexOf("_Disabled") > -1 && strClickedButtonName == "TableLayoutButton")
        {
            objListLayoutButton.className = objListLayoutButton.className + "_Disabled";
            objTableLayoutButton.className = objTableLayoutButton.className.replace("_Disabled", "");
        }
    }
}
/// </method>

/// <method name="DataGridViewVisualTemplate_ToggleViewByGroups">
/// <summary>
/// Toggles View by Groups switch.
/// </summary>
function DataGridViewVisualTemplate_ToggleViewByGroups(strGridId, strBaseClassName, objWindow, objEvent)
{
    var objViewByGroupsButton = Web_GetWebElement("VWG_VBG_" + strGridId, objWindow);
    var objGroupOrderContainer = Web_GetWebElement("VWGDGVGROUPORDERCONTAINER_" + strGridId, objWindow);

    if (objViewByGroupsButton && objGroupOrderContainer)
    {
        if (objViewByGroupsButton.className.indexOf("_Disabled") > -1)
        {
            objViewByGroupsButton.className = objViewByGroupsButton.className.replace("_Disabled", "");
            $(objGroupOrderContainer).removeClass(strBaseClassName + "_Hidden");
        }
        else
        {
            objViewByGroupsButton.className = objViewByGroupsButton.className + "_Disabled";
            $(objGroupOrderContainer).addClass(strBaseClassName + "_Hidden");
        }
    }
}
/// </method>

/// <method name="DataGridViewVisualTemplate_AddGroup">
/// <summary>
/// Adds group to current grouping.
/// </summary>
function DataGridViewVisualTemplate_AddGroup(strGridId, strMemberId, objWindow, objEvent)
{
    //// Get the subject VWG element.
    //var objSourceColumn = Web_GetElementById("VWG_" + strGridId + "_" + strMemberId, objWindow);

    //// Get dragged column data property name.
    //var strSourceColumnDataPropertyName = Web_GetAttribute(objSourceColumn, "vwggroupingcolumnname", "");

    //if (!Aux_IsNullOrEmpty(strSourceColumnDataPropertyName))
    //{
    //    // Raise proper event.
    //    DataGridView_CreateColumnDragEvent(strGridId, "InsertGroup", strSourceColumnDataPropertyName, "");
    //}




    // Get the subject VWG element.
    var objSourceColumn = Web_GetElementById("VWG_CH_" + strGridId + "_" + strMemberId, objWindow);

    // Get dragged column data property name.
    var strSourceColumnDataPropertyName = Web_GetAttribute(objSourceColumn, "vwggroupingcolumnname", "");

    // Create event and raise if critical
    var objVisualTemplateEvent = VisualTempalte_CreateEvent(strGridId, false, false, false);

    Events_SetEventAttribute(objVisualTemplateEvent, "Attr.Member", strMemberId);
    Events_SetEventAttribute(objVisualTemplateEvent, "Attr.Name", strSourceColumnDataPropertyName);

    Events_SetEventAttribute(objVisualTemplateEvent, "EventAction", "AddGroup");

    Events_RaiseEvents();
}
/// </method>