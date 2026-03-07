/// <page code="Forms" name="Forms Services">
/// <summary>
/// Controls related services
/// </summary>

// Collection of open forms by id
var mobjFormsWindowById				= {};

// Collection of open popups by id
var mobjFormsPopupById				= {};

// Popup management objects
var mobjFormsActivePopup			= null;
var mobjFormsActivePopupWindow		= null;
var mstrFormsActivePopupGuid		= "";

// This parameters are used to calculate form opening offset
var mobjFormsOffsetFound			= false;
var mintFormsOffsetW				= 0;
var mintFormsOffsetH				= 0;
var mintFormsOffsetX				= 0;
var mintFormsOffsetY				= 0;

// Indicates in reload state
var mblnFormsIsReload = false;

// Resizing interval.
var mintMainFormResizeHandle = 0;	// Handle the resize event

// An array which contains all IE dialogs initialization state.
var marrDialogInitializationState = {};

// Holds the id of the active window.
var mstrActiveWindowGuid= "";

/// <method name="Forms_Initialize" access="private">
/// <summary>
/// Initializes the forms. 
/// </summary>
/// <param name="objResponse">The server response dom.</param>
function Forms_Initialize(objResponse)
{
	// Reset the form collection
	mobjFormsWindowById = {};
	
	// set initialize response
	objResponseDocument = objResponse.documentElement;
	
	// Get the current window element
	var objOwnerForm = Xml_SelectSingleNode("/WG:Tags.Response/WG:Tags.Form",objResponseDocument);
    if(objOwnerForm!=null)
    {			
        // Get body content element
		 var objBodyContent = Web_GetBodyContentElement();
        var objFormContainer = objBodyContent;

        var objMasterPageNode = Xml_SelectSingleNode("/WG:Tags.Response/WC:Tags.MasterPage", objResponseDocument);;
        if (objMasterPageNode)
        {
            Controls_DrawControl(window, objMasterPageNode, true, objBodyContent);
            objFormContainer = Web_GetMasterPageContentElement();
        }

        // Preload client.
        Client_Preload(objOwnerForm);

        // Initialize the form's GeoLocation service.
        Forms_InitializeGeoLocation(objOwnerForm);

	    // Set window id and active window id
	    mstrActiveWindowGuid = mstrWindowGuid = Web_GetWebId(objOwnerForm.getAttribute("Id"));
    	
	    // Set window title
	    Forms_UpdateTitle(window,objOwnerForm);
    	
	    // Get body content element
	    var objBodyContent = Web_GetContextElementById(window.document.body,"VWG_BodyContent");
        if(objBodyContent)
        {
	        // Draw form.
	        Controls_DrawControl(window, objOwnerForm, true, objFormContainer);
	        
	        // Set current window reference
	        mobjFormsWindowById[mstrWindowGuid] = window;
        	
	        // Process opened forms
	        Forms_ProcessForms(window, objOwnerForm);
                    	
        	// Preserve handled response.
			Forms_HandleResponse.HandledResponse=objResponseDocument;
				
			// Handle response.
			Forms_HandleResponse();

            //Initialize WebSockets
			Forms_InitializeWebSockets();
	    }
	}
	else
	{
	    // Handle refresh or close response
	    Events_HandleTerminationResponse(objResponseDocument);
	}
	
	// Try getting the Device integrator
	var objDeviceIntegration = Xml_SelectSingleNode("/WG:Tags.Response/Tags.DeviceIntegrator", objResponseDocument);
	
	// If device integrator exists
	if (objDeviceIntegration)
	{
        // Get the VWG_DeviceIntegration element
	    var objDeviceContent = Web_GetContextElementById(window.document.body, "VWG_DeviceIntegration");
	    if (objDeviceContent)
	    {
            // Render the device integrator element
	        Controls_DrawControl(window, objDeviceIntegration, true, objDeviceContent);
	    }
	}
}
/// </method>

/// <method name="Forms_ProcessMasterPage">
/// <summary>
/// Process master page. 
/// </summary>
function Forms_ProcessMasterPage(objMasterPageNode)
{
    // NOTE: In case master page has been rendered, in order to avoid rendering all the forms (because all the forms are under the master page)
    // and in order to keep the "closed" forms under the master page we will remove all the forms from the master page, update the master page
    // and than return to forms to the master page.

    // Save the current master page forms.
    // NOTE: We do not need to remove the forms from the windows box, because after the master page update, the windows box will be replaced.
    // NOTE2: We remove all the window box child nodes, because if we will not do that, in the Forms_UpdateControl the form elements children will disappear.
    var objCurrentFormElements = [];
    var objWindowsBox = Web_GetWindowsBox();
    for (var i = objWindowsBox.childNodes.length -  1; i >= 0; i--)
    {
        var objFormElement = objWindowsBox.childNodes[i];        
        objCurrentFormElements.push(objFormElement);
        objWindowsBox.removeChild(objFormElement);
    }

    // Take the master page from the response and replace the current master page with it.
    // NOTE: This code is added because in FireFox, the XslTransform can be executed only on xml nodes from the mobjDataDomObject and not with nodes from the response.
    var objExistMasterPageNode = Xml_SelectSingleNode("/WG:Tags.Response/WC:Tags.MasterPage", mobjDataDomObject.documentElement);
    var strMasterPageNodeId = Controls_GetGuid(objExistMasterPageNode);
    objMasterPageNode = Data_SetNode(strMasterPageNodeId, objMasterPageNode.cloneNode(true));

    // Update only the master page.
    var objMastePageContainer = Web_GetContextElementById(window.document.body, "VWG_BodyContent");
    Forms_UpdateControl(window, objMasterPageNode, false, objMastePageContainer);

    // Get the new windows box after the master page has been rendered.
    objWindowsBox = Web_GetWindowsBox();

    // Returned the original forms to the new master page.
    for (var i = 0; i < objCurrentFormElements.length; i++)
    {
        var objFormHtml = objCurrentFormElements[i];
        var objFormElement = $(objFormHtml)[0];
        objWindowsBox.appendChild(objFormElement);
    }
}

/// <method name="Forms_ProcessForms" access="private">
/// <summary>
/// Processes the child windows.
/// </summary>
/// <param name="objWindow">The parent browser window.</param>
/// <param name="objOwnerFormNode">The parent server object data.</param>
function Forms_ProcessForms(objWindow, objOwnerFormNode)
{
    // Get all child forms.
    var arrFormNodes = Xml_SelectNodes("WG:Tags.Form", objOwnerFormNode);
	
    // Loop all child forms
	for(var intIndex=0; intIndex < arrFormNodes.length; intIndex++)
	{
		// Get current form node.
		var objCurrentFormNode = arrFormNodes[intIndex];
		
		// The form node
		var objFormNode = null;
		
		// Get the form node id
		var strFormNodeId = Xml_GetAttribute(objCurrentFormNode, "Attr.Id", "");
		
		// Get the parent form node
		var objParentNode = Data_GetNode(Xml_GetAttribute(objOwnerFormNode, "Attr.Id", ""));
		
		// Get the window node if available
		var objWindowData = Data_GetNode(strFormNodeId,objParentNode);
		
		
		// If could not find form data
		if(!objWindowData)
		{
		    // Clone node so we can embed it into the data behind
			objFormNode = objCurrentFormNode.cloneNode(true);
			
			// If the parent is valid
			if(objParentNode)
			{
			    // Append the cloned node to the parent
			    objParentNode.appendChild(objFormNode);
			}
		}
		else
		{
		    // Simply get the existing node
			objFormNode = objWindowData;
		}

        // If there is a valid form node
        if(objFormNode)
        {
            // By default we want to draw the delayed controls
            var blnDrawDelayedControls = true;
            
            // Get an existing form from the window cache
            var objFormElement = Forms_GetWindowById(strFormNodeId);
            
            // If window does not exist it is a new window
            if(!objFormElement)
            {
                // Create a new window form.
                objFormElement = Forms_CreateForm(objWindow, objFormNode);
                
                // In case that a new form is created, flag not to draw delayed controls.
                blnDrawDelayedControls = false;
            }
		    
	        // Process form new or updated form.
	        if(objFormElement)
	        {
	            // Process the window form changes or initialization drawing
                Forms_ProcessForm(objFormElement, objCurrentFormNode, blnDrawDelayedControls);
            }

        }
    }
}
/// </method>

/// <method name="Forms_ProcessForm" access="private">
/// <summary>
/// Processes window changes.
/// </summary>
/// <param name="objWindow">The containing browser window object.</param>
/// <param name="objResponse">The server window data response.</param>
/// <param name="blnDrawDelayedControls">Whether to draw delayed controls or not.</param>
function Forms_ProcessForm(objWindow, objFormNode, blnDrawDelayedControls) 
{
    if (!objFormNode) { return; }

    if (Xml_IsAttribute(objFormNode, "Attr.Redraw", "1"))
	{
            // Getting all owned forms.
        var arrChildFormNodes = Xml_SelectNodes("WG:Tags.Form[not(@Attr.Redraw)]", objFormNode);

            // Loop all owned forms.
            for(var intForm=0; intForm<arrChildFormNodes.length;intForm++)
            {
                // Get current owned form node.
                var objCurrentFormNode = arrChildFormNodes[intForm];
                if(objCurrentFormNode)
                {
                    // Get current owned form id.
                    var strCurrentFormId = Xml_GetAttribute(objCurrentFormNode,"Attr.Id","");
                    if(!Aux_IsNullOrEmpty(strCurrentFormId))
                    {
                        // Getting current owned form node from data behind.
                        var objDataFormNode = Data_GetNode(strCurrentFormId);
                        if(objDataFormNode)
                        {
                            // Getting data node parent node.
                            var objCurrentFormParentNode = objCurrentFormNode.parentNode;
                            if(objCurrentFormParentNode)
                            {
                                // Clone data form node.
                                var objClonedFormNode = objDataFormNode.cloneNode(true);
                                if(objClonedFormNode)
                                {
                                    // Remove the cloned form redraw atrtibute.
                                    objClonedFormNode.removeAttribute("Attr.Redraw");

                                    // Replace current form node in response with the cloned one.
                                    objCurrentFormParentNode.replaceChild(objClonedFormNode,objCurrentFormNode);
                                }
                            }
                        }
                    }
                }
            }
    }

    Forms_UpdateControl(objWindow, objFormNode, blnDrawDelayedControls);
        
    // Get the window form id
    var strGuid = Xml_GetAttribute(objFormNode,"Id");
        
	// Set window title
    Forms_UpdateTitle(objWindow,objFormNode,strGuid);
		
	// Set window params
    Forms_UpdateParams(objWindow, objFormNode, strGuid, blnDrawDelayedControls);

	// process child windows
    Forms_ProcessForms(objWindow, objFormNode);	    
		}
/// </method>


/// <method name="Forms_UpdateControl" access="private">
/// <summary>
/// Updates the control. (Form or MasterPage)
/// </summary>
function Forms_UpdateControl(objWindow, objNode, blnDrawDelayedControls)
{
    // If form should redraw
    if(Xml_IsAttribute(objNode,"Attr.Redraw","1"))
    {
        var strDataId = Data_GetNodeAttribute(objNode, "Id");
        var objFormElement = Forms_GetWindowById(strDataId);

        if (objFormElement)
        {
            // Redraw the entire control.
            Controls_UpdateControl(Forms_GetWindow(objWindow), objNode, true, blnDrawDelayedControls);
        }
		else
		{
            // Redraw the forms control..
	        var strType = Xml_GetAttribute(objNode,"Attr.Type","");

            var objControlContainer = null;

	        switch (strType) 
            {
                case "MainWindow":
                    objControlContainer = Web_GetBodyContentElement();
                    break;
                case "PopupWindow":
                    objControlContainer = Web_GetElementById("VWG_PopUpBox", objWindow);
                    break;
	            default:
                    objControlContainer = Web_GetWindowsBox();
                    break;
	        }

            Controls_DrawControl(objWindow, objNode, true, objControlContainer);
        }
    }
    else
    {
		    // get all postback element
        var objElements	= objNode.childNodes;

		    // loop all controls
		    for(var intIndex=0;intIndex<objElements.length;intIndex++)
		    {
			    // Get current node
			    var objElement = objElements[intIndex];

			    // Select node type
			    switch(objElement.nodeName)
			    {
			        // The form and traces are handled in a diffrent process
				    case "WG:Tags.Form":
				    case "WG:Traces":
					    break;
    				
    				// Updates the node paramater using xml diff
				    case "WC:Tags.UpdateParams":
				    case "WG:Tags.UpdateParams":
				        Controls_UpdateControlParams(Forms_GetWindow(objWindow), objElement, null, true, Xml_IsAttribute(objElement, "Attr.UseClientUpdateHandler", "1"), blnDrawDelayedControls);
					    break;

                        
                    // Update the entire control
				    default:
					    Controls_UpdateControl(Forms_GetWindow(objWindow), objElement, true, blnDrawDelayedControls);
					    break;
			    }
		    }
        }
	}
/// </method>


/// <method name="Forms_UpdateTitle" access="private">
/// <summary>
/// Updates the browser window title.
/// </summary>
/// <param name="objWindow">The browser window to update.</param>
/// <param name="objResponse">The server response data.</param>
function Forms_UpdateTitle(objWindow,objResponse,strGuid)
{
	// Set window title if needed get the decoded value
	var strTitle = Xml_GetAttribute(objResponse, "Attr.Text", null, true);
	
	// If there is a valid title
	if(!Aux_IsNullOrEmpty(strTitle))
	{
	    // If is inline form
	    if (Forms_IsInlineWindow(objWindow))
        {
            // Get the window title text
            var objTitle = $$("VWGE_WinTX"+strGuid);
            if(objTitle) 
            {
                Web_SetInnerText(objTitle,strTitle);
            }
        }
	    else if (Web_IsWindow(objWindow)) {
	        // Updates the window title
	        objWindow.document.title = strTitle;
	    }
    }
}
/// </method>

/// <method name="Forms_UpdateControlBoxVisibility" access="private">
/// <summary>
///
/// </summary>
function Forms_UpdateControlBoxVisibility(objFormNode, objResponse)
{
    // Validate recieved arguments.
    if (objResponse && objFormNode)
    {
        // Get the form's control box attribute.
        var strControlBox = Xml_GetAttribute(objResponse, "Attr.ControlBox", "");
        if (!Aux_IsNullOrEmpty(strControlBox))
        {
            // Update form's control box attribute.
            Data_SetNodeAttribute(objFormNode, "Attr.ControlBox", strControlBox);
        }
    }
}
/// </method>

/// <method name="Forms_UpdateFormButtons" access="private">
/// <summary>
///
/// </summary>
function Forms_UpdateFormButtons(objFormNode, objResponse)
{
    // Validate recieved arguments.
    if (objResponse && objFormNode)
    {
        // Get the form's accept button attribute.
        var strAcceptButton = Xml_GetAttribute(objResponse,"Attr.AcceptButton","");
        if(!Aux_IsNullOrEmpty(strAcceptButton))
        {
            // Update form's accept button attribute.
            Data_SetNodeAttribute(objFormNode, "Attr.AcceptButton", strAcceptButton);
        }
        
        // Get the form's cancel button attribute.
        var strCancelButton = Xml_GetAttribute(objResponse,"Attr.CancelButton","");
        if(!Aux_IsNullOrEmpty(strCancelButton))
        {
            // Update form's cancel button attribute.
            Data_SetNodeAttribute(objFormNode, "Attr.CancelButton", strCancelButton);
        }
    }
}
/// </method>

/// <method name="Forms_UpdateFormControlBoxData" access="private">
/// <summary>
///
/// </summary>
function Forms_UpdateFormControlBoxData(objFormNode, objResponse)
{   
    // Validate recieved arguments.
    if(objResponse && objFormNode)
    {
        // Get the form's close box attribute.
        var strCloseBox = Xml_GetAttribute(objResponse, "Attr.Close", "");
        if (!Aux_IsNullOrEmpty(strCloseBox))
        {
            // Update form's close box attribute.
            Data_SetNodeAttribute(objFormNode, "Attr.Close", strCloseBox);
        }

        // Get the form's maximize box attribute.
        var strMaximizeBox = Xml_GetAttribute(objResponse,"Attr.Maximize","");
        if(!Aux_IsNullOrEmpty(strMaximizeBox))
        {
            // Update form's maximize box attribute.
            Data_SetNodeAttribute(objFormNode, "Attr.Maximize", strMaximizeBox);
        }
        
        // Get the form's mininize box attribute.
        var strMinimizeBox = Xml_GetAttribute(objResponse,"Attr.Minimize","");
        if(!Aux_IsNullOrEmpty(strMinimizeBox))
        {
            // Update form's minimize box attribute.
            Data_SetNodeAttribute(objFormNode, "Attr.Minimize", strMinimizeBox);
        }
    }
}
/// </method>

/// <method name="Forms_UpdateFormControlBoxElement" access="private">
/// <summary>
///
/// </summary>
function Forms_UpdateFormControlBoxElement(strGuid)
{
    // Validate recieved arguments and main DOM object.
    if(!Aux_IsNullOrEmpty(strGuid) && mobjDataDomObject)
    {
        // Get header element.
        var objControlBoxElement = Web_GetElementById("VWGE_WinHeader"+strGuid,window);
        if(objControlBoxElement)
        {
            // Create a control box node.
            var objControlBoxNode = Xml_CreateNode(mobjDataDomObject,1,"WG:"+"Tags.FormControlBox","http://www.gizmox.com/webgui");
            if(objControlBoxNode)
            {
                // Get form node.
                var objFormNode = Data_GetNode(strGuid);
                if(objFormNode)
                {
                    // Set the form's id attribute.
                    Xml_SetAttribute(objControlBoxNode,"Attr.Id",strGuid);

                    // Set the control box maximize attribute - if one exist.
                    var strControlBox = Data_GetNodeAttribute(objFormNode, "Attr.ControlBox", "");
                    if (!Aux_IsNullOrEmpty(strControlBox))
                    {
                        Xml_SetAttribute(objControlBoxNode, "Attr.ControlBox", strControlBox);
                    }
                    if (strControlBox != "0")
                    {
                        // Set the control box close attribute - if one exist.
                        var strCloseBox = Data_GetNodeAttribute(objFormNode, "Attr.Close", "1");
                        if (!Aux_IsNullOrEmpty(strCloseBox))
                        {
                            Xml_SetAttribute(objControlBoxNode, "Attr.Close", strCloseBox);
                        }

                        // Set the control box maximize attribute - if one exist.
                        var strMaximizeBox = Data_GetNodeAttribute(objFormNode, "Attr.Maximize", "");
                        if (!Aux_IsNullOrEmpty(strMaximizeBox))
                        {
                            Xml_SetAttribute(objControlBoxNode, "Attr.Maximize", strMaximizeBox);
                        }

                        // Set the control box minimize attribute - if one exist.
                        var strMinimizeBox = Data_GetNodeAttribute(objFormNode, "Attr.Minimize", "");
                        if (!Aux_IsNullOrEmpty(strMinimizeBox))
                        {
                            Xml_SetAttribute(objControlBoxNode, "Attr.Minimize", strMinimizeBox);
                        }

                        // Get the form's border style attribute.
                        var strFormBorderStyle = Data_GetNodeAttribute(objFormNode, "Attr.FormBorderStyle", "");
                        if (!Aux_IsNullOrEmpty(strFormBorderStyle))
                        {
                            // Set the control box border style attribute.
                            Xml_SetAttribute(objControlBoxNode, "Attr.FormBorderStyle", strFormBorderStyle);
                        }

                        // Get the form's window state attribute.
                        var strWindowState = Data_GetNodeAttribute(objFormNode, "Attr.WindowState", "");
                        if (!Aux_IsNullOrEmpty(strWindowState))
                        {
                            // Set the control box window state attribute.
                            Xml_SetAttribute(objControlBoxNode, "Attr.WindowState", strWindowState);
                        }
                    }
                    // Append control box node to form node.
                    objFormNode.appendChild(objControlBoxNode);
                    
                    try
                    {
                        // Draw the control box node into the header element.
                        Controls_SetOuterHtmlFromNode(window,objControlBoxElement,objControlBoxNode);
                    }
                    catch(e){}
                    
                    // Remove control box node from form node.
                    objFormNode.removeChild(objControlBoxNode);
                }
            }
        }
    }
}
/// </method>

