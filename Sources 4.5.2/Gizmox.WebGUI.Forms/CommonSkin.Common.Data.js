/// <page name="Common.Data.js">
/// <summary>
/// This script handles all interface data.
/// </summary>

/// <summary>
/// Stores the UI data state
/// </summary> 
var mobjDataDomObject = null;

/// <summary>
/// Stores the UI data state root element
/// </summary>
var mobjDataRootObject = null;

/// <summary>
/// Tabulation parameters
/// </summary>
var mcntSelectableControlXpath = "not(@Attr.Enabled='0') and not(@Attr.Visible='0') ";



/// <method name="Data_GetDataId">
/// <summary>
/// Gets a data ID format "XXX".
/// </summary>
/// <param name="strId">Data node ID.</param>
function Data_GetDataId(strId)
{
	return String(strId).replace("VWG_", "").replace("TRG_", "").replace("WRP_", "");
}
/// </method>

/// <method name="Data_GetDataOwnerId">
/// <summary>
/// Gets a data owner id format "XXX".
/// </summary>
/// <param name="strId">Data node ID.</param>
function Data_GetDataOwnerId(strId)
{
	strId = Data_GetDataId(strId);
	if (strId.indexOf("_"))
	{
		return strId.split("_")[0];
	}
	else
	{
		return strId;
	}
}
/// </method>

/// <method name="Data_GetCalculatedNode">
/// <summary>
/// Gets a data node with a given attribute value.
/// </summary>
/// <param name="objNodeList">A node list.</param>
/// <param name="strSortFunction">A sorting function.</param>
/// <param name="strSortedAttribute">The sorted attribute.</param>
/// <param name="fncValidationFunction">A validation function.</param>
function Data_GetCalculatedNode(objNodeList, strSortFunction, strSortedAttribute, fncValidationFunction)
{
	var objPreferedNode = null;

	// Validate recieved pareameters.
	if (objNodeList && objNodeList.length > 0 &&
        strSortFunction && strSortFunction != "" &&
        strSortedAttribute && strSortedAttribute != "")
	{
		// Scan the list for the prefered node.
		for (var i = 0; i < objNodeList.length; i++)
		{
			// Execute validation function.
			if (fncValidationFunction)
			{
				if (!fncValidationFunction(Xml_GetAttribute(objNodeList[i], "Attr.Id", "")))
				{
					continue;
				}
			}

			// First initialization of the prefered node.
			if (!objPreferedNode)
			{
				// Set prefered node default value.
				objPreferedNode = objNodeList[i];
			}
			// Check for a prefered node.
			else
			{
				// Get current and prefered attributes values.
				var strCurrentAttributeValue = Xml_GetAttribute(objNodeList[i], strSortedAttribute, "");
				var strPreferedAttributeValue = Xml_GetAttribute(objPreferedNode, strSortedAttribute, "");

				if (strCurrentAttributeValue != "" && strPreferedAttributeValue != "")
				{
					// Compare indexes.
					if (eval("Math." + strSortFunction + "(" + strPreferedAttributeValue + "," + strCurrentAttributeValue + ")!=" + strPreferedAttributeValue))
					{
						objPreferedNode = objNodeList[i];
					}
				}
			}
		}
	}
	return objPreferedNode;
}
/// </method>

function Data_GetShortcutTarget(strShortcut, strFormId)
{
    strFormId = Data_GetDataId(Aux_IsNullOrEmpty(strFormId) ? mstrActiveWindowGuid : strFormId);
    var objForm = Data_GetNode(strFormId, mobjDataRootObject);
    if (objForm != null)
    {
        // Get the form node of requested shortcut
        var objNode = Xml_SelectSingleNode("descendant-or-self::*[WG:Tags.ShortcutsContainer/Tags.Item/@Attr.Shortcut='" + strShortcut + "']", objForm, mobjDataDomObject);
        if (objNode)
        {
            return Xml_GetAttribute(objNode, "Attr.Id");
        }
        else
        {
            var strMdiParentID = Data_GetNodeAttribute(objForm, "Attr.MdiParent", "");
            if (!Aux_IsNullOrEmpty(strMdiParentID))
            {
                return Data_GetShortcutTarget(strShortcut, strMdiParentID);
            }
        }
    }
    return null;
}

/// <method name="Data_GetNodeByAttribute">
/// <summary>
/// Gets a data node with a given attribute value.
/// </summary>
/// <param name="objNodeScope">Search node scope.</param>
/// <param name="strAttribute">The attribute name.</param>
/// <param name="strValue">The attribute value.</param>
function Data_GetNodeByAttribute(objNodeScope, strAttribute, strValue)
{
	//======================================================
	// Get node node by select nodes
	//======================================================
	var objScope = objNodeScope;
	var objNodes = Xml_SelectNodes(".//*[@" + strAttribute + "='" + strValue + "']", objScope);
	var objNode = objNodes[0];

	//======================================================
	// Return node
	//======================================================
	return objNode;
}
/// </method>


