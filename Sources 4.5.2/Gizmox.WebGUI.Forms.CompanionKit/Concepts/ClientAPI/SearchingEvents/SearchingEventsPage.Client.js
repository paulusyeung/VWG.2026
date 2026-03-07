/// <method name="getEvents" access="private">
/// <summary>
/// Searches events and shows result in textBox. 
/// </summary>
function getEvents(lngStartTicks, lngEndTicks) {    
    //Getting objects of components by ClientId
    var objScheduleBox = vwgContext.provider.getComponentByClientId("schedule");
    var objExactRadio = vwgContext.provider.getComponentByClientId("exact");
    var objOutputTextBox = vwgContext.provider.getComponentByClientId("textBox");

    //Getting needed values: events, start and end dates
    var objEvents = objScheduleBox.events();
    var datStartDate = convertTicksToDate(lngStartTicks);
    var datEndDate = convertTicksToDate(lngEndTicks);

    //Searching events and showing result in textBox
    var strOutput = objExactRadio.checked() == 1 ? searchByExact(datStartDate, objEvents) : searchByRange(datStartDate, datEndDate, objEvents);
    strOutput = strOutput == "" ? "Sorry, but no events was not found with current conditions. Try to use other dates." : strOutput;
    objOutputTextBox.text(strOutput);
    objOutputTextBox.update();
}
/// </method>

/// <method name="searchByRange" access="private">
/// <summary>
/// Searches events by range of dates
/// </summary>
function searchByRange(datStartDate, datEndDate, objEvents) {
    //Output string declaration
    var strOutputData = "";
    //Passing through all events
    for (var i = 0; i < objEvents.length; i++) {
        //If year's value of event is in range of specified dates, go further 
        if (objEvents[i].startDate().getFullYear() >= datStartDate.getFullYear() && objEvents[i].endDate().getFullYear() <= datEndDate.getFullYear()) {
            //If month's value of event's in range of specified dates, go further 
            if (objEvents[i].startDate().getMonth() >= datStartDate.getMonth() && objEvents[i].endDate().getMonth() <= datEndDate.getMonth()) {
                //If day's value of event's in range of specified dates, go further 
                if (objEvents[i].startDate().getDate() >= datStartDate.getDate() && objEvents[i].endDate().getDate() <= datEndDate.getDate()) {
                    //Fills output string with data
                    strOutputData += "********************************\r\n"
                    + "Subject:" + objEvents[i].subject() + "\r\n"
                    + "StartDate:" + objEvents[i].startDate() + "\r\n"
                    + "EndDate:" + objEvents[i].endDate() + "\r\n\r\n";
                }
            }
        }

    }
    //returns output string
    return strOutputData;
}
/// </method>

/// <method name="searchByExact" access="private">
/// <summary>
/// Searches events by exact date
/// </summary>
function searchByExact(datExactDate, objEvents) {
    //Output string declaration
    var strOutputData = "";
    //Passing through all events
    for (var i = 0; i < objEvents.length; i++) {
        //If year's value of specified date equals year's value of event, go further
        if (datExactDate.getFullYear() == objEvents[i].startDate().getFullYear()) {
            //If month's value of specified date equals month's value of event, go further
            if (datExactDate.getMonth() == objEvents[i].startDate().getMonth()) {
                //If day's value of specified date equals day's value of event, go further
                if (datExactDate.getDate() == objEvents[i].startDate().getDate()) {
                    //Fills output string with data
                    strOutputData += "********************************\r\n"
                    + "Subject:" + objEvents[i].subject() + "\r\n"
                    + "StartDate:" + objEvents[i].startDate() + "\r\n"
                    + "EndDate:" + objEvents[i].endDate() + "\r\n\r\n";
                }
            }
        }
    }
    //returns output string
    return strOutputData;
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