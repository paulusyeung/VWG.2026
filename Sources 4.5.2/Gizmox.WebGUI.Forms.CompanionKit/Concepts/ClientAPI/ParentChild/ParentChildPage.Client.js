/// <method name="sendCheckedControls" access="private">
/// <summary>
/// Changes parent control of checked controls
/// </summary>
function sendCheckedControls(strSourceId, strDestinationId) {
    //Getting objects of panels
    var objSourcePanel = vwgContext.provider.getComponentById(strSourceId);
    var objDestinationPanel = vwgContext.provider.getComponentById(strDestinationId);
    //Getting controls array
    var objControlArray = objSourcePanel.controls();
    //For each control in array...
    for (var i = 0; i < objControlArray.length; i++) {
        //If control checked, then go further
        if (objControlArray[i].checked()) {
            //Remove checked control from old panel and add to the new one. After that - update panels.
            objSourcePanel.removeChild(objControlArray[i]);
            objSourcePanel.update();
            objDestinationPanel.addChild(objControlArray[i]);
            objDestinationPanel.update();
        }
    }
}
/// </method>