/// <method name="Data_GetNode">
/// <summary>
/// Gets data node by guid.
/// </summary>
/// <param name="strGuid">The data node ID.</param>
/// <param name="objNodeScope">Search node scope.</param>
function Data_GetNode(strGuid, objNodeScope)
{
	// Ensure string
	strGuid = String(strGuid);

	//======================================================
	// Check if is member guid
	//======================================================
	if (strGuid.indexOf("_") > -1)
	{
		// Split member id parts
		var arrGuid = strGuid.split("_");

		// Get owner node from guid first part
		var objOwnerNode = Data_GetNode(arrGuid[0]);

		// If owner is found
		if (objOwnerNode)
		{
			// Get member node from owner
		    return Data_GetNodeByMember(arrGuid[1], objOwnerNode);
		}
		else
		{
			return null;
		}
	}
	else
	{
		//======================================================
		// Get node node by select nodes
		//======================================================
		if (mobjDataDomObject)
		{
			var objScope = objNodeScope ? objNodeScope : mobjDataDomObject.documentElement;
			var objNodes = Xml_SelectNodes("./" + "/" + "*[@Id='" + strGuid + "']", objScope, mobjDataDomObject);
			var objNode = objNodes[0];

			//======================================================
			// Check Ambiguous
			//======================================================
			if (objNodes.length > 1) alert("Ambiguous controls id=" + strGuid);

			//======================================================
			// Return node
			//======================================================
			return objNode;
		}
		else
		{
			return null;
		}
	}
}
/// </method>

/// <method name="Data_GetNodeByMember">
/// <summary>
/// Get data node by member.
/// </summary>
/// <param name="strMemberId">The member ID.</param>
/// <param name="objNodeScope">Search node scope.</param>
function Data_GetNodeByMember(strMemberId, objNodeScope)
{
	if (mobjDataDomObject)
	{
        // Init xPath to search the member ID under the scope recursivly
	    var strXpath = ".//*[@Attr.MemberID='" + strMemberId + "'";

        // Get the scope node's Id
	    var strControlId = Data_GetNodeAttribute(objNodeScope, "Attr.Id", "");

	    if (!Aux_IsNullOrEmpty(strControlId))
	    {
            // Add a search condition to find all nodes that their direct parent is the scope node
	        strXpath += " and (ancestor::WC:*[1]/@Attr.Id='" + strControlId + "' or ancestor::WG:*[1]/@Attr.Id='" + strControlId + "')";
	    }

	    strXpath += "]";

		//======================================================
		// Get node node by select nodes
		//======================================================
		var objScope = objNodeScope ? objNodeScope : mobjDataDomObject.documentElement;
		var objNodes = Xml_SelectNodes(strXpath, objScope, mobjDataDomObject);
		var objNode = objNodes[0];

		//======================================================
		// Return node
		//======================================================
		return objNode;
	}
	else
	{
		return null;
	}
}
/// </method>

/// <method name="Data_GetChildNodes">
/// <summary>
/// Gets data node child nodes(optional attribute filtering).
/// </summary>
/// <param name="objNode">The node to get its children</param>
/// <param name="strAttribute">The attribute name to filter by</param>
/// <param name="strValue">The attribute value to filter by</param>
function Data_GetChildNodes(objNode, strAttribute, strValue)
{
	if (strAttribute)
	{
		return objNode.selectNodes("*[" + strAttribute + "='" + strValue + "']");
	}
	else
	{
		return objNode.childNodes;
	}
}
/// </method>

/// <method name="Data_DeleteNode">
/// <summary>
/// Removes the data node.
/// </summary>
/// <param name="strGuid">The ID of the node to be removed.</param>
/// <param name="objNodeScope">Search node scope.</param>
function Data_DeleteNode(strGuid, objNodeScope)
{
	var objNode = Data_GetNode(strGuid, objNodeScope);
	if (objNode) if (objNode.parentNode) objNode.parentNode.removeChild(objNode);
}
/// </method>

/// <method name="Data_SetNode">
/// <summary>
/// Replaces a data node.
/// </summary>
/// <param name="strGuid">The ID of a node to be replaced.</param>
/// <param name="objNewNode">The new node.</param>
function Data_SetNode(strGuid, objNewNode)
{
	var objOldNode = Data_GetNode(strGuid);
	if (objOldNode)
	{
        var objParentNode = objOldNode.parentNode;
        if(objParentNode)
        {
			objParentNode.replaceChild(objNewNode, objOldNode);
        }

	    return objNewNode;
	}

    return null;
}
/// </method>

