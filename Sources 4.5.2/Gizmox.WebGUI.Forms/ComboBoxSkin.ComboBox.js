/// <method name="ComboBox_ShowDropDown">
/// <summary>
/// Occurs when a combobox navigation is required
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="objWindow">The originating event window.</param>
/// <param name="objNode">The combobox data node.</param>
function ComboBox_ShowDropDown(strGuid, objWindow, objNode)
{
    // Open a new drop down 
    ComboBox_OpenPopup(strGuid, objWindow, objNode, false);

    // Get combobox target element.
    var objTargetElement = Web_GetElementById("TRG_" + strGuid, objWindow);
    if (objTargetElement)
    {
        // Set selection on the whole value in the input
        if (Web_IsTag(objTargetElement, "input"))
        {
            // Gets the component node if not provided
            if (!objNode)
            {
                objNode = Data_GetNode(strGuid);
            }
            if (objNode)
            {
                // Scroll into view as for the current text.
                ComboBox_SetPositionByText(strGuid, objNode, objTargetElement, objTargetElement.value, false, true, objWindow);
            }
        }
    }
}
/// </method>

/// <method name="ComboBox_ToggleDropDown">
/// <summary>
/// Toggle drop down from open to close and vice versa.
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="objWindow">The originating event window.</param>
function ComboBox_ToggleDropDown(strGuid, objWindow)
{
    // Gets the component node
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        // Check if control	is disabled.
        if (!Data_IsDisabled(objNode))
        {
            // If there is an open popup
            if (ComboBox_IsDropDownVisible(strGuid))
            {
                // Hide open popup.
                ComboBox_HideDropDown(strGuid);
            }
            else
            {
                // Show drop down 
                ComboBox_ShowDropDown(strGuid, objWindow, objNode);
            }
        }
    }
}
/// </method>

/// <method name="ComboBox_OnKeyUP">
/// <summary>
/// Occurs when a key is pressed on the combobox
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="strStyle">The combobox style.</param>
/// <param name="objInput">The input box.</param>
/// <param name="objWindow">The originating event window.</param>
/// <param name="objEvent">The keypress event object.</param>
function ComboBox_OnKeyUP(strGuid, strStyle, objInput, objWindow, objEvent)
{
    // Get the pressed key
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // Check if enter was pressed.
    if (intKeyCode == mcntEnterKey)
    {
        // If the popup is not visible
        if (!ComboBox_IsDropDownVisible(strGuid))
        {
            ComboBox_FireTextChange(strGuid, objInput.value, objWindow);
        }
    }

        // Check if not is navigation key.
    else if (!Web_IsNavigationKey(intKeyCode))
    {
        // Gets the component node
        var objNode = Data_GetNode(strGuid);
        if (objNode)
        {
            // Get auto complete mode.
            var strAutoCompleteMode = Xml_GetAttribute(objNode, "Attr.AutoCompleteMode", "");

            // Scroll into view the current text
            ComboBox_SetPositionByText(strGuid, objNode, objInput, objInput.value, false, strAutoCompleteMode == "S" || strAutoCompleteMode == "SA", objWindow);
        }
    }
}
/// </method>

/// <method name="ComboBox_FireTextChange">
/// <summary>
/// Occurs when a combobox text is changed
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="strValue">The select value.</param>
/// <param name="objWindow">The originating event window.</param>
function ComboBox_FireTextChange(strGuid, strValue, objWindow)
{
    // Gets the component node
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        // Even when setting inputs with text-transform:uppercase/lowercase their value can still be "Normal
        // So we change the value to be correct before any logic occurs
        var strCharacterCasingAttribute = Data_GetNodeAttribute(objNode, "Attr.CharacterCasing", null);

        if (strCharacterCasingAttribute) {
            switch (strCharacterCasingAttribute) {
                case "2":
                    strValue = strValue.toLowerCase();
                    break;
                case "1":
                    strValue = strValue.toUpperCase();
                    break;
            }
        }

        //Encode the text before sending it to the server.
        var strEncodeText = Aux_EncodeText(strValue);

        // Check if value has changed
        if (!Xml_IsAttribute(objNode, "Attr.Text", strEncodeText))
        {
            // Set control value
            Xml_SetAttribute(objNode, "Attr.Text", strEncodeText);

            // Create event and raise if critical	
            var objEvent = Events_CreateEvent(strGuid, "TextChange", null, true);

            // Set event value
            Events_SetEventAttribute(objEvent, "Attr.Value", strEncodeText);

            // Raise event if needed
            if (Data_IsCriticalEvent(objNode, "Event.ValueChange", true))
            {
                Events_ScheduleRaiseEvents(100);
            }

            Events_ScheduleProcessClientEvent(objEvent, 100);
        }
    }
}
/// </method>

/// <method name="ComboBox_HandlePopupTerminationKeys">
/// <summary>
///	Handles keys which causes popup to be hidden.
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="intKeyCode">The current key code.</param>
/// <param name="objWindow">The originating event window.</param>
/// <param name="objEvent">The html event.</param>
function ComboBox_HandlePopupTerminationKeys(strGuid, intKeyCode, objWindow, objEvent)
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEMpty(strGuid) && !Aux_IsNullOrEMpty(intKeyCode) && objWindow)
    {
        // If should select current dropdown selection
        if ([mcntTabKey, mcntEnterKey].contains(intKeyCode))
        {
            // Get combobox node
            var objComboBoxNode = Data_GetNode(strGuid);
            if (objComboBoxNode)
            {
                // Check if combobox value should be updated: user pressed enter or combobox located in a datagridview
                if (intKeyCode == mcntEnterKey || Xml_IsAttribute(objComboBoxNode, "Attr.CancelSelectOnDropDownNaviagation", "1"))
                {
                    // Get the virtual list scroller
                    var objVLScroller = ComboBox_GetVLScroller(strGuid, objWindow);
                    if (objVLScroller)
                    {
                        // Get the selection index of the virtual list
                        var intDropDownIndex = VirtualList_GetSelection(objVLScroller);

                        // Update value by option position - data behind, target element and a value changed event.
                        ComboBox_UpdateValueByOptionPosition(strGuid, objComboBoxNode, intDropDownIndex, objWindow, false);
                    }
                }
            }
        }

        // Check if popup is visible.
        if (ComboBox_IsDropDownVisible(strGuid))
        {
            // Hide existing popup
            ComboBox_HideDropDown(strGuid);
        }
    }
}
/// </method>

