// Preload resources
var mintTotalResourcesToLoad = 0;
var mblnAllResourceSourcesLoaded = false;
var mstrPreloadCompleteTargetId = undefined;
var mintTotalLoadedResources = 0;
var mintTotalFailedToLoadResources = 0;
var mblnHasCompleteHandler = false;
var mintRequestTimeout = -1;
var mintStartIndex = 0;
var mintBlockResourcesLoadedCount = 0;
var mintBlockResourceErrorsCount = 0;
var mintDataLength = 0;

var mobjEventArgs;

function vwgComponent(objNode)
{
    this.objNode = objNode;
}

vwgComponent.prototype.id = function ()
{
    return Number(Xml_GetAttribute(this.objNode, "Attr.Id", ""));
};

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgComponent.prototype.typeName = function ()
{
    return "Component";
};
/// </method>

/// <method name="property">
/// <summary>
/// Gets and sets custom property to the component.
/// </summary>
vwgComponent.prototype.property = function (strName, strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, strName);
    }

    Xml_SetAttribute(this.objNode, strName, strValue ? strValue : "");
};
/// </method>

function vwgControl(objNode)
{
    vwgComponent.call(this, objNode);
}

var objBaseControl = new vwgComponent();
vwgControl.prototype = objBaseControl;
vwgControl.prototype.constructor = objBaseControl;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgControl.prototype.typeName = function ()
{
    return "Control";
};
/// </method>

/// <method name="controls">
/// <summary>
/// Gets the controls inside the current control.
/// </summary>
vwgControl.prototype.controls = function ()
{
    // Get child components
    var arrControlNodes = Xml_SelectNodes("WC:*", this.objNode);

    var arrControls = [];

    // Build array of vwgControl elements initialized with provided nodes.
    for (var i = 0; i < arrControlNodes.length; i++)
    {
        var objControlNode = arrControlNodes[i];
        var objControl = vwgContext_GetComponentByNode(objControlNode);
        arrControls.push(objControl);
    }

    return arrControls;
};
/// </method>

/// <method name="parent">
/// <summary>
/// Gets the parent control.
/// </summary>
vwgControl.prototype.parent = function ()
{
    // Get the parent control node.
    var objParentNode = Xml_SelectSingleNode("ancestor::WC:*[1]", this.objNode);
    if (!objParentNode)
    {
        // If not found, get parent form.
        objParentNode = Xml_SelectSingleNode("ancestor::WG:F[1]", this.objNode);
    }

    if (objParentNode)
    {
        // Create and return Control of the parent.
        return vwgContext_GetComponentByNode(objParentNode);
    }

    return null;
};
/// </method>

/// <method name="padding">
/// <summary>
/// Gets or sets the padding of the control.
/// </summary>
vwgControl.prototype.padding = function (objValue)
{
    if (objValue == undefined)
    {
        // Create Margin object.
        var objValue = {};

        // Padding values used to gain ClientPaddingValue reuse for margins, too.
        objValue["all"] = Xml_GetAttribute(this.objNode, "Attr.PaddingAll", -1);

        objValue["bottom"] = Number(Xml_GetAttribute(this.objNode, "Attr.PaddingBottom", objValue["all"]));
        objValue["left"] = Number(Xml_GetAttribute(this.objNode, "Attr.PaddingLeft", objValue["all"]));
        objValue["right"] = Number(Xml_GetAttribute(this.objNode, "Attr.PaddingRight", objValue["all"]));
        objValue["top"] = Number(Xml_GetAttribute(this.objNode, "Attr.PaddingTop", objValue["all"]));

        // Return it.
        return objValue;
    }

    // If All set, set PA attribute.
    if (objValue.hasOwnProperty("all") && objValue["all"] != -1)
    {
        // Remove all other padding attributes.
        Xml_RemoveAttribute(this.objNode, "Attr.PaddingBottom");
        Xml_RemoveAttribute(this.objNode, "Attr.PaddingTop");
        Xml_RemoveAttribute(this.objNode, "Attr.PaddingLeft");
        Xml_RemoveAttribute(this.objNode, "Attr.PaddingRight");

        Xml_SetAttribute(this.objNode, "Attr.PaddingAll", objValue["all"]);
    }
    else
    {
        // If PA set, remove it and set all other padding attributes to its value.
        vwgContext_SetPaddingToAll(this.objNode);

        var strPaddingBottom = objValue["bottom"];
        var strPaddingTop = objValue["top"];
        var strPaddingLeft = objValue["left"];
        var strPaddingRight = objValue["right"];

        if (strPaddingBottom != undefined && !Aux_IsNullOrEmpty(strPaddingBottom) && strPaddingBottom != -1)
        {
            Xml_SetAttribute(this.objNode, "Attr.PaddingBottom", strPaddingBottom);
        }

        if (strPaddingLeft != undefined && !Aux_IsNullOrEmpty(strPaddingLeft) && strPaddingLeft != -1)
        {
            Xml_SetAttribute(this.objNode, "Attr.PaddingLeft", strPaddingLeft);
        }

        if (strPaddingRight != undefined && !Aux_IsNullOrEmpty(strPaddingRight) && strPaddingRight != -1)
        {
            Xml_SetAttribute(this.objNode, "Attr.PaddingRight", strPaddingRight);
        }

        if (strPaddingTop != undefined && !Aux_IsNullOrEmpty(strPaddingTop) && strPaddingTop != -1)
        {
            Xml_SetAttribute(this.objNode, "Attr.PaddingTop", strPaddingTop);
        }

        // Remove PA.
        Xml_RemoveAttribute(this.objNode, "Attr.PaddingAll");
    }    
};
/// </method>