/// <method name="Forms_UpdateFormRectangleElement" access="private">
/// <summary>
/// 
/// </summary>
function Forms_UpdateFormRectangleElement(strGuid, objFormNode, intLeft, intTop, intWidth, intHeight)
{
    // Validate form's data id.
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        // Validate positions or sizes.
        if((!Aux_IsNullOrEmpty(intLeft) && !Aux_IsNullOrEmpty(intTop)) || (!Aux_IsNullOrEmpty(intWidth) && !Aux_IsNullOrEmpty(intHeight)))
        {
            // Get form wrapper element.
            var objFormWrapperElement = Web_GetElementById("WRP_"+strGuid,window);
            if(objFormWrapperElement)
            { 
                // Convert position to Integer
                intLeft = parseInt(intLeft);
                intTop = parseInt(intTop);
                
                if(!isNaN(intLeft) && !isNaN(intTop))
                {
                    // Set the new window top and left
                    objFormWrapperElement.style.top = intTop + "px";
                    objFormWrapperElement.style.left = intLeft + "px";
                }
                
                // Convert size to Integer
                intWidth = parseInt(intWidth);
                intHeight = parseInt(intHeight);
                
                // Validate sizes.
                if(!isNaN(intWidth) && !isNaN(intHeight))
                {
                    //Get dialog's height and width offsets out of skin defeinitions.
                    var objSize = Forms_GetInlineWindowSkinOffset(strGuid, objFormNode);
                    var intWindowHeightOffset = objSize.Height;
                    var intWindowWidthOffset = objSize.Width;

                    // Set the new window width and height
                    objFormWrapperElement.style.width = (intWidth+intWindowWidthOffset)+"px";
                    objFormWrapperElement.style.height = (intHeight+intWindowHeightOffset)+"px";
                }
            }
        }
    }
}
/// </method>

/// <method name="Forms_UpdateParams" access="private">
/// <summary>
/// Updates browser window parameters.
/// </summary>
/// <param name="objWindow">The browser object window.</param>
/// <param name="objResponse">The server response data.</param>
function Forms_UpdateParams(objWindow, objResponse, strGuid, blnDrawDelayedControls)
{
    // Validate recieved arguments.
    if(objWindow && objResponse && !Aux_IsNullOrEmpty(strGuid))
    {
        // Get Form data node
        var objFormNode = Data_GetNode(strGuid);

        // Update form's accept / cancel buttons.
        Forms_UpdateFormButtons(objFormNode, objResponse);

        // Update control box
        Forms_UpdateControlBoxVisibility(objFormNode, objResponse);

        // Cancel resizing of main form.
        if (Web_GetWebId(mstrWindowGuid) != Web_GetWebId(strGuid))
        {
			// Update window size, state, and control box if not in full screen mode.
            if (!mblnFullScreenMode)
            {
                // Check whether the received form is an MDI form.
                var blnIsMdiChild = !Aux_IsNullOrEmpty(Data_GetNodeAttribute(objFormNode, "Attr.MdiParent", ""));

                // Get width and height of the current form
                var intWidth = Xml_GetAttribute(objResponse, "Attr.Width", "");
                var intHeight = Xml_GetAttribute(objResponse, "Attr.Height", "");

                // Get current window's state.
                var strCurrentWindowState = Data_GetNodeAttribute(objFormNode, "Attr.WindowState", "0");

                // Get the window's state.
                var strNewWindowState = Xml_GetAttribute(objResponse, "Attr.WindowState", strCurrentWindowState);

                // If is inline windows
                if (mblnInlineWindows || blnIsMdiChild)
                {
                    // Update form's control box data.
                    Forms_UpdateFormControlBoxData(objFormNode, objResponse);

                    // Get top and left of current form (from response with default values out of meta data).
                    var intLeft = Xml_GetAttribute(objResponse, "Attr.Left", Xml_GetAttribute(objFormNode, "Attr.Left", ""));
                    var intTop = Xml_GetAttribute(objResponse, "Attr.Top", Xml_GetAttribute(objFormNode, "Attr.Top", ""));

                    // Get restored sizes and positions of current form (from response with default values out of meta data).
                    var intRestoredWidth = Xml_GetAttribute(objResponse, "Attr.RestoredWidth", Xml_GetAttribute(objFormNode, "Attr.RestoredWidth", ""));
                    var intRestoredHeight = Xml_GetAttribute(objResponse, "Attr.RestoredHeight", Xml_GetAttribute(objFormNode, "Attr.RestoredHeight", ""));
                    var intRestoredLeft = Xml_GetAttribute(objResponse, "Attr.RestoredLeft", Xml_GetAttribute(objFormNode, "Attr.RestoredLeft", ""));
                    var intRestoredTop = Xml_GetAttribute(objResponse, "Attr.RestoredTop", Xml_GetAttribute(objFormNode, "Attr.RestoredTop", ""));

                    // Update form rectangle meta data
                    Forms_UpdateFormRectangleData(objFormNode, intLeft, intTop, intWidth, intHeight, intRestoredLeft, intRestoredTop, intRestoredWidth, intRestoredHeight);

                    // In case of new "Normal" window state.
                    if (strNewWindowState == "0")
                    {
                        // Restore inline window to Normal state.
                        Forms_RestoreInlineWindow(objWindow, strGuid, objFormNode, strCurrentWindowState, strNewWindowState, intRestoredWidth, intRestoredHeight, intRestoredLeft, intRestoredTop, intWidth, intHeight, intLeft, intTop);
                    }

                    // Check if window state is changed.
                    else if (strCurrentWindowState != strNewWindowState)
                    {
                        // Check window state.
                        switch (strNewWindowState)
                        {
                            case "1":
                                // Minimize inline window.
                                Forms_MinimizeInlineWindow(strGuid, window, false);
                                break;

                            case "2":
                                // Maximize inline window.
                                Forms_MaximizeInlineWindow(strGuid, null, window, false, false);
                                break;
                        }
                    }

                    // If window state is changed - update it.
                    if (strCurrentWindowState != strNewWindowState)
                    {
                        Data_SetNodeAttribute(objFormNode, "Attr.WindowState", strNewWindowState);
                    }

                    // Update control box element.
                    Forms_UpdateFormControlBoxElement(strGuid);

                    // Get the restored window's state.
                    var strRestoredWindowState = Xml_GetAttribute(objResponse, "Attr.RestoredWindowState", "");
                    if (!Aux_IsNullOrEmpty(strRestoredWindowState))
                    {
                        // If meta data's restored window state is different - update it.
                        if (!Data_IsNodeAttribute(objFormNode, "Attr.RestoredWindowState", strRestoredWindowState))
                        {
                            Data_SetNodeAttribute(objFormNode, "Attr.RestoredWindowState", strRestoredWindowState);
                        }
                    }
                }

                // None inline windows.
                else
                {
                    // Validate sizes.
                    if (!Aux_IsNullOrEmpty(intWidth) && !Aux_IsNullOrEmpty(intHeight))
                    {
                        try
                        {
                            // Convert size to Integer
                            intWidth = parseInt(intWidth);
                            intHeight = parseInt(intHeight);

                            objWindow.resizeTo((intWidth + mintFormsOffsetW * 1), (intHeight + mintFormsOffsetH * 1));
                        }
                        catch (e) { }

                        try
                        {
                            objWindow.dialogHeight = (intHeight + mintFormsOffsetH * 1) + "px";
                            objWindow.dialogWidth = (intWidth + mintFormsOffsetW * 1) + "px";
                        }
                        catch (e) { }
                    }
                }
            }

            // Update drag targets.
            var strDragTargets = Xml_GetAttribute(objResponse, "Attr.DragTargets", "");
            if (!Aux_IsNullOrEmpty(strDragTargets))
            {
                Data_SetNodeAttribute(objFormNode, "Attr.DragTargets", strDragTargets);

                var strFormDragElementIDPrefix = mblnFullScreenMode ? "VWG_" : "WRP_";

                var objFormWrapperElement = Web_GetElementById(strFormDragElementIDPrefix + strGuid, window);
                if (objFormWrapperElement)
                {
                    Web_SetAttribute(objFormWrapperElement, "vwgdragtargets", strDragTargets);
                }
            }

        }

        // Update form's other updateable attributes.
        Forms_UpdateFormAttributes(objWindow, objFormNode, objResponse, blnDrawDelayedControls);
    }
}
/// </method>

/// <method name="Forms_RedrawFormContent" access="private">
/// <summary>
/// 
/// </summary>
function Forms_RedrawFormContent(objWindow, objFormNode, blnExcludeDelayedControls)
{
    Xml_SetAttribute(objFormNode, "vwg_content", "1");

    try
    {
        // Redraw the entire form (passing the form node, because the response might not contain all the controls)
        Controls_RedrawControlByNode(Forms_GetWindow(objWindow), objFormNode, blnExcludeDelayedControls);
    }
    catch (e)
    {
        // Remove the recieved node's redraw attribute.
        Xml_RemoveAttribute(objFormNode, "vwg_content");

        // Throws original exception.
        throw e;
    }

    Xml_RemoveAttribute(objFormNode, "vwg_content");
}
/// </method>

/// <method name="Forms_UpdateFormAttributes" access="private">
/// <summary>
/// Updates the form's attributes with the new data from the server
/// </summary>
/// <param name="objFormNode"></param>
/// <param name="objResponse"></param>
function Forms_UpdateFormAttributes(objWindow, objFormNode, objResponse, blnDrawDelayedControls)
{
     // Validate recieved arguments.
    if (objResponse && objFormNode)
    {
	    var strTitle = Xml_GetAttribute(objResponse, "Attr.Text", null, true);
	
	    // If there is a valid title
	    if (!Aux_IsNullOrEmpty(strTitle))
	    {
	        // Update form's Enable attribute.
	        Data_SetNodeAttribute(objFormNode, "Attr.Text", strTitle);
	    }

        //The Enable attribute
        var strEnabeled = Xml_GetAttribute(objResponse, "Attr.Enabled", "");
        if (!Aux_IsNullOrEmpty(strEnabeled))
        {
            // Update form's Enable attribute.
            Data_SetNodeAttribute(objFormNode, "Attr.Enabled", strEnabeled);

            Forms_RedrawFormContent(Forms_GetWindow(objWindow), objFormNode, !blnDrawDelayedControls);
        }
    }
}

/// <method name="Forms_RestoreInlineWindow" access="private">
/// <summary>
/// Restore inline window to Normal
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objFormNode"></param>
/// <param name="intLeft"></param>
/// <param name="intTop"></param>
/// <param name="intWidth"></param>
/// <param name="intHeight"></param>
/// <param name="intRestoredLeft"></param>
/// <param name="intRestoredTop"></param>
/// <param name="intRestoredWidth"></param>
/// <param name="intRestoredHeight"></param>
function Forms_RestoreInlineWindow(objWindow, strGuid, objFormNode, strCurrentWindowState, strNewWindowState, intRestoredWidth, intRestoredHeight, intRestoredLeft, intRestoredTop, intWidth, intHeight, intLeft, intTop)
{
	// Check if current window state is different from "Normal".
	if (strCurrentWindowState != strNewWindowState)
	{
		// Validate restored sizes and positions.
		if (!Aux_IsNullOrEmpty(intRestoredWidth) && !Aux_IsNullOrEmpty(intRestoredHeight) &&
                            !Aux_IsNullOrEmpty(intRestoredLeft) && !Aux_IsNullOrEmpty(intRestoredTop))
		{
			// Get restored sizes and positions.
			intWidth = intRestoredWidth;
			intHeight = intRestoredHeight;
			intLeft = intRestoredLeft;
			intTop = intRestoredTop;
		}
	}
	
	// Restore inline window.
	Forms_UpdateFormRectangleElement(strGuid, objFormNode, intLeft, intTop, intWidth, intHeight);
	
	// If restored from minimized, take care of taskbar.
	if(strCurrentWindowState == "1")
	{
		Forms_RestoreTaskBarItem(objWindow, "TBI_" + strGuid);
	}
}
/// </method>

/// <method name="Forms_UpdateFormRectangleData" access="private">
/// <summary>
/// Update form rectangle meta data 
/// </summary>
/// <param name="objFormNode"></param>
/// <param name="intLeft"></param>
/// <param name="intTop"></param>
/// <param name="intWidth"></param>
/// <param name="intWidth"></param>
/// <param name="intRestoredLeft"></param>
/// <param name="intRestoredTop"></param>
/// <param name="intRestoredWidth"></param>
/// <param name="intRestoredHeight"></param>
function Forms_UpdateFormRectangleData(objFormNode, intLeft, intTop, intWidth, intHeight, intRestoredLeft, intRestoredTop, intRestoredWidth, intRestoredHeight)
{
    // Check that top and left values are not empty
    if (!Aux_IsNullOrEmpty(intLeft) && !Aux_IsNullOrEmpty(intTop)) 
    {
        // Update Left + Top
        if (!Data_IsNodeAttribute(objFormNode, "Attr.Left", intLeft))
        {
            Data_SetNodeAttribute(objFormNode, "Attr.Left", intLeft);
        }
        if (!Data_IsNodeAttribute(objFormNode, "Attr.Top", intTop))
        {
            Data_SetNodeAttribute(objFormNode, "Attr.Top", intTop);
        }        
    }
    
    // Check that restored left and top values are not empty
    if(!Aux_IsNullOrEmpty(intRestoredLeft) && !Aux_IsNullOrEmpty(intRestoredTop))        
    {
        // Update restored Left + Top
        if (!Data_IsNodeAttribute(objFormNode, "Attr.RestoredLeft", intRestoredLeft))
        {
            Data_SetNodeAttribute(objFormNode, "Attr.RestoredLeft", intRestoredLeft);
        }
        if (!Data_IsNodeAttribute(objFormNode, "Attr.RestoredTop", intRestoredTop))
        {
            Data_SetNodeAttribute(objFormNode, "Attr.RestoredTop", intRestoredTop);
        }
    }
    
    // Check that width and height values are not empty
    if(!Aux_IsNullOrEmpty(intWidth) && !Aux_IsNullOrEmpty(intHeight))        
    {
        // Update Width + Height
        if (!Data_IsNodeAttribute(objFormNode, "Attr.Width", intWidth))
        {
            Data_SetNodeAttribute(objFormNode, "Attr.Width", intWidth);
        }
        if (!Data_IsNodeAttribute(objFormNode, "Attr.Height", intHeight))
        {
            Data_SetNodeAttribute(objFormNode, "Attr.Height", intHeight);
        }
    }
    
    // Check that restored width and height values are not empty
    if(!Aux_IsNullOrEmpty(intRestoredWidth) && !Aux_IsNullOrEmpty(intRestoredHeight))        
    {
        // Update restored Width + Height
        if (!Data_IsNodeAttribute(objFormNode, "Attr.RestoredWidth", intRestoredWidth))
        {
            Data_SetNodeAttribute(objFormNode, "Attr.RestoredWidth", intRestoredWidth);
        }
        if (!Data_IsNodeAttribute(objFormNode, "Attr.RestoredHeight", intRestoredHeight))
        {
            Data_SetNodeAttribute(objFormNode, "Attr.RestoredHeight", intRestoredHeight);
        }
    }
}
/// </method>

/// <method name="Forms_UpdateActiveForm" access="private">
/// <summary>
/// 
/// </summary>
/// <param name="objResponse">The server response data.</param>
function Forms_UpdateActiveForm(objResponse)
{
    if(objResponse)
    {   
        // Get the active form which has been sent from server side.
	    var strActiveWindowDataId = Xml_GetAttribute(objResponse,"Attr.ActiveForm","");
	    if(!Aux_IsNullOrEmpty(strActiveWindowDataId))
	    {
	        // If not the current focus window
	        if(mstrActiveWindowGuid != Web_GetWebId(strActiveWindowDataId))
	        {
	            // Set active window focus
	            Forms_SetFocus(strActiveWindowDataId);

	            // Set active form.
	            Forms_SetActiveFormById(strActiveWindowDataId, true);
	        }
	        
	    }
    }
}
/// </method>

/// <method name="Forms_ExecuteMethodInvokes" access="private">
/// <summary>
/// 
/// </summary>
/// <param name="objResponse">The server response data.</param>
function Forms_ExecuteMethodInvokes(objResponse)
{
    if(objResponse)
    {
        // Get current method invokes.
        var objMethodInvokeNodes = Xml_SelectNodes("/WG:Tags.Response/Tags.MethodInvokes/Tags.MethodInvoke",objResponse,objResponse.ownerDocument);
        if (objMethodInvokeNodes && objMethodInvokeNodes.length > 0)
        {
            // Loop all method invokes.
            for (var intIndex = 0; intIndex < objMethodInvokeNodes.length; intIndex++)
            {
                Remoting_ServerInvoke(objMethodInvokeNodes[intIndex]);
            }
        }
      
        // Clear remoting information.
        Remoting_Clear();
    }
}
/// </method>

/// <method name="Forms_DialogsInitialized" access="private">
/// <summary>
/// 
/// </summary>
function Forms_DialogsInitialized()
{
    // Validate dialogs array.
    if(marrDialogInitializationState)
    {
        // Loop all dialogs.
        for(var strDialogId in marrDialogInitializationState)
        {
            // If one of the dialogs is not initialized, return false.
            if(marrDialogInitializationState[strDialogId]!="1")
            {
                return false;
            }
        }
    }
    
    return true;
}
/// </method>

/// <method name="Forms_HandleResponse" access="private">
/// <summary>
/// Processes response data.
/// </summary>
function Forms_HandleResponse()
{
    // Check if all loaded modeless dialogs are initialized.
    if(Forms_DialogsInitialized())
    {
        // Clear the modeless dialogs array.
        marrDialogInitializationState = {};
        
        // Invoke Forms_DoHandleResponse with a milli-seconds delay inorder to allow delayed controls being drawn with delay.
        Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Forms_DoHandleResponse,Forms_HandleResponse.HandledResponse),1);
        
        // Clear handled response.
        Forms_HandleResponse.HandledResponse=null;
    }
    else
    {
        // Invoke Forms_HandleResponse with a milli-seconds delay inorder to allow all IE dialogs to be initialized.
        Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Forms_HandleResponse),1);
    }
}
/// </method>

