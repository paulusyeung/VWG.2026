var mstrDataId;
var mblnFakeSubmit = false;

/// <method name="vwg_pipeline_onsubmit">
/// <summary>
/// Sends the event buffer to the application server.
/// </summary>
function vwg_pipeline_onsubmit()
{
    if (mblnFakeSubmit) { return; }

    // Get main window.
    var objMainWindow = vwg_pipeline_getMainWindow();
    if(objMainWindow && objMainWindow.mobjApp)
    {
        objMainWindow.mobjApp.Events_RaiseEventsThroughForm(document);
    }
}
/// </method>

/// <method name="vwg_pipeline_getMainWindow">
/// <summary>
/// Get the VWG main window.
/// </summary>
function vwg_pipeline_getMainWindow()
{
    var objMainWindow = window;
    
    // Search main window.
    while(objMainWindow && !objMainWindow.mobjApp)
    {
        if(objMainWindow != objMainWindow.parent)
        {
            objMainWindow = objMainWindow.parent;
        }
        else
        {
            objMainWindow = null;
        }
    }
    
    return objMainWindow;
}
/// </method>

/// <method name="vwg_pipeline_onload">
/// <summary>
/// Sends the event buffer to the application server.
/// </summary>
function vwg_pipeline_onload(objDocument)
{
    mblnFakeSubmit = false;

    // Get main window.
    var objMainWindow = vwg_pipeline_getMainWindow();

    // Validate main window.
    if(objMainWindow && objMainWindow.mobjApp)
    {
        // Handle response on main window.
        objMainWindow.mobjApp.Events_HandlesResponseFromForm(objDocument);

        vwg_pipeline_handleSyncVwgPostData();
    }
}
/// </method>

/// <method name="vwg_pipeline_handleSyncVwgPostData">
/// <summary>
/// Handle sync vwg post data.
/// </summary>
function vwg_pipeline_handleSyncVwgPostData() {
    var objMainWindow = vwg_pipeline_getMainWindow();

    // Check if the control should sync changed on raise events. If no we will not register it.
    var objJqVwgForm = objMainWindow.$(vwgForm);
    mstrDataId = objJqVwgForm.find("#vwg_data_id").val();

    // Gets if the control should sync vwg postbacks.
    var blnWatchDirtyMode = vwg_pipeline_getSyncChangesOnVwgPostBackMode(mstrDataId);
    vwg_pipeline_tryWatchPostDataDirty(blnWatchDirtyMode);
}

/// <method name="vwg_pipeline__getSyncChangesOnVwgPostBackMode">
/// <summary>
/// Returns contro synchronize changes in vwg postback (raise events) mode. (Return "Off"/"On"/"None"
/// If the result is "None" it will sync changes onlt if there are input fields in the control.
/// </summary>
function vwg_pipeline_getSyncChangesOnVwgPostBackMode(mstrDataId) {
    var objMainWindow = vwg_pipeline_getMainWindow();

    var objNode = objMainWindow.mobjApp.Data_GetNode(mstrDataId);
    var strResult = objMainWindow.mobjApp.Data_GetAttribute(mstrDataId, "Attr.SyncChangesOnVwgPostBack");

    if (strResult == "0") { return "Off"; }
    if (strResult == "1") { return "On"; }

    return "None";
}
/// </method>

/// <method name="vwg_pipeline_tryWatchPostDataDirty">
/// <summary>
/// Check whether watch dirty for asp control should be performed, and if yes, execute AspControlBoxBase_WatchPostDataDirt
/// </summary>
function vwg_pipeline_tryWatchPostDataDirty(objAspControl, blnWatchDirtyMode) {
    if (blnWatchDirtyMode == "Off") { return; }

    var objMainWindow = vwg_pipeline_getMainWindow();

    // We will execute watch dirty if blnForceWatch is true or if there are input or selects in the form.
    // NOTE: We need the blnForceWatch only for cases there are dynamically input controls added to the form, in this case the user should set a property in the server
    // to force the watch dirty because we cannot know that in the client.
    var blnExecuteWatchDirty = blnWatchDirtyMode == "On" ? true : false;
    if (!blnExecuteWatchDirty) {

        //  Get all input elements in the form without the view state element.
        var objInputElements = objMainWindow.$(vwgForm).find("textarea,input,select [name]");
        var blnInputElementExist = false;
        for (var i = 0; i < objInputElements.length; i++) {
            var name = objMainWindow.$(objInputElements[i]).attr("name");
            if (name && name != '__VIEWSTATE' && name != '__EVENTTARGET' && name != '__EVENTARGUMENT' && name.indexOf("vwg_") < 0) {
                blnInputElementExist = true;
                break;
            }
        }

        if (blnInputElementExist) {
            blnExecuteWatchDirty = true;
        }
    }

    if (!blnExecuteWatchDirty) { return; }

    vwg_pipeline_watchPostDataDirty();
    return true;
}
/// </method>

function vwg_pipeline_watchPostDataDirty(strFormSerialize, strFormSerializeForDirty) {
    var objMainWindow = vwg_pipeline_getMainWindow();

    // NOTE: We must save the strFormSerializeForDirty here (Before the submit) because in case the submit changes the form data, we need to create event for it
    // on initialize. If we would wait to get the strFormSerializeForDirty after the submit the event will not be created on initialize and in Refresh if wont work.
    if (!strFormSerialize) {
        strFormSerialize = objMainWindow.$(vwgForm).serialize();
        strFormSerializeForDirty = vwg_pipeline_getFormSerializeForDirty(strFormSerialize);
    }

    objMainWindow.$(vwgForm).bind("submit", vwg_pipeline_watchPostDataDirtyFakeSubmit);
    mblnFakeSubmit = true;
    try
    {
        objMainWindow.$(vwgForm).submit();
    }
    catch(error)
    {
        // Ignore any exception.
    }
    finally
    {
        mblnFakeSubmit = false;
        objMainWindow.$(vwgForm).unbind("submit", vwg_pipeline_watchPostDataDirtyFakeSubmit);
    }

    function vwg_pipeline_watchPostDataDirtyFakeSubmit(e) {
        window.setTimeout(function () {
            // NOTE: In Unload the objMainWindow.vwgForm becomes undefined, so we should stop the timeout.
            if (!vwgForm){return;}

            strFormSerialize = objMainWindow.$(vwgForm).serialize();
            var strCurrentFormSerializeForDirty = vwg_pipeline_getFormSerializeForDirty(strFormSerialize);

            // If the current form data is different from the previous form data, we will add a post data event for the raise events.
            if (strCurrentFormSerializeForDirty != strFormSerializeForDirty) {
                var objEvent = objMainWindow.mobjApp.Events_CreateEvent(mstrDataId, "SyncVwgChanges", null, true, false);
                objMainWindow.mobjApp.Events_SetEventAttribute(objEvent, "PostData", strFormSerialize);
            }

            strFormSerializeForDirty = strCurrentFormSerializeForDirty;
            vwg_pipeline_watchPostDataDirty(strFormSerialize, strFormSerializeForDirty);
        }, 500);

        e.preventDefault();
        return false;
    }
}

/// <method name="AspControlBoxBase_GetAspFormData">
/// <summary>
/// Returns post data (Without view state) of vwgForm in the asp control.
/// </summary>
function vwg_pipeline_getFormSerializeForDirty(strVwgFormSerialize) {
    var objFormFields = strVwgFormSerialize.split("&");

    var objTempFormFields = objFormFields;
    for (var i = 0; i < objTempFormFields.length; i++) {
        if (objTempFormFields[i].indexOf("__VIEWSTATE") == 0) {
            objFormFields.splice(i, 1);
            break;
        }
    }

    var strResult = objFormFields.join("&");
    return strResult;
}

/// <method name="vwg_pipeline_xhr">
/// <summary>
/// Provides a wrapper class for the xmlhttp request object
/// </summary>
function vwg_pipeline_xhr()
{
    var _context = this;
    
    this._xmlhttp = this._create();
    this._xmlhttp.onreadystatechange = function(){_context._onreadystatechange()};
    this._init();
}
/// </method>

/// <method name="vwg_pipeline_xhr._init">
/// <summary>
/// Initialized the state of the xhr wrapper
/// </summary>
vwg_pipeline_xhr.prototype._init = function()
{
    this.readyState             =   0;
    this.responseText           =   "";
    this.responseXML            =   null;
    this.status                 =   0;
    this.statusText             =   "";
    this.onreadystatechange     = null;
    this._url                   = "";
    this._method                = "GET";
    this._async                 = false;
    this._isPipelineRequest     = false;
};
/// </method>

/// <method name="vwg_pipeline_xhr._sync">
/// <summary>
/// Syncronizes the fields state of the xhr wrapper
/// </summary>
vwg_pipeline_xhr.prototype._sync = function()
{
    try{this.readyState     = this._xmlhttp.readyState;}catch(e){}
    try{this.responseText   = this._xmlhttp.responseText;}catch(e){}
    try{this.responseXML    = this._xmlhttp.responseXML;}catch(e){}
    try{this.status         = this._xmlhttp.status;}catch(e){}
    try{this.statusText     = this._xmlhttp.statusText;}catch(e){}
};
/// </method>

/// <method name="vwg_pipeline_xhr._create">
/// <summary>
/// Creates the original xhr
/// </summary>
vwg_pipeline_xhr.prototype._create = function()
{
    if(vwg_pipeline_xhr._xmlhttprequest!=null)
    {
        return new vwg_pipeline_xhr._xmlhttprequest();
    }
    else
    {
        return new ActiveXObject("Msxml2.XMLHTTP");
    }
};
/// </method>

/// <method name="vwg_pipeline_xhr._onbeforesubmit">
/// <summary>
/// Before the xhr is submited
/// </summary>
vwg_pipeline_xhr.prototype._onbeforesubmit = function()
{
    this._isPipelineRequest = true;
    
    // Get main window.
    var objMainWindow = vwg_pipeline_getMainWindow();
    if(objMainWindow && objMainWindow.mobjApp)
    {
        objMainWindow.mobjApp.Events_RaiseEventsThroughXmlHttp(this._xmlhttp);
    }
};
/// </method>

/// <method name="vwg_pipeline_xhr._onbeforeload">
/// <summary>
/// Before the xhr result is loaded
/// </summary>
vwg_pipeline_xhr.prototype._onbeforeload = function()
{
    if(this._isPipelineRequest)
    {
        this._isPipelineRequest = false;
        
        // Get main window.
        var objMainWindow = vwg_pipeline_getMainWindow();
        if(objMainWindow && objMainWindow.mobjApp)
        {
            objMainWindow.mobjApp.Events_HandlesResponseFromXmlHttp(this._xmlhttp);
        }
    }
};
/// </method>

/// <method name="vwg_pipeline_xhr._onreadystatechange">
/// <summary>
/// Handles the on ready state change of the original xhr
/// </summary>
vwg_pipeline_xhr.prototype._onreadystatechange = function()
{
    this._sync();
    
    // If is an async request
    if(this._async)
    {
        // if the response is ready
        if(this.readyState==4)
        {
            // Call the before load handler
            this._onbeforeload();    
        }
    }
    
    // If there is a handler to the wrapper state change event
    if(this.onreadystatechange)
    {
        this.onreadystatechange();
    }
};
/// </method>

/// <method name="vwg_pipeline_xhr.open">
/// <summary>
/// Proxy to the xhr.open method
/// </summary>
vwg_pipeline_xhr.prototype.open = function(method, url, async, user, password)
{
    this._method = method;
    this._url = url;
    this._async = async;
    this._xmlhttp.open(method, url, async, user, password);
    this._sync();
};
/// </method>



/// <method name="vwg_pipeline_xhr.send">
/// <summary>
/// Proxy to the xhr.send method
/// </summary>
vwg_pipeline_xhr.prototype.send = function(data)
{
    // provides an entry point to do actions before submit
    this._onbeforesubmit();
    
    // Get main window.
    var objMainWindow = vwg_pipeline_getMainWindow();
    if(objMainWindow && objMainWindow.mobjApp)
    {
        // Show the sent string if needed
	    if(objMainWindow.mobjApp.mblnDebugEvents) 
	    {
	        // Build data xml string.
	        var strDataXml = "<PipelineRequest><![CDATA["+data+"]]></PipelineRequest>";
	        
	        // Log request event.
	        objMainWindow.mobjApp.Debug_LogEvent("Events","Request",strDataXml);
	    }
    }
    
    
    // sends the data
    this._xmlhttp.send(data);
    
    // syncronize the fields
    this._sync();
    
    // If the request is not asyncronic on
    if(!this._async)
    {
        // if the response is ready
        if(this.readyState==4)
        {
            // Call the before load handler
            this._onbeforeload();    
        }
    }
    
};
/// </method>

/// <method name="vwg_pipeline_xhr.setRequestHeader">
/// <summary>
/// Proxy to the xhr.setRequestHeader method
/// </summary>
vwg_pipeline_xhr.prototype.setRequestHeader = function(header, value)
{
    this._xmlhttp.setRequestHeader(header, value);
    this._sync();
};
/// </method>

/// <method name="vwg_pipeline_xhr.abort">
/// <summary>
/// Proxy to the xhr.abort method
/// </summary>
 vwg_pipeline_xhr.prototype.abort = function()
{
    this._xmlhttp.abort();
    this._sync();
};
/// </method>

/// <method name="vwg_pipeline_xhr.getAllResponseHeaders">
/// <summary>
/// Proxy to the xhr.getAllResponseHeaders method
/// </summary>
vwg_pipeline_xhr.prototype.getAllResponseHeaders = function()
{
    this._sync();
    return this._xmlhttp.getAllResponseHeaders();
};
/// </method>

/// <method name="vwg_pipeline_xhr.getResponseHeader">
/// <summary>
/// Proxy to the xhr.getResponseHeader method
/// </summary>
vwg_pipeline_xhr.prototype.getResponseHeader = function(header)
{
    this._sync();
    return this._xmlhttp.getResponseHeader(header);
};
/// </method>


// Substitute the original xhr with the wrapper
vwg_pipeline_xhr._xmlhttprequest = window.XMLHttpRequest;
var XMLHttpRequest = vwg_pipeline_xhr;

