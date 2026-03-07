
/// <method name="FrameControl_Print">
/// <summary>
/// Prints the frame control
/// </summary>
/// <param name="strGuid">The component id.</param>
function FrameControl_Print(strGuid)
{
    var objElement = Web_GetElementByDataId(strGuid);
    if(objElement)
    {
        var objIFrame = Web_GetContextElementById(objElement,"TRG_"+strGuid);
        if(objIFrame)
        {
            objIFrame.contentWindow.print();
        }
    }
}
/// </method>

/// <method name="FrameControl_Execute">
/// <summary>
/// Executes a richtextbox command(used by the server control)
/// </summary>
/// <param name="strGuid">The component id.</param>
/// <param name="strCommand">The command to be executed.</param>
/// <param name="strParamA">The first command parameter.</param>
/// <param name="strParamB">The second command parameter.</param>
function FrameControl_Execute(strGuid,objParam1,objParam2,objParam3)
{
    // Get IFrame contained with in element
    var objIFrame = Web_GetTargetElementByDataId(strGuid);
    if(objIFrame)
    {   
        // Check that iframe method is found
        if(objIFrame.contentWindow.HtmlBox_DoExecute)
        {
            // Assign control to the richtextbox frame script
            objIFrame.contentWindow.HtmlBox_DoExecute(objParam1,objParam2,objParam3);
        }
    }
}
/// </method>

/// <method name="FrameControl_SetUrl">
/// <summary>
/// 
/// </summary>
/// <param name="strGuid">The component id.</param>
/// <param name="strUrl">The required url.</param>
function FrameControl_SetUrl(strGuid,strUrl)
{
    if(strGuid && strUrl)
    {
        // Get IFrame contained with in element
        var objIFrame = Web_GetTargetElementByDataId(strGuid);
        if(objIFrame)
        {   
            objIFrame.src = strUrl;
        }
    }
}
/// </method>