/// <method name="ComboBox_CalculateNavigatedIndex">
/// <summary>
///	Calculates next index.
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="objNode">The combobox node.</param>
/// <param name="objWindow">The originating event window.</param>
/// <param name="intKeyCode">The current key code.</param>
function ComboBox_CalculateNavigatedIndex(strGuid, objNode, objWindow, intKeyCode)
{
    var intIndex = 0;

    // Get combobox target element.
    var objTargetElement = Web_GetElementById("TRG_" + strGuid, objWindow);

    // Try getting a client index.
    var strClientIndex = Web_GetAttribute(objTargetElement, "vwg_ClientIndex", true);
    if (!Aux_IsNullOrEmpty(strClientIndex))
    {
        // Clean client index.
        Web_SetAttribute(objTargetElement, "vwg_ClientIndex", "");

        // Parse client index.
        intIndex = parseInt(strClientIndex, 10);
    }
    else
    {
        // Try get the virtual list scroller
        var objVLScroller = ComboBox_GetVLScroller(strGuid, objWindow);

        // Get the current position as for virtual list / data behind
        intIndex = (objVLScroller ? VirtualList_GetSelection(objVLScroller) : ComboBox_GetPosition(objNode));
    }

    // Get options array.
    var arrOptions = ComboBox_GetOptions(objNode, true);
    if (arrOptions)
    {
        // Calculate options count.
        var intOptionsCount = arrOptions.length;

        // Get the number of items in page
        var intPageSize = parseInt(Xml_GetAttribute(objNode, "Attr.Maximum"));

        // Select navigation diff
        switch (intKeyCode)
        {
            case mcntLeftKey:
            case mcntUpKey:
                intIndex--;
                break;
            case mcntRightKey:
            case mcntDownKey:
                intIndex++;
                break;
            case mcntPageDownKey:
                intIndex += (intPageSize - 1);
                break;
            case mcntPageUpKey:
                intIndex -= (intPageSize - 1);
                break;
            case mcntEndKey:
                intIndex = (intOptionsCount - 1);
                break;
            case mcntHomeKey:
                intIndex = 0;
                break;
        }

        // Validate and normalize index - if it exceeds one of the boundries.
        if (intIndex < 0)
        {
            intIndex = 0;
        }
        else if (intIndex >= intOptionsCount)
        {
            intIndex = intOptionsCount - 1;
        }
    }

    return intIndex;
}
/// </method>

/// <method name="ComboBox_HandleNavigationKeys">
/// <summary>
///	Occurs when a combobox key down is pressed
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="strStyle">The combobox style.</param>
/// <param name="objWindow">The originating event window.</param>
/// <param name="objEvent">The keydown event object.</param>
/// <param name="intKeyCode">The current key code.</param>
function ComboBox_HandleNavigationKeys(strGuid, strStyle, objWindow, objEvent, intKeyCode)
{
    var blnNavigationHandled = false;

    // If is navigation key(vertical navigation) or horizontal navigation in DropDownList only
    // Handle the up and down movment in the combo popup list item window.	
    if ([mcntUpKey, mcntDownKey, mcntPageUpKey, mcntPageDownKey].contains(intKeyCode) ||
        (strStyle == 'DDL' && [mcntRightKey, mcntLeftKey, mcntEndKey, mcntHomeKey].contains(intKeyCode)))
    {
        // Get combobox node.
        var objNode = Data_GetNode(strGuid);
        if (objNode)
        {
            // Calculates next index.
            var intIndex = ComboBox_CalculateNavigatedIndex(strGuid, objNode, objWindow, intKeyCode);

            // Check whether to restrain the event in case of navigation keys.            
            if (Xml_IsAttribute(objNode, "Attr.CancelSelectOnDropDownNaviagation", "1"))
            {
                //If the drop down is open select
                if (ComboBox_IsDropDownVisible(strGuid))
                {
                    // Update combobox selection.
                    ComboBox_UpdateSelection(strGuid, intIndex, false, objWindow);
                }
            }
            else
            {
                var blnSuspendRaiseEvents = false;

                if (strStyle == "S")
                {
                    blnSuspendRaiseEvents = Data_IsCriticalEvent(objNode, "Event.KeyDown", true);
                }

                // Update value by option position - data behind, target element and a value changed event.
                ComboBox_UpdateValueByOptionPosition(strGuid, objNode, intIndex, objWindow, blnSuspendRaiseEvents);

                if (blnSuspendRaiseEvents)
                {
                    Web_OnKeyDown(objEvent, objWindow, true);
                }
            }

            // Cancel defualt scrolling functionality.
            Web_EventCancelBubble(objEvent, true, false);

            // Try get the virtual list scroller.
            var objVLScroller = ComboBox_GetVLScroller(strGuid, objWindow);
            if (objVLScroller)
            {
                // Set virtual list selection.
                VirtualList_SetSelection(objVLScroller, intIndex, true, objWindow);
            }
        }

        blnNavigationHandled = true;
    }

    //return if this function was handled
    return blnNavigationHandled;
}
/// </method>

