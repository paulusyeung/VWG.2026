/// <page name="SplitterSkin.Splitter.js">
/// <summary>
/// This script is used as a shared drag script.
/// </summary>

var mobjSplitterData = {};

/// <parameters>
/// <summary>
/// Global parameters
/// </summary>
mobjSplitterData.objObjectRect		= null;
mobjSplitterData.objSubject			= null;
mobjSplitterData.objSecondSubject   = null;
mobjSplitterData.mblnMirroring		= false;
mobjSplitterData.mstrGuid			= 0;
/// </parameters>



/// <method name="Splitter_HorzClickChange">
/// <summary>
///
/// </summary>
/// <param name=""></param>
function Splitter_HorzClickChange(objRect)
{
    var intWidth = 0;

    // Check if in mirroring mode.
    if (mobjSplitterData.mblnMirroring)
    {
        // Update target's rectangle's left position.
        mobjSplitterData.objObjectRect.left = objRect.right;
    }
    else
    {
        // Update target's rectangle's right position.
        mobjSplitterData.objObjectRect.right = objRect.left;
    }

    with (mobjSplitterData.objSubject.style)
    {
        // Calculate new width.
        var intWidth = (mobjSplitterData.objObjectRect.right - mobjSplitterData.objObjectRect.left);

        // Make sure that the width is not negative.
        if (intWidth < 1)
        {
            intWidth = 0;
        }

        width = intWidth + "px";
    }

    // Update cotnrol's width.
    Controls_UpdateWidth(mobjSplitterData.mstrTargetGuid, mobjSplitterData.objSubject, intWidth);

    // Raise the splitter moved event.
    Splitter_Moved(intWidth);
}
/// </method>

 
/// <method name="Splitter_Moved">
/// <summary>
///
/// </summary>
function Splitter_Moved(intSize) 
{
    // Emulate resize for main subject.
    if(mobjSplitterData.objSubject)
    {
        Web_EmulateResize(mobjSplitterData.objSubject,null,true);
    }
    
    // Emulate resize for second subject.
    if(mobjSplitterData.objSecondSubject)
    {
        Web_EmulateResize(mobjSplitterData.objSecondSubject,null,true);
    }
    
    // Create event
    var objEvent = Events_CreateEvent(mobjSplitterData.mstrGuid, "SplitterMoved", mobjSplitterData.mstrTargetGuid, true);

    // Set event size attribuete
    Events_SetEventAttribute(objEvent, "Size", intSize);

    if (mobjSplitterData != null) 
    {
        if (mobjSplitterData.objObjectRect != null) 
        {
			var intSplitX = mobjSplitterData.objObjectRect.right - mobjSplitterData.objObjectRect.left;	
            var intSplitY = mobjSplitterData.objObjectRect.bottom - mobjSplitterData.objObjectRect.top;

            //Sets(event text attribuet) the x/y-coordinate of the mouse pointer 
            Events_SetEventAttribute(objEvent, "X", String(intSplitX));
            Events_SetEventAttribute(objEvent, "Y", String(intSplitY));
        }
	    
    }    

    // Raise event if splitter moved event is critical for the splitter or the if resize 
    // event is critical for the target control.
    if (Data_IsCriticalEvent(mobjSplitterData.mstrGuid, "Event.PositionChanged") ||
	    Data_IsCriticalEvent(mobjSplitterData.mstrTargetGuid, "Event.SizeChange"))
	{
        Events_RaiseEvents();
    }

    Events_ProcessClientEvent(objEvent);
}
/// </method>


/// <method name="Splitter_GetObject">
/// <summary>
///
/// </summary>
/// <param name=""></param>
/// <param name=""></param>
function Splitter_GetObject(objSplitter,strDock)
{
	if(strDock=="T"||strDock=="L")
	{
		return objSplitter.previousSibling;
	}
	else
	{
		return objSplitter.nextSibling;
	}
}
/// </method>