/// <method name="width">
/// <summary>
/// Gets or sets the width of the control.
/// </summary>
vwgControl.prototype.width = function (intValue)
{
    if (intValue == undefined)
    {
        return Number(Xml_GetAttribute(this.objNode, "Attr.Width", ""));
    }

    Xml_SetAttribute(this.objNode, "Attr.Width", intValue);
};
/// </method>
/// </method>

/// <method name="height">
/// <summary>
/// Gets or sets the height of the control.
/// </summary>
vwgControl.prototype.height = function (intValue)
{
    if (intValue == undefined)
    {
        return Number(Xml_GetAttribute(this.objNode, "Attr.Height", ""));
    }

    Xml_SetAttribute(this.objNode, "Attr.Height", intValue);
};
/// </method>

/// <method name="left">
/// <summary>
/// Gets or sets the left of the control.
/// </summary>
vwgControl.prototype.left = function (intValue) {
    if (intValue == undefined) {
        return Number(Xml_GetAttribute(this.objNode, "Attr.Left", ""));
    }

    Xml_SetAttribute(this.objNode, "Attr.Left", intValue);
};
/// </method>

/// <method name="top">
/// <summary>
/// Gets or sets the top of the control.
/// </summary>
vwgControl.prototype.top = function (intValue) {
    if (intValue == undefined) {
        return Number(Xml_GetAttribute(this.objNode, "Attr.Top", ""));
    }

    Xml_SetAttribute(this.objNode, "Attr.Top", intValue);
};
/// </method>

/// <method name="foreColor">
/// <summary>
/// Gets or sets the foreColor of the control.
/// </summary>
vwgControl.prototype.foreColor = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Fore", "");
    }

    Xml_SetAttribute(this.objNode, "Attr.Fore", strValue);
};
/// </method>

/// <method name="backColor">
/// <summary>
/// Gets or sets the backColor of the control.
/// </summary>
vwgControl.prototype.backColor = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Background", "");
    }

    Xml_SetAttribute(this.objNode, "Attr.Background", strValue);
};
/// </method>

/// <method name="backgroundImageUrl">
/// <summary>
/// Gets or sets the backgroundImageUrl of the control.
/// </summary>
vwgControl.prototype.backgroundImageUrl = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.BackgroundImage", "");
    }

    Xml_SetAttribute(this.objNode, "Attr.BackgroundImage", strValue);
};
/// </method>

/// <method name="enabled">
/// <summary>
/// Gets or sets the enabled of the control.
/// </summary>
vwgControl.prototype.enabled = function (blnValue)
{
    if (blnValue == undefined)
    {
        var strEnabled = Xml_GetAttribute(this.objNode, "Attr.Enabled", "1");
        return (strEnabled == "1" || Aux_IsNullOrEmpty(strEnabled)) ? true : false;
    }

    Xml_SetAttribute(this.objNode, "Attr.Enabled", blnValue ? "1" : "0");
};
/// </method>

