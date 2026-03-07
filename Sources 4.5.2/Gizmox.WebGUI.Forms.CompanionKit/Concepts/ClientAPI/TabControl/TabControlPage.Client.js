/// <method name="currentSelectedTabPage" access="private">
/// <summary>
/// Displays index of currently selected TabPage on label 
/// </summary>
function currentSelectedTabPage() {
    //Getting objects of components
    var objTabControl = vwgContext.provider.getComponentByClientId("tab");
    var objIndexLabel = vwgContext.provider.getComponentByClientId("indexLabel");

    //Show index of currently selected TabPage on label 
    objIndexLabel.text("Index of selected tabPage:" + objTabControl.selectedIndex().toString());
    objIndexLabel.update();
}
/// </method>