/// <method name="Forms_DoHandleResponse" access="private">
/// <summary>
/// Processes response data.
/// </summary>
/// <param name="objResponse">The handled response.</param>
function Forms_DoHandleResponse(objResponse)
{
    // Validate recieved response.
    if(objResponse)
    {
        // Check if any delayed controls are still exist.
        if(Controls_DrawDelayedControls())
        {
            // Invoke this function with a milli-seconds delay inorder to allow delayed controls being completed.
            Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Forms_DoHandleResponse,objResponse),1);
        }
        else 
        {        
            // Update active form out of response.
            Forms_UpdateActiveForm(objResponse);
        
            // Handle timers
            Events_HandleTimers(objResponse);
            
            // Asynchronous execute response's method invokes so that last response updates will have the time to finish.
            Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Forms_ExecuteMethodInvokes, objResponse), 5);
            
		    // Invoke callback method
            Events_InvokeCallback();
            }
        }
    }
/// </method>


/// <method name="Forms_SetDialogInitializationStatus" access="private">
/// <summary>
/// Processes response data.
/// </summary>
function Forms_SetDialogInitializationStatus(strDialogDataId,blnInitialized)
{
    // Validate dialog id and dialogs array.
    if(marrDialogInitializationState && !Aux_IsNullOrEmpty(strDialogDataId))
    {
        // Set dialog's initialization status.
        marrDialogInitializationState[strDialogDataId] = (blnInitialized?"1":"0");
    }
}
/// </method>



/// <method name="Forms_CloseAll" access="private">
/// <summary>
/// Closes all windows.
/// </summary>
/// <param name="blnServerClosed">The flag indicating if server initiated closing.</param>
function Forms_CloseAll(blnServerClosed)
{
	// Loop all forms
	for(var strForm in mobjFormsWindowById)
	{
		// If not current window
		if(mobjFormsWindowById[strForm]!=window)
		{
			// If server closed event
			if(blnServerClosed) Events_SetServerClosed(mobjFormsWindowById[strForm]);
			
			// Close window
			Forms_CloseWindowElement(mobjFormsWindowById[strForm]);
		}
		
		// cleat window cahce cell
		Forms_UnregisterForm(strForm);
	}
}
/// </method>

/// <method name="Forms_ProcessClosed" access="private">
/// <summary>
/// Closes all window that have been server side closed.
/// </summary>
/// <param name="objResponse">The current response object.</param>
function Forms_ProcessClosed(objResponse)
{
	// Check valid window collection
	if(mobjFormsWindowById)
	{
		// Is full reload needed
		var blnIsReload = false;
		
		// array of windows to close
		var objClosed = {};
		
		// Loop all open windows
		for(var strForm in mobjFormsWindowById)
		{
			// Search if window still exists in response
			var objForm = Xml_SelectSingleNode("/"+"/WG:Tags.Form[@Id='"+String(strForm).replace("VWG_","")+"']",objResponse);
			if(objForm==null)
			{
				// get current window
				var objWindow = mobjFormsWindowById[strForm];
				if(objWindow!=null)
				{
				    // If not windows 
					if(strForm!=mstrWindowGuid)
					{
					    var strFormId = Data_GetDataId(strForm);
						var objPopup = mobjFormsPopupById[strFormId];
						
						if(!objPopup)
						{
							objClosed[strForm]=(objWindow);
						}
						else
						{
							// Hide popup form without informing server.
						    Popups_HideFormPopup(objWindow, strFormId, true);
						}
					}
					else
					{
						blnIsReload=true;
					}
				}
			}
		}
		
		var arrForms = [];
		
		// If full reload is required
		if(blnIsReload) 
		{
			// Set reload to true
			mblnFormsIsReload = true;
			
			// Loop all forms
			for(var strForm in mobjFormsWindowById)
			{
				arrForms.push(strForm);
			}
			
			arrForms.reverse();
			
			// Loop all forms
			for(var intIndex=0;intIndex<arrForms.length;intIndex++)
			{
			
				var strForm = arrForms[intIndex];
				
				var objWindow = mobjFormsWindowById[strForm];
				
				// If not current window
				if(objWindow!=window)
				{
					// Set server closed
					Events_SetServerClosed(objWindow);
					
					// Close window
					Forms_CloseWindowElement(objWindow);
				}
				
				// cleat window cahce cell
				Forms_UnregisterForm(strForm);
			}

			mblnFormsIsReload = false;							
			Common_InitializeContent(objResponse.ownerDocument);

			return false;
		}
		else
		{
			// Loop all forms
			for(var strForm in objClosed)
			{
				arrForms.push(strForm);
			}
			
			arrForms.reverse();

			// Loop all forms
			for(var intIndex=0;intIndex<arrForms.length;intIndex++)
			{
			    // Get form web id.
				var strForm = arrForms[intIndex];

                try
                {					    
				    // Set server closed
				    Events_SetServerClosed(objClosed[strForm]);
				    
				    // Get form's data id.
					var strFormDataId=Data_GetDataId(strForm);
    				
    				// Remove minimized inline window - if needed.
					Forms_RemoveMinimizedInlineWindow(strFormDataId);

					Forms_CloseForm(strForm, true, objClosed[strForm]);
				}
				catch(e)
				{
				}
				
				// Clean window cahce cell
				Forms_UnregisterForm(strForm);

			}
			
			return true;
		}
	}
}
/// </method>

/// <method name="Forms_RemoveMinimizedInlineWindow" access="private">
/// <summary>
/// Remove minimized inline window - if needed.
/// </summary>
/// <param name="strFormDataId">The removed form data id.</param>
function Forms_RemoveMinimizedInlineWindow(strFormDataId)
{
    // Validate form data id.
    if(!Aux_IsNullOrEmpty(strFormDataId))
    {
        // If is inline windows remove form xml from data behined
	    if(mblnInlineWindows)
	    {					    
	        // Check if form is minimized.
	        if(Data_IsAttribute(strFormDataId,"WS","1"))
	        {
	            // Get the task bar box.
                var objTaskBarBox = Web_GetTaskBarBox();
                if(objTaskBarBox)
                {
                    // Get the taskbar items container.
                    var objTaskBarItems = Web_GetContextElementById(objTaskBarBox,"VWG_TaskBarItems");
                    if(objTaskBarItems)
                    {
                        // Get the form data id out of the element id.
                        var objTaskBarItemElement=Web_GetContextElementById(objTaskBarItems,"TBI_"+strFormDataId);
                        if(objTaskBarItemElement)
                        {
                            // Remove the recieved taskbar element from taskbar box.
                            objTaskBarItems.removeChild(objTaskBarItemElement);
                            
                            // Resizes all inline boxes.
                            Forms_ResizeInlineWindowsBoxes(window);
                            
                            // Resize inline maximized windows.
                            Forms_OnMainWindowResized(false);
                        }
                    }
                }                                                    
	        }
        }
    }
}
/// </method>

/// <method name="Forms_GetMdiParent" access="private">
/// <summary>
/// Checks whether the received form has an MDI parent.
/// </summary>
/// <param name="objForm">The form meta data.</param>
function Forms_GetMdiParent(objForm)
{
	var intMdiParent = null;
	
	// Validate recieved form node.
	if(objForm)
	{
	    // Try get mdi parent attribute.
        var strMdiParent = Xml_GetAttribute(objForm,"Attr.MdiParent","");
        if(!Aux_IsNullOrEmpty(strMdiParent))
        {
            // Parse mdi parent id.
            intMdiParent = parseInt(strMdiParent);
        }
	}
	
	return intMdiParent;
}
/// </method>

/// <method name="Forms_CreateForm" access="private">
/// <summary>
/// Creats a browser window object from the server form data.
/// </summary>
/// <param name="objWindow">The window.</param>
/// <param name="objFormNode">The form node.</param>
function Forms_CreateForm(objWindow,objFormNode)
{
	// window reference variable
	var objFormNodeWindow = null;
	
	// Get form id.
	var strGuid	= Xml_GetAttribute(objFormNode,"Attr.Id","");
	
	// get window details
	var strType				= Xml_GetAttribute(objFormNode,"Attr.Type","");
	var intBorderType       = parseInt(Xml_GetAttribute(objFormNode,"Attr.FormBorderStyle","0"),10);
	var intStartPos			= Xml_GetAttribute(objFormNode,"Attr.FormStartPosition","");
	var intLeft				= Xml_GetAttribute(objFormNode,"Attr.Left","");
	var blnIsWindowSized	= Xml_IsAttribute(objFormNode,"Attr.IsWindowSized","1");
	var intMdiParent    	= Forms_GetMdiParent(objFormNode);
	var intTop				= Xml_GetAttribute(objFormNode,"Attr.Top","");
	var intWidthOrig		= Xml_GetAttribute(objFormNode,"Attr.Width","0")*1;
	var intHeightOrig		= Xml_GetAttribute(objFormNode,"Attr.Height","0")*1;
	var blnResizable        = intBorderType==6 || intBorderType==4;
	var blnMaximize		    = blnResizable && Xml_IsAttribute(objFormNode,"Attr.Maximize","1");
	var blnMinimize 		= Xml_IsAttribute(objFormNode,"Attr.Minimize","1");
	var intWidth			= intWidthOrig + (blnIsWindowSized?0:mintFormsOffsetW);
	var intHeight			= intHeightOrig + (blnIsWindowSized?0:mintFormsOffsetH);
	var strTitle			= Xml_GetAttribute(objFormNode,"Attr.Text","",true);
	var intWindowState      = Xml_GetAttribute(objFormNode, "Attr.WindowState", "");    
    
    var objWindowsBox = Web_GetWindowsBox(intMdiParent);

	// if is a main window type
	if(strType=="MainWindow")
	{
		// return the current window
		return mobjFormsWindowById[Web_GetWebId(strGuid)] = window;
	}

	else
	{
	    // Check if a non-popup window is about to be open.
	    if(strType!="PopupWindow")
	    {
	        // Hide all popup windows.
	        Popups_HidePopups();
	    }
	    
		// If in inline windows mode or an mdi child window
		if(mblnInlineWindows || !Aux_IsNullOrEmpty(intMdiParent) || strType=="PopupWindow")
		{
		    if (!mblnFullScreenMode)
		    {
		        // Define default offset variables.
		        var intOffsetX = parseInt(document.body.clientWidth / 2, 10) - parseInt(intWidthOrig / 2, 10);
		        var intOffsetY = parseInt(document.body.clientHeight / 2, 10) - parseInt(intHeightOrig / 2, 10);
		    }

			// If inline window
			if(strType!="PopupWindow")
			{			    
			    // Get parent window by id
		        var objMdiParentWindow = Forms_GetWindowById(intMdiParent);

			    // Get document box
			    var objWindowBoxDocument = Web_IsWindow(objMdiParentWindow)?objMdiParentWindow.document:window.document;

			    if (!mblnFullScreenMode)
			    {
			        // Get inline window offset.
			        var objInlineOffset = Forms_GetInlineWindowOffset(objMdiParentWindow ? objWindowsBox : objWindowBoxDocument.body, objFormNode);

			        intOffsetX = objInlineOffset.left;
			        intOffsetY = objInlineOffset.top;
			    }
            
                // If a window box found
			    if(objWindowsBox && objWindowBoxDocument)
			    {
				    // Update form node attributes
				    Xml_SetAttribute(objFormNode,"Inline","1");
				    
                    if (!mblnFullScreenMode)
				    {
				        Xml_SetAttribute(objFormNode, "Attr.Left", intOffsetX);
				        Xml_SetAttribute(objFormNode, "Attr.Top", intOffsetY);
				        Xml_SetAttribute(objFormNode, "Attr.Resize", blnResizable ? "1" : "0");
				    }

				    // Get form html from node.
				    var strFormHtml = Controls_GetHtmlFromNode(objFormNode,strGuid);
				    if(!Aux_IsNullOrEmpty(strFormHtml))
                    {
                        // Create containing span
				        objFormNodeWindow = objWindowBoxDocument.createElement("DIV");

				        // Set window's html.
				        Web_SetInnerHtml(objFormNodeWindow, strFormHtml);				       

				        // Get first child which is the WinDIV.
				        objFormNodeWindow = objFormNodeWindow.firstChild;

						// Check if the document property is missing.
                        if(!objFormNodeWindow.document)
                        {
							// Set new element's document property.
                            objFormNodeWindow.document = objWindowBoxDocument;
                        }
					
                        // Find out and set modal owner id attribute on the inline window form
					    Forms_SetInlineWindowModalOwnerID(objFormNodeWindow);
		
				        // Append window to window container
					    objWindowsBox.appendChild(objFormNodeWindow);
				    
				        // Set top window focus.
				        Forms_ReorderInlineWindowsPosition(objFormNodeWindow,objWindowsBox);

				        if (!mblnFullScreenMode)
				        {
				            // Minimzed window state.
				            if (intWindowState == "1")
				            {
				                // Check if restored window state was "Maximized".
				                if (Data_IsAttribute(strGuid, "Attr.RestoredWindowState", "2"))
				                {
				                    // Maximize inline window.
				                    Forms_MaximizeInlineWindow(strGuid, null, window, false, false);
				                }

				                Forms_MinimizeInlineWindow(strGuid, window, false);
				            }
				            // Maximized window state.
				            else if (intWindowState == "2")
				            {
				                Forms_MaximizeInlineWindow(strGuid, null, window, false, false);
				            }

                            // Update raise OnMove event
			                Forms_OnMove(strGuid,intOffsetX,intOffsetY,true,false,false);
				        }                        
                    }
                }
			}
			else
			{
			    // Define a share focus flag.
			    var blnShareFocus = false;
			    var objPopupRect = {X:intOffsetX, Y:intOffsetY, Width: null, Height: null};

				// Get align to form data
				var strAlignToComponent = Xml_GetAttribute(objFormNode,"Attr.AlignTo","");
				if(!Aux_IsNullOrEmpty(strAlignToComponent))
				{
					// Get align type from form data
				    var strAlignType = objFormNode.getAttribute("Attr.AlignType");

					// Get positioned rect
				    var objAlignedPopupRect = Popups_GetAlignedRectangle(strAlignToComponent, strAlignType, intWidthOrig, intHeightOrig, parseInt(intTop, 10), parseInt(intLeft, 10));
				    if (objAlignedPopupRect)
				    {
				        objPopupRect = objAlignedPopupRect;
                    }
					
			        // Check whether popup sholud share focus with aligned component.
			        blnShareFocus = Xml_IsAttribute(objFormNode,"Attr.ShareFocus","1");
				}

				// Create a new popup form.
				objFormNodeWindow = Popups_CreatePopup(strGuid, strAlignToComponent, Popups_GetOwnerPopupId(objFormNode), objPopupRect.X, objPopupRect.Y, objPopupRect.Width, objPopupRect.Height, objFormNode, true, blnShareFocus, false);
			}
			
		    // Store window reference
			mobjFormsWindowById[Web_GetWebId(strGuid)] = objFormNodeWindow;

			// Set current active window
			Forms_SetActiveFormById(strGuid,true);
			
			// Load forms sub forms
            Forms_LoadForms(strGuid,window);	
		} 
		else
		{
			// if the parent window was found
			if(objWindow)
			{	    
				// switch window type
				switch(strType)
				{
					case "ModalWindow":
						// show the modaldialog dialog
						Forms_ShowModalDialog(objWindow,Web_GetAbsoluteUrl("[Skin.Path]Commons.Dialogs.Dialog.htm.wgx"),strGuid,Web_GetDialogArgs(intStartPos,intWindowState,intLeft,intTop,intWidth, intHeight, objWindow,blnResizable,blnMaximize,blnMinimize),strTitle,blnIsWindowSized,{X:intLeft,Y:intTop});
						break;
					case "ModalessWindow":			
						// show the modallessdialog dialog
						Forms_ShowModelessDialog(objWindow,Web_GetAbsoluteUrl("[Skin.Path]Commons.Dialogs.Dialog.htm.wgx"),strGuid,Web_GetDialogArgs(intStartPos,intWindowState,intLeft,intTop,intWidth, intHeight, objWindow,blnResizable,blnMaximize,blnMinimize),strTitle,blnIsWindowSized,{X:intLeft,Y:intTop});
						break;
				}
			}	
		}	
	}
}
/// </method>

/// <method name="Forms_GetInlineWindowOffset" access="private">
/// <summary>
/// Calculate window offset.
/// </summary>
/// <param name="objContainerElement">The container element</param>
/// <param name="objFormNode">The form node.</param>
function Forms_GetInlineWindowOffset(objContainerElement,objFormNode)
{
    var intWidth		= parseInt(Xml_GetAttribute(objFormNode,"Attr.Width","0"));
	var intHeight		= parseInt(Xml_GetAttribute(objFormNode,"Attr.Height","0"));
	var intLeft			= Xml_GetAttribute(objFormNode,"Attr.Left","");
    var intTop			= Xml_GetAttribute(objFormNode,"Attr.Top","");
    var intStartPos		= Xml_GetAttribute(objFormNode,"Attr.FormStartPosition","");
    
    //Get dialog's height and width offsets out of skin defeinitions.
    var objSize = Forms_GetInlineWindowSkinOffset(null,objFormNode);
    intHeight+= objSize.Height;
    intWidth+= objSize.Width;
	
    // Set offset to the middle of the recieved windows box element.
    var intOffsetX = parseInt(objContainerElement.clientWidth/2)-parseInt(intWidth/2,10) + objContainerElement.scrollLeft;
    var intOffsetY = parseInt(objContainerElement.clientHeight/2,10)-parseInt(intHeight/2,10) + objContainerElement.scrollTop;

    if(intStartPos==4) //if StartPos is center parent
    {
        // Get parent node
        var objParentFormData = objFormNode.parentNode;
        if(objParentFormData!=null)
        {
            // Check if parent is not main window and not MDI container.
            if(!Xml_IsAttribute(objParentFormData,"Attr.Type","MainWindow") && !Xml_IsAttribute(objParentFormData,"Attr.IsMdiContainer","1"))
            {
                //Get dialog's height and width offsets out of skin defeinitions.
                objSize = Forms_GetInlineWindowSkinOffset(null,objParentFormData);
                if(objSize)
                {
                    // Get parent's width.
                    var intParentWidth = parseInt(Xml_GetAttribute(objParentFormData,"Attr.Width",""));
                    if(!isNaN(intParentWidth))
                    {
                        // Add skin's width offset to parent's width.
                        intParentWidth += objSize.Width;
                        
                        // Calculate parent's center X position.
                        intOffsetX = parseInt(intParentWidth/2,10)-parseInt(intWidth/2,10);
                    }
                    
                    // Get parent's height.
                    var intParentHeight = parseInt(Xml_GetAttribute(objParentFormData,"Attr.Height",""));   
                    if(!isNaN(intParentHeight))
                    {
                        // Add skin's height offset to parent's height.
                        intParentHeight += objSize.Height;
                        
                        // Calculate parent's center Y position.
                        intOffsetY = parseInt(intParentHeight/2,10)-parseInt(intHeight/2,10);
                    }
                }
                
                // Get parent's left position.
                var intParentLeft = parseInt(Xml_GetAttribute(objParentFormData,"Attr.Left",""));
                if(!isNaN(intParentLeft))
                {
                    // Add parent's left position to return offset.
                    intOffsetX += intParentLeft;
                }
                
                // Get parent's top position.
                var intParentTop = parseInt(Xml_GetAttribute(objParentFormData,"Attr.Top",""));  
                if(!isNaN(intParentTop))
                {
                    // Add parent's top position to return offset.
                    intOffsetY += intParentTop;
                }
            }
        }
    }
    
    // In case that start position has been sent or in case of manual positioning with missing left or top cordinates.
    if(Aux_IsNullOrEmpty(intLeft) || Aux_IsNullOrEmpty(intTop) || !Aux_IsNullOrEmpty(intStartPos))
    {
        // Get valid position
        var objInlineRect = Web_GetWindowPosition(intOffsetX,intOffsetY,intWidth,intHeight,window);
        if(objInlineRect)
        {
            intOffsetX = objInlineRect.left;
            intOffsetY = objInlineRect.top; 
        }
    }
    
    // Check if form position has been sent (center parent or screen)
    if(Aux_IsNullOrEmpty(intStartPos))
    {
        // Assign the state's left cordinate - if not empty.
        if(!Aux_IsNullOrEmpty(intLeft))
        {
            intOffsetX=parseInt(intLeft);
        }
        
        // Assign the state's top cordinate - if not empty.
        if(!Aux_IsNullOrEmpty(intTop))
        {
            intOffsetY=parseInt(intTop);
        }
    }

	return {left:intOffsetX,top:intOffsetY};
}
/// </method>