/// <method name="Data_SetAttribute">
/// <summary>
/// Sets a data node attribute.
/// </summary>
/// <param name="strGuid">The ID of the data node.</param>
/// <param name="strName">The data node attribute name.</param>
/// <param name="strValue">The data node attribute value.</param>
function Data_SetAttribute(strGuid, strName, strValue)
{
	//======================================================
	// Get Node
	//======================================================
    var objNode = strGuid != "/" ? Data_GetNode(strGuid) : mobjDataRootObject;

	//======================================================
	// Set the node attribute
	//======================================================
	Data_SetNodeAttribute(objNode, strName, strValue);
}
/// </method>

/// <method name="Data_SetNodeAttribute">
/// <summary>
/// Sets a data node attribute.
/// </summary>
/// <param name="objNode">The handled data node.</param>
/// <param name="strName">The data node attribute name.</param>
/// <param name="strValue">The data node attribute value.</param>
function Data_SetNodeAttribute(objNode, strName, strValue)
{
	//======================================================
	// Set the node attribute
	//======================================================
	if (objNode) objNode.setAttribute(String(strName), String(strValue));
}
/// </method>

/// <method name="Data_GetAttribute">
/// <summary>
/// Gets a data node attribute value.
/// </summary>
/// <param name="strGuid">The ID of the data node.</param>
/// <param name="strName">The data node attribute name.</param>
/// <param name="strDefault">The default value to be returned if attribute value is null or does not exist.</param>
function Data_GetAttribute(strGuid, strName, strDefault)
{
	//======================================================
	// Get Node
	//======================================================
	var objNode = strGuid != "/" ? Data_GetNode(strGuid) : mobjDataRootObject;

	//======================================================
	// Get the node attribute
	//======================================================
	return Data_GetNodeAttribute(objNode, strName, strDefault);
}
/// </method>

/// <method name="Data_GetNodeAttribute">
/// <summary>
/// Gets a data node attribute value.
/// </summary>
/// <param name="objNode">The data node.</param>
/// <param name="strName">The data node attribute name.</param>
/// <param name="strDefault">The default value to be returned if attribute value is null or does not exist.</param>
function Data_GetNodeAttribute(objNode, strName, strDefault)
{
	//======================================================
	// Get the node attribute
	//======================================================
	if (objNode) return objNode.getAttribute(String(strName));
	else return strDefault ? strDefault : "";
}
/// </method>

/// <method name="Data_IsAttribute">
/// <summary>
/// 
/// </summary>
/// <param name="strGuid">The ID of the data node.</param>
/// <param name="strAttributeName">The data node attribute name.</param>
/// <param name="strAttributeValue"></param>
function Data_IsAttribute(strGuid, strAttributeName, strAttributeValue)
{
	// Get Node
	var objNode = strGuid != "/" ? Data_GetNode(strGuid) : mobjDataRootObject;

	return Data_IsNodeAttribute(objNode, strAttributeName, strAttributeValue);
}
/// </method>

/// <method name="Data_IsAttribute">
/// <summary>
/// 
/// </summary>
/// <param name="objNode">The data node.</param>
/// <param name="strAttributeName">The data node attribute name.</param>
/// <param name="strAttributeValue"></param>
function Data_IsNodeAttribute(objNode, strAttributeName, strAttributeValue)
{
	// Check node's attribute
	if (objNode)
	{
		return (objNode.getAttribute(String(strAttributeName)) == strAttributeValue);
	}

	return false;
}
/// </method>

/// <method name="Data_RemoveAttribute">
/// <summary>
/// Remove attribute from data node.
/// </summary>
/// <param name="strGuid">The ID of the data node.</param>
/// <param name="strName">The data node attribute name.</param>
function Data_RemoveNodeAttribute(objNode, strName)
{
	// remove attribute from node
	if (objNode)
	{
		objNode.removeAttribute(String(strName));
	}
}
/// </method>


/// <method name="Data_IsCriticalEvent">
/// <summary>
/// Checks if a given event is critical.
/// </summary>
/// <param name="objSource">The event source id or node.</param>
/// <param name="objEventId">The event ID to be checked. (Might be string or list of strings</param>
/// <param name="blnIsNode">The event source is a node.</param>
function Data_IsCriticalEvent(objSource, objEventId, blnIsNode)
{
    return Data_IsCriticalEventAttribute(objSource, objEventId, blnIsNode, mblnIsOfflineMode ? "Attr.ClientEvents" : "Attr.Events");
}
/// </method>


