

/// <method name="RichTextBox_Execute">
/// <summary>
/// Executes a richtextbox command(used by the server control)
/// </summary>
/// <param name="strGuid">The component id.</param>
/// <param name="strCommand">The command to be executed.</param>
/// <param name="strParamA">The first command parameter.</param>
/// <param name="strParamB">The second command parameter.</param>
function RichTextBox_Execute(strGuid,strCommand,strParamA,strParamB)
{
    // Get IFrame contained with in element
    var objIFrame = Web_GetTargetElementByDataId(strGuid);
    if(objIFrame)
    {   
        // Check that iframe method is found
        if(objIFrame.contentWindow.RichTextBox_Execute)
        {
            // Assign control to the richtextbox frame script
            objIFrame.contentWindow.RichTextBox_Execute(strCommand,strParamA,strParamB);
        }
    }
}
/// </method>