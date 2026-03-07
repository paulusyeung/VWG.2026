/// <method name="showLoadingIcon" access="private">
/// <summary>
/// Shows icon until timeout is not reached
/// </summary>
function showLoadingIcon() {

    //Getting object of numericUpDown component
    var objNumericUpDown = vwgContext.provider.getComponentByClientId("nud");

    //Getting value of numericUpDown and converting to milliseconds format
    var intSeconds = objNumericUpDown.value() * 1000;

    //Starting to show icon
    vwgContext.showMask();

    //Hiding icon after timeout with defined duration
    setTimeout(function () { vwgContext.hideMask(); }, intSeconds);
}
/// </method>