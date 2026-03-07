/// <method name="NativeDateTimePicker_OnChange">
/// <summary>
///  Native DateTimePicker value change handler.
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objNode"></param>
/// <param name="intSelectedIndex"></param>
/// <param name="objWindow"></param>
function NativeDateTimePicker_OnChange(strGuid, objInput, objEvent, objWindow)
{
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        var varFormat = Data_GetNodeAttribute(objNode, "Attr.VisualTemplateNativeDateTimePickerFormat", "");
        var blnDate = true;
        var blnTime = false;
        switch (varFormat)
        {
            case "time":
                blnTime = true;
                blnDate = false;
                break;

            case "datetime-local":
                blnTime = true;
                break;
        }

        var strCurreentValue = NativeDateTimePicker_GetNativeValue(objNode, "Attr.DateTime", blnDate, blnTime);
        var strNewDateTimeValue = objInput.value;

        // Check if value changed
        if (strCurreentValue != strNewDateTimeValue)
        {
            var strNewDate = null;
            var strNewTime = null;

            if (blnDate && blnTime)
            {
                var arrDateAndTime = strNewDateTimeValue.split("T");
                strNewDate = arrDateAndTime[0];
                strNewTime = arrDateAndTime[1];
            }
            else if (blnDate)
            {
                strNewDate = strNewDateTimeValue;
            }
            else if (blnTime)
            {
                strNewTime = strNewDateTimeValue;
            }

            var strCurrentTicks = Data_GetNodeAttribute(objNode, "Attr.DateTime", "");
            var datNewDate = Web_GetDateFromTicks(parseFloat(strCurrentTicks));

            if (strNewDate)
            {
                // Update Date
                var arrNewDateValue = strNewDate.split('-');

                datNewDate.setFullYear(parseInt(arrNewDateValue[0]));
                datNewDate.setMonth(parseInt(arrNewDateValue[1]) - 1);
                datNewDate.setDate(parseInt(arrNewDateValue[2]));
            }

            if (strNewTime)
            {
                // Update Time
                var arrNewTimeValue = strNewTime.split(':');

                datNewDate.setHours(parseInt(arrNewTimeValue[0]));
                datNewDate.setMinutes(parseInt(arrNewTimeValue[1]));
                if (arrNewTimeValue[2])
                {
                    datNewDate.setSeconds(parseInt(arrNewTimeValue[2]));
                }
            }

            // Get the updated datetime ticks.
            var lngUpdatedDateTimeTicks = Web_GetTicksFromDate(datNewDate);

            // Update meta data date time value.
            Data_SetNodeAttribute(objNode, "Attr.DateTime", lngUpdatedDateTimeTicks);

            // Fire the value change event.
            Events_ValueChange(strGuid, lngUpdatedDateTimeTicks, Data_IsCriticalEvent(objNode, "Event.ValueChange", true));

        }
    }
}
/// </method>

/// <method name="NativeDateTimePicker_Init">
/// <summary>
/// Init datetime picker value min value and max value
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objWindow"></param>
function NativeDateTimePicker_Init(strGuid, objWindow)
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGuid))
    {
        // Get data node
        var objNode = Data_GetNode(strGuid);
        {
            // Get input element
            var objInput = Web_GetElementById("TRG_" + strGuid, objWindow);
            if (objInput)
            {
                var varFormat = Data_GetNodeAttribute(objNode, "Attr.VisualTemplateNativeDateTimePickerFormat", "");
                var blnDate = true;
                var blnTime = false;
                switch (varFormat)
                {
                    case "time":
                        blnTime = true;
                        blnDate = false;
                        break;

                    case "datetime-local":
                        blnTime = true;
                        break;
                }

                // Set initial value
                var strValue = NativeDateTimePicker_GetNativeValue(objNode, "Attr.DateTime", blnDate, blnTime);
                if (!Aux_IsNullOrEmpty(strValue))
                {
                    objInput.value = strValue;
                }

                // Set min value
                strValue = NativeDateTimePicker_GetNativeValue(objNode, "Attr.MinDate", blnDate, blnTime);
                if (!Aux_IsNullOrEmpty(strValue))
                {
                    objInput.min = strValue;
                }

                // Set max value
                strValue = NativeDateTimePicker_GetNativeValue(objNode, "Attr.MaxDate", blnDate, blnTime);
                if (!Aux_IsNullOrEmpty(strValue))
                {
                    objInput.max = strValue;
                }
            }
        }
    }
}
/// </method>

/// <method name="NativeDateTimePicker_GetNativeValue">
/// <summary>
/// return date value from ticks with format yyyy-mm-dd
/// </summary>
/// <param name="objNode"></param>
/// <param name="strAttributeName"></param>
function NativeDateTimePicker_GetNativeValue(objNode, strAttributeName, blnDate, blnTime)
{
    var strNativeDate = "";
    var strValueTicks = Data_GetNodeAttribute(objNode, strAttributeName, "");
    if (!Aux_IsNullOrEmpty(strValueTicks))
    {
        var datValue = Web_GetDateFromTicks(parseFloat(strValueTicks));

        if (blnDate)
        {
            var strFullYear = datValue.getFullYear().toString();
            var strMonth = (datValue.getMonth() + 1).toString(); // month is zero-based
            var strDate = datValue.getDate().toString();

            strNativeDate = strFullYear + "-" + (strMonth[1] ? strMonth : "0" + strMonth[0]) + "-" + (strDate[1] ? strDate : "0" + strDate[0]);
            if (blnTime)
            {
                strNativeDate = strNativeDate + "T";
            }
        }
        if (blnTime)
        {
            var strHours = datValue.getHours().toString();
            var strMinutes = datValue.getMinutes().toString();
            var strSeconds = datValue.getSeconds().toString();

            strNativeDate = strNativeDate + (strHours[1] ? strHours : "0" + strHours[0]) + ":" + (strMinutes[1] ? strMinutes : "0" + strMinutes[0]) + ":" + (strSeconds[1] ? strSeconds : "0" + strSeconds[0]);
        }
    }

    return strNativeDate;
}
/// </method>

/// <method name="NativeDateTimePicker_setNowOnClick">
/// <summary>
/// On mousedown on a DateTimePicker with a blank date, replace date with current date and then select.
/// </summary>
/// <param name="objEvent">The event object for mousedown event</param>
/// <param name="objWindow">Current window object</param>
/// <param name="objInput">Element which is the subject of the mousedown</param>
/// <param name="strGuid">VWG ID of control being clicked</param>
function NativeDateTimePicker_setNowOnClick(objEvent, objWindow, objInput, strGuid) {
    if (!Aux_IsNullOrEmpty(strGuid) && objInput.type == "date" && !Data_IsDisabled(strGuid)) {
        var objNode = Web_GetElementByDataId(strGuid);
        var intEmptyYear = parseInt(Data_GetAttribute(strGuid, "Attr.EmptyDateYear", "0"));
        var strYear = objInput.valueAsDate.getFullYear();

        if (Aux_IsNullOrEmpty(strYear) || parseInt(strYear) <= intEmptyYear) {
            objInput.valueAsDate = new Date();

            // Update value.
            NativeDateTimePicker_OnChange(strGuid, objInput, objEvent, objWindow);
        }
    }
}
/// </method>