/// <method name="Data_IsCriticalEventAttribute">
/// <summary>
/// Checks if a given event is critical.
/// </summary>
/// <param name="objSource">The event source id or node.</param>
/// <param name="objEventId">The event ID to be checked.</param>
/// <param name="blnIsNode">The event source is a node.</param>
/// <param name="strEventAttributeName">The event attribute name.</param>
function Data_IsCriticalEventAttribute(objSource, objEventId, blnIsNode, strEventAttributeName)
{
    // Get the guid of the data node
    var strGuid = blnIsNode ? Xml_GetAttribute(objSource, "Id") : objSource;

    // Get the current event ID
    if (objEventId)
    {
        // Get current event register
        var strEvents = blnIsNode ? Xml_GetAttribute(objSource, strEventAttributeName) : Data_GetAttribute(strGuid, strEventAttributeName, "");
        // If event is not registered on current node, and working client, check parent node that can propogate client events.
        if ((strEvents == undefined || strEvents === "") && mblnIsOfflineMode) {
            var objNode = Data_GetNode(strGuid);

            // Get parent node containing current node type in its event propogation tags list.
            var objParentEventHandlerNode = Client_GetClientEventPropogationParent(objNode);

            if (objParentEventHandlerNode) {
                strEvents = Xml_GetAttribute(objParentEventHandlerNode, strEventAttributeName);
            }
        }

        if (strEvents)
        {
            var blnIsCritical = false;

            // The objEventId might be string or array of strings.
            var strEventArray = strEvents.split(",");
            if (typeof (objEventId) == "string")
            {
                blnIsCritical = strEventArray.contains(objEventId);
            }
            else 
            {
                // Here the event id is array of string, so we will check if one of the events in the array is critical.
                for (var i = 0; i < objEventId.length; i++)
                {
                    var strEventId = objEventId[i];
                    if (strEventArray.contains(strEventId)) {
                        blnIsCritical = true;
                        break;
                    }
                }
            }

            return blnIsCritical;
        }        
    }

    return false;
}

/// </method>



/// <method name="Data_ClearIsDelayedDrawingFromChildren">
/// <summary>
/// Clears the is delayed drawing attrbitue from child nodes
/// </summary>
/// <param name="objNode">The node to clear its children's is delayed drawing.</param>
function Data_ClearIsDelayedDrawingFromChildren(objNode)
{
	// Clear delayed controls
	var objDelayedControls = Xml_SelectNodes("descendant::WC:*[@Attr.IsDelayedDrawing='1']", objNode, objNode.ownerDocument);

	for (var intIndex = 0; intIndex < objDelayedControls.length; intIndex++)
	{
		Data_ClearIsDelayedDrawing(objDelayedControls[intIndex]);
	}
}
/// </method>

/// <method name="Data_ClearIsDelayedDrawing">
/// <summary>
/// Clears the is delayed drawing attrbitue
/// </summary>
/// <param name="objNode">The node to clear its is delayed drawing.</param>
function Data_ClearIsDelayedDrawing(objNode)
{
	Xml_SetAttribute(objNode, "Attr.IsDelayedDrawing", "0");
}
/// </method>

/// <method name="Data_GetParam">
/// <summary>
/// Gets a document param.
/// </summary>
/// <param name="strParamName">Parameter name.</param>
function Data_GetParam(strParamName)
{
	return mobjDataRootObject.getAttribute(strParamName);
}
/// </method>

/// <method name="Data_GetParentControl">
/// <summary>
/// Gets the parent control.
/// </summary>
/// <param name="objContext">The current context node.</param>
function Data_GetParentControl(objContext)
{
	var objCurrent = objContext;

	while (objCurrent && objCurrent.nodeName.indexOf("WC:") != 0)
	{
		objCurrent = objCurrent.parentNode;
	}

	return objCurrent;
}
/// </method>

/// <method name="Data_GetParentControlByDataId">
/// <summary>
/// Gets the parent control by data id.
/// </summary>
/// <param name="strDataId">Node's data id.</param>
function Data_GetParentControlByDataId(strDataId)
{
	// Validate data id.
	if (!Aux_IsNullOrEmpty(strDataId))
	{
		var objNode = Data_GetNode(strDataId);
		if (objNode)
		{
			return Data_GetParentControl(objNode);
		}
	}

	return null;
}
/// </method>