/// <method name="" access="private">
/// <summary>
/// Sets window modal owner attribute, to track relative order between modal and modalless windows
/// for further ordering and separation by z-order inline windows positioning.
/// </summary>
/// <param name="objFormNodeWindow">Inline window HTML element to set attribute on it</param>
/// <remarks>
/// Inline Window Modal owner Id is and Id of modal inline window that was "active" when the window was created.
/// If the window(a) was created from modalless window(b) than window(a) inherits the owner id from
/// the window(b) and recursively.
/// </remarks>
function Forms_SetInlineWindowModalOwnerID(objFormNodeWindow)
{
    if(!Aux_IsNullOrEmpty(mstrActiveWindowGuid))
    {
        var cntModalOwnerIdAttribute = "vwgmodalownerid";
        
        // the value of attribute if will be determined
        var strModalOwnerId        = null;

        // the node of active window in data behind
        var objActiveWindowNode    = Data_GetNode(Data_GetDataId(mstrActiveWindowGuid));

        // the value is true if active window is modal one
        var blnIsActiveWindowModal   = objActiveWindowNode && Xml_IsAttribute(objActiveWindowNode,"Attr.Type","ModalWindow");
        
        // Get id of active modal window
        if(blnIsActiveWindowModal)
        {
            strModalOwnerId = Xml_GetAttribute(objActiveWindowNode,"Attr.Id");
        }
        // Active window is not modal - try to get Id from it's "modal owner" if defined
        else 
        {
            // the element of active inline window
            var objActiveWindowElement = Forms_GetWindowById(Data_GetDataId(mstrActiveWindowGuid));
            if(objActiveWindowElement)
            {
                strModalOwnerId = Web_GetAttribute(objActiveWindowElement, cntModalOwnerIdAttribute, true);
            }
        }

        // Set atttirbute on given inline window element
        if(!Aux_IsNullOrEmpty(strModalOwnerId))
        {
            Web_SetAttribute(objFormNodeWindow, cntModalOwnerIdAttribute, Web_GetWebId(strModalOwnerId));
        }
    }
}
/// </method>


/// <method name="Forms_RegisterForm" access="private">
/// <summary>
/// Registers a form.
/// </summary>
/// <param name="strGuid">The form ID.</param>
/// <param name="objWindow">The form browser window object.</param>
/// <param name="objParentWindow">The form parent browser window object.</param>
function Forms_RegisterForm(strGuid,objWindow,objParentWindow)
{
	var strFormGuid = Web_GetWebId(strGuid);
	
	// Register global window
	mobjFormsWindowById[strFormGuid] = objWindow;
	
	// Register owned window
	if(objParentWindow)
	{
		if(objParentWindow.mobjOwnedWindows)
		{
			objParentWindow.mobjOwnedWindows[strFormGuid] = objWindow;
		}
	}
}
/// </method>



/// <method name="Forms_UnregisterForm" access="private">
/// <summary>
/// Unegisters a form.
/// </summary>
/// <param name="strGuid">The form ID.</param>
/// <param name="objWindow">The form browser window object.</param>
/// <param name="objParentWindow">The form parent browser window object.</param>
function Forms_UnregisterForm(strGuid,objWindow,objParentWindow)
{
    // Get web id for the current form
	var strFormGuid = Web_GetWebId(strGuid);
	
	// Check if there is a valid window
	if(!objWindow)
	{
	    // Get window from id
	    objWindow = mobjFormsWindowById[strFormGuid];
	    if(objWindow)
	    {
	        // Get parent (protected to prevent closed windows error)
	        try{objParentWindow = objWindow.mobjParentWindow;}catch(e){}
	    }
	}
	
	// Unregister global window
	delete mobjFormsWindowById[strFormGuid];
	
	// Unregister owned window
	if(objParentWindow)
	{
	    // Loop all owned windows
		if(objParentWindow.mobjOwnedWindows)
		{
		    // delete owned windows
			delete objParentWindow.mobjOwnedWindows[strFormGuid];
		}
	}
}
/// </method>


/// <method name="Forms_LoadForms" access="private">
/// <summary>
/// Loads a the form's sub forms.
/// </summary>
/// <param name="strGuid">The form ID to load its child forms.</param>
/// <param name="objWindow">The containing browser window object.</param>
function Forms_LoadForms(strGuid,objWindow)
{
	var objOwnerForm = mobjApp.Data_GetNode(strGuid);
	if(objOwnerForm)
	{
		Forms_ProcessForms(objWindow,objOwnerForm);
	}
}
/// </method>

/// <method name="Forms_OnResize" access="private">
/// <summary>
/// Handles form resizing. 
/// </summary>
/// <param name="strGuid">The ID of the form to be resized.</param>
/// <param name="intWidth">The width to resize the form.</param>
/// <param name="intHeight">The height to resize the form.</param>
/// <param name="blnSuspendRaiseEvents">Suspend raise event.</param>
function Forms_OnResize(strGuid, intWidth, intHeight, blnSuspendRaiseEvents)
{
    var objFormNode = Data_GetNode(strGuid);

    // Update meta data so that window state changing will have updated values.
    Data_SetNodeAttribute(objFormNode, "Attr.Width", intWidth);
    Data_SetNodeAttribute(objFormNode, "Attr.Height", intHeight);
    
    // Remove restored sizes.
    Data_RemoveNodeAttribute(objFormNode, "Attr.RestoredWidth");
    Data_RemoveNodeAttribute(objFormNode, "Attr.RestoredHeight");
    
    // Create resize event
	var objEvent = Events_CreateEvent(strGuid,"Resize",null,true); 
	
	// Set event attributes
	Events_SetEventAttribute(objEvent,"Width",intWidth.toString());
	Events_SetEventAttribute(objEvent,"Height",intHeight.toString());
	
	// Raise event if critical
	if(!blnSuspendRaiseEvents)
	{
	    Events_RaiseEvents();
	}

	   Events_ProcessClientEvent(objEvent);
}
/// </method>

/// <method name="Forms_OnMove" access="private">
/// <summary>
/// Handles form moving. 
/// </summary>
/// <param name="strGuid">The ID of the form to be moved.</param>
/// <param name="intLeft">The left value to move form to.</param>
/// <param name="intTop">The top value to move form to.</param>
/// <param name="blnUniqueEvent">Whether to create a unique move event or not.</param>
/// <param name="blnClosing">A flag indicating form is closing.</param>
/// <param name="blnSuspendRaiseEvents">Whether to suspend raise events or not.</param>
function Forms_OnMove(strGuid,intLeft,intTop,blnUniqueEvent,blnClosing,blnSuspendRaiseEvents)
{
    // Get form node
    var objNode = Data_GetNode(strGuid);

    // Update meta data so that window state changing will have updated values.
    Data_SetNodeAttribute(objNode, "Attr.Left", intLeft);
    Data_SetNodeAttribute(objNode, "Attr.Top", intTop);
    
    // Remove restored positions.
    Data_RemoveNodeAttribute(objNode, "Attr.RestoredLeft");
    Data_RemoveNodeAttribute(objNode, "Attr.RestoredTop");
    
	// Create resize event
	var objEvent = Events_CreateEvent(strGuid,"Move",null,blnUniqueEvent); 
	
	// Set event attributes
	Events_SetEventAttribute(objEvent,"Left",(intLeft+mintFormsOffsetX).toString());
	Events_SetEventAttribute(objEvent,"Top",(intTop+mintFormsOffsetY).toString());
	
	// Raise event if critical
	if (!blnSuspendRaiseEvents && !blnClosing && Data_IsCriticalEvent(objNode, "Event.LocationChange", true))
	{
	    Events_RaiseEvents();
    }

	Events_ProcessClientEvent(objEvent);
}
/// </method>

/// <method name="Forms_UnloadForm" access="private">
/// <summary>
/// Unloads an open window.
/// </summary>
/// <param name="strGuid">The ID of the form to be unloaded.</param>
function Forms_UnloadForm(strGuid, blnServerSource, blnPreventNavigationEffects)
{  
    // Validate received 
    if(!Aux_IsNullOrEmpty(strGuid))
    {
	    // Get a data id.
        strGuid = Data_GetDataId(strGuid);        
    	
	    // Clear the recieved window's error providers.
        Web_ClearWindowErrorProviders(strGuid);
    	
	    // Unregister form
	    var objWindow = Forms_GetWindowById(strGuid);
	    if(objWindow)
	    {	
		    Events_UnloadWindow(objWindow);
		    
		    var objParentWindow = null;
		    
	        try
	        {
	            // Try getting a parent window.
	            objParentWindow = objWindow.mobjParentWindow;
	        }
	        catch(e){}
		    
		    Forms_UnregisterForm(strGuid,objWindow,objParentWindow);
	    }
	    else
	    {
	        // Delete current window register
	        Forms_UnregisterForm(strGuid);
	    }
    	
	    // Define a raise events flag.
	    var blnRaiseEevnts = !blnServerSource;
    	
	    // If in inline windos mode.
        if(mblnInlineWindows)
        {   
            // Get activate inline window.
            var strActiveWindow = Forms_GetActivatedInlineWindow(objWindow);

            // Delete form node
            Data_DeleteNode(strGuid);            

            // Validate new active inline window.
            if (!Aux_IsNullOrEmpty(strActiveWindow))
            {
                // Activate new window.
                Forms_SetActiveFormById(strActiveWindow, blnServerSource, blnPreventNavigationEffects);
            }
        }
        else 
        {
            // Delete form node
	        Data_DeleteNode(strGuid);
	        
	        // Check if recieved window is the active window.
            if(objWindow==Web_GetActiveWindow())
            {
                // Activate next real window from cach.
                Web_SetActiveWindow(Forms_GetActivatedWindow(Web_GetWebId(strGuid)));
            }
        }
        
        // Remove unloaded form from focus cache.
        Focus_RemoveFormFocusElement(strGuid);
	}
}
/// </method>

/// <method name="Forms_OnMainWindowResized" access="private">
/// <summary>
/// 
/// </summary>
function Forms_OnMainWindowResized(blnUpdateServer)
{   
    // Hide all popup windows.
	Popups_HidePopups();
	
    // Ensure inline windows mode.
    if(mblnInlineWindows)
    {
        // Get the window's available content size.
        var objSize = Web_GetMainWindowAvailableSize(mobjApp.mintFormsOffsetW,mobjApp.mintFormsOffsetH);
        if(objSize)
        {	
            // Resize maximized inline windows.
	        Forms_ResizeMaximizedInlineWindows(null,objSize.Width,objSize.Height,blnUpdateServer);
	    }

	    // Resize maximized mdi child windows.
        Forms_ResizeMaximizedMdiChildWindows(Data_GetDataId(mstrWindowGuid));
	}
}
/// </method>

/// <method name="Forms_ResizeInlineWindowsBoxes" access="private">
/// <summary>
/// Resizes all inline boxes.
/// </summary>
function Forms_ResizeInlineWindowsBoxes(objMainWindow)
{   
    // Ensure inline windows mode.
    if(mblnInlineWindows)
    {
        // Initialize taskbar.
        Common_InitializeInlineWindowsTaskBar(objMainWindow);
        
        // Get the window's available content size.
        var objSize = Web_GetMainWindowAvailableSize(mobjApp.mintFormsOffsetW,mobjApp.mintFormsOffsetH);
        if(objSize)
        {	
	        // Resize the modal window box.
            Forms_ResizeInlineWindowsModalBoxes(objSize.Width,objSize.Height); 
	    }
	}
}
/// </method>

/// <method name="Forms_Resize" access="private">
/// <summary>
/// Resizes main form.
/// </summary>
function Forms_Resize()
{	
    // Resize inline maximized windows.
    Forms_OnMainWindowResized(true);
    
    // Resizes all inline boxes.
    Forms_ResizeInlineWindowsBoxes(window);
    
    // Emulate the resize event for all child nodes.
    Forms_EmulateResize();
    
    // Clear resize interval.    
    Web_ClearInterval(mintMainFormResizeHandle, window);
	
    // Execute the Forms_ResizeEnd with interval of 40 miliseconds.
    mintMainFormResizeHandle = Web_SetInterval("Forms_ResizeEnd()",500,window);
}
/// </method>

/// <method name="Forms_ResizeEnd" access="private">
/// <summary>
/// Resizes main form.
/// </summary>
function Forms_ResizeEnd()
{
    var blnRaiseEvents = false;

    // Clear resize interval.
    Web_ClearInterval(mintMainFormResizeHandle, window);

    // Validate main window data id.
    if (!Aux_IsNullOrEmpty(mstrWindowGuid))
    {
        // Get form data id
        var strFormDataId = Data_GetDataId(mstrWindowGuid);

        //Get window data node
        var objWindowNode = Data_GetNode(strFormDataId);

        // Raise OnMove event for main window - in IE only (supports screenLeft and screenTop)
        if (mcntIsIE)
        {
            if (!Data_IsNodeAttribute(objWindowNode, "Attr.Left", window.screenLeft) ||
                !Data_IsNodeAttribute(objWindowNode, "Attr.Top", window.screenTop))
            {
                mobjApp.Forms_OnMove(mstrWindowGuid, window.screenLeft, window.screenTop, true, true, true);

                blnRaiseEvents = mobjApp.Data_IsCriticalEvent(mstrWindowGuid, "Event.LocationChange");
            }
        }

        // Get the window's available content size.
        var objSize = Web_GetMainWindowAvailableSize(mobjApp.mintFormsOffsetW, mobjApp.mintFormsOffsetH);
        if (objSize)
        {
            if (!Data_IsNodeAttribute(objWindowNode, "Attr.Width", objSize.Width) ||
                !Data_IsNodeAttribute(objWindowNode, "Attr.Height", objSize.Height))
            {
                // Raise OnResize event for main window.
                mobjApp.Forms_OnResize(strFormDataId, objSize.Width, objSize.Height, true);

                blnRaiseEvents = true;
            }
        }
    }

    // Raise event if needed.
    if (blnRaiseEvents)
    {
        Events_RaiseEvents();
    }
}
/// </method>

/// <method name="Forms_UnloadMainForm" access="private">
/// <summary>
/// Unloads an main form.
/// </summary>
function Forms_UnloadMainForm()
{
	// If not is server close
	if(!Events_IsServerClosed(window))
	{
	    // Loop all form ids.
	    for(var strFormId in mobjFormsWindowById)
	    {
	        // Check that current form is not the main window form.
	        if(strFormId!=mstrWindowGuid)
	        {
	            // Get current window.
	            var objCurrentWindow = mobjFormsWindowById[strFormId];
    	        
    	        // Check that current window is a real window.
	            if(Web_IsWindow(objCurrentWindow))
	            {
	                // Flag that form unloading should not be performed on current window.
	                objCurrentWindow.mblnPerformFormUnloading = false;
	                
	                // Close current window.
	                Forms_CloseWindowElement(objCurrentWindow);
	            }
	        }
	    }
	    
		var strBeforeUnloadMessage = Data_GetAttribute(Data_GetDataId(mstrWindowGuid),"Attr.BeforeUnloadMessage","");
        if(!Aux_IsNullOrEmpty(strBeforeUnloadMessage))
        {
            return strBeforeUnloadMessage;
        }	
	}
}
/// </method>

/// <method name="Forms_SetFocus" access="private">
/// <summary>
/// Sets focus to a given form.
/// </summary>
/// <param name="strGuid">The ID of the form to recieve focus.</param>
function Forms_SetFocus(strDataId)
{
	if(mblnInlineWindows)
    {
        // Bring inline window to top.
        Forms_BringWindowToTop(strDataId);
    }
    else
    {
        // Get none inline window.
        var objWindow = mobjFormsWindowById[Web_GetWebId(strDataId)];
        if(objWindow)
        {
            // Set focus on window.
            Web_SetFocus(objWindow);
        }
    }
}
/// </method>

/// <method name="Forms_ShowModalDialog" access="private">
/// <summary>
/// Opens a modal dialog 
/// </summary>
/// <param name="objWindow"></param>
/// <param name="strUrl"></param>
/// <param name="strGuid"></param>
/// <param name="strFeatures"></param>
/// <param name="strTitle"></param>
/// <param name="blnIsWindowSized"></param>
/// <param name="objPosition"></param>
function Forms_ShowModalDialog(objWindow,strUrl,strGuid,strFeatures,strTitle,blnIsWindowSized,objPosition)
{
	// If is IE
	if(mcntIsIE)
	{
	    // Set the new dialog's initialization status to not initialized.
	    Forms_SetDialogInitializationStatus(strGuid,false);
	    
		objWindow.showModalDialog(Web_GetAbsoluteUrl("[Skin.Path]Commons.Dialogs.Dialog.htm.wgx"),{mobjApp:mobjApp,mstrWindowGuid:strGuid,mobjParentWindow:objWindow,Title:strTitle,mblnIsModeless:false,blnIsWindowSized:blnIsWindowSized,objPosition:objPosition},strFeatures);
	}
	else
	{
		objWindow.open(Web_GetAbsoluteUrl("[Skin.Path]Commons.Dialogs.Dialog.htm.wgx"), strGuid , strFeatures + ",modal=yes,dialog=yes");
	}
}
/// </method>

