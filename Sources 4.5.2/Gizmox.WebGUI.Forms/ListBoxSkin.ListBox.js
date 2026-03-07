
var mintListBoxClickTimeout = 0;

/// <method name="ListBox_ScrollIntoView">
/// <summary>
///
/// </summary>
function ListBox_ScrollIntoView(strGuid, strIndex)
{
    var objWindow = Forms_GetWindowByDataId(strGuid);
    
    if(objWindow)
    {
        var objListBoxItem = Web_GetElementById("VWGE_" + strGuid + "_" + strIndex,objWindow);
        
        if(objListBoxItem)
        {
            Web_ScrollIntoView(objListBoxItem);
        }
    }
}
/// </method>

/// <method name="ListBox_Click">
/// <summary>
/// 
/// </summary>
function ListBox_Click(strGuid,intIndex,objWindow,objEvent)
{
    // Get Listbox node
    var objListBoxNode=Data_GetNode(strGuid);

    // Exit on disabled control
    if(Data_IsDisabled(objListBoxNode)) return;
	
	// Get the selection mode	
	var intSelectionMode = parseInt(Data_GetAttribute(strGuid,"Attr.SelectionMode","3"));
	
    // Synchrinc selection of new index.
    // If click or doubleclick are critical - suspend the selected index change event.
	List_Click(strGuid, intIndex, intSelectionMode, true, true, objWindow, Web_IsShift(objEvent), Web_IsControl(objEvent), true, Xml_IsAttribute(objListBoxNode, "Attr.ForceSelectedIndexChanged", "1"));
	
    // If click and doubleclick are not critical and the selected index change event is critical - raise events.
    if (Data_IsCriticalEvent(objListBoxNode, "Event.SelectionChange", true))
    {
        // Handles the click event and forces raise (this 'overload' cancels the click bubble.
        Web_OnClick(objEvent,objWindow, true);
    }
}
/// </method>

/// <method name="ListBox_KeyDown">
/// <summary>
/// Handles The ListBox KeyDown
/// </summary>
function ListBox_KeyDown(strGuid,objWindow,objEvent)
{
    // Get Listbox node
    var objListBoxNode = Data_GetNode(strGuid);	    	 
    if(objListBoxNode)
    {
        // Exit on disabled control
        if(Data_IsDisabled(objListBoxNode)) return;
	
	    // Check that conotrol that selection mode is not "None".
        if(Data_IsNodeAttribute(objListBoxNode,"SM","2"))
	    {
            // Cancel defualt scrolling functionality.
            Web_EventCancelBubble(objEvent,true,false);

            return;
	    }
	
	    // Get the pressed key
	    var intKeyCode = Web_GetEventKeyCode(objEvent);
	
        //select only when navigations control or space key.
        if ([mcntUpKey,mcntDownKey,mcntPageUpKey,mcntPageDownKey,mcntEndKey,mcntHomeKey,mcntSpaceKey].contains(intKeyCode))  	
        {
            //If Space Key has been pressed
            if(intKeyCode == mcntSpaceKey)
            {         
                //Get the selected checkedbox node
                var objSelectedNode = Xml_SelectSingleNode("Tags.Option[@Attr.Selected='1']",objListBoxNode);
                    	        	  
                if(!objSelectedNode)
                { 
                        //Get the first child if no item is selected.
                        objSelectedNode = objListBoxNode.firstChild;     	                
                }
        	    
                if(objSelectedNode)
                {
                    //Get the desired checkedbox index
                    var  strIndex = parseInt(Xml_GetAttribute(objSelectedNode,"Idx","-1"));               	            	           	       
            	       	    
                    if(strIndex != -1)
                    {
                        //Get the CheckboxImage 
                        var objCheckboxImage = Web_GetElementById("CB_IMG_"+strGuid+"_"+strIndex,objWindow);
        	            
                        if(objCheckboxImage)
                        {   
                            //check/uncheck the box    	            
                            List_Checked(strGuid,strIndex,true,objCheckboxImage,objWindow,false);
                        }
                    }  
                }
            }
            
            // Get event source.
            var objEventSource = Web_GetEventSource(objEvent);            
            if(objEventSource)
            {
    	        //Get the list items
    	        var objItems = Data_GetChildNodes(objListBoxNode);
    	        
    	        // Check if the key down event is critical for the event source element or one of its ancestors.
    	        var blnIsKeyDownCritical = !Aux_IsNullOrEmpty(Data_GetFirstEnabledAncestorOrSelf(strGuid, "Event.KeyDown", true));

                // Get all selected nodes.
                var objSelectedItems = Xml_SelectNodes("Tags.Option[@Attr.Selected='1']",objListBoxNode);
                
                // Get the selection mode
                var intSelectionMode = parseInt(Xml_GetAttribute(objListBoxNode,"Attr.SelectionMode","3"),10);
                
                //true - blnUseIndexes(is it ListBox)
                // If key down is critical - suspend the selected index change event.
                List_KeyDown(strGuid,objItems,objSelectedItems,objListBoxNode,objWindow,objEvent,intSelectionMode,intKeyCode,"List",true,blnIsKeyDownCritical);
                
                // Check if key down is critical.
                if(blnIsKeyDownCritical) 
                {
                    // Handles the key down event for the registered element in the tree and stop the key down event propagation.
                    Web_OnKeyDown(objEvent,objWindow,true);
                }
                else
                {
                    // Cancel defualt scrolling functionality.
                    Web_EventCancelBubble(objEvent,true,false);
                }
            }
        } 
    }
}
/// </method>


