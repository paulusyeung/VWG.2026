
function CheckBox_Click(strGuid,objWindow,objEvent)
{
    CheckBox_Change(strGuid,objWindow,objEvent);
}


/// <method name="CheckBox_KeyDown">
/// <summary>
///
/// </summary>
/// <param name="strGuid">The check box guid.</param>
/// <param name="objElement"></param>
/// <param name="objWindow"></param>
function CheckBox_KeyDown(strGuid,objWindow,objEvent)
{
	// Get the pressed key	
	var intKeyCode = objEvent.keyCode;
	
	//When space key was pressed
	if(intKeyCode == mcntSpaceKey)
	{		
	    // Chance the check value
		CheckBox_Change(strGuid,objWindow,objEvent);
		
		// Cancel the event bubbling
        Web_EventCancelBubble(objEvent); 
	}    
}
/// </method>




/// <method name="CheckBox_Change">
/// <summary>
///
/// </summary>
/// <param name="strGuid">The check box guid.</param>
/// <param name="objElement"></param>
function CheckBox_Change(strGuid, objWindow, objEvent, intHorizonPos)
{
    // check if control	is disabled.
    if (Data_IsDisabled(strGuid)) return;

    // Get the check box element.
    var objCheckBoxElement = Web_GetElementByDataId(strGuid, objWindow);

    // Validate check box element.
    if (!objCheckBoxElement) return;

    // Get appearance value.
    var strAppearance = Web_GetAttribute(objCheckBoxElement, "vwgappearance", true);

    // Get the checkbox data node
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        // Check if auto chech is not disabled
        if (Xml_IsAttribute(objNode, "Attr.AutoCheck", "0"))
        {
            return;
        }

        // Get a flag indicating if we are in three state mode
        var blnThreeState = Xml_IsAttribute(objNode, "Attr.Mode", "3");

        // Get the current checked state
        var strOldCheckState = Xml_GetAttribute(objNode, "Attr.Checked", "0");

        // Calculate the new state mode
        var strNewCheckState;

        // If is unchecked
        if (strOldCheckState == "0")
        {
            strNewCheckState = "1";
        }
            // If is checked
        else if (strOldCheckState == "1")
        {
            // If is in three stare mode
            if (blnThreeState)
            {
                strNewCheckState = "2";
            }
            else
            {
                strNewCheckState = "0";
            }
        }
        else
        {
            // Uncheck state
            strNewCheckState = "0";
        }

        var blnIsButton = strAppearance == "1";

        var objSource = null;

        // Update data behind
        Data_SetNodeAttribute(objNode, "Attr.Checked", strNewCheckState);

        if (blnIsButton)
        {
            Controls_RedrawControlByNode(objWindow, objNode, false);
            objSource = Web_GetElementByDataId(strGuid);
        }
        else
        {
            // If found the check image
            var objElement = Web_GetElementById("TRG_" + strGuid, objWindow);
            if (objElement)
            {
                // Set the state image
                Web_ReplaceBackgroundImage(objElement, strOldCheckState + ".gif", strNewCheckState + ".gif");
            }
        }

        // Raise event
        CheckBox_ValueChange(strGuid, objNode, strNewCheckState, objWindow, objEvent, objSource);
    }
}
/// </method>


/// <method name="CheckBox_ValueChange">
/// <summary>
/// Update data and raise event.
/// </summary>
/// <param name="strGuid">The checkbox guid.</param>
/// <param name="objNode">The checkbox data node.</param>
/// <param name="strNewCheckState">The checkbox new check state.</param>
/// <param name="objWindow">The originating event window.</param>
/// <param name="objEvent">The event to process.</param>
/// <param name="objSource">The checkbox source element(when needed).</param>
function CheckBox_ValueChange(strGuid, objNode, strNewCheckState, objWindow, objEvent, objSource)
{
    // Create event and raise if critical
    var objVWGEvent = Events_CreateTraceableEvent(objWindow, objEvent, strGuid, "ValueChange", null, true);

    // Set the checked value
    Events_SetEventAttribute(objVWGEvent, "Attr.Checked", strNewCheckState);

    // If click sholud be bubbled and value change is critical - raise events through click handling.
    if (Data_IsCriticalEvent(objNode, "Event.ValueChange", true))
    {
        // Handles the click event and forces raise (this 'overload' cancels the click bubble.
        Web_OnClick(objEvent, objWindow, true, objSource);
    }

    Events_ProcessClientEvent(objVwgEvent);
}
/// </method>