/// <method name="anchor">
/// <summary>
/// Gets or sets the anchor of the control.
/// </summary>
vwgControl.prototype.anchor = function (objValue)
{
    if (objValue == undefined)
    {
        var objAnchor = {};
        objAnchor["left"] = false;
        objAnchor["right"] = false;
        objAnchor["top"] = false;
        objAnchor["bottom"] = false;


        var strAnchor = Xml_GetAttribute(this.objNode, "Attr.Anchoring", "");
        if (strAnchor.indexOf("Attr.Left") >= 0)
        {
            objAnchor["left"] = true;
        }

        if (strAnchor.indexOf("Attr.Right") >= 0)
        {
            objAnchor["right"] = true;
        }

        if (strAnchor.indexOf("Attr.Top") >= 0)
        {
            objAnchor["top"] = true;
        }

        if (strAnchor.indexOf("Attr.Bottom") >= 0)
        {
            objAnchor["bottom"] = true;
        }
        
        return objAnchor;
    }

    var strAnchor = objValue;
    if (typeof objValue == "object")
    {
        strAnchor = "";
        if (objValue["left"] == true)
        {
            strAnchor += "Attr.Left";
        }

        if (objValue["right"] == true)
        {
            strAnchor += "Attr.Right";
        }

        if (objValue["top"] == true)
        {
            strAnchor += "Attr.Top";
        }

        if (objValue["bottom"] == true)
        {
            strAnchor += "Attr.Bottom";
        }
    }

    Xml_RemoveAttribute(this.objNode, "Attr.Docking");
    Xml_SetAttribute(this.objNode, "Attr.Anchoring", strAnchor);
};
/// </method>

/// <method name="dock">
/// <summary>
/// Gets or sets the dock of the control.
/// </summary>
vwgControl.prototype.dock = function (strValue)
{
    if (strValue == undefined)
    {
        // Get dock from xml.
        var strDock = Xml_GetAttribute(this.objNode, "Attr.Docking", "");

        // Convert xml dock to client api.
        if (strDock == "Attr.Left")
        {
            return "left";
        }
        else if (strDock == "Attr.Right")
        {
            return "right";
        }
        else if (strDock == "Attr.Top")
        {
            return "top";
        }
        else if (strDock == "Attr.Bottom")
        {
            return "bottom";
        }
        else if (strDock == "F")
        {
            return "fill";
        }

        return "none";
    }

    // Remove the anchoring.
    Xml_RemoveAttribute(this.objNode, "Attr.Anchoring");

    // Convert client API dock to xml.
    if (strValue == "left")
    {
        strValue = "Attr.Left";
    }
    else if (strValue == "right")
    {
        strValue = "Attr.Right";
    }
    else if (strValue == "top")
    {
        strValue = "Attr.Top";
    }
    else if (strValue == "bottom")
    {
        strValue = "Attr.Bottom";
    }
    else if (strValue == "fill")
    {
        strValue = "F";
    }

    // If dock is set to none, we will remove the docking from the xml.
    if (strValue == "none")
    {
        Xml_RemoveAttribute(this.objNode, "Attr.Docking");        
    }
    else
    {
        Xml_SetAttribute(this.objNode, "Attr.Docking", strValue);
    }
};
/// </method>

/// <method name="tagName">
/// <summary>
/// Gets or sets the tag of the control.
/// </summary>
vwgControl.prototype.tagName = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.ClientTag", "");
    }

    Xml_SetAttribute(this.objNode, "Attr.ClientTag", strValue);
};
/// </method>

/// <method name="text">
/// <summary>
/// Gets and sets the text of the control.
/// </summary>
vwgControl.prototype.text = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Value");
    }

    Xml_SetAttribute(this.objNode, "Attr.Value", strValue ? strValue : "");
};
/// </method>

/// <method name="tagName">
/// <summary>
/// Gets or sets a value indicating whether the control is visible.
/// </summary>
vwgControl.prototype.visible = function (blnValue)
{
    if (blnValue == undefined)
    {
        var strVisible = Xml_GetAttribute(this.objNode, "Attr.Visible", "1");
        return (strVisible == "1" || Aux_IsNullOrEmpty(strVisible)) ? true : false;
    }

    Xml_SetAttribute(this.objNode, "Attr.Visible", blnValue ? "1" : "0");
};
/// </method>

