var mblnIsOfflineMode = false;
var VWGEventArgs;

/// <method name="Client_Preload">
/// <summary>
/// Preload client.
/// </summary>
function Client_Preload(objOwnerForm)
{
    // Validate recieved arguments.	
    if (objOwnerForm)
    {
        // Register ajaxError event at document level.
        $(document).ajaxError(function (objEvent, objXHR, objSettings, objThrownError) 
        {
            if (!objSettings.vwgEvent)
            {
                // Validate offline mode.
                if (!Client_IsInOfflineMode() && Client_OfflineConfirming(objXHR))
                {
                    // Set preserve offline mode.
                    Client_SetOfflineMode(true);
                }
            }
        });

        // Execute the client preload event node.
        Client_ExecuteEvent(Xml_SelectSingleNode("Tags.ClientEvents/Tags.ClientEvent[@Attr.Name='ClientPreload']", objOwnerForm));
       
	}
}
/// </method>

/// <method name="Client_OfflineInitializing">
/// <summary>
/// 
/// </summary>
function Client_OfflineInitializing()
{
    // Validate main form id.
    if (!Aux_IsNullOrEmpty(mstrActiveWindowGuid))
    {
        var objMainFormNode = Data_GetNode(Data_GetDataId(mstrActiveWindowGuid));
        if (objMainFormNode)
        {
            // Execute the client initiailze event node.
            Client_ExecuteEvent(Xml_SelectSingleNode("Tags.ClientEvents/Tags.ClientEvent[@Attr.Name='OfflineInitializing']", objMainFormNode));
        }
    }
}
/// </method>

/// <method name="Client_OfflineConfirming">
/// <summary>
/// 
/// </summary>
function Client_OfflineConfirming(objXmlHTTP)
{
    // Validate main form id.
    if (!Aux_IsNullOrEmpty(mstrActiveWindowGuid))
    {
        var objMainFormNode = Data_GetNode(Data_GetDataId(mstrActiveWindowGuid));
        if (objMainFormNode)
        {
            // Gets the client confirming event node.
            var objOfflineConfirmingEvent = Xml_SelectSingleNode("Tags.ClientEvents/Tags.ClientEvent[@Attr.Name='OfflineConfirming']", objMainFormNode);
            if (objOfflineConfirmingEvent)
            {
                // Create an arguments object.
                var objArgs =
                {
                    offlineConfirm: false,
                    xmlHttp: objXmlHTTP
                };

                // Execute the client confirming event node.
                Client_ExecuteEvent(objOfflineConfirmingEvent, objArgs);

                // Return offline confirmation value.
                return objArgs.offlineConfirm;
            }
        }
    }

    return false;
}
/// </method>

/// <method name="Client_SetOfflineMode">
/// <summary>
/// 
/// </summary>
function Client_SetOfflineMode(blnOfflineMode)
{
    // Check that moe has changed.
    if(mblnIsOfflineMode != blnOfflineMode)
    {
        // Preseve mode.
        mblnIsOfflineMode = blnOfflineMode;

        // In case of offline mode.
        if(blnOfflineMode)
        {
            // Initialize offline mode.
            Client_OfflineInitializing();
        }
    }

    Debug_Log("Offline mode: " + mblnIsOfflineMode);
}
/// </method>

/// <method name="Client_IsInOfflineMode">
/// <summary>
/// 
/// </summary>
function Client_IsInOfflineMode()
{
    return mblnIsOfflineMode;
}
/// </method>

/// <method name="Client_ProcessEvents">
/// <summary>
/// Process the event queue
/// </summary>
/// <param name="objEventsNode">The events buffer to process.</param>
/// <param name="strEventAvailability">The event availability.</param>
function Client_ProcessEvents(objEventsNode,strEventAvailability,blnRemoveHandled)
{
    // Get the events list
    var objEvents = Xml_SelectNodes("Tags.Event", objEventsNode);
    if(objEvents)
    {
        // Loop all events
        for(var intIndex = 0; intIndex < objEvents.length; intIndex++)
        {
            // Get current event node.
            var objEventNode = objEvents[intIndex];
            if(objEventNode)
            {
                // If event was handled and should be removed.
                if(Client_ProcessEvent(objEventNode,strEventAvailability) && blnRemoveHandled)
                {
                    // Remove event node.
                    Xml_RemoveChild(objEventsNode,objEventNode);
                }
            }
        }
    }
}
/// </method>

