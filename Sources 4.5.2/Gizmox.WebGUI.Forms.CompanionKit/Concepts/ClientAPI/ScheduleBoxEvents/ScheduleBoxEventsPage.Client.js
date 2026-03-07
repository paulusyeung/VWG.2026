//Global array, which contains all events
var objEvents = [];

/// <method name="addEvent" access="private">
/// <summary>
/// Adds new event to schedule
/// </summary>
function addEvent(lngStartDateTicks, lngEndDateTicks) {
    //Getting component objects by ClientId
    var objScheduleBox = vwgContext.provider.getComponentByClientId("schedule");
    var objColorCombo = vwgContext.provider.getComponentByClientId("color");    
    var objSubjectTextBox = vwgContext.provider.getComponentByClientId("subject");
    var objTagTextBox = vwgContext.provider.getComponentByClientId("tag");

    //Getting all needed values for new event
    var strSubject = objSubjectTextBox.text();
    var strBackgroundColor = objColorCombo.text();
    var strTag = objTagTextBox.text();
    var datStartDate = convertTicksToDate(lngStartDateTicks);
    var datEndDate = convertTicksToDate(lngEndDateTicks);

    //Adding new event and updating ScheduleBox
    objEvents.push({ subject: strSubject, background: strBackgroundColor, startDate: datStartDate, endDate: datEndDate, tagName: strTag });
    objScheduleBox.dataSource(objEvents);
    objScheduleBox.update();
}
/// </method>

/// <method name="updateSchedule" access="private">
/// <summary>
/// Updates schedule's source
/// </summary>
function updateSchedule(strViewType) {
    //Getting object of ScheduleBox component
    var objScheduleBox = vwgContext.provider.getComponentByClientId("schedule");

    //Sets view type
    objScheduleBox.view(strViewType);

    //Updating source of ScheduleBox component
    objScheduleBox.dataSource(objEvents);
    objScheduleBox.update();
}
/// </method>

/// <method name="convertTicksToDate" access="private">
/// <summary>
/// Function for getting Date object from ticks
/// </summary>
function convertTicksToDate(lngTicks) {
    //Trying to convert ticks to Date
    try {
        var datTimeObject = new Date((lngTicks - 621355968000000000) / 10000);
        return datTimeObject;
    }
    catch (Err) {
        // On Error, returns error message string
        return "Invalid input data";
    }
}
/// </method>