/// <method name="update">
/// <summary>
/// Redraw the control.
/// </summary>
vwgControl.prototype.update = function ()
{
    Controls_RedrawControlByNode(window, this.objNode);
};
/// </method>

/// <method name="focus">
/// <summary>
/// Set focus on the control.
/// </summary>
vwgControl.prototype.focus = function ()
{
    Controls_Focus(Xml_GetAttribute(this.objNode, "Attr.Id"));
};
/// </method>

/// <method name="addChild">
/// <summary>
/// Add child in the control.
/// </summary>
vwgControl.prototype.addChild = function (objChildContrrol)
{
    this.objNode.appendChild(objChildContrrol.objNode);
};
/// </method>

/// <method name="removeChild">
/// <summary>
/// Remove child from the control.
/// </summary>
vwgControl.prototype.removeChild = function (objChildContrrol)
{
    if (objChildContrrol.parent() != null && objChildContrrol.parent().id() == this.id()) {
        Xml_RemoveChild(this.objNode, objChildContrrol.objNode);
    }    
};
/// </method>

function vwgContext()
{

}

vwgContext.events = {};
vwgContext.provider = {};
vwgContext.deviceIntegrator = {};
vwgContext.deviceIntegrator.Info = deviceInfoAccess;
vwgContext.deviceIntegrator.Connection = deviceConnectionAccess;
vwgContext.deviceIntegrator.Globalization = deviceGlobalizationAccess;
vwgContext.deviceIntegrator.Accelerometer = deviceAccelerometerAccess;
vwgContext.deviceIntegrator.Camera = deviceCameraAccess;
vwgContext.deviceIntegrator.Capture = deviceCaptureAccess;
vwgContext.deviceIntegrator.Compass = deviceCompassAccess;
vwgContext.deviceIntegrator.Contacts = deviceContactsAccess;
vwgContext.deviceIntegrator.Geolocation = deviceGeolocationAccess;
vwgContext.deviceIntegrator.Notification = deviceNotificationAccess;
vwgContext.deviceIntegrator.Splashscreen = deviceSplashscreenAccess;
vwgContext.deviceIntegrator.Storage = deviceStorageAccess;
vwgContext.deviceIntegrator.Events = deviceEventsAccess;
vwgContext.deviceIntegrator.FileManager = deviceFileManagerAccess;
vwgContext.deviceIntegrator.Media = deviceMediaAccess;


/// <summary>
/// Sets PaddingAll value to all other padding attributes.
/// </summary>
function vwgContext_SetPaddingToAll(objNode)
{
	var strPaddingAll = Xml_GetAttribute(objNode, "Attr.PaddingAll", -1);
	if (strPaddingAll != -1)
	{
		Xml_SetAttribute(objNode, "Attr.PaddingLeft", strPaddingAll);
		Xml_SetAttribute(objNode, "Attr.PaddingRight", strPaddingAll);
		Xml_SetAttribute(objNode, "Attr.PaddingTop", strPaddingAll);
		Xml_SetAttribute(objNode, "Attr.PaddingBottom", strPaddingAll);
	}
}
/// </method>

/// <method name="vwgContext.provider.getComponentByClientId">
/// <summary>
/// Get's a client component element by id
/// </summary>
vwgContext.provider.getComponentByClientId = function (strClientId)
{
    // Select first node with the client id.
    var objComponentNode = Xml_SelectSingleNode("//*[(@Attr.ClientId='" + strClientId + "')][1]", mobjDataRootObject);
    if (!objComponentNode)
    {
        return undefined;
    }

    // Return component.
    return vwgContext_GetComponentByNode(objComponentNode);
};
/// </method>

/// <method name="vwgContext.provider.getControlById">
/// <summary>
/// Get's a client component element by id
/// </summary>
vwgContext.provider.getComponentById = function (intId)
{
    var objNode = Data_GetNode(intId);
    var objComponent = vwgContext_GetComponentByNode(objNode);
    return objComponent;
};
/// </method>