/// <method name="Forms_ShowModelessDialog" access="private">
/// <summary>
/// Opens a modeless dialog.
/// </summary>
/// <param name="objWindow"></param>
/// <param name="strUrl"></param>
/// <param name="strGuid"></param>
/// <param name="strFeatures"></param>
/// <param name="strTitle"></param>
/// <param name="blnIsWindowSized"></param>
/// <param name="objPosition"></param>
function Forms_ShowModelessDialog(objWindow,strUrl,strGuid,strFeatures,strTitle,blnIsWindowSized,objPosition)
{
	// If is IE
	if(mcntIsIE)
	{   
	    // Set the new dialog's initialization status to not initialized.
	    Forms_SetDialogInitializationStatus(strGuid,false);	    
	    
		mobjFormsWindowById[Web_GetWebId(strGuid)] = objWindow.showModelessDialog(Web_GetAbsoluteUrl("[Skin.Path]Commons.Dialogs.Dialog.htm.wgx"),{mobjApp:mobjApp,mstrWindowGuid:strGuid,mobjParentWindow:objWindow,Title:strTitle,mblnIsModeless:true,blnIsWindowSized:blnIsWindowSized,objPosition:objPosition},strFeatures);
	}
	else
	{
		mobjFormsWindowById[Web_GetWebId(strGuid)] = objWindow.open(Web_GetAbsoluteUrl("[Skin.Path]Commons.Dialogs.Dialog.htm.wgx"), strGuid , strFeatures + ",modal=yes");
	}
}
/// </method>

/// <method name="Forms_BringWindowToTop" access="private">
/// <summary>
/// Brings the inline window to the top
/// </summary>
function Forms_BringWindowToTop(strDataID)
{
    if(!Aux_IsNullOrEmpty(strDataID))
    {
        var objWindow = mobjFormsWindowById[Web_GetWebId(strDataID)];
	    if(objWindow)
	    {
	        // Check if recieved window is not a popup.
            if(!Popups_IsPopup(objWindow))
            {
                if (mblnFullScreenMode && objWindow === mobjApp)
                {
                    objWindow = Web_GetElementById(Web_GetWebId(strDataId), mobjApp);
                }
    	        
                // Check if recieved window is inline window.
	            if(Forms_IsInlineWindow(objWindow))
	            {
	                // Reorder inline windows positions.
	                Forms_ReorderInlineWindowsPosition(objWindow,Web_GetWindowsBox(Data_GetAttribute(strDataID,"Attr.MdiParent","")));
	            }
                else if(Web_IsWindow(objWindow))
                {
                    objWindow.focus();
                }
            }
	    }
    }   
}
/// </method>

/// <method name="Forms_GetInlineWindows" access="private">
/// <summary>
/// Gets an array of inline windows
/// </summary>
function Forms_GetInlineWindows(objActiveWindow,objWindowsBox)
{
    // Define an empty windows array.
    var arrWindows = [];
    
    // In case of a null windows box and a valid active window.
    if(!objWindowsBox && objActiveWindow)
    {
        // Get windows box as for active element.
        objWindowsBox = Web_GetParent(objActiveWindow);
    }
    
    // Validate windows box.
	if(objWindowsBox)
	{	    
	    // Loop all child windows
        for(var intIndex=0;intIndex<objWindowsBox.childNodes.length;intIndex++)
        {
            // get current window
            var objCurrentWindow = objWindowsBox.childNodes[intIndex];

            if (!mblnFullScreenMode)
            {
                // If is a visible inline window which sholud not be exluded.
                if (Forms_IsInlineWindow(objCurrentWindow) &&
                    objCurrentWindow.style.display != "none" &&
                    objCurrentWindow != objActiveWindow)
                {
                    arrWindows.push(objCurrentWindow);
                }
            }
            else
            {
                // In full screen mode, also add invisible forms.
                if (objCurrentWindow != objActiveWindow)
                {
                    arrWindows.push(objCurrentWindow);
                }
            }
        }
    }
    
    return arrWindows;
}
/// </method>

function Forms_GetWindowIds()
{
    var arrWindowIds = [];
    
    if (mobjFormsWindowById)
    {
        for (windowId in mobjFormsWindowById)
        {
            if (mobjFormsWindowById.hasOwnProperty(windowId))
            {
                arrWindowIds.push(Data_GetDataId(windowId));
            }
        }
    }

    return arrWindowIds;
}

/// <method name="Forms_IsModalWindow" access="private">
/// <summary>
/// Validates whether provided form is modal.
/// </summary>
function Forms_IsModalWindow(strFormId)
{
    if (!Aux_IsNullOrEmpty(strFormId))
    {
        var strDataId = Data_GetDataId(strFormId);
        
        if (!Aux_IsNullOrEmpty(strDataId))
        {
            var objNode = Data_GetNode(strDataId);
            
            if (objNode)
            {
                return Xml_IsAttribute(objNode, "Attr.Type", "ModalWindow");
            }
        }
    }

    return false;
}
/// </method>

/// <method name="Forms_ReorderInlineWindowsPosition" access="private">
/// <summary>
/// Sets a top index to a given window
/// </summary>
function Forms_ReorderInlineWindowsPosition(objActiveWindow,objWindowsBox)
{
    // Define an empty mdi parent id.
    var strActiveWindowMdiParentId = "";
    
    if(objActiveWindow)
    {
        // Get active window id.
        var strActiveWindowId = Data_GetDataId(Web_GetAttribute(objActiveWindow, "vwgguid",true));
        if(!Aux_IsNullOrEmpty(strActiveWindowId))
        {
            // Try getting the top window mdi parent.
            strActiveWindowMdiParentId = Data_GetAttribute(strActiveWindowId,"Attr.MdiParent","");
        }
    }
	
    if(objWindowsBox)
    {
        // Get the windows box z-index.
        var intWindowsBoxZindex = parseInt(objWindowsBox.style.zIndex);
        
        // Get all inline windows but the current
        var arrWindows = Forms_GetInlineWindows(objActiveWindow,objWindowsBox);
              
        // Sort the current windows by z index
        arrWindows.sort(Forms_ReorderInlineWindowsPositionSorter);
        
        // Add current window to end
        if(objActiveWindow)
        {
            arrWindows.push(objActiveWindow);
        }
        
        // Define a last masked modal window index.
        var intLastMaskedModalWindowIndex = -1;
        
        // Define a last transparent modal window index.
        var intLastTransparentModalWindowIndex = -1;
        
        // Define a window index.
        var intIndex=arrWindows.length-1;
        
        // Loop all child windows backwards while modal indexes are not found.
        while(intIndex>=0 && (intLastMaskedModalWindowIndex==-1 || intLastTransparentModalWindowIndex==-1))
        {
            // Get current inline window.
            var objInlineWindow = arrWindows[intIndex];
            
            // Check if current window in a modal window.
            if(Forms_IsModalInlineWindow(objInlineWindow))
            {
                // Get inline window's data id.
                var strFormDataId = Web_GetAttribute(objInlineWindow,"vwgguid","");
                if(!Aux_IsNullOrEmpty(strFormDataId))
                {
                    // Check if current modal inline window requires masked modality.
                    if(!Data_IsAttribute(strFormDataId,"Attr.ShowModalMask","0"))
                    {
                        // Check if masked modal window index has been preserved before.
                        if(intLastMaskedModalWindowIndex==-1)
                        {
                            // Preserve masked modal window index.
                            intLastMaskedModalWindowIndex=intIndex;
                        }
                    }
                    // Check if transparent modal window index has been preserved before.
                    else if(intLastTransparentModalWindowIndex==-1)
                    {
                        // Preserve transparent modal window index.
                        intLastTransparentModalWindowIndex=intIndex;
                    }
                }
            }
            
            // Decrease index.
            intIndex--;
        }
        
        // Check if a masked modal windows box is needed.
        if(intLastMaskedModalWindowIndex>=0)
        {
            // Merge inline windows array with the masked modal window box.
            arrWindows = Forms_GetMergedInlineWindows(arrWindows,intLastMaskedModalWindowIndex,true);
            
            // In case that exist a valid transparent modal window index and it is bigger then the masked modal window index,
            // increase the transparent modal window index by one so it will match the new array dimensions.
            if(intLastTransparentModalWindowIndex>=0 && intLastTransparentModalWindowIndex>intLastMaskedModalWindowIndex)
            {
                // Increase the transparent modal window index by one.
                intLastTransparentModalWindowIndex++;
            }
        }
        
        // Check if a transparent modal windows box is needed.
        if(intLastTransparentModalWindowIndex>=0)
        {
            // Merge inline windows array with the transparent modal window box.
            arrWindows = Forms_GetMergedInlineWindows(arrWindows,intLastTransparentModalWindowIndex,false);
        }
        
        // Loop all child windows
        for(var intIndex=0;intIndex<arrWindows.length;intIndex++)
        {
            arrWindows[intIndex].style.zIndex = (intIndex+intWindowsBoxZindex+1);
        }
        
		// Check if recived windows box is Main window
        if(objWindowsBox==Web_GetWindowsBox())
        {
            // Initialize the masked modal window box.
            Forms_InitializeModalWindowBox(intLastMaskedModalWindowIndex>=0 || mblnFullScreenMode, true, objWindowsBox);
            
            // Initialize the transparent modal window box.
            Forms_InitializeModalWindowBox(intLastTransparentModalWindowIndex >= 0 || mblnFullScreenMode, false, objWindowsBox);
        }
    }
}
/// </method>   

/// <method name="Forms_ReorderInlineWindowsPositionSorter" access="private">
/// <summary>
/// Sorts the inline windows
/// </summary>
function Forms_ReorderInlineWindowsPositionSorter(objWindowA,objWindowB)
{
    var intIndexA = objWindowA.style.zIndex;
    var intIndexB = objWindowB.style.zIndex;
    return intIndexA>intIndexB?+1:intIndexA<intIndexB?-1:0;
}
/// </method>

/// <method name="Forms_TriggerFocusElementBlurHandler" access="private">
/// <summary>
/// Triggers the focus element's blur handler.
/// </summary>
function Forms_TriggerFocusElementBlurHandler()
{
    // Get current focus element id.
    var strFocusElementDataId = Focus_GetFocusElementDataId();
    if(!Aux_IsNullOrEmpty(strFocusElementDataId))
    {
        // Get current focus element.
        var objFocusElement = Controls_GetFocusElementByDataId(strFocusElementDataId);
        if(objFocusElement)
        {
            // Triger the "blur" and "focusout" handlers of the focus element.
            $(objFocusElement).triggerHandler("blur");
            $(objFocusElement).triggerHandler("focusout");
        }
    }
}
/// </method>

/// <method name="Forms_CloseInlineWindow" access="private">
/// <summary>
/// Closes an inline window
/// </summary>
function Forms_CloseInlineWindow(strGuid,objEvent,objMainWindow)
{
    // Triggers the focus element's blur handler.
    Forms_TriggerFocusElementBlurHandler();
    
	// The HTML id of closed inline window
	var strWebGuid = Web_GetWebID(strGuid);
	var objWindow = mobjFormsWindowById[strWebGuid];
	if(objWindow)
	{
	    // Set the main window's value if it came null - should happen when inline window is being closed programmatically.
	    if(!objMainWindow)
	    {
	        objMainWindow = window;
	    }

        // Only if the closed window is Modal - check that closed window has "owned" windows,
        // and update them, to be owned by the "owner" of closed window. The attribute was set during
        // inline window creation

        // the node of deleted window in data behind to get the window modality
        var objWindowNode = Data_GetNode(Data_GetDataId(strGuid));
        if(objWindowNode && Xml_IsAttribute(objWindowNode,"Attr.Type","ModalWindow"))
        {
            // Get all inline windows.
            var cntModalOwnerIdAttribute = "vwgmodalownerid";
            
            // DIV elements of inline windows
            var arrWindows               = Forms_GetInlineWindows(objWindow);
            var strParentModalOwnerId    = Web_GetAttribute(objWindow, cntModalOwnerIdAttribute);
            
            // if no available parent, empty the parent of windows
            if(Aux_IsNullOrEmpty(strParentModalOwnerId))
            {
                strParentModalOwnerId = "";
            }
            
            for(var Index = 0; Index < arrWindows.length; Index++)
            {
                // update if the window belong to modal window with strWebGuid
                if(Web_IsAttribute(arrWindows[Index], cntModalOwnerIdAttribute, strWebGuid))
                {
                    Web_SetAttribute(arrWindows[Index], cntModalOwnerIdAttribute, strParentModalOwnerId);
                }
            }
        }

        Forms_CloseForm(strGuid, false, objWindow);
	}
}
/// </method>

