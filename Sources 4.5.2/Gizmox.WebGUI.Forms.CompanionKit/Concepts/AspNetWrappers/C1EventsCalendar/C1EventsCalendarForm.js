/// <method name="viewTypeChanged" access="private">
/// <summary>
/// Raise custom event
/// </summary>
function viewTypeChanged() {
    //Get the value of current ViewType property of c1 events calendar
    var returnsValue = $('#hosted_control_id').c1eventscalendar('option', 'viewType');
    var objVwgWindow = vwg_pipeline_getMainWindow();
    //Get Label
    var objLabel = objVwgWindow.vwgContext.provider.getComponentByClientId("lollabel");
    //Set new Label text
    objLabel.text("ViewType: " + returnsValue);
    objLabel.update();
}
/// </method>