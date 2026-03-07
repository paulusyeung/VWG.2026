/// <page name="Common.Drag.js">
/// <summary>
/// This script is used as a shared drag script.
/// </summary>


/// <parameters>
/// <summary>
/// Global parameters
/// </summary>
var mcntDragMoveHorz = 0;
var mcntDragMoveVert = 1;
var mcntDragMoveFree = 2;
var mcntDragResizeTop = 4;
var mcntDragResizeTopRight = 12;
var mcntDragResizeTopLeft = 20;
var mcntDragResizeBottom = 32;
var mcntDragResizeBottomRight = 40;
var mcntDragResizeBottomLeft = 48;
var mcntDragResizeRight = 8;
var mcntDragResizeLeft = 16;
/// </parameters>

/// <parameters>
/// <summary>
/// Global parameters
/// </summary>
var mobjDragElement		= null;
var mobjDragOffset		= null;
var mobjDragRect		= null;
var mobjDragRectOld		= null;
var mobjDragRegion		= null;
var mobjDragMoveCallIInterval = null;
var mfncDragDropCallback	= null;
var mintDragType		= 0; 
var mintDragWidth		= 0;
var mintDragHeight		= 0;
var mfncDragMoveCallback = null;
var mintDragMoveCallIInterval = 0;
var mblnApplyDraggedAppearance = false;
var mobjDraggedOverContainer = null;
/// </parameters>

/// <summary>
/// Variables which serves the "scroll by drag" functionallity.
/// </summary>
var mobjScrollableContainer = null;
var mintSyncDragAndDropScrollTimeOut = 0;

/// <summary>
/// Constants which serves the "scroll by drag" functionallity.
/// </summary>
var mcntScrollingMargins = 20;
var mcntScrollingGaps = 30;
var mcntScrollingInterval = 200;
var mcntScrollingDetectionTimeOut = 650;

/// <summary>
/// Whether mouse is down
/// </summary>
var mblnDragDown = false;

/// <summary>
/// The drag window
/// </summary>
var mobjDragWindow = null;

/// <summary>
/// The drag subject
/// </summary>
var mobjDragSubject = null;

/// <summary>
/// Whether mouse left element with mouse down.
/// </summary>
var mblnDragLeave = false;

/// <summary>
/// Contain the last element that was dragged over.
/// </summary>
var mobjDraggedOverElement = null;

/// <method name="Drag_ShowDragElement">
/// <summary>
/// Returns and syncronizes a drag frame.
/// </summary>
/// <param name="objRect">The rectangle of the draged element.</param>
/// <param name="intDragType">The draging type.</param>
/// <param name="objWindow">The element containing window.</param>
/// <param name="fncDragDropCallback">The callback function to be used after drop event.</param>
/// <param name="objOffset">The draging mouse offset.</param>
/// <param name="objRegion">The limiting containing rectangle region (Optional).</param>
/// <param name="fncDragMoveCallback">The function which will be called on drag move (Optional).</param>
/// <param name="intDragMoveCallIInterval">The interval in which the fncDragMoveCallback function will be called (Optional).</param>
function Drag_ShowDragElement(objRect,intDragType,objWindow,fncDragDropCallback,objOffset,objRegion,strHtml,fncDragMoveCallback,intDragMoveCallIInterval)
{
	// set global reference
	mobjDragRect		      = objRect;
	mintDragType		      = intDragType;
	mobjDragWindow		      = objWindow;
	mfncDragDropCallback      = fncDragDropCallback;
	mobjDragOffset		      = objOffset;
	mobjDragRegion		      = objRegion;
	mobjDragRectOld           = {left:objRect.left,right:objRect.right,top:objRect.top,bottom:objRect.bottom};
	mfncDragMoveCallback      = fncDragMoveCallback;
	mintDragMoveCallIInterval = intDragMoveCallIInterval;

	// set initial size 
	mintDragWidth	= mobjDragRect.right-objRect.left;
	mintDragHeight	= mobjDragRect.bottom-objRect.top;
	
	// If there is html to drag
	if(!Aux_IsNullOrEmpty(strHtml))
	{
		// Hide marker 
		mobjDragElement = Web_GetElementById("VWG_DragStandardIndicatorBox",objWindow);
		mobjDragElement.style.visibility="hidden";
		
		// Show container
		mobjDragElement = Web_GetElementById("VWG_DragHtmlIndicatorBox", objWindow);
		Web_SetInnerHtml(mobjDragElement, strHtml);		
		mobjDragElement.style.visibility="visible";
	}
	else
	{
		// Hide container
		mobjDragElement = Web_GetElementById("VWG_DragHtmlIndicatorBox",objWindow);
		mobjDragElement.style.visibility="hidden";
		
		// Show marker
		mobjDragElement = Web_GetElementById("VWG_DragStandardIndicatorBox",objWindow);
		mobjDragElement.style.visibility="visible";
	}

	// if element found
	if(mobjDragElement)
	{
	    // Cover all iframes on drag window.
	    Drag_CoverIFrameElements(mobjDragWindow);
	
		// syncronize drag frame to draged element
		with(mobjDragElement.style)
		{
		    left = objRect.left + "px";
			top = objRect.top + "px";

			var intWidth = (objRect.right - objRect.left) ;
	        if(intWidth>0)
		    {
		        width = intWidth + "px";
			}

			var intHeight = (objRect.bottom - objRect.top) ;
	        if(intHeight>0)
		    {
		        height = intHeight + "px";
			}
		}
		// show and capture events
		mobjDragElement.parentNode.style.display = "block";
		Web_SetCapture(mobjDragElement);
	}
	
	// Validate the drag move function parameters.
	if(mfncDragMoveCallback && mintDragMoveCallIInterval && mintDragMoveCallIInterval > 0)
	{
	    mobjDragMoveCallIInterval = Web_SetInterval(mfncDragMoveCallback,mintDragMoveCallIInterval);
	}

	// return the drag frame
	return mobjDragElement;
}
/// </method>


