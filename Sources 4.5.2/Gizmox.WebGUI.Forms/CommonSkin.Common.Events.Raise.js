
/// <method name="Events_RaiseDialogEvents">
/// <summary>
/// Sends the event buffer to the application server.
/// </summary>
/// <param name="blnTerminate">A flag indicating if application should be terminated.</param>
function Events_RaiseDialogEvents(blnSynchronicLoadingMask, blnAsynchronicRequeset)
{
    mobjApp.Events_ExecuteRaiseEvents(blnSynchronicLoadingMask, blnAsynchronicRequeset);
}
/// </method>


var mintESHandle				= 0;
var mintESScreenLeft			= 0;
var mintESScreenTop				= 0;

/// <method name="Events_SimulationInitialize">
/// <summary>
/// Simulate resize and move browser events.
/// </summary>

function Events_SimulationInitialize()
{
	mintESScreenLeft	= window.screenLeft;
	mintESScreenTop		= window.screenTop;
	
	// Start simulation loop
	mintESHandle = mobjApp.Web_SetInterval("Events_SimulationCall()",100,window);
}
/// </method>

/// <method name="Events_SimulationCall">
/// <summary>
/// Checks browser properties and fire events if necessary.
/// </summary>
function Events_SimulationCall()
{
	var intTop = parseInt(window.screenTop);
	var intLeft = parseInt(window.screenLeft);
	
	if(intLeft!=mintESScreenLeft && intTop!=mintESScreenTop)
	{
		mintESScreenLeft = intLeft;
		mintESScreenTop = intTop;
		mobjApp.Forms_OnMove(mstrWindowGuid,mintESScreenLeft,mintESScreenTop,true);
	}
}
/// </method>

/// <method name="Events_SimulationTerminate">
/// <summary>
/// Terminates event simulation.
/// </summary>
function Events_SimulationTerminate()
{
	window.clearInterval(mintESHandle);
}
/// </method>