/// <page name="Dialog.js">
/// <summary>
/// This script is used as a shared script for dialogs.
/// </summary>

/// <parameters>
/// <summary>
/// Constants parameters
/// </summary>
var mcntIsMozilla					= (document.all==null);
/// </parameters>

/// <parameters>
/// <summary>
/// Global parameters
/// </summary>
/// <param name="Common"></param>	
var mobjApp = null;		// Reference to top window
var vwgApp;             // Reference to non obscured window.
var mintKeepConnected	= 0;		// Interval keep connected handle
var mobjParentWindow				= null;
var mstrWindowGuid				= null;
var mblnIsModeless		= false;
var mobjOwnedWindows	= {};	
var mobjContentControl	= null;
var mblnDebugMode		= false;
var mblnCalculateSizeMode = false;
var mintDialogResizeHandle = 0;	// Handle the resize event
var mblnCanClose		= false;
var blnIsWindowSized	= false;
var mblnPerformFormUnloading = true;
/// </parameters>

/// <summary>
/// Prevent IE from showing the browser help
/// </summary>
document.onhelp = function(){return false};

/// <namespace name="Dialog">
/// <summary>
/// Namespace for all dialog methods
/// </summary>
var Dialog = {};
/// </namespace>

function Web_OnError(strMsg,strUrl,strLine)
{
   return !mblnDebugMode;
}

/// <method name="$">
/// <summary>
/// 
/// </summary>
/// <param name="strId"></param>
function $$() 
{ 
    if(arguments.length==1)
    {
        return document.getElementById(arguments[0]); 
    }
    else if(arguments.length>1)
    {
        var arrElements = [];
        for(var intIndex=0;intIndex<arguments.length;intIndex++)
        {
            arrElements.push(document.getElementById(arguments[intIndex]));
        }
        return arrElements;
    }
    else
    {
        return null;
    }
}  
/// </method>

/// <method name="Dialog_InitializeDialog">
/// <summary>
/// initializes the dialog window
/// </summary>
/// <param name="objDocument"></param>
function Dialog_InitializeDialog()
{
	
	var objArguments = window.dialogArguments;
	if(!objArguments)
	{
		objArguments = window.frameElement.args;
	}
	
	// Set local variables	
	mobjApp = objArguments.mobjApp;

	mobjParentWindow	= objArguments.mobjParentWindow;
	mstrWindowGuid		= objArguments.mstrWindowGuid;
	mblnIsModeless		= objArguments.mblnIsModeless;
	blnIsWindowSized	= objArguments.blnIsWindowSized;

	try
	{
		// Register current form
	    mobjApp.Forms_RegisterForm(mstrWindowGuid,window,mobjParentWindow);
	}
	catch(e)
	{
	}
	
	if(!mobjApp.mblnInlineWindows)
	{
		// If forms offset was not calculated yet
		if(!mobjApp.mobjFormsOffsetFound)
		{
			// Calculate form offset
			var intOffsetW = (parseInt(dialogWidth)-document.body.clientWidth);
			var intOffsetH = (parseInt(dialogHeight)-document.body.clientHeight);
			
			// Disable resize event
			mblnCalculateSizeMode = true;
			
			if(!blnIsWindowSized)
			{
				// Fix current form on the fly
				dialogWidth = (parseInt(dialogWidth)+intOffsetW)+"px";
				dialogHeight= (parseInt(dialogHeight)+intOffsetH)+"px";
			}
			
			// Enable resize event
			mblnCalculateSizeMode = false;
			
			// Save form offset for other window openinig
			mobjApp.mobjFormsOffsetFound			= true;
			mobjApp.mintFormsOffsetW				= intOffsetW;
			mobjApp.mintFormsOffsetH				= intOffsetH;
			mobjApp.mintFormsOffsetX				= parseInt(dialogLeft) - parseInt(window.screenLeft);
			mobjApp.mintFormsOffsetY				= parseInt(dialogTop) - parseInt(window.screenTop);
		}
	}
	
	window.onerror = Web_OnError;
	window.onmoveend = Dialog_Move;

	mblnDebugMode = mobjApp.mblnDebugMode;

	document.title = objArguments.Title;

	// set document direction
	document.body.dir = mobjApp.document.body.dir;
	
	try
	{
		
		// Get the form data node
		var objData = mobjApp.Data_GetNode(mstrWindowGuid);
		if(objData)
		{	
			mobjContentControl = objData;
	
			// Attach form events
			mobjApp.Web_AttachEvents(document);
			
			// Sets the active form with event registering
			mobjApp.Forms_SetActiveFormById(mstrWindowGuid,true);

			// Sets the active window (the one that can be used for setTimeout or XMLHttp request).
			mobjApp.Web_SetActiveWindow(window);
			
			// Set timeout for content initialization
			setTimeout("Dialog_InitializeContent()", 1);
		}
	}
	catch(e)
	{
		alert(e.description);
	}

	mobjApp.Common_ApplyAccessibilityFeatures(document.body);
}
/// </method>
function Dialog_InitializeContent()
{
	// Draw dialog.
	mobjApp.Controls_DrawControl(window,mobjContentControl,true,document.getElementById("VWG_BodyContent"));
	
	// Set the this dialog initialization status to initialized.
    mobjApp.Forms_SetDialogInitializationStatus(mstrWindowGuid,true);
    
	// Load forms sub forms
	mobjApp.Forms_LoadForms(mstrWindowGuid,window);	

    // Check if current dialog is modal.
    if(mobjApp.Data_IsAttribute(mobjApp.Data_GetDataId(mstrWindowGuid),"Attr.Type","ModalWindow"))	
    {
	    // Process the current response
        mobjApp.Forms_HandleResponse();

        // Simulate initialization.
	    Events_SimulationInitialize();
	}
}