/// <method name="ComboBox_OnKeyDown">
/// <summary>
///	Occurs when a combobox key down is pressed
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="strStyle">The combobox style.</param>
/// <param name="strAutoCompleteMode">The combobox auto complete mode.</param>
/// <param name="objWindow">The originating event window.</param>
/// <param name="objEvent">The keydown event object.</param>
function ComboBox_OnKeyDown(strGuid, strStyle, strAutoCompleteMode, objElement, objWindow, objEvent)
{
    // Define a toggle drop down switch.
    var blnToggleDropDown = false;

    // Define a drop down switch.
    var blnShowDropDown = false;

    // Define a transfer key down switch.
    var blnTransferKeyDown = false;

    // Get the pressed key
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // Check whether recieved element is an input.
    var blnIsInput = Web_IsTag(objElement, "input");

    // Check if alt is pressed.
    if (Web_IsAlt(objEvent))
    {
        // Check if down or up keys has been pressed.   
        if (intKeyCode == mcntDownKey || intKeyCode == mcntUpKey)
        {
            // Check that srop down style is not simple.
            blnToggleDropDown = (strStyle != 'S');
        }
    }

        // Check if popup should be terminated.
    else if ([mcntTabKey, mcntEscapeKey, mcntEnterKey].contains(intKeyCode))
    {
        // Make sure TextChange is raised before Enter key is processed
        if ([mcntEnterKey].contains(intKeyCode)) {
            if (!ComboBox_IsDropDownVisible(strGuid)) {
                ComboBox_FireTextChange(strGuid, objElement.value, objWindow);
            }
        }

        // Handles keys which causes popup termination.
        ComboBox_HandlePopupTerminationKeys(strGuid, intKeyCode, objWindow, objEvent);
    }

        // Check if navigation key.
    else if (Web_IsNavigationKey(intKeyCode))
    {
        // Check if HandleNavigationKeys was handled.
        if (ComboBox_HandleNavigationKeys(strGuid, strStyle, objWindow, objEvent, intKeyCode))
        {
            // Check if target element is a input.(DropDwon and Simple styles)
            if (blnIsInput)
            {
                // Select all of input's text after navigation is completed.
                Web_SetSelection(objElement, 0, objElement.value.length);
            }
        }
    }


        // If not WinForms compatible and AutoCompleteMode - Suggest or SuggestAppend (not None or Append). Ignores control/alt and any non-character keys.
    else if (!Web_IsAlt(objEvent) && !Web_IsControl(objEvent) && Aux_IsCharacterKeyCode(intKeyCode) && strStyle != 'S' && strAutoCompleteMode != 'A' && strAutoCompleteMode != 'N')
    {
        // Check if transfer key down is needed.
        blnTransferKeyDown = (strStyle == 'DDL');

        // Flag that drop down is needed.
        blnShowDropDown = true;
    }

        // If not alt/enter/Ctrl/Shift key alone and there is not a text box
    else if (!blnIsInput && !([mcntAltKey, mcntEnterKey, mcntShiftKey, mcntCtrlKey].contains(intKeyCode)))
    {
        // Gets the component node
        var objNode = Data_GetNode(strGuid);
        if (objNode)
        {
            // Check if keydown accumulating is not supported
            blnTransferKeyDown = !Xml_IsAttribute(objNode, "Attr.SupportKeydownAccumulating", "0");
        }
    }

    // Check if transfer key down is needed.
    if (blnTransferKeyDown)
    {
        // Transfer keydown to "recorder".
        Web_TransferKeyDown(objElement, objWindow, ComboBox_KeyDownCallback, strGuid);
    }

    // Check combobox visibility.
    var blnIsDropDownVisible = ComboBox_IsDropDownVisible(strGuid);

    // Check if drop down should be shown.
    if (blnShowDropDown)
    {
        // Check combobox visibility.
        if (!blnIsDropDownVisible)
        {
            // Show the drow down.
            ComboBox_ShowDropDown(strGuid, objWindow);
        }
    }
        // Check if drop down should be toggled.
    else if (blnToggleDropDown)
    {
        // Check combobox visibility.
        if (!blnIsDropDownVisible)
        {
            // Show the drow down.
            ComboBox_ShowDropDown(strGuid, objWindow);
        }
        else
        {
            // Hide existing popup
            ComboBox_HideDropDown(strGuid);
        }
    }
}
/// </method>

/// <method name="ComboBox_KeyDownCallback">
/// <summary>
///	Is invoked after "recorder" is done to record typing on a closed DDL
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="strValue">The recorded string value.</param>
/// <param name="objElement">The source element.</param>
function ComboBox_KeyDownCallback(strGuid, strValue, objElement)
{
    // Gets the component node
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        ComboBox_SetPositionByText(strGuid, objNode, objElement, strValue, true, true, Web_GetWindowFromObject(objElement));
    }
}
/// </method>

/// <method name="ComboBox_SetPositionByText">
/// <summary>
///	
/// </summary>
function ComboBox_SetPositionByText(strGuid, objNode, objElement, strText, blnUpdateValue, blnUpdateSelection, objWindow)
{
    var strIndex = "-1";

    // Validate recieved text.
    if (!Aux_IsNullOrEmpty(strText))
    {
        // Replace no break spaces with normal spaces and encode outcome value.
        strText = Aux_EncodeText(strText.replace(/\xA0/g, String.fromCharCode(32)));
    }

    // Get the option node
    var objOptionNode = ComboBox_GetOptionByText(objNode, strText);
    if (objOptionNode)
    {
        // Get the actual option index
        strIndex = Xml_GetAttribute(objOptionNode, "Attr.Index", "");
        if (!Aux_IsNullOrEmpty(strIndex))
        {
            // Check if should update value.
            if (blnUpdateValue)
            {
                // Update value by option position - data behind, target element and a value changed event.
                ComboBox_UpdateValueByOptionPosition(strGuid, objNode, strIndex, objWindow, false);
            }
            else if (objElement)
            {
                // Preseve client index.
                Web_SetAttribute(objElement, "vwg_ClientIndex", strIndex);
            }
        }
    }

    // If should update selection
    if (blnUpdateSelection)
    {
        // Update selection and scroll into view
        ComboBox_UpdateSelection(strGuid, strIndex, true, objWindow);
    }
    else
    {
        // Scroll into view
        ComboBox_UpdateScroller(strGuid, strIndex, objWindow);
    }
}
/// </method>

