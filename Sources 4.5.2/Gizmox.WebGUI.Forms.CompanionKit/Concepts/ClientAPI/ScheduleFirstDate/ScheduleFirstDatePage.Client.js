/// <method name="navigateDate" access="private">
/// <summary>
/// Changes current FirstDate of ScheduleBox to +1 or -1 day depending on strDelta
/// </summary>
function navigateDate(strDelta) {
    
    //Get client ScheduleBox
    var objScheduleBox = vwgContext.provider.getComponentByClientId("schedule");
    
    //Get current FirstDate of ScheduleBox
    var objDateNow = objScheduleBox.firstDate();

    //Parse strDelta to int
    var intDelta = parseInt(strDelta);

    //Change objDateNow value to +1 or -1 day depending on intDelta
    objDateNow.setDate(objDateNow.getDate() + intDelta);

    //Set new FirstDate value
    objScheduleBox.firstDate(objDateNow);
    objScheduleBox.update();
}
/// </method>