/// <method name="CheckBox_TouchStart">
/// <summary>
/// Handles checkbox touchstart.
/// </summary>
/// <param name="strGuid">The check box guid.</param>
function CheckBox_TouchStart(objElement, strGuid, objWindow, objEvent)
{	
	Web_SetStyle(objElement, 'touchstart', objWindow, objEvent);
}

/// <method name="CheckBox_TouchEnd">
/// <summary>
/// Handles checkbox end.
/// </summary>
/// <param name="strGuid">The check box guid.</param>
function CheckBox_TouchEnd(objElement, strGuid, objWindow, objEvent)
{	
	Web_SetStyle(objElement, 'touchend', objWindow, objEvent);

	//getting the div state image Element
	var objStateImageElement = Web_GetElementById("TRG_" + strGuid, objWindow);

	var intBackgroundHorizonPos = null;
	if (Web_GetAttribute(objStateImageElement, "vwg_backgroundhorizonpos", true) != null)
	{
		intBackgroundHorizonPos = Number(Web_GetAttribute(objStateImageElement, "vwg_backgroundhorizonpos", true));

		Data_RemoveNodeAttribute(objStateImageElement, "vwg_backgroundhorizonpos");
		objStateImageElement.style.removeProperty("background-position");
	}

	CheckBox_Change(strGuid, objWindow, objEvent, intBackgroundHorizonPos);
}


/// <method name="CheckBox_TouchMove">
/// <summary>
/// Handles checkbox touch move.
/// </summary>
/// <param name="strGuid">The check box guid.</param>
function CheckBox_TouchMove(objElement, strGuid, objWindow, objEvent, intTotalWidth)
{	
	if (objEvent.touches.length == 1)
	{ // Only deal with one finger
		var touch = objEvent.touches[0]; // Get the information for finger #1

		//getting the div state image Element
		var objStateImageElement = Web_GetElementById("TRG_" + strGuid, objWindow);
		var intX = 0;

		//checking for the element's position
		if (Web_GetAttribute(objStateImageElement, "vwg_backgroundpos", true) == null)
		{
			var objStateImageElementTemp = objStateImageElement;
			var intX = objStateImageElementTemp.offsetLeft;
			while (objStateImageElementTemp != null)
			{
				intX += objStateImageElementTemp.offsetLeft;
				objStateImageElementTemp = objStateImageElementTemp.offsetParent;
			}

			Web_SetAttribute(objStateImageElement, "vwg_backgroundpos", intX);
		}
		else
		{
			intX = Number(Web_GetAttribute(objStateImageElement, "vwg_backgroundpos", true));
		}

		//enabling the movement only of the touch made in the state image element
		if (touch.pageX >= intX && touch.pageX <= (intX + intTotalWidth))
		{
			var intBackgroundHorizonPos = (objStateImageElement.className.indexOf("_Checked") > -1) ? 0 : ((objStateImageElement.className.indexOf("_Indeterminate") > -1) ? 50 : 100);

			intBackgroundHorizonPos = 100 - Math.max((touch.pageX - intX) * 100 / intTotalWidth, 0).toFixed();
			objStateImageElement.style.backgroundPosition = intBackgroundHorizonPos + '% 0%';

			Web_SetAttribute(objStateImageElement, "vwg_backgroundhorizonpos", intBackgroundHorizonPos);
		}
	}
}