/// <method name="Data_IsKeyFilterEnabled">
/// <summary>
/// Returns true if key event should be fired.
/// </summary>
/// <param name="intKeyCode">The ASCII keycode.</param>
function Data_IsKeyFilterEnabled(strDataId, intKeyCode, objEvent)
{
	// Validate data id.
	if (!Aux_IsNullOrEmpty(strDataId))
	{
		// Get node as for data id.
		var objNode = Data_GetNode(strDataId);
		if (objNode)
		{
			// Get the key filter attribute.
			var intKeyFilter = parseInt(Xml_GetAttribute(objNode, "Attr.KeyFilter", "0"));

			// Check if had no key filter defined.
			if (intKeyFilter == 0)
			{
				return true;
			}

			// Check keyfilter for control/alt/shift and return true if pressed together with another key
			else if ((intKeyFilter & mcntKeyFilterControl && objEvent.ctrlKey) ||
                     (intKeyFilter & mcntKeyFilterAlt && objEvent.altKey) ||
                     (intKeyFilter & mcntKeyFilterShift && objEvent.shiftKey))
			{
				return true;
			}
			else
			{
				// Get appropriate binary number for bitmask test based on ASCII keycode.
				switch (intKeyCode)
				{
					// Delete      
					case 46:
						intKeyFilterCode = mcntKeyFilterDelete;
						break;
					// Down        
					case 40:
						intKeyFilterCode = mcntKeyFilterDown;
						break;
					// End         
					case 35:
						intKeyFilterCode = mcntKeyFilterEnd;
						break;
					// Escape      
					case 27:
						intKeyFilterCode = mcntKeyFilterEscape;
						break;
					// F1          
					case 112:
						intKeyFilterCode = mcntKeyFilterF1;
						break;
					// F2          
					case 113:
						intKeyFilterCode = mcntKeyFilterF2;
						break;
					// F3          
					case 114:
						intKeyFilterCode = mcntKeyFilterF3;
						break;
					// F4          
					case 114:
						intKeyFilterCode = mcntKeyFilterF4;
						break;
					// F5          
					case 115:
						intKeyFilterCode = mcntKeyFilterF5;
						break;
					// F6         
					case 116:
						intKeyFilterCode = mcntKeyFilterF6;
						break;
					// F7          
					case 118:
						intKeyFilterCode = mcntKeyFilterF7;
						break;
					// F8          
					case 119:
						intKeyFilterCode = mcntKeyFilterF8;
						break;
					// F9          
					case 120:
						intKeyFilterCode = mcntKeyFilterF9;
						break;
					// F10         
					case 121:
						intKeyFilterCode = mcntKeyFilterF10;
						break;
					// F11         
					case 122:
						intKeyFilterCode = mcntKeyFilterF11;
						break;
					// F12         
					case 123:
						intKeyFilterCode = mcntKeyFilterF12;
						break;
					// Home        
					case 36:
						intKeyFilterCode = mcntKeyFilterHome;
						break;
					// Insert      
					case 45:
						intKeyFilterCode = mcntKeyFilterInsert;
						break;
					// Left        
					case 37:
						intKeyFilterCode = mcntKeyFilterLeft;
						break;
					// PageDown    
					case 34:
						intKeyFilterCode = mcntKeyFilterPageDown;
						break;
					// PageUp      
					case 33:
						intKeyFilterCode = mcntKeyFilterPageUp;
						break;
					// Right       
					case 39:
						intKeyFilterCode = mcntKeyFilterRight;
						break;
					// Up                      
					case 38:
						intKeyFilterCode = mcntKeyFilterUp;
						break;
					// Enter 
					case 13:
						intKeyFilterCode = mcntKeyFilterEnter;
						break;
					// Default 
					default:
						intKeyFilterCode = mcntKeyFilterAll;
						break;
				}

				// Perform a bit mask comparison.
				return (intKeyFilter & intKeyFilterCode) > 0;
			}
		}
	}
}
/// </method>

/// <method name="Data_IsDisabled">
/// <summary>
/// Gets a flag indicating if a component is disabled.
/// </summary>
/// <param name="objValue">The component guid or node.</param>
function Data_IsDisabled(objValue)
{
	// Get data node
	var objNode = null;

	if ((typeof (objValue) == "string") || (typeof (objValue) == "number"))
	{
		// Validate recieved guid.
		if (!Aux_IsNullOrEmpty(objValue))
		{
			// Get xml node.
			objNode = Data_GetNode(Data_GetDataId(String(objValue)));
		}
	}
	else
	{
		objNode = objValue;
	}

	if (objNode)
	{
	    // Checking the current node is a WG:FORM, if so, returning it's Enabled attibute
	    if (objNode.tagName == "WG:Tags.Form")
	    {
	        return (Xml_GetAttribute(objNode, "Attr.Enabled", "1") != "1");
	    }

	    if (Xml_GetAttribute(objNode, "Attr.Enabled", "1") == "1")
	    {
	        // Gets the first disabled node
	        var objNotEnabledNode = Xml_SelectSingleNode("ancestor-or-self::*[@Attr.Enabled='0'][1]", objNode);

	        if (objNotEnabledNode)
	        {
	            // Gets the disabled node first form container
	            var objNotEnabledNodeForm = Xml_SelectSingleNode("ancestor-or-self::WG:Tags.Form[1]", objNotEnabledNode);

	            // Get the current node first form container
	            var objNodeForm = Xml_SelectSingleNode("ancestor::WG:Tags.Form[1]", objNode);

	            // Compering 2 forms IDs
	            if (Xml_GetAttribute(objNodeForm, "Attr.Id") == Xml_GetAttribute(objNotEnabledNodeForm, "Attr.Id"))
	            {
	                return true;
	            }
	        }
	    }
	    else
	    {
	        return true;
	    }
	}

	return false;
}
/// </method>