/// <method name="Client_ProcessEvent">
/// <summary>
/// Process the event
/// </summary>
/// <param name="objEvent">The event to process.</param>
/// <param name="strEventAvailability">The event availability.</param>
function Client_ProcessEvent(objEvent,strEventAvailability)
{
    // Get the data id
    var strDataId = Xml_GetAttribute(objEvent, "Attr.Source");

    // If there is a valid data Id
    if(!Aux_IsNullOrEmpty(strDataId))
    {
        // Get the data node
        var objDataNode = Data_GetNode(strDataId);

        // IF there is a valid data node
        if(objDataNode)
        {
            // Get event type
            var strEventType = Xml_GetAttribute(objEvent, "Attr.Type");

            // If there is a valid event type
            if(!Aux_IsNullOrEmpty(strEventType))
            {
                // Try find a proper client event.
                var objEventNode = Xml_SelectSingleNode("Tags.ClientEvents/Tags.ClientEvent[@Attr.Name='" + strEventType + "' and @Attr.EventAvailability='"+strEventAvailability+"']", objDataNode);
                if (objEventNode) {
                	// Execute the client event node.
                	Client_ExecuteEvent(objEventNode, objEvent);

                	// Return that event was handled.
                	return true;
                }

                // If event not found on source node, try to get it from parent control.
                else {
                	
                	// Get parent node containing current node type in its event propogation tags list.
                	var objParentEventHandlerNode = Client_GetClientEventPropogationParent(objDataNode);
                	
					if (objParentEventHandlerNode) {

                		objEventNode = Xml_SelectSingleNode("Tags.ClientEvents/Tags.ClientEvent[@Attr.Name='" + strEventType + "' and @Attr.EventAvailability='" + strEventAvailability + "']", objParentEventHandlerNode);
                		if (objEventNode) {

                			// Execute the client event node.
                			Client_ExecuteEvent(objEventNode, objEvent);

                			// Return that event was handled.
                			return true;
                		}
                	}
                }                
            }
        }
    }

    // Return that event was not handled.
    return false;
}
/// </method>

/// <method name="Client_GetClientEventPropogationParent">
/// <summary>
/// Gets parent node containing current node type in its event propogation tags list.
/// </summary>
/// <param name="objDataNode">The current node fired event to process.</param>
function Client_GetClientEventPropogationParent(objDataNode){
	
	if (objDataNode) {
		// Get node type.
		var strNodeType = objDataNode.nodeName;

		// Get parent node containing current node type in its event propogation tags list.
		return Xml_SelectSingleNode("ancestor::WC:*[@Attr.ClientEventsPropogationTags[contains(.,'" + strNodeType + "')]][1]", objDataNode, null);
	}

	return null; 
}
/// </method>

/// <method name="Client_ExecuteEvent">
/// <summary>
/// Executes an event.
/// </summary>
/// <param name="objEvent">The event to process.</param>
function Client_ExecuteEvent(objClientEventNode, objEventArgs)
{
    if (objClientEventNode)
    {
        try
        {
            // If the event args are event xml node, we will convert it to xml.
            if (objEventArgs != undefined && objEventArgs.tagName == "Attr.Events")
            {
                objEventArgs = convertEventNodeToJson(objEventArgs);
            }

            // Save the event args as global member, so it will be used by the strCode if needed.
            vwgContext.events.eventArgs(objEventArgs);

            var objMethodInvokeNodes = Xml_SelectNodes("Tags.MethodInvokes/Tags.MethodInvoke", objClientEventNode);

            // Loop all method invokes nodes
            for (var intIndex = 0; intIndex < objMethodInvokeNodes.length; intIndex++)
            {
                Remoting_ServerInvoke(objMethodInvokeNodes[intIndex]);
            }
        }
        catch (e)
        {
            Debug_Log("Client event handler execution failed:\n" + e.message);
        }
        finally
        {
            // Clear the event args.
            vwgContext.events.eventArgs(undefined);
        }
    }
}
/// </method>

/// <method name="convertEventNodeToJson">
/// <summary>
///
/// </summary>
/// <param name="objEvent">The event to process.</param>
function convertEventNodeToJson(objEventNode)
{
    var objEventJson = {};

    // Loop thru all event attributes and create a json object.
    for (var i = 0; i < objEventNode.attributes.length; i++)
    {
        var objAttribute = objEventNode.attributes[i];
        var name = objAttribute.nodeName;
        var value = Xml_GetAttribute(objEventNode, name);
        objEventJson[name] = value;
    }

    return objEventJson;
}