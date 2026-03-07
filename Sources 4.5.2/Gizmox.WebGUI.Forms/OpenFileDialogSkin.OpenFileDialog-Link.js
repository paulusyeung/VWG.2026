/// <method name="OpenFileDialog_ShowHideProgress">
/// <summary>
/// 
/// </summary>
function OpenFileDialog_ShowHideProgress(strID, blnShow)
{
    // Get the containing panel
    var objProgressPanel = vwgContext.provider.getComponentByClientId("VWGOpenFileDialogPanel" + strID);

    if (objProgressPanel)
    {
        objProgressPanel.dock("F"); // Fill

        // Change z-index to show/hide the progress panel
        if (blnShow)
        {
            objProgressPanel.visible(true);
        }
        else
        {
            objProgressPanel.visible(false);
        }
    }
    objProgressPanel.update();
}
/// </method>

/// <method name="OpenFileDialog_ShowHideProgress">
/// <summary>
/// 
/// </summary>
function OpenFileDialog_UpdateProgress(strID, intFileProgress, intTotalProgress)
{
    // Get references to all relevant components
    var objProgressPanel = vwgContext.provider.getComponentByClientId("VWGOpenFileDialogPanel" + strID);
    var objFileProgress = vwgContext.provider.getComponentByClientId("FileProgress_" + strID);
    var objTotalProgress = vwgContext.provider.getComponentByClientId("TotalProgress_" + strID);
    var objFileLabel = vwgContext.provider.getComponentByClientId("FileLabel_" + strID);

    if (objProgressPanel && objFileProgress && objTotalProgress && objFileLabel)
    {
        objFileProgress.property("Precent", intFileProgress + "");
        objTotalProgress.property("Precent", intTotalProgress + "");
        objFileLabel.text("Overall file progress: " + intFileProgress + "%");

        // Update the whole panel
        objProgressPanel.update();
    }
}
/// </method>

/// <method name="OpenFileDialog_ShowHideProgress">
/// <summary>
/// 
/// </summary>
function OpenFileDialog_SetUploadMessage(strID, strMessage, blnUpdate)
{
    var objTotalLabel = vwgContext.provider.getComponentByClientId("TotalLabel_" + strID);

    if (objTotalLabel)
    {
        objTotalLabel.text(strMessage);

        if (blnUpdate)
        {
            var objProgressPanel = vwgContext.provider.getComponentByClientId("VWGOpenFileDialogPanel" + strID);
            if (objProgressPanel)
            {
                objProgressPanel.update();
            }
        }
    }
}
/// </method>

/// <method name="OpenFileDialog_ShowHideProgress">
/// <summary>
/// 
/// </summary>
function OpenFileDialog_ShowHideProgressMessage(strID, blnShow)
{
    var objFileLabel = vwgContext.provider.getComponentByClientId("FileLabel_" + strID);
    if (objFileLabel)
    {
        objFileLabel.visible(blnShow);
        objFileLabel.update();
    }
}
/// </method>
