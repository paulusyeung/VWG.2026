/// <method name="closeSelectedTabPage" access="private">
/// <summary>
/// Close selected tabPage and shows on label count of pages which left
/// </summary>
function closeSelectedTabPage() {
    //Getting objects of components
    var objTabControl = vwgContext.provider.getComponentByClientId("tab");
    var objCountLabel = vwgContext.provider.getComponentByClientId("countLabel");

    //Gets index of selected tabPage
    var intPageIndex = objTabControl.selectedIndex();

    //If index not -1, then remove page and update tabControl
    if (intPageIndex != -1) {
        objTabControl.removeChild(objTabControl.tabPages()[intPageIndex]);
        objTabControl.update();
    }

    //Selecting first tabPage if tabPages exist
    if (objTabControl.tabPages().length > 0) {
        objTabControl.selectedIndex(0);
    }

    //Show count tabPages 
    objCountLabel.text(objTabControl.tabPages().length + " page(s) left");
    objCountLabel.update();
}
/// </method>