/// <method name="vwgContext_ComparePreloadResourceCounters">
/// <summary>
/// Preload resources as a request from from the server.
/// </summary>
function vwgContext_ComparePreloadResourceCounters()
{
    if (mblnAllResrouceSourcesLoaded === true && Number(mintTotalResroucesToLoad) === Number(mintTotalLoadedResrouces + Number(mintTotalFailedToLoadResrouces)))
    {
        var vwgEvent = vwgContext.events.createEvent(mstrPreloadCompleteTargetId, "PreloadResourcesComplete", null, true, true);
        vwgContext.events.setEventAttribute(vwgEvent, "resourceLoadedCount", mintTotalLoadedResrouces);
        vwgContext.events.setEventAttribute(vwgEvent, "resourceErrorCount", mintTotalFailedToLoadResrouces);
        vwgContext.events.raiseEvents();
    }
};
/// </method>

/// <method name="vwgContext.showMask">
/// <summary>
/// Show mask
/// </summary>
vwgContext.showMask = function()
{
    Events_ShowMask(null, true);
};
/// </method>

/// <method name="vwgContext.hideMask">
/// <summary>
/// Hide mask
/// </summary>
vwgContext.hideMask = function()
{
    Events_HideLoading(true);
};
/// </method>

/// <method name="vwgContext.isInOfflineMode">
/// <summary>
/// Checks current network mode.
/// </summary>
vwgContext.isInOfflineMode = function(){
	return Client_IsInOfflineMode();
};
/// </method>

/// <method name="eventArgs">
/// <summary>
/// The property contains the event args when event args are raised to the user in the client.
/// </summary>
vwgContext.events.eventArgs = function (objEventArgs)
{
    if (objEventArgs == undefined)
    {
        return mobjEventArgs;
    }

    mobjEventArgs = objEventArgs;
};

/// </method>

/// <method name="raiseEvents">
/// <summary>
/// Unobscured wrapper of Events_RaiseEvents
/// </summary>
vwgContext.events.raiseEvents = function (objCallbackDelegate) {
	if (objCallbackDelegate) {
		// Set required properties.
		if (typeof objCallbackDelegate.fncMethod === 'undefined') {
			objCallbackDelegate.fncMethod = objCallbackDelegate;
		}

		if (typeof objCallbackDelegate.arrArguments === 'undefined') {
			if (objCallbackDelegate.arguments !== null) {
				objCallbackDelegate.arrArguments = Array.prototype.slice.apply(objCallbackDelegate.arguments, 0);
			}
		}

		Events_RaiseEvents(objCallbackDelegate, true);
	}

	else {
		Events_RaiseEvents();
	}
};
/// </method>

/// <method name="setEventAttribute">
/// <summary>
/// Unobscured wrapper of Events_SetEventAttribute
/// </summary>
vwgContext.events.setEventAttribute = function (objEvent, strName, strValue) {
	Events_SetEventAttribute(objEvent, strName, strValue);
};
/// </method>

/// <method name="setEventValue">
/// <summary>
/// Unobscured wrapper of Events_SetEventValue
/// </summary>
vwgContext.events.setEventValue = function (objEvent, strValue) {
	Events_SetEventValue(objEvent, strValue);
};
/// </method>

/// <method name="createEvent">
/// <summary>
/// Unobscured version of Events_CreateEvent
/// </summary>
vwgContext.events.createEvent = function (strSource, strType, strTarget, blnUnique, blnTypeOnlyUnique) {

	return Events_CreateEvent(strSource, strType, strTarget, blnUnique, blnTypeOnlyUnique);
};
/// </method>

/// <method name="performClientEvent">
/// <summary>
/// Unobscured version of Events_CreateEvent
/// </summary>
vwgContext.events.performClientEvent = function (intComponentId, strClientEventType, objAttributes, blnUpdateState)
{
    // Create event of provided type targeted to provided component, not inqueued
    var objEvent = Events_CreateEvent(intComponentId, strClientEventType, null, null, null, !blnUpdateState);

    // Attach attributes
    for (strPropertyName in objAttributes)
    {
        if (objAttributes.hasOwnProperty(strPropertyName))
        {
            Events_SetEventAttribute(objEvent, strPropertyName, objAttributes[strPropertyName]);
        }
    }

    // Process event ("Always" availability).
    Client_ProcessEvent(objEvent, "2");
};
/// </method>