/// <method name="Splitter_VertClickChange">
/// <summary>
///
/// </summary>
/// <param name=""></param>
function Splitter_VertClickChange(objRect)
{
	var intHeight = 0;

	// Check if in mirroring mode.
	if(mobjSplitterData.mblnMirroring)
	{
	    // Update target's rectangle's top position.
		mobjSplitterData.objObjectRect.top = objRect.bottom;
	}
	else
	{
	    // Update target's rectangle's bottom position.
		mobjSplitterData.objObjectRect.bottom = objRect.top;
	}
	
	with(mobjSplitterData.objSubject.style)
	{
	    // Calculate new height.
	    var intHeight = mobjSplitterData.objObjectRect.bottom - mobjSplitterData.objObjectRect.top;
	    
        // Make sure that the width is not negative.
	    if(intHeight < 1)
	    {
	        intHeight = 0;
	    }

	    height = intHeight + "px";
	}
	
    // Update target control's height.
    Controls_UpdateHeight(mobjSplitterData.mstrTargetGuid,mobjSplitterData.objSubject,intHeight);
	
    // Raise the splitter moved event.
    Splitter_Moved(intHeight);
}

/// <method name="Splitter_GetElementSize">
/// <summary>
/// Get the size attribute-value out of the received HTML element.
/// </summary>
/// <param name="objElement">The HTML element.</param>
/// <param name="strSizeAttributeName">The size attribute name.</param>
function Splitter_GetElementSize(objElement,strSizeAttributeName)
{   
    // Define a zero size.
    var intSize = 0;
    
    // Validate received arguments.
    if(objElement && strSizeAttributeName)
    {
        // Get web id of the received element.
        var strId = Web_GetId(objElement);
        
        if(strId && strId!="")
        {
            // Get the data Guid of the received element.
            var strGuid = Data_GetDataId(strId);
            
            if(strGuid && strGuid!="")
            {
                // Get a data node by the calculated Guid.
                var objNode = Data_GetNode(strGuid);
                
                if(objNode)
                {
                    // Perform a numeric parse on the requested attribute.
                    intSize = parseInt(Xml_GetAttribute(objNode,strSizeAttributeName,"0"));
                }
            }
        }
    }
    
    return intSize;
}

/// <method name="Splitter_MouseDown">
/// <summary>
/// 
/// </summary>
function Splitter_MouseDown(strGuid,strDock,objWindow,objEvent)
{
    // Start the drag of the splitter only if this is the left button
    if (Web_IsLeftClick(objEvent)) 
    {
        Splitter_StartDrag(strGuid,strDock,objWindow);
    }
}

/// </method>



/// <method name="Splitter_GetAvailableLimitationSpace">
/// <summary>
/// Get the available amout of pixels available for resizing of the docking area
/// </summary>
/// <param name="objElement">The HTML element.</param>
/// <param name="objFirstElement">The first resized HTML element.</param>
/// <param name="intDragMoveType">The current splitter orientation.</param>
function Splitter_GetAvailableLimitationSpace(objSplitterElement, intDragMoveType)
{
    // Checking required objects to be available
    if(objSplitterElement && objSplitterElement.parentNode)
    {
        // Defining docking area container and it's rect
        var objContainerElement = objSplitterElement.parentNode;
        var objContainerElementRect = Web_GetRect(objContainerElement); 
        // Varibale to accomulate available space
        var intPreservedSpace = 0;
        
        if (intDragMoveType == mcntDragMoveHorz)
        {
            var intHorizontalDockPadding = parseInt(Xml_GetAttribute(objContainerElement, "data-vwgpaddingright", "0"), 0) + parseInt(Xml_GetAttribute(objContainerElement, "data-vwgpaddingleft", "0"), 0);

            // Running over all child elements of the container
            for (var i=0; i<objContainerElement.childNodes.length; i++)
            {
                // Getting the docking mode
                var strDocking = Web_GetAttribute(objContainerElement.childNodes[i], "vwgdocking");
                
                // Calculating only "Left" and "Right" docked panels
                if (strDocking == "L" || strDocking == "R")
                {
                    // Getting the panel object
                    var objSiblingRect = Web_GetRect(objContainerElement.childNodes[i]);
                    
                    // Adding to available space variable the width of the horizontally docked panel
                    intPreservedSpace += (objSiblingRect.right - objSiblingRect.left);
                }
            }
            
            // The available space is container width substract accomulative width of panels
            return (objContainerElementRect.right - objContainerElementRect.left) - intPreservedSpace - intHorizontalDockPadding;
        }
        
        else if (intDragMoveType == mcntDragMoveVert)
        {
            var intVerticalDockPadding = parseInt(Xml_GetAttribute(objContainerElement, "data-vwgpaddingtop", "0"), 0) + parseInt(Xml_GetAttribute(objContainerElement, "data-vwgpaddingbottom", "0"), 0);

            // Running over all child elements of the container
            for (var i=0; i<objContainerElement.childNodes.length; i++)
            {
                // Getting the docking mode
                var strDocking = Web_GetAttribute(objContainerElement.childNodes[i], "vwgdocking");
                
                // Calculating only "Top" and "Bottom" docked panels
                if (strDocking == "T" || strDocking == "B")
                {
                    // Getting the panel object
                    var objSiblingRect = Web_GetRect(objContainerElement.childNodes[i]);
                    
                    // Adding to available space variable the height of the panel
                    intPreservedSpace += (objSiblingRect.bottom - objSiblingRect.top);
                }
            }
            
            // The available space is container height substract accomulative height of vertically docked panels
            return (objContainerElementRect.bottom - objContainerElementRect.top) - intPreservedSpace - intVerticalDockPadding;
        }
    }
    
    // In case of required element is missing
    return 0;   
}

