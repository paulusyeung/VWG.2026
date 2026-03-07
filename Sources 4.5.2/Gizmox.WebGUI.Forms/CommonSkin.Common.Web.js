/// <page name="Web.js">
/// <summary>
/// General scripts for web stuff handling.
/// </summary>


var Web = {};
                                              
var mcntKeysAlt             = 262144;
var mcntKeysControl         = 131072;
var mcntKeysShift           = 65536;

var mcntRightKey			= 39;
var mcntLeftKey				= 37;
var mcntDownKey				= 40;
var mcntUpKey				= 38;
var mcntEscapeKey			= 27;
var mcntEnterKey			= 13;
var mcntDeleteKey			= 46;
var mcntPageUpKey           = 33;
var mcntPageDownKey         = 34;
var mcntHomeKey				= 36;
var mcntEndKey				= 35;
var mcntTabKey				= 9;
var mcntBackspaceKey		= 8;
var mcntShiftKey			= 16;
var mcntCtrlKey 			= 17;
var mcntAltKey	    		= 18;
var mcntSpaceKey			= 32;
var mcntHelpKey			    = 112;
var mcntPlusKey			    = 107;
var mcntMinusKey1			= 189;
var mcntMinusKey2			= 109;
var mcntPointKey1           = 190;
var mcntPointKey2           = 110;
var mcntF1Key               = 112;
var mcntF2Key               = 113;
var mcntF3Key               = 114;
var mcntF4Key               = 115;
var mcntF5Key               = 116;
var mcntF6Key               = 117;
var mcntF7Key               = 118;
var mcntF8Key               = 119;
var mcntF9Key               = 120;
var mcntF10Key              = 121;
var mcntF11Key              = 122;
var mcntF12Key              = 123;
var mcntEqualKey			= 187;

var mcntKeyFilterAll        = 0x00;
var mcntKeyFilterAlt        = 0x01;
var mcntKeyFilterControl    = 0x02;
var mcntKeyFilterDelete     = 0x04;
var mcntKeyFilterDown       = 0x08;
var mcntKeyFilterEnd        = 0x10;
var mcntKeyFilterEscape     = 0x20;
var mcntKeyFilterF1         = 0x40;
var mcntKeyFilterF2         = 0x80;
var mcntKeyFilterF3         = 0x100;
var mcntKeyFilterF4         = 0x200;
var mcntKeyFilterF5         = 0x400;
var mcntKeyFilterF6         = 0x800;
var mcntKeyFilterF7         = 0x1000;
var mcntKeyFilterF8         = 0x2000;
var mcntKeyFilterF9         = 0x4000;
var mcntKeyFilterF10        = 0x8000;
var mcntKeyFilterF11        = 0x10000;
var mcntKeyFilterF12        = 0x20000;
var mcntKeyFilterHome       = 0x40000;
var mcntKeyFilterInsert     = 0x80000;
var mcntKeyFilterLeft       = 0x100000;
var mcntKeyFilterNext       = 0x200000;
var mcntKeyFilterPageDown   = 0x400000;
var mcntKeyFilterPageUp     = 0x800000;
var mcntKeyFilterRight      = 0x1000000;
var mcntKeyFilterShift      = 0x2000000;
var mcntKeyFilterTab        = 0x4000000;
var mcntKeyFilterUp         = 0x8000000;
var mcntKeyFilterPrior      = 0x10000000;
var mcntKeyFilterEnter      = 0x20000000;

/// <summary>
/// Maximum interval between the first and the last click of the double click
/// </summary>
var mcntDoubleClickInterval = 280;

/// <summary>
/// An html scroller width / height.
/// </summary>
var mcntScrollerSize = 17;

/// <summary>
/// The web log window to write to
/// </summary>
var mobjScrollingInterval   = null;

/// <summary>
/// Determines if Shortcut Disable
/// </summary>
 var mblnEnableClientShortcuts = "Context.EnableClientShortcuts"=="1";

/// <summary>
/// Determines if request should contain content type header.
/// </summary> 
 var mblnAppendRequestContentTypeHeader = "Context.AppendRequestContentTypeHeader"=="1";

/// <summary>
/// A refference to the taskbar box.
/// </summary>
var mobjTaskBarBox = null;

/// <summary>
/// Preserve focus element.
/// </summary>
 var mblnPreserveFocusElement = "Context.PreserveFocusElement"=="1";

/// <summary>
/// Preserve keys modifier.
/// </summary>
var mintModifierKeys = 0;

/// <summary>
/// Preserve cursor position.
/// </summary>
var mobjCursorPosition = null;

/// <summary>
/// Browser capabilities variables.
/// </summary>
var mintBrowserCapabilities_MISC = Number("Context.MISCBrowserCapabilities");
var mintBrowserCapabilities_CSS3  = Number("Context.CSS3BrowserCapabilities");		
var mintBrowserCapabilities_HTML5 = Number("Context.HTML5BrowserCapabilities");		

/// <method name="Web_OnMouseMove">
/// <summary>
/// Handles mouse move event.
/// </summary>
function Web_OnMouseMove(objEvent)
{
	 Web_PreserveMouseCursorPosition(objEvent);      
}
/// </method>

/// <method name="Web_PreserveMouseCursorPosition">
/// <summary>
/// Preserves cursor position coordinates.
/// </summary>
function Web_PreserveMouseCursorPosition(objEvent)
{
	if(objEvent)
	{
		// Reset cursor position.
		Web_ClearMouseCursorPosition();
		mobjCursorPosition = {X:objEvent.clientX,Y:objEvent.clientY};
	}
}

/// <method name="Web_ClearMouseCursorPosition">
/// <summary>
/// Clears mouse cursor saved coordinates.
/// </summary>
function Web_ClearMouseCursorPosition()
{
	mobjCursorPosition = null;
	
}

/// <method name="Web_GetMouseCursorPosition">
/// <summary>
/// Gets mouse cursor coordinates.
/// </summary>
function Web_GetMouseCursorPosition()
{
	return mobjCursorPosition;
}

/// <method name="Web_GetDaylightSavingTimeOffset">
/// <summary>
/// Return the daylight saving time offset
/// </summary>
function Web_GetDaylightSavingTimeOffset(objDate) 
{
    // Initialize the daylight saving time offset variable.
    var intDaylightSavingTimeOffset = 0;
    
    // Get the year of the recieved date.
    var intYear = objDate.getFullYear();
    
    // Create a january date object.
    var objJanuary = new Date(intYear, 0, 1, 0, 0, 0, 0);
    
    // Create a july date object.
    var objJuly = new Date(intYear, 6, 1, 0, 0, 0, 0);   
 
    // Calculate the time offset of january from UTC.
    var intJanauaryTimeOffset = objJanuary.getTimezoneOffset();
    
    // Calculate the time offset of july from UTC.
    var intJulyTimeOffset = objJuly.getTimezoneOffset();

    // Check if daylight savings are being saved on this machine.
    if (intJanauaryTimeOffset != intJulyTimeOffset) 
    {
        // Check if the recievd date's offset equals to July's offset.
	    if(objDate.getTimezoneOffset() == intJulyTimeOffset)
        {
            intDaylightSavingTimeOffset = (intJulyTimeOffset-intJanauaryTimeOffset);
        }
    }

    // Return the daylight saving time offset variable.
    return (intDaylightSavingTimeOffset * -60000);
}
/// </method>


/// <method name="Web_SetInterval" access="private">
/// <summary>
/// Sets an interval to activate the received code.
/// </summary>
function Web_SetInterval(objCode,intTime, objWindow)
{      	
    if(!objWindow)
    {
        objWindow = Web_GetActiveWindow();
    }
	
	return objWindow.setInterval(objCode,intTime);
}
/// </method>

/// <method name="Web_ClearInterval" access="private">
/// <summary>
/// Clears the interval which activates a code.
/// </summary>
/// <param name="objInterval">The interval object to be clean.</param>
function Web_ClearInterval(objInterval, objWindow)
{      	
    if(!objWindow)
    {
        objWindow = Web_GetActiveWindow();
    }
    
	objWindow.clearInterval(objInterval);
}
/// </method>


/// <method name="Web_StartScroll">
/// <summary>
///
/// </summary>
/// <param name="objElement">The scrollable element.</param>
/// <param name="intPixelsToScroll">The amount of pixels to scroll.</param>
/// <param name="intIntervalTime">The amount of milliseconds to interval the scrolling.</param>
/// <param name="intOrientation">The scrolling orientation - 0 for vertical and 1 for horizontal</param>
function Web_StartScroll(objElement,intPixelsToScroll,intIntervalTime,intOrientation)
{
    if(objElement)
    {
        // Clear previous scrolling interval.
        Web_ClearInterval(mobjScrollingInterval);
        
        // Vertical scrolling.
        if(intOrientation == 0)
        {
            mobjScrollingInterval = Web_SetInterval("$$('" + objElement.id + "').scrollTop += " + intPixelsToScroll + ";",intIntervalTime);
        }
        
        // Horizontal scrolling.
        else if(intOrientation == 1)
        {
            mobjScrollingInterval = Web_SetInterval("$$('" + objElement.id + "').scrollLeft += " + intPixelsToScroll + ";",intIntervalTime);
        }
    }
}
/// </method>


/// <method name="Web_StopScroll">
/// <summary>
/// Stop the received element from interval scrolling.
/// </summary>
/// <param name="objElement">The scrollable element.</param>
function Web_StopScroll(objElement)
{
    // Clear previous scrolling interval.
    Web_ClearInterval(mobjScrollingInterval);
}
/// </method>


/// <method name="Web_AttachEvents" access="private">
/// <summary>
/// Attaches doccument events to engine.
/// </summary>
function Web_AttachEvents(objDocument)
{
}
/// </method>

/// <method name="Web_SetTimeout" access="private">
/// <summary>
/// Sets a timeout to cativate a code.
/// </summary>
/// <param name="objWindow">Preserved for special cases when specific window execution is required (do not use the param if not absolutly neccessary).</param>
function Web_SetTimeout(objCode,intTime, objWindow)
{
    // Get active window for non specific invocation
    if(!objWindow)
    {
        objWindow = Web_GetActiveWindow();
    }
    
    // Set the timeout on the desired window
    return objWindow.setTimeout(objCode,intTime);
}
/// </method>

/// <method name="Web_ClearTimeout" access="private">
/// <summary>
/// Clears the timeout which activates a code.
/// </summary>
/// <param name="objWindow">Preserved for special cases when specific window execution is required (do not use the param if not absolutly neccessary).</param>
function Web_ClearTimeout(intTimeout, objWindow)
{      	
    // Get active window for non specific invocation
    if(!objWindow)
    {
        objWindow = Web_GetActiveWindow();
    }
    
	// Clear the timeout in the specified window
    objWindow.clearTimeout(intTimeout);   
}
/// </method>

/// <method name="Web_DeAttachEvents" access="private">
/// <summary>
/// Deattaches doccument events from engine.
/// </summary>
function Web_OnError(strMsg,strUrl,strLine)
{
   return !mblnDebugMode;
}
/// </method>

/// <method name="Web_DeAttachEvents" access="private">
/// <summary>
/// Deattaches doccument events from engine.
/// </summary>
function Web_DeAttachEvents(objDocument)
{
	objDocument.onselectstart	= null;
	objDocument.oncontextmenu	= null;
	objDocument.onkeydown		= null;
	objDocument.onblur			= null;
}
/// </method>

var mobjDragSource = null;

/// <method name="Web_IsMoveDragType">
/// <summary>
///
/// </summary>
/// <param name="intDragType"></param>
function Web_IsMoveDragType(intDragType)
{
    return (intDragType==mcntDragMoveFree)||((intDragType==mcntDragMoveVert)||(intDragType==mcntDragMoveHorz));
}
/// </method>

/// <method name="Web_IsResizeDragType">
/// <summary>
///
/// </summary>
/// <param name="intDragType"></param>
function Web_IsResizeDragType(intDragType)
{
    return intDragType==mcntDragResizeTop || intDragType==mcntDragResizeTopRight || intDragType==mcntDragResizeTopLeft || intDragType==mcntDragResizeBottom || intDragType==mcntDragResizeBottomRight || intDragType==mcntDragResizeBottomLeft || intDragType==mcntDragResizeRight || intDragType==mcntDragResizeLeft;
}
/// </method>

/// <method name="Web_GetDragType">
/// <summary>
///
/// </summary>
/// <param name="objSource"></param>
function Web_GetDragType(objSource)
{
	// Initialize drag typeobjSource
	var intDragType = -1;
	
	// Get drag type marker
	var strDragType = Web_GetAttribute(objSource,"vwgdrag");
	
	// Get drag type
	switch(strDragType)
	{
		case "m":intDragType=mcntDragMoveFree;break;
		case "mv":intDragType=mcntDragMoveVert;break;
		case "mh":intDragType=mcntDragMoveHorz;break;
		case "rt":intDragType=mcntDragResizeTop;break;
		case "rtr":intDragType=mcntDragResizeTopRight;break;
		case "rtl":intDragType=mcntDragResizeTopLeft;break;
		case "rl":intDragType=mcntDragResizeLeft;break;
		case "rr":intDragType=mcntDragResizeRight;break;
		case "rb":intDragType=mcntDragResizeBottom;break;
		case "rbr":intDragType=mcntDragResizeBottomRight;break;
		case "rbl":intDragType=mcntDragResizeBottomLeft;break;
	}
	
	return intDragType;
}
/// </method>

/// <method name="Web_GetEventOffset">
/// <summary>
/// 
/// </summary>
function Web_GetEventOffset(objEvent)
{
	return {X:Web_GetEventOffsetX(objEvent),Y:Web_GetEventOffsetY(objEvent)};
}
/// </method>

/// <method name="Web_GetAbsoluteUrl">
/// <summary>
/// 
/// </summary>
function Web_GetAbsoluteUrl(strRelativeURL)
{
	return mstrBaseURL+strRelativeURL;
}
/// </method>

/// <method name="Web_HandleKeyCaptures">
/// <summary>
///
/// </summary>
/// <param name="objEvent">The event object.</param>
/// <param name="intCaptures">The bitmask captures</param>
/// <param name="objWindow">The window of the event source.</param>
function Web_HandleKeyCaptures(objEvent, intCaptures, objWindow)
{
    // Flag indicating if to capture event. Check if the event capture is set for ALL types of keys.
    var blnCapture = (intCaptures & 65536) > 0;

    if(!blnCapture)
    {
        // Get the event key code
        var intKeyCode = Web_GetEventKeyCode(objEvent);

        // Switch key code
        switch(intKeyCode)
        {        
            case mcntUpKey:         blnCapture = ((intCaptures & 4) > 0); break;
            case mcntDownKey:       blnCapture = ((intCaptures & 8) > 0); break;
            case mcntRightKey:      blnCapture = ((intCaptures & 16) > 0); break;
            case mcntLeftKey:       blnCapture = ((intCaptures & 32) > 0); break;
            case mcntPageDownKey:   blnCapture = ((intCaptures & 64) > 0); break;
            case mcntPageUpKey:     blnCapture = ((intCaptures & 128) > 0); break;
            case mcntHomeKey:       blnCapture = ((intCaptures & 256) > 0); break;
            case mcntEndKey:        blnCapture = ((intCaptures & 512) > 0); break;
            case mcntTabKey:        blnCapture = ((intCaptures & 1024) > 0); break;
            case mcntEscapeKey:     blnCapture = ((intCaptures & 2048) > 0); break;
            case mcntBackspaceKey:  blnCapture = ((intCaptures & 4096) > 0); break;
            case mcntSpaceKey:      blnCapture = ((intCaptures & 8192) > 0); break;
            case mcntDeleteKey:     blnCapture = ((intCaptures & 16384) > 0); break;
            case mcntEnterKey:      blnCapture = ((intCaptures & 32768) > 0); break;      
        }
    }
    
    // If should capture events by pass parents
    if(blnCapture)
    {
        // Cancel event bubble
        Web_EventCancelBubble(objEvent,false,true);
        
        // Call the generic on key down
        Web_OnKeyDown(objEvent, objWindow, false);
    }
}
/// </method>

/// <method name="Web_HandleMouseCaptures">
/// <summary>
///
/// </summary>
/// <param name="objEvent">The event object.</param>
/// <param name="intCaptures">The bitmask captures.</param>
/// <param name="objWindow">The window of the event source.</param>
function Web_HandleMouseCaptures(objEvent, intCaptures, objWindow)
{
    // Flag indicating if to capture event
    var blnCapture = false;
    
    // If is left click
    if(Web_IsLeftClick(objEvent))
    {
        // if should capture left click
        blnCapture = ((intCaptures & 131072) > 0);
    }
    else if(Web_IsRightClick(objEvent))
    {
        // if should capture right click
        blnCapture = ((intCaptures & 65536) > 0);
    }
    
    // If should capture events by pass parents
    if(blnCapture)
    {
        // Cancel event bubble
        Web_EventCancelBubble(objEvent,false,true);
        
        // Call the generic on mouse down
        Web_OnMouseDown(objEvent, objWindow);
    }
}
/// </method>

/// <method name="Web_OnClick" access="private">
/// <summary>
/// 
/// </summary>
function Web_OnClick(objEvent,objWindow,blnEnforceRaise,objSource,objCallbackDelegate)
{
    // Check the following:
    // 1. Double click is not being listened.
    // 2. Click is not a mouse right click.
    // 3. Loading screen is not active.
    if(Web_OnClick.intClick || Web_IsRightClick(objEvent) || mblnLoadingIsActive)
    {
        return;
    }    
    
    // Handle label editing.
    Web_HandleLabelEdit(objEvent,objWindow);
        
    // Get source element - if needed.
    if(!objSource)
    {
	    objSource = Web_GetEventSource(objEvent);    
	}
	
	if(objSource)
	{
        var objNode = null;

	    // Get VWG source element.
	    var objVwgSource = Web_GetVwgElement(objSource, true);    	    
        if(objVwgSource)
        {   
            // Get source element data id.
            var strGuid = Data_GetDataId(Web_GetId(objVwgSource));            
            if(strGuid!="")
            {
                // Get element's meta data node.
                objNode = Data_GetNode(strGuid);

                // Try execute client action.
                if (Web_ExecuteClientInvocation(objNode, objEvent))
                {
                    // If a clent action executed - prevent server click.
                    return;
                }
            }
        }       
        
	    // If the Web_OnClick was called directly 
        if(blnEnforceRaise)
        {
            Web_EventCancelBubble(objEvent,false,true);
        }

		// Set the click source object
		Web_OnClick.objSource = objSource;
		
		// Set the enforce raise value
		Web_OnClick.blnEnforceRaise = blnEnforceRaise;
		
		// Set the current click point
		Web_OnClick.objPoint = Web_PointFromEvent(objEvent);
		
		// Set the menu window
		Web_OnClick.objWindow = objWindow;

        // Set the source data node
        Web_OnClick.objNode = objNode;

        // Set if middle mouse button was clicked click
        Web_OnClick.blnIsMiddleClick = Web_IsMiddleClick(objEvent);

        // Update callback delegate
        Web_OnClick.objCallbackDelegate = objCallbackDelegate;
		
		// Define a default 10 milli seconds delay.
		var intDelay = 10;
		
		// If double click is critical raise delay.
		if (Data_IsCriticalEvent(objNode, "Event.DoubleClick", true))
		{
		    intDelay = mcntDoubleClickInterval;
		}
				
		// Set click timeout
        Web_OnClick.intClick = Web_SetTimeout(function ()
        {
            mobjApp.Web_OnClickAsync();
        },
        intDelay, objWindow);
    }
}
/// </method>