/// <method name="preloadResources">
/// <summary>
/// Preload resource as a request from from the server.
/// </summary>
vwgContext.preloadResources = function (intBlockSize, intRequestTimeout, strPreloadUrl, strPreloadCompleteTargetId)
{
    // Set url in Globals, because the preloadResources is called later (without the url).
    if (ClientStorage.Globals["mstrPreloadResourcesUrl"] == undefined)
    {        
        ClientStorage.Globals["mstrPreloadResourcesUrl"] = strPreloadUrl;
    }

    // Initialize variabled.    
    mintRequestTimeout = intRequestTimeout;

    if (strPreloadCompleteTargetId != undefined)
    {
        mblnHasCompleteHandler = true;
        mstrPreloadCompleteTargetId = strPreloadCompleteTargetId;
    }

    // If we are not in offline mode.
    if (vwgContext.isInOfflineMode() == false)
    {
        var strActualPreloadUrl = ClientStorage.Globals["mstrPreloadResourcesUrl"] + '&StartIndex=' + mintStartIndex;
        
        jQuery.post(strActualPreloadUrl, null, function (res)
        {
            if (res)
            {
                mintDataLength = res.length;
                if (mintDataLength > 0)
                {
                    if (mblnHasCompleteHandler)
                    {
                        mintTotalResourcesToLoad = Number(mintTotalResourcesToLoad) + mintDataLength;
                    }

                    for (var _index = 0; _index < res.length; _index++)
                    {
                        var row = res[_index];
                        var strSource = row.src;
                        if (strSource && strSource != '')
                        {
                            $.ajax(strSource, 
                            {
                                timeout : mintRequestTimeout,
                                success : vwgContext_OnPreloadBlockResourceLoad,
                                error : vwgContext_OnPreloadBlockResourceError
                            });

                            mintStartIndex = mintStartIndex + 1;
                        }
                    }
                }
                else
                {
                    if (mblnHasCompleteHandler)
                    {
                        mblnAllResourceSourcesLoaded = true;
                        vwgContext_ComparePreloadResourceCounters();
                    }
                }
            }
        }, 'json');
    }
};
/// </method>

/// <method name="vwgContext_ComparePreloadResourceCounters">
/// <summary>
/// Preload resources as a request from from the server.
/// </summary>
function vwgContext_ComparePreloadResourceCounters()
{
    if (mblnAllResourceSourcesLoaded === true && Number(mintTotalResourcesToLoad) === Number(mintTotalLoadedResources + Number(mintTotalFailedToLoadResources)))
    {
        var vwgEvent = vwgContext.events.createEvent(mstrPreloadCompleteTargetId, "PreloadResourcesComplete", null, true, true);
        vwgContext.events.setEventAttribute(vwgEvent, "resourceLoadedCount", mintTotalLoadedResources);
        vwgContext.events.setEventAttribute(vwgEvent, "resourceErrorCount", mintTotalFailedToLoadResources);
        vwgContext.events.raiseEvents();
    }
};
/// </method>

/// <method name="vwgContext_OnPreloadResourceLoad">
/// <summary>
/// Preload resources as a request from from the server.
/// </summary>
function vwgContext_OnPreloadResourceLoad()
{
    mintTotalLoadedResources = Number(mintTotalLoadedResources) + 1;
    vwgContext_ComparePreloadResourceCounters();
};
/// </method>

/// <method name="vwgContext_OnPreloadResourceError">
/// <summary>
/// Preload resources as a request from from the server.
/// </summary>
function vwgContext_OnPreloadResourceError()
{
    mintTotalFailedToLoadResources = Number(mintTotalFailedToLoadResources) + 1;
    vwgContext_ComparePreloadResourceCounters();
};
/// </method>

/// <method name="vwgContext_IsPreviousPreloadResourceBlockComplete">
/// <summary>
/// Preload resources as a request from from the server.
/// </summary>
function vwgContext_IsPreviousPreloadResourceBlockComplete()
{
    if (Number(mintDataLength) === Number(mintBlockResourcesLoadedCount) + Number(mintBlockResourceErrorsCount))
    {
        mintBlockResourcesLoadedCount = 0;
        mintBlockResourceErrorsCount = 0;
        vwgContext.preloadResources();
    }
};
/// </method>

