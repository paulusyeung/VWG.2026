

/// <summary>
/// Debug related parameters
/// </summary>
var mobjDebugWindow = null;
var mblnDebugWindow = false;

/// <method name="Debug_Initialize">
/// <summary>
/// Initializes debug mode
/// </summary>
function Debug_Initialize()
{
    // Try to get debug window (could throw exception if not same domain top)
	try
	{
	    // If there is a get debug window method
	    if(parent.Debug_GetDebugWindow)
	    {
	        // Set that there is a debug window
	        mblnDebugWindow = true;
	        
	        // Try to get debug window
	        mobjDebugWindow = parent.Debug_GetDebugWindow();
	        
	        // Set the current application window
	        parent.Debug_SetApplicationWindow(window);
	        
	        // Enable events debugging
	        mblnDebugEvents = true;
	    }
	}
	catch(e)
	{
	}
}
/// </method>

/// <method name="Debug_GetDebugWindow">
/// <summary>
/// Gets the current debug window
/// </summary>
function Debug_EnsureWindow()
{
    // If there should be a debug window and window was not cached
    if(mblnDebugWindow && !mobjDebugWindow)
    {
        // Cache debug window
        mobjDebugWindow = parent.Debug_GetDebugWindow();
    }
}
/// </method>

/// <method name="Debug_Log">
/// <summary>
/// Writes a string to the log
/// </summary>
/// <param name="strText">The text to write to the log</param>
function Debug_Log(strText)
{
    // 
    Debug_EnsureWindow();

    // If there is a valid debug window
    if(mobjDebugWindow!=null)
    {
        mobjDebugWindow.Debug_Log(strText);
    }    
}
/// </method>

/// <method name="Debug_LogEvent">
/// <summary>
/// Writes an event to the event viewer
/// </summary>
/// <param name="strSource"></param>
/// <param name="strMessage"></param>
/// <param name="strBody"></param>
/// <param name="objTag">An object to associate with log entry for further use when double clicked to inspect</param>
/// <param name="fncCallBack">Function to call when the log entry row double clicked.</param>
function Debug_LogEvent(strSource,strSubject,strBody, strStats, objTag, fncCallBack)
{
    // 
    Debug_EnsureWindow();

    // If there is a valid debug window
    if(mobjDebugWindow!=null)
    {
        mobjDebugWindow.Debug_LogEvent(strSource,strSubject,strBody, strStats, objTag, fncCallBack);
    }    
}
/// </method>