/// <method name="ListBox_OnClickChecked">
/// <summary>
/// List box on item click check the item
/// </summary>  
function ListBox_OnClickChecked(strGuid,intIndex,blnCheck,objWindow,objEvent)
{
    // Get radio button node
	var objNode = Data_GetNode(strGuid);
	if (objNode)
	{
	    // Check that conotrol is not disabled and that selection mode is not "None".
	    if (!Data_IsDisabled(objNode) && !Data_IsNodeAttribute(objNode,"SM","2"))
	    {
	        // Get the selection type
            var blnIsSelectOnClick = Xml_IsAttribute(objNode, "Attr.CheckOnClick",1);
            var blnIsSelectd = false;
            var objSelectedNode = Xml_SelectSingleNode("Tags.Option[@Attr.Selected='1']",objNode);
	        if (objSelectedNode)
	        {
                blnIsSelectd = Xml_IsAttribute(objSelectedNode, "Idx",intIndex);
	        }

            var objCheckImage = Web_GetElementById("CB_IMG_"+strGuid+"_"+intIndex,objWindow);
	        if (objCheckImage)
	        {
	            //If this is selection on click        
       	        if ((!blnIsSelectOnClick && blnIsSelectd ) || (blnIsSelectOnClick) || blnCheck)
	            {
	                // set checked flag
		            var blnChecked = false;

	                // check current image state
		            if(objCheckImage.src.indexOf("1.gif")>-1)
	                {
	                    // turn check box off
			            objCheckImage.src = objCheckImage.src.replace("1.gif","0.gif");
	                }
	                else
	                {
	                    // turn check box on
			            blnChecked = true;
			            objCheckImage.src = objCheckImage.src.replace("0.gif","1.gif");
	                }


	                // loop variables
		            var objChildNodes	= Xml_GetEnumerable(objNode.childNodes);
		            var objChild		= null;
		            var intChild		= 0;

	                // checked indexes array
		            var arrChecked		= [];

	                // Loop all children
		            while(objChild = objChildNodes.nextNode())
	                {
	                    // if current index change
			            if(intChild==intIndex)
	                    {
	                        objChild.setAttribute("Attr.Checked",blnChecked?"1":"0");
	                    }

			            if(objChild.getAttribute("Attr.Checked")=="1")
	                    {
	                        arrChecked[arrChecked.length]=intChild;
	                    }
	                    intChild++;
	                }

	                // Create event and raise if critical
	                var objCheckedChangeEvent = Events_CreateEvent(strGuid, "CheckedChange", null, true); 
		            Events_SetEventAttribute(objCheckedChangeEvent, "Indexes", String(arrChecked));
		            
		            if (Data_IsCriticalEvent(objNode, "Event.ValueChange", true) && !Data_IsCriticalEvent(objNode, "Event.SelectionChange", true))
	                {
	                    Events_RaiseEvents();
	                }

	                Events_ProcessClientEvent(objCheckedChangeEvent);
	            }
	        }

	        // Exectue the click internal logic.
	        ListBox_Click(strGuid,intIndex,objWindow,objEvent);
	    }
	}
}
/// </method>



/// <method name="ListBox_SetFocus">
/// <summary>
/// Sets focus to a given element
/// </summary>
/// <param name="objElement">The element to set focus to.</param>
function ListBox_SetFocus(objFocusElement,strGuid)
{
    // Exit on disabled control
	if(Data_IsDisabled(strGuid)) return;
	
	if(objFocusElement)
	{
        Web_SetFocus(objFocusElement);	    
	}
}
/// </method>