/// <method name="Forms_RestoreTaskBarItem" access="private">
/// <summary>
/// 
/// </summary>
function Forms_RestoreTaskBarItem(objWindow,strTaskBarItemElementId,blnClientSource)
{
    // Validate recived arguments.
	if (objWindow && !Aux_IsNullOrEmpty(strTaskBarItemElementId))
    {
        // Get the task bar box.
        var objTaskBarBox = Web_GetTaskBarBox();
        if(objTaskBarBox)
        {
			//Get task bar element by id
        	var objTaskBarItemElement = Web_GetContextElementById(objTaskBarBox, strTaskBarItemElementId);
        	if (objTaskBarItemElement)
        	{
				// Get the taskbar items container.
				var objTaskBarItems = Web_GetContextElementById(objTaskBarBox,"VWG_TaskBarItems");
				if(objTaskBarItems)
				{
					// Get the form data id out of the element id.
					var strFormDataId = objTaskBarItemElement.id.replace("TBI_","");
					if(!Aux_IsNullOrEmpty(strFormDataId))
					{
						// Get the form element by the form data id.
						var objFormElement = Forms_GetWindowById(strFormDataId);
						if(objFormElement)
						{   
							// Gets the modal window box.
							var objModalWindowBox = Web_GetModalWindowBox(!Data_IsAttribute(strFormDataId,"Attr.ShowModalMask","0"));
							if(objModalWindowBox)
							{
								// Check that the modal window box is hidden or located under the handled form.
								if( objModalWindowBox.style.display=="none" || 
									objModalWindowBox.style.zIndex<objFormElement.style.zIndex)
								{
									// Try to get restored window state before the form was minimized
									var strRestoredWindowState = Data_GetAttribute(strFormDataId,"Attr.RestoredWindowState","0");
                                
									// Check if restoring to normal state.
									if(strRestoredWindowState=="0")
									{
										// Get restored data.
										var objFormRestoredData = Forms_GetFormRestoredData(strFormDataId);
                                    
										// Get dialog's height and width offsets out of skin defeinitions.
										var objSkinOffsetSize = Forms_GetInlineWindowSkinOffset(strFormDataId);
                                    
										// Set form element's restored size (sumed with skin offset size).
										objFormElement.style.width = (Number(objFormRestoredData.Width) + objSkinOffsetSize.Width) + "px"; ;
										objFormElement.style.height = (Number(objFormRestoredData.Height) + objSkinOffsetSize.Height) + "px"; ;
                                    
										// Set form element's restored location.
										objFormElement.style.top = objFormRestoredData.Top + "px";
										objFormElement.style.left = objFormRestoredData.Left + "px";
									}
                                
									// Display the form element.
									objFormElement.style.display = "block";
                                
									// Remove the recieved taskbar element from taskbar box.
									objTaskBarItems.removeChild(objTaskBarItemElement);

									// Update form's window state with restored window state.
									Data_SetAttribute(strFormDataId,"Attr.WindowState",strRestoredWindowState);
                                
									// Resizes all inline boxes.
									Forms_ResizeInlineWindowsBoxes(objWindow);
                                
									// Resize inline maximized windows.
									Forms_OnMainWindowResized(false);

									// Update form's control box element.
									Forms_UpdateFormControlBoxElement(strFormDataId);

									if (blnClientSource)
									{
										// Create a window state change event.
										var objVwgEvent = Events_CreateEvent(strFormDataId, "WindowStateChange", null, true); 
										
										// Set the window state attribute value as for the restored window state (if one exists).
										Events_SetEventAttribute(objVwgEvent, "Attr.WindowState", strRestoredWindowState);								
									}    
                                
									// Check if restored inline window in modal.
									if(Forms_IsModalInlineWindow(objFormElement))
									{
										// Set focus to the active window's (which is the restored inline window) focus element.
										Web_SetFocusByDataId(Focus_GetFocusElementDataId());
									}
									else
									{
										// Set the restored form as the active form.
										Forms_SetActiveFormById(strFormDataId, !blnClientSource);
									}

									if (blnClientSource)
									{
										// Raise events.
										Events_RaiseEvents();
									}									
                                
									//Bring To Top InlineWindow
									Forms_BringWindowToTop(strFormDataId);
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

/// <method name="Forms_GetInlineWindowSkinOffset" access="private">
/// <summary>
/// Get dialog's height and width offsets out of FormBorderStyle property and skin defeinitions.
/// </summary>
function Forms_GetInlineWindowSkinOffset(strGuid,objFormNode)
{
    var intWidth = 0;
    var intHeight = 0;
    
    if(!Aux_IsNullOrEmpty(strGuid) || objFormNode)
    {
        var strFormBorderStyle = null;
        
        // Get the form's border style attribute.
        if(objFormNode)
        {
            strFormBorderStyle = Xml_GetAttribute(objFormNode, "Attr.FormBorderStyle", "");
        }
        else
        {
            strFormBorderStyle = Data_GetAttribute(strGuid, "Attr.FormBorderStyle", "");
        }
        
        if(!Aux_IsNullOrEmpty(strFormBorderStyle))
        {
            switch(strFormBorderStyle)
            {
                case "0":
                    //Non window type
                    break;
                case "5":
                case "6":
                    // tool's window type
                    intWidth  = Number([Skin.ToolWindowWidthOffset]);
                    intHeight = Number([Skin.ToolWindowHeightOffset]);
                    break;
                default:
                    // dialog's window type
                    intWidth  = Number([Skin.DialogWindowWidthOffset]);
                    intHeight = Number([Skin.DialogWindowHeightOffset]);
                    break;
            }
        }
    }
    
    // Return offset size
    return {Width:intWidth,Height:intHeight};
}
/// </method>

/// <method name="Forms_GetFormRestoredData" access="private">
/// <summary>
/// 
/// </summary>
function Forms_GetFormRestoredData(strGuid)
{
    // Get form node
    var objNode = Data_GetNode(strGuid);

    // Try getting form's restored width.
    var strRestoredWidth = Data_GetNodeAttribute(objNode, "Attr.RestoredWidth", "");
    if(Aux_IsNullOrEmpty(strRestoredWidth))
    {
        // Try getting form's width.
        strRestoredWidth = Data_GetNodeAttribute(objNode, "Attr.Width", "0");
    }

    // Try getting form's restored height.
    var strRestoredHeight = Data_GetNodeAttribute(objNode, "Attr.RestoredHeight", "");
    if(Aux_IsNullOrEmpty(strRestoredHeight))
    {
        // Try getting form's height.
        strRestoredHeight = Data_GetNodeAttribute(objNode, "Attr.Height", "0");
    }

    // Try getting form's restored left.        
    var strRestoredLeft = Data_GetNodeAttribute(objNode, "Attr.RestoredLeft", "");
    if(Aux_IsNullOrEmpty(strRestoredLeft))
    {
        // Try getting form's left.
        strRestoredLeft = Data_GetNodeAttribute(objNode, "Attr.Left", "0");
    }

    // Try getting form's restored top.        
    var strRestoredTop = Data_GetNodeAttribute(objNode, "Attr.RestoredTop", "");
    if(Aux_IsNullOrEmpty(strRestoredTop))
    {
        // Try getting form's top.        
        strRestoredTop = Data_GetNodeAttribute(objNode, "Attr.Top", "0");
    }
    
    // Return restored data.
    return {Width:strRestoredWidth,Height:strRestoredHeight,Left:strRestoredLeft,Top:strRestoredTop};
}
/// </method>

/// <method name="Forms_MinimizeMdiWindow" access="private">
/// <summary>
/// Minimizes an MDI window.
/// Enum Values: Maximized = 2; Minimized = 1; Normal = 0
/// </summary>
function Forms_MinimizeMdiWindow(strGuid,objMainWindow,objWrapperElement,blnClientSource)
{   
    // Validate recieved arguments.
	if(objWrapperElement && objMainWindow && !Aux_IsNullOrEmpty(strGuid))
	{   
        // Get the window's state.
        var strWindowState = Data_GetAttribute(strGuid,"Attr.WindowState","0");
        
        //Get dialog's height and width offsets out of skin defeinitions.
        var objSize = Forms_GetInlineWindowSkinOffset(strGuid);
        
        // Get restored data.
        var objFormRestoredData = Forms_GetFormRestoredData(strGuid);
        
        // Try getting form's restored width.
        var strWindowWidth = objFormRestoredData.Width;
        
        // Add width offset to window width.
        strWindowWidth = Number(strWindowWidth)+objSize.Width;
        
        // Try getting form's restored height.
        var strWindowHeight = objFormRestoredData.Height;

        // Add height offset to window height.
        strWindowHeight = Number(strWindowHeight)+objSize.Height;
                
        // Define a display css value for form's body.
        var strDisplay = "block";
        
        // Check window state.
        if(!blnClientSource || strWindowState != "1")
        {       
            // Set a minimized size.
            strWindowWidth  = "[Skin.MinimizedMdiFormWidth]";
            strWindowHeight = "[Skin.MinimizedMdiFormHeight]";
            
            // Set display css value to none.
            strDisplay = "none";
        }
        
        // Set the form's wrapper new size. 
        objWrapperElement.style.height = strWindowHeight + "px";
        objWrapperElement.style.width = strWindowWidth  + "px";

        // Set the form's wrapper new location. 
        objWrapperElement.style.top = Number(objFormRestoredData.Top) + "px";
        objWrapperElement.style.left = Number(objFormRestoredData.Left) + "px";
        
        // Get form's body element.
        var objFormBodyElement = Web_GetElementByDataId(strGuid, objMainWindow);
        if(objFormBodyElement)
        {
            // Set form's body display css value.
            objFormBodyElement.style.display=strDisplay;
        }
        
        if(blnClientSource)
        {
            // Update form's control box element.
            Forms_UpdateFormControlBoxElement(strGuid);
        
            // Create a window state change event.
            var objVwgEvent = Events_CreateEvent(strGuid,"WindowStateChange",null,true); 
            Events_SetEventAttribute(objVwgEvent,"Attr.WindowState",strWindowState=="1"?"0":"1");

            // Raise event
            Events_RaiseEvents();           
	    }
    }
}
/// </method>

/// <method name="Forms_CreateInlineWindowTaskBarItem" access="private">
/// <summary>
/// Creates task bar item.
/// </summary>
function Forms_CreateInlineWindowTaskBarItem(strGuid,objFormNode,objMainWindow)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid) && objFormNode && objMainWindow)
    {
        // Build a task bar item id.
        var strTaskBarItemId = "TBI_"+strGuid;
        
        // Check if a taskbar item does not exist for the handled form.
        if(!Web_GetElementById(strTaskBarItemId,objMainWindow))
        {	                  
            // Get the task bar box.
            var objTaskBarBox = Web_GetTaskBarBox();
            if(objTaskBarBox)
            {
                // Get the taskbar items container.
                var objTaskBarItems = Web_GetContextElementById(objTaskBarBox,"VWG_TaskBarItems");
                if(objTaskBarItems)
                {
                    // Get the task bar item template.
                    var objTaskBarItemTemplate = Web_GetElementById("VWG_TaskBarItemTemplate",objMainWindow);
                    if(objTaskBarItemTemplate)
                    { 
                        // Clone the taskbar item template.
                        var objTaskBarItem = objTaskBarItemTemplate.cloneNode(true);
                        if(objTaskBarItem)
                        {
                            // Set the new taskbar item's id.
                            objTaskBarItem.id = strTaskBarItemId;
                            
                            // Show the new taskbar item.
                            objTaskBarItem.style.display="block";
                            
                            // Create a new content element.
                            var objTaskBarItemContent = objMainWindow.document.createElement("SPAN");
                            
                            // Set the new content class.
                            objTaskBarItemContent.className = "[Skin.TaskBarItemContentClass] nobr";
                                
                            // Append the content div.
                            objTaskBarItem.appendChild(objTaskBarItemContent);
                            
                            // Define an image element.
                            var objImageElement = null;
                                                                
                            // Get the icon of the minimized form.
                            var strFormIcon = Xml_GetAttribute(objFormNode,"Attr.Icon","");
                            if(!Aux_IsNullOrEmpty(strFormIcon))
                            {
                                // Create a new image element.
                                objImageElement = objMainWindow.document.createElement("IMG");
                                
                                // Set the new image class.
                                objImageElement.className = "[Skin.TaskBarItemImageClass]";
                                
                                // Set the new image's source.
                                objImageElement.src=strFormIcon;
                                
                                // Append the new image.
                                objTaskBarItemContent.appendChild(objImageElement);
                            }
                            
                            // Get the title of the minimized form.
                            var strFormTitle = Xml_GetAttribute(objFormNode,"Attr.Text","",true);
                            if(!Aux_IsNullOrEmpty(strFormTitle))
                            {
                                // Check if an image element was created.
                                if(objImageElement)
                                {
                                    // Create a new empty image element.
                                    var objEmptyImageElement = objMainWindow.document.createElement("IMG");
                                    
                                    // Set the empty image element's source.
                                    objEmptyImageElement.src="[Skin.CommonPath]Empty.gif.swgx";
                                    
                                    // Set the empty image element's size.
                                    objEmptyImageElement.style.width="5px";
                                    objEmptyImageElement.style.height="1px";
                                    
                                    // Append the empty image element.
                                    objTaskBarItemContent.appendChild(objEmptyImageElement);
                                }
                                
                                // Create a new nobr element.
                                var objNoBrElement = objMainWindow.document.createElement("SPAN");
                                
                                // Set the new nobr class.
                                objNoBrElement.className = "[Skin.TaskBarItemLabelClass] nobr";
                                
                                // Set the new nobr's inner text.
                                Web_SetInnerText(objNoBrElement,strFormTitle);
                                
                                // Append the new nobr.
                                objTaskBarItemContent.appendChild(objNoBrElement);
                                
                                // Set the task bar item tooltip.
                                objTaskBarItem.title = strFormTitle;
                            }
                            
                            // Add the new taskbar item.
                            $(objTaskBarItems).append(objTaskBarItem);
                            
                            // Resizes all inline boxes.
                            Forms_ResizeInlineWindowsBoxes(objMainWindow);
                            
                            // Resize inline maximized windows.
                            Forms_OnMainWindowResized(false);
                        }	            
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Forms_GetActivatedWindow" access="private">
/// <summary>
/// 
/// </summary>
function Forms_GetActivatedWindow(strDeactivatedWindowId)
{
    var objActivatedWindow = null;
            
    // Loop all form ids.
    for(var strFormId in mobjFormsWindowById)
    {
        // Check that current form is not the deactivated form.
        if(strFormId!=strDeactivatedWindowId)
        {
            // Get current window.
            var objCurrentWindow = mobjFormsWindowById[strFormId];
	        
            // Check that current window is a real window.
            if(Web_IsWindow(objCurrentWindow))
            {
                // Preserve current window.
                objActivatedWindow=objCurrentWindow;
            }
        }
    }
    
    return objActivatedWindow;
}
/// </method>

/// <method name="Forms_GetActivatedInlineWindow" access="private">
/// <summary>
/// 
/// </summary>
function Forms_GetActivatedInlineWindow(objDeactivatedWindowElement)
{
    var strActivatedInlineWindow = null;
    
    // Validate recieved window element.
    if(Forms_IsInlineWindow(objDeactivatedWindowElement))
    {
        var strDeactivatedWindowId = "";
        
        // Check if the deactivated form is popup
        if(Popups_IsPopup(objDeactivatedWindowElement))
        {
            // Get deactivated window id from the vwg_FormId attribute.
            strDeactivatedWindowId = Web_GetAttribute(objDeactivatedWindowElement,"vwg_FormId","");
        }
        else
        {
            // Get deactivated window id from the vwgguid attribute.
            strDeactivatedWindowId = Web_GetAttribute(objDeactivatedWindowElement,"vwgguid","");
        }
        
        if(!Aux_IsNullOrEmpty(strDeactivatedWindowId))
        {
            var strFormOwnerId = "";
            
            // Get form's parent form node
            var objNode = Data_GetFormNodeByDataId(strDeactivatedWindowId,true);
            if(objNode)
            {
                // Get closed form parent id
                strFormOwnerId = Xml_GetAttribute(objNode,"Attr.Id","");
            }
            
            // If the closed form was pop up set its parent to be the active form
            if(Popups_IsPopup(objDeactivatedWindowElement))
            {
                // Set active form.
                strActivatedInlineWindow=strFormOwnerId;
            }
            else
            {
                // Get all inline windows.
                var arrWindows = Forms_GetInlineWindows(objDeactivatedWindowElement,Web_GetWindowsBox(strFormOwnerId));
                
                // Validate inline windows array.
                if(arrWindows && arrWindows.length>0)
                {
                    // Sort the current windows by z-index
                    arrWindows.sort(Forms_ReorderInlineWindowsPositionSorter);
                    
                    // Get top inline window guid.
                    var strTopWindowGuid = Web_GetAttribute(arrWindows[arrWindows.length-1],"vwgguid","");
                    if(!Aux_IsNullOrEmpty(strTopWindowGuid))
                    {
                        // Set active form.
                        strActivatedInlineWindow=Data_GetDataId(strTopWindowGuid);
                    }
                }
                else if(!Aux_IsNullOrEmpty(strFormOwnerId))
                {
                    // Set parent as active form.
                    strActivatedInlineWindow=strFormOwnerId;
                }
                // Validate main window guid.
                else if(!Aux_IsNullOrEmpty(mstrWindowGuid))
                {
                    // Set active form.
                    strActivatedInlineWindow=Data_GetDataId(mstrWindowGuid);
                }
            }
        }
    }
    
    return strActivatedInlineWindow;
}
/// </method>

/// <method name="Forms_MinimizeInlineWindow" access="private">
/// <summary>
/// Minimizes an inline window
/// </summary>
function Forms_MinimizeInlineWindow(strGuid,objMainWindow,blnClientSource)
{
    if(blnClientSource)
    {
        // Triggers the focus element's blur handler.
        Forms_TriggerFocusElementBlurHandler();
    }
    
    // Validate recieved arguments.
	if(objMainWindow && !Aux_IsNullOrEmpty(strGuid))
	{
	    // Get the form's wrapper element. 
        var objWrapperElement = Web_GetElementById("WRP_"+strGuid,objMainWindow);
        if(objWrapperElement)
        {
	        // Get the form node.
            var objFormNode = Data_GetNode(strGuid);
            if(objFormNode)
            {
                // Check if form is an MDI window.
                if(!Aux_IsNullOrEmpty(Forms_GetMdiParent(objFormNode)))
                {       
                    // Minimizes window as MDI.
                    Forms_MinimizeMdiWindow(strGuid,objMainWindow,objWrapperElement,blnClientSource);
                }
                else
                {
                    // Creates task bar item.
                    Forms_CreateInlineWindowTaskBarItem(strGuid,objFormNode,objMainWindow);
                    
                    // Hide the original window.
                    objWrapperElement.style.display="none";
	                
	                // Check if the Deactivated event is critical for the minimized window.
                    var blnRaiseEvents = Data_IsCriticalEvent(objFormNode, "Event.Deactivate", true);
                    
                    // Check that minimized window is not modal.
                    if(!Forms_IsModalInlineWindow(objWrapperElement))
                    {
                        // Get activate inline window.
                        var strActiveWindow = Forms_GetActivatedInlineWindow(objWrapperElement);
                        if(!Aux_IsNullOrEmpty(strActiveWindow))
                        {
                            // Check if the Activated event is critical for the new active form.
                            blnRaiseEvents = (blnRaiseEvents || Data_IsCriticalEvent(strActiveWindow, "Event.Activated"));
                            
                            // Activate window.
	                        Forms_SetActiveFormById(strActiveWindow,!blnClientSource);
                        }
                    }
	                
	                if(blnClientSource)
                    {                        
                        // Create a window state change event.
                        var objVwgEvent = Events_CreateEvent(strGuid,"WindowStateChange",null,true); 
                        Events_SetEventAttribute(objVwgEvent, "Attr.WindowState", "1");                       

                        blnRaiseEvents = true;
                    }
                    
                    // Raise events - if needed.
                    if(blnRaiseEvents)
                    {
                        // Raise event
                        Events_RaiseEvents();
                    }
                }
            }
        }
	}
}
/// </method>

/// <method name="Forms_DragInlineWindow" access="private">
/// <summary>
/// 
/// </summary>
function Forms_DragInlineWindow(strGuid,blnResizable,objSource,objWindow,objEvent)
{
    if(Web_IsLeftClick(objEvent))
    {
        // Try getting a form node.
        var objFormNode = Data_GetNode(strGuid);
        if(objFormNode)
        {
            // Cacnel default behavior.
            Web_EventCancelBubble(objEvent,true,false);
            
            // Get form's mdi parent.
            var intMdiParent = Forms_GetMdiParent(objFormNode);
            
            // Get source drag type.
            var intDragType = Web_GetDragType(objSource);

	        // If drag type was not found
	        if(intDragType!=-1)
	        {
                // Check if window is in normal state.
                if(Data_IsAttribute(strGuid,"Attr.WindowState","0"))
                {
                    // Bring inline window to front.
                    Forms_BringWindowToTop(strGuid);
                    
                    if(blnResizable)
                    {
                        // Define an empty windows box rectangle.
                        var objWindowsBoxRect = null;
                        
                        // Try getting a windows box element.
                        var objWindowsBox = Web_GetWindowsBox(intMdiParent);
                        if(objWindowsBox && objWindowsBox.parentNode)
                        {
                            // Get windows box rectangle.
                            objWindowsBoxRect = Web_GetRect(objWindowsBox.parentNode);
                            
                            // In case of a positive bottom position.
                            if(objWindowsBoxRect.bottom > 0)
                            {
                                // Fix bottom position of drag region.
                                objWindowsBoxRect.bottom-=1;
                            }

                            // In case if resizing.
                            if(Web_IsResizeDragType(intDragType))
                            {
                                // Get form element.
                                var objFormElement = mobjFormsWindowById[Web_GetWebId(strGuid)];
	                            if(objFormElement)
	                            {
                                    // Get form element rectangle.
                                    var objFormElementRect = Web_GetRect(objFormElement);

                                    // Initialize resize direction indicators.
                                    var blnIsTopResize = intDragType==mcntDragResizeTop || intDragType==mcntDragResizeTopRight || intDragType==mcntDragResizeTopLeft;
                                    var blnIsBottomResize = intDragType==mcntDragResizeBottom || intDragType==mcntDragResizeBottomRight || intDragType==mcntDragResizeBottomLeft;
                                    var blnIsLeftResize = intDragType==mcntDragResizeLeft || intDragType==mcntDragResizeTopLeft || intDragType==mcntDragResizeBottomLeft;
                                    var blnIsRightResize = intDragType==mcntDragResizeBottomRight || intDragType==mcntDragResizeTopRight || intDragType==mcntDragResizeRight;

                                    // In case of top resizing, limit resize at the bottom edge of the form element rectangle.
                                    if(blnIsTopResize)
                                    {
                                        objWindowsBoxRect.bottom = objFormElementRect.bottom;
                                    }
                                    
                                    // In case of bottom resizing, limit resize at the top edge of the form element rectangle.
                                    if(blnIsBottomResize)
                                    {
                                        objWindowsBoxRect.top = objFormElementRect.top;
                                    }

                                    // In case of left resizing, limit resize at the right edge of the form element rectangle.
                                    if(blnIsLeftResize)
                                    {
                                        objWindowsBoxRect.right = objFormElementRect.right;
                                    }

                                    // In case of right resizing, limit resize at the left edge of the form element rectangle.
                                    if(blnIsRightResize)
                                    {
                                        objWindowsBoxRect.left = objFormElementRect.left;
                                    }

                                    // Try get form's maximum height.
                                    var intMaximumHeight = Number(Xml_GetAttribute(objFormNode, "Attr.MaximumHeight", "0"));
                                    if(intMaximumHeight>0)
                                    {
                                        if(blnIsBottomResize)
                                        {
                                            // Update windows box rectangle.
                                            objWindowsBoxRect.bottom=objWindowsBoxRect.top+intMaximumHeight;
                                        }
                                        else if(blnIsTopResize)
                                        {
                                            // Update windows box rectangle.
                                            objWindowsBoxRect.top=objFormElementRect.bottom-intMaximumHeight;
                                        }
                                    }

                                    // Try get form's maximum width.
                                    var intMaximumWidth = Number(Xml_GetAttribute(objFormNode, "Attr.MaximumWidth", "0"));
                                    if(intMaximumWidth>0)
                                    {
                                        if(blnIsRightResize)
                                        {
                                            // Update windows box rectangle.
                                            objWindowsBoxRect.right=objWindowsBoxRect.left+intMaximumWidth;

                                        }
                                        else if(blnIsLeftResize)
                                        {
                                            // Update windows box rectangle.
                                            objWindowsBoxRect.left=objFormElementRect.right-intMaximumWidth;
                                        }
                                    }

                                    // Try get form's minimum height.
                                    var intMinimumHeight = Number(Xml_GetAttribute(objFormNode, "Attr.MinimumHeight", "0"));
                                    if(intMinimumHeight>0)
                                    {   
                                        if(blnIsBottomResize)
                                        {
                                            // Update windows box rectangle.
                                            objWindowsBoxRect.top+=intMinimumHeight;
                                        }
                                        else if(blnIsTopResize)
                                        {
                                            // Update windows box rectangle.
                                            objWindowsBoxRect.bottom=objWindowsBoxRect.top+intMinimumHeight;
                                        }
                                    }

                                    // Try get form's minimum width.
                                    var intMinimumWidth = Number(Xml_GetAttribute(objFormNode, "Attr.MinimumWidth", "0"));
                                    if(intMinimumWidth>0)
                                    {
                                        if(blnIsRightResize)
                                        {
                                            // Update windows box rectangle.
                                            objWindowsBoxRect.left+=intMinimumWidth;
                                        }
                                        else if(blnIsLeftResize)
                                        {
                                            // Update windows box rectangle.
                                            objWindowsBoxRect.right=objWindowsBoxRect.left+intMinimumWidth;
                                        }
                                    }
                                }
                            }
                        }
                        
                        // Start inline window draging.
                        Forms_InlineWindowDragStart(strGuid,objSource,objWindow,objEvent,objWindowsBoxRect,null,Forms_DragInlineWindowCallback,strGuid);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Forms_ResizeMaximizedMdiChildWindows" access="private">
/// <summary>
/// 
/// </summary>
function Forms_ResizeMaximizedMdiChildWindows(strGuid)
{
    // Check if the resized form is an mdi container.
    if(Data_IsAttribute(strGuid,"Attr.IsMdiContainer","1"))
    {
        // Get mdi container's windows box.
        var objWindowsBox = Web_GetElementById("VWGE_WindowsBox"+strGuid,window);
        if(objWindowsBox)
        {
            // Get windows box rect.
            var objWindowsBoxRect = Web_GetRect(objWindowsBox);
            if(objWindowsBoxRect)
            {
                // Calculate windows box sizes.
                var intWindowsBoxWidth  = (objWindowsBoxRect.right-objWindowsBoxRect.left);
                var intWindowsBoxHeight = (objWindowsBoxRect.bottom-objWindowsBoxRect.top);
                
                // Resize maximized inline windows.
                Forms_ResizeMaximizedInlineWindows(objWindowsBox,intWindowsBoxWidth,intWindowsBoxHeight,true);
            }
        }
    }
}
/// </method>

/// <method name="Forms_DragInlineWindow" access="private">
/// <summary>
/// 
/// </summary>
function Forms_DragInlineWindowCallback(objRect,strGuid)
{
    switch(mintDragType)
	{
		case mcntDragMoveHorz:
		case mcntDragMoveVert:
		case mcntDragMoveFree:
            // Add a move event and update position data.		    
			Forms_OnMove(strGuid,objRect.left,objRect.top,true,false,false);
			break;
default:
    // Fire the resize events for controls in tshe inner form
    Web_EmulateResize(Web_GetElementByDataId(strGuid));

    // Handle inline window resize actions.
    Forms_ResizeMaximizedMdiChildWindows(strGuid);

    //Get dialog's height and width offsets out of skin defeinitions.
    var objSize = Forms_GetInlineWindowSkinOffset(strGuid);

    // Add a resize event and update size data.		    
    Forms_OnResize(strGuid, (objRect.right - objRect.left - objSize.Width), (objRect.bottom - objRect.top - objSize.Height), true);

    // Add a move event and update position data.		    
    Forms_OnMove(strGuid, objRect.left, objRect.top, true, false, true);

    // Raise events
    Events_RaiseEvents();
    break;
	}
}
/// </method>

/// <method name="Forms_MaximizeInlineWindow" access="private">
/// <summary>
/// Maximizes an inline window
/// </summary>
function Forms_MaximizeInlineWindow(strGuid,objEvent,objMainWindow,blnClientSource,blnBringToFront)
{
    if(blnClientSource)
    {
        // Triggers the focus element's blur handler.
        Forms_TriggerFocusElementBlurHandler();
    }
    
    // Variable declerations.
    var objFormNode          = Data_GetNode(strGuid);
    var intMdiParent         = Forms_GetMdiParent(objFormNode);
	var objWrapperElement    = Web_GetElementById("WRP_"+strGuid,objMainWindow);
	var objWindowsBoxElement = Web_GetWindowsBox(intMdiParent);
	
	// Validate elements.
	if(objWindowsBoxElement && objWrapperElement)
	{
        // Set handled window to be the active window.
        Forms_SetActiveFormById(strGuid,!blnClientSource);
                    
	    // Get the window's state.
        var strWindowState = Data_GetAttribute(strGuid, "Attr.WindowState", "0");

        // If restored from minimized, take care of taskbar.
        if (strWindowState == "1")
        {
        	Forms_RestoreTaskBarItem(objMainWindow, "TBI_" + strGuid, blnClientSource);
        }
	    
	    // Check if current windows box is scrollable.
        if(Web_IsAttribute(objWindowsBoxElement,"vwgscrollable","1",true))
        {
            objWindowsBoxElement.style.overflow=(!blnClientSource || strWindowState!="2"?"hidden":"auto");
        }
        
        // Get restored data.
        var objFormRestoredData = Forms_GetFormRestoredData(strGuid);
        
        // Try getting form's restored width.
        var strWindowDataWidth = objFormRestoredData.Width;
        
        // Try getting form's restored height.
        var strWindowDataHeight = objFormRestoredData.Height;
        
        // Get dialog's height and width offsets out of skin defeinitions.
        var objSize = Forms_GetInlineWindowSkinOffset(strGuid);        
        var intWindowHeightOffset = objSize.Height;
        var intWindowWidthOffset = objSize.Width;
        
        // Add offdsets to window's last size.
        var strWindowWidth = String(Number(strWindowDataWidth)+intWindowWidthOffset);
        var strWindowHeight = String(Number(strWindowDataHeight)+intWindowHeightOffset);
    	
        // Try getting form's restored left.        
        var strWindowLeft = objFormRestoredData.Left;
        
        // Try getting form's restored top.        
        var strWindowTop = objFormRestoredData.Top;
		
	    if(!blnClientSource || strWindowState!="2")
	    {            
	        // Get the windowsbox's parent element.
	        var objWindowsBoxParent = Web_GetParent(objWindowsBoxElement);
	        if(objWindowsBoxParent)
	        {
	            // Get windows box parent's rectangle.
	            var objWindowsBoxParentRect = Web_GetRect(objWindowsBoxParent);
                if(objWindowsBoxParentRect)
                {
                    // Get form's maximum height.
                    var intMaximumHeight = Number(Xml_GetAttribute(objFormNode, "Attr.MaximumHeight", "0"));
                    if(intMaximumHeight>0)
                    {
                        // Set form's maximized height with form's maximum height.
                        strWindowDataHeight = strWindowHeight  = intMaximumHeight;
                    }
                    else
                    {
                        // Set form's maximized height with the windows box height.
                        strWindowDataHeight = strWindowHeight = objWindowsBoxParentRect.bottom-objWindowsBoxParentRect.top;
                    }

                    // Get form's maximum width.
                    var intMaximumWidth = Number(Xml_GetAttribute(objFormNode, "Attr.MaximumWidth", "0"));
                    if(intMaximumWidth>0)
                    {
                        // Set form's maximized width with form's maximum width.
                        strWindowDataWidth  = strWindowWidth = intMaximumWidth;
                    }
                    else
                    {
                        // Set form's maximized width with the windows box width.
                        strWindowDataWidth  = strWindowWidth  = objWindowsBoxParentRect.right-objWindowsBoxParentRect.left;
                    }
                }
            }
            
            // Set the window "Maximized" locations.
            strWindowLeft = "0";
            strWindowTop  = "0";
        }
    	
	    // Set the window's position to absolute.
	    if(objWrapperElement.style.position != "absolute")
	    {
            objWrapperElement.style.position = "absolute";
        }
         
        // Set the form's body wrapper size.
        objWrapperElement.style.height = strWindowHeight + "px";
        objWrapperElement.style.width = strWindowWidth + "px";
        
	    // Set the window's new location.
        objWrapperElement.style.left = strWindowLeft + "px";
        objWrapperElement.style.top = strWindowTop + "px";
        
        // Handle inline window resize actions.
		Forms_ResizeMaximizedMdiChildWindows(strGuid);
		    
        // Check if form is an MDI window.
        if(!Aux_IsNullOrEmpty(intMdiParent))
        {
            // Get form's body element.
            var objFormBodyElement = Web_GetElementByDataId(strGuid, objMainWindow);
            if(objFormBodyElement)
            {
                // Ste form's body display css value.
                objFormBodyElement.style.display="block";
            }
        }
        
        if(blnClientSource)
        {
            // Update form's control box element.
            Forms_UpdateFormControlBoxElement(strGuid);
            
            // Create a window state change event.
            var objVwgEvent = Events_CreateEvent(strGuid,"WindowStateChange",null,true); 
            Events_SetEventAttribute(objVwgEvent, "Attr.WindowState", strWindowState == "2" ? "0" : "2");
            
            // Raise events.
    	    Events_RaiseEvents();
	    }	
		
	}

	// Bring window to front.
	if(blnBringToFront)
	{
	    Forms_BringWindowToTop(strGuid);
	}
}
/// </method>

/// <method name="Forms_InitalizeBoxButton" access="private">
/// <summary>
/// 
/// </summary>
function Forms_InitalizeBoxButton(objWindow,strElementId,strClassName,strTitle)
{
    // Validate received arguments.
    if(objWindow && !Aux_IsNullOrEmpty(strElementId))
    {
        // Get the button element.
        var objButtonElement = Web_GetElementById(strElementId,objWindow);
        if(objButtonElement)
        {
            // Set the button's class.  
            objButtonElement.className = strClassName;
            objButtonElement.guiclassname = strClassName;
            objButtonElement.guilastclassname = strClassName;
      
            // Set the button's title.  
            objButtonElement.title = strTitle;
        }
    }
}
/// </method>

/// <method name="Forms_CloseWindowElement" access="private">
/// <summary>
/// Closes a window.
/// </summary>
/// <param name="objWindow">The window object.</param>
function Forms_CloseWindowElement(objWindow, objFormNode)
{
    if (objWindow)
    {
        // Chek if recieved window is an inline window.
        if (Forms_IsInlineWindow(objWindow))
        {
            if (mcntIsIE)
            {
                mobjApp.Web_ClearIFramesSource(objWindow.getElementsByTagName("iframe"));
            }

            if (objWindow.parentNode)
            {
                // Define an empty windows box element.
                var objWindowsBox = Web_GetWindowsBox(Data_GetDataId(Web_GetAttribute(objWindow, "vwgmdiparent", true)));               

                // If closing non-popup window & in full screen mode..
                if (objFormNode && mblnFullScreenMode)
                {                    
                    // Create mock previous effect object
                    var objTargetPreviousValues = { "Attr.BeforeExitEffect" : Xml_GetAttribute(objFormNode, "Attr.BeforeEntranceEffect") };

                    // Apply exit effect on element.
                    VisualEffects_ChangeVisualEffect(objFormNode, objTargetPreviousValues, mobjApp, "Attr.BeforeExitEffect", "Attr.AfterExitEffect", function ()
                    {
						// Remove closed window element at the end of exit effect.
                        objWindow.parentNode.removeChild(objWindow);

                        // Reorder inline windows position.
                        Forms_ReorderInlineWindowsPosition(null, objWindowsBox);
                    });
                }

                else
                {
                    // Remove current inline window.
                    objWindow.parentNode.removeChild(objWindow);
                    // Reorder inline windows position.
                    Forms_ReorderInlineWindowsPosition(null, objWindowsBox);
                } 
            }
        }
        else if (Web_IsWindow(objWindow))
        {
            objWindow.close();
        }
    }
}
/// </method>

/// <method name="Forms_GetWindowById">
/// <summary>
/// Gets a window object by its id
/// </summary>
/// <param name="strGuid">The window id.</param>
function Forms_GetWindowById(strGuid)
{
    return mobjFormsWindowById[Web_GetWebId(strGuid)];
}
/// </method>

/// <method name="Forms_IsInlineWindow">
/// <summary>
/// Gets a boolean indicating if window is inline
/// </summary>
/// <param name="objWindow">The window object.</param>
function Forms_IsInlineWindow(objWindow)
{
    if(objWindow)
    {
        return  mblnFullScreenMode || Web_IsAttribute(objWindow, "vwginlinewindow", "1", true);
        }

    return false;
}
/// </method>

/// <method name="Forms_CloseWindow" access="private">
/// <summary>
/// Closes a window.
/// </summary>
/// <param name="strGuid">The ID of the window to be closed.</param>
function Forms_CloseWindow(strGuid)
{
    var objWindow = Forms_GetWindowById(strGuid);    
    
    if(objWindow)
    {
        if(Forms_IsInlineWindow(objWindow))
        {
            Forms_CloseInlineWindow(strGuid,null,null);            
    	}
    	else
    	{
    	    Forms_CloseForm(strGuid, false, objWindow);
        }
    }
}
/// </method>

/// <method name="Forms_FireOnUnload">
/// <summary>
/// Fires on unload event.
/// </summary>
function Forms_FireOnUnload(strGuid)
{
    var blnRaiseEevnts = false;

    // Raise the unload event
    var objVwgEvent = Events_CreateEvent(strGuid, "OnUnload");

    // Check if the closed, closing or deactivate events are critical.
    blnRaiseEevnts = Data_IsCriticalEvent(strGuid, ["Event.Closed", "Event.Closing", "Event.Deactivate"]);

    // Process client event before node removed.
    Events_ProcessClientEvent(objVwgEvent);

    if (blnRaiseEevnts)
    {
        Events_RaiseEvents();
    }

    return blnRaiseEevnts;
}

/// <method name="Forms_CloseForm">
/// <summary>
/// Handles closing a window.
/// If the window has a Closing event on the server, then the server is responsible for closing the window
/// </summary>
function Forms_CloseForm(strGuid, blnIsServerResource, objWindow)
{
    var blnRaiseEevnts = false;

    if (!blnIsServerResource)
    {
        // Fires on unload event.
        blnRaiseEevnts = Forms_FireOnUnload(strGuid);
    }

    if (!blnRaiseEevnts)
    {
        // Validate window existence.
        var objValidatedWindow = objWindow || Forms_GetWindowById(strGuid);

        // Get form node before it removed.
        var objFormNode = Data_GetNode(strGuid);

        // Remove form's node from XML state.
        Forms_UnloadForm(strGuid, blnIsServerResource);

        // Remove element if not popup.
        Forms_CloseWindowElement(objValidatedWindow, objFormNode);
    }
}
/// </method>

/// <method name="Forms_GetWindowByDataId">
/// <summary>
/// Gets an window related to a given component.
/// </summary>
/// <param name="strGuid">The component element to find its container.</param>
function Forms_GetWindowByDataId(strGuid)
{
    // Validate recieved arguments.
    if(!Aux_IsNullOrEmpty(strGuid))
    {
        // Get the containing form node
        var objFormNode = Data_GetFormNodeByDataId(strGuid);
        if(objFormNode!=null)
        {
            // Get window from form node
            return Forms_GetWindow(Forms_GetWindowById(Xml_GetAttribute(objFormNode,"Id")));
        }
    }
}
/// </method>

/// <method name="Forms_IsModalInlineWindow">
/// <summary>
/// Check whether the recieved inline window is modal.
/// </summary>
function Forms_IsModalInlineWindow(objInlineWindow)
{
    // Check if the recieved window is inline.
    var blnIsModalInlineWindow = Forms_IsInlineWindow(objInlineWindow);
    if(blnIsModalInlineWindow)
    {
        // Get the inline window guid.
        var strGuid = Web_GetAttribute(objInlineWindow, "vwgguid", "");
        blnIsModalInlineWindow = Forms_IsModalWindow(strGuid);
    }
    
    return blnIsModalInlineWindow;
}
/// </method>

/// <method name="Forms_InitializeModalWindowBox">
/// <summary>
/// Initializes the modal window box.
/// </summary>
function Forms_InitializeModalWindowBox(blnShow,blnMaskedBox,objWindowsBox)
{   
    // Define an empty modal window box.
    var objModalWindowBox = Web_GetModalWindowBox(blnMaskedBox);
    if(objModalWindowBox)
    {    
        // Set the modal window box visivbility.
        objModalWindowBox.style.display = (blnShow ? "block" : "none");  
        
        if(!mblnFullScreenMode)
        {
            // If should show
            if(blnShow)
            {
                // Validate windows box.
                if(objWindowsBox)
                {
                    // Get windows box rect.
                    var objWindowsBoxRect = Web_GetRect(objWindowsBox.id=="VWGE_WindowsBox"?objWindowsBox.parentNode:objWindowsBox);
                    if(objWindowsBoxRect)
                    {
                        // Resize the modal window box.
                        Forms_ResizeModalWindowBox(objModalWindowBox,(objWindowsBoxRect.right-objWindowsBoxRect.left),(objWindowsBoxRect.bottom-objWindowsBoxRect.top));
                    }
                }
            }
        }
    }
}
///</method>

/// <method name="Forms_ResizeModalWindowBox">
/// <summary>
/// Initializes the modal window box.
/// </summary>
function Forms_ResizeModalWindowBox(objModalWindowBox,intWidth,intHeight)
{
    // Check if the masked modal window box is visible.
    if(objModalWindowBox && objModalWindowBox.style.display=="block")
    {       
        // Set the modal window box size.
        objModalWindowBox.style.width = intWidth + "px";
        objModalWindowBox.style.height = intHeight + "px";     
    }
}
/// </method>

/// <method name="Forms_ResizeInlineWindowsModalBoxes">
/// <summary>
/// Initializes the modal window box.
/// </summary>
function Forms_ResizeInlineWindowsModalBoxes(intWidth,intHeight)
{
    // Loop all of the windows box's modal window boxes.
    for(var intModalWindowBox=0; intModalWindowBox<=1; intModalWindowBox++)
    {
        // Resize current modal window box.
        Forms_ResizeModalWindowBox(Web_GetModalWindowBox(intModalWindowBox==0?false:true),intWidth,intHeight);
    }
}
/// </method>

/// <method name="Forms_ResizeMaximizedInlineWindows" access="private">
/// <summary>
/// 
/// </summary>
function Forms_ResizeMaximizedInlineWindows(objWindowsBox,intWidth,intHeight,blnUpdateServer)
{
    // Validate inline windows mode.
    if(mblnInlineWindows)
    {
        // Check if windows box has been sent.
        if(!objWindowsBox)
        {
            // Get main window's windows box.
            objWindowsBox = Web_GetElementById("VWGE_WindowsBox",window);
        }
        
        // Validate windows box.
        if(objWindowsBox)
        {
            // Loop windows box child windows.
            for(var intIndex=0;intIndex<objWindowsBox.childNodes.length;intIndex++)
            {
                // Get current window.
                var objCurrentWindow = objWindowsBox.childNodes[intIndex];
                if(objCurrentWindow)
                {
                    // Get current window's form id.
                    var strFormId = Data_GetDataId(objCurrentWindow.id);

                    // Get form node.
                    var objFormNode = Data_GetNode(strFormId);
                    if(objFormNode)
                    {
                        // Cehck if current window is maximized.
                        if(Xml_IsAttribute(objFormNode,"Attr.WindowState","2"))
                        {
		                    // Get form's maximum height.
                            var intMaximumHeight = Number(Xml_GetAttribute(objFormNode, "Attr.MaximumHeight", "0"));
                            if(intMaximumHeight>0)
                            {
                                // Set current window's height with the form's maximum height.
                                objCurrentWindow.style.height = intMaximumHeight + "px";
                            }
                            else
                            {
                                // Set current window's height with the recieved height.
                                objCurrentWindow.style.height = intHeight + "px";
                            }

		                    // Get form's maximum width.
                            var intMaximumWidth = Number(Xml_GetAttribute(objFormNode, "Attr.MaximumWidth", "0"));
                            if(intMaximumWidth>0)
                            {
                                // Set current window's width with the form's maximum width.
                                objCurrentWindow.style.width = intMaximumWidth + "px";
                            }
                            else
                            {
                                // Set current window's width with the recieved width.
                                objCurrentWindow.style.width = intWidth + "px";
                            }
                            
                            // Check if server should be updated.
                            if(blnUpdateServer)
                            {
                                // Raise resize event for current form.
                                Forms_OnResize(strFormId,intWidth,intHeight,true);
                            }
                        }
                    }
                }
            }
	    }
	}
}
/// </method>

/// <method name="Forms_HasOwnedModalWindows">
/// <summary>
/// Check whether recieved window has owned modal windows.
/// </summary>
/// <param name="strWindowGuid">The window ID.</param>
function Forms_HasOwnedModalWindows(strWindowGuid)
{   
    var blnHasOwnedModalWindows = false;
    
    if(!Aux_IsNullOrEmpty(strWindowGuid))
    {
        // Get form node.
        var objFormNode = Data_GetNode(Data_GetDataId(strWindowGuid));
        if(objFormNode)
        {
            // Check whether recieved window has owned modal windows.
            blnHasOwnedModalWindows = (Xml_SelectNodes("WG:Tags.Form[@Attr.Type='ModalWindow']",objFormNode).length > 0);
        }
    }
    
    return blnHasOwnedModalWindows;
}
/// </method>

/// <method name="Forms_SetActiveFormById">
/// <summary>
/// Adds active window for event handlings
/// </summary>
/// <param name="strWindowGuid">The window ID to set active.</param>
/// <param name="blnServerSource">The activation request was from server side</param>
function Forms_SetActiveFormById(strWindowGuid, blnServerSource, blnPreventNavigationEffects)
{
    // Get web id.
    var strWindowWebGuid = Web_GetWebId(strWindowGuid);

    // If window guid is different the current
    if (mstrActiveWindowGuid != strWindowWebGuid)
    {
        var intFocusedElementID = Focus_GetFocusElementDataId();

        // Check whether recieved window has owned modal windows.
        if (!Forms_HasOwnedModalWindows(strWindowWebGuid))
        {
            var blnHandleFocus = true;

            // Apply navigation effects only if deactivated form is not popup and preventing effects is not forced.
            var blnApplyNavigationEffects = !mobjFormsPopupById[Data_GetDataId(mstrActiveWindowGuid)] && !blnPreventNavigationEffects;

            var objPopup = Popups_GetPopup("vwg_ControlId", intFocusedElementID);
            if (objPopup)
            {
                // If they have shared focus on that specific form, don't do focus logic so the source-control will not lose it
                blnHandleFocus = !(Web_IsAttribute(objPopup, "vwg_ShareFocus", "1", true) && Web_IsAttribute(objPopup, "vwg_FormId", strWindowGuid, true));
            }

            if (blnHandleFocus)
            {
                // Blurs the current active window's focused element.
                Web_BlurByDataId(intFocusedElementID, false);
            }

            // Check if the call was being made from the server
            if (!blnServerSource)
            {
                // Create a new active event
                Events_FormActivated(strWindowGuid);
            }

            // Change current active window.
            mstrActiveWindowGuid = strWindowWebGuid;
            //Debug_Log("activated: " + mstrActiveWindowGuid);

            // If full screen mode..
            if (mblnFullScreenMode && blnApplyNavigationEffects)
            {
                var objFormToActivate = Forms_GetWindowById(strWindowGuid);

                // If form to activate is a main window
                if (objFormToActivate === mobjApp)
                {
                    // Get its form element
                    objFormToActivate = Web_GetElementById(strWindowWebGuid, mobjApp);
                }

                var $objFormToActivate = $(objFormToActivate);

                // Show activated window.
                $objFormToActivate.css("display", "block");

                // Get its state node.
                var objFormNode = Data_GetNode(strWindowGuid);

                if (objFormNode)
                {
                    // Get restored entrance effect attributes.
                    var strBeforeEntranceEffect = Xml_GetAttribute(objFormNode, "RBEE", null);
                    var strAfterEntranceEffect = Xml_GetAttribute(objFormNode, "RAEE", null);

                    // If entrance visual effect is defined
                    if (strBeforeEntranceEffect)
                    {
                        // Restore entrance effect attributes
                        Xml_SetAttribute(objFormNode, "Attr.BeforeEntranceEffect", strBeforeEntranceEffect);

                        if (strAfterEntranceEffect)
                        {
                            Xml_SetAttribute(objFormNode, "Attr.AfterEntranceEffect", strAfterEntranceEffect);
                        }

                        // Create mock previous effect object
                        var objTargetPreviousValues = { "Attr.BeforeEntranceEffect": strBeforeEntranceEffect };

                        // Apply entrance effect on element.
                        VisualEffects_ChangeVisualEffect(objFormNode, objTargetPreviousValues, mobjApp, "Attr.BeforeEntranceEffect", "Attr.AfterEntranceEffect");
                    }
                    
                    // Otherwise, just hide underlying forms.
                    else
                    {
                        $('#' + mstrActiveWindowGuid).siblings().css("display", "none");
                    }
                }
            }         

            if (blnHandleFocus)
            {
                // Get the new window's focus element id.
                var strFocusElementDataId = Focus_GetFormFocusableElementDataId(strWindowGuid);
                if (!Aux_IsNullOrEMpty(strFocusElementDataId))
                {
                    // Set focus to the new window's focus element.
                    Web_SetFocusByDataId(strFocusElementDataId);
                }
            }
        }
    }
}
/// </method>

/// <method name="Forms_InlineWindowDragStart">
/// <summary>
///
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objSource"></param>
/// <param name="objRegion"></param>
/// <param name="strHtml"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
function Forms_InlineWindowDragStart(strGuid,objSource,objWindow,objEvent,objRegion,strHtml,fncCallback,objCallbackArgs)
{
	// Get drag type.
	var intDragType = Web_GetDragType(objSource);
	
	// If drag type was not found
	if(intDragType!=-1)
	{
	    // Get drag source attribute
	    var strDragSource= Web_IsMoveDragType(intDragType)?"vwgresizable":"vwgdragable";
	    
	    Forms_InlineWindowDragStart.fncCallback = fncCallback;
	    Forms_InlineWindowDragStart.objCallbackArgs = objCallbackArgs;
	    
	    // Initialize pointer
	    var objCurrent = objSource;
	    
	    // Search drag target
	    while(objCurrent && !Web_IsAttribute(objCurrent,strDragSource,"1"))
	    {
	    	objCurrent = Web_GetParent(objCurrent);
	    }
	    
	    // Set current drag source
	    mobjDragSource = objCurrent;
	    
	    // If drag source was found
	    if(mobjDragSource)
	    {	    	  
	        // Get event offset.
	        var objEventOffset = Web_GetEventOffset(objEvent);
	        
	        // Check if in a move drag.
	        if(Web_IsMoveDragType(intDragType))
	        {
	            // Get event's source element.
	            var objSourceElement = Web_GetEventSource(objEvent);
    	        
	            // Validate source element.
	            if(objSourceElement && objSourceElement.id!=("VWGE_WinHeaderIcon"+strGuid))
	            {
	                // Get source element's parent.
	                var objParentElement=Web_GetParent(objSourceElement);
    	            
	                // Loop all parents until the win header container element is found.
	                while(objParentElement && objParentElement.id!=("VWGE_WinHeaderContainer"+strGuid))
                    {
                        // Set source element to its parent.
                        objSourceElement=objParentElement;
                        
                        // Get parent's parent element.
                        objParentElement=Web_GetParent(objParentElement);
                    }
                    
                    // Get offset element's and drag source's rectangles.
                    var objSourceElementRect = Web_GetRect(objSourceElement);
                    var objDragSourceRect = Web_GetRect(mobjDragSource);
    	            
                    // Validate rectangles.
                    if(objSourceElementRect && objDragSourceRect)
                    {
                        // Fix event offset positions.
                        objEventOffset.X+=(objSourceElementRect.left-objDragSourceRect.left);
                        objEventOffset.Y+=(objSourceElementRect.top-objDragSourceRect.top);
                    }
	            }
	        }

			// Update drag subject.
            mobjDragSubject = mobjDragSource;
	        
	        // Show drag element.
	    	Drag_ShowDragElement(Web_GetRect(mobjDragSource),intDragType,objWindow,Forms_InlineWindowDragEnd,objEventOffset,objRegion,null,Drag_OnMove,30);
	    }
	}
}
/// </method>

/// <method name="Forms_InlineWindowDragEnd">
/// <summary>
///
/// </summary>
/// <param name="objRect"></param>
function Forms_InlineWindowDragEnd(objRect,objSourceElementOldRect,objEvent)
{
	if(mobjDragSource && objRect)
	{
		// Try getting a scrollable parent.
		var objScrollableParent = Web_GetScrollableParent(mobjDragSource);
		if(objScrollableParent)
		{
		    // Update drag source position as for scrollable parent's scrolling position.
		    objRect.top+=objScrollableParent.scrollTop;
		    objRect.bottom+=objScrollableParent.scrollTop;
		    objRect.left+=objScrollableParent.scrollLeft;
		    objRect.right+=objScrollableParent.scrollLeft;
		}
		
		// Check offset parent.
		if(mobjDragSource.offsetParent)
		{
		    // Get offset parrent rect.
		    var objOffsetRegion = Web_GetRect(mobjDragSource.offsetParent);
		    if(objOffsetRegion)
		    {
    		    // Fix form rectangle as for parent offset.
		        objRect.left-=objOffsetRegion.left;
		        objRect.right-=objOffsetRegion.left;
		        objRect.top-=objOffsetRegion.top;
		        objRect.bottom-=objOffsetRegion.top;
		    }
		    
    		// Fix form rectangle as for parent's scroll positions.
            objRect.left+=mobjDragSource.offsetParent.scrollLeft;
            objRect.right+=mobjDragSource.offsetParent.scrollLeft;
            objRect.top+=mobjDragSource.offsetParent.scrollTop;
            objRect.bottom+=mobjDragSource.offsetParent.scrollTop;
		}
		
		// Set drag source positions.
		mobjDragSource.style.left = objRect.left + "px";
		mobjDragSource.style.top = objRect.top + "px";
		
		// Set drag source's width.
		if(objRect.right-objRect.left>0)
		{
		    mobjDragSource.style.width = String(objRect.right-objRect.left) + "px";
		}
		
		// Set drag source's height.
		if(objRect.bottom-objRect.top>0)
		{
		    mobjDragSource.style.height = String(objRect.bottom-objRect.top) + "px";
		}
		
		// Execute call back.
		if(Forms_InlineWindowDragStart.fncCallback!=null)
		{
		   Forms_InlineWindowDragStart.fncCallback(objRect,Forms_InlineWindowDragStart.objCallbackArgs);
		}
	}

    // Execute drag and drop infrastructure.
    Drag_OnDrop(objRect,objSourceElementOldRect,objEvent);
}
/// </method>

/// <method name="Forms_GetMergedInlineWindows">
/// <summary>
///
/// </summary>
function Forms_GetMergedInlineWindows(arrWindows,intModalWindowIndex,blnMaskedBox)
{
    // Validate recieved arguments.
    if( arrWindows && arrWindows.length>0 && intModalWindowIndex >= 0)
    {
        var strLastModalId = Web_GetAttribute(arrWindows[intModalWindowIndex], "vwgguid");
    
        // Define an empty modal window box.
        var objModalWindowBox = Web_GetModalWindowBox(blnMaskedBox);
        if(objModalWindowBox)
        {
            // Slicing a new array which will contain preceding windows.
            var arrPreceding = arrWindows.slice(0,intModalWindowIndex);           
            
            // Slicing a new array which will contain ending windows.
            var arrEnding = arrWindows.slice(intModalWindowIndex);

            // loop preceding windows and move all owned windows to ending windows
            // to reach effect of been able to touch non-modal windows owned/opened
            // by this modal window
            for(var intIndex = arrPreceding.length; intIndex >= 0; intIndex--)
            {
                // if the window is owned by strLastModalId moved it to arrEnding
                if(Web_IsAttribute(arrWindows[intIndex], "vwgmodalownerid", Web_GetWebId(strLastModalId)))
                {
                    //splice will return an array of windows with 1 element only
                    arrEnding.unshift(arrPreceding.splice(intIndex, 1)[0]);
                }
            }
            
            // Push the modal window box just before the last modal window.
            arrPreceding.push(objModalWindowBox);
            
            // Concat preciding and ending arrays.
            arrWindows = arrPreceding.concat(arrEnding);
        }
    }
    
    return arrWindows;
}
/// </method>


/// <method name="Form_IsChildFormHaveCriticalEvent">
/// <summary>
/// Checks if the current form owned forms has the requested critial event.
/// </summary>
function Form_IsChildFormHaveCriticalEvent(objFormNode, intEventId)
{
    var blnIsCritical = false;

    var objForms = Xml_SelectNodes("WG:Tags.Form", objFormNode);

    if (objForms)
    {
        // Loop all sub forms
        for (var intIndex = 0; intIndex < objForms.length && !blnIsCritical; intIndex++)
        {
            blnIsCritical = Data_IsCriticalEvent(objForms[intIndex], intEventId, true);

            //check current form sub forms.
            if (!blnIsCritical)
            {
                blnIsCritical = Form_IsChildFormHaveCriticalEvent(objForms[intIndex], intEventId);
            }
        }
    }

    return blnIsCritical;
}
/// </method>

/// <method name="Forms_FireGeoLocationChanged">
/// <summary>
/// Fires the GeoLocation event.
/// </summary>
function Forms_FireGeoLocationChanged(objPosition,objError)
{
    // Validate form id.
    if(!Aux_IsNullOrEmpty(Forms_InitializeGeoLocation.FormId))
    {
        // Create GeoLocationChanged event
	    var objEvent = Events_CreateEvent(Forms_InitializeGeoLocation.FormId,"GeoLocationChanged",null,true);

        // Check if position has been sent.
        if(objPosition)
        {
            // Validate coordinates.
            if(objPosition.coords)
            {
                // Set event attributes
	            Events_SetEventAttribute(objEvent,"Attr.Latitude",objPosition.coords.latitude);
	            Events_SetEventAttribute(objEvent,"Attr.Longitude",objPosition.coords.longitude);
            }
        }
        // Check if error has been sent.
        else if(objError)
        {
            // Set event attributes
	        Events_SetEventAttribute(objEvent,"Attr.ErrorMessage",objError.message);
	        Events_SetEventAttribute(objEvent,"Attr.ErrorCode",objError.code);
        }

        if (Data_IsCriticalEvent(Forms_InitializeGeoLocation.FormId, "Event.PositionChanged")) {
	        // Raise events.
	        Events_RaiseEvents();
	    }

	    Events_ProcessClientEvent(objEvent);
    }
}
/// </method>

/// <method name="Forms_GeoLocationSuccess">
/// <summary>
/// Success handler for GeoLocation service.
/// </summary>
function Forms_GeoLocationSuccess(objPosition)
{
    // Fire geo-location changed event with recieved position.
    Forms_FireGeoLocationChanged(objPosition,null);
}
/// </method>

/// <method name="Forms_GeoLocationFailed">
/// <summary>
/// Error handler for GeoLocation service.
/// </summary>
function Forms_GeoLocationFailed(objError)
{
    // Validate watch id.
    if(!Aux_IsNullOrEmpty(Forms_InitializeGeoLocation.WatchId))
    {
        // Validate geo-location service.
        if(navigator && navigator.geolocation)
        {
            // Clear last watch id.
            navigator.geolocation.clearWatch(Forms_InitializeGeoLocation.WatchId);
        }

        // Clear last watch id.
        Forms_InitializeGeoLocation.WatchId = null;
    }

    // Fire geo-location changed event with recieved error.
    Forms_FireGeoLocationChanged(null,objError);
}
/// </method>

/// <method name="Forms_InitializeGeoLocation">
/// <summary>
/// Initialize the form's GeoLocation service.
/// </summary>
function Forms_InitializeGeoLocation(objFormNode)
{
    // Validate geo-location service.
    if(navigator && navigator.geolocation)
    {
        // Validate recieved form node.
        if(objFormNode)
        {
			// Check if geo-location event is critical.
            if (Data_IsCriticalEventAttribute(objFormNode, "Event.PositionChanged", true, "Attr.ClientEvents") ||
                Data_IsCriticalEventAttribute(objFormNode, "Event.PositionChanged", true, "Attr.Events"))
            {
                // Get geo-location data attributes.
                var blnRepeatCheck = Xml_GetAttribute(objFormNode, "Attr.RepeatCheck", "0")=="1" ? true : false;
                var blnEnableHighAccuracy = Xml_GetAttribute(objFormNode, "Attr.EnableHighAccuracy", "");
                var dblMaximumAge = Xml_GetAttribute(objFormNode, "Attr.MaximumAge", "");
                var dblTimeout = Xml_GetAttribute(objFormNode, "Attr.Timeout", "");

                // Define an empty params JSon object.
                var objParams = {};

                // Add enableHighAccuracy parameter - if one is sent from server side.
                if(!Aux_IsNullOrEmpty(blnEnableHighAccuracy))
                {
                    objParams.enableHighAccuracy = Boolean(blnEnableHighAccuracy);
                }

                // Add maximumAge parameter - if one is sent from server side.
                if(!Aux_IsNullOrEmpty(dblMaximumAge))
                {
                    objParams.maximumAge = parseFloat(dblMaximumAge);
                }

                // Add timeout parameter - if one is sent from server side.
                if(!Aux_IsNullOrEmpty(dblTimeout))
                {
                    objParams.timeout = parseFloat(dblTimeout);
                }

                // Preserve recieved form id.
                Forms_InitializeGeoLocation.FormId = Xml_GetAttribute(objFormNode, "Attr.Id", "");

                // Check if position check should be repeated.
                if(blnRepeatCheck)
                {
                    Forms_InitializeGeoLocation.WatchId=navigator.geolocation.watchPosition(Forms_GeoLocationSuccess,Forms_GeoLocationFailed,objParams);
                }
                else
                {
                    navigator.geolocation.getCurrentPosition(Forms_GeoLocationSuccess,Forms_GeoLocationFailed,objParams);
                }
            }
        }
    }
}
/// </method>

/// <method name="Forms_EmulateResize">
/// <summary>
/// Emulates resize call recursivly - for all contained controls.
/// </summary>
function Forms_EmulateResize()
{
    if (!mcntIsObsoleteIE)
    {
        Web_EmulateResize(document.body, window.event);
    }
}
/// </method>

/// </page>


function Forms_InitializeWebSockets() {
    if (typeof InitializeWebSockets == 'function') {
        InitializeWebSockets(mstrBaseURL,
            //Success callback
            function (strConnectionId) {
                var strLoadDocument = "content." + mstrBasePage + ".wgx?vwginstance=" + mstrPageInstance + "&vwgwebsocketconnectionid=" + strConnectionId;
                Xml_LoadDocument(strLoadDocument, null, true, Web_CreatePostString(null), true);
            },
            //CSlientNotification Callback
            Events_WebSocketsNotification);
    }
}