/// </method>


/// <method name="Splitter_GetLimitationsRect">
/// <summary>
/// Retreives a rectangle which represents the limitations of the splitter.
/// </summary>
/// <param name="intDragMoveType">The current splitter orientation.</param>
/// <param name="objSplitterElement">The splitter HTML element.</param>
/// <param name="objFirstElement">The first resized HTML element.</param>
/// <param name="objSecondElement">The second resized HTML element.</param>
function Splitter_GetLimitationsRect(intDragMoveType, strDock, objSplitterElement, objFirstElement,objSecondElement)
{
    var objLimitationsRect = null;
    
    // Validate received elements.
    if(objSplitterElement && objFirstElement && objSecondElement)
    {   
        // Get elements rectangles.
        var objFirstElementRect = Web_GetRect(objFirstElement);
        var objSecondElementRect = Web_GetRect(objSecondElement);
        
        if(objFirstElementRect && objSecondElementRect)
        {                     
            // Get available limitations rectangle.
            var objAvailableLimitationsRect = Splitter_GetAvailableLimitationsRect(objFirstElementRect,objSplitterElement,strDock,intDragMoveType);
            
            // Get minimum and maximum limitations rectangle.
            objLimitationsRect = Splitter_GetMinMaxLimitationsRect(objAvailableLimitationsRect,objFirstElement,objSecondElement,objFirstElementRect,objSecondElementRect,intDragMoveType);
        }
    }
    
    return objLimitationsRect;
}
/// </method>

/// <method name="Splitter_GetAvailableLimitationsRect">
/// <summary>
/// Get available limitations rectangle.
/// </summary>
/// <param name="objFirstElementRect"></param>
/// <param name="objSplitterElement"></param>
/// <param name="strDock"></param>
/// <param name="intDragMoveType"></param>
function Splitter_GetAvailableLimitationsRect(objFirstElementRect, objSplitterElement, strDock, intDragMoveType)
{
    // Define default rect values
    var intTop = objFirstElementRect.top;
    var intLeft = objFirstElementRect.left;
    var intRight = objFirstElementRect.right;
    var intBottom = objFirstElementRect.bottom;

    // Calculating available space for resize of the panel
    var intAvailableSpace = Splitter_GetAvailableLimitationSpace(objSplitterElement, intDragMoveType);


    // Get splitter rectangle.
    var objSplitterElementRect = Web_GetRect(objSplitterElement);

    // Verical mode
    if (intDragMoveType == mcntDragMoveVert)
    {
        var intSplitterHeight = objSplitterElementRect.bottom - objSplitterElementRect.top;

        // In case of processing Top docked panel
        if (strDock == "T")
        {
            intTop = objFirstElementRect.top;
            intBottom = objFirstElementRect.bottom + intAvailableSpace;
        }
        // In case of processin Bottom docked panel
        else if (strDock == "B")
        {
            intTop = objFirstElementRect.top - intAvailableSpace - intSplitterHeight;
            intBottom = objFirstElementRect.bottom - intSplitterHeight;
        }
    }
    
    // Horizontal mode
    else if(intDragMoveType == mcntDragMoveHorz)
    {
        var intSplitterWidth = objSplitterElementRect.right - objSplitterElementRect.left;

        // In case of processing Left docked panel
        if (strDock == "L") 
        {
            intLeft = objFirstElementRect.left;    
            intRight = objFirstElementRect.right + intAvailableSpace;
        }
        
        // In case of processing Right docked panel
        else if (strDock == "R")
        {
            intLeft = objFirstElementRect.left - intAvailableSpace - intSplitterWidth;
            intRight = objFirstElementRect.right - intSplitterWidth;
        }
    }

    return Common_CreateRect(intLeft, intTop, intRight, intBottom);
}
/// </method>

