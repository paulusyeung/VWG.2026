var mstrControlId		= "";
var mstrControlHtml		= "";


function RichTextBox_Initialize()
{
    // This check is due to an IE10 bug where the window.parent == this.
    // It happens in a specific scenario documented in issue VWG-84411
    // The cause of the issue is not fully known, but defending against it solves the problem
    if (window.parent.mobjApp)
    {
        // Set reference to application
        window.mobjApp = window.parent.mobjApp;

        // Get the control id
        mstrControlId = mobjApp.Web_GetQueryStringParam(document.location.href, "id");

        // Get control data node
        var objNode = mobjApp.Data_GetNode(mstrControlId);

        // Get the control html
        mstrControlHtml = mobjApp.Aux_DecodeText(mobjApp.Xml_GetAttribute(objNode, "Attr.Source", ""), true);

        // Get the Enabled attribute.
        var blnIsDisabled = (mobjApp.Data_GetNodeAttribute(objNode, "Attr.Enabled", "1") == "0");

        // Get the read only attribute.
        var blnIsReadOnly = (mobjApp.Data_GetNodeAttribute(objNode, "Attr.ReadOnly", "0") == "1");

        // Set inner html
        var objDocument = RichTextBox_GetDocument();

        if (objDocument)
        {
            //Define default class 
            objDocument.body.className = "RichTextBox-Body";

            // Check if browser does not support scrollbars.
            if (!mobjApp.Web_SupportsMISCBrowserCapability(512))
            {
                //Add -webkit-overflow-scrolling support
                objDocument.body.className += " RichTextBox_NonScrollBarSupport";
            }


            if (!mobjApp.mcntIsIE)
            {
                objDocument.designMode = ((blnIsReadOnly || blnIsDisabled) ? "off" : "on");
            }
            else
            {
                objDocument.body.contentEditable = ((blnIsReadOnly || blnIsDisabled) ? "false" : "true");
            }
        }

        mobjApp.Web_SetInnerHtml(objDocument.body, mstrControlHtml);

        if (blnIsDisabled)
        {
            objDocument.body.className += " RichTextBox-Body_Disabled";
        }

        // Get the word wrap mode attribute.
        var blnWordWrap = !(mobjApp.Data_GetNodeAttribute(objNode, "Attr.WordWrap", "0") == "0");

        // Set the word wrap mode.
        RichTextBox_SetWordWrap(objDocument, blnWordWrap);

        mobjApp.Events_AttachOnSubmit(mstrControlId, RichTextBox_OnSubmit);
    }
}

function RichTextBox_Blur() {

    if (mobjApp.Data_IsCriticalEvent(mstrControlId, "Event.ValueChange")) {
        RichTextBox_Save(true);
    }
}

function RichTextBox_OnSubmit()
{
	RichTextBox_Save(false);
}


function RichTextBox_Terminate()
{
	mobjApp.Events_DetachOnSubmit(mstrControlId);
}


function RichTextBox_GetDocument() 
{
	return document;
}

function RichTextBox_GetSelection() 
{
	var objDocument = RichTextBox_GetDocument();
	if(objDocument && objDocument.selection)
	{
		return objDocument.selection.createRange();
	}
}

function RichTextBox_Execute(strCommand, strParam1, strParam2) 
{
	try
	{
	    // Set focus to window before executing action
	    window.focus();
	    
	    switch(strCommand)
	    {	        
	        case "Print":
	            window.print();
	            break;
            case "Select":
            
                break;
            default:
                var objDocument = RichTextBox_GetDocument();
                if(objDocument)
                {
                    objDocument.execCommand(strCommand, strParam1, strParam2);
                }
            break;
	    }

	}
	catch(e)
	{
		alert(e.description);
	}
}

function RichTextBox_Save(blnForce)
{

	var objDocument = RichTextBox_GetDocument();
	if(objDocument)
	{
	    var strControlHtml = objDocument.body.innerHTML;
		if(mstrControlHtml!=strControlHtml || blnForce)
		{
			// on the client side. This is left for the developer to handle. 
            mobjApp.Data_SetAttribute(mstrControlId,"Attr.Source",strControlHtml);
                
			// Create event
			var objEvent = mobjApp.Events_CreateEvent(mstrControlId,"ValueChange",null,true);
			
			// Set event text attribuet
			mobjApp.Events_SetEventAttribute(objEvent, "Attr.Text", strControlHtml);			
			
			// Raise event if critical
			if (blnForce) mobjApp.Events_RaiseEvents();

			mobjApp.Events_ProcessClientEvent(objEvent);
			
			// Save last updated html
			mstrControlHtml = strControlHtml;
		}
		
	}
}

function RichTextBox_Bold()				
{ 
	RichTextBox_Execute('Bold', false, null); 
}

function RichTextBox_Italic()				
{ 
	RichTextBox_Execute('Italic', false, null); 
}

function RichTextBox_Underline()				
{ 
	RichTextBox_Execute('Underline', false, null); 
}

function RichTextBox_RemoveFormat()				
{ 
	RichTextBox_Execute('RemoveFormat', false, null); 
}

function RichTextBox_Cut()				
{ 
	RichTextBox_Execute('Cut', false, null); 
}

function RichTextBox_Copy()				
{ 
	RichTextBox_Execute('Copy', false, null); 
}

function RichTextBox_Paste()				
{ 
	RichTextBox_Execute('Paste', false, null); 
}

function RichTextBox_CreateLink()				
{ 
	RichTextBox_Execute('CreateLink', false, null); 
}

function RichTextBox_UnLink()				
{ 
	RichTextBox_Execute('UnLink', false, null); 
}

function RichTextBox_JustifyLeft()				
{ 
	RichTextBox_Execute('JustifyLeft', false, null); 
}

function RichTextBox_JustifyCenter()				
{ 
	RichTextBox_Execute('JustifyCenter', false, null); 
}

function RichTextBox_JustifyRight()				
{ 
	RichTextBox_Execute('JustifyRight', false, null); 
}

function RichTextBox_InsertOrderedList()				
{ 
	RichTextBox_Execute('InsertOrderedList', false, null); 
}

function RichTextBox_InsertUnorderedList()				
{ 
	RichTextBox_Execute('InsertUnorderedList', false, null); 
}

function RichTextBox_Indent()				
{ 
	RichTextBox_Execute('Indent', false, null); 
}

function RichTextBox_Outdent()				
{ 
	RichTextBox_Execute('Outdent', false, null); 
}

/// <method name="RichTextBox_SetWordWrap">
/// <summary>
/// Sets a richtextbox word wrap mode.
/// </summary>
/// <param name="objDocument">The initialized document.</param>
/// <param name="blnWordWrap">The word wrap mode.</param>
function RichTextBox_SetWordWrap(objDocument, blnWordWrap)
{
    if (objDocument)
    {
        if (objDocument.body)
        {
            var objStyle = objDocument.body.style;
            if (objStyle)
            {
                objStyle.wordBreak = "normal";
                objStyle.wordWrap = blnWordWrap ? "break-word" : "";
                objStyle.whiteSpace = blnWordWrap ? "normal" : "nowrap";
            }
        }
    }
}