/// <method name="DialogClick">
/// <summary>
/// Manage dialog focus
/// </summary>
function Dialog_Click()
{
}
/// </method>

var mblnDialogProcessingTerminated = false;

/// <method name="Dialog_BeforeUnload">
/// <summary>
/// 
/// </summary>
function Dialog_BeforeUnload()
{   
    // If is in processing mode
    if(mobjApp.Events_IsProcessing())
    {
        // Stop processing
	    mobjApp.Events_StopProcessing();
	    
	    // Set terminated flag
	    mblnDialogProcessingTerminated = true;
    }
}
/// </method>

/// <method name="Dialog_UnloadDialog">
/// <summary>
/// Unloads the dialog window
/// </summary>
function Dialog_UnloadDialog()
{
	Events_SimulationTerminate();
	
	// Clean applets
	mobjApp.Common_CleanApplets(document.applets);
	
	// Clean ActiveX
    mobjApp.Common_CleanApplets(document.getElementsByTagName("OBJECT"));
	
	// Clear keep contexted interval
	clearInterval(mintKeepConnected);
	
	// Removes current window from active windows
	mobjApp.Web_RemoveActiveDialogWindow(window);
	
	// Deatach form events
	mobjApp.Web_DeAttachEvents(document);
	
	// Check if form should be unloaded.
	if(mblnPerformFormUnloading)
	{
	    // If not reload or server close
	    if((!mobjApp.mblnFormsIsReload && !mobjApp.Events_IsServerClosed(window))||mblnDialogProcessingTerminated)
	    {
		    // Call unload form handler with event
		    mobjApp.Forms_CloseForm(mstrWindowGuid,false);
	    }
	    else
	    {
		    // Call unload form handler without event
	        mobjApp.Forms_CloseForm(mstrWindowGuid, true);
	    }
	}
}
/// </method>

/// <method name="Dialog_Resize">
/// <summary>
/// 
/// </summary>

function Dialog_Resize()
{	
	if(!mblnCalculateSizeMode)
	{
	    // Hide all popup windows.
	    mobjApp.Popups_HidePopups();

		clearInterval(mintDialogResizeHandle);
		mintDialogResizeHandle = setInterval("Dialog_ResizeEnd()",40);
	}
}
/// </method>

/// <method name="Dialog_ResizeEnd">
/// <summary>
/// 
/// </summary>
function Dialog_ResizeEnd()
{
	clearInterval(mintDialogResizeHandle);
	
	var intWidth = window.document.body.clientWidth;
	var intHeight = window.document.body.clientHeight;
	if(blnIsWindowSized)
	{
		intWidth+=mobjApp.mintFormsOffsetW;
		intHeight+=mobjApp.mintFormsOffsetH;
	}
	
	mobjApp.Forms_OnMove(mstrWindowGuid,window.screenLeft,window.screenTop,true,true,true);
	mobjApp.Forms_OnResize(mstrWindowGuid,intWidth,intHeight,true);
	
	// Raise events.
	mobjApp.Events_RaiseEvents();
}
/// </method>

/// <method name="Dialog_Move">
/// <summary>
/// 
/// </summary>
function Dialog_Move()
{
	clearInterval(mintDialogResizeHandle);
	mintDialogResizeHandle = setInterval("Dialog_MoveEnd()",40);
}
/// </method>

/// <method name="Dialog_MoveEnd">
/// <summary>
/// 
/// </summary>
function Dialog_MoveEnd()
{
	clearInterval(mintDialogResizeHandle);

	var intTop = parseInt(window.screenTop);
	var intLeft = parseInt(window.screenLeft);
	
	mobjApp.Forms_OnMove(mstrWindowGuid,intLeft,intTop,true,false);
}
/// </method>

/// <method name="Common_GetGuid">
/// <summary>
/// 
/// </summary>
function Common_GetGuid()
{
	return mstrWindowGuid;
}
/// </method>

[Skin.WebSetStyleFunction]

/// </page>