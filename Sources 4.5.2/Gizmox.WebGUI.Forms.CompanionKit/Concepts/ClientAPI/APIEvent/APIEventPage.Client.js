/// <method name="raiseCustomEvent" access="private">
/// <summary>
/// Raise custom event
/// </summary>
function raiseCustomEvent() {
    //Getting objects of controls
    var objComboBox = vwgContext.provider.getComponentByClientId("combo");
    var objLabel = vwgContext.provider.getComponentByClientId("label");
    var objForm = vwgContext.provider.getComponentByClientId("form");
    //Getting event's arguments
    var objEventArgs = vwgContext.events.eventArgs();

    //Creating and filling attributes
    var objAttributes = {};
    objAttributes.index = objEventArgs.VLB;
    objAttributes.text = objComboBox.text();

    //Creating, registering and raising event
    vwgContext.events.performClientEvent(objForm.id(), "customEvent", objAttributes, true);
    vwgContext.events.raiseEvents();
}
/// </method>