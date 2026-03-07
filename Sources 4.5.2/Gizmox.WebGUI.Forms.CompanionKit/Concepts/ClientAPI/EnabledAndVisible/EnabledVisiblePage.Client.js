/// <method name="visibleChange" access="private">
/// <summary>
/// Changes Visible property of a objButton
/// </summary>
function visibleChange() {

    //Get client Button
    var objButton = vwgContext.provider.getComponentByClientId("btn");

    //Get client VisibleLabel
    var objVisibleLabel = vwgContext.provider.getComponentByClientId("lblVisible");

    //Change Visible property of a Button
    objButton.visible(!objButton.visible());
    objButton.update();

    //change VisibleLabel text
    if (objButton.visible() == true) {
        objVisibleLabel.text("Button is visible");
    }
    else {
        objVisibleLabel.text("Button is invisible");
    }
    objVisibleLabel.update();

}
/// </method>

/// <method name="enabledChange" access="private">
/// <summary>
/// Changes Enabled property of a objButton
/// </summary>
function enabledChange() {

    //Get client Button
    var objButton = vwgContext.provider.getComponentByClientId("btn");

    //Get client EnabledLabel
    var objEnabledLabel = vwgContext.provider.getComponentByClientId("lblEnabled");

    //Change Enabled property of a Button
    objButton.enabled(!objButton.enabled());
    objButton.update();

    //change EnabledLabel text
    if (objButton.enabled() == true) {
        objEnabledLabel.text("Button is enabled");
    }
    else {
        objEnabledLabel.text("Button is disabled");
    }
    objEnabledLabel.update();

}
/// </method>