/// <method name="ComboBox_QueryOptionByText">
/// <summary>
/// 
/// </summary>
function ComboBox_QueryOptionByText(objNode, strText)
{
    // Define option node.
    var objOptionNode = null;

    // Get options parentNode either local or through options component
    if (objNode) {
        objNode = ComboBox_GetOptions(objNode, false);
        if (objNode)
            objNode = objNode.parentNode;
    }

    // Validate recieved arguments.
    if (objNode && !Aux_IsNullOrEmpty(strText))
    {
        // Get lower and upper cases of recieved text.
        var strLowerCaseText = strText.toLowerCase();
        var strUpperCaseText = strText.toUpperCase();

        // Define an xpath which will search for recieved text in lower case.
        var strXPath = "Tags.Options/Tags.Option[starts-with(translate(@Attr.Text, \"" + strUpperCaseText + "\" , \"" + strLowerCaseText + "\"),\"" + strLowerCaseText + "\")]";

        // Exectue xpath.
        objOptionNodes = Xml_SelectNodes(strXPath, objNode);

        // Get the currently selected index
        var intCurrentPosition = ComboBox_GetPosition(objNode);

        if (intCurrentPosition > -1)
        {
            // Iterate through all items to check if the current item is within them
            for (var i = 0; i < objOptionNodes.length; i++)
            {
                if (Xml_GetAttribute(objOptionNodes[i], "Attr.Index") == intCurrentPosition)
                {
                    // The the current item is there, select the next one.
                    if (objOptionNodes.length > i + 1)
                    {
                        return objOptionNodes[i + 1];
                    }
                    break;
                }
            }
        }

        objOptionNode = objOptionNodes.length > 0 ? objOptionNodes[0] : null;
    }

    return objOptionNode;
}
/// </method>

/// <method name="ComboBox_DoGetOptionsByText">
/// <summary>
/// Gets a combobox option by text
/// </summary>
/// <param name="objNode">The control node.</param>
/// <param name="strText">The current text value.</param>
function ComboBox_DoGetOptionsByText(objNode, strText)
{
    // Define option node.
    var objOptionNode = null;

    // Validate recieved arguments.
    if (objNode && !Aux_IsNullOrEmpty(strText))
    {
        // Quotation marks are used as string delimiters. It must be eliminated from recieved text so that auto complete will ignore it.
        strText = strText.replace(/\"/g, "&quot;");

        // Query option by text.        
        objOptionNode = ComboBox_QueryOptionByText(objNode, strText);

        // Loop while an option node is not found and text is not empty.
        while (!objOptionNode && !Aux_IsNullOrEmpty(strText))
        {
            // Remove last character.
            strText = strText.substring(0, strText.length - 1);

            // Re-query option by text.
            objOptionNode = ComboBox_QueryOptionByText(objNode, strText);
        }
    }

    // Return option node.
    return objOptionNode;
}
/// </method>

/// <method name="ComboBox_OnListNavigateWheel">
/// <summary>
///	
/// </summary>
function ComboBox_OnListNavigateWheel(strGuid, objWindow, objEvent, intControlReadOnly) {
    // Cehck that combobox is not read only.
    if (intControlReadOnly == 0) {
        // Get combobox scroller.
        var objVLScroller = ComboBox_GetVLScroller(strGuid, objWindow);
        if (objVLScroller) {
            // Calculate index offset.
            var intOffsetIndex = 0;
            if (objEvent.detail) {
                intOffsetIndex = objEvent.detail
            } else if (objEvent.wheelDelta) {
                intOffsetIndex = ((-1) * (objEvent.wheelDelta / 120));
            } else if (objEvent.deltaY && objEvent.deltaFactor)
                intOffsetIndex = ((-1) * objEvent.deltaY * objEvent.deltaFactor) / 120;

            // Update scroller.
            VirtualList_UpdateScroller(objVLScroller, intOffsetIndex);

            // Cancel event bubbling
            Web_EventCancelBubble(objEvent);
        }
    }
}
/// </method>

/// <method name="ComboBox_GetVLScroller">
/// <summary>
///	
/// </summary>
function ComboBox_GetVLScroller(strGuid, objWindow)
{
    return Web_GetElementById("VWGVLSC_" + strGuid, objWindow);
}
/// </method>

/// <method name="ComboBox_OnContentNavigateWheel">
/// <summary>
///	
/// </summary>
function ComboBox_OnContentNavigateWheel(strGuid, strStyle, objWindow, objEvent, intControlReadOnly)
{
    // Cehck that combobox is not read only and that it is in focus.
    if (intControlReadOnly == 0 && strGuid == Focus_GetFocusElementDataId())
    {
        // Get combobox node
        var objNode = Data_GetNode(strGuid);
        if (objNode)
        {
            // Check popup visibility.
            if (!ComboBox_IsDropDownVisible(strGuid))
            {
                // Get option index
                var intIndex = parseInt(ComboBox_GetPosition(objNode));
                if (!isNaN(intIndex))
                {
                    // Change index by wheel-delta
                    intIndex -= objEvent.wheelDelta / 120;

                    // Update value by option position - data behind, target element and a value changed event.
                    ComboBox_UpdateValueByOptionPosition(strGuid, objNode, intIndex, objWindow, false);
                }

                // Cancel event bubbling
                Web_EventCancelBubble(objEvent);
            }
            else
            {
                // Perform list navigate wheel.
                ComboBox_OnListNavigateWheel(strGuid, objWindow, objEvent, intControlReadOnly);
            }
        }
    }
}
/// </method>

/// <method name="ComboBox_OnItemClick">
/// <summary>
/// 
/// </summary>
function ComboBox_OnItemClick(strGuid, strIndex, strStyle, objWindow, objEvent)
{
    // Check if control is enabled.
    //And if an item index exist(in simple mode you can press on an area without any item
    if (!Data_IsDisabled(strGuid))
    {
        // Gets the component node
        var objNode = Data_GetNode(strGuid);
        if (objNode)
        {
            if (ComboBox_IsDropDownVisible(strGuid))
            {
                // Popup is visible -> close it
                ComboBox_HideDropDown(strGuid);
            }
                // Validate recieved index.
            else if (!Aux_IsNullOrEmpty(strIndex))
            {
                // Set the new selection
                ComboBox_UpdateSelection(strGuid, strIndex, false, objWindow);
            }

            // Validate recieved index.
            if (!Aux_IsNullOrEmpty(strIndex))
            {
                var blnSuspendRaiseEvents = false;

                if (strStyle == "S")
                {
                    blnSuspendRaiseEvents = Data_IsCriticalEvent(objNode, "Event.ValueChange", true);
                }

                // Update value by option position - data behind, target element and a value changed event. Consider ForceSelectedIndexChanged attribute.
                ComboBox_UpdateValueByOptionPosition(strGuid, objNode, strIndex, objWindow, false, Xml_IsAttribute(objNode, "Attr.ForceSelectedIndexChanged", "1"));

                if (blnSuspendRaiseEvents)
                {
                    // Handles the click event and forces raise (this 'overload' cancels the click bubble.
                    Web_OnClick(objEvent, objWindow, true);
                }
            }

            // Set the focus back to the combo
            Controls_Focus(strGuid);
        }
    }
}
/// </method>

/// <method name="ComboBox_OnItemHover">
/// <summary>
/// 
/// </summary>
function ComboBox_OnItemHover(strGuid, strStyle, strIndex, objWindow, objEvent)
{
    if (strStyle != 'S')
    {
        ComboBox_UpdateSelection(strGuid, strIndex, false, objWindow);

        if (strStyle == 'DD')
        {
            // Get combobox target element.
            var objTargetElement = Web_GetElementById("TRG_" + strGuid, objWindow);
            if (objTargetElement)
            {
                // Clear client index.
                Web_SetAttribute(objTargetElement, "vwg_ClientIndex", "");
            }
        }
    }
}
/// </method>

/// <method name="ComboBox_UpdateSelection">
/// <summary>
/// 
/// </summary>
function ComboBox_UpdateSelection(strGuid, strIndex, blnScrollIntoView, objWindow)
{
    var objVLScroller = ComboBox_GetVLScroller(strGuid, objWindow);
    if (objVLScroller)
    {
        VirtualList_SetSelection(objVLScroller, parseInt(strIndex), blnScrollIntoView, objWindow);
    }
}
/// </method>

/// <method name="ComboBox_UpdateScroller">
/// <summary>
/// 
/// </summary>
function ComboBox_UpdateScroller(strGuid, strIndex, objWindow)
{
    var objVLScroller = ComboBox_GetVLScroller(strGuid, objWindow);
    if (objVLScroller)
    {
        VirtualList_SetScroller(objVLScroller, parseInt(strIndex));
    }
}
/// </method>

/// <method name="ComboBox_OnPopulateSimpleModeAsync">
/// <summary>
// Populate the simple mode list items
/// </summary>
function ComboBox_OnPopulateSimpleModeAsync(strGuid, objWindow)
{
    // Get the combobox node
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        // get the selected item position
        var intPosition = ComboBox_GetPosition(objNode);

        //set the objVLScroller
        var objVLScroller = ComboBox_CreateBinding(strGuid, ComboBox_GetOptions(objNode, true), objWindow, intPosition);

        //Move the scroller to the selected item position.
        VirtualList_NavigateToPosition(objVLScroller, intPosition, objWindow);

        //set the scroller visibility.
        ComboBox_ShowItemsScroller(strGuid, objWindow);
    }
}
/// </method>