/// <method name="Drag_MoveDragElement">
/// <summary>
/// Handles drag mouse move.
/// </summary>
/// <param name="objEvent">The browser mouse move event.</param>
function Drag_MoveDragElement(objEvent)
{
    // Preserve last target which was dragged over.
    mobjDraggedOverElement = Web_GetExplicitOriginalTarget(objEvent);
    
    // Define offset variables.
    var intOffsetX = 0;
    var intOffsetY = 0;
	
	// In case that offset was defined, get its values.
    if(mobjDragOffset)
    {
	    intOffsetX = mobjDragOffset.X;
	    intOffsetY = mobjDragOffset.Y;
    }
    
    // Get mouse position from event object.
	var objMousePosition = Web_PointFromEvent(objEvent);
	
	// Get event's absolute x and y mouse positions.
    var intClientX = objMousePosition.left;
    var intClientY = objMousePosition.top;
	
	// Check if a drag region was defined.
    if(mobjDragRegion!=null)
    {
        // Check if the mouse curssor has exceed the left border of the drag region.
	    if(mobjDragRegion.left>intClientX)
	    {
	        // Set the mouse x position to the left border of the drag region.
	        intClientX=mobjDragRegion.left;
	    }
	    
        // Check if the mouse curssor has exceed the right border of the drag region.
	    if(mobjDragRegion.right<intClientX - intOffsetX) 
	    {
	        // Set the mouse x position to the right border of the drag region.
	        intClientX=mobjDragRegion.right + intOffsetX;
	    }
	    
        // Check if the mouse curssor has exceed the top border of the drag region.	    
	    if(mobjDragRegion.top>intClientY - intOffsetY) 
	    {
	        // Set the mouse y position to the top border of the drag region.
	        intClientY=mobjDragRegion.top + intOffsetY;
	    }
	    
        // Check if the mouse curssor has exceed the bottom border of the drag region.
	    if(mobjDragRegion.bottom<intClientY - intOffsetY) 
	    {
	        // Set the mouse y position to the bottom border of the drag region.
	        intClientY=mobjDragRegion.bottom + intOffsetY;
	    }
    }
	
	// Switch drag type.
    switch(mintDragType)
    {
	    case mcntDragMoveHorz:
	        // Set drag frame's rectangle's left position.
		    mobjDragRect.left = intClientX - intOffsetX;
		    
	        // Set drag frame's rectangle's right position.		    
		    mobjDragRect.right = mobjDragRect.left + mintDragWidth;
		    break;
	    case mcntDragMoveVert:
	        // Set drag frame's rectangle's top position.
		    mobjDragRect.top = intClientY - intOffsetY;
		    
	        // Set drag frame's rectangle's bottom position.
		    mobjDragRect.bottom = mobjDragRect.top + mintDragHeight;
		    break;
	    case mcntDragMoveFree:
	        // Set drag frame's rectangle's left position.
		    mobjDragRect.left = intClientX - intOffsetX;
		    
	        // Set drag frame's rectangle's right position.		    
		    mobjDragRect.right = mobjDragRect.left + mintDragWidth;
		    
	        // Set drag frame's rectangle's top position.
		    mobjDragRect.top = intClientY - intOffsetY;
		    
	        // Set drag frame's rectangle's bottom position.
		    mobjDragRect.bottom = mobjDragRect.top + mintDragHeight;
		    break;
	    default:
		    if(mintDragType & mcntDragResizeTop)
		    {
			    mobjDragRect.top = intClientY;
		    }
		    if(mintDragType & mcntDragResizeBottom)
		    {
			    mobjDragRect.bottom = intClientY;
		    }
		    if(mintDragType & mcntDragResizeLeft)
		    {
			    mobjDragRect.left = intClientX;
		    }
		    if(mintDragType & mcntDragResizeRight)
		    {
		        mobjDragRect.right = intClientX;
		    }
		    break;
    }

	
    // Syncronize drag frame to draged element
    with(mobjDragElement.style)
    {
        // Set drag frame positions.
	    left = mobjDragRect.left + "px";
	    top = mobjDragRect.top + "px";
	    
	    // Calculate drag frame width out of its recangle.
	    var intWidth = mobjDragRect.right-mobjDragRect.left;
	    
	    // In case of a positive width, set it to the drag frame.
	    if(intWidth>0)
		{
		    width = intWidth + "px";
		}
		
	    // Calculate drag frame height out of its recangle.		
		var intHeight = mobjDragRect.bottom-mobjDragRect.top;
		
	    // In case of a positive height, set it to the drag frame.
	    if(intHeight>0)
		{
		    height = intHeight + "px";
		}
    }
}
/// </method>

/// <method name="Drag_HideDragElement">
/// <summary>
/// Returns and syncronizes a drag frame.
/// </summary>
/// <param name="objEvent">The browser drop event.</param>
function Drag_HideDragElement(objEvent)
{        
    if  (mobjDragElement && 
        mobjDragElement.parentNode &&
        mobjDragElement.parentNode.style.display != "none")
    {
        // Define x an y position.
        var intX = mobjDragRect.left + 1;
        var intY = mobjDragRect.top - 1;

        // Get target element according to x and y position.
        var objTargetElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);

        if (!objTargetElement)
        {
            // Get last dragged over element.
            objTargetElement = mobjDraggedOverElement;
        }

        // Invoke the element's 'Drop' handler (if one exists)
        Drag_InvokeTargetElementMethod(objTargetElement, "vwgDragDropHandler");

	    // show and capture events
	    mobjDragElement.parentNode.style.display = "none";	    
	    Web_SetInnerHtml(mobjDragElement, "");
	    Web_ReleaseCapture(mobjDragElement);
	    
	    // Clear the drag move function call interval.
        if(mobjDragMoveCallIInterval)
        {
            Web_ClearInterval(mobjDragMoveCallIInterval);
        }
    	
	    if(mfncDragDropCallback)
	    {
		    mfncDragDropCallback(mobjDragRect,mobjDragRectOld,objEvent);
	    }
	    
        // Reset drag locals and event listeners.
        Drag_InitializeDragAndDrop();
	}
	
	// Uncover all iframes from drag window.
    Drag_UnCoverIFrameElements();
}
/// </method>

/// <method name="Drag_CancelEvent">
/// <summary>
/// Handles drag starting.
/// </summary>
/// <param name="objEvent">The browser event object.</param>
function Drag_CancelEvent(objEvent)
{
    if(objEvent)
    {
        objEvent.returnValue = false;
    }

    return false;
}
/// </method>