/// <method name="Splitter_GetMinMaxLimitationsRect">
/// <summary>
/// Get minimum and maximum limitations rectangle.
/// </summary>
/// <param name="objLimitationsRect"></param>
/// <param name="objFirstElement"></param>
/// <param name="objSecondElement"></param>
/// <param name="objFirstElementRect"></param>
/// <param name="objSecondElementRect"></param>
/// <param name="intDragMoveType"></param>
function Splitter_GetMinMaxLimitationsRect(objLimitationsRect, objFirstElement, objSecondElement, objFirstElementRect, objSecondElementRect, intDragMoveType)
{
    // Define default rect values
    var intTop = objLimitationsRect.top;
    var intLeft = objLimitationsRect.left;
    var intRight = objLimitationsRect.right;
    var intBottom = objLimitationsRect.bottom;
    
    // Define the size attribtue name.
    var strMinimumSizeAttributeName = (intDragMoveType == mcntDragMoveVert) ? "Attr.MinimumHeight" : "Attr.MinimumWidth";
    var strMaximumSizeAttributeName = (intDragMoveType == mcntDragMoveVert) ? "Attr.MaximumHeight" : "Attr.MaximumWidth";

    // Get the elements minimal sizes out of their meta data.
    var intFirstElementMinimalSize = Splitter_GetElementSize(objFirstElement, strMinimumSizeAttributeName);
    
    // Get the elements maximal sizes out of their meta data.
    var intFirstElementMaximalSize = Splitter_GetElementSize(objFirstElement, strMaximumSizeAttributeName);

    // Valid normal values (maximum >= minimum)
    if (intFirstElementMaximalSize == 0 || intFirstElementMinimalSize == 0 || intFirstElementMaximalSize >= intFirstElementMinimalSize)
    {
    // Handle the first element's minimal size.
    if(intFirstElementMinimalSize > 0)
    {
        // Check splitter orientation.
        if(intDragMoveType == mcntDragMoveVert)
        {
            // Check which element is upper most.
            if(objFirstElementRect.bottom > objSecondElementRect.bottom)
            {
                // Decrease rectangle's bottom.
                intBottom-=intFirstElementMinimalSize;
            }
            else
            {
                // Increase rectangle's top.
                intTop+=intFirstElementMinimalSize;
            }
        }
        else
        {
            // Check which element is right most.
            if(objFirstElementRect.right > objSecondElementRect.right)
            {
                // Decrease rectangle's right.
                intRight-=intFirstElementMinimalSize;
            }
            else
            {
                // Increase rectangle's left.
                intLeft+=intFirstElementMinimalSize;
            }
        }
    }
    
    // Handle the second element's minimal size.
        if (intFirstElementMaximalSize > 0)
    {
        // Check splitter orientation.
        if(intDragMoveType == mcntDragMoveVert)
        {
            // Check which element is upper most.
            if(objSecondElementRect.bottom > objFirstElementRect.bottom)
            {
                    // Increase rectangle's bottom.
                    intBottom = objLimitationsRect.top + intFirstElementMaximalSize;
            }
            else
            {
                    // Decrease rectangle's top.
                    intTop = objLimitationsRect.bottom - intFirstElementMaximalSize;
            }
        }
        else
        {
            // Check which element is right most.
            if(objSecondElementRect.right > objFirstElementRect.right)
            {
                    // set rectangle's right.
                    intRight = objLimitationsRect.left + intFirstElementMaximalSize;
            }
            else
            {
                    // set rectangle's left.
                    intLeft = objLimitationsRect.right - intFirstElementMaximalSize;
            }
        }
    }
    }
    else
    {
        // Check splitter orientation.
        if (intDragMoveType == mcntDragMoveVert)
        {
            // Check which element is upper most.
            if (objSecondElementRect.bottom > objFirstElementRect.bottom)
            {
                intBottom = intTop = objLimitationsRect.top + objFirstElementRect.bottom - objFirstElementRect.top;
            }
            else
            {
                intBottom = intTop = objLimitationsRect.bottom - (objFirstElementRect.bottom - objFirstElementRect.top);
            }
        }
        else
        {
            // Check which element is right most.
            if (objSecondElementRect.right > objFirstElementRect.right)
            {
                // set rectangle's right.
                intLeft = intRight = objLimitationsRect.left + objFirstElementRect.right - objFirstElementRect.left;
            }
            else
            {
                // set rectangle's left.
                intLeft = intRight = objLimitationsRect.right - (objFirstElementRect.right - objFirstElementRect.left);
            }
        }
    }
    
    return Common_CreateRect(intLeft,intTop,intRight,intBottom);
}
/// </method>

