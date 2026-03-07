/// <summary>
/// Provides IE tracking of the active window which 
/// can be used for setTimeout or XMLHttp request.
/// </summary>
var mobjActiveWindow = window;

/// <method name="Web_SetActiveWindow">
/// <summary>
/// Sets the current active window which can be used for setTimeout or XMLHttp request
/// </summary>
/// <param name="objWindow">The window to active (IHTMLWindow).</param>
function Web_SetActiveWindow(objWindow)
{
    // Ensure valid active window and set it
	mobjActiveWindow = objWindow ? objWindow : window;
}
/// </method>

/// <method name="Web_GetActiveWindow">
/// <summary>
/// Gets the current active window which can be used for setTimeout or XMLHttp request
/// </summary>
function Web_GetActiveWindow()
{
    // Ensure the active window is valid
    if(!mobjActiveWindow)
    {
        mobjActiveWindow = window;
    }
    return mobjActiveWindow;
}
/// </method>

/// <method name="Web_RemoveActiveDialogWindow">
/// <summary>
/// Removes the active window for event handlings.
/// </summary>
/// <param name="objWindow">The window to set inactive.</param>
function Web_RemoveActiveDialogWindow(objWindow)
{
    // Check that loading is not active.
	if(!mblnLoadingIsActive)
	{
	    // Check if recieved window is the active window.
	    if(objWindow==Web_GetActiveWindow())
	    {
	        // Get dialog's window id.
	        var strWindowId = objWindow.mstrWindowGuid;
	        if(!Aux_IsNullOrEmpty(strWindowId))
	        {
                // Get next real window from cache.
                var objActiveWindow = Forms_GetActivatedWindow(Web_GetWebId(strWindowId));

                // Activate next real window.
                Web_SetActiveWindow(objActiveWindow);

                // Re-initialize popup window to the new active window.
                Popups_Initialize(objActiveWindow);
            }
        }
	}
}
/// </method>

/// <method name="Web_SetActive">
/// <summary>
/// Activate a given element
/// </summary>
function Web_SetActive(objElement)
{
    // Validate element.
    if(objElement)
    {   
        // Check if the setActive function exists.
        if(objElement.setActive)
        {            
            objElement.setActive();
        }
    }
}
/// </method>

/// <method name="Web_ClearIFramesSource">
/// <summary>
/// 
/// </summary>
/// <param name="objIFrames">The IFrames collection.</param>
function Web_ClearIFramesSource(objIFrames)
{
    if (objIFrames && objIFrames.length > 0)
    {
        for (var intIndex = 0; intIndex < objIFrames.length; intIndex++)
        {
            objIFrames[intIndex].src = "";
        }
    }
}
/// </method>

/// <method name="Web_SetMouseEnterLeaveEvents">
/// <summary>
/// 
/// </summary>
function Web_SetMouseEnterLeaveEvents(objElement, strHandler, objWindow, objExtraParams)
{
    objElement.onmouseenter = function (objEvent)
    {
        if (typeof mobjApp[strHandler] === "function")
        {
            mobjApp[strHandler](objElement, 'mouseenter', objWindow, objEvent, objExtraParams);
        }
    };
    objElement.onmouseleave = function (objEvent)
    {
        if (typeof mobjApp[strHandler] === "function")
        {
            mobjApp[strHandler](objElement, 'mouseleave', objWindow, objEvent, objExtraParams);
        }
    };
}
/// </method>