/// <method name="ComboBox_ShowItemsScroller">
/// <summary>
///	Occurs when a combobox key down is pressed
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="objWindow">The originating event window.</param>
function ComboBox_ShowItemsScroller(strGuid, objWindow)
{
    // Get virtual list scroller.
    var objVLScroller = ComboBox_GetVLScroller(strGuid, objWindow);
    if (objVLScroller)
    {
        objVLScroller.style.visibility = 'visible';
    }
}
/// </method>

/// <method name="ComboBox_OnPopulateSimpleMode">
/// <summary>
/// Populate the simple mode list items
/// </summary>
function ComboBox_OnPopulateSimpleMode(strGuid, objWindow)
{
    Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(ComboBox_OnPopulateSimpleModeAsync, strGuid, objWindow), 10);
}
/// </method>

/// <method name="ComboBox_OnScroll">
/// <summary>
/// Called when combobox is scrolled
/// </summary>
/// <param name="objElement">Elment to focus to after thr scrol</param>
/// <param name="strGuid">the elment id</param>
function ComboBox_OnScroll(objElement, strGuid, objWindow)
{
    // Navigate to the current scrolled position
    VirtualList_Navigate(objElement, 0);
}
/// </method>

/// <method name="ComboBox_FireValueChange">
/// <summary>
/// Occurs when the combobox value has changed
/// </summary>
/// <param name="objWindow">The containing window.</param>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="objNode">The combobox data node.</param>
/// <param name="strValue">The select value.</param>
/// <param name="blnSuspendRaiseEvents">Suspend raise event.</param>
function ComboBox_FireValueChange(objWindow, strGuid, objNode, strValue, blnSuspendRaiseEvents)
{
    if (objNode)
    {
        // Create event and raise if critical
        var objEvent = Events_CreateTraceableEvent(objWindow, null, strGuid, "ValueChange", null, true);

        Events_SetEventAttribute(objEvent, "Attr.Value", strValue);

        // Raise if critical
        if (Data_IsCriticalEvent(objNode, "Event.ValueChange", true) && !blnSuspendRaiseEvents)
        {
            Events_RaiseEvents();
        }

        // Process client event.
        Events_ProcessClientEvent(objEvent);
    }
}
/// </method>

/// <method name="ComboBox_GetPosition">
/// <summary>
/// Gets the current combobox position
/// </summary>
function ComboBox_GetPosition(objNode)
{
    return parseInt(Xml_GetAttribute(objNode, "Attr.Value", 0));
}
/// </method>

