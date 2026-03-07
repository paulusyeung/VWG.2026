/// <method name="setDockStyle" access="private">
/// <summary>
/// Setting dock style. 
/// </summary>
function setDockStyle(strDockStyle) {
    //Getting object of label by using vwgProvider static class
    var objLabel = vwgContext.provider.getComponentByClientId("label");

    //Applying dock type to label component.
    objLabel.dock(strDockStyle);
    objLabel.update();
}
/// </method>