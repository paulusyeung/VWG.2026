/// <method name="Drag_CoverIFrameElements">
/// <summary>
/// 
/// </summary>
/// <param name="objWindow"></param>
function Drag_CoverIFrameElements(objWindow)
{
}	        
/// </method>

/// <method name="Drag_UnCoverIFrameElements">
/// <summary>
/// 
/// </summary>
function Drag_UnCoverIFrameElements()
{
}
/// </method>

/// <method name="Web_SetCapture">
/// <summary>
/// Captures all mouse events to this element
/// </summary>
/// <param name="objElement">The element to capture events to.</param>
function Web_SetCapture(objElement)
{
    if (objElement && objElement.setCapture)
    {
        objElement.setCapture();
    }
}
/// </method>

/// <method name="Web_ReleaseCapture">
/// <summary>
/// Releases event capturing
/// </summary>
/// <param name="objElement">The element to release capture from.</param>
function Web_ReleaseCapture(objElement)
{
    if (objElement && objElement.releaseCapture)
    {
        objElement.releaseCapture();
    }
}
/// </method>