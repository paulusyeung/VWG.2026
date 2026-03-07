/// <method name="Web_SetActiveWindow">
/// <summary>
/// Sets the current active window which can be used for setTimeout or XMLHttp request
/// </summary>
/// <param name="objWindow">The window to active (IHTMLWindow).</param>
function Web_SetActiveWindow(objWindow)
{

}
/// </method>


/// <method name="Web_GetActiveWindow">
/// <summary>
/// Gets the current active window which can be used for setTimeout or XMLHttp request
/// </summary>
function Web_GetActiveWindow()
{
    return window;
}
/// </method>

/// <method name="Web_SetActive">
/// <summary>
/// Activate a given element
/// </summary>
function Web_SetActive(objElement)
{
}
/// </method>

/// <method name="Web_SetMouseEnterLeaveEvents">
/// <summary>
/// 
/// </summary>
function Web_SetMouseEnterLeaveEvents(objElement, strHandler, objWindow, objExtraParams)
{
    objElement.onmouseover = function (objEvent)
    {
        Common_OnMouseOver(strHandler, this, objWindow, objEvent, objExtraParams);
    };
    objElement.onmouseout = function (objEvent)
    {
        Common_OnMouseOut(strHandler, objElement, objWindow, objEvent, objExtraParams);
    };
}
/// </method>