/// <method name="vwgContext_OnPreloadBlockResourceLoad">
/// <summary>
/// Preload Resources as a request from from the server.
/// </summary>
function vwgContext_OnPreloadBlockResourceLoad()
{
    mintBlockResourcesLoadedCount = Number(mintBlockResourcesLoadedCount) + 1;
    window.vwgContext_IsPreviousPreloadResourceBlockComplete();
    if (mblnHasCompleteHandler)
    {
        vwgContext_OnPreloadResourceLoad();
    }
};
/// </method>

/// <method name="vwgContext_OnPreloadBlockResourceError">
/// <summary>
/// Preload resources as a request from from the server.
/// </summary>
function vwgContext_OnPreloadBlockResourceError()
{
    mintBlockResourceErrorsCount = Number(mintBlockResourceErrorsCount) + 1;
    vwgContext_IsPreviousPreloadResourceBlockComplete();
    if (mblnHasCompleteHandler)
    {
        vwgContext_OnPreloadResourceError();
    }
};
/// </method>

/// <method name="vwgContext_GetComponentByNode">
/// <summary>
/// Get's a client component by node.
/// </summary>
vwgContext_GetComponentByNode = function (objNode)
{
    var objComponent;
    if (objNode.tagName == "WC:Tags.ScheduleBox")
    {
        objComponent = new vwgScheduleBox(objNode);
    }
    else if (objNode.tagName == "WC:Tags.Button")
    {
        objComponent = new vwgButton(objNode);
    }
    else if (objNode.tagName == "WC:Tags.CheckBox")
    {
        objComponent = new vwgCheckBox(objNode);
    }
    else if (objNode.tagName == "WC:Tags.ComboBox")
    {
        objComponent = new vwgComboBox(objNode);
    }
    else if (objNode.tagName == "WC:Tags.DataGridView")
    {
        objComponent = new vwgDataGridView(objNode);
    }
    else if (objNode.tagName == "WC:Tags.DateTimePicker")
    {
        objComponent = new vwgDateTimePicker(objNode);
    }
    else if (objNode.tagName == "WC:Tags.DomainUpDown")
    {
        objComponent = new vwgDomainUpDown(objNode);
    }
    else if (objNode.tagName == "WC:Tags.FrameControl")
    {
        objComponent = new vwgFrameControl(objNode);
    }
    else if (objNode.tagName == "WC:Tags.Label")
    {
        objComponent = new vwgLabel(objNode);
    }
    else if (objNode.tagName == "WC:Tags.LinkLabel")
    {
        objComponent = new vwgLinkLabel(objNode);
    }
    else if (objNode.tagName == "WC:Tags.ListBox")
    {
        objComponent = new vwgListBox(objNode);
    }
    else if (objNode.tagName == "WC:Tags.ListView")
    {
        objComponent = new vwgListView(objNode);
    }
    else if (objNode.tagName == "WC:Tags.NumericUpDown")
    {
        objComponent = new vwgNumericUpDown(objNode);
    }
    else if (objNode.tagName == "WC:Tags.PictureBox")
    {
        objComponent = new vwgPictureBox(objNode);
    }
    else if (objNode.tagName == "WC:Tags.ProgressBar")
    {
        objComponent = new vwgProgressBar(objNode);
    }
    else if (objNode.tagName == "WC:Tags.RadioButton")
    {
        objComponent = new vwgRadioButton(objNode);
    }
    else if (objNode.tagName == "WC:Tags.RichTextBox")
    {
        objComponent = new vwgRichTextBox(objNode);
    }
    else if (objNode.tagName == "WC:Tags.TabControl")
    {
        objComponent = new vwgTabControl(objNode);
    }
    else if (objNode.tagName == "WC:Tags.TabPage")
    {
        objComponent = new vwgTabPage(objNode);
    }
    else if (objNode.tagName == "WC:Tags.TreeView")
    {
        objComponent = new vwgTreeView(objNode);
    }
    else
    {
        objComponent = new vwgControl(objNode);
    }

    return objComponent;
};
/// </method>