/// <method name="Drag_FireDragDrop">
/// <summary>
/// Drag drop event.
/// </summary>
/// <param name="objSource">Not supported yet.</param>
function Drag_FireDragDrop(strSourceElementId,strTargetElementId,strExplicitDropTargetDataId,strKeyState,strCursorPosition,strRelativePosition, blnSuspendEvents)
{
	if (!Aux_IsNullOrEmpty(strSourceElementId)) {		

		// Create the DragDrop event
		var objVwgEvent = Events_CreateEvent(strTargetElementId, "DragDrop", null, true);

		// Fill up relevant attributes.
		Events_SetEventAttribute(objVwgEvent, "Attr.DragSource", strSourceElementId);
		Events_SetEventAttribute(objVwgEvent, "Attr.ExplicitTarget", strExplicitDropTargetDataId);
		Events_SetEventAttribute(objVwgEvent, "Attr.KeyState", strKeyState);
		Events_SetEventAttribute(objVwgEvent, "Attr.CursorPosition", strCursorPosition);
		Events_SetEventAttribute(objVwgEvent, "Attr.RelativePosition", strRelativePosition);

		// Checks if event is critical.
		if (Data_IsCriticalEvent(strTargetElementId, "Event.DragDrop", false) && !blnSuspendEvents) {
			Events_RaiseEvents();
		}

		Events_ProcessClientEvent(objVwgEvent);

	}
}
/// </method>


/// <method name="Drag_HandleStartDrag">
/// <summary>
/// Start drag event.
/// </summary>
function Drag_HandleStartDrag(strSourceElementId)
{   
    if(!Aux_IsNullOrEmpty(strSourceElementId))
    {
        // Create the DragDrop event
        var objVwgEvent = Events_CreateEvent(strSourceElementId,"StartDrag",null, true); 
        
        // Checks if event is critical.
        if (Data_IsCriticalEvent(strSourceElementId, "Event.StartDrag", false))
        {
            Events_RaiseEvents();
        }

        Events_ProcessClientEvent(objVwgEvent);
    }
}
/// </method>

/// <method name="Drag_GetViewByTagName">
/// <summary>
/// 
/// </summary>
function Drag_GetViewByTagName(strGuid,strTagName)
{   
    // Define empty view string.
    var strViewByTagName = null;
    
    // Validate received guid.
    if(strGuid!=null && strGuid!="")
    {   
        // Try getting a node.
        var objNode = Data_GetNode(Data_GetDataId(strGuid));
        
        if(objNode)
        {   
            // Define a null tag element.
            var objTagElement = null;
            
            // Create a tag element node.
            objTagElement = Xml_CreateNode(mobjDataDomObject,1,strTagName,"http://www.gizmox.com/webgui");
           
            if(objTagElement)
            {
                // Append tag element to the receieved component's node.
                objNode.appendChild(objTagElement);
                
                // Transform the received component's xml into html.
                strViewByTagName = Xml_TransformToHTML(objTagElement);
                
                // Remove the tag element from the receieved component's node.
                objNode.removeChild(objTagElement);
            }
        }
    }
    
    // Return a tag view html string.
    return strViewByTagName;
}
/// </method>

/// <method name="Drag_GetValidDropTarget">
/// <summary>
/// 
/// </summary>
function Drag_GetValidDropTarget(objDraggedOverElement,arrSubjectDragTargets)
{
    // Validate recieved arguments.
    if( mobjDragWindow &&
        objDraggedOverElement && 
        arrSubjectDragTargets && arrSubjectDragTargets.length>0)
    {
        // Get the VWG dragged over element.
        var objVwgDraggedOverElement = Web_GetVwgElement(objDraggedOverElement);
        if(objVwgDraggedOverElement)
        {
            // Defein an empty xpath variable.
            var strXPath = "";

            // Get explicit target data id.
            var strExplicitDropTargetDataId = Data_GetDataId(objVwgDraggedOverElement.id);

            // Get dragged over node.
            var objVwgDraggedOverNode = Data_GetNode(strExplicitDropTargetDataId);
            if(objVwgDraggedOverNode)
            {
                // Loop all drag targets.
                for(var i=0; i<arrSubjectDragTargets.length; i++)
                {
                    // Check if XPath is not empty and add "or" operator.
                    if(!Aux_IsNullOrEMpty(strXPath))
                    {
                        strXPath+=" or ";
                    }

                    // Add current drag target to XPath.
                    strXPath+="@Attr.Id='"+arrSubjectDragTargets[i]+"'";
                }

                // Complete XPath statement.
                strXPath = "ancestor-or-self::*[("+strXPath+") and (@Attr.AllowDrop='1' and not(ancestor-or-self::*[@Attr.Enabled='0']))]";

                // Try selecting a taget node.
                var objValidDropTargetNode = Xml_SelectSingleNode(strXPath,objVwgDraggedOverNode);
                if(objValidDropTargetNode)
                {
                    // Try getting the target node ID.
                    var strValidDropTargetDataId = Xml_GetAttribute(objValidDropTargetNode,"Attr.Id");
                    var strDropIndicatorPropogation = Xml_GetAttribute(objValidDropTargetNode,"Attr.DropIndicatorPropogation","1");
                    if(!Aux_IsNullOrEMpty(strValidDropTargetDataId))
                    {
                        // Return a valid drop target struct.
                        return { ValidDropTargetElement: Web_GetElementByDataId(strValidDropTargetDataId, mobjDragWindow), ValidDropTargetDataId: strValidDropTargetDataId, DropIndicatorPropogation: strDropIndicatorPropogation, ExplicitDropTargetElement: Web_GetElementByDataId(strExplicitDropTargetDataId, mobjDragWindow), ExplicitDropTargetDataId: strExplicitDropTargetDataId };
                    }
                }
            }
        }
    }

    return null;
}
/// </method>

/// <method name="Drag_InitializeDragAndDrop">
/// <summary>
/// 
/// </summary>
function Drag_InitializeDragAndDrop()
{
    // Deattach drag and drop events.
    Drag_DeAttachEvents();
    
    // Clear all local references.
    mobjDragSubject = null;
    mobjDragWindow = null;
    mobjDraggedOverContainer = null;
    mblnDragDown = false;
    mblnDragLeave = false;
}
/// </method>

/// <method name="Drag_GetDragTargets">
/// <summary>
/// 
/// </summary>
function Drag_GetDragTargets(objElement)
{   
    // Check that the received element is not null.
    if(objElement)
    {
        // Try getting the drag targets of the drag source element.  
        var strDragTargets = Web_GetAttribute(objElement, "vwgdragtargets", true);
        if(!Aux_IsNullOrEmpty(strDragTargets))
        {
            // Parse drag targets.
            return strDragTargets.split(',');
        }
    }
    
    return null;
}
/// </method>

/// <method name="Drag_GetReferencedDragTargets">
/// <summary>
/// 
/// </summary>
function Drag_GetReferencedDragTargets(objElement, objWindow)
{
	// Validate recieved arguments.
    if (objElement && objWindow)
    {
        // Get the referenced component ID that contains the drag targets for this control
        var strReferencedDragTargetsControlId = Web_GetAttribute(objElement, "vwgDragTargetsComponent", true);
        if (!Aux_IsNullOrEmpty(strReferencedDragTargetsControlId))
        {
            // Get the actual control
            var objRemoteElement = Web_GetElementById("VWG_" + strReferencedDragTargetsControlId, objWindow);
            if (objRemoteElement)
            {
				// Return refferenced component's drag target.
                return Drag_GetDragTargets(objRemoteElement);
            }
        }
    }

    return null;
}
/// </method>

/// <method name="Drag_OnDrop">
/// <summary>
/// 
/// </summary>
function Drag_OnDrop(objSourceElementRect,objSourceElementOldRect,objEvent)
{   
    // Removes the DropTargetElement - if exists.
    Drag_RemoveDropTargetElement();

    if (objSourceElementRect && mobjDragSubject && mobjDragWindow)
    {
        // Get drag descriptor.
        var objDragData = Drag_GetDragDescriptor(mobjDragSubject, mobjDragWindow);
        if (objDragData)
        {
            var arrDragTargets = objDragData.DragTargets;
            var objDragableSourceElement = objDragData.DragSource;

            var strTargetElementDataId = null;
            var strExplicitDropTargetDataId = null;

            // Define x an y position.
            var intX = mobjDragRect.left + 1;
            var intY = mobjDragRect.top - 1;

            // Get target element according to x and y position.
            var objTargetElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);
            if (!objTargetElement)
            {
                // Get last dragged over element.
                objTargetElement = mobjDraggedOverElement;
            }

            // Check the a target element was found.
            if (objTargetElement)
            {
                // Get valid drop target struct.
                var objValidDropTargetStruct = Drag_GetValidDropTarget(objTargetElement, arrDragTargets);
                if (objValidDropTargetStruct)
                {
                    // Get valid drop target data ids.
                    strTargetElementDataId = objValidDropTargetStruct.ValidDropTargetDataId;
                    strExplicitDropTargetDataId = objValidDropTargetStruct.ExplicitDropTargetDataId;
                }
            }

            // Check if a proper drop target found.
            if (!Aux_IsNullOrEmpty(strTargetElementDataId) &&
                        !Aux_IsNullOrEmpty(strExplicitDropTargetDataId))
            {
                // Get the VWG source element.
                var objVwgDragSubject = Web_GetVwgElement(mobjDragSubject, true, false, true);

                // Get the VWG source element id.
                var strSourceElementId = Data_GetDataId(Web_GetId(objVwgDragSubject));
                if (!Aux_IsNullOrEmpty(strSourceElementId))
                {
                    // Define key state.
                    var intKeyState = 0;

                    if (objEvent)
                    {
                        if (Web_IsShift(objEvent))
                        {
                            intKeyState |= 4;
                        }
                        if (Web_IsControl(objEvent))
                        {
                            intKeyState |= 8;
                        }
                        if (Web_IsAlt(objEvent))
                        {
                            intKeyState |= 32;
                        }
                    }

                    // Get the relative drop location to the drop target.
                    var objExplicitDropTargetElement = Web_GetElementByDataId(strExplicitDropTargetDataId, mobjDragWindow);
                    var objExplicitDropTargetRect = Web_GetRect(objExplicitDropTargetElement, true);

                    var intRelativeX = objSourceElementRect.left - objExplicitDropTargetRect.left;
                    var intRelativeY = objSourceElementRect.top - objExplicitDropTargetRect.top;

                    // If the drop target is scrollable, we should add the scrolling value to the relative position.
                    var objExplicitDropTargetScrollableElement = Controls_GetScrollableElement(objExplicitDropTargetElement);
                    if (objExplicitDropTargetScrollableElement) {
                        intRelativeX += $(objExplicitDropTargetScrollableElement).scrollLeft();
                        intRelativeY += $(objExplicitDropTargetScrollableElement).scrollTop();
                    }

                    //  Fire the DragDrop event.
                    Drag_FireDragDrop(strSourceElementId, strTargetElementDataId, strExplicitDropTargetDataId, intKeyState, (objSourceElementRect.left + "," + objSourceElementRect.top), (intRelativeX + "," + intRelativeY), false);
                }
            }
        }
    }

    // Reset scrollable container.
    Drag_ResetDragAndDropScrolling();
}
/// </method>