/// <method name="Web_OnClickAsyn" access="private">
/// <summary>
/// 
/// </summary>
function Web_OnClickAsync(blnDblClick)
{	
    // Get source element
	var objSource = Web_OnClick.objSource;
	
	// Get the click point
	var objPoint = Web_OnClick.objPoint;
	
	// Get the menu window
	var objWindow = Web_OnClick.objWindow;
		
	// Get the enforce raise value
	var blnEnforceRaise = Web_OnClick.blnEnforceRaise;

    // Get the source data node
    var objNode = Web_OnClick.objNode;
	
	// Set if middle mouse button was clicked click
    var blnIsMiddleClick = Web_OnClick.blnIsMiddleClick;

    // set callback delegate
    var objCallbackDelegate = Web_OnClick.objCallbackDelegate;

    // Clear click global state
    Web_OnClick.intClick = null;
    Web_OnClick.objSource = null;
    Web_OnClick.blnEnforceRaise = false;
    Web_OnClick.objWindow = null;
    Web_OnClick.objPoint = null;
    Web_OnClick.objNode = null;
    Web_OnClick.blnIsMiddleClick = null;
    Web_OnClick.objCallbackDelegate = null;

	// Protect against unexists elements
    if(objSource)
    {
        try {var objTest = objSource.id;} catch(e) { return;}
    }
    
	// Get the vwg source element.
	var objVwgSource = Web_GetVwgElement(objSource, true);
	if(objVwgSource) 
	{
	    // Get the source element's data id.
        var strDataId = Data_GetDataId(Web_GetId(objVwgSource));

        // In case that current component is disabled.
        if(Data_IsDisabled(objNode))
	    {
	        // Try getting the nearest parent which is registered to the click / double click event.
            var strRegisteredAncestorId = Data_GetFirstEnabledAncestorOrSelf(strDataId, blnDblClick ? "Event.DoubleClick" : "Event.Click", false);
            if(strRegisteredAncestorId!=strDataId)
            {
                // Update data id and node.
                strDataId=strRegisteredAncestorId;
                objNode=Data_GetNode(strDataId);
            }
	    }
        
        // Validate data id.
	    if(!Aux_IsNullOrEmpty(strDataID))
	    {
            // Check if source element defined as click once.
            var blnIsClickOnce = objNode && Xml_IsAttribute(objNode,"Attr.ClickOnce","1");
		    
            // Check if events are critical.
            var blnIsCriticalClick = Data_IsCriticalEvent(objNode, "Event.Click", true);
            var blnIsCriticalDblClick = Data_IsCriticalEvent(objNode, "Event.DoubleClick", true);
		    
            // Get the relative position
            var objRelativePoint = Web_GetRelativePoint(objVwgSource,objPoint);
	        
            // Define x and y coordination variables.
            var intX = objRelativePoint.left;
            var intY = objRelativePoint.top;
            
            // if double click was not found and is double click
            if(blnDblClick)
            {   
                // Add a double click event.
                Events_DoubleClick(strDataId,false,intX,intY);
            }
            else
            {
                // Add a click event.
                Events_Click(objWindow,null,strDataId,false,true,intX,intY,false,blnIsMiddleClick);
                
                // Disable control if ClickOnce is true
                if(blnIsClickOnce)
                {
                    Data_SetAttribute(strDataId,"Attr.Enabled","0");
                    Controls_RedrawControlByNode(objWindow,objNode);
                }
            }
            
            // if is critical event found
            if( (blnDblClick && blnIsCriticalDblClick) || 
                (!blnDblClick && blnIsCriticalClick) || 
                 blnEnforceRaise)
            {	    
                Events_RaiseEvents(objCallbackDelegate);
            }
        }
	}
}
/// </method>



/// <method name="Web_OnDblClick" access="private">
/// <summary>
/// 
/// </summary>
function Web_OnDblClick(objEvent,objWindow,blnEnforceRaise,objSource)
{
    // Check that the loading screen is not active.
    if(mblnLoadingIsActive)
    {
        return;
    }   
    
    // If the Web_OnClick was called directly 
    if(blnEnforceRaise)
    {
        Web_EventCancelBubble(objEvent);
    }
    
	// Clear the click time out
	if(Web_IsValidWindow(Web_OnClick.objWindow))
	{
	    Web_ClearTimeout(Web_OnClick.intClick,Web_OnClick.objWindow);
	}
	
	// Get source element - if needed.
    if(!objSource)
    {
	    objSource = Web_GetEventSource(objEvent);
	}
	if(objSource)
	{
	    // In case of enfocing - flag it for the Web_OnClickAsync function.
	    if(blnEnforceRaise)
	    {
	        Web_OnClick.blnEnforceRaise = blnEnforceRaise;
	    }
	    
		// set the click source object
		Web_OnClick.objSource = objSource;
		
	    // Raise click and double click
	    Web_OnClickAsync(true);
    }
}
/// </method>

/// <method name="Web_OnSelectStart" access="private">
/// <summary>
/// Handles client selection event
/// </summary>
function Web_OnSelectStart(objEvent,objWindow)
{
	// Get selection source element
	var objSource = Web_GetEventSource(objEvent);
	if(objSource)
	{
		if(Web_IsAttribute(objSource,"vwgeditable","1",true))
		{
		    // return if element supports selection
		    return;
	    }
		else 
		{
		    // get parent element
		    var objParent = Web_GetVwgElement(objSource);
	
		    if(objParent!=null && Web_IsAttribute(objParent, "vwgeditable","1",true))
		    {
		        //return if parent supports selection
		        return;
		    }
		}
	}
	
	// disable default behavior
	Web_EventCancelBubble(objEvent);
}
/// </method>

/// <method name="Web_OnRightClick" access="private">
/// <summary>
/// 
/// </summary>
function Web_OnRightClick(objEvent, objWindow, blnEnforceRaise,objCallbackDelegate)
{
    var blnIsRightClickCritical = false;
 
    // Cancel any ongoing drag&drop operation
    // Temporary fix until VWG-114925 has been researched and fixed.
    // TODO: Find permanent fix for VWG-114925
    Drag_InitializeDragAndDrop();

    // Get source element
	var objSource = Web_GetEventSource(objEvent);    
	if(objSource)
	{
	    // Get VWG source element.
	    var objVwgSource = Web_GetVwgElement(objSource, true);    	    
	    
        if(objVwgSource)
        {
            // Get the vwg id
		    var strDataId = Data_GetDataId(Web_GetId(objVwgSource));

            // Check if control is disabled
            if(Data_IsDisabled(strDataId))
            {
                // Try getting the nearest parent which is registered to right click event.
                var strRegisteredAncestorId = Data_GetFirstEnabledAncestorOrSelf(strDataId, "Event.RightClick", false);
                if(strRegisteredAncestorId!=strDataId)
                {
                    // Update data id.
                    strDataId=strRegisteredAncestorId;
                }
            }

		    if(!Aux_IsNullOrEmpty(strDataId))
		    {
                // Get data node
                var objNode=Data_GetNode(strDataId);

                if(objNode)
                {
                    // Check if right click is critical.
                    blnIsRightClickCritical = Data_IsCriticalEvent(objNode, "Event.RightClick", true);
            
                    // If right click is critical raise or force raise
		            if(blnEnforceRaise || blnIsRightClickCritical)
		            {
		                // Get the relative point 
		                var objRelativePoint = Web_GetRelativePoint(objVwgSource, Web_PointFromEvent(objEvent));		      		                

		                // Raise the click event
                        Events_Click(objWindow,objEvent,strDataId,false,false,objRelativePoint.left,objRelativePoint.top,true,false);

                        // Raise events
                        Events_RaiseEvents(objCallbackDelegate);
		            }
                }
		    }
        }	
    }
    
    // Cancel context menu for components which does not have right click or for elements that are not editable.
    if(!Web_IsAttribute(objSource,"vwgeditable","1",true) || blnIsRightClickCritical )
    {
        // NOTE: In case we are in enforce mode, it means we dont want any parents (like contextMenu) to be raise.
        var blnSkipCancelBubble = !blnEnforceRaise;

        // Disable default behavior
        Web_EventCancelBubble(objEvent, blnSkipCancelBubble, false);
	}
}
/// </method>

/// <method name="Web_PreserveModifierKeys" access="private">
/// <summary>
/// 
/// </summary>
function Web_PreserveModifierKeys(objEvent)
{
    if(objEvent)
    {
        // Clear modifier keys.
        Web_ClearModifierKeys();

        // Check if control key is pressed.
        if(Web_IsControl(objEvent))
        {
            mintModifierKeys |= mcntKeysControl;
        }

        // Check if alt key is pressed.
        if(Web_IsAlt(objEvent))
        {
            mintModifierKeys |= mcntKeysAlt;
        }

        // Check if shift key is pressed.
        if(Web_IsShift(objEvent))
        {
            mintModifierKeys |= mcntKeysShift;
        }
    }
}

/// <method name="Web_ClearModifierKeys" access="private">
/// <summary>
/// 
/// </summary>
function Web_ClearModifierKeys()
{
    mintModifierKeys = 0;
}

/// <method name="Web_GetModifierKeys" access="private">
/// <summary>
/// 
/// </summary>
function Web_GetModifierKeys()
{
    // Return modifier keys.
    return mintModifierKeys;
}

/// <method name="Web_OnKeyDown" access="private">
/// <summary>
/// 
/// </summary>
function Web_OnKeyDown(objEvent,objWindow,blnEnforceRaise)
{
	if(objEvent)
	{
        // Preserve 
        Web_PreserveModifierKeys(objEvent);

	    // Get event source.
	    var objEventSource   = Web_GetEventSource(objEvent);
		
		// Get event key code
		var intKeyCode  = Web_GetEventKeyCode(objEvent);
		
		// Get system keys status.
        var blnCtrl     = Web_IsControl(objEvent);
        var blnAlt      = Web_IsAlt(objEvent);
        var blnShift    = Web_IsShift(objEvent);
	    
	    // If an application shortcut or system shortcut has been pressde - cancel buble.
        if((mblnEnableClientShortcuts && Web_IsSystemKey(intKeyCode,blnCtrl,blnAlt)) || 
            Web_IsApplicationShortcut(intKeyCode,blnCtrl,blnAlt,blnShift))        
        {
            Web_EventCancelBubble(objEvent);
        }
        // Handle key down.
        else
        {
            Web_HandleKeyDown(objWindow,objEventSource,objEvent,blnEnforceRaise);
        }
	}	
}
/// </method>

/// <method name="Web_OnKeyUp" access="private">
/// <summary>
/// 
/// </summary>
function Web_OnKeyUp(objEvent,objWindow)
{
    // Clear modifier keys.
    Web_ClearModifierKeys();
}
/// </method>

/// <method name="Web_OnTabKeyDown">
/// <summary>
/// Handles Tab key.
/// </summary>
function Web_OnTabKeyDown(objEvent)
{   
    if(objEvent)
    {
        // Cancel bubble.
        Web_EventCancelBubble(objEvent);
        
        // Get source element.
        var objSourceElement = Web_GetEventSourceElement(objEvent);        
        if(objSourceElement)
        {   
            Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Web_HandleTabKeyBehavior,objSourceElement,objEvent.shiftKey),1);
        }
    }
}
/// </method>

/// <method name="Web_TriggerFocusOutHandler">
/// <summary>
/// Trigger focus out handler of recieved VWG component.
/// </summary>
function Web_TriggerFocusOutHandler(strFocusOutElementDataId)
{
    // Get current focus out element.
    var objFocusOutElement = Controls_GetFocusElementByDataId(strFocusOutElementDataId);
    if(objFocusOutElement)
    {
        // Triger the "blur" and "focusout" handlers of the focus out element.
        $(objFocusOutElement).triggerHandler("blur");
        $(objFocusOutElement).triggerHandler("focusout");
    }
}
/// </method>


/// <summary>
/// Get Arrow Navigation Key Event Handler from Element's attribute and raise it to element's control  
/// </summary>
/// <param name="strTargetDataId">The control's Node Data Id</param>
/// <param name="objTargetElement">Element to which navigation key was target</param>
/// <param name="intKeyCode">The pressed key code</param>
function Web_TriggerArrowKeyPress(strTargetDataId, objTargetElement, intKeyCode)
{


    //Rasie event only for arrow keys
    if (!Web_IsArrowKey(intKeyCode))
    {
        return;
    }

   
    var objWindow = Forms_GetWindowByDataId(strTargetDataId); 

    if (objTargetElement)
    {
        // Try getting the vwg_AfterArrowKeyPressEventHandler attribute.
        var strNavigationEventHandler = Web_GetAttribute(objTargetElement, "vwg_AfterArrowKeyPressEventHandler");

        if (!Aux_IsNullOrEmpty(strNavigationEventHandler))
        {
            // Get handler function.
            var fncNavigationEventHandler = Remoting_GetMethod(strNavigationEventHandler);
            if (fncNavigationEventHandler)
            {

                // Create an arguments array.
                var arrArguments = [strTargetDataId, intKeyCode, objWindow];

                // Invoke function with arguments.
                Aux_InvokeMethod(fncNavigationEventHandler, arrArguments);
            }
        }
    }
    
}

/// <method name="Web_HandleTabKeyBehavior">
/// <summary>
/// Handles Tab key.
/// </summary>
function Web_HandleTabKeyBehavior(objSourceElement,blnShiftKey)
{   
    if(objSourceElement)
    {
        // Get the Vwg source element.
        var objVwgSourceElement = Web_GetVwgElement(objSourceElement);
        if(objVwgSourceElement && !Aux_IsNullOrEmpty(objVwgSourceElement.id))
        {
            // Get the source element node.
            var objSourceNode = Data_GetNode(Data_GetDataId(objVwgSourceElement.id));
            
            Web_HandleNavigationFocus(objSourceNode,blnShiftKey, mcntTabKey);
        }
    }
}
/// </method>