/// <method name="ComboBox_UpdateValueByOptionPosition">
/// <summary>
/// Update value by option position - data behind, target element and a value changed event.
/// </summary>
function ComboBox_UpdateValueByOptionPosition(strGuid, objNode, intOptionPosition, objWindow, blnSuspendRaiseEvents, blnForceSelectedIndexChanged)
{
    // Get the relevant option node
    var objOptionNode = ComboBox_GetOptionByPosition(objNode, intOptionPosition);
    if (objOptionNode != null)
    {
        // Get the actual option index
        var intIndex = Xml_GetAttribute(objOptionNode, "Attr.Index", "");
        if (!Aux_IsNullOrEmpty(intIndex))
        {
            // Get text from option
            var strText = Xml_GetAttribute(objOptionNode, "Attr.Text", "");

            // Check if text has been changed.
            var blnValueChanged = !Xml_IsAttribute(objNode, "Attr.Value", intIndex);

            // Check if not in drop down list - a mode which does not allow text changing.
            if (!Xml_IsAttribute(objNode, "Attr.Style", "DDL"))
            {
                // Check if text changed
                blnValueChanged = blnValueChanged || !Xml_IsAttribute(objNode, "Attr.Text", strText);
            }

            if (blnValueChanged)
            {
                // Update data behind
                Xml_SetAttribute(objNode, "Attr.Value", intIndex);
                Xml_SetAttribute(objNode, "Attr.Text", strText);
                Xml_SetAttribute(objNode, "Attr.FormattedText", strText);

                // Get combobox target element.
                var objTargetElement = Web_GetElementById("TRG_" + strGuid, objWindow);
                if (objTargetElement)
                {
                    // Check if target element is a input.
                    var blnIsInputTaget = Web_IsTag(objTargetElement, "input");

                    // Set the inner text of the target element
                    Web_SetInnerText(objTargetElement, strText, (blnIsInputTaget ? 1 : 2));

                    // Flag that input's value has been applied through clipboard.
                    Web_SetAttribute(objTargetElement, "vwg_AppliedValue", "1");

                    // Set selection on the whole value in the input
                    if (blnIsInputTaget)
                    {
                        Web_SetSelection(objTargetElement, 0, objTargetElement.value.length);
                    }
                }
            }

            // If selected value changed or SelectedIndexChanged event is forced to be raised.
            if (blnValueChanged || blnForceSelectedIndexChanged)
            {
                // Raise event of text changed if needed
                ComboBox_FireValueChange(objWindow, strGuid, objNode, intIndex, blnSuspendRaiseEvents);
            }
        }
    }
}
/// </method>

/// <method name="ComboBox_GetOptionsNode">
/// <summary>
/// 
/// </summary>
/// <param name="objNode"></param>
function ComboBox_GetOptions(objNode, blnItems)
{
    var objOptions = null;

    // Try getting a local options node.
    objOptions = Xml_SelectSingleNode("Tags.Options", objNode);

    // If could not find local options
    if (!objOptions)
    {
        // Check if an options component attribute is defined.
        var strOptionsComponentId = Xml_GetAttribute(objNode, "Attr.OptionsComponent", "");

        // If there is a valid componenent id
        if (!Aux_IsNullOrEmpty(strOptionsComponentId))
        {
            // Get the options component node.
            var objOptionsComponent = Data_GetNode(strOptionsComponentId);

            // If there is a valid component options node
            if (objOptionsComponent)
            {
                // Get the options node from within the options component node.
                objOptions = Xml_SelectSingleNode("Tags.Options", objOptionsComponent);
            }
        }
    }

    // If should return items
    if (blnItems)
    {
        if (objOptions)
        {
            // Get option items from node
            objOptions = Xml_SelectNodes("Tags.Option", objOptions);
        }
    }

    return objOptions;
}
/// </method>

/// <method name="ComboBox_GetOptionByPosition">
/// <summary>
///	Gets a combobox option by index
/// </summary>
function ComboBox_GetOptionByPosition(objNode, intPosition)
{
    // Get options node
    var objOptionsNode = ComboBox_GetOptions(objNode, false);
    if (objOptionsNode)
    {
        // Get child in the required position.
        if ((intPosition >= 0) && (intPosition < objOptionsNode.childNodes.length))
        {
            return objOptionsNode.childNodes[intPosition];
        }

            // Ensure that new index does not exceed options boundries.
        else if (intPosition < 0)
        {
            return objOptionsNode.firstChild;
        }
        else if ((intPosition > objOptionsNode.childNodes.length - 1))
        {
            return objOptionsNode.lastChild;
        }
    }
}
/// </method>

/// <method name="ComboBox_HideDropDown">
/// <summary>
/// Hides the current active popup
/// </summary>
function ComboBox_HideDropDown(strControlId)
{
    Popups_HideControlPopup(window, strControlId);
}
/// </method>

/// <method name="ComboBox_IsDropDownVisible">
/// <summary>
/// Checks if a given drop down is visible
/// </summary>
function ComboBox_IsDropDownVisible(strGuid)
{
    return Popups_ShareFocusWithExistPopup(strGuid);
}
/// </method>

/// <method name="ComboBox_CreateBinding">
/// <summary>
/// Sets dropdown binding using a virtual list
/// </summary>
/// <param name="strGuid">The control guid.</param>
/// <param name="objItems">The binded item list.</param>
/// <param name="objWindow">The containing window.</param>
function ComboBox_CreateBinding(strGuid, objItems, objWindow, intStartingIndex, intItemHeight)
{
    // Bind virtual list
    var objVLTemplate = Web_GetElementById("VWGVL_" + strGuid, objWindow);
    if (objVLTemplate)
    {
        var objVLScroller = ComboBox_GetVLScroller(strGuid, objWindow);
        if (objVLScroller)
        {
            VirtualList_CreateBinding(objWindow, objVLTemplate, objVLScroller, objItems, intStartingIndex, false, 25, Xml_DataSourceAdapter, intItemHeight);

            if (!Web_SupportsMISCBrowserCapability(512))
            {
                VirtualList_CreateTouchBindings(objVLScroller, function (jqEvent, intClickTopOffset, intFactor, objEvent)
                {
                    /* 
                        When touch scroll is activated on the VirtualList, the virtual scroller completely covers the items area which
                        causes the items area to be unclickable.
                        So we emulate the click by getting the location of the click (or tap) on the screen and getting the correct item index according 
                        to that location.
                    */

                    // Get all items
                    var objItems = objWindow.$("#VWGVL_" + strGuid + " tr[data-vwgindex]");
                    // Calculate the relative offset of the item from its container
                    var intRelativeOffsetY = intClickTopOffset - $(objVLScroller).offset().top;
                    // Calculate the item's index
                    var intElementIndex = Math.floor(intRelativeOffsetY / intFactor);
                    // Get the correct item from items array by using the index
                    var objClickedElement = objItems[intElementIndex];

                    // invoke the element's click function
                    $(objClickedElement).click();
                }, objWindow);
            }
        }

        return objVLScroller;
    }

    return null;
}
/// </method>

