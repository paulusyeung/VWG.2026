
/// <summary>
/// Reference to the current debug window
/// </summary>
var mobjDebugWindow = null;

/// <summary>
/// Reference to the current application window
/// </summary>
var mobjAppWindow = null;

/// <method name="Debug_SetDebugWindow">
/// <summary>
/// Sets the current debug window
/// </summary>
/// <param name="objDebugWindow">The current debug window</param>
function Debug_SetDebugWindow(objDebugWindow)
{
    mobjDebugWindow = objDebugWindow;
}
/// </method>

/// <method name="Debug_GetDebugWindow">
/// <summary>
/// Gets the current debug window
/// </summary>
function Debug_GetDebugWindow()
{
    return mobjDebugWindow;
}
/// </method>


/// <method name="Debug_SetApplicationWindow">
/// <summary>
/// Sets the current application window
/// </summary>
/// <param name="objAppWindow">The current application window</param>
function Debug_SetApplicationWindow(objAppWindow)
{
    mobjAppWindow = objAppWindow;
}
/// </method>

/// <method name="Debug_GetApplicationWindow">
/// <summary>
/// Gets the current application window
/// </summary>
function Debug_GetApplicationWindow()
{
    return mobjAppWindow;
}
/// </method>