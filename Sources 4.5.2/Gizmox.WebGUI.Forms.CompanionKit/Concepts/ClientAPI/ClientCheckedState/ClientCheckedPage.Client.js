/// <method name="setLabelText" access="private">
/// <summary>
/// Setting value of Checked state to Label's text. 
/// </summary>
function setLabelText() {
    // Getting objects of checkBox and label by using vwgProvider static class
    var objCheckBox = vwgContext.provider.getComponentByClientId("checkBox");
    var objLabel = vwgContext.provider.getComponentByClientId("label");

    //Getting checked state from checkbox and representing on a label
    var strState = objCheckBox.checked() ? "true" : "false";
    objLabel.text(strState);
    objLabel.update();
}
/// </method>