/// <method name="ComboBox_GetItemHeight">
/// <summary>
/// Calculate an item height.
/// </summary>
/// <param name="objNode">The combobox node.</param>
function ComboBox_GetItemHeight(objNode)
{
    var intItemHeight = 0;

    // Validate combobox node.
    if (objNode)
    {
        intItemHeight = parseInt(Xml_GetAttribute(objNode, "Attr.ItemHeight", "18"), 10);
    }

    return intItemHeight;
}
/// </method>

/// <method name="ComboBox_GetDropDownSize">
/// <summary>
/// Calculate the drop down size.
/// </summary>
/// <param name="objNode">The combobox node.</param>
/// <param name="objElement">The the current combobox element.</param>
function ComboBox_GetDropDownSize(objNode, objElement)
{
    var objDropDownSize = null;

    // Validate recieved arguments.
    if (objNode && objElement)
    {
        // Get combobox options node.
        var objOptions = ComboBox_GetOptions(objNode, false);
        if (objOptions)
        {
            // Calculate the popup height
            var intMaxItems = parseInt(Xml_GetAttribute(objNode, "Attr.Maximum", "8"), 10);
            var intItemHeight = ComboBox_GetItemHeight(objNode);

            // Get options count.
            var intOptionsCount = objOptions.childNodes.length;

            // Claculate items count.
            var intItemsCount = intOptionsCount < intMaxItems ? intOptionsCount : intMaxItems;

            // Claculate drop down height.
            var intDropDownHeight = (intItemsCount * intItemHeight);

            // Get current combo rectangle
            var objRect = Web_GetRect(objElement);

            // Get drop down width from meta data.
            var intDropDownWidth = Xml_GetAttribute(objNode, "Attr.DropDownWidth", "");
            if (Aux_IsNullOrEmpty(intDropDownWidth))
            {
                // Calculate drop down width out of combo position.
                intDropDownWidth = objRect.right - objRect.left;
            }
            else
            {
                //Convert the drop down width to integer
                intDropDownWidth = parseInt(intDropDownWidth, 10);

                // Add width offset - if one has been provided through skin.
                var intSkinPopupWindowOffsetWidth = [Skin.PopupWindowOffsetWidth];
                if (!Aux_IsNullOrEmpty(intSkinPopupWindowOffsetWidth))
                {
                    intDropDownWidth = parseInt(intDropDownWidth, 10) + parseInt(intSkinPopupWindowOffsetWidth, 10);
                }
            }

            // Add height offset - if one has been provided through skin.
            var intSkinPopupWindowOffsetHeight = [Skin.PopupWindowOffsetHeight];
            if (!Aux_IsNullOrEmpty(intSkinPopupWindowOffsetHeight))
            {
                intDropDownHeight += parseInt(intSkinPopupWindowOffsetHeight);
            }

            // Build a drop down size.
            objDropDownSize = { Width: intDropDownWidth, Height: intDropDownHeight };
        }
    }

    // Return drop down size.
    return objDropDownSize;
}
/// </method>

/// <method name="ComboBox_CreateDropDownPopup">
/// <summary>
/// Crate a drop down popup element.
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="objNode">The the combobox node.</param>
/// <param name="objOptions">The options node.</param>
/// <param name="objDropDownSize">The drop down size</param>
function ComboBox_CreateDropDownPopup(strGuid, objNode, objOptions, objDropDownSize)
{
    var objComboBoxPopupElement = null;

    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGuid) && objNode && objOptions && objDropDownSize)
    {
        // Get popup owner id.
        var strOwnerPopupId = Popups_GetOwnerPopupId(objNode);

        // Get the options current parent.
        var objOptionsParent = objOptions.parentNode;

        // Check if the options current parent is different from the combobox node.
        if (objOptionsParent != objNode)
        {
            // Change options parent to the combobox node.
            objNode.appendChild(objOptions);
        }

        // Check whether to use animation.
        var blnUseAnimation = Xml_IsAttribute(objNode, "Attr.Animation", "1");

        // Get position rectangle
        var objRect = Popups_GetAlignedRectangle(strGuid, "B", objDropDownSize.Width, objDropDownSize.Height, 0, 0);
        if (objRect)
        {
            // Create a new options popup div.
            objComboBoxPopupElement = Popups_CreatePopup(null, strGuid, strOwnerPopupId, objRect.X, objRect.Y, objRect.Width, objRect.Height, objOptions, false, true, blnUseAnimation, ComboBox_OnDropDownClosed);
        }

        // In case that the options original parent was different from the combobox node.
        if (objOptionsParent && objOptionsParent != objNode)
        {
            // Change options parent to its original parent node.
            objOptionsParent.appendChild(objOptions);
        }
    }

    return objComboBoxPopupElement;
}
/// </method>

/// <method name="ComboBox_InvokeOpenPopup">
/// <summary>
///	
/// </summary>
function ComboBox_InvokeOpenPopup(strGuid, blnFromServer)
{
    // Get combobox node.
    var objNode = Data_GetNode(strGuid);

    // Get the relevant window.
    var objWindow = Forms_GetWindowByDataId(strGuid);

    // Validate node and window objects.
    if (objNode && objWindow)
    {
        // Set grid's selection mode.
        ComboBox_OpenPopup(strGuid, objWindow, objNode, blnFromServer);
    }
}
/// </method>

