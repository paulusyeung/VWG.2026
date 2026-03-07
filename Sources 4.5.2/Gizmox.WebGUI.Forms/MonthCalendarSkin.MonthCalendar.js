function Calendar_SwitchView(strGuid)
{
    Events_CreateEvent(strGuid,"SwitchView");
	Events_RaiseEvents();
}

function Calendar_Previous(strGuid)
{
	Events_CreateEvent(strGuid,"Previous");
	Events_RaiseEvents();
}

//Raise the get next event
function Calendar_Next(strGuid)
{
	Events_CreateEvent(strGuid,"Next");
	Events_RaiseEvents();
}

function Calendar_NavigateYear(strGuid,strYear)
{
	var objEvent = Events_CreateEvent(strGuid,"NavigateYear",true);
	Events_SetEventAttribute(objEvent,"Year",strYear);
	Events_RaiseEvents();
}

function Calendar_NavigateMonth(strGuid,strMonth)
{
	var objEvent = Events_CreateEvent(strGuid,"NavigateMonth",true);
	Events_SetEventAttribute(objEvent,"Month",strMonth);
	Events_RaiseEvents();
}

//Select a calendar value
function Calendar_Choose(strGuid,strValue,intViewType)
{
	// Get calendar node
	var objNode = Data_GetNode(strGuid);
	if(objNode)
	{
	    var objEvent = Events_CreateEvent(strGuid,"ValueChange",true);
	    Events_SetEventAttribute(objEvent, "Value", strValue);
	    Events_RaiseEvents();
	    Events_ProcessClientEvent(objEvent);
	}
}