/// <method name="Data_GetRegisteredParent">
/// <summary>
/// 
/// </summary>
function Data_GetRegisteredParent(strGuid, intEventID, blnCrossForms)
{
	// Define a registered parent object.
	var objRegisteredParent = null;

	// Validate recieved arguments.
	if (!Aux_IsNullOrEmpty(strGuid) && !Aux_IsNullOrEmpty(intEventID))
	{
		// Get control node by guid. 
		objRegisteredParent = Data_GetNode(strGuid);
		if (objRegisteredParent)
		{
			// Get control's parent node.
			objRegisteredParent = objRegisteredParent.parentNode;

			// Loop while parent is not registered to the recieved event.
			while (objRegisteredParent && !Data_IsCriticalEvent(objRegisteredParent, intEventID, true))
			{
				// Check if current parent is a form.
				if (blnCrossForms || objRegisteredParent.tagName != "WG:Tags.Form")
				{
					// Get control's parent node.
					objRegisteredParent = objRegisteredParent.parentNode;
				}
				else
				{
					// Cause a loop break.
					objRegisteredParent = null;
				}
			}
		}
	}

	// Return the registered parent object.
	return objRegisteredParent;
}
/// </method>

/// <method name="Data_GetFormNodeByDataId">
/// <summary>
/// 
/// </summary>
function Data_GetFormNodeByDataId(strGuid, blnEexcludSelf)
{
	// Validate recieved arguments.
	if (!Aux_IsNullOrEmpty(strGuid))
	{
		// Get the current data node
		var objNode = Data_GetNode(strGuid);
		if (objNode)
		{
			// Get the containing form node
			return Xml_GetNamedAncestor(objNode, "WG:Tags.Form", blnEexcludSelf);
		}
	}

	return null;
}
/// </method>

/// <method name="Data_GetTabKeyTargetNode">
/// <summary>
/// Gets the target node of a tab operation
/// </summary>
/// <param name="objSourceNode"></param>
/// <param name="blnBackwards"></param>
/// <param name="intKeyCode"></param>
function Data_GetTabKeyTargetNode(objSourceNode,blnBackwards, intKeyCode)
{ 
    // Decalre a target node.
    var objTargetNode = null;
    
    // Get target node  
    if(objSourceNode && objSourceNode.tagName=="WG:Tags.Form")
    {   
        // In case of a form - target node sholud be the form it self.
        objTargetNode = objSourceNode;
    }
    else
    {
        // In case of other controls - get next control.
        objTargetNode = Data_GetTabKeyNextTargetNode(objSourceNode, blnBackwards, intKeyCode);
    }
    
    if(objTargetNode)
    {
        // If is a container and not a focus control get a focusable control with in
        objTargetNode = Data_GetTabKeyContentTargetNodeOfSelf(objTargetNode,blnBackwards);
    }
    
    // If target was not found
    if(!objTargetNode)
    {
        // Get parent node
        var objParentNode = objSourceNode.parentNode;
        
        // If parent is not form
        if(objParentNode.tagName!="WG:Tags.Form")
        {
            // Get the next target node with in the parent parent
            objTargetNode = Data_GetTabKeyTargetNode(objParentNode, blnBackwards, intKeyCode);
        }
        else
        {
            // Get the first tab index control in the form
            objTargetNode = Data_GetTabKeyFirstTargetNode(objParentNode,blnBackwards);
        }
        
        if(objTargetNode)
        {
            // If is a container and not a focus control get a focusable control with in
            objTargetNode = Data_GetTabKeyContentTargetNodeOfSelf(objTargetNode,blnBackwards);
        }
    }
    
    return objTargetNode;
}
/// </method>

/// <method name="Data_GetTabKeyContentTargetNodeOfSelf">
/// <summary>
/// Get a contained focus node or return target if no contained focus node
/// </summary>
/// <param name="objTargetNode"></param>
/// <param name="blnBackwards"></param>
function Data_GetTabKeyContentTargetNodeOfSelf(objTargetNode,blnBackwards)
{ 
    // Try to get first node from the taget node
    var objTargetContentNode = Data_GetTabKeyFirstTargetNode(objTargetNode,blnBackwards);
    if(objTargetContentNode!=null)
    {
        // Try to get contained node in contained node
        return Data_GetTabKeyContentTargetNodeOfSelf(objTargetContentNode,blnBackwards);
    }
    else
    {
        // Return original target node
        return objTargetNode;
    }
}
/// </method>