/// <method name="Splitter_StartDrag">
/// <summary>
/// setting drag abilities to splitter element.
/// </summary>
function Splitter_StartDrag(strGuid, strDock, objWindow, objEvent) {
    // Get the splitter element
    var objParentElement = Web_GetWebElement(Web_GetWebId(strGuid), objWindow);
    if (objParentElement) {
        // The target element to change its size
        var objTargetElement = null;

        // Define the elements which will serve limitation calculations.
        var objFirstElement = null;
        var objSecondElement = null;

        // Drag moving type
        var intDragMoveType = 0;

        // Splitter changed handler
        var fncSplitterHandler = null;

        // Calculation should be mirrored
        var blnMirror = false;

        // chose drag mode
        switch (strDock) {
            case "L":
                objTargetElement = objParentElement.previousSibling;
                objFirstElement = objTargetElement;
                objSecondElement = objParentElement.nextSibling;
                fncSplitterHandler = Splitter_HorzClickChange;
                intDragMoveType = mcntDragMoveHorz;
                break;
            case "R":
                objTargetElement = objParentElement.previousSibling;
                objFirstElement = objTargetElement;
                objSecondElement = objParentElement.nextSibling;
                fncSplitterHandler = Splitter_HorzClickChange;
                intDragMoveType = mcntDragMoveHorz;
                blnMirror = true;
                break;
            case "B":
                objTargetElement = objParentElement.previousSibling;
                objFirstElement = objTargetElement;
                objSecondElement = objParentElement.nextSibling;
                fncSplitterHandler = Splitter_VertClickChange;
                intDragMoveType = mcntDragMoveVert;
                blnMirror = true;
                break;
            case "T":
                objTargetElement = objParentElement.previousSibling;
                objFirstElement = objTargetElement;
                objSecondElement = objParentElement.nextSibling;
                fncSplitterHandler = Splitter_VertClickChange;
                intDragMoveType = mcntDragMoveVert;
                break;
        }

        // if the target element was found
        if (objTargetElement) {
            // Get target's data id.
            var strTargetDataId = Data_GetDataId(objTargetElement.id);
            if (!Aux_IsNullOrEmpty(strTargetDataId)) {
                // Check if target control is visible.
                if (!Data_IsAttribute(strTargetDataId, "Attr.Visible", "0")) {
                    // Set general parmas
                    mobjSplitterData.objSubject = objTargetElement;
                    mobjSplitterData.objSecondSubject = objSecondElement;
                    mobjSplitterData.objObjectRect = Web_GetRect(objTargetElement);
                    mobjSplitterData.mblnMirroring = blnMirror;
                    mobjSplitterData.mstrGuid = strGuid;
                    mobjSplitterData.mstrTargetGuid = strTargetDataId;
                    mobjSplitterData.objWindow = objWindow;

                    // Register drag source element.			
                    Drag_RegisterDragElement(objParentElement, intDragMoveType, objWindow, objEvent, fncSplitterHandler, null, Splitter_GetLimitationsRect(intDragMoveType, strDock, objParentElement, objFirstElement, objSecondElement), false);
                }
            }
        }
    }
}
