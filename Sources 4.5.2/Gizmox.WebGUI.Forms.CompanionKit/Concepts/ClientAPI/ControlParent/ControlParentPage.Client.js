/// <method name="showParent" access="private">
/// <summary>
/// Fills appropriate panel with color
/// </summary>
function showParent() {

    //Get client labels
    var objLabel1 = vwgContext.provider.getComponentByClientId("l1");
    var objLabel2 = vwgContext.provider.getComponentByClientId("l2");
    var objLabel3 = vwgContext.provider.getComponentByClientId("l3");

    //Get client panels
    var objPanel1 = vwgContext.provider.getComponentByClientId("p1");
    var objPanel2 = vwgContext.provider.getComponentByClientId("p2");
    var objPanel3 = vwgContext.provider.getComponentByClientId("p3");

    //Get client ComboBox
    var objComboBox = vwgContext.provider.getComponentByClientId("cb");

    //Get ControlParentPage UserControl
    var objUserControl = vwgContext.provider.getComponentByClientId("uc");

    //Selected label
    var objSelectedLabel;

    //Get currently selected index in ComboBox
    var objSelectedIndex = objComboBox.selectedIndex();

    //Set backColor for all panels to avoid multiple parent showing
    objPanel1.backColor("white");
    objPanel2.backColor("white");
    objPanel3.backColor("white");
    objUserControl.update();

    //Define currently selected label
    if (objSelectedIndex == 0) {
        objSelectedLabel = objLabel1;
    }
    if (objSelectedIndex == 1) {
        objSelectedLabel = objLabel2;
    }
    if (objSelectedIndex == 2) {
        objSelectedLabel = objLabel3;
    }

    //Get selected label's parent and change its backColor
    objSelectedLabel.parent().backColor("#FFD4FF");
    objSelectedLabel.parent().update();

}
/// </method>