/// <method name="Data_GetTabKeyFirstTargetNode">
/// <summary>
/// Get the first tab indexed control (last if backwards is true)
/// </summary>
/// <param name="objParentNode"></param>
/// <param name="blnBackwards"></param>
function Data_GetTabKeyFirstTargetNode(objParentNode, blnBackwards)
{
	// Get the first or last (according to the direction)tab index control in the parent node.
	return Data_GetNearestTabIndexTargetNode(Xml_SelectNodes("WC:*[" + mcntSelectableControlXpath + " and @Attr.TabIndex]", objParentNode), blnBackwards);

}
/// </method>

/// <method name="Data_GetNodeDebugInfo">
/// <summary>
/// Gets node information for debugging
/// </summary>
/// <param name="objSourceNode"></param>
function Data_GetNodeDebugInfo(objNode)
{
	if (objNode)
	{
		return "[Node:" + Xml_GetAttribute(objNode, "Attr.Id") + ", Type:" + objNode.nodeName + ", Text:" + Xml_GetAttribute(objNode, "Attr.Text") + "]";
	}

	// Return empty info string
	return "[Empty]";
}
/// </method>

/// <method name="Data_GetNearestTabIndexTargetNode">
/// <summary>
/// </summary>
function Data_GetNearestTabIndexTargetNode(arrTargetNodes, blnBackwards)
{
	// Define a nearest tab index target node.
	var objNearestTabIndexTargetNode = null;

	// Validate recieved nodes.
	if (arrTargetNodes)
	{
		// Define a nearest tab index variable.
		var intNearestTabIndex = null;

		// Loop all nodes.
		for (var i = 0; i < arrTargetNodes.length; i++)
		{
			// Get a current node.
			var objCurrentNode = arrTargetNodes[i];
			if (objCurrentNode)
			{
				// Get current node's tab index.
				var intCurrentTabIndex = Number(Xml_GetAttribute(objCurrentNode, "Attr.TabIndex", ""));
				if (!isNaN(intCurrentTabIndex))
				{
					// In case that nearest tab index is still null.
					if (Aux_IsNullOrEmpty(intNearestTabIndex))
					{
						// Preserve nearest tab index and node.
						intNearestTabIndex = intCurrentTabIndex;
						objNearestTabIndexTargetNode = objCurrentNode;
					}
					else
					{
						// In case that maximal tab index is requested.
						if (blnBackwards)
						{
							// Check if current node's tab index is greater then the nearest tab index found so far.
							if (intCurrentTabIndex > intNearestTabIndex)
							{
								// Preserve nearest tab index and node.
								intNearestTabIndex = intCurrentTabIndex;
								objNearestTabIndexTargetNode = objCurrentNode;
							}
						}
						// In case that minimal tab index is requested.
						else
						{
							// Check if current node's tab index is smaller then the nearest tab index found so far.
							if (intCurrentTabIndex < intNearestTabIndex)
							{
								// Preserve nearest tab index and node.
								intNearestTabIndex = intCurrentTabIndex;
								objNearestTabIndexTargetNode = objCurrentNode;
							}

						}
					}
				}
			}
		}
	}

	// Return the nearest tab index target node.
	return objNearestTabIndexTargetNode;
}
/// </method>

/// <method name="Data_GetTabKeyNextTargetNode">
/// <summary>
/// Gets the next sibling tab index target using the source node
/// </summary>
/// <param name="objSourceNode"></param>
/// <param name="blnBackwards"></param>
function Data_GetTabKeyNextTargetNode(objSourceNode, blnBackwards, intKeyCode)
{
    // Decalre a target node.
    var objTargetNode = null;

    // If valid source node
    if (objSourceNode)
    {
        // Set the xpath default opreator so it will search for the next tab index.
        var strXpathOperator = ">";
        var strXpathNegativeOperator = "<";
        var strXpathSelector = "../WC:*";
        var strXpathEqualSelector = "following-sibling::WC:*";

        // If shift key is pressed - search for the maximal previous tab index.
        if (blnBackwards)
        {
            strXpathOperator = "<";
            strXpathNegativeOperator = ">";
            strXpathEqualSelector = "preceding-sibling::WC:*";
        }

        // Get soure element tab for group indication. 
        var strSourceEnableGroupTabbing = Xml_GetAttribute(objSourceNode, "Attr.EnableGroupTabbing", "");

        //Define additonal xpath query to support avoid tabbing between controls in the same group
        var strAdditonalFilter = "";

        //If current control is set to single Tabbing for group, filter out other controls of the same type, under the same container
        if ((strSourceEnableGroupTabbing) && (intKeyCode == mcntTabKey))
        {

            strAdditonalFilter = " and not(name()='" + objSourceNode.nodeName + "') ";
        }

        // Get soure element tab index. 
        var strSourceTabIndex = Xml_GetAttribute(objSourceNode, "Attr.TabIndex", "-1");

        // Try to get target node with the same tab index
        objTargetNode = Xml_SelectSingleNode(strXpathEqualSelector + "[@Attr.TabIndex=" + strSourceTabIndex + strAdditonalFilter + " and " + mcntSelectableControlXpath + "][1]", objSourceNode);

        // If same tab index target was not found
        if (!objTargetNode)
        {
            // Define an xpath which will query all valid controls which has tab index greater or smaller (according to the direction) then 
            // the source's tab index.
            var strXpathNextTarget = strXpathSelector + "[@Attr.TabIndex" + strXpathOperator + strSourceTabIndex + strAdditonalFilter + " and " + mcntSelectableControlXpath + "]";

            // Execute XPath and get the nearest tab index node (according to the direction).
            objTargetNode = Data_GetNearestTabIndexTargetNode(Xml_SelectNodes(strXpathNextTarget, objSourceNode), blnBackwards);
        }
        
    }

    return objTargetNode;
}
/// </method>





