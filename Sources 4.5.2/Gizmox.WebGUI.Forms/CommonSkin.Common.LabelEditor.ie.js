/// <method name="LabelEditor_Clear">
/// <summary>
/// Clear edit element.
/// </summary>
function LabelEditor_Clear()
{
    if(mobjLabelEditorWindow)
    {
        // Get the edit input element.
        var objEditElementInput = Web_GetElementById("VWG_LabelEditorInput",mobjLabelEditorWindow);
        if(objEditElementInput)
        {
            // Clear the input's value.
            objEditElementInput.value = "";
        }
    }
}