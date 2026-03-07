var arrCaptureEvents = ["click", "mousedown", "mouseup", "mousemove", "mouseover", "mouseout"];
/// <method name="Web_SetCapture">
/// <summary>
/// Captures all mouse events to this element
/// </summary>
/// <param name="objElement">The element to capture events to.</param>
function Web_SetCapture(objElement)
{
    // Create capture events array
    var blnIsCapturing = false;

    objElement.fncCaptureFunction = function (objEvent)
    {
        // If flag is true return
        if (!blnIsCapturing)
        {
            // Set true flag
            blnIsCapturing = true;

            // Cancel bubble.
            Web_EventCancelBubble(objEvent);

            // The objEvent.relatedTarget might have access restriction in cases like scroller elements 
            // and therefore we have to defend these following calls.
            try
            {
                // Create event object
                var objMouseEvents = document.createEvent("MouseEvents");

                // Initialize event
                objMouseEvents.initMouseEvent(objEvent.type,
                        objEvent.bubbles, objEvent.cancelable, objEvent.view, objEvent.detail,
                        objEvent.screenX, objEvent.screenY, objEvent.clientX, objEvent.clientY,
                        objEvent.ctrlKey, objEvent.altKey, objEvent.shiftKey, objEvent.metaKey,
                        objEvent.button, objEvent.relatedTarget);

                // Dispatch event.
                objElement.dispatchEvent(objMouseEvents);
            }
            catch (objException) { }

            // Set false flag
            blnIsCapturing = false;
        }
    };

    // Capture all events to method
    for (var intIndex = 0; intIndex < arrCaptureEvents.length; intIndex++)
    {
        // Exclusivly attaching event to window.
        window.addEventListener(arrCaptureEvents[intIndex], objElement.fncCaptureFunction, true);
    }
}

/// <method name="Web_ReleaseCapture">
/// <summary>
/// Releases event capturing
/// </summary>
/// <param name="objElement">The element to release capture from.</param>
function Web_ReleaseCapture(objElement)
{
    // Release capture all events from method
    for (var intIndex = 0; intIndex < arrCaptureEvents.length; intIndex++)
    {
        // Exclusivly removing event to window.
        window.removeEventListener(arrCaptureEvents[intIndex], objElement.fncCaptureFunction, true);
    }

    // Destroy method
    objElement.fncCaptureFunction = null; 
}
/// </method> 

/// <method name="Drag_CreateIFrameCover">
/// <summary>
/// 
/// </summary>
function Drag_CreateIFrameCover(objIFrame,objWindow)
{   
    // Validate recieved parameters.
    if (objIFrame && Web_IsWindow(objWindow))
    {
        // Get the drag iframe cover box.
        var objIFrameCoverBoxElement = Web_GetElementById("VWG_DragIFrameCoverBox",objWindow);
        if(objIFrameCoverBoxElement)
        {
            // Get iframe rectangle.
            var objIFrameRect = Web_GetRect(objIFrame);
            if(objIFrameRect)
            {        
                // Create a new cover div element.
	            var objIFrameCover = objWindow.document.createElement("DIV");
        	    
	            // Set new cover div's location.
	            objIFrameCover.style.top = objIFrameRect.top + "px";
	            objIFrameCover.style.left = objIFrameRect.left + "px";

                // Set new cover div's size.
	            objIFrameCover.style.width = (objIFrameRect.right - objIFrameRect.left) + "px";
	            objIFrameCover.style.height = (objIFrameRect.bottom - objIFrameRect.top) + "px";
        	    
	            // Set new cover div's class name.
	            objIFrameCover.className = "Common-IFrameCover";
        	    
	            // Add new cover div's to the recieved iframe's parent.
	            $(objIFrameCoverBoxElement).append(objIFrameCover);
	        }
	    }
	}
}
/// </method>

/// <method name="Drag_CoverIFrameElements">
/// <summary>
/// 
/// </summary>
/// <param name="objWindow"></param>
function Drag_CoverIFrameElements(objWindow)
{
    // Validate recieved window.
    if(Web_IsWindow(objWindow))
    {
        // Get iframe elements from the received window.
        var arrIframs = Web_GetWebElementsByTagName('IFRAME',objWindow);
        if(arrIframs && arrIframs.length>0)
        {
            // Run over all iframes.
            for(var i=0; i<arrIframs.length; i++)
            {
                // Create an iframe cover.
                Drag_CreateIFrameCover(arrIframs[i],objWindow);
            }
        }
    }
}	        
/// </method>

/// <method name="Drag_UnCoverIFrameElements">
/// <summary>
/// 
/// </summary>
function Drag_UnCoverIFrameElements()
{
    // Validate drag window.
    if(Web_IsWindow(mobjDragWindow))
    {
        // Get the drag iframe cover box.
        var objIFrameCoverBoxElement = Web_GetElementById("VWG_DragIFrameCoverBox",mobjDragWindow);
        if(objIFrameCoverBoxElement)
        {
            // Get iframe cover box element child count.
            var intCoverBoxChildCount = objIFrameCoverBoxElement.childNodes.length;
            
            // Loop all childs.
            for(var intCover=0; intCover<intCoverBoxChildCount; intCover++)
            {
                // Remove current child.
                objIFrameCoverBoxElement.removeChild(objIFrameCoverBoxElement.childNodes[intCover]);
            }
        }
    }
}
/// </method>