/// <method name="Data_GetFirstEnabledAncestorOrSelf" access="private">
/// <summary>
/// Search node metadata for the first registered VWG component anchestor of node (including self if blnIncludeSelf),
/// stopping on any disabled intermediate nodes and before a form node is reached during the search upwards the metadata node tree.
/// </summary>
///
/// <param name="strDataId">Data Id of the node where search starts</param>
/// <param name="cntEventId">Event signature of the event (Event.Click)</param>
/// <param name="blnIncludeSelf">True if the given node should be checked as well, False if search starts with node's parent</param>
/// <param name="blnIsClientEvent">True if checking ClientEvent registration, False if checking for regular event registration</param>
///
/// <returns>
/// Empty string if none found, else a VWG Data Id that has the event registered and it can be raised against
/// </returns>
function Data_GetFirstEnabledAncestorOrSelf(strDataId, cntEventId, blnIncludeSelf, blnIsClientEvent)
{
    var strRegisteredComponentDataId = "";
    var blnIsDisabled = false;

    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strDataId) && !Aux_IsNullOrEmpty(cntEventId))
    {
        // Get element's meta data node.
        var objNode = Data_GetNode(strDataId);
        if (objNode)
        {
            if (!blnIncludeSelf)
            {
                objNode = objNode.parentNode;
            }

            while (objNode) {
                blnIsDisabled = Data_IsDisabled(objNode);
                strRegisteredComponentDataId = Xml_GetAttribute(objNode, "Attr.Id", "");

                // If we hit a disabled node, we stop searching and return false
                if (blnIsDisabled) {
                    objNode = null;
                    strRegisteredComponentDataId = "";
                    break;
                }

                // We always stop search on Form tag, which is the top of where we will go
                if (objNode.tagName === "WG:Tags.Form") {
                    objNode = null;
                    strRegisteredComponentDataId = "";
                    break;
                }

                // Stop anchestor search at first registered component
                if (strRegisteredComponentDataId != "") {
                    break;
                }

                objNode = objNode.parentNode;
            }

            // Check if the Control has a critical event
            if (objNode && 
                Layout_IsNode(objNode) &&
                !Xml_IsAttribute(objNode, "Attr.Visible", "0") &&
                (blnIsClientEvent ? Data_IsCriticalEventAttribute(objNode, cntEventId, true, "Attr.ClientEvents") : Data_IsCriticalEvent(objNode, cntEventId, true))
                )
            {
                return strRegisteredComponentDataId;
            }
        }
    }

    return "";
}
/// </method>

/// <method name="Data_SetTextSelectionData">
/// <summary>
///
/// </summary>
/// <param name="strGuid">TextBox guid.</param>
/// <param name="intStart">The input control value</param>
/// <param name="intLength">The text box window</param>
function Data_SetTextSelectionData(strGuid, intStart, intLength)
{
	var objNode = Data_GetNode(strGuid);
	Data_SetNodeAttribute(objNode, "Attr.SelectionStart", intStart);
	Data_SetNodeAttribute(objNode, "Attr.SelectionLength", intLength);
}
/// </method>


/// <method name="Data_GetTheme">
/// <summary>
///
/// </summary>
/// <param name="strGuid">TextBox guid.</param>
function Data_GetTheme(strGuid)
{
    var strTheme = null;

    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        strTheme = Xml_GetAttribute(objNode, "Attr.Theme", "");
        if(Aux_IsNullOrEmpty(strTheme))
        {
            var objParentNode = Xml_SelectSingleNode("./ancestor::*[@Attr.Theme and not(@Attr.Theme='')][1]", objNode);
            if(objParentNode)
            {
                strTheme = Xml_GetAttribute(objParentNode, "Attr.Theme", "");
            }
        }
    }

    return strTheme;
}
/// </method>