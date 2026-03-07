/// <method name="Forms_OpenLink">
/// <summary>
/// Opens a link.
/// </summary>
function Forms_OpenLink(strUrl,strName,strParams,strArguments,strMode)
{	
	// Get active window
	var objWindow = Web_GetActiveWindow();
	
	switch(strMode)
	{
		case "ModalWindow":
			objWindow.showModalDialog(strUrl,null,strParams);
			break;
		case "ModalessWindow":
			objWindow.showModelessDialog(strUrl,null,strParams);
			break;
		default:
		    if(Aux_IsNullOrEmpty(strArguments))
		    {
			    window.open(strUrl,strName,strParams);
			}
			else
			{
			    Web_SubmitForm(Web_CreateForm(strUrl,strName,strArguments));		
			}
			break;
	}
}
/// </method>

/// <method name="Forms_GetWindow">
/// <summary>
/// Gets a browser window object from a window or an element.
/// </summary>
/// <param name="objWindow">The window object or the window element.</param>
function Forms_GetWindow(objWindow)
{
    if (!mblnInlineWindows)
    {
        return objWindow;
    }

	return window;
}
/// </method>

/// <method name="Forms_FormResized">
/// <summary>
/// Handle form resizing
/// </summary>
function Forms_FormResized(objElement)
{
    // Flags for knowing if the height or widths have been changed to the minimum width/height attributes
    var blnHeightChanged = false;
    var blnWidthChanged = false;

    // Get the element's current height/width
    var intHeight = Layout_GetHeight(objElement);
    var intWidth = Layout_GetWidth(objElement);

    // Get the element Minimum/Maximum Height/Widht
    var intMinimumHeight = parseInt(objElement.vwgminimumheight);
    var intMinimumWidth = parseInt(objElement.vwgminimumwidth);
    var intMaximumHeight = parseInt(objElement.vwgmaximumheight);
    var intMaximumWidth = parseInt(objElement.vwgmaximumwidth);

    // Keep a referance to the element's style
    var objStyle = null;
    var objStyleWidth = null;
    var objStyleHeight = null;

    var objContainerElement = Web_GetContextElementByAttribute(objElement, "vwgtype", "container",true);

    if (objContainerElement)
    {
        objStyle = objContainerElement.style;
        objStyleHeight = objStyle.height;
        objStyleWidth = objStyle.width;
    }

    if (objStyle)
    {
        // Check that the height exists
        if (!isNaN(intHeight))
        {
            // Check that the Minimum height exists
            if (!isNaN(intMinimumHeight))
            {
                // Check if the current height is less than the minimum height
                if (intHeight < intMinimumHeight)
                {
                    var strNewHeight = intMinimumHeight + "px";
                    if (strNewHeight != objStyleHeight)
                    {
                        // Assign the minimum height
                        objStyle.height = strNewHeight;
                    }
                    // Flag that the height was changed
                    blnHeightChanged = true;
                }
            }

            // Check that the Maximum height exists
            if (!isNaN(intMaximumHeight))
            {
                if (intHeight > intMaximumHeight)
                {
                    var strNewHeight = intMaximumHeight + "px";
                    if (strNewHeight != objStyleHeight)
                    {
                        // Assign the maximum height
                        objStyle.height = strNewHeight;
                    }

                    // Flag that the height was changed
                    blnHeightChanged = true;
                }
            }
        }

        // Check that the width exists
        if (!isNaN(intWidth))
        {
            if (!isNaN(intMinimumWidth))
            {
                if (intWidth < intMinimumWidth)
                {
                    var strNewWidth = intMinimumWidth + "px";
                    if (strNewWidth != objStyleWidth)
                    {
                        // Assign the minimum width
                        objStyle.width = strNewWidth;
                    }

                    blnWidthChanged = true;
                }
            }

            if (!isNaN(intMaximumWidth))
            {
                if (intWidth > intMaximumWidth)
                {
                    var strNewWidth = intMaximumWidth + "px";
                    if (strNewWidth != objStyleWidth)
                    {
                        // Assign the maximum width
                        objStyle.width = strNewWidth;
                    }
                    blnWidthChanged = true;
                }
            }
        }

        // If width flag was not set, Set the element's width to 100%
        if (!blnWidthChanged)
        {
            if (objStyle.width != "100%")
            {
                objStyle.width = "100%";
            }
        }
        // If height flag was not set, Set the element's height to 100%
        if (!blnHeightChanged)
        {
            if (objStyle.height != "100%")
            {
                objStyle.height = "100%";
            }
        }
    }    
}
/// </method>