/// <method name="ComboBox_InvokeClosePopup">
/// <summary>
///	
/// </summary>
function ComboBox_InvokeClosePopup(strGuid)
{
    ComboBox_HideDropDown(strGuid);
}
/// </method>

/// <method name="ComboBox_OnDropDownClosed">
/// <summary>
/// 
/// </summary>
function ComboBox_OnDropDownClosed()
{
    // Try getting control id from popup element.
    var strControlId = Web_GetAttribute(this, "vwg_ControlId", true);
    if (!Aux_IsNullOrEmpty(strControlId))
    {
        // Get combobox node.
        var objNode = Data_GetNode(strControlId);
        if (objNode)
        {
            // Create the drop down closed event.
            var objVwgEvent = Events_CreateEvent(strControlId, "DropDownClosed", null, true);

            // Raise the drop down closed event if it is critical.
            if (Data_IsCriticalEvent(objNode, "Event.DropDownClosed", true))
            {
                Events_RaiseEvents();
                Events_ProcessClientEvent(objVwgEvent);
            }
                // Otherwise set UpdateDroppedDownOnly attribute to true.
            else
            {
                Events_SetEventAttribute(objVwgEvent, "UpdateDroppedDownOnly", true);
            }
        }
    }
}
/// </method>

/// <method name="ComboBox_OpenPopup">
/// <summary>
/// Occurs when combobox navigation is required
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="objElement">The the current combobox element.</param>
/// <param name="objWindow">The originating event window.</param>
/// <param name="objNode">The combobox data node.</param>
function ComboBox_OpenPopup(strGuid, objWindow, objNode, blnFromServer)
{
    // Validate recieved arguments.
    if (objWindow && !Aux_IsNullOrEmpty(strGuid))
    {
        // Get combobox node.
        if (!objNode)
        {
            objNode = Data_GetNode(strGuid);
        }
        if (objNode)
        {
            // Get combobox element
            var objElement = Web_GetElementByDataId(strGuid, objWindow);
            if (objElement)
            {
                // Hide other popups if there are any
                Popups_HidePopups(objElement);

                // If is a dropdown window combobox style
                if (Xml_IsAttribute(objNode, "Attr.CustomDropDown", "1"))
                {
                    // Create the drop down window event and raise it
                    var objVwgEvent = Events_CreateEvent(strGuid, "DropDownWindow", null, true);
                    Events_RaiseEvents();
                    Events_ProcessClientEvent(objVwgEvent);
                }
                else
                {
                    // If current method is not invoked from server.
                    if (!blnFromServer)
                    {
                        // Create the drop down event.
                        var objVwgEvent = Events_CreateEvent(strGuid, "DropDown", null, true);

                        // Raise the drop down event if it is critical.
                        if (Data_IsCriticalEvent(objNode, "Event.DropDown", true))
                        {
                            Events_RaiseEvents();
                            Events_ProcessClientEvent(objVwgEvent);
                            return;
                        }
                            // Otherwise set UpdateDroppedDownOnly attribute to true.
                        else
                        {
                            Events_SetEventAttribute(objVwgEvent, "UpdateDroppedDownOnly", true);
                        }
                    }

                    // Get combobox options node.
                    var objOptions = ComboBox_GetOptions(objNode, false);
                    if (objOptions)
                    {
                        // Calculate drop down size.
                        var objDropDownSize = ComboBox_GetDropDownSize(objNode, objElement);
                        if (objDropDownSize)
                        {
                            // Create dropdown popup
                            var objComboBoxPopupElement = ComboBox_CreateDropDownPopup(strGuid, objNode, objOptions, objDropDownSize);

                            // If we need the scroller
                            if (objOptions.childNodes.length > parseInt(Xml_GetAttribute(objNode, "Attr.Maximum", "8"), 10))
                            {
                                // Show the items scroller
                                ComboBox_ShowItemsScroller(strGuid, objWindow);
                            }

                            // Check whether to use animation.
                            var blnUseAnimation = Xml_IsAttribute(objNode, "Attr.Animation", "1");

                            // Get combobox value from meta data.
                            var intValue = Xml_GetAttribute(objNode, "Attr.Value", 0);

                            // Create binding and get scroller.
                            var objVLScroller = ComboBox_CreateBinding(strGuid, Xml_SelectNodes("Tags.Option", objOptions), objWindow, intValue, (blnUseAnimation ? ComboBox_GetItemHeight(objNode) : null));

                            // If popup should support animation
                            if (objComboBoxPopupElement && blnUseAnimation)
                            {
                                // Preserve the overflow behavior of the popup element.
                                var strOverflow = objComboBoxPopupElement.style.overflow;

                                // Show the combobox using animation
                                objWindow.$(objComboBoxPopupElement).slideDown("normal");

                                // Check if the overflow behavior of the popup element has changed due to animation.
                                if (objComboBoxPopupElement.style.overflow != strOverflow)
                                {
                                    // Change the overflow behavior of the popup element back to what it was before animation.
                                    objComboBoxPopupElement.style.overflow = strOverflow;
                                }
                            }

                            //Move the scroller to the selected item position.
                            VirtualList_NavigateToPosition(objVLScroller, intValue, objWindow);
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="ComboBox_TextBoxBlur">
/// <summary>
/// Occurs on combobox textbox blur event
/// </summary>
/// <param name="strGuid">The combobox guid.</param>
/// <param name="strValue">The current combobox value.</param>
/// <param name="objWindow">The originating event.</param>
function ComboBox_TextBoxBlur(strGuid, strValue, objWindow)
{
    ComboBox_FireTextChange(strGuid, strValue, objWindow);
}
/// </method>

/// <method name="ComboBox_OnFocus">
/// <summary>
/// Occurs on combobox focus event
/// </summary>
/// <param name="objElement">The the current combobox element.</param>
function ComboBox_OnFocus(objElement)
{
    if (objElement)
    {
        //Select the text in the input
        Web_SetInputSelection(objElement);
    }
}
/// </method>