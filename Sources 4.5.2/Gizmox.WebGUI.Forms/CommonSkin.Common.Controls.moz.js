/// <page code="Controls" browser="moz">

/// <method name="Controls_SetInnerHtmlFromNode" access="private">
/// <summary>
/// Sets the inner html from a given node
/// </summary>
/// <param name="objElement">The element to set it's inner html.</param>
/// <param name="objNode">The node to transform to get inner html.</param>
function Controls_SetInnerHtmlFromNode(objWindow, objElement, objNode, strGuid)
{
     // Get the html dom
    var objHtmlDom = Controls_GetHtmlDomFromNode(objNode,strGuid);
    if(objHtmlDom)
    {
        // clear the current content
        Web_SetInnerHtml(objElement, "");
        
        // Append the new content
        $(objElement).append(objHtmlDom);

    }
}
/// </method>

/// <method name="Controls_SetInnerHtmlFromNode" access="private">
/// <summary>
/// Sets the outer html from a given node
/// </summary>
/// <param name="objElement">The element to set it's inner html.</param>
/// <param name="objNode">The node to transform to get inner html.</param>
function Controls_SetOuterHtmlFromNode(objWindow, objElement, objNode, strGuid)
{
    // Get the html dom
    var objHtmlDom = Controls_GetHtmlDomFromNode(objNode,strGuid);
    if(objHtmlDom)
    {
        // Get the element parent node
        var objParent = objElement.parentNode;
        if(objParent)
        {
            // Get replaced element's focus element.
            var objFocusElement = Controls_GetFocusElement(objElement);
            if(objFocusElement)
            {
                // Clear blur and focus out events so it won't be called on parent's replacement.
                objFocusElement.onblur=null;
                objFocusElement.onfocusout=null;
            }
            
            // Replace the child node
            $(objElement).replaceWith(objHtmlDom);

			// Update hash reference.
            if (mblnFullScreenMode && mobjFormsWindowById[objElement.id])
            {
                mobjFormsWindowById[objElement.id] = objHtmlDom;
            }
            
            // Perfoprm parent layout.
	        Layout_PerformLayout(objParent);
        }
    }
}
/// </method>


/// <method name="Controls_GetHtmlDomFromNode" access="private">
/// <summary>
/// Gets a html dom representation of a given node.
/// </summary>
/// <param name="objNode">The node to get its html.</param>
/// <param name="strGuid" optional="true">Node guid used for tracing.</param>
function Controls_GetHtmlDomFromNode(objNode,strGuid)
{
	if(!Aux_IsNullOrEmpty(strGuid)) 
	{
	    Trace_Time("Controls","GetControlHTML");
	}
	
	// Reset the delayed drawing flag
	Xml_SetAttribute(objNode,"Attr.IsDelayedDrawing","0");
	
	// Transform HTML.
	var objHtmlDom	= Xml_TransformToDom(objNode);

	if(!Aux_IsNullOrEmpty(strGuid)) 
	{
	    Trace_Write("Transform control data to HTML.",strGuid);
	}
	
	return objHtmlDom;
}
/// </method>

/// <method name="Controls_UpdateWidth" access="private">
/// <summary>
/// Updates a given control width
/// </summary>
/// <param name="strGuid">The node guid of the current control.</param>
/// <param name="objElement">The browser element to be updated.</param>
/// <param name="intWidth">The control new width value.</param>
function Controls_UpdateWidth(strGuid,objElement,intWidth)
{
	// Get current node
	var objNode = Data_GetNode(strGuid);
	if(objNode)
	{
		// Set width
		Xml_SetAttribute(objNode,"Attr.Width",intWidth);
		
		// Recalculate layout
		Controls_Layout(objElement.parentNode,true,false,false);
	}
}
/// </method>

/// <method name="Controls_UpdateHeight" access="private">
/// <summary>
/// Updates a given control height
/// </summary>
/// <param name="strGuid">The node guid of the current control.</param>
/// <param name="objElement">The browser element to be updated.</param>
/// <param name="intHeight">The control new height value.</param>
function Controls_UpdateHeight(strGuid,objElement,intHeight)
{
	// Get current node
	var objNode = Data_GetNode(strGuid);
	if(objNode)
	{
		// Set height
		Xml_SetAttribute(objNode,"H",intHeight);
		
		// Recalculate layout
		Controls_Layout(objElement.parentNode,false,true,false);
	}
}
/// </method>

/// <method name="Controls_Layout" access="private">
/// <summary>
/// Updates docked controls layout
/// </summary>
/// <param name="objElement">The element to update its layout.</param>
/// <param name="">Update horizontal layout flag.</param>
/// <param name="">Update vertical layout flag.</param>
/// <param name="">Recursivly update the layout of this control and all sub controls.</param>
function Controls_Layout(objElement,blnHorizontal,blnVertival,blnRecursive)
{
	//getting base padding info from the container. (using private attributes and not the actual padding)    
    var intTop = Number(Web_GetAttribute(objElement,"vwgpaddingtop",true));
    var intBottom = Number(Web_GetAttribute(objElement, "vwgpaddingbottom",true));
    var intLeft = Number(Web_GetAttribute(objElement, "vwgpaddingleft",true));
    var intRight = Number(Web_GetAttribute(objElement, "vwgpaddingright",true));

	var objCurrent	= objElement.firstChild;
		
		while(objCurrent)
		{
			var strLayout = Web_GetAttribute(objCurrent,"vwgdocking");
			
			switch(strLayout)
			{
				case "F":
					if(blnVertival)
			        {
				        objCurrent.style.top		= intTop+"px";
				        objCurrent.style.bottom	= intBottom+"px";
			        }
			        if(blnHorizontal)
			        {
				        objCurrent.style.left		= intLeft+"px";
				        objCurrent.style.right		= intRight+"px";
			        }
					break;
				case "T":
					if(blnVertival)
					{
						objCurrent.style.top = intTop+"px";
						intTop+=parseInt(objCurrent.style.height);
					}
					if(blnHorizontal)
					{
						objCurrent.style.left = intLeft+"px";
						objCurrent.style.right = intRight+"px";
					}
					
					break;
				case "B":
					if(blnVertival)
					{
						objCurrent.style.bottom = intBottom+"px";
						intBottom+=parseInt(objCurrent.style.height);
					}
					if(blnHorizontal)
					{
						objCurrent.style.left = intLeft+"px";
						objCurrent.style.right = intRight+"px";
					}
					break;
				case "L":
					if(blnHorizontal)
					{
						objCurrent.style.left = intLeft+"px";
						intLeft+=parseInt(objCurrent.style.width);
					}
					if(blnVertival)
					{
						objCurrent.style.top = intTop+"px";
						objCurrent.style.bottom = intBottom+"px";
					}
					break;
				case "R":
					if(blnHorizontal)
					{
						objCurrent.style.right = intRight+"px";
						intRight+=parseInt(objCurrent.style.width);
					}
					if(blnVertival)
					{
					    objCurrent.style.top = intTop+"px";
						objCurrent.style.bottom = intBottom+"px";
					}
					break;
			}
			
			objCurrent = objCurrent.nextSibling;
		}
	
		
		if(blnRecursive)
		{
			objCurrent	= objElement.firstChild;
			
			while(objCurrent)
			{
				Controls_Layout(objCurrent,blnHorizontal,blnVertival,blnRecursive);
				objCurrent = objCurrent.nextSibling;
			}
		}
}
/// </method>

/// </page>