/// <method name="Web_HandleNavigationFocus">
/// <summary>
/// Handles Navigation keys focus.
/// </summary>
function Web_HandleNavigationFocus(objSourceNode,blnShiftKey, intKeyCode)
{
    if(objSourceNode)
    {
        // The required target element
        var objTargetElement = Web_GetTabKeyTargetElement(objSourceNode,blnShiftKey, intKeyCode);
        if(objTargetElement)
        {
            // Get target's VWG element.
            var objVwgTargetElement = Web_GetVwgElement(objTargetElement);            
            if(objVwgTargetElement)
            {
                // Get target's data id.
                var strTargetDataId = Data_GetDataId(objVwgTargetElement.id);
                if(!Aux_IsNullOrEmpty(strTargetDataId))
                {   
                    // Get current focus element id.
                    var strFocusElementDataId = Focus_GetFocusElementDataId();
                    if(!Aux_IsNullOrEmpty(strFocusElementDataId))
                    {
                        // Check that current focus element is not the target element.
                        if(strFocusElementDataId!=Data_GetDataOwnerId(strTargetDataId))
                        {
                            // Trigger focus out handler of the focus element.
                            Web_TriggerFocusOutHandler(strFocusElementDataId);
                        }
                    }
                            
                    // Attach a focus event handler to target element.
                    Web_RegisterFocus(objTargetElement);
                            
                    // Focus target element.
                    Web_SetFocus(objTargetElement);

                    //If navigation arrow key was pressed, get event handler from the control's html code and raise handler for unique logic support by control
                    //(e.g.: RadioButton should be selected upon arrow key press)
                    if (Web_IsArrowKey(intKeyCode))
                    {
                        Web_TriggerArrowKeyPress(strTargetDataId, objTargetElement, intKeyCode);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Web_OnFocus">
/// <summary>
/// Handles the focus event.
/// </summary>
/// <param name="objEvent"></param>
function Web_OnFocus(objEvent)
{
    // Get the event's source element.
    var objSourceElement = Web_GetEventSourceElement(objEvent);
    if(objSourceElement)
    {
        // Deattach the focus event handler from the source element.
        Web_UnRegisterFocus(objSourceElement);
        
        // Set focus on source element.
        if(Focus_SetFocus(objSourceElement))
        {
            // Raise events.
            Events_RaiseEvents();
        }
    }
}
/// </method>

/// <method name="Web_GetTabKeyTargetElement">
/// <summary>
/// Gets a target tab element from a given node
/// </summary>
/// <param name="objSourceNode"></param>
/// <param name="blnBackwards"></param>
/// <param name="intKeyCode"></param>
function Web_GetTabKeyTargetElement(objSourceNode,blnBackwards, intKeyCode)
{ 
    // The first target node id.
    var strFirstTargetNodeId = null;
    
    // The required target element
    var objTargetElement = null;
    
    // Try to get the target node
    var objTargetNode = Data_GetTabKeyTargetNode(objSourceNode,blnBackwards, intKeyCode);
    if(objTargetNode)
    {
        do
        {
            // Gets the received node id.
            var strTargetNodeId = Xml_GetAttribute(objTargetNode,"Attr.Id","");
            
            // Check if an other target node has been ever found.
            if(!Aux_IsNullOrEmpty(strFirstTargetNodeId))
            {       
                // Check if the previously found target node is the same as the current one.
                if(strFirstTargetNodeId==strTargetNodeId)
                {
                    // Return null in order to avoid infinite loops.
                    return;
                }
            }
            else
            {
                // Validate the current target node id.
                if(!Aux_IsNullOrEmpty(strTargetNodeId))
                {
                    // Save the current target node id.
                    strFirstTargetNodeId=strTargetNodeId;
                }
            }
            
            // Ensure that target node is focusable.
            if(Xml_IsAttribute(objTargetNode,"Attr.Focus","1"))
            {
                // Try to get target element
                objTargetElement = Controls_GetFocusElementByDataId(strTargetNodeId);
            }
            
            // If there is no valid taget element
            if(!objTargetElement)
            {
                // Get next tab index control
                objTargetNode = Data_GetTabKeyTargetNode(objTargetNode,blnBackwards, intKeyCode);
            }
        }
        // Loop untill no more controls 
        while(!objTargetElement && objTargetNode!=null)
    }
    
    // Return the target element to focus on
    return objTargetElement;
}
/// </method>

/// <method name="Web_HandleKeyDown">
/// <summary>
/// Handles key down.
/// </summary>
function Web_HandleKeyDown(objWindow,objEventSource,objEvent,blnEnforceRaise)
{
    // Get the pressed key
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    var blnCancelBubble = (intKeyCode == mcntTabKey) ? false : !blnEnforceRaise;
    var blnPreventDefault = (intKeyCode == mcntTabKey) ? false : !Web_IsForbiddenCharacter(intKeyCode) && !blnEnforceRaise;
	
    // 1. Cancel buble in case that key down event was enforced.
    // 2. Prevent default in case that character is not forbidden and key down event was not enforced.
    Web_EventCancelBubble(objEvent, blnCancelBubble, blnPreventDefault);

	// Raise event if critical and key filter set
	// Check event code
	switch(intKeyCode)
	{
		// Ignore modifiers only
		case mcntTabKey:
		    Web_OnTabKeyDown(objEvent);
		    break;

        case mcntRightKey:
        case mcntDownKey:
            Web_OnNavigationKeyDown(objEvent,false, intKeyCode);
            break;

        case mcntLeftKey:
        case mcntUpKey:
            Web_OnNavigationKeyDown(objEvent,true, intKeyCode);
            break;
	}
	
	// Fire key down event.
	Web_FireKeyDown(objEventSource,objEvent,blnEnforceRaise);
}
/// </method>

/// <method name="Web_OnNavigationKeyDown">
/// <summary>
/// Handles Navigation keys key down.
/// </summary>
function Web_OnNavigationKeyDown(objEvent,blnPrevious, intKeyCode)
{
    if(objEvent)
    {
        // Get source element.
        var objSourceElement = Web_GetEventSourceElement(objEvent);
        if(objSourceElement)
        {
            // Get the Vwg source element.
            var objVwgSourceElement = Web_GetVwgElement(objSourceElement);
            if(objVwgSourceElement && !Aux_IsNullOrEmpty(objVwgSourceElement.id))
            {
                // Get the source element node.
                var objSourceNode = Data_GetNode(Data_GetDataId(objVwgSourceElement.id));
                if(objSourceNode)
                {
                    if(Data_GetNodeAttribute(objSourceNode, "Attr.SupportsKeyNavigation") == "0" && Data_GetNodeAttribute(objSourceNode, "Attr.ControlEditMode") != "1")
                    {
                        Web_HandleNavigationFocus(objSourceNode,blnPrevious, intKeyCode);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Web_FireKeyDown">
/// <summary>
/// Fires key down.
/// </summary>
function Web_FireKeyDown(objSoureElement,objEvent,blnEnforceRaise)
{
    if(objSoureElement)
    {
        // Get vwg source element.
        var objVwgSource = Web_GetVwgElement(objSoureElement,true);
        if(objVwgSource)
        {
            // Get vwg source element's id.
            var strVwgSourceDataId = Data_GetDataId(objVwgSource.id);
            if(!Aux_IsNullOrEmpty(strVwgSourceDataId))
            {
                // Define a raise events switch.
                var blnRaiseEvents = false;
    		    
                var objVWGEvent = null;

                // Get key code from dom event.
                var intKeyCode = Web_GetEventKeyCode(objEvent);
               
	            // Check if enter is supported.
		        var blnSupportsEnter = objSoureElement && Web_GetAttribute(objSoureElement,"vwgentersupported")=="1";
		    
                // If enter or esc pressed and active window exists.
                // blnSupportsEnter states if an internal "New Line" character should be added or "Enter" key press event raised.
                if( !Aux_IsNullOrEmpty(mstrActiveWindowGuid) &&
                    ((intKeyCode==mcntEnterKey && !blnSupportsEnter) || intKeyCode==mcntEscapeKey))
                {
                    // Get the window's data id
                    var strWindowDataId = Data_GetDataId(mstrActiveWindowGuid);
              	
                    // If is enter
                    if(intKeyCode==mcntEnterKey)
                    {
                        // Get the vwg source element.
                        var objVwgElement = Web_GetVwgElement(objSoureElement, true);
                        if(objVwgElement)
                        {
                            // Get source node.
                            var objSourceNode = Data_GetNode(Data_GetDataId(Web_GetId(objVwgElement)));
                            if(objSourceNode)
                            {
                                // Check that source node is not a button control.
                                if(!Xml_IsAttribute(objSourceNode,"Attr.IsButtonControl","1") &&
                                    Data_IsAttribute(strWindowDataId,"Attr.AcceptButton","1"))
                                {
                                    Events_FireEvent(strWindowDataId,"OnAccept",false);
                                    blnRaiseEvents = true;
                                }
                            }
                        }
                    }
              	
                    // If is escape
                    if(intKeyCode==mcntEscapeKey)
                    {
                        // If there is an CancelButton assigned
                        if(Data_GetAttribute(strWindowDataId,"Attr.CancelButton","0")=="1")
                        {
                            Events_FireEvent(strWindowDataId,"OnCancel",false);
                            if (!mcntIsIE)
                            {
                                Web_EventCancelBubble(objEvent);
                            }
                            blnRaiseEvents = true;
                        }
                    }
                }

                // Get registered ancestor or self which is registered to key down event.
                var strSourceDataId = Data_GetFirstEnabledAncestorOrSelf(strVwgSourceDataId, "Event.KeyDown", true);
                if(!Aux_IsNullOrEmpty(strSourceDataId))
                {
                    // Check if recieved key should be filtered.
                    if(Data_IsKeyFilterEnabled(strSourceDataId,intKeyCode,objEvent))
                    {
                        // Create a key down event.
                        objVWGEvent = Events_KeyDown(strSourceDataId,objEvent);

                        // Flag that raise events should be done.
                        blnRaiseEvents = true;
		            }
    		    }
    		    
    		    // Raise events - if needed.
                if(blnRaiseEvents || blnEnforceRaise)
                {
                    Events_RaiseEvents();
                }

                if(!objVWGEvent)
                {
                    // Try getting a source id of a control which is registed to the client key 
                    strSourceDataId = Data_GetFirstEnabledAncestorOrSelf(strVwgSourceDataId, "Event.KeyDown", true, true);
                    if(!Aux_IsNullOrEmpty(strSourceDataId))
                    {
                        // Check if recieved key should be filtered.
                        if(Data_IsKeyFilterEnabled(strSourceDataId,intKeyCode,objEvent))
                        {
                            // Create a key down client event.
                            objVWGEvent = Events_KeyDown(strSourceDataId,objEvent,true);
                        }
                    }
                }

                // Process client key down event is passing filter test
                if(objVWGEvent)
                {
                    Events_ProcessClientEvent(objVWGEvent);
	            }
	        }
	    }
    }
}

/// <method name="Web_IsForbiddenCharacter" access="private">
/// <summary>
/// 
/// </summary>
function Web_IsForbiddenCharacter(intKeyCode)
{
    return !Aux_IsNullOrEmpty(intKeyCode) && [mcntHelpKey].contains(intKeyCode);
}
/// </method>

/// <method name="Web_IsApplicationShortcut" access="private">
/// <summary>
/// 
/// </summary>
function Web_IsApplicationShortcut(intKeyCode,blnCtrl,blnAlt,blnShift)
{
    // Calculate valid key coden
    var blnValidFKey        = (intKeyCode>=112 && intKeyCode<=123);
    var blnValidNumPadKey   = (intKeyCode>=96 && intKeyCode<=105);
    var blnValidCmd         = blnValidNumPadKey || blnValidFKey || (intKeyCode==45 || intKeyCode==46 || intKeyCode==9 || intKeyCode==19 || intKeyCode==32 || intKeyCode==35 || intKeyCode==37 || intKeyCode==38 || intKeyCode==39 || intKeyCode==40 || intKeyCode==144 || intKeyCode==187 || intKeyCode==188 || intKeyCode==189 || intKeyCode==190 || intKeyCode==191 || intKeyCode==192 || intKeyCode==219 || intKeyCode==220);
    var blnValidKey         = (intKeyCode>=65 && intKeyCode<=90) || (intKeyCode>=48 && intKeyCode<=57);
    var blnValidEntry       = blnValidCmd || blnValidKey;
    
    // If valid shortcut
    if((blnCtrl && !blnAlt && blnValidEntry) || (blnAlt && !blnShift && !blnCtrl && blnValidEntry) || (blnShift && !blnAlt && blnValidEntry) || blnValidCmd)
    {
        var strShortcut = (blnCtrl?"Ctrl":"")+(blnShift?"Shift":"")+(blnAlt?"Alt":"");
        if(blnValidFKey)
        {
            strShortcut+="F"+(intKeyCode-111);
        }
        else if(blnValidNumPadKey)
        {
            strShortcut+="NumPad"+(intKeyCode-96);
        }
        else if(intKeyCode==45)
        {
            strShortcut+="Ins";
        }
        else if(intKeyCode==46)
        {
            strShortcut+="Del";
        }
        else if(intKeyCode==9)
        {
            strShortcut+="Tab";
        }
        else if(intKeyCode==19)
        {
            strShortcut+="Pause";
        }
        else if(intKeyCode==32)
        {
            strShortcut+="Space";
        }
        else if(intKeyCode==35)
        {
            strShortcut+="End";
        }
        else if(intKeyCode==37)
        {
            strShortcut+="Left";
        }
        else if(intKeyCode==38)
        {
            strShortcut+="Up";
        }
        else if(intKeyCode==39)
        {
            strShortcut+="Right";
        }
        else if(intKeyCode==40)
        {
            strShortcut+="Down";
        }
        else if(intKeyCode==144)
        {
            strShortcut+="NumLock";
        }
        else if(intKeyCode==187)
        {
            strShortcut+="Oemplus";
        }
        else if(intKeyCode==188)
        {
            strShortcut+="Oemcomma";
        }
        else if(intKeyCode==189)
        {
            strShortcut+="OemMinus";
        }
        else if(intKeyCode==190)
        {
            strShortcut+="OemPeriod";
        }
        else if(intKeyCode==191)
        {
            strShortcut+="OemQuestion";
        }
        else if(intKeyCode==192)
        {
            strShortcut+="Oemtilde";
        }
        else if(intKeyCode==219)
        {
            strShortcut+="OemOpenBrackets";
        }
        else if(intKeyCode==220)
        {
            strShortcut+="OemBackslash";
        }
        else
        {
            strShortcut+=String.fromCharCode(intKeyCode);
        }
        
        var strDataId = Data_GetShortcutTarget(strShortcut);
        if(strDataId)
        {
            var objEvent = Events_CreateEvent(strDataId,"Shortcut");
	        Events_SetEventAttribute(objEvent,"Attr.Value",strShortcut);
	        Events_RaiseEvents();
        }
    }
    
    return false;
}
/// </method>

/// <method name="Web_IsSystemKey" access="private">
/// <summary>
/// 
/// </summary>
function Web_IsSystemKey(intKeyCode,blnCtrl,blnAlt)
{
	if(blnCtrl && blnAlt)
	{
		switch(intKeyCode)
		{
		    case 82:
		        open(mstrBaseURL+"Resources.Manifest.wgx");
		        break;
			case 83:
				Web_CopyToClipBoard("Text",Xml_GetOuterXML(mobjDataDomObject));
				break;
			case 88:
				Web_CopyToClipBoard("Text",Xml_GetOuterXML(mobjXSLDocument.documentElement));
				break;
			case 86:
				alert(Data_GetParam("V"));
				break;
			case 72:
			    var objWindow = Web_GetActiveWindow();
			    if(objWindow)
			    {
			        Web_CopyToClipBoard("Text",objWindow.document.body.innerHTML);
				}
				break;
            case 79:
				Client_SetOfflineMode(!mblnIsOfflineMode);
				break;
			case 68:
			    debugger;
				break;
			case 69:
                Events_CreateEvent(mstrWindowGuid,"ShowServerExplorer");
                Events_RaiseEvents();
				break;
			default:
			    return false;			    
		}
		return true;
	}
	return false;
}
/// </method>





/// <method name="Web_OnUnload">
/// <summary>
/// 
/// </summary>
function Web_OnUnload(objEvent,objWindow)
{
    // If was not closed by the server
    if(!mblnServerClosed)
    {
        try
        {
            // Raise the close event so context will be closed if needed
		    var objVwgEvent = Events_CreateEvent(mstrWindowGuid,"OnClose"); 
		    Events_RaiseEvents(null,false,!mcntIsIE);

			Events_ProcessClientEvent(objVwgEvent);
		}
		catch(e)
		{
		    // Do not throw errors at this stage
		}
    }
}
/// </method>

/// <method name="Web_OnBodyScroll">
/// <summary>
/// Disables the scrolling for Body element
/// </summary>
function Web_OnBodyScroll(objEvent)
{
    if(objEvent)
    {
        // Get the event's source element.
        var objSourceElement = Web_GetEventSourceElement(objEvent);
        if(objSourceElement)
        {
            switch (Web_GetId(objSourceElement)) 
            {
                case "VWG_Body":
                case "VWG_BodyContentContainer":
                case "VWG_BodyContent":
                    // Cancel default action and buble.
                    Web_EventCancelBubble(objEvent);
            
                    // Initialize scroll position.
                    objSourceElement.scrollTop = objSourceElement.scrollLeft = 0;
                    break;
            }
        }
    }
}
/// </method>

/// <method name="Web_SetSelectedElement">
/// <summary>
/// Sets a selected style to given element in a given window
/// </summary>
/// <param name="objElement">Reference to styled element.</param>
/// <param name="objWindow">Reference to element's window.</param>
function Web_SetSelectedElement(objElement,objWindow)
{
	Web_SetStyle(objElement,"selected",objWindow);
}
/// </method>

/// <method name="Web_SetUnselectedElement">
/// <summary>
/// Sets an unselected style to given element in a given window
/// </summary>
/// <param name="objElement">Reference to styled element.</param>
/// <param name="objWindow">Reference to element's window.</param>
function Web_SetUnselectedElement(objElement,objWindow)
{
	Web_SetStyle(objElement,"deselected",objWindow);
}
/// </method>






/// <method name="Web_GetId">
/// <summary>
/// Get an id from a given element
/// </summary>
/// <param name="objIESource">Gets the ID of the component related with this element.</param>
function Web_GetId(objIESource)
{
	while(!objIESource.id) 
	{	
		objIESource=objIESource.parentNode;
		if(!objIESource) return "";
	}
	return objIESource.id;
}
/// </method>

/// <method name="Web_GetDialogArgs" access="private">
/// <summary>
/// Returns a dialog arguments string 
/// </summary>
/// <param name="intLeft">The dialog left.</param>
/// <param name="intTop">The dialog top.</param>
/// <param name="intWidth">The dialog width.</param>
/// <param name="intHeight">The dialog height.</param>
/// <param name="objWindow">The parent dialog window.</param>
/// <param name="blnResizable">Indicates if the form dialog can be resizable</param>
/// <param name="blnMaximize">Indicates if the form dialog can be maximized</param>
/// <param name="blnMinimize">Indicates if the form dialog can be minimized</param>
function Web_GetDialogArgs(intStartPos,intWindowState,intLeft,intTop,intWidth, intHeight,objWindow,blnResizable,blnMaximize,blnMinimize) 
{
    // Define X and Y positions variables.
    var intPosX = intLeft;
	var intPosY = intTop;
		
	// If top or left attributes are missing - calculates form's position.
	if(!intPosX || !intPosY)
	{
		if (Web_IsWindow(objWindow)) 
		{
			intPosX = objWindow.screenLeft + (objWindow.document.body.clientWidth-intWidth)/2;
			intPosY = objWindow.screenTop  + (objWindow.document.body.clientHeight-intHeight)/2;
		}
		else 
		{
			intPosX = screenLeft + (document.body.clientWidth-intWidth)/2;
			intPosY = screenTop  + (document.body.clientHeight-intHeight)/2;
		}
	}
	
	// Check if position is overflowing the available screen size.
	if (intPosX > screen.availWidth || intPosY > screen.availHeight) 
	{
		intPosX = (screen.availWidth -  intWidth)/2;
		intPosY = (screen.availHeight - intHeight)/2;
	}
	
	// Check maximize windwos state.
	if( intWindowState == 2 )
	{
	    intWidth = screen.availWidth;
	    intHeight = screen.availHeight;
	    intPosX = 0;
		intPosY = 0;
	}
	
	if(mcntIsIE)
	{
		return 'dialogLeft:'+intPosX+'px;dialogTop:'+intPosY+'px;'+
			 'dialogWidth:'+intWidth+'px;dialogHeight:'+intHeight+'px;'+
			 'status:no;scroll:no;edge:sunken;help:no;resizable:'+(blnResizable?'yes':'no')+';minimize:'+(blnMinimize?'yes':'no')+';maximize:'+(blnMaximize?'yes':'no')+';';
	}
	else
	{	
		return 'width='+intWidth+'px,height='+intHeight+'px,'+
			 'status=0,scroll=0,resizable='+(blnResizable?'1':'0')+',minimizable='+(blnMinimize?'1':'0');
	}
}
/// </method>

/// <method name="Web_GetParentById">
/// <summary>
/// Gets a parent element with the current id
/// </summary>
function Web_GetParentById(objContext,strId)
{
	var objElement = objContext;
	while(objElement.id!=strId)
	{
		var objParent = objElement.parentNode;
		if(objElement==objParent || objParent==null)
		{
			return null;
		}
		else
		{
			objElement = objParent;
		}
	}
	return objElement;
}
/// </method>

/// <method name="Web_GetVwgElement">
/// <summary>
/// Gets a parent element with the current id
/// </summary>
function Web_GetVwgElement(objElement,blnIncludeMembers,blnIncludeTargets,blnIncludeWrappers)
{
    // Preserve recieved element.
	var objCurrentElement = objElement;
	
	// Loops while current element is not empty.
	while(objCurrentElement) 
    {
        // Get element's ID.
        var strId = objCurrentElement.id;
        
        // Check that the current element id begins with "vwg_" and does not contain any umpersent after that.
        if (!Aux_IsNullOrEmpty(strId) &&
            strId.length>4)
        {
            if(strId.substring(0,4).toLowerCase()=="vwg_")
            {
                if(blnIncludeMembers || strId.substring(4).indexOf("_")==-1)
                {
                    break;
                }
            }
            else if(blnIncludeTargets && strId.substring(0,4).toLowerCase()=="trg_")
            {
                break;
            }
            else if(blnIncludeWrappers && strId.substring(0,4).toLowerCase()=="wrp_")
            {
                break;
            }
	    }
	    
	    // Get element's parent.
	    objCurrentElement = Web_GetParent(objCurrentElement);
    }
	
	// Return current element.
	return objCurrentElement;
}
/// </method>

/// <method name="Web_IsVwgElement">
/// <summary>
/// Checks whether the recieved element is a VWG element.
/// </summary>
function Web_IsVwgElement(objElement)
{
	return (objElement && objElement.id && objElement.id.length>3 && objElement.id.substring(0,4).toLowerCase()=="vwg_");
}
/// </method>

/// <method name="Web_GetWebId">
/// <summary>
/// Gets a web id format "VWG_XXX"
/// </summary>
function Web_GetWebId(strGuid,blnIsUnregeistered)
{
	if( String(strGuid).indexOf("VWG_")!=0 &&
	    String(strGuid).indexOf("VWGE_")!=0)
	{
	    if(blnIsUnregeistered)
	    {
		    return "VWGE_"+strGuid;
		}
		else
		{
		    return "VWG_"+strGuid;
		}
	}
	
	return strGuid;
}
/// </method>

/// <method name="Web_GetTargetElementByDataId">
/// <summary>
/// Gets the target element by data id
/// </summary>
/// <param name="strId">The data ID.</param>
/// <param name="objWindow">The element window(optional).</param>
function Web_GetTargetElementByDataId(strDataId,objWindow)
{
    // Get browser element from component id
    var objElement = Web_GetElementByDataId(strDataId,objWindow);
    if(objElement)
    {
        // Get contained target with in element
        return Web_GetContextElementById(objElement,"TRG_"+strDataId);
    }
}    
/// </method>

/// <method name="Web_GetElementByDataId">
/// <summary>
/// Gets the element by data id
/// </summary>
/// <param name="strId">The data ID.</param>
/// <param name="objWindow">The element window(optional).</param>
function Web_GetElementByDataId(strDataId,objWindow)
{
    if(!objWindow) objWindow = Forms_GetWindowByDataId(strDataId);
    if(objWindow)
    {
        return Web_GetElementById(Web_GetWebId(strDataId),objWindow);
    }
}
/// </method>


/// <method name="Web_GetElementByDataId">
/// <summary>
/// Gets the element by data id
/// </summary>
/// <param name="strId">The data ID.</param>
/// <param name="objWindow">The element window(optional).</param>
function Web_GetElementsByIds(objIDs,objWindow)
{
    if(objIDs.length==1)
    {
        return Web_GetElementById(objIDs[0],objWindow); 
    }
    else if(objIDs.length>1)
    {
        var arrElements = [];
        for(var intIndex=0;intIndex<objIDs.length;intIndex++)
        {
            arrElements.push(Web_GetElementById(objIDs[intIndex],objWindow));
        }
        return arrElements;
    }
    else
    {
        return null;
    }
}
/// </method>

/// <method name="Web_GetElementByDataId">
/// <summary>
/// Gets the element by data id
/// </summary>
/// <param name="tagName">The name of HTML tag.</param>
/// <param name="objWindow">The element window(optional).</param>
function Web_GetElementsByTagName(strTagName,objWindow)
{
    if (!strTagName) return null;
    if (!objWindow) 
    {
        objWindow = Web_GetActiveWindow();
    }
    try
    {
        return objWindow.document.getElementsByTagName(strTagName);
    }
    catch(e)
    {
        return null;
    }
}
/// </method>

/// <method name="Web_AnchorY">
/// <summary>
/// Get the anchor position value
/// </summary>
function Web_AnchorY(objParent,intX1,intX2)
{
	if(objParent)
	{
		var intValue = objParent.clientHeight-intX1-intX2;
		return intValue<0?3:intValue;
	}
	else
	{
		return 3;
	}
}
/// </method>

/// <method name="Web_AnchorX">
/// <summary>
/// Get the anchor position value
/// </summary>
function Web_AnchorX(objParent,intX1,intX2)
{
	if(objParent)
	{
		var intValue = objParent.clientWidth-intX1-intX2;
		return intValue<0?3:intValue;
	}
	else
	{
		return 3;
	}
}
/// </method>

/// <method name="Web_ValidateValue">
/// <summary>
/// Validates a value from an expressions
/// </summary>
function Web_ValidateValue(strExpression,value,elementObject,windowObject,eventObject)
{
	try
	{
		var fncExecute = new Function("value,elementObject,windowObject,eventObject","return " + strExpression + ";");
		return fncExecute(value,elementObject,windowObject,eventObject);
	}
	catch(e)
	{
		alert("Expression Error:" + e.description + "("+strExpression+")");
		return false;
	}
}
/// </method>

/// <method name="Web_ExecuteClientInvocation">
/// <summary>
/// Executes client invocation if available and cancels default action
/// </summary>
/// <param name="objNode">The component data node</param>
function Web_ExecuteClientInvocation(objNode, objEvent)
{
    if(objNode)
    {
        // Check for client invocation 
        var strMember = Xml_GetAttribute(objNode,"Attr.ClientInvocationMember");
        if(!Aux_IsNullOrEmpty(strMember))
        {
            // Get target method
            var fncMember = Remoting_GetMethod(strMember);
	        if(fncMember!=null)
	        {
                // Create a variable to indicate if the client invokation method wants to prevent further execution
                var blnPreventDefaultAction = true;

                // Get the ClientInvocationPreventDefaultAction attribute
                if(Xml_GetAttribute(objNode,"Attr.PreventDefaultAction"))
                {
                    // The attribute's existance tells the calling method that this action does not prevent further execution
                    blnPreventDefaultAction = false;
                }
            
	            // Cancel default action
                if(objEvent) Web_EventCancelBubble(objEvent);
                
                // Create arguments array
                var arrArguments = [];
                
                var intIndex = 0;

	            // While argument exists
	            while(objNode.attributes.getNamedItem("Attr.ClientInvocationArgument"+intIndex))
	            {
	                arrArguments[intIndex] = objNode.getAttribute("Attr.ClientInvocationArgument"+intIndex);
	                intIndex++;
	            }
	    
                // Invoke method
	            Aux_InvokeMethod(fncMember,arrArguments);
	            
	            return blnPreventDefaultAction;
            }
        }
    }
    
    return false;
}
/// </method>

function Web_SyncScrollSchedule(objSource,objTarget,intType,strDir)
{
    Web_SyncScrollSchedule.objSource = objSource;
    Web_SyncScrollSchedule.objTarget = objTarget;
    Web_SyncScrollSchedule.intType = intType;
    Web_SyncScrollSchedule.strDir = strDir;
    setTimeout("Web_SyncScrollScheduleExecute()",1);
}

function Web_SyncScrollScheduleExecute()
{
    Web_SyncScroll(Web_SyncScrollSchedule.objSource,Web_SyncScrollSchedule.objTarget,Web_SyncScrollSchedule.intType,Web_SyncScrollSchedule.strDir);
}

function Web_SyncScroll(objSource,objTarget,intType,strDir)
{
	try
	{
		// Validate objects
		if(objTarget && objSource)
		{
			
			// If horisontal sync
			if(intType==1 || intType==3)
			{
			    // set scroll left for WebKit if is rtl
			    if(mcntIsWebKit && strDir=="RTL")
			    {
                    var intScrollRight = objSource.scrollWidth - objSource.scrollLeft - objSource.clientWidth;
                    objTarget.scrollLeft = objTarget.scrollWidth - objTarget.clientWidth - intScrollRight;
			    }
			    else // set scroll left for all the rest
			    {
			        // Set scroll left
					objTarget.scrollLeft = objSource.scrollLeft;
				}
			}
			
			// If vertical sync
			if(intType==2 || intType==3)
			{
				objTarget.scrollTop = objSource.scrollTop;
			}
		}
	}
	catch(e)
	{
	}
}

function Web_HasScrollX(objSource)
{
	return objSource.clientWidth<objSource.scrollWidth;
}

function Web_HasScrollY(objSource)
{
	return objSource.clientHeight<objSource.scrollHeight;
}

function Web_GetChildByIndex(objElement,intIndex)
{
	if(objElement)
	{
		return objElement.childNodes[intIndex];
	}
	return null;
}

function Web_GetIndex(objElement)
{
	if(objElement)
	{
		var intIndex	= 0;
		var objCurrent	= objElement.parentNode.firstChild;
		if(objCurrent)
		{
			do
			{
				if(objCurrent==objElement)
				{
					return intIndex;
				}
				intIndex++;
			}
			while(objCurrent = objCurrent.nextSibling)
		}
	}

	return -1;
	
}

function Web_IsAttribute(objControl,strAttribute,strValue,blnProtected)
{
    return Web_GetAttribute(objControl,strAttribute,blnProtected)==strValue;
}

function Web_GetAttribute(objControl,strAttribute,blnProtected)
{
	if(objControl)
	{
		if(blnProtected)
		{
			if(!objControl.getAttribute)
			{
				return "";
			}
		}
		//Check first if there is an attribute with the name "data-" + strAttribute, if so, return its value. otherwise, get default attribute (strAttribute) value
		var strAttributeValue = $(objControl).attr('data-' + strAttribute);
		if (strAttributeValue != undefined) {
		    return strAttributeValue;
		}
		return objControl.getAttribute(strAttribute);
	}
	else
	{
		return "";
	}
}

function Web_SetSelectionRange(ctrl,objRange)
{
	Web_SetSelection(ctrl,objRange.Start,objRange.End-objRange.Start);
}

function Web_GetCursorPosition(ctrl)
{
	var objRange = Web_GetSelectionRange(ctrl);
	if(objRange)
	{
		 return objRange.Start;
	}
	else
	{
		return 0;
	}
}

function Web_GetParent(objElement)
{
	if(objElement==null)return null;
	var parent=null;
	if(mcntIsIE)parent=objElement.parentElement;
	else parent=objElement.parentNode;
	return parent;
}

function Web_GetContainedWebElement(strId,strContainedId,objWindow)
{
	var objContainer = Web_GetWebElement(strId,objWindow);
	if(objContainer)
	{
	    return Web_GetContextElementById(objContainer,strContainedId);
	}
}

function Web_GetContextElementByAttribute(objContainer,strAttribute,strValue,blnScanContainedComponents)
{
    if (objContainer)
    {
        // Loop all child elements
        for(var intIndex=0;intIndex<objContainer.childNodes.length;intIndex++)
        {
            // Get current element
            var objElement = objContainer.childNodes[intIndex];
        
		    if(!Web_IsVwgElement(objElement) || blnScanContainedComponents)
		    {
			    if (objElement.nodeType==1)
			    {
				    // If element has attribute with value
				    if(Web_GetAttribute(objElement,strAttribute)==strValue)
				    {
					    return objElement;
				    }
            
				    // Check sub elements
				    var objSubElement = Web_GetContextElementByAttribute(objElement,strAttribute,strValue,blnScanContainedComponents);
				    if(objSubElement!=null)
				    {
					    return objSubElement;
				    }
			    }
		    }
        }
    }
    
    // Element not found
    return null;
}

function Web_SetAttribute(objControl,strAttribute,strValue)
{
	if(objControl)
	{
		//Check first if there is a "data-" attribute or there is no attribute (strAttribute) at all, if so, set the new value in the "data-" attribute. otherwise, set default attribute (strAttribute)
	    if ($(objControl).attr('data-' + strAttribute) != undefined || $(objControl).attr(strAttribute) == undefined) {
	        return $(objControl).attr('data-' + strAttribute, strValue);
	    }
		return objControl.setAttribute(strAttribute,strValue);
	}
}

function Web_GetSelection(ctrl)
{
	var objRange = Web_GetSelectionRange(ctrl);
	if(objRange)
	{
		 return {Start:objRange.Start,Length:objRange.End-objRange.Start};
	}
	else
	{
		return {Start:0,Length:0};
	}
}

function Web_SetSelection(ctrl,iStart,iLength)
{
    // Update the selection start position only if the selection length is bigger then one.
    iStart = ((iStart>=ctrl.value.length && iLength>0)?iStart-1:iStart);
	
	if(mcntIsIE)
	{
		var oRange=ctrl.createTextRange();
		oRange.moveStart("character",iStart);
		oRange.moveEnd("character",iLength+iStart-ctrl.value.length);
		oRange.select();
		ctrl.caretPos=oRange;
	}
	else
	{
	    ctrl.focus();
	    ctrl.setSelectionRange(iStart,iStart+iLength);
	}
}

function Web_SetEventKeyCodeOnKeyPress(objEvent, strKeyCode)
{
    // Will work only from a keyPress event!
    if (mcntIsIE) 
    {
        if (objEvent.type != "keypress")
        {
            return;
        }
    
        objEvent.keyCode = strKeyCode;
    }
}

function Web_GetEventKeyCode(objEvent)
{
    if (objEvent)
    {
        if (objEvent.keyCode && objEvent.keyCode != 0)
        {
            return objEvent.keyCode;
        }
        else if (objEvent.charCode && objEvent.charCode != 0)
        {
            return objEvent.charCode;
        }
    }
    return 0;
}

function Web_Refresh(blnServerClosed)
{
    // Close all active dialogs.
    Forms_CloseAll(false);
    
    // Indicate server has requested refresh
    mblnServerClosed = blnServerClosed;
    
    // Get main window location.
    var strMainWindowLocation = Web_GetMainWindowLocation();
    if(!Aux_IsNullOrEmpty(strMainWindowLocation))
    {
        // Refresh page
        Web_SetMainWindowLocation(strMainWindowLocation.replace(/[/]Post[.]/i,"/"));
    }
}

function Web_GetWindowPosition(intLeft,intTop,intWidth,intHeight,objWindow)
{
	var objRect = Web_GetRect(objWindow.document.body);
	intLeft = (intLeft+(intWidth+7)>objRect.right)?objRect.right-(intWidth+7):intLeft;
	intTop = (intTop+(intHeight+7)>objRect.bottom)?objRect.bottom-(intHeight+7):intTop;
	if(intTop<0) intTop = 0;
	if(intLeft<0) intLeft = 0;
	return {left:intLeft,top:intTop};
}

function Web_IsControl(objEvent)
{
    return objEvent.ctrlKey;
}

function Web_IsAlt(objEvent)
{
    return objEvent.altKey;
}

function Web_IsShift(objEvent)
{
    return objEvent.shiftKey;
}

/// <method name="Web_GetScrollableParent">
/// <summary>
/// Recursivly search for the received element's first scrollable parent.
/// </summary>
function Web_GetScrollableParent(objElement)
{
    if(objElement)
    {
        var objVWGElement = Web_GetVwgElement(objElement, true);
        if(objVWGElement)
        {
            // Get the window from the control
            var objWindow = Forms_GetWindowByDataId(Data_GetDataId(objVWGElement.id));
            if(objWindow)
            {
                var objScrollableParent     = objElement;
    
                do
                {           
                    // Get scrollable value
                    var strScrollableValue = Web_GetAttribute(objScrollableParent,"vwgscrollable",true);
        
                    var blnHasScrollableValue = !Aux_IsNullOrEmpty(strScrollableValue);

                    // If value doesn't exist, iterate to the parent control
                    if(!blnHasScrollableValue)
                    {
                        objScrollableParent     = objScrollableParent.parentNode;
                    }
                    // If value is not "1" (i.e. not the scrollable element itself), Then the value is the ID of the scrollable element related to the given control
                    else if(strScrollableValue !== "1")
                    {
                        // Get the scrollable element
                        objScrollableParent = Web_GetElementById(strScrollableValue,objWindow);
                    }
    
                }
                while (objScrollableParent && !strScrollableValue);
    
                return objScrollableParent;
            }
        }
    }
}
/// </method>

function Web_IsEmptyOrNull(strInput)
{
	if(strInput)
	{
		return strInput=="";
	}
	else
	{
		return true;
	}
}

/// <method name="Web_CreateForm">
/// <summary>
/// Creates a new HTML form
/// </summary>
function Web_CreateForm(strAction, strTarget, strArguments)
{
    // Create form    
    var objForm = document.createElement("FORM");
    objForm.target = strTarget;
    objForm.method = "post";
    objForm.action = strAction;
    objForm.style.display = "none";

    // Check if there are arguments
    if (strArguments != null)
    {
        // Split arguments string
        var arrArguments = strArguments.split("&");

        // Loop all arguments
        for (var intIndex = 0; intIndex < arrArguments.length; intIndex++)
        {
            // Split argument value
            var arrArgument = arrArguments[intIndex].split("=");

            // Check valid argument
            if (arrArgument.length == 2)
            {
                // Create a new form intput for argument
                Web_CreateFormInput(objForm, arrArgument[0], unescape(arrArgument[1]));
            }
        }
    }

    // Return the created form
    return objForm;
}
/// </method>

/// <method name="Web_CreateFormInput">
/// <summary>
/// Creates a new HTML form input
/// </summary>
function Web_CreateFormInput(objForm,strName,strValue)
{
    var objFormInput = document.createElement("INPUT");
    objFormInput.type = "hidden";
    objFormInput.name = strName;
    objFormInput.value = strValue;
    objForm.appendChild(objFormInput);
}
/// </method>

/// <method name="Web_SubmitForm">
/// <summary>
/// Submits an HTML form
/// </summary>
function Web_SubmitForm(objForm)
{
    document.body.appendChild(objForm);
    objForm.submit();    
    document.body.removeChild(objForm);
}
/// </method>

/// <method name="Web_IsEventSourceElement">
/// <summary>
/// If the current element is the event source
/// </summary>
/// <param name="objEvent"></param>
function Web_IsEventSourceElement(objEvent, objElement)
{
    return Web_GetEventSourceElement(objEvent) == objElement;
}
/// </method>

/// <method name="Web_CreatePostString">
/// <summary>
/// Creates a post string from a hash object
/// </summary>
/// <param name="objFields"></param>
function Web_CreatePostString(objFields)
{
    // Create buffer
    var objBuffer = [];
    
    // If there are fields
    if(objFields!=null)
    {
        for(var strField in objFields)
        {
            objBuffer.push(strField+"="+escape(objFields[strField]));
        }
    }
    
    // Return post string
    return objBuffer.join("&");
}
/// </method>

/// <sumary>
/// Holds the recording transfer target object
/// </sumary>
var mobjTransferTarget 		= null;

/// <sumary>
/// Holds a "delegate" to the callback function
/// </sumary>
var mfncTransferCallback 	= null;

/// <sumary>
///
/// </sumary>
var mobjTransferSource		= null;

/// <sumary>
/// Recording timeout
/// </sumary>
var mintTransferTimeout		= null;

/// <sumary>
/// Transfer callback arguments
/// </sumary>
var mobjTransferCallbackArgs        = null;

/// <sumary>
/// Saves a transfered character between key-down and key-up events
/// </sumary>
var mstrTransferString  = null;

/// <method name="Web_TransferKeyDown">
/// <summary>
/// Records a string value assembled of the keys pressed in a short period
/// </summary>
function Web_TransferKeyDown(objTransferSource,objTransferWindow,fncTransferCallback,objTransferCallbackArgs)
{
	// Set default transfer input
	mobjTransferTarget = objTransferWindow.document.getElementById("VWG_TransferTarget");
	
	// If there is a transfer keydown input box
	if(mobjTransferTarget)
	{
	    // Set transfer callback
	    mfncTransferCallback =fncTransferCallback;
    	
	    // Set transfer callback arguments
	    mobjTransferCallbackArgs = objTransferCallbackArgs;
    	
	    // Set transfer source
	    mobjTransferSource = objTransferSource;
    	
	    // Clear previous timeout
	    Web_ClearTimeout(mintTransferTimeout,window);
    	
	    // Set timeout
	    mintTransferTimeout = Web_SetTimeout("mobjApp.Web_TransferInvoke()",500,objTransferWindow);
    	
	    // Transfer focus
	    if(mobjTransferTarget)
	    {
	        // Grab the cliked value
	        mstrTransferString = mobjTransferTarget.value;
	        
	        // Clear the target object's character
	        mobjTransferTarget.value = "";
	        
	        // Set focus to target object
		    mobjTransferTarget.focus();
	    }
	}
}
/// </method>

/// <method name="Web_TransferKeyUp">
/// <summary>
/// Concat the string value assembled of the keys pressed in a short period after
/// key up event (accomulative).
/// </summary>
function Web_TransferKeyUp()
{
	// Transfer focus back to source
	if(mobjTransferSource)
	{
		try
		{
		    // Set the target value to be the old target value + new clicked character
		    mobjTransferTarget.value = mstrTransferString + mobjTransferTarget.value;
		    
		    // Clear the saved transfer char
		    mstrTransferString = null;
		    
		    // Set the focus back on the source object
		    mobjTransferSource.focus();
		    
		}catch(e){}
	}
}
/// </method>

/// <method name="Web_TransferInvoke">
/// <summary>
/// Invokes the transfer callback function after recording is done
/// </summary>
function Web_TransferInvoke()
{
	// Transfer focus back to source
	if(mfncTransferCallback)
	{
        // Call transfer method - safe
		try
		{
    	    // Call the callback method with the current value
		    mfncTransferCallback(mobjTransferCallbackArgs,mobjTransferTarget.value,mobjTransferSource);
		}
		catch(e){}
		
		// Clear transfer target - fafe
		try{mobjTransferTarget.value = "";}catch(e){}
		
		// Clear all transfer objects
		mfncTransferCallback = mobjTransferSource = mobjTransferTarget = mobjTransferCallbackArgs = null;
	}
}
/// </method>

/// <method name="Web_IsNavigationKey">
/// <summary>
/// Validates that KeyCode is a navigation key
/// Left, right, up, down, pageup, pagedown, home, end
/// </summary>
function Web_IsNavigationKey(intKeyCode)
{
	if([mcntUpKey,mcntDownKey,mcntPageUpKey,mcntPageDownKey,mcntHomeKey, 
	        mcntEndKey,mcntLeftKey,mcntRightKey].contains(intKeyCode))
	{
	    return true;
	}
}

/// <summary>
/// Validates that KeyCode is an arrow key
/// Left, right, up, down
/// </summary>
function Web_IsArrowKey(intKeyCode)
{
	if([mcntUpKey,mcntDownKey,mcntEndKey,mcntLeftKey,mcntRightKey].contains(intKeyCode))
	{
	    return true;
	}
}


/// <method name="Web_OnMouseWheel">
/// <summary>
/// 
/// </summary>
function Web_OnMouseWheel(objEvent)
{
    // Get the event's source element.
    var objSourceElement = Web_GetEventSourceElement(objEvent);
    if(objSourceElement)
    {
        // Emulate mouse wheel.
        Web_EmulateMouseWheel(objSourceElement,objEvent);
        
        // Get the vwg source element.
        var objVwgElement = Web_GetVwgElement(objSourceElement, true);
        if(objVwgElement)
        {   
            // Get vwg element id.
            var strGuid = Data_GetDataId(objVwgElement.id);
            
            // Check if source element has connected popup element - otherwise hide main popup box.
            if(!Popups_ShareFocusWithExistPopup(strGuid))
            {
                Popups_HidePopups(objSourceElement);
            }
        }
    }
}
/// </method>

/// <method name="Web_HandleMouseDownFocusing">
/// <summary>
/// 
/// </summary>
function Web_HandleMouseDownFocusing(objWindow,objEvent,objMouseDownSourceElement,strMouseDownSourceDataId,blnOccuredWithinClientArea)
{
    // Get current focus element id.
    var strFocusElementDataId = Focus_GetFocusElementDataId();
    if(!Aux_IsNullOrEmpty(strFocusElementDataId))
    {
        // Check that current focus element is not the mouse down source element.
        if(strFocusElementDataId!=Data_GetDataOwnerId(strMouseDownSourceDataId))
        {
            // Trigger focus out handler of the focus element.
            Web_TriggerFocusOutHandler(strFocusElementDataId);
        }
    }
    
    // Get current active window.
    var strPreviousActiveWindow = mstrActiveWindowGuid;
    
    // Execute focusing on mouse down source element.
    if(Focus_SetFocus(objMouseDownSourceElement))
    {
        // Get mouse down VWG source element.
        var objMouseDownVwgSourceElement = Web_GetElementByDataId(strMouseDownSourceDataId,objWindow);
        if(objMouseDownVwgSourceElement)
        {
            // Define a function which will handle the mouse down source element's click event.
            var fncClickHandler = function(objClickEvent) {
                
                // Unbind this click handler.
                $(this).unbind("click", fncClickHandler);
                
                // Stop event's propogation.
                objClickEvent.stopPropagation();
            };
            
            // Bind a click handler to the mouse down source element.
            $(objMouseDownVwgSourceElement).bind("click", fncClickHandler);
        }
        
        // Enforce on click handling so that focus and blur events will be raised in same post back.
        Web_OnClick(objEvent,objWindow,true);
    }
    
    // Get the new focus element id.
    strFocusElementDataId = Focus_GetFocusElementDataId();
    
    // Check that:
    // 1. the system configure to preserve focus element
    // 2. Mouse down has occured whithin client area.
    // 3. Focused element is entirely visible.
    // 4. Source element does not support label editing.
    // 5. Active form did not change.
    // 6. Focused element is different from the mouse down source element.
    // 7. The mouse down source element is not focusable.
    if( mblnPreserveFocusElement &&
        blnOccuredWithinClientArea &&
        Web_IsElementEntirelyVisible(strFocusElementDataId,objWindow) && 
        !Web_IsAttribute(objMouseDownSourceElement,"vwglabeledit","1",true) &&
        strPreviousActiveWindow==mstrActiveWindowGuid && 
        strFocusElementDataId!=Data_GetDataOwnerId(strMouseDownSourceDataId) &&
        !Data_IsAttribute(strMouseDownSourceDataId,"Attr.Focus","1"))
    {
        // Set focus on current focus element.
	    Web_SetFocusByDataId(strFocusElementDataId);
    }
}
/// </method>

/// <method name="Web_IsElementEntirelyVisible">
/// <summary>
/// 
/// </summary>
function Web_IsElementEntirelyVisible(strDataID,objWindow)
{
    // Vaidatre recieved arsuments.
    if(!Aux_IsNullOrEmpty(strDataID) && objWindow)
    {
        // Get handled element.
        var objElement = Web_GetElementByDataId(strDataID,objWindow);
        if(objElement)
        {
            // Get handled element's rect.
            var objElementRect = Web_GetRect(objElement);
            if(objElementRect)
            {
                // Get handled element's parent.
                var objParentElement = objElement.parentNode;
                if(objParentElement)
                {
                    // Get parent element's rect.
                    var objParentElementRect = Web_GetRect(objParentElement);
                    if(objParentElementRect)
                    {
                        // Check if handled element is entirely visible.
                        return  objElementRect.top>=objParentElementRect.top && 
                                objElementRect.bottom<=objParentElementRect.bottom &&
                                objElementRect.left>=objParentElementRect.left &&
                                objElementRect.right<=objParentElementRect.right;
                    }
                }
            }
        }
    }
    
    return false;
}
/// </method>

/// <method name="Web_HandleLabelEdit">
/// <summary>
/// 
/// </summary>
function Web_HandleLabelEdit(objEvent,objWindow)
{
    // Get the event's source element.
    var objSourceElement = Web_GetEventSourceElement(objEvent);
    if(objSourceElement)
	{
	    // Check if source element supports label editing.
	    if(Web_IsAttribute(objSourceElement,"vwglabeledit","1",true))
	    {
	        // Get the VWG source element.
            var objVwgSource = Web_GetVwgElement(objSourceElement,true,false,true);
            if(objVwgSource)
            {
                // Get vwg source element data id.
                var strVwgSourceDataId = Data_GetDataId(objVwgSource.id);
                if(!Aux_IsNullOrEmpty(strVwgSourceDataId))
                {
                    // Begin edit.
                    LabelEditor_Show(strVwgSourceDataId,objWindow);
                }
	        }
	    }
    }
}
/// </method>

/// <method name="Web_OnMouseDown">
/// <summary>
/// 
/// </summary>
function Web_OnMouseDown(objEvent, objWindow)
{
    // Get the event's source element.
    var objSourceElement = Web_GetEventSourceElement(objEvent);
    if (objSourceElement)
    {
        // Get the VWG source.
        var objVwgSource = Web_GetVwgElement(objSourceElement, true, false, true);
        if (objVwgSource)
        {
            // Get vwg source element id.
            var strVwgSourceId = objVwgSource.id;

            // Check that source element is not the one of loading box's.
            if (strVwgSourceId != "VWG_LoadingAnimationBox" && strVwgSourceId != "VWG_LoadingScreen")
            {
                // Get vwg element id.
                var strDataId = Data_GetDataId(strVwgSourceId);

                // Check if source element has connected popup element - otherwise hide main popup box.
                if (!Popups_ShareFocusWithExistPopup(strDataId))
                {
                    Popups_HidePopups(objSourceElement);
                }

                // Define a client area switch.
                var blnOccuredWithinClientArea = true;

                // Get source element client rectangle.
                var objSourceRect = Web_GetRect(objSourceElement, true);
                if (objSourceRect)
                {
                    // Check if client rectangle is not empty.
                    if (objSourceRect.right != objSourceRect.left && objSourceRect.bottom != objSourceRect.top)
                    {
                        // Get mouse curssor point.
                        var objPoint = Web_PointFromEvent(objEvent);
                        if (objPoint)
                        {
                            // Check if mouse down was performed over client area.
                            blnOccuredWithinClientArea = (objPoint.left < objSourceRect.right && objPoint.top < objSourceRect.bottom);
                        }
                    }
                }

                // Set handle mouse down focusing.
                Web_SetTimeout(function ()
                {
                    Web_HandleMouseDownFocusing(objWindow, objEvent, objSourceElement, strDataId, blnOccuredWithinClientArea);
                }, 20);

                // Check if mouse down has occured whithin client area.
                if (blnOccuredWithinClientArea)
                {
                    // Check that no other drag & drop is already active    
                    if (!mobjDragSubject)
                    {
                        // Get drag descriptor.
                        var objDragData = Drag_GetDragDescriptor(objSourceElement, objWindow);
                        if (objDragData)
                        {
                            Drag_RegisterDragElement(objDragData.DragSource, mcntDragMoveFree, objWindow, objEvent, Drag_OnDrop, null, null, true, Drag_OnMove, 30);
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Web_SetElementProperty">
/// <summary>
/// Set element property using week element reference
/// </summary>
/// <param name="objWindow">The container window.</param>
/// <param name="strElementId">The element ID.</param>
/// <param name="strElementProperty">The element property to be set.</param>
/// <param name="strValue">The element property value to be set.</param>
function Web_SetElementProperty(objWindow,strElementId,strElementProperty,strValue)
{
    var objElement = objWindow.$$(strElementId);
    if(objElement!=null)
    {
        objElement[strElementProperty] = strValue;
    }
}
/// </method>

/// <method name="Web_SetElementPropertyByNode">
/// <summary>
/// Set element property using week element reference from node
/// </summary>
/// <param name="objWindow">The container window.</param>
/// <param name="strElementId">The element ID.</param>
/// <param name="strElementProperty">The element property to be set.</param>
/// <param name="objNode">The node to get the property value from.</param>
/// <param name="strAttribute">The node attribute to get the property value from.</param>
function Web_SetElementPropertyByNode(objWindow,strElementId,strElementProperty,objNode,strAttribute)
{
    // Get image element and change image source
    var objElement = objWindow.$$(strElementId);
    if(objElement!=null)
    {
        objElement[strElementProperty] = Xml_GetAttribute(objNode,strAttribute);
    }   
}
/// </method>

/// <method name="Web_SetElementsDisplay">
/// <summary>
/// Loops the elements collection in the first argument and sets display to none to elements
/// which are not the element sent in the second arguments.
/// </summary>
/// <param name="objElements">An array of elements to set their display value.</param>
/// <param name="objElement">The element that should bel visible.</param>
function Web_SetElementsDisplay(objElements,objElement)
{
     // Loop all elements
    for(var intIndex=0;intIndex<objElements.length;intIndex++)
    {
        // Get current element
        var objCurrentElement = objElements[intIndex];
        
        // If is current tab
        if(objCurrentElement != objElement)
        {
            objCurrentElement.style.display='none';
        }
    }
    
    if(objElement!=null)
    {
        // Set tab visible
        objElement.style.display='block';
    }
}
/// </method>

/// <method name="Web_ScrollIntoView">
/// <summary>
/// Scrolls the received element's parent in order to show the element.
/// intMode = {0 - Both horizontal and vertical scrolling ; 1- Vertical scrolling. ; 2 - horizontal scrolling.}
/// </summary>
function Web_ScrollIntoView(objElement,objParent,intMode)
{
    if(objElement)
    {
        if(!objParent)
        {
            // Get the element's parent.
            objParent = Web_GetScrollableParent(objElement);
        }
        
        if(objParent)
        {
            // Gets element's and parent's locations.
            var objElementRect = Web_GetRect(objElement);
            var objParentRect = Web_GetRect(objParent,true);

            Web_ScrollIntoViewByRect(objElement,objElementRect,objParent,objParentRect,intMode);
        }
    }
}
/// </method>


/// <method name="Web_ScrollIntoViewByRect">
/// <summary>
/// Scrolls the received element's parent in order to show the element.
/// intMode = {0 - Both horizontal and vertical scrolling ; 1- Vertical scrolling. ; 2 - horizontal scrolling.}
/// </summary>
function Web_ScrollIntoViewByRect(objElement,objElementRect,objParent,objParentRect,intMode)
{
    // Set default value to vertical scrolling.
    if(intMode == null)
    {
        intMode = 1;
    }
    
	// Validate recieved arguments.
    if(objElement && objParent && objElementRect && objParentRect)
    {
        // Define delta variables with defaults values.
        var intScrolX = 0;
        var intScrolY = 0;
        
        if(intMode==0 || intMode==1)   
        {       
            // Checks if the receieved element is out of bound in Y scale.
            if(objParentRect.top>objElementRect.top)
            {
                // Get vartical scrolliong delta.
                intScrolY = (objElementRect.top-objParentRect.top);
            }
            else if(objParentRect.bottom<objElementRect.bottom)
            {
                // Get vartical scrolliong delta.
                intScrolY = (objElementRect.bottom-objParentRect.bottom);
            }
            
            // Scroll top/bottom.
            if(intScrolY!=0)
            {
                objParent.scrollTop += intScrolY;
            }
        }
        
        // Checks if the receieved element is out of bound in X scale.
        if(intMode==0 || intMode==2)   
        {          
            // Checks if the receieved element is out of bound in X scale.
            if(objParentRect.left>objElementRect.left)
            {
                // Get horizental scrolliong delta.
                intScrolX = (objElementRect.left-objParentRect.left);
            }
            else if(objParentRect.right<objElementRect.right)
            {
                // Get horizental scrolliong delta.
                intScrolX = (objElementRect.right-objParentRect.right);
            }
            
            // Scroll left/right.
            if(intScrolX!=0)
            {
                objParent.scrollLeft += intScrolX;
            }
        }
    }
}
/// </method>

/// <method name="Web_IsWindow">
/// <summary>
/// 
/// </summary>
/// <param name="objEvent"></param>
function Web_IsWindow(objWindow)
{
     return (objWindow && objWindow.setTimeout!=null);
}
/// </method>

function Web_GetWindowFromObject(objWindow)
{
    if(objWindow!=null)
    {
        if(Web_IsWindow(objWindow))
        {
            return objWindow;
        }
        else
        {            
            if(objWindow.document)
            {
                return objWindow.document.parentWindow;
            }
            else if (objWindow.ownerDocument)
            {                                  
              return objWindow.ownerDocument.defaultView;               
            }
            
        }
    }
}

/// <method name="Web_SetDisplayBlock">
/// <summary>
/// Sets the display value of the specified element
/// </summary>
/// <param name="objElement">The element to set it's display value.</param>
/// <param name="blnDisplay">The flag that indicates if to put 'display' or 'none'.</param>
function Web_SetDisplayBlock(objElement,blnDisplay)
{
    // If there is a valid element
    if(objElement)
    {
        // If there is a valid element style
        if(objElement.style)
        {
            objElement.style.display = blnDisplay ? "block" : "none";
        }
    }
}
/// </method>

/// <method name="Web_SetBackgroundImage">
/// <summary>
/// Sets the background image of the specified element
/// </summary>
/// <param name="objElement">The element to set it's background image.</param>
/// <param name="strFind">The string to find with in the background image.</param>
/// <param name="strReplace">The string to replace with in the backgound image.</param>
function Web_ReplaceBackgroundImage(objElement, strFind, strReplace)
{
    // Get the current background image
    var  strImage = Web_GetBackgroundImage(objElement);
    
    // Replace the image string
    strImage = strImage.replace(strFind,strReplace);
    
    // Set the new background image
    Web_SetBackgroundImage(objElement,strImage);
}
/// </method>

/// <method name="Web_SetBackgroundImage">
/// <summary>
/// Sets the background image of the specified element
/// </summary>
/// <param name="objElement">The element to set it's background image.</param>
/// <param name="strImage">The background image to set.</param>
function Web_SetBackgroundImage(objElement,strImage)
{
    // If there is a valid element and image string
    if(objElement && strImage)
    {
        // If there is a valid element style
        if(objElement.style)
        {
            // If image does not contain the url format
            if(strImage.indexOf("url(")==-1)
            {
                // Add the url format
                strImage = "url(" + strImage + ")";
            }
            
            // Set the background image
            objElement.style.backgroundImage = strImage;
        }
    }
}
/// </method>

/// <method name="Web_GetBackgroundImage">
/// <summary>
/// Gets the background image of the specified element
/// </summary>
/// <param name="objElement">The element to get it's background image.</param>
function Web_GetBackgroundImage(objElement)
{
    var strImage = "";

    // If there is a valid element 
    if(objElement)
    {
        // If there is a valid element style
        if(objElement.style)
        {
            // Get the image value
            strImage = objElement.style.backgroundImage;
        }
    }
    
    return strImage;   
}
/// </method>

/// <method name="Web_IsActiveWindow">
/// <summary>
/// Checks if the window is active
/// </summary>
/// <param name="objWindow">The browser window object.</param>
function Web_IsActiveWindow(objWindow)
{
    return Web_GetActiveWindow()==objWindow;
}
/// </method>

/// <summary>
/// The ticks offset from year 1901 to year 1.
/// </summary>
 var mlngDateTicksOffset = (new Date(1,0,1,24,0,0)).setFullYear(1,0,1);
    
/// <method name="Web_GetTicksFromDate">
/// <summary>
/// Gets the ticks from a given date object.
/// </summary>
/// <param name="objDate">The date to convert to ticks.</param>
function Web_GetTicksFromDate(objDate)
{
    return (Number(objDate) + Web_GetDaylightSavingTimeOffset(objDate) - mlngDateTicksOffset) * 10000;
}
/// </method>
        
/// <method name="Web_GetDateFromTicks">
/// <summary>
/// Gets the date object from a given ticks value.
/// </summary>
/// <param name="lngTicks">The ticks to convert to date.</param>
function Web_GetDateFromTicks(lngTicks)
{
    // Create a date object based on received ticks.
    var objDate = new Date(mlngDateTicksOffset + lngTicks / 10000);
    
    // Get day light saving time offset.
    var intDaylightSavingTimeOffset = Web_GetDaylightSavingTimeOffset(objDate);
    
    // In case that there is'nt a day light saving time offset.
    if(intDaylightSavingTimeOffset==0)
    {
        // Return created date.
        return objDate;
    }
    else
    {    
        // Create a new date object based on received ticks and day light saving time offset.
        return new Date(Number(objDate)-intDaylightSavingTimeOffset);
    }
}
/// </method>


/// <method name="Web_GetModalWindowBox">
/// <summary>
/// 
/// </summary>
function Web_GetModalWindowBox(blnMaskedBox)
{
    // Return the modal window box element.
    return mblnFullScreenMode ? Web_GetBodyContentElement(window) : Web_GetElementById(blnMaskedBox?"VWG_MaskedModalWindowBox":"VWG_TransparentModalWindowBox",window);    
}
/// </method>

/// <method name="Web_GetMasterPageContentElement">
/// <summary>
/// 
/// </summary>
function Web_GetMasterPageContentElement()
{
    var objMasterPageContent = vwgContext.provider.getComponentByClientId("MasterPageContent");
    if (!objMasterPageContent) { return undefined; }

    var objMasterPageContentElement = Web_GetElementByDataId(objMasterPageContent.id(), window);
    return objMasterPageContentElement;
}
/// </method>

/// <method name="Web_GetTaskBarBox">
/// <summary>
/// 
/// </summary>
function Web_GetTaskBarBox()
{
    if(!mobjTaskBarBox)
    {
        mobjTaskBarBox = Web_GetContextElementById(window.document.body,"VWG_TaskBarBox");
    }
    
    return mobjTaskBarBox;
}
/// </method>

/// <method name="Web_GetMainWindowAvailableSize">
/// <summary>
/// 
/// </summary>
function Web_GetMainWindowAvailableSize(intOffsetWidth,intOffsetHeight)
{
    // Get body's client sizes.
    var intWidth=window.document.body.clientWidth;
    var intHeight=window.document.body.clientHeight;
    
    // Adapt offset width.
    if(!Aux_IsNullOrEmpty(intOffsetWidth))
    {
        intWidth+=intOffsetWidth;
    }
    
    // Adapt offset height.
    if(!Aux_IsNullOrEmpty(intOffsetHeight))
    {
        intHeight+=intOffsetHeight;
    }
    
    if(mblnInlineWindows)
    {
        // Get the task bar box.
        var objTaskBarBox = Web_GetTaskBarBox();
        if(objTaskBarBox && objTaskBarBox.style.display!="none")
        {
            // Decrease taskbar height.
            intHeight-=objTaskBarBox.clientHeight;
        }
    }
    
    // Return the new size sturcture.
    return {Width:intWidth,Height:intHeight};
}
/// </method>

/// <method name="Web_SetInputSelection">
/// <summary>
/// 
/// </summary>
function Web_SetInputSelection(objInput,intDelayTime)
{
    // Validate recieved delay time.
    if(!Aux_IsNullOrEmpty(intDelayTime))
    {
        // Asyncronic execution of Web_DoSetInputSelection.
        Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Web_DoSetInputSelection,objInput),intDelayTime);
    }
    else
    {
        // Syncronic execution of Web_DoSetInputSelection.        
        Web_DoSetInputSelection(objInput);
    }
}
/// </method>

/// <method name="Web_SetInputSelection">
/// <summary>
/// 
/// </summary>
function Web_DoSetInputSelection(objInput)
{
    // Select full text
	if(objInput && objInput.select)
	{
        objInput.select();
    }
}
/// </method>

/// <method name="Web_GetRelativePoint">
/// <summary>
/// 
/// </summary>
function Web_GetRelativePoint(objElement, objPoint)
{
        
    // Define x and y coordination variables.
    var intX = 0;
    var intY = 0;
    
    // If there is a valid element and point
    if(objElement && objPoint)
    {
        // Get element rectangle
        var objRect = Web_GetRect(objElement);
        if(objRect)
        {
            intX = Math.ceil(objPoint.left - objRect.left);
            intY = Math.ceil(objPoint.top - objRect.top);
        }
    }
    
    // Get relative point
    return {left:intX, top:intY};
}
/// </method>

/// <method name="Web_IsRightClick">
/// <summary>
/// Returns true if the button that was clicked in the event is the Right button.
/// </summary>
/// <param name="objEvent">The current event.</param>     
function Web_IsRightClick(objEvent)
{
   if (objEvent)
   {
        if (objEvent.button == 2)
        {
            return true;
        }
   }
   return false;
}
/// </method>

/// <method name="Web_ErrorProviderBlink">
/// <summary>
/// Blink the image of the error provider.
/// </summary>
/// <param name="strGuid">the image element guid.</param>
/// <param name="objElement">image element.</param>
/// <param name="intDelay">blink delay.</param>
/// <param name="intLoop">number of blinks.</param>
function Web_ErrorProviderBlink(strGuid, objElement,intDelay,intLoop)
{   
    // Create array of styles
    if(!Web_ErrorProviderBlink.mobjElementStyles)
    {
        Web_ErrorProviderBlink.mobjElementStyles = {};
    }
    // Store the current element style in the array
    Web_ErrorProviderBlink.mobjElementStyles[strGuid] = objElement.style;
    
    // Set time out to the blinking mehtod
    Web_SetTimeout("mobjApp.Web_ErrorProviderDoBlink('"+strGuid+"',"+intDelay+",+"+intLoop*2+")",intDelay);                    
}
/// </method>

/// <method name="Web_ErrorProviderDoBlink">
/// <summary>
/// Blink the image of the error provider.
/// </summary>
/// <param name="strGuid">the image element guid.</param>
/// <param name="intDelay">blink delay.</param>
/// <param name="intLoop">number of blinks.</param>
function Web_ErrorProviderDoBlink(strGuid,intDelay,intLoop)
{
    // Get the blinking image style
    var objElementStyle = Web_ErrorProviderBlink.mobjElementStyles[strGuid];
    if(objElementStyle)
    {
        // Switch visibility
        objElementStyle.visibility = ( objElementStyle.visibility == "visible" )? "hidden" : "visible";
        
        if(intLoop>0)    
        {
            // Decrease loop counter.
            intLoop--;

            // Set another time out to the blinking mehtod
            Web_SetTimeout("mobjApp.Web_ErrorProviderDoBlink('"+strGuid+"',"+intDelay+",+"+intLoop+")",intDelay);
        }
        else
        {
            // Clear style from the array 
            delete Web_ErrorProviderBlink.mobjElementStyles[strGuid];
        }
    }
}
/// </method>

/// <method name="Web_SetFocusByDataId">
/// <summary>
/// 
/// </summary>
function Web_SetFocusByDataId(strDataId,blnAsynchronic)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strDataId))
    {
        // Get focus element by data id.
        var objFocusElement = Controls_GetFocusElementByDataId(strDataId);
        if(objFocusElement)
        {
            // Set focus on focus element.
            Web_SetFocus(objFocusElement,blnAsynchronic);
        }
    }
}
/// </method>

/// <method name="Web_SetFocus">
/// <summary>
/// Sets focus to a given element
/// </summary>
/// <param name="objElement">The element to set focus to.</param>
function Web_SetFocus(objElement,blnAsynchronic)
{
    if(objElement)
    {
        // Check whether the focus element is Focusable.
        if(Web_IsFocusableElement(objElement))
        {
            if(blnAsynchronic)
            {
                // Perform a delayed call to the function which execute the focus.
                Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Web_DoSetFocus,objElement),200);
            }
            else
            {
                // Perform a call to the function which execute the focus.
                Web_DoSetFocus(objElement);
            }
        }
    }
}
/// </method>

/// <method name="Web_DoSetFocus">
/// <summary>
/// Sets focus to a given element
/// </summary>
function Web_DoSetFocus(objFocusElement)
{
    // Validate focus element.
    if(objFocusElement && objFocusElement.tagName)
    {
        // Some mobile browsers show the Virtual Keyboard when focusing a text input via JavaScript - we want to prevent that.
        if (!(["input", "textarea"].contains(objFocusElement.tagName.toLowerCase()) && Web_SupportsMISCBrowserCapability(1024)))
        {
            // Execute focus function.
            $(objFocusElement).focus();
        }
    }
}
/// </method>

/// <method name="Web_SetInnerHtml">
/// <summary>
/// Sets the element inner html
/// </summary>
/// <param name="objElement">The element to set it's html.</param>
/// <param name="strHtml">The html to set.</param>
function Web_SetInnerHtml(objElement,strHtml)
{
    objElement.innerHTML = strHtml;
    $(objElement).completeMissingAccessibilityEvents();
}
/// </method>

/// <method name="Web_BlurByDataId">
/// <summary>
/// 
/// </summary>
function Web_BlurByDataId(strDataId,blnAsynchronic)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strDataId))
    {
        // Get focus element by data id.
        var objFocusElement = Controls_GetFocusElementByDataId(strDataId);
        if(objFocusElement)
        {
            // Blurs the focus element.
            Web_Blur(objFocusElement,blnAsynchronic);
        }
    }
}
/// </method>

/// <method name="Web_Blur">
/// <summary>
/// Blurs a given element
/// </summary>
/// <param name="objElement">The element to be blured.</param>
function Web_Blur(objElement,blnAsynchronic)
{
    if(objElement)
    {
        // Check whether the focus element is Focusable.
        if(Web_IsFocusableElement(objElement))
        {
            // Set element memory
            Web_Blur.BlurElement = objElement;
            
            if(blnAsynchronic)
            {
                // Perform asynchronic blur.
                Web_SetTimeout("mobjApp.Web_DoBlur()",200);
            }
            else
            {
                // Perform synchronic blur.
                Web_DoBlur();
            }
        }
    }
}
/// </method>

/// <method name="Web_DoBlur">
/// <summary>
/// Blurs to a given element
/// </summary>
function Web_DoBlur()
{
    // If has element in memory
    if(Web_Blur.BlurElement)
    {
        // Check if the blur function exists.
        if(Web_Blur.BlurElement.blur)
        {            
            Web_Blur.BlurElement.blur(); 	        
	    }
	    
	    // Clear last blur element.
	    Web_Blur.BlurElement = null;
	}
}
/// </method>

/// <method name="Web_GetMainWindow">
/// <summary>
/// 
/// </summary>
function Web_GetMainWindow()
{
    if(mblnDebugEvents)
    {
        return mobjApp.parent;
    }
    else
    {
        return mobjApp;        
    }
}
/// </method>

/// <method name="Web_GetDocumentLocation">
/// <summary>
/// 
/// </summary>
function Web_GetMainWindowLocation()
{
    // Get main window.
    var objMainWindow = Web_GetMainWindow();
    if(objMainWindow)
    {
        // Return document location.
        return objMainWindow.document.location.href;
    }
}
/// </method>

/// <method name="Web_SetMainWindowLocation">
/// <summary>
/// 
/// </summary>
function Web_SetMainWindowLocation(strDocumentLocation)
{
    // Get main window.
    var objMainWindow = Web_GetMainWindow();
    if(objMainWindow)
    {
        // Set document location.
        objMainWindow.document.location.href = strDocumentLocation;
    }
}
/// </method>

/// <method name="Web_SubmitHostedForm">
/// <summary>
/// 
/// </summary>
function Web_SubmitHostedForm(strGuid, strEventArgument)
{	
	// Get the VWG element.
    var objElement = Web_GetElementByDataId(strGuid);
    if(objElement)
    {
		// Get the contained IFRAME element.
        var objIFrame = Web_GetContextElementById(objElement,"TRG_"+strGuid);
        if(objIFrame && objIFrame.contentWindow && objIFrame.contentWindow.vwg_pipeline_submit)
        {
			// Submit pipeline form.
            objIFrame.contentWindow.vwg_pipeline_submit(strEventArgument);
        }
    }
} 
/// </method>

/// <method name="Web_GetWindowsBox">
/// <summary>
/// 
/// </summary>
function Web_GetWindowsBox(strWindowsBoxId)
{
    // In full screen, there might be master page or not.
    if (mblnFullScreenMode)
    {
        var objMasterPageContentElement = Web_GetMasterPageContentElement();
        if (objMasterPageContentElement)
        {
            return objMasterPageContentElement;
        }
        else
        {
            return Web_GetBodyContentElement(window);
        }
    }
    else if (!Aux_IsNullOrEmpty(strWindowsBoxId))
    {
        return Web_GetElementById("VWGE_WindowsBox" + strWindowsBoxId, window);
    }
    else
    {
        return Web_GetElementById("VWGE_WindowsBox", window);
    }
}
/// </method>

/// <method name="Web_GetBodyContentElement">
/// <summary>
/// Gets window BodyContent element.
/// </summary>
function Web_GetBodyContentElement(objWindow)
{    
   return Web_GetElementById("VWG_BodyContent", objWindow || window);   
}
/// </method>

/// <method name="Web_OnBlur">
/// <summary>
/// 
/// </summary>
function Web_OnBlur(objEvent)
{
    mobjApp.Drag_HideDragElement(objEvent);
}
/// </method>

/// <method name="Web_RegisterFocus" access="private">
/// <summary>
/// Registers focus.
/// </summary>
function Web_RegisterFocus(objElement)
{   
    if(objElement)
	{   
        // Attach a focus event handler to the element.
        Web_AttachEvent(objElement,mcntIsIE?"focusin":"focus",Web_OnFocus);
	}
}
/// </method>

/// <method name="Web_UnRegisterFocus" access="private">
/// <summary>
/// Registers focus.
/// </summary>
function Web_UnRegisterFocus(objElement)
{   
    if(objElement)
	{   
        // Deattach a focus event handler to the element.
        Web_DetachEvent(objElement,mcntIsIE?"focusin":"focus",Web_OnFocus);
	}
}
/// </method>

/// <method name="Web_GetGatewayUrl" access="private">
/// <summary>
/// Returns a gateway url as for recieved arguments.
/// </summary>
function Web_GetGatewayUrl(blnStatelessMode,strPageName,strPageInstance,strComponentId,strAction,strQueryString)
{   
    // Set component prefix.
    var strGatewayUrl=(blnStatelessMode?"Stateless":"")+"Component.";

    // Set page name and page instance.
    strGatewayUrl+=(strPageName+"."+strPageInstance+".");
    
    // Set component id, action.
    strGatewayUrl+=(strComponentId+"."+strAction+".wgx");
    
    // Set query string - if needed.
    if(!Aux_IsNullOrEmpty(strQueryString))
    {
        strGatewayUrl+=("?"+strQueryString);
    }
    
    // Retirn gateway url.
    return strGatewayUrl;
}
/// </method>

/// <method name="Web_GetRect">
/// <summary>
/// Gets an elements positioning rect
/// </summary>
/// <param name="objElement">The element to get it's positioning rect.</param>
/// <param name="blnClientArea">Indicates whether to return a client area rectangle.</param>
function Web_GetRect(objElement,blnClientArea)
{
    // Validate recieved element.
    if(objElement)
    {   
        // Get JQuery wrapped element.
        var objJQElement=$(objElement);
        if(objJQElement)
        {
            // Get element's offset object.
            var objOffset=objJQElement.offset();
            if(objOffset)
            {
                // Define empty recangle.
                var objRect = {};
                
                // Set rectangle's values.
                objRect.left = objOffset.left;
                objRect.top = objOffset.top;
                objRect.right = objRect.left + (blnClientArea?objElement.clientWidth:objElement.offsetWidth);
                objRect.bottom = objRect.top + (blnClientArea?objElement.clientHeight:objElement.offsetHeight);
                
                // Return rectangle.
                return objRect;
            }
        }
    }
	
	return null;
}
/// </method>

/// <method name="Web_ClearWindowErrorProviders">
/// <summary>
/// Clear the recieved window's error providers.
/// </summary>
/// <param name="strWindowDataId">The handled window data id.</param>
function Web_ClearWindowErrorProviders(strWindowDataId)
{   
    // Validate recieved window.
    if(!Aux_IsNullOrEmpty(strWindowDataId))
    {
        // Check if any error providers exists.
        if(Web_ErrorProviderBlink.mobjElementStyles)
        {
            // Loop all controls that has active error providers.
            for(var strControlDataId in Web_ErrorProviderBlink.mobjElementStyles)
            {
                // Get current control's form node.
                var objFormNode = Data_GetFormNodeByDataId(strControlDataId);
                if(objFormNode)
                {
                    // Check if current control's form equals to the recieved window.
                    if(Xml_IsAttribute(objFormNode,"Attr.Id",strWindowDataId))
                    {
                        // Delete current control's style element.
                        delete Web_ErrorProviderBlink.mobjElementStyles[strControlDataId];        
                    }
                }
            }
        }
    }
}
/// </method>


/// <method name="Web_IsTag">
/// <summary>
/// /// Checks if a the tag name is the sane as the string 
/// </summary>
/// <param name="objElement">The element to to test the tag name</param>
/// <param name="strTagName">The tag name</param>
function Web_IsTag(objElement, strTagName)
{
    //If we have an elment
    if (objElement && objElement.tagName)
    {        
        //test it the tag name is the saem as the string.
        if(objElement.tagName.toLowerCase() == strTagName.toLowerCase())
        {
           return true;
        }
    }   
    return false;
}
/// </method>

/// <method name="Web_GetClientSize">
/// <summary>
/// /// 
/// </summary>
/// <param name="objElement">The element to be messured.</param>
function Web_GetClientSize(objElement)
{
    // Validte recieved elment.
    if (objElement)
    {
        // Return client size.
        return {width:objElement.clientWidth,height:objElement.clientHeight};
    }
    
    // Return null.
    return null;
}
/// </method>

/// <method name="Web_PointFromEvent" access="private">
/// <summary>
/// Gets an Aux_Point from an event object
/// </summary>
/// <param name="objEvent">The browser event object.</param>
function Web_PointFromEvent(objEvent)
{
    // Validate recieved event.
    if(objEvent)
    {
        // Return a point as for client x and y (from recieved event object).
        return new Aux_Point(objEvent.clientX,objEvent.clientY);
    }
    
    return null;
}
/// </method>

/// <method name="Web_OnModalWindowBoxMouseDown" access="private">
/// <summary>
/// 
/// </summary>
function Web_OnModalWindowBoxMouseDown()
{
    // Set focus to the active window's (which is the restored inline window) focus element.
	Web_SetFocusByDataId(Focus_GetFocusElementDataId(),true);
}
/// </method>

/// <method name="Web_ContainsElement">
/// <summary>
/// Check whetehr the contained element is contained whithin the container element.
/// </summary>
function Web_ContainsElement(objContainerElement,objContainedElement)
{
    // Declare a flag which will indicate whetehr the contained element is contained
    // whithin the container element.
    var blnContainsElement = false;
 
    // Validate recieved arguemtns.
    if(objContainerElement && objContainedElement)           
    {
        // Loop while contained element is valid and not equal to the container element.
        while(!blnContainsElement && objContainedElement)
        {
            // Check if the contained element equals to the container element.
            if(objContainedElement==objContainerElement)
            {
                // Flag that contained element is contained whithin the container element.
                blnContainsElement=true;
            }
            else
            {
                // Move to the contained element's parent node.
                objContainedElement = objContainedElement.parentNode;
            }
        }
    }
    
    // Return result.
    return blnContainsElement;
}
/// </method>

/// <method name="Array.Web_GetQueryStringParams">
/// <summary>
/// Gets an query string values hashtable from a url.
/// </summary>
/// <param name="strUrl">The URL to extract params from.</param>
function Web_GetQueryStringParams(strUrl)
{
    var arrUrl = String(strUrl).split("?");
    var arrQuery = String((arrUrl.length==1)?arrUrl[0]:arrUrl[1]).split("&");
    var objQuery = {};
    for(var intIndex=0;intIndex<arrQuery.length;intIndex++)
    {
        var arrValue = String(arrQuery[intIndex]).split("=");
        objQuery[arrValue[0]]=arrValue[1];
    }
    return objQuery;
}
/// </method>

/// <method name="Array.Web_GetQueryStringParam">
/// <summary>
/// Gets an query string param value from a url.
/// </summary>
/// <param name="strUrl">The URL to extract params from.</param>
/// <param name="strParam">The param to extract.</param>
function Web_GetQueryStringParam(strUrl,strParam)
{
    return Web_GetQueryStringParams(strUrl)[strParam];
}
/// </method>

[Skin.WebSetStyleFunction]


/// <method name="Web_GetElementFromPoint">
/// <summary>
/// Gets the html element which is has the (intX,intY) poisition
/// </summary>
/// <param name="objWindow">The handled window.</param>
/// <param name="intX">The x position.</param>
/// <param name="intY">The y position.</param>
/// <param name="fncElementValidation">The validation function.</param>
function Web_GetElementFromPoint(objWindow,intX,intY)
{
    if  (objWindow && objWindow.document && 
        objWindow.document.elementFromPoint != undefined)
    {
        return objWindow.document.elementFromPoint(intX,intY);
    }
    
    return null;
}
/// </method>

/// <method name="Web_GetEventOffsetX">
/// <summary>
/// Gets the event offset X value
/// </summary>
/// <param name="objEvent">The browser event object.</param>
function Web_GetEventOffsetX(objEvent)
{
    if(objEvent.offsetX)
    {
        return objEvent.offsetX;
    }

    if(objEvent.layerX)
    {
        return objEvent.layerX;
    }

    return 0;
}
/// </method>

/// <method name="Web_GetEventOffsetY">
/// <summary>
/// Gets the event offset Y value
/// </summary>
/// <param name="objEvent">The browser event object.</param>
function Web_GetEventOffsetY(objEvent)
{
    if(objEvent.offsetY)
    {
        return objEvent.offsetY;
    }

    if(objEvent.layerY)
    {
        return objEvent.layerY;
    }

    return 0;
}
/// </method>

/// <method name="Web_SetSelectedTextValue">
/// <summary>
/// Sets the Selected Text Value
/// </summary>
/// <param name="objCharacter">The  Character object.</param>
function Web_SetSelectedTextValue(objEvent,objWindow,objCharacter)
{	 
        var oTR =   Web_GetEventSource(objEvent);
     	var start = oTR.value.substring(0, oTR.selectionStart);
		var end = oTR.value.substring(oTR.selectionEnd, oTR.value.length);
		var newRange = oTR.selectionEnd + 1;
		var scrollPos = oTR.scrollTop;
		oTR.value = start.concat(objCharacter, end);
		oTR.setSelectionRange(newRange, newRange);
		oTR.scrollTop = scrollPos;
}
/// </method>

/// <method name="Web_ScrollToCaret">
/// <summary>
/// Scrolls to caret.
/// </summary>
function Web_ScrollToCaret(objElement)
{
    // TODO: No text range in FF and as for that the TextArea should scroll into view of its caret
    //       differnetly.
}
/// </method>

/// <method name="Web_GetOuterHtml" access="private">
/// <summary>
/// Sets outer HTML code to a specific element
/// </summary>
/// <param name="objWindow">The window containing the element.</param>
/// <param name="objElement">The element to set outer HTML.</param>
function Web_GetOuterHtml(objWindow,objElement)
{
    var strOuterHtml = "";
    
    if(objWindow && objElement)
    {
        var objOriginalParent = objElement.parentNode;
        var objParent = objWindow.document.createElement("DIV");
        
        objParent.appendChild(objElement);
        strOuterHtml = objParent.innerHTML;
        
        objParent.removeChild(objElement);
        
        if(objOriginalParent!=null)
        {
            $(objOriginalParent).append(objElement);
        }
    }
    return strOuterHtml;
}
/// </method>

/// <method name="Web_SetOuterHTML" access="private">
/// <summary>
/// Sets outer HTML code to a specific element
/// </summary>
/// <param name="objIEWindow">The window containing the element.</param>
/// <param name="objIEElement">The element to set outer HTML.</param>
/// <param name="strOuterHTML">The outer HTML string to set.</param>
/// <param name="strGuid">The guid of the component updated.</param>
function Web_SetOuterHTML(objIEWindow, objIEElement, strOuterHTML, strGuid)
{
    // Write trace time
    Trace_Time("Web", "SetOuterHTML");

    // This happens on hidden controls as they do not appear in the browser.
    // That way updating those components is not needed.
    if (objIEElement == null)
    {
        return;
    }

    // Get parent node
    var objParentElement = objIEElement.parentNode;

    // If parent is to be updated (this value is used to update 
    // horizontal dockink updating).
    if (objIEElement.Slave == '1')
    {
        objIEElement = objParentElement;
    }

    // Get the html tag name
    var strTagName = objIEElement.tagName.toLowerCase();

    var objSpan = null;
    var objNewNode = null;

    // Select the tag name 
    switch (strTagName)
    {
        case "td":
        case "tbody":
        case "tr":
            // Check if there is already a canvas span
            if (!(objSpan = objIEWindow.objSpanSetOuterHTML))
            {
                //create dummy node
                objSpan = objIEWindow.objSpanSetOuterHTML = objIEWindow.document.createElement("span");
            }

            // set tr html code
            Web_SetInnerHtml(objSpan, "<table>" + strOuterHTML + "</table>");

            // get new TR
            var objTable = objSpan.firstChild;
            var objNewTbody = objTable.firstChild;
            var objNewTr = objNewTbody.firstChild;

            // select table node
            objNewNode = (strTagName == "tr") ? objNewTr : objNewTbody;
            if (objNewNode != null)
            {
                if (strTagName == "td")
                {
                    objNewNode = objNewTr.firstChild;
                }

                // replace the row node
                $(objIEElement).replaceWith(objNewNode);

                // Clean applets
                mobjApp.Common_CleanApplets(objIEElement.getElementsByTagName("APPLET"));
                // Clean ActiveX
                mobjApp.Common_CleanApplets(objIEElement.getElementsByTagName("OBJECT"));

            }
            break;
        default:
            // Check if there is already a canvas span
            if (!(objSpan = objIEWindow.objSpanSetOuterHTML))
            {
                //create dummy node
                objSpan = objIEWindow.objSpanSetOuterHTML = objIEWindow.document.createElement("span");
            }

            // set tr html code
            Web_SetInnerHtml(objSpan, strOuterHTML);

            // Get child
            objNewNode = objSpan.firstChild;
            if (objNewNode != null)
            {
                // replace the row node
                $(objIEElement).replaceWith(objNewNode);

                // If top-level form, update hash reference
                if (mblnFullScreenMode && mobjFormsWindowById[objIEElement.id])
                {
                    mobjFormsWindowById[objIEElement.id] = objNewNode;
                }
            }
            break;
    }

    if (objParentElement)
    {
        Layout_PerformLayout(objParentElement);
    }

    // Write trace end
    Trace_Write("Apply transformed HTML.", strGuid);

    // return newly created element
    return objNewNode;
}
/// </method>

/// <method name="Web_GetWebElement">
/// <summary>
/// Gets a browser element by element ID.
/// </summary>
/// <param name="strId">The element ID.</param>
/// <param name="objWindow">The element window.</param>
function Web_GetWebElement(strId,objWindow)
{
	if(objWindow.document)
	{
		return objWindow.document.getElementById(strId);
	}
	else
	{
		return window.document.getElementById(strId);
	}
}
/// </method>

/// <method name="Web_FireClick">
/// <summary>
/// Fires the click event on a given element.
/// </summary>
/// <param name="objElement">The element to fire click on.</param>
function Web_FireClick(objElement)
{
	var objClickEvent	= objElement.ownerDocument.createEvent("MouseEvents");
	objClickEvent.initEvent("click",false,false);
	objElement.dispatchEvent(objClickEvent);
	
}
/// </method>

/// <method name="Web_GetEventSource">
/// <summary>
/// Gets the source element generating the event
/// </summary>
/// <param name="objEvent">The event object.</param>
function Web_GetEventSource(objEvent)
{
    if(objEvent.target)
    {
	    return objEvent.target;
    }
    else if(objEvent.srcElement)
    {
	    return objEvent.srcElement;
    }

    return null;
}
/// </method>

/// <method name="Web_InternalCopyToClipBoard">
/// <summary>
/// Copy text to clipboard. Mozilla clients must configure their browsers
/// to allow access to the clipboard:
/// 1. navigate to about:config
/// 2. set 'signed.applets.codebase_principal_support' param to 'true'
/// Even if user configured his\her browser as specified,recent versions
/// of FireFox alert the user when javascript code is trying to access
/// the clipboard.
/// </summary>
/// <param name="objEvent">The event object.</param>
function Web_InternalCopyToClipBoard(textToCopy)
{
    netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');
    
    var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
    if (!clip)
    {
        return false;
    }
    
    var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
    if (!trans)
    {
        return false;
    }
    
    trans.addDataFlavor('text/unicode');

    var str = new Object();
    var len = new Object();

    var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);

    var copytext=textToCopy;
    str.data=copytext;

    trans.setTransferData("text/unicode",str,copytext.length*2);

    var clipid=Components.interfaces.nsIClipboard;

    if (!clip)
    {
        return false;
    }
    clip.setData(trans,null,clipid.kGlobalClipboard);
}
/// </method>

/// <method name="Web_CopyToClipBoard">
/// <summary>
/// GCopy to clip board
/// </summary>
/// <param name="strType">The content type.</param>
/// <param name="strValue">The content to copy to the clipboard.</param>
function Web_CopyToClipBoard(strType,strValue)
{
    if(clipboardData)
    {
        clipboardData.setData(strType,strValue);
    }
    else
    {
        Web_InternalCopyToClipBoard(strValue);
    }
}
/// </method>

/// <method name="Web_GetContextElementById">
/// <summary>
/// Gets an element contained in a given element
/// </summary>
/// <param name="objContext">The containing element.</param>
/// <param name="strId">The contained element id.</param>
function Web_GetContextElementById(objContext,strId)
{
	for(var i=0;i<objContext.childNodes.length;i++)
	{
		var objItem = objContext.childNodes[i];
		
		if(objItem.id==strId)
		{
			return objItem;
		}
		
		objItem = Web_GetContextElementById(objItem,strId);
		
		if(objItem!=null)
		{
			return objItem;
		}
	}
	
	return null;
}
/// </method>

/// <method name="Web_GetInnerText">
/// <summary>
/// Gets the element inner text value
/// </summary>
/// <param name="objElement">The element to get its contained text.</param>
function Web_GetInnerText(objElement)
{
	if(objElement) 
    {
        //behavior for obselete browsers
        if (objElement.textContent == undefined)
        {
            return objElement.innerText;
        }
        else
        {
            return objElement.textContent;
        }
    
    }    
}
/// </method>

/// <method name="Web_SetInnerText">
/// <summary>
/// Sets the element inner text value
/// </summary>
/// <param name="objElement">The element to set its contained text.</param>
/// <param name="strValue">The element new value.</param>
/// <param name="enmDecodeType">{0 - No decode.; 1 - Text decode. ; 2 - Html decode.}</param>
function Web_SetInnerText(objElement,strValue,enmDecodeType)
{
	if(objElement)
	{
	    switch(enmDecodeType)
	    {
	        case 1:
	        case 2:
	            strValue = Aux_DecodeText(strValue,(enmDecodeType==2));
	            break
	    }	    
        
        //behavior for obselete browsers
        if (objElement.textContent == undefined)
        {
             objElement.innerText = strValue;
        }
        else
        {
            objElement.textContent = strValue;
	        objElement.value = strValue;
        }
	}
}



/// </method>

/// <method name="Web_GetElementById">
/// <summary>
/// Gets the element in the window by ID
/// </summary>
/// <param name="strId">The element ID.</param>
/// <param name="objWindow">The element window.</param>
function Web_GetElementById(strId,objWindow)
{
	return objWindow.document.getElementById(strId);
}
/// </method>

/// <method name="Web_GetWebElementsByTagName">
/// <summary>
/// Gets elements by tag name
/// </summary>
/// <param name="strTag">The tag name.</param>
/// <param name="objWindow">The containing window.</param>
function Web_GetWebElementsByTagName(strTag,objWindow)
{
	return objWindow.document.getElementsByTagName(strTag);
}
/// </method>

/// <method name="Web_StopPropagation">
/// <summary>
///
/// </summary>
/// <param name="objEvent">The browser event object.</param>
function Web_StopPropagation(objEvent)
{
    if(objEvent.stopPropagation != undefined)
    {
        objEvent.stopPropagation();
    }
    else 
    {
	    objEvent.cancelBubble = true;        
    }
}
/// </method>

/// <method name="Web_PreventDefault">
/// <summary>
///
/// </summary>
/// <param name="objEvent">The browser event object.</param>
function Web_PreventDefault(objEvent)
{
    if(typeof objEvent.preventDefault == "function")
    {
        objEvent.preventDefault();
    }
    else 
    {
	    objEvent.returnValue = false;        
    }
}
/// </method>

/// <method name="Web_EventCancelBubble">
/// <summary>
/// Cancel event bubbling
/// </summary>
/// <param name="objEvent">The browser event object.</param>
/// <param name="blnSkipCancelBubble">Whether to skip CancelBubble.</param>
/// <param name="blnSkipPreventDefault">Whether to skip PreventDefault.</param>
function Web_EventCancelBubble(objEvent,blnSkipCancelBubble,blnSkipPreventDefault)
{
	if(objEvent) 
	{
	    if(!blnSkipCancelBubble) 
	    {
            Web_StopPropagation(objEvent);
	    }
	    
	    if(!blnSkipPreventDefault) 
	    {
	        Web_PreventDefault(objEvent);
	    }
    }
}
/// </method>

/// <method name="Web_SetRowVisibility">
/// <summary>
/// Sets the visibility of a table row
/// </summary>
/// <param name="objRow">The table row element.</param>
/// <param name="blnVisible">A flag indicating if row should be visible.</param>
function Web_SetRowVisibility(objRow,blnVisible)
{
	objRow.style.display = blnVisible?"table-row":"none";
}
/// </method>

/// <method name="Web_AttachEvent">
/// <summary>
/// Attachs an event handler
/// </summary>
/// <param name="objElement">The element to add an event handler to</param>
/// <param name="strEvent">The event name to listen to</param>
/// <param name="fncHandler">The handler function</param>
function Web_AttachEvent(objElement,strEvent,fncHandler)
{
    if(objElement)
    {
        if(objElement.addEventListener)
        {
            // Fix event name for non IE browsers
            if(strEvent.indexOf("on")==0)
            {
                strEvent = strEvent.substring(2);
            }
	        objElement.addEventListener(strEvent,fncHandler,false);
	    }
        else if(objElement.attachEvent)
        {
            // Fix event name for IE
            if(strEvent.indexOf("on")!=0)
            {
                strEvent = "on"+strEvent;
            }
	        objElement.attachEvent(strEvent,fncHandler);
	    }
    }
}
/// </method>
    
/// <method name="Web_DetachEvent">
/// <summary>
/// 
/// </summary>
function Web_DetachEvent(objElement,strEvent,fncHandler)
{
    if(objElement.removeEventListener)
    {
         // Fix event name for non IE browsers
        if(strEvent.indexOf("on")==0)
        {
            strEvent = strEvent.substring(2);
        }
	    objElement.removeEventListener(strEvent,fncHandler,false);
    }
    else if(objElement.detachEvent)
    {
        // Fix event name for IE
        if(strEvent.indexOf("on")!=0)
        {
            strEvent = "on"+strEvent;
        }
	    objElement.detachEvent(strEvent,fncHandler);
    }
}
/// </method>


/// <method name="Web_InvokeEvent">
/// <summary>
/// Invokes a code bolck under a scope of a specific event.
/// </summary>
/// <param name="strValue">A code block.</param>
/// <param name="event">The evnt which will serve the invoked code block.</param>
function Web_InvokeEvent(strValue,event)
{
    // Invoke the received code.
    eval(strValue);
}
/// </method>


/// <method name="Web_GetEventSourceElement">
/// <summary>
/// 
/// </summary>
/// <param name="objEvent"></param>
function Web_GetEventSourceElement(objEvent)
{
    if(objEvent)
    {
        if(objEvent.target)
        {
            return objEvent.target;
        }

        if(objEvent.srcElement)
        {
            return objEvent.srcElement;
        }
    }

    return null;
}
/// </method>

/// <method name="Web_EmulateResize">
/// <summary>
/// Recursivly emulates a resize event for the received element and all of its childnodes.
/// </summary>
/// <param name="objElement">The handled element.</param>
/// <param name="objEvent">The event which will serve the resize invokations.</param>
/// <param name="blnIncludeRootElement">Whether to invoke the received element resize code.</param>
function Web_EmulateResize(objElement,objEvent,blnIncludeRootElement)
{
    // Check if the received element's resize event should be invoked.
    if(blnIncludeRootElement)
    {   
        try
        {
            // Try getting the "onresize" event for the received element.
            var objAttribute = objElement.attributes.getNamedItem("onresize");
            if(objAttribute)
            {
                // Save the "onresize" code as one of the received element's member so it will preserve the right 
                // "this" object for the invoked scope.
                objElement.fncResize = Web_InvokeEvent;
                
                // Invoke the resize code.
                objElement.fncResize(objAttribute.value,objEvent);
            }
        } 
        catch (e) {}
    }
        
    // Get the received elemet's child nodes.
    var objChildNodes = objElement.childNodes;
    var intChildNodes = objChildNodes.length;
    
    // Run over all of the received elemet's child nodes.
    for(var i=0;i<intChildNodes;i++)
    {
        // Get a reference to the current child node.
        var objChildNode = objChildNodes[i];
        if(objChildNode.nodeType==1)
        {   
            // Recursivly emulate resize for the current child node.
            Web_EmulateResize(objChildNode,objEvent,true);
        }
    }
}
/// </method>

/// <method name="Web_IsContained">
/// <summary>
/// 
/// </summary>
function Web_IsContained(objContainer,objElement)
{
    if (objContainer && objElement)
    {
        var objElementCursor = objElement.parentNode;
        
        while (objElementCursor)
    {
            if (objElementCursor == objContainer)
            {
                return true;
    }
            
            objElementCursor = objElementCursor.parentNode;
}
    }
    
    return false;
}
/// </method>

/// <method name="Web_IsCharacterPressed">
/// <summary>
/// Check whether a character was last pressed.
/// </summary>
function Web_IsCharacterPressed(objEvent)
{
    return (objEvent && objEvent.charCode!=0);
}
/// </method>

/// <method name="Web_GetExplicitOriginalTarget">
/// <summary>
/// 
/// </summary>
/// <param name="objEvent"></param>
function Web_GetExplicitOriginalTarget(objEvent)
{
    if(objEvent)
    {
        if (objEvent.explicitOriginalTarget != undefined)
        {
            return objEvent.explicitOriginalTarget;
        }
        else
        {
            return Web_GetEventSourceElement(objEvent);
        }
    }
    else
    {
        return null;
    }
}
/// </method>

/// <method name="Web_IsValidWindow">
/// <summary>Checks whether the recieved window is valid.
/// </summary>
/// <param name="objWindow">The checked window.</param>
function Web_IsValidWindow(objWindow)
{
	return objWindow;
}
/// </method>

/// <method name="Web_IsClientRequestStatus">
/// <summary>
/// 
/// </summary>
function Web_IsClientRequestStatus(objXmlHTTP)
{
    var blnIsClient = false;
    
    try
    {
        blnIsClient=(objXmlHTTP && objXmlHTTP.status==0);
    }
    catch (e) 
    {
        blnIsClient=true;
    }
    
    return blnIsClient;
}
/// </method>

/// <method name="Web_IsLeftClick">
/// <summary>
/// Returns true if the button that was clicked in the event is the left button.
/// </summary>
/// <param name="objEvent">The current event.</param>  
function Web_IsLeftClick(objEvent)
{
    if (objEvent)
    {
        if(mcntIsObsoleteIE)
        {
            return (objEvent.button == 1);
        }
        else 
        {
            return (objEvent.button == 0);
        }
    }
    return false;
}
/// </method>


/// <method name="Web_IsRightClick">
/// <summary>
/// Returns true if the button that was clicked in the event is the Right button.
/// </summary>
/// <param name="objEvent">The current event.</param>     
function Web_IsRightClick(objEvent)
{
    if (objEvent)
    {
        if (objEvent.button == 2)
        {
            return true;
        }
    }
    return false;
}
/// </method>

/// <method name="Web_IsMiddleClick">
/// <summary>
/// Returns true if the button that was clicked in the event is the middle button.
/// </summary>
/// <param name="objEvent">The current event.</param>  
function Web_IsMiddleClick(objEvent)
{
    if (objEvent)
    {
        if(mcntIsObsoleteIE)
        {
            return (objEvent.button == 4);
        }
        else 
        {
            return (objEvent.button == 1);
        }
    }
    return false;
}
/// </method>

/// <method name="Web_IsFocusableElement">
/// <summary>
/// Check whether an element is focusable.
/// </summary>
/// <param name="objElement">The element being checked.</param>
function Web_IsFocusableElement(objElement)
{
    return true;
}
/// </method>

/// <method name="Web_GetEventRelatedSource">
/// <summary>
/// Gets the related element generating the event
/// </summary>
/// <param name="objEvent">The event object.</param>
function Web_GetEventRelatedSource(objEvent)
{
	return objEvent.relatedTarget;
}
/// </method>

/// <method name="Web_EmulateMouseWheel">
/// <summary>
/// 
/// </summary>
function Web_EmulateMouseWheel(objElement,objEvent)
{
    // Validate recieved arguments.
    if(objElement && objEvent)
    {
        // Prevent entering of the body element so that its mouse wheel handler won't re-proccess the
        // recursive emulation.
        if(objElement.tagName.toLowerCase()!="body")
        {
            // Try getting the "onmousewheel" event for the received element.
            var objAttribute = objElement.attributes.getNamedItem("onmousewheel");
            if(objAttribute)
            {
                // Save the "onmousewheel" code as one of the received element's member so it will preserve the right "this" object for the invoked scope.
                objElement.fncMouseWheel = Web_InvokeEvent;
                
                // Invoke the mousewheel code.
                objElement.fncMouseWheel(objAttribute.value,objEvent);
            }
            
            // Check if recieved element has no scrolling area at all.
            if((objElement.style.overflowY=="hidden" || !Web_HasScrollY(objElement)) &&
                (objElement.style.overflowX=="hidden" || !Web_HasScrollX(objElement)))
            {
                // Get element's parent node.
                var objParentElement = objElement.parentNode;
                
                // Loop while no proper parent element is found.
                while(objParentElement!=null && objParentElement.nodeType!=1)
                {
                    // Get parent element's parent node.
                    objParentElement=objParentElement.parentNode;
                }
                
                // Emulate mouse wheel on parent element.
                Web_EmulateMouseWheel(objParentElement,objEvent);
            }
        }
    }
}
/// </method>

/// <method name="Web_GetSelectionRange">
/// <summary>
/// Get the selection range
/// </summary>
/// <param name="objElement">The element the was selected</param>
function Web_GetSelectionRange(objElement)
{
    //Get selection start
    var intSelectionStart = 0;

    //Get selection end
    var intSelectionEnd = 0;

    // Validate recieved arguments.
    if (objElement)
    {
        if (objElement.selectionStart != undefined)
        {
            // Get selection start and end from element.
            intSelectionStart = objElement.selectionStart;
            intSelectionEnd = objElement.selectionEnd;
        }
        else //for IE 8 and less.
        {
            // Get active window.
            var objWindow = Web_GetActiveWindow();

            // Validate active window.
            if (objWindow && Web_IsWindow(objWindow))
            {
                // The current selection
                var objRange = objWindow.document.selection.createRange();

                // We'll use this as a 'dummy'
                var objStoredRange = objRange.duplicate();

                if (Web_IsTag(objElement, "TEXTAREA"))
                {
                    // Select all text
                    objStoredRange.moveToElementText(objElement);

                    // Now move 'dummy' end point to end point of original objRange
                    objStoredRange.setEndPoint('EndToEnd', objRange);

                    // Get text range length.
                    var intTextRangeLength = objRange.text.length;

                    // Now we can calculate start and end points
                    intSelectionStart = (objStoredRange.text.length - intTextRangeLength);
                    intSelectionEnd = (intSelectionStart + intTextRangeLength);
                }
                else if (Web_IsTag(objElement, "INPUT"))
                {
                    // Get selection text length
                    var intSelectedText = objStoredRange.text.length;

                    // Move selection start to 0 position
                    objStoredRange.moveStart('character', -objElement.value.length);

                    // The caret position is selection length
                    intSelectionEnd = objStoredRange.text.length;

                    // The selection start is the caret position sub the selection text length
                    intSelectionStart = intSelectionEnd - intSelectedText;
                }
            }
        }
    }

    return { Start: intSelectionStart, End: intSelectionEnd };
}
/// </method>

/// <method name="Web_GetEventCharCode">
/// <summary>
/// 
/// </summary>
function Web_GetEventCharCode(objEvent)
{
    if (objEvent)
    {
        return objEvent.charCode;
    }
    
    return 0;
}
/// </method>

/// <method name="Web_SupportsHTML5BrowserCapability">
/// <summary>
/// 
/// </summary>
function Web_SupportsHTML5BrowserCapability(intHTML5BrowserCapability)
{
    return (mintBrowserCapabilities_HTML5 & intHTML5BrowserCapability)>0 ? true : false;
}
/// </method>

/// <method name="Web_SupportsCSS3BrowserCapability">
/// <summary>
/// 
/// </summary>
function Web_SupportsCSS3BrowserCapability(intCSS3BrowserCapability)
{
    return (mintBrowserCapabilities_CSS3 & intCSS3BrowserCapability)>0 ? true : false;
}
/// </method>

/// <method name="Web_SupportsMISCBrowserCapability">
/// <summary>
/// 
/// </summary>
function Web_SupportsMISCBrowserCapability(intMISCBrowserCapability)
{
    return (mintBrowserCapabilities_MISC & intMISCBrowserCapability)>0 ? true : false;
}
/// </method>


/// <method name="Web_OnOrientationChange">
/// <summary>
/// 
/// </summary>
function Web_OnOrientationChange(objEvent, objWindow)
{
    // NOTE: We need to raise the orientation changed event, on all the opened forms.
    var objFormNodes = Xml_SelectNodes(".//WG:Tags.Form", mobjDataRootObject);       
    for (var i = 0; i < objFormNodes.length; i++)
    {
        var objFormNode = objFormNodes[i];

        // Checking all forms for critical event
        var blnIsCritical = Data_IsCriticalEvent(objFormNode, "Event.OrientationChanged", true) || Form_IsChildFormHaveCriticalEvent(objFormNode, "Event.OrientationChanged");

        // Create event and raise if critical	
        var objOrientationChangedEvent = Events_CreateEvent(Controls_GetGuid(objFormNode), "OrientationChange", null, true, false, !blnIsCritical);

        Events_SetEventAttribute(objOrientationChangedEvent, "Attr.Orientation", window.orientation);

        // If orientation change is critical raise.
        if (blnIsCritical) {
            Events_RaiseEvents();
        }

        // Process Client event.
        Events_ProcessClientEvent(objOrientationChangedEvent);
    }        
}
/// </method>

/// <method name="Web_IsAbsoluteUrl">
/// <summary>
/// Check if url is absolute.
/// </summary>
/// <param name="strURL">The url to be checked.</param>
function Web_IsAbsoluteUrl(strURL)
{
    if (!Aux_IsNullOrEmpty(strUrl))
    {
        strUrl = strUrl.toLowerCase();
        if (
                strUrl.indexOf("~/") == 0 ||
                strUrl.indexOf("http://") == 0 ||
                strUrl.indexOf("https://") == 0 ||
                strUrl.indexOf("mailto:") == 0 ||
                strUrl.indexOf("ftp://") == 0
            )
        {
            return true;
        }
    }

    return false;
}

/// </method>

/// <method name="Web_SetMouseEvents">
/// <summary>
/// 
/// </summary>
function Web_SetMouseEvents(objElement, strHandler ,objWindow, objExtraParams)
{
    if(objElement && strHandler)
    {
        objElement.onmousedown = function(objEvent)
        {
            if (typeof mobjApp[strHandler] === "function")
            {
                mobjApp[strHandler](objElement, 'mousedown', objWindow, objEvent, objExtraParams);
            }   
        };
        objElement.onmouseup = function(objEvent)
        {
            if (typeof mobjApp[strHandler] === "function")
            {
                mobjApp[strHandler](objElement, 'mouseup', objWindow, objEvent, objExtraParams);
            }   
        };

        Web_SetMouseEnterLeaveEvents(objElement, strHandler,objWindow, objExtraParams);
    }
}
/// </method>

/// <method name="Web_IsWindowLandscape">
/// <summary>
/// Returns whether the device the browser is running is landscape or not. (Portrait)
/// </summary>
function Web_IsWindowLandscape() {
    if ($(window).width() > $(window).height())
    {
        return true;
    }

    return false;
}
/// </method>

/// <method name="Web_GetThemeName">
/// <summary>
/// 
/// </summary>
function Web_GetThemeName(objElement)
{
    if (mblnSupportsMultiTheme && objElement && objElement.className)
    {
        var arrClasses = objElement.className.split(" ");
        if (arrClasses.length > 0)
        {
            return arrClasses[0];
        }
    }

    return "";
}
/// </method>

/// <method name="Web_EnforceIFrameTheming">
/// <summary>
/// 
/// </summary>
/// <param name="strIFrameId">The component id.</param>
function Web_EnforceIFrameTheming(strIFrameId)
{
    // Check if multi theme is supported.
    if (mblnSupportsMultiTheme)
    {
        if (!Aux_IsNullOrEmpty(strIFrameId))
        {
            // Get iframe element.
            var objIFrame = Web_GetTargetElementByDataId(strIFrameId);
            if (objIFrame)
            {
                // Get frame's window.
                var objWindow = objIFrame.contentWindow;
                if(objWindow)
                {
                    // Get theme value for recieved frame.
                    var strTheme = Data_GetTheme(strIFrameId);
                    if(!Aux_IsNullOrEmpty(strTheme))
                    {
                        // Get all link elements on page.
                        var arrLinkElements = mobjApp.$(objWindow.document).find("link");
                        for (var i = 0; i < arrLinkElements.length; i++)
                        {
                            // Update current link's href with desiered theme.
                            arrLinkElements[i].href = arrLinkElements[i].href.replace("/Context.MultiThemeDefault/", ("/" + strTheme + "/"))
                        }

                        // Get all elements on page which has a class attribute.
                        var arrElements = mobjApp.$(objWindow.document).find('[class]');
                        if (arrElements)
                        {
                            // Loop all elements.
                            for (var i = 0; i < arrElements.length; i++)
                            {
                                // Add desiered theme to class name.
                                arrElements[i].className = strTheme + " " + arrElements[i].className;
                            }
                        }
                    }
                }
            }
        }
    }
}
/// </method>