/// <method name="Drag_GetDragDescriptor">
/// <summary>
/// 
/// </summary>
function Drag_GetDragDescriptor(objSourceElement, objWindow)
{
    // Validate recieved arguments.
    if (objSourceElement && objWindow)
    {
        // Get drag subject VWG element.
        var objVwgDragSubjectElement = Web_GetVwgElement(objSourceElement, false, false, true);
        if (objVwgDragSubjectElement)
        {
            // Loop to find the first draggable VWG element.
            while(objVwgDragSubjectElement && Web_IsAttribute(objVwgDragSubjectElement, "vwgAllowDrag", "0", true))
            {
                objVwgDragSubjectElement = Web_GetVwgElement(objVwgDragSubjectElement.parentNode, false, false, true);
            }

            // Validate draggable VWG element.
            if(objVwgDragSubjectElement)
            {
                var objReturnData = null;

                // Try getting local drag targets.
                var arrTargets = Drag_GetDragTargets(objVwgDragSubjectElement);
                if (arrTargets) 
                {
                    // Return local drag targets.
                    objReturnData = { DragTargets: arrTargets, DragSource: objVwgDragSubjectElement };
                }
                else 
                {
                    // Try getting refferenced drag data
                    arrTargets = Drag_GetReferencedDragTargets(objVwgDragSubjectElement, objWindow);
                    if (arrTargets)
                    {
                        // Return refferenced drag targets.
                        objReturnData = { DragTargets: arrTargets, DragSource: objVwgDragSubjectElement };
                    }
                    else // Try getting propegated drag data
                    {
                        var objVwgPropogatingElement = objVwgDragSubjectElement;

                        // Loop to find the first VWG element which has drag targets and allows propogation.
                        while(  objVwgPropogatingElement && 
                                (!arrTargets || 
                                Web_IsAttribute(objVwgPropogatingElement, "vwgallowdragtargetspropegate", "0", true)))
                        {
                            // Get next parent VWG element.
                            objVwgPropogatingElement = Web_GetVwgElement(objVwgPropogatingElement.parentNode, false, false, true);
                            if(objVwgPropogatingElement)
                            {
                                // Try getting drag target of current VWG element.
                                arrTargets = Drag_GetDragTargets(objVwgPropogatingElement);
                            }
                        }

                        // Validate propogating element and its drag targets.
                        if(objVwgPropogatingElement && arrTargets)
                        {
                        // Return propogating element's drag targets and draggable VWG element as drag source.
                        objReturnData = { DragTargets: arrTargets, DragSource: objVwgDragSubjectElement };
                    }
                }
                        }

                if (objReturnData)
                {
                    var arrExcludedDragTargets = Web_GetAttribute(objReturnData.DragSource, "vwgExcludedDragTargets", "", true);
                    if(!Aux_IsNullOrEMpty(arrExcludedDragTargets))
                    {
                        arrExcludedDragTargets = arrExcludedDragTargets.split(',');
                        if(arrExcludedDragTargets.length > 0)
                        {
                            // Get drag source data id.
                            var strDragSourceId = Data_GetDataId(objReturnData.DragSource.id);
                            if(!Aux_IsNullOrEMpty(strDragSourceId))
                            {
                                // Exclude the the dragSource's ID from drag target
                                var arrTargetsHolder = [];

                                // Loop all drag targets.
                                for (var i = 0; i < objReturnData.DragTargets.length; ++i)
                                {
                                    // Check if current drag target is the drag source it self.
                                    if (!arrExcludedDragTargets.contains(objReturnData.DragTargets[i]))
                                    {
                                        // Push current drag target id to new array.
                                        arrTargetsHolder.push(objReturnData.DragTargets[i]);
                                    }
                                }

                                // Update drag targets array with updated value.
                                objReturnData.DragTargets = arrTargetsHolder;
                            }
                        }
                    }
                }

                return objReturnData;
            }
        }
    }

    return null;
}
/// </method>


/// <method name="Drag_InvokeTargetElementMethod">
/// <summary>
/// 
/// </summary>
function Drag_InvokeTargetElementMethod(objElement, strInvokationAttribute, arrParameters)
{
    // If no parameters where given just create an empty one
    if (!arrParameters)
    {
        arrParameters = [];
    }

    // Get the handler string from the relevant attribute
    var strDragMoveHandler = Web_GetAttribute(objElement, strInvokationAttribute, true);

    if (!Aux_IsNullOrEMpty(strDragMoveHandler))
    {
        // Get the function from the string
        var fncDragMoveHandler = Remoting_GetMethod(strDragMoveHandler);

        if (fncDragMoveHandler != null)
        {
            // Invoke the method with the relevant params
            Aux_InvokeMethod(fncDragMoveHandler, [objElement].concat(arrParameters));
        }
    }
}
/// </method>

/// <method name="Drag_AttachEvents">
/// <summary>
/// 
/// </summary>
function Drag_AttachEvents()
{
    if(mobjDragSubject)
    {
        // Attach leave / out event.
        if(mcntIsIE)
        {
            Web_AttachEvent(mobjDragSubject,"mouseleave",Drag_OnMouseLeave);
        }
        else
        {
            Web_AttachEvent(mobjDragSubject,"mouseout",Drag_OnMouseLeave);
        }
        
        // Attach mouse up event.
        Web_AttachEvent(mobjDragSubject,"mouseup",Drag_InitializeDragAndDrop);

        // Switch drag element's selection mode off.
        Drag_SwitchDragElementSelection(mobjDragWindow, mobjDragSubject, false);
    }
}
/// </method>

/// <method name="Drag_DeAttachEvents">
/// <summary>
/// 
/// </summary>
function Drag_DeAttachEvents()
{
    if(mobjDragSubject)
    {        
        // Deattach leave / out event.
        if(mcntIsIE)
        {
            Web_DetachEvent(mobjDragSubject,"mouseleave",Drag_OnMouseLeave);
        }
        else
        {
            Web_DetachEvent(mobjDragSubject,"mouseout",Drag_OnMouseLeave);
        }
        
        // Deattach mouse up event.
        Web_DetachEvent(mobjDragSubject,"mouseup",Drag_InitializeDragAndDrop);

        // Switch drag element's selection mode on.
        Drag_SwitchDragElementSelection(mobjDragWindow, mobjDragSubject, true);
    }
}
/// </method>

/// <method name="Drag_OnMouseLeave">
/// <summary>
/// 
/// </summary>
function Drag_OnMouseLeave()
{
    if(mblnDragDown && !mblnDragLeave && mobjDragSubject)
    {      
        // Flag on mouse leave
        mblnDragLeave = true;
    
        // Deattach drag and drop events.
        Drag_DeAttachEvents();
        
        // Handle start drag.
        Drag_HandleStartDrag(Data_GetDataId(mobjDragSubject.id));
        
        var strHtml = null;
        if (mblnApplyDraggedAppearance) {
            var strDragSubjectId = Data_GetDataId(mobjDragSubject.id);
            strHtml = Drag_GetViewByTagName(strDragSubjectId, "WG:Tags.DragElement");
        }
        // Show drag element.
        Drag_ShowDragElement(Web_GetRect(mobjDragSubject), mintDragType, mobjDragWindow, mfncDragDropCallback, mobjDragOffset, mobjDragRegion, strHtml, mfncDragMoveCallback, mintDragMoveCallIInterval);
    }
}
/// </method>

/// <method name="Drag_OnTargetElementSelectStart">
/// <summary>
/// 
/// </summary>
function Drag_OnTargetElementSelectStart()
{
    return false;
}
/// </method>

/// <method name="Drag_SwitchDragElementSelection">
/// <summary>
/// 
/// </summary>
function Drag_SwitchDragElementSelection(objWindow, objElement, blnSelectionOn)
{
    // Validate received arguments.
    if(objWindow && objElement)
    {
        // Get drag target element.
        var objTargetElement = Web_GetTargetElementByDataId(Data_GetDataId(objElement.id),objWindow);
        if(objTargetElement)
        {
            // Get target element tag name.
            var strTargetTagName  = objTargetElement.tagName.toLowerCase();
        
            // Switch target element tag name.
            switch (strTargetTagName) 
            {
                case "input":
                case "textarea":
                    // Get a jQuery target element.
                    objTargetElement = $(objTargetElement);
                    
                    // In case of an IE browser, attach or deattach select start event and cancel it.
                    if(mcntIsIE)
                    {
                        if(blnSelectionOn)
                        {
                            objTargetElement.unbind("selectstart", Drag_OnTargetElementSelectStart);
                        }
                        else
                        {
                            objTargetElement.bind("selectstart", Drag_OnTargetElementSelectStart);
                        }
                    }
                    // In case of a none IE browser, add or remove a class which disable selection.
                    else
                    {
                        if(blnSelectionOn)
                        {
                            objTargetElement.removeClass("Common-Unselectable");
                        }
                        else
                        {
                            objTargetElement.addClass("Common-Unselectable");
                        }
                    }
                    break;
            }
        }
    }
}
/// </method>

/// <method name="Drag_RegisterDragElement">
/// <summary>
/// 
/// </summary>
function Drag_RegisterDragElement(objDragElement,intDragType,objWindow,objEvent,fncDragDropCallback,objOffset,objRegion,blnApplyDraggedAppearance,fncDragMoveCallback,intDragMoveCallIInterval)
{
     // Flag that mouse is down.
    mblnDragDown = true;
    
    // Save local drag parameters.
    mobjDragSubject             = objDragElement;
    mintDragType		        = intDragType;
    mobjDragWindow              = objWindow;
    mfncDragDropCallback        = fncDragDropCallback;
    mobjDragOffset		        = objOffset;
    mobjDragRegion = objRegion;
    mblnApplyDraggedAppearance  = blnApplyDraggedAppearance;
    mfncDragMoveCallback        = fncDragMoveCallback;
    mintDragMoveCallIInterval   = intDragMoveCallIInterval;
    
    // Attach drag and drop events.
    Drag_AttachEvents();
}
/// </method>

/// <method name="Drag_InitDragAndDropScrolling">
/// <summary>
/// 
/// </summary>
function Drag_InitDragAndDropScrolling(objDraggedOverElement)
{
    // Check that scrolling synchronization function is not already active.
    if(mintSyncDragAndDropScrollTimeOut==0)
    {
        // Validate recieved drag over element.
        if(objDraggedOverElement)
        {
            // Define an empty scrollable parent.
            var objDraggedOverScrollableParent = null;
            
            // Check if the dragged over element is dragged over floating element or an element which is contained in it.
            if(Web_GetId(objDraggedOverElement)=="VWG_DraggedOverFloatingElement")
            {
                // Try getting the dragged over floating element out of drag window.
                var objDraggedOverFloatingElement = Web_GetElementById("VWG_DraggedOverFloatingElement", mobjDragWindow);
                if(objDraggedOverFloatingElement)
                {
                    // Try getting the preserved dragged over element out of the dragged over floating.
                    var strPreservedDraggedOverElement = Web_GetAttribute(objDraggedOverFloatingElement,"vwg_DraggedOverElement",true);
                    if(!Aux_IsNullOrEmpty(strPreservedDraggedOverElement))
                    {
                        // Try getting the preserved dragged over element.
                        var objPreservedDraggedOverElement = Web_GetElementByDataId(strPreservedDraggedOverElement,mobjDragWindow);
                        if(objPreservedDraggedOverElement)
                        {
                            // Try getting contained scrollable element.
                            objDraggedOverScrollableParent = Controls_GetScrollableElement(objPreservedDraggedOverElement);

                            // Check if scrollable element was found, if not try going up
                            if (!objDraggedOverScrollableParent)
                            {
                                objDraggedOverScrollableParent = Web_GetScrollableParent(objPreservedDraggedOverElement);
                            }
                        }
                    }
                }
            }
            else
            {
                // Get scrollable parent.
                objDraggedOverScrollableParent = Web_GetScrollableParent(objDraggedOverElement);
            }
            
            // Validate the scrollable container and the drag subject's scrolling location.
            if(Drag_GetScrollingDirection(objDraggedOverScrollableParent)!=0)
            {                
                // Preserve the srollable container.        
                mobjScrollableContainer = objDraggedOverScrollableParent;
                
                // Asynch execution of the Drag_SyncDragAndDropScrolling function.
                mintSyncDragAndDropScrollTimeOut = Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Drag_SyncDragAndDropScrolling),mcntScrollingDetectionTimeOut);
            }
        }
    }
}
/// </method>

/// <method name="Drag_OnMove">
/// <summary>
/// Handles the drag on move event.
/// </summary>
/// <param name="objSource">Gets the ID of the component related with this element.</param>
function Drag_OnMove()
{   
    // Validate drag window, drag subject, and drag subject's rectangle.
    if(mobjDragWindow && mobjDragSubject && mobjDragRect)
    {   
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetVwgElement(mobjDragSubject,false,false,true);
        if(objVwgDragSubject)
        {
			// Get drag descriptor.
            var objDragData = Drag_GetDragDescriptor(objVwgDragSubject, mobjDragWindow);
            if (objDragData != null)
            {
				// Get drag subjects from descriptor.
                var arrSubjectDragTargets = objDragData.DragTargets;

                // Define x an y position.
                var intX = mobjDragRect.left + 1;
                var intY = mobjDragRect.top - 1;
                
                // Get element according to x and y position. (If the blue div is displayed, it will be returned)
                var objDraggedOverElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);
                if(!objDraggedOverElement)
                {
                    // Get last dragged over element.
                    objDraggedOverElement = mobjDraggedOverElement;
                }
                    
                // Validate dragged over element.
                if(objDraggedOverElement)
                {
                    // Invoke the Drag Move Handler on the 'dragged over' element
                    Drag_InvokeTargetElementMethod(objDraggedOverElement, "vwgDragMoveHandler");

                    // Initialize drag and drop scrolling.
                    Drag_InitDragAndDropScrolling(objDraggedOverElement);
                    
                    // Get the preserved dragged element, which is saved when the blue div is created.
                    var strPreservedDraggedOverElementId = null;

                    // The Drop indicator propogation value
                    var strPreservedDropIndicatorPropogation = null;
                    
                    // Get the id of the element given by the selected point.
                    var strDraggedOverElementId = Web_GetId(objDraggedOverElement);

                    // Alternate element that might be other explicit element for dragging.
                    var objExplicitDraggedOverElement = null;
                    var strExplicitDraggedOverElementId = null;

                    // The element we are over on is the blue div.
                    if (strDraggedOverElementId == "VWG_DraggedOverFloatingElement")
                    {
                        // Get the blue div main container
                        var objDraggedOverFloatingElement = Web_GetElementById("VWG_DraggedOverFloatingElement", mobjDragWindow);
                        if (objDraggedOverFloatingElement)
                        {
                            // Try getting the preserved dragged over element out of the dragged over floating.
                            strPreservedDraggedOverElementId = Web_GetAttribute(objDraggedOverFloatingElement, "vwg_DraggedOverElement", true);

                            // Get the indicator propogation value saved
                            strPreservedDropIndicatorPropogation = Web_GetAttribute(objDraggedOverFloatingElement, "vwg_DropIndicatorPropogation", true);
                        }

                        // get the current display style of the blue div.
                        var strPrevDisplay = objDraggedOverFloatingElement.style.display;

                        // The following lines shuold occur in one function scope (to avoid screen/browser rerender and by that - blinking.)
                        // Set the style to none, 
                        objDraggedOverFloatingElement.style.display = "none";

                        // Try to get another explicit dragged over element.
                        objExplicitDraggedOverElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);
                        strExplicitDraggedOverElementId = Data_GetDataId(Web_GetVwgElement(objExplicitDraggedOverElement).id);

                        // Return the display style that was previously.
                        objDraggedOverFloatingElement.style.display = strPrevDisplay;
                    }

                    // Check that the source element is not the VWG_DraggedOverFloatingElement. if it is, check that the explicit element is not the preserved element.
                    if (strDraggedOverElementId != "VWG_DraggedOverFloatingElement" || (strDraggedOverElementId == "VWG_DraggedOverFloatingElement" && strPreservedDropIndicatorPropogation == '1' && strPreservedDraggedOverElementId && strExplicitDraggedOverElementId && strPreservedDraggedOverElementId != strExplicitDraggedOverElementId))
                    {                       
                        // Removes the DropTargetElement - if exists.
                        Drag_RemoveDropTargetElement();
                        
                        // Get the VWG dragged over element.
                        var objVwgDraggedOverElement = Web_GetVwgElement(objDraggedOverElement);
                        
                        // Validate the VWG dragged over element.
                        if(objVwgDraggedOverElement && Web_GetId(objVwgDraggedOverElement)!="VWG_DragHtmlIndicatorBox")
                        {
                            // Define an empty dragged over element data id.
                            var strDraggedOverElementDataId = null;

                            // Get valid drop target struct.
                            var objValidDropTargetStruct = Drag_GetValidDropTarget(objDraggedOverElement, arrSubjectDragTargets);
                            if(objValidDropTargetStruct)
                            {
                                if (objValidDropTargetStruct.DropIndicatorPropogation == '0')
                                {
                                    // Get valid actual drop target element and data id.
                                    objVwgDraggedOverElement = objValidDropTargetStruct.ValidDropTargetElement;
                                    strDraggedOverElementDataId = objValidDropTargetStruct.ValidDropTargetDataId;
                                }
                                else
                                {
                                    // Get valid explicit drop target element and data id.
                                    objVwgDraggedOverElement = objValidDropTargetStruct.ExplicitDropTargetElement;
                                    strDraggedOverElementDataId = objValidDropTargetStruct.ExplicitDropTargetDataId;
                                }
                            }

                            // Validate drop target element and data id.
                            if( !Aux_IsNullOrEmpty(strDraggedOverElementDataId) && objVwgDraggedOverElement)
                            {  
                                // Get dragged over container element.
                                var objDraggedOverContainerElement = Drag_GetDraggedOverContainer();
                                if(objDraggedOverContainerElement)
                                {
                                    // Get the dragged over element rectangle.
                                    var objVwgDraggedOverElementRect = Web_GetRect(objVwgDraggedOverElement);
                                    if(objVwgDraggedOverElementRect)
                                    {
                                        // Get the dragged over element's "draged over" view.
                                        var strDraggedOverView = Drag_GetViewByTagName(strDraggedOverElementDataId, "WG:Tags.DraggedOverElement");
                                        if(!Aux_IsNullOrEmpty(strDraggedOverView))
                                        {
                                            // Create a new DIV element.
                                            var objDraggedOverFloatingElement = mobjDragWindow.document.createElement("DIV");
                                            
                                            // Add floating element to its container.
                                            objDraggedOverContainerElement.appendChild(objDraggedOverFloatingElement);
                                            
                                            // Update the dragged over floating element id.
                                            objDraggedOverFloatingElement.id = "VWG_DraggedOverFloatingElement";

                                            // Set the dragged over floating element inner html.
                                            Web_SetInnerHtml(objDraggedOverFloatingElement, strDraggedOverView);
                                            
                                            // Set the dragged over floating element position to absolute.
                                            objDraggedOverFloatingElement.style.position = "absolute";
                                            
                                            // Set element's height and top.
                                            objDraggedOverFloatingElement.style.height = (objVwgDraggedOverElementRect.bottom - objVwgDraggedOverElementRect.top) + "px";
                                            objDraggedOverFloatingElement.style.top = objVwgDraggedOverElementRect.top + "px";
                                                
                                            // Set element's width and left. 
                                            objDraggedOverFloatingElement.style.width = (objVwgDraggedOverElementRect.right - objVwgDraggedOverElementRect.left) + "px";
                                            objDraggedOverFloatingElement.style.left = objVwgDraggedOverElementRect.left + "px";
                                            
                                            // Preserve the dragged over element id.
                                            Web_SetAttribute(objDraggedOverFloatingElement, "vwg_DraggedOverElement", strDraggedOverElementDataId);

                                            // Preserve the drop indicator propogation value
                                            Web_SetAttribute(objDraggedOverFloatingElement, "vwg_DropIndicatorPropogation", objValidDropTargetStruct.DropIndicatorPropogation);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Drag_RemoveDropTargetElement">
/// <summary>
/// Removes the DropTargetElement - if exists.
/// </summary>
function Drag_RemoveDropTargetElement()
{
    // Validate drag window.
    if(mobjDragWindow)
    {
        // Try getting the drop target element out of drag window.
        var objDraggedOverFloatingElement = Web_GetElementById("VWG_DraggedOverFloatingElement", mobjDragWindow);
        if(objDraggedOverFloatingElement)
        {
            // Get dragged over container element.
            var objDraggedOverContainerElement = Drag_GetDraggedOverContainer();
            if(objDraggedOverContainerElement)
            {
                // Remove floating element from its container.
                objDraggedOverContainerElement.removeChild(objDraggedOverFloatingElement);
            }
        }
    }
}
/// </method>

/// <method name="Drag_GetDraggedOverContainer">
/// <summary>
/// 
/// </summary>
function Drag_GetDraggedOverContainer()
{
    if(!mobjDraggedOverContainer && mobjDragWindow)
    {
        mobjDraggedOverContainer=Web_GetElementById("VWG_DragMarkBox",mobjDragWindow);
    }
    
    return mobjDraggedOverContainer;
}
/// </method>

/// <method name="Drag_GetScrollingDirection">
/// <summary>
/// Get the scrolliong direction as for the location of the drag subject whitin the recieved container.
// This function will return the following values:
/// 0 - When the drag subject is located at the center of the recieved container.
/// 1 - When the drag subject is located at the top margin of the recieved container.
/// 2 - When the drag subject is located at the right margin of the recieved container.
/// 3 - When the drag subject is located at the bottom margin of the recieved container.
/// 4 - When the drag subject is located at the left margin of the recieved container.
/// </summary>
function Drag_GetScrollingDirection(objContainer)
{   
    var intDirection = 0;
    
    if(mobjDragRect && objContainer)
    {
        // Get container's rectangle.
        var objContainerRect = Web_GetRect(objContainer);
        if(objContainerRect)
        {
            // Check that drag position is within container rectangle.
            if( mobjDragRect.top > objContainerRect.top &&
                mobjDragRect.top < objContainerRect.bottom &&
                mobjDragRect.left > objContainerRect.left &&
                mobjDragRect.left < objContainerRect.right)
            {
                // Check if located at top margin.
                if((mobjDragRect.top - objContainerRect.top) <= mcntScrollingMargins)
                {
                    intDirection = 1;
                }
                // Check if located at right margin.
                else if((objContainerRect.right - mobjDragRect.left) <= mcntScrollingMargins)
                {
                    intDirection = 2;
                }
                // Check if located at bottom margin.
                else if((objContainerRect.bottom - mobjDragRect.top) <= mcntScrollingMargins)
                {
                    intDirection = 3;
                }
                // Check if located at left margin.
                else if((mobjDragRect.left - objContainerRect.left) <= mcntScrollingMargins)
                {
                    intDirection = 4;
                }
            }
        }
    }
    
    return intDirection;
}
/// </method>

/// <method name="Drag_SyncDragAndDropScrolling">
/// <summary>
/// Synchronize scrolling position as for dragged subject position.
/// </summary>
function Drag_SyncDragAndDropScrolling()
{
    var intScrollingDirection = 0;
    
    if( mobjScrollableContainer  &&
        (intScrollingDirection = Drag_GetScrollingDirection(mobjScrollableContainer)) > 0)
    {
        var blnRecallSynch = false;
        
        switch(intScrollingDirection)
        {
            // Top Scrolling.
            case 1:
                // Validate scrolling position and drag move type.
                if  (mobjScrollableContainer.scrollTop > 0 && 
                    (mintDragType == mcntDragMoveVert || mintDragType == mcntDragMoveFree))
                {
                    // Update scrolling position.
                    mobjScrollableContainer.scrollTop -= mcntScrollingGaps;
                    
                    // Flag to recall the synch function.
                    blnRecallSynch = true;
                }
                break;
            // Right Scrolling.
            case 2:
                // Validate scrolling position and drag move type.
                if  (mobjScrollableContainer.scrollLeft < mobjScrollableContainer.scrollWidth && 
                    (mintDragType == mcntDragMoveHorz || mintDragType == mcntDragMoveFree))
                {
                    // Update scrolling position.
                    mobjScrollableContainer.scrollLeft += mcntScrollingGaps;
                    
                    // Flag to recall the synch function.
                    blnRecallSynch = true;
                }
                break;
            // Bottom Scrolling.
            case 3:
                // Validate scrolling position and drag move type.
                if (mobjScrollableContainer.scrollTop < mobjScrollableContainer.scrollHeight &&
                    (mintDragType == mcntDragMoveVert || mintDragType == mcntDragMoveFree))
                {
                    // Update scrolling position.
                    mobjScrollableContainer.scrollTop += mcntScrollingGaps;
                    
                    // Flag to recall the synch function.
                    blnRecallSynch = true;
                }
                break;
            // Left Scrolling.
            case 4:
                // Validate scrolling position and drag move type.
                if  (mobjScrollableContainer.scrollLeft > 0 && 
                    (mintDragType == mcntDragMoveHorz || mintDragType == mcntDragMoveFree))
                {
                    // Update scrolling position.
                    mobjScrollableContainer.scrollLeft -= mcntScrollingGaps;
                    
                    // Flag to recall the synch function.
                    blnRecallSynch = true;
                }
                break;
        }
        
        if(blnRecallSynch)
        {
            // Recall Drag_SyncDragAndDropScrolling.
            mintSyncDragAndDropScrollTimeOut = Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Drag_SyncDragAndDropScrolling),mcntScrollingInterval);
        }
        else
        {
            // Reset drag and drop scrolling.
            Drag_ResetDragAndDropScrolling();
        }
    }
    else
    {
        // Reset drag and drop scrolling.
        Drag_ResetDragAndDropScrolling();
    }
}
/// </method>

/// <method name="Drag_ResetDragAndDropScrolling">
/// <summary>
/// Resets scrollabel container and execution time out.
/// </summary>
function Drag_ResetDragAndDropScrolling()
{
    mobjScrollableContainer = null;
    mintSyncDragAndDropScrollTimeOut = 0;
}
/// </method>

/// </page>
