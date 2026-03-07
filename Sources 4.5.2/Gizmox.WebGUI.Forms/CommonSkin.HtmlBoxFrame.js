// Set reference to application
window.mobjApp = window.parent.mobjApp;

var isAccessibilityMode = window.mobjApp.isAccessibilityMode;

// Get the control id
var mstrHtmlBoxId = (window && window.frameElement && window.frameElement.id && window.frameElement.id!="" ? window.frameElement.id.replace("TRG_","") : null);

function HtmlBox_GetId()
{
    return mstrHtmlBoxId;
}

function HtmlBox_GetAttribute(strAttribute,strDefault)
{
    if(mstrHtmlBoxId)
    {
        return mobjApp.Data_GetAttribute(mstrHtmlBoxId,strAttribute,strDefault);
    }
}


function HtmlBox_CreateEvent(strType,strTarget,blnUnique,blnTypeOnlyUnique)
{
    if(mstrHtmlBoxId)
    {
        return mobjApp.Events_CreateEvent(mstrHtmlBoxId,strType,strTarget,blnUnique,blnTypeOnlyUnique);
    }
}

function HtmlBox_SetEventAttribute(objEvent,strName,strValue,blnIsElement)
{
    mobjApp.Events_SetEventAttribute(objEvent,strName,strValue,blnIsElement);
}

function HtmlBox_RaiseEvents()
{
    mobjApp.Events_RaiseEvents();
}

function HtmlBox_AttachOnSubmit(fncCallback)
{
    if(mstrHtmlBoxId)
    {
        mobjApp.Events_AttachOnSubmit(mstrHtmlBoxId,fncCallback);
    }
}

function HtmlBox_DetachOnSubmit()
{   
    if(mstrHtmlBoxId)
    {
	    mobjApp.Events_DetachOnSubmit(mstrHtmlBoxId);
	}
}

/// <method name="HtmlBox_DoExecute">
/// <summary>
/// Executes a richtextbox command(used by the server control)
/// </summary>
/// <param name="strGuid">The component id.</param>
/// <param name="strCommand">The command to be executed.</param>
/// <param name="strParamA">The first command parameter.</param>
/// <param name="strParamB">The second command parameter.</param>
function HtmlBox_DoExecute(objParam1,objParam2,objParam3)
{
    if(mfncExecuter)
    {
        mfncExecuter(objParam1,objParam2,objParam3);
    }
}

var mfncExecuter = null;

function HtmlBox_SetExecuter(fncExecuter)
{
    mfncExecuter = fncExecuter;
}

function HtmlBox_ClearExecuter()
{
    mfncExecuter = null;
}