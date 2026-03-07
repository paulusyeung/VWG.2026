/// <page name="Common.js">
/// <summary>
/// This script is used as a shared script.
/// </summary>

/// <summary>
/// Prevent IE from showing the browser help
/// </summary>
document.onhelp = function () { return false; };

/// <namespace name="mobjApp">
/// <summary>
/// Generic name space for referencing from every window.
/// </summary>
var mobjApp = window;
/// </namespace>


/// <parameters>
/// <summary>
/// Constants parameters
/// </summary>
/// <param name="mcntXmlHttpGuid">Xml http guid.</param>
var mcntXmlHttpGuid = "Msxml2.XMLHTTP";
var mcntKeepConnectedInterval = Aux_ParseInt("Context.KeepConnectedInterval");
var mcntUserAgent = navigator.userAgent;
var mcntIsMozilla = mcntUserAgent.indexOf("Firefox") != -1;
var mcntIsWebKit = mcntUserAgent.indexOf("WebKit") != -1;
var mcntIsOpera = mcntUserAgent.indexOf("Opera") != -1;
var mcntIsObsoleteIE = "Context.BrowserObsoleteIE" == "1";
var mblnSupportsMultiTheme = "Context.SupportsMultipleThemes" == "1";
var mblnIsRTL = false;
var mblnAutoHideTaskBar = false;
var mblnDebugMode = false;
var mstrWindowGuid = "";
var mblnIsMainWindow = true;
var mobjOwnedWindows = {};
var mblnIsModeless = true;
var mblnServerClosed = false;
var mstrBaseURL = "Context.RouterContext";
var mstrThousandsSeparator = "Context.ThousandsSeparator";
var mstrNumberDecimalSeparator = "Context.NumberDecimalSeparator";
var mblnFullScreenMode = "Context.FullScreenMode" === "1";
var isAccessibilityMode = "Context.AccessibilityMode" === "1";

// Indicates inline windows mode.
var mblnInlineWindows = false;

// Date/Time related arrays
var marrMonths = ["Labels.January", "Labels.February", "Labels.March", "Labels.April", "Labels.May", "Labels.June", "Labels.July", "Labels.August", "Labels.September", "Labels.October", "Labels.November", "Labels.December"];
var marrShortMonths = ["Labels.JanuaryShort", "Labels.FebruaryShort", "Labels.MarchShort", "Labels.AprilShort", "Labels.MayShort", "Labels.JuneShort", "Labels.JulyShort", "Labels.AugustShort", "Labels.SeptemberShort", "Labels.OctoberShort", "Labels.NovemberShort", "Labels.DecemberShort"];
var marrGenitiveMonths = ["Labels.GenitiveJanuary", "Labels.GenitiveFebruary", "Labels.GenitiveMarch", "Labels.GenitiveApril", "Labels.GenitiveMay", "Labels.GenitiveJune", "Labels.GenitiveJuly", "Labels.GenitiveAugust", "Labels.GenitiveSeptember", "Labels.GenitiveOctober", "Labels.GenitiveNovember", "Labels.GenitiveDecember"];
var marrDaysOfWeek = ["Labels.Sunday", "Labels.Monday", "Labels.Tuesday", "Labels.Wednesday", "Labels.Thursday", "Labels.Friday", "Labels.Saturday"];
var marrShortDaysOfWeek = ["Labels.SundayShort", "Labels.MondayShort", "Labels.TuesdayShort", "Labels.WednesdayShort", "Labels.ThursdayShort", "Labels.FridayShort", "Labels.SaturdayShort"];
var marrTimeParts = ["Labels.AMDesignator", "Labels.PMDesignator"];
var marrShortTimeParts = ["Labels.AMDesignatorShort", "Labels.PMDesignatorShort"];

// Masking constants
var marrMaskChars = ['0', '&', 'L', 'C', 'A', 'a', '9', '?', '#'];
var marrMaskIgnoreChars = ['\\', '>', '<', '|'];
var mstrMaskNullChar = " ";

/// </parameters>

var Common = {};

/// <method name="DoAction">
/// <summary>
/// Executes a givent webgui action (For external interaction)
/// </summary>
/// <param name="strCommand">The webgui action command name.</param>
function DoAction(strCommand)
{
    switch (strCommand)
    {
        case "close": // "close" is used to close a webgui application externaly
            var objVwgEvent = Events_CreateEvent(mstrWindowGuid, "OnUnload");

            Events_RaiseEvents();

            Events_ProcessClientEvent(objVwgEvent);
            break;
    }
}
/// </method>

/// <method name="$">
/// <summary>
/// 
/// </summary>
/// <param name="strId..."></param>
function $$()
{
    return Web_GetElementsByIds(arguments, window);
}
/// </method>

/// <method name="Common_AttachWindowEvents">
/// <summary>
/// Attach window events.
/// </summary>
/// <param name="objDocument">The document.</param>
function Common_AttachWindowEvents(objWindow)
{
    if (objWindow)
    {
        var jqWindow = $(objWindow);

        jqWindow.bind("resize", function () { Forms_Resize(); });
    }
}
/// </method>

/// <method name="Common_AttachBodyEvents">
/// <summary>
/// Attach body events.
/// </summary>
/// <param name="objDocument">The document.</param>
function Common_AttachBodyEvents(objWindow, objDocument)
{
    if (objDocument)
    {
        var jqBody = $(objDocument.body);

        jqBody.bind("selectstart", function (objEvent) { Web_OnSelectStart(objEvent, window); });
        jqBody.bind("contextmenu", function (objEvent) { Web_OnRightClick(objEvent, window); });
        jqBody.bind("keydown", function (objEvent) { Web_OnKeyDown(objEvent, window); });
        jqBody.bind("keyup", function (objEvent) { Web_OnKeyUp(objEvent, window); });
        jqBody.bind("touchstart", function (objEvent) { Web_OnMouseDown(objEvent, window); });
        jqBody.bind("mousedown", function (objEvent) { Web_OnMouseDown(objEvent, window); });
        jqBody.bind("mousewheel", function (objEvent) { Web_OnMouseWheel(objEvent); });
        jqBody.bind("click", function (objEvent) { Web_OnClick(objEvent, window); });
        jqBody.bind("dblclick", function (objEvent) { Web_OnDblClick(objEvent, window); });
        jqBody.bind("blur", function (objEvent) { Web_OnBlur(objEvent); });
        jqBody.bind("mousemove", function (objEvent) { Web_OnMouseMove(objEvent); });
		$(objWindow).bind("orientationchange", function (objEvent) { Web_OnOrientationChange(objEvent, window); });
        $(objWindow).bind("unload", function (objEvent) { Web_OnUnload(objEvent, window); });
        $(objWindow).bind("beforeunload", function () { return Forms_UnloadMainForm(); });
    }
}


/// </method>

/// <method name="Common_Initialize">
/// <summary>
/// Initialize the current document
/// </summary>
/// <param name="objDocument">The document.</param>
function Common_Initialize(objWindow)
{
    var objDocument = objWindow.document;

    // Try to get the base url from the base tag to support
    // reverse proxies
    try
    {
        // Try to get the base tag
        var objBase = objDocument.getElementsByTagName("base");

        // If base tag exists and is valid
        if (objBase.length > 0 && objBase[0].href)
        {
            // Get the base url from base tag to support reverse proxies
            mstrBaseURL = objBase[0].href;
        }
    }
    catch (e) { }

    // Initialize debug mode if needed
    Debug_Initialize();

    // Schedule loading 
    Events_ScheduleLoading(0, 0);

    // Sel loading status
    Status = "Loading application design.";

    // Attach window events.
    Common_AttachWindowEvents(objWindow);

    // Attach body events.
    Common_AttachBodyEvents(objWindow, objDocument);

    // Initialize the UI
    Common_InitializeUI();

    mobjApp.Common_ApplyAccessibilityFeatures(document.body);
}
/// </method>

/// <method name="Common_LoadContent">
/// <summary>
/// Load the initial content
/// </summary>
function Common_LoadContent()
{
    // Load content
    status = "Loading content.";

    var strLoadDocument = "content." + mstrBasePage + ".wgx?vwginstance=" + mstrPageInstance;
    Common_LoadDocument(strLoadDocument);
}

function Common_LoadDocument(strLoadDocument){
    Xml_LoadDocument(strLoadDocument, Common_InitializeContent, true, Web_CreatePostString(null), true);
}
/// <method name="Common_CleanApplets">
/// <summary>
/// Onload applets to prevent IE applet bugs
/// </summary>
/// <param name="objApplets">The applets collection.</param>
function Common_CleanApplets(objApplets)
{
    if (objApplets.length > 0)
    {
        for (var intIndex = 0; intIndex < objApplets.length; intIndex++)
        {
            objApplets[intIndex].outerHTML = "";
        }
    }
}
/// </method>


/// <method name="Common_InitializeContent">
/// <summary>
/// Initialize the content
/// </summary>
/// <param name="objResponse">The content response.</param>
function Common_InitializeContent(objContent)
{
    // If server required refreshing
    if (objContent.documentElement.tagName == "WG:Tags.Refresh")
    {
        Web_Refresh(true);
        return;
    }

    // Hide the loading message
    Events_HideLoading();

    // Initialize content
    status = "Initializing content.";

    // initialize data state
    Data_Initialize(objContent);

    // Set global params
    mblnAutoHideTaskBar = ("Context.AutoHideTaskBar" == "1");
    mblnIsRTL = ("Context.Direction" == "RTL");
    mblnDebugMode = Data_GetParam("DM") == "1";
    mblnInlineWindows = Data_GetParam("InlineWindows") == "1" || mcntIsMozilla || mcntIsWebKit || mcntIsOpera || mblnFullScreenMode;

    // Initialize document
    Common_InitializeMain(window.document);

    // Initialize the forms state
    Forms_Initialize(objContent);

    // Initialize taskbar.
    Common_InitializeInlineWindowsTaskBar(window);
}
/// </method>

/// <method name="Common_InitializeMain">
/// <summary>
/// Initialize document
/// </summary>
/// <param name="objDocument">The initialized document.</param>
function Common_InitializeMain(objDocument)
{
    // attach window events
    Web_AttachEvents(objDocument);

    // initialize traces
    Trace_Initialize();

    // Attach global error
    window.onerror = Web_OnError;

    // Initialization ended.
    status = "Ready.";
}
/// </method>


/// <method name="Common_GetGuid">
/// <summary>
/// Returns the guid of the current window
/// </summary>
function Common_GetGuid()
{
    return mstrWindowGuid;
}
/// </method>

/// <method name="Common_CreatePoint">
/// <summary>
/// Creates a point object
/// </summary>
/// <param name="intX">The X value.</param>
/// <param name="intY">The Y value.</param>
function Common_CreatePoint(intX, intY)
{
    return { X: intX, Y: intY };
}
/// </method>

/// <method name="Common_CreateRect">
/// <summary>
/// Creates a rect object
/// </summary>
/// <param name="intLeft">The left value.</param>
/// <param name="intTop">The top value.</param>
/// <param name="intRight">The right value.</param>
/// <param name="intBottom">The bottom value.</param>
function Common_CreateRect(intLeft, intTop, intRight, intBottom)
{
    return { right: intRight, left: intLeft, top: intTop, bottom: intBottom };
}
/// </method>

/// <method name="Common_Round">
/// <summary>
/// Rounds a number
/// </summary>
/// <param name="intNumber">The number to round.</param>
/// <param name="intPlaces">The decimal places after the period.</param>
function Common_Round(intNumber, intPlaces)
{
    var intResult = 0;
    if (intNumber > 8191 && intNumber < 10485)
    {
        intNumber = intNumber - 5000;
        intResult = Math.round(intNumber * Math.pow(10, intPlaces)) / Math.pow(10, intPlaces);
        intResult = intResult + 5000;
    } else
    {
        intResult = Math.round(intNumber * Math.pow(10, intPlaces)) / Math.pow(10, intPlaces);
    }
    return intResult;
}
/// </method>

/// <method name="Common_IsInlineWindows">
/// <summary>
/// Gets a value indicating if inline windows should be used
/// </summary>
function Common_IsInlineWindows()
{
    return !mcntIsIE || mblnInlineWindows;
}
/// </method>

/// <method name="Common_TimePassed">
/// <summary>
/// Gets a value in miliseconds of the time passed from now to a given date.
/// </summary>
/// <param name="objDate">The date.</param>
function Common_TimePassed(objDate)
{
    return (new Date()) - objDate;
}
/// </method>

/// <method name="Array.contains">
/// <summary>
/// Adds a contains method to the array type.
/// </summary>
/// <param name="value">The containment value to check.</param>
Array.prototype.contains = function (value)
{
    for (var i = 0; i < this.length; i++)
    {
        if (this[i] == value) return true;
    }
    return false;
};
/// </method>

/// <method name="Array.indexOf">
/// <summary>
/// Gets an index of a value whithin an array.
/// </summary>
/// <param name="value">The containment value to check.</param>
Array.prototype.indexOf = function (value)
{
    for (var i = 0; i < this.length; i++)
    {
        if (this[i] == value) return i;
    }
    return -1;
};
/// </method>

/// <method name="Common_InitializeInlineWindowsTaskBar" access="private">
/// <summary>
///
/// </summary>
function Common_InitializeInlineWindowsTaskBar(objWindow)
{
    // Validate recieved arguments.
    if (objWindow)
    {
        // Get the task bar box.
        var objTaskBarBox = Web_GetTaskBarBox();
        if (objTaskBarBox)
        {
            // Get the taskbar items container.
            var objTaskBarItems = Web_GetContextElementById(objTaskBarBox, "VWG_TaskBarItems");
            if (objTaskBarItems)
            {
                // Default block display.
                var strDisplayStyle = "block";

                // In case of none inline windows or empty taskbar in auto hide mode.
                if (!mblnInlineWindows || (objTaskBarItems.childNodes.length == 1 && mblnAutoHideTaskBar))
                {
                    // No display.
                    strDisplayStyle = "none";
                }
                // Update body content bottom to taskbar height.
                var objBodyContentContainer = Web_GetElementById("VWG_BodyContentContainer", objWindow);
                if (objBodyContentContainer)
                {
                    objBodyContentContainer.style.bottom = $(objTaskBarBox).height() + "px";
                    var objTaskBarFrame = Web_GetContextElementById(objTaskBarBox, "VWG_TaskBarFrame");
                    if (objTaskBarFrame)
                    {
                        objTaskBarFrame.style.height = $(objTaskBarBox).height() + "px";
                    }
                }

                // Show / hide the taskbar box.
                if (objTaskBarBox.style.display != strDisplayStyle)
                {
                    objTaskBarBox.style.display = strDisplayStyle;
                }

            }
        }
    }
}
/// </method>

/// <method name="Common_MaskExecute">
/// <summary>
/// Executes a MaskedTextBox command(used by the server control)
/// </summary>
/// <param name="strGuid">The component id.</param>
/// <param name="strCommand">The command to be executed.</param>
/// <param name="strParamA">The first command parameter.</param>
/// <param name="strParamB">The second command parameter.</param>
function Common_MaskExecute(strGuid, strCommand, strParamA, strParamB)
{
    // Get textarea/input element
    var objElement = Web_GetTargetElementByDataId(strGuid);
    if (objElement)
    {
        switch (strCommand)
        {
            case "Select":
                Web_SetAttribute(objElement, "vwgHidefocus", 1);
                var intStart = parseInt(strParamA);
                var intLength = parseInt(strParamB);
                Web_SetSelection(objElement, intStart, intLength);
                Data_SetTextSelectionData(strGuid, intStart, intLength);
                break;
        }
    }
}
/// </method>

/// <method name="Common_MaskFocus">
/// <summary>
/// Handle a masked textbox focus event
/// </summary>
/// <param name="objControl">The masked control.</param>
/// <param name="objEvent">The current event object.</param>
function Common_MaskFocus(objControl, objEvent, strGuid)
{
    if (!objControl.readOnly)
    {
        if (Web_IsAttribute(objControl, "vwgHidefocus", "1", true))
        {
            Web_SetAttribute(objControl, "vwgHidefocus", "0");
        }
        else
        {
            var strControlValue = objControl.value;

            // Format the control value to focus formar
            var strFormatedValue = Common_MaskGetFormatedValue(false, objControl, String(strControlValue).split(''));

            if (strControlValue != strFormatedValue)
            {
                objControl.value = strFormatedValue;

                // Set cursur position to 0
                Web_SetSelection(objControl, 0, 0);
            }
        }
    }
}
/// </method>

/// <method name="Common_MaskOnPaste">
/// <summary>
///
/// </summary>
function Common_MaskOnPaste(objControl)
{
    if (objControl)
    {
        Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Common_MaskEnforcePaste, objControl), 10);
    }
}
/// </method>

/// <method name="Common_MaskEnforcePaste">
/// <summary>
///
/// </summary>
function Common_MaskEnforcePaste(objControl)
{
    if (objControl)
    {
        var intMaskedTextBoxPosition = Web_GetCursorPosition(objControl);

        var arrMaskedTextBoxState = String(objControl.value).split('');
        var arrMaskedTextBoxMask = String(Web_GetAttribute(objControl, "Mask")).split('');

        while (arrMaskedTextBoxState.length > arrMaskedTextBoxMask.length)
        {
            arrMaskedTextBoxState.pop();
        }

        // Flag that input's value has been applied through clipboard.
        Web_SetAttribute(objControl, "vwg_AppliedValue", "1");

        // Format the control value to focus formar
        objControl.value = Common_MaskGetFormatedValue(false, objControl, arrMaskedTextBoxState);

        Web_SetSelection(objControl, intMaskedTextBoxPosition, 0);
    }
}
/// </method>

/// <method name="Common_MaskKeyDown">
/// <summary>
/// Handle the masked textbox keydown event
/// </summary>
/// <param name="objControl">The masked control.</param>
/// <param name="objEvent">The current event object.</param>
function Common_MaskKeyDown(objControl, objEvent, strGuid, objWindow)
{
    var blnIsValidKey = false;

    if (!objControl.readOnly)
    {
        // Flag that input's value has not been applied through clipboard.
        Web_SetAttribute(objControl, "vwg_AppliedValue", "0");

        Common_TextBoxSyncKeyEvent(strGuid, objWindow, objEvent, objControl, "TextBoxRealTimeKeyDown");

        // Get the key code
        var intKeyCode = Web_GetEventKeyCode(objEvent);

        // Check if control key is pressed.
        var blnIControl = Web_IsControl(objEvent);

        // Disable all control navigations.
        if (!(blnIControl && [mcntRightKey, mcntLeftKey, mcntHomeKey, mcntEndKey].contains(intKeyCode)))
        {
            // Enable copy and all other "F" keys.
            if (([67].contains(intKeyCode) && blnIControl) ||
    	        [mcntF1Key, mcntF2Key, mcntF3Key, mcntF4Key, mcntF5Key, mcntF6Key, mcntF7Key, mcntF8Key, mcntF9Key, mcntF10Key, mcntF11Key, mcntF12Key].contains(intKeyCode))
            {
                blnIsValidKey = true;
            }
            else
            {
                var intMaskedTextBoxPosition = Web_GetCursorPosition(objControl);

                // Enable paste/cut
                if ([86, 88].contains(intKeyCode) && blnIControl)
                {
                    blnIsValidKey = true;
                }
                else
                {
                    var arrMaskedTextBoxState = String(objControl.value).split('');

                    // Choose action
                    switch (intKeyCode)
                    {
                        case mcntBackspaceKey:
                            // Get the current selection	
                            var objSelection = Web_GetSelectionRange(objControl);

                            // If there is no selected text
                            if (objSelection.Start == objSelection.End)
                            {
                                // Check valid position
                                if (intMaskedTextBoxPosition > 0)
                                {
                                    // Move to the next editable position
                                    Common_MaskMoveToEditable(objControl, -1, true);

                                    //update current position
                                    intMaskedTextBoxPosition = Web_GetCursorPosition(objControl);

                                    // Remove the selected characters
                                    Common_MaskRemoveSelection(intMaskedTextBoxPosition - 1, intMaskedTextBoxPosition, objControl, arrMaskedTextBoxState);

                                    // Reformat the text box value
                                    objControl.value = Common_MaskGetFormatedValue(false, objControl, arrMaskedTextBoxState);

                                    // Change the position to the previous character
                                    Common_MaskChangePosition(objControl, intMaskedTextBoxPosition, -1);
                                }
                            }
                            else
                            {
                                // Remove current selected characters
                                Common_MaskRemoveSelection(objSelection.Start, objSelection.End, objControl, arrMaskedTextBoxState);

                                // Reformat the control value
                                objControl.value = Common_MaskGetFormatedValue(false, objControl, arrMaskedTextBoxState);

                                // Change the position to the begining of the selection
                                Web_SetSelection(objControl, objSelection.Start, 0);
                            }

                            break;
                        case mcntRightKey:
                        case mcntLeftKey:
                        case mcntTabKey:
                        case mcntHomeKey:
                        case mcntEndKey:
                        case mcntEnterKey:
                            blnIsValidKey = true;
                            break;
                        case mcntDeleteKey:

                            // Get the current selection	
                            var objSelection = Web_GetSelectionRange(objControl);

                            // If there is no selected text
                            if (objSelection.Start == objSelection.End)
                            {
                                // Remove the current selected section
                                Common_MaskRemoveSelection(intMaskedTextBoxPosition, intMaskedTextBoxPosition + 1, objControl, arrMaskedTextBoxState);
                            }
                            else
                            {
                                // Remove current selected characters
                                Common_MaskRemoveSelection(objSelection.Start, objSelection.End, objControl, arrMaskedTextBoxState);
                            }

                            // Reformat the control value
                            objControl.value = Common_MaskGetFormatedValue(false, objControl, arrMaskedTextBoxState);

                            // Change the position to the begining of the selection			    
                            Web_SetSelection(objControl, objSelection.Start, 0);

                            break;

                        default:

                            // If not a control key event
                            if (!blnIControl)
                            {
                                // Move to the next editable character
                                Common_MaskMoveToEditable(objControl, 1);

                                //update current position
                                intMaskedTextBoxPosition = Web_GetCursorPosition(objControl);

                                // Get the current position mask object
                                var objMask = Common_MaskGetMaskForPosition(objControl, intMaskedTextBoxPosition);
                                if (objMask)
                                {
                                    // Check the current input input key is valid
                                    if (Common_MaskIsValidCode(objControl, intKeyCode, objMask.MaskChar, Web_IsShift(objEvent), null, 2))
                                    {
                                        // Get the current selected text range
                                        var objSelection = Web_GetSelectionRange(objControl);

                                        // Set the current character value
                                        if (objMask.UpperCase)
                                        {
                                            arrMaskedTextBoxState[intMaskedTextBoxPosition] = Aux_CharFromKeyCode(intKeyCode).toUpperCase();
                                        }
                                        else if (objMask.LowerCase)
                                        {
                                            arrMaskedTextBoxState[intMaskedTextBoxPosition] = Aux_CharFromKeyCode(intKeyCode).toLowerCase();
                                        }
                                        else
                                        {
                                            arrMaskedTextBoxState[intMaskedTextBoxPosition] = (objEvent.shiftKey) ? Aux_CharFromKeyCode(intKeyCode).toUpperCase() : Aux_CharFromKeyCode(intKeyCode).toLowerCase();
                                        }

                                        // If there is selection objet or no selected text
                                        if (objSelection && objSelection.End - objSelection.Start > 0)
                                        {
                                            // Remove the current character selection
                                            Common_MaskRemoveSelection((objSelection.Start + 1), objSelection.End, objControl, arrMaskedTextBoxState);
                                        }

                                        // Reformate the control value
                                        objControl.value = Common_MaskGetFormatedValue(false, objControl, arrMaskedTextBoxState);

                                        // Change the position to the next character
                                        Common_MaskChangePosition(objControl, intMaskedTextBoxPosition, 1);
                                    }
                                }
                            }
                    }
                }
            }
        }

        // Check if default behavior should be prevented.
        if (!blnIsValidKey)
        {
            // Cancel default behavior so that the native key down character wont't be written twice.
            Web_EventCancelBubble(objEvent, true, false);
        }

        Common_TextBoxSyncKeyEvent(strGuid, objWindow, objEvent, objControl, "TextBoxRealTimeKeyPress");

        // Cancel normal browser behavior
        return blnIsValidKey;
    }
}
/// </method>

/// <method name="Common_TextBoxSyncKeyEvent">
/// <summary>
///  Checks if RealTimeKeyboardEvents is turned on and raises event if needed
/// </summary>
function Common_TextBoxSyncKeyEvent(strGuid, objWindow, objEvent, objInput, strKeyEvent)
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strGuid))
    {
        // Get the inpute node 
        var objNode = Data_GetNode(strGuid);

        // Get the RealTimeKeyboardEvents attribute value
        var blnIsRealTimeEvents = Xml_GetAttribute(objNode, "Attr.TextBoxRealTimeKeyboardEvents", "") === "1";

        // Raise Key event if TextBox Server events syncronization is turned on 
        if (blnIsRealTimeEvents)
        {
            Common_TextBoxRaiseKeyEvent(strGuid, objWindow, objEvent, objInput, strKeyEvent);
        }

    }
}
/// </method>


/// <method name="Common_TextBoxRaiseKeyEvent">
/// <summary>
/// If server side has registered event handlers to any of the KeyDown, KeyPress or KeyUp events, fire those
/// events critically (immediately). If not, there is basically no need to fire these events specifically to
/// the server at all. 
/// </summary>
function Common_TextBoxRaiseKeyEvent(strGuid, objWindow, objEvent, objInput, strEventType)
{

    // Get source element and check if we need to handle events critically
    var objVwgSource = Web_GetVwgElement(objInput, true);

    // Get key code
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    if (objVwgSource)
    {
        // Check if event is critical
        var blnCritical = false;
        var blnFireTextChanged = false;

        if (strEventType == "TextBoxRealTimeKeyDown")
        {
            blnCritical = Common_TextBoxIsCriticalEvent(strGuid, mcntTextBoxRealTimeKeyDownId);
        }
        else if (strEventType == "TextBoxRealTimeKeyPress")
        {
            blnCritical = Common_TextBoxIsCriticalEvent(strGuid, mcntTextBoxRealTimeKeyPressId);
            Common_TextChange(strGuid, objInput.value, objWindow, false);
        }
        else if (strEventType == "TextBoxRealTimeKeyUp")
        {
            blnCritical = Common_TextBoxIsCriticalEvent(strGuid, mcntTextBoxRealTimeKeyUpId);
            Common_TextChange(strGuid, objInput.value, objWindow, false);
        }

        // Only raise event if it is critical
        if (blnCritical)
        {

            // And only raise if keyFiltering states we should filter this key
            if (Data_IsKeyFilterEnabled(strGuid, intKeyCode, objEvent))
            {
                var vwgEvent = Events_CreateEvent(strGuid, strEventType, null, true);

                Events_SetEventAttribute(vwgEvent, "Attr.KeyCode", intKeyCode);
                Events_RaiseEvents();
            }
        }
    }
}
/// </method>


/// <method name="Common_TextBoxIsCriticalEvent">
/// <summary>
/// Checks if a given event is critical for strGuid
/// </summary>
function Common_TextBoxIsCriticalEvent(strGuid, intEventId)
{
    //If valid event id
    if (!isNaN(intEventId))
    {
        // Get current event register
        var intEvents = Common_TextBoxGetRealTimeEvents(strGuid);

        if (!isNaN(intEvents))
        {
            return (parseInt(intEvents, 10) & parseInt(intEventId, 10)) > 0;
        }
    }

    return false;
}


/// <method name="Common_TextBoxGetRealTimeEvents">
/// <summary>
/// Gets the strGuid's event registered value
/// </summary>
function Common_TextBoxGetRealTimeEvents(strGuid)
{
    if (strGuid)
    {
        var strEvents = Data_GetAttribute(strGuid, "Attr.TextBoxRealTimeKeyEvents", "0");
        if (!Aux_IsNullOrEmpty(strEvents))
        {
            return strEvents;
        }
    }

    return "0";
}
/// </method>

/// <method name="Common_MaskBlur">
/// <summary>
/// Handle masked textbox blur event
/// </summary>
/// <param name="strGuid">The masked control id.</param>
/// <param name="objControl">The masked control.</param>
/// <param name="objEvent">The current event object.</param>
/// <param name="objWindow">The masked control window.</param>
function Common_MaskBlur(strGuid, objControl, objEvent, objWindow)
{
    if (!objControl.readOnly)
    {
        // Reset the state
        var arrMaskedTextBoxState = String(objControl.value).split('');

        var strHide = Data_GetAttribute(strGuid, "Attr.HidePromptOnLeave", "0");

        // Reformat the textbox value to a non focus style
        var strValue = Common_MaskGetFormatedValue(strHide == "1", objControl, arrMaskedTextBoxState);

        // If prompt sholud be hidden set value back into the input.
        if (strHide == "1")
        {
            objControl.value = strValue;
        }

        // Connect to default textbox text change behavior
        Common_TextChange(strGuid, strValue, objWindow);
    }
}
/// </method>

/// <method name="Common_MaskSelect">
/// <summary>
/// Handles the selection event of a masked textbox
/// </summary>
/// <param name="objControl">The masked control.</param>
/// <param name="objEvent">The current event object.</param>
function Common_MaskSelect(objControl, objEvent)
{
    objEvent.cancelBubble = true;
    objEvent.returnValue = false;
    return false;
}
/// </method>

/// <method name="Common_MaskRemoveSelection">
/// <summary>
/// Removes a character section
/// </summary>
/// <param name="intStart">The start character index.</param>
/// <param name="intEnd">The end character index.</param>
/// <param name="objControl">The Mask Control.</param>
function Common_MaskRemoveSelection(intStart, intEnd, objControl, arrMaskedTextBoxState)
{
    // Get the starting of set
    var intValidOffset = intEnd - intStart;

    var strPromptChar = Web_GetAttribute(objControl, "PromptChar");

    // chech if start is not valid for looping
    if (intStart == arrMaskedTextBoxState.length)
    {
        // Clear the current position
        arrMaskedTextBoxState[intStart - 1] = strPromptChar;
    }
    else
    {
        // Loop from the start position to the end of the state buffer
        for (var intIndex = intStart; intIndex < arrMaskedTextBoxState.length; intIndex++)
        {
            // Get mask object for current position
            var objMask = Common_MaskGetMaskForPosition(objControl, intIndex);
            if (objMask)
            {

                // Check if this character is a user prompt position
                if (Aux_ArrayContains(marrMaskChars, objMask.MaskChar))
                {
                    // Check that the copy from index is valid
                    if (intIndex + intValidOffset < arrMaskedTextBoxState.length)
                    {
                        // A copy from not found flag
                        var blnNotFound = true;

                        do
                        {

                            // Get the copy from mask
                            var objCopyFromMask = Common_MaskGetMaskForPosition(objControl, intIndex);
                            if (objCopyFromMask)
                            {
                                // Check if the copy from mask is an input character
                                if (Aux_ArrayContains(marrMaskChars, objCopyFromMask.MaskChar))
                                {
                                    // Check that the copy from value is valid for current index
                                    if (Common_MaskIsValid(objControl, arrMaskedTextBoxState[intIndex + intValidOffset], objMask.MaskChar))
                                    {
                                        // Set the current index state with the value of the copy from index
                                        arrMaskedTextBoxState[intIndex] = arrMaskedTextBoxState[intIndex + intValidOffset];

                                        // Set the not found flag to false
                                        blnNotFound = false;
                                    }
                                    else
                                    {
                                        // Increment offset value
                                        intValidOffset++;
                                    }
                                }
                                else
                                {
                                    // Increment offset value
                                    intValidOffset++;
                                }
                            }
                            else
                            {
                                // Increment offset value
                                intValidOffset++;
                            }
                        }
                        while (intIndex + intValidOffset < arrMaskedTextBoxState.length && blnNotFound);

                        // If not found
                        if (blnNotFound)
                        {
                            arrMaskedTextBoxState[intIndex] = strPromptChar;
                        }
                    }
                    else
                    {
                        arrMaskedTextBoxState[intIndex] = strPromptChar;
                    }
                }
                else
                {
                    if (intValidOffset > 1)
                    {
                        intValidOffset--;
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Common_MaskGetFormatedValue">
/// <summary>
/// Handles masked text box control value formating
/// </summary>
/// <param name="blnHidePrompt">Whether to hide prompt.</param>
function Common_MaskGetFormatedValue(blnHidePrompt, objControl, arrMaskedTextBoxState)
{
    // Check if input's value has been applied not through a normal GUI key down.
    var blnAppliedValue = Web_IsAttribute(objControl, "vwg_AppliedValue", "1", true);

    // Split a mask array.
    var arrMaskedTextBoxMask = String(Web_GetAttribute(objControl, "Mask")).split('');

    // Get a new value array 
    var arrFormatedValue;

    // The action flags
    var blnUpperCase = false;
    var blnLowerCase = false;

    var intEndPosition = arrMaskedTextBoxMask.length - 1;
    if (blnHidePrompt)
    {
        //Find Non Edit Position In Range        
        var intNonEditPositionInRange = Common_MaskFindNonEditPositionInRange(arrMaskedTextBoxMask);

        //Find Assigned Edit Position In Range
        var intAssignedEditPositionInRange = Common_MaskFindAssignedEditPositionInRange(objControl, arrMaskedTextBoxMask, arrMaskedTextBoxState);

        intEndPosition = Math.max(intAssignedEditPositionInRange, intNonEditPositionInRange);
    }

    if (intEndPosition != -1)
    {
        arrFormatedValue = new Array(intEndPosition);

        // Get the character for prompting user	    
        var strPromptChar = Web_GetAttribute(objControl, "PromptChar");

        // Define offsets for mask array, formated array and state array.
        var intMaskOffset = 0;
        var intFormatedOffset = 0;
        var intStateOffset = 0;

        // Loop all mask characters.
        while (intMaskOffset <= intEndPosition)
        {
            // Get the current mask character
            var strMaskChar = arrMaskedTextBoxMask[intMaskOffset];

            // Define a boolean which determines whether to preserve offsets.
            var blnPreserveOffsets = false;

            // If is in the ignore characters
            if (!Aux_ArrayContains(marrMaskIgnoreChars, strMaskChar))
            {
                // If there is a state char for index
                if (intStateOffset < arrMaskedTextBoxState.length)
                {
                    // Get the current state character
                    var strStateChar = arrMaskedTextBoxState[intStateOffset];

                    // If is a valid state char
                    if (Common_MaskIsValid(objControl, strStateChar, strMaskChar, blnAppliedValue))
                    {
                        // If is in upper case mode
                        if (blnUpperCase)
                        {
                            // Set character in upper case
                            arrFormatedValue[intFormatedOffset] = strStateChar.toUpperCase();
                        }
                            // If is in lower case mode
                        else if (blnLowerCase)
                        {
                            // Set character in lower case
                            arrFormatedValue[intFormatedOffset] = strStateChar.toLowerCase();
                        }
                        else
                        {
                            // Set normal character value
                            arrFormatedValue[intFormatedOffset] = strStateChar;
                        }

                        // Raise state offset
                        intStateOffset++;
                    }
                    else
                    {
                        // If is an input character
                        if (Aux_ArrayContains(marrMaskChars, strMaskChar))
                        {
                            // Raise state offset
                            intStateOffset++;

                            // In case of space or propmt characters - set a propmt character into the formated array.
                            if (strStateChar == mstrMaskNullChar || strStateChar == strPromptChar)
                            {
                                // Set input prompt character
                                arrFormatedValue[intFormatedOffset] = (blnHidePrompt) ? mstrMaskNullChar : strPromptChar;
                            }
                            else
                            {
                                // Signal to preserve offsets.
                                blnPreserveOffsets = true;
                            }
                        }
                        else
                        {
                            // Set the default state char for this index
                            arrFormatedValue[intFormatedOffset] = strMaskChar;
                        }
                    }
                }
                else
                {
                    // If is an input character
                    if (Aux_ArrayContains(marrMaskChars, strMaskChar))
                    {
                        // Set input prompt character
                        arrFormatedValue[intFormatedOffset] = (blnHidePrompt) ? mstrMaskNullChar : strPromptChar;
                    }
                    else
                    {
                        // Set the default state char for this index
                        arrFormatedValue[intFormatedOffset] = strMaskChar;
                    }
                }

                if (!blnPreserveOffsets)
                {
                    // Raise the formated offset
                    intFormatedOffset++;
                }
            }
            else
            {
                // Handle ignore character
                switch (strMaskChar)
                {
                    case ">": // Upper case sibling
                        blnUpperCase = true;
                        blnLowerCase = false;
                        break;
                    case "<": // Lower case sibling
                        blnUpperCase = false;
                        blnLowerCase = true;
                        break;
                    case "|": // Cancel previous state
                        blnUpperCase = false;
                        blnLowerCase = false;
                        break;
                }
            }

            if (!blnPreserveOffsets)
            {
                // Raise the mask offset.
                intMaskOffset++;
            }
        }
    }
    else
    {
        arrFormatedValue = new Array(0);
    }

    // Return the formated value
    return arrFormatedValue.join('');
}
/// </method>

/// <method name="Common_MaskFindNonEditPositionInRange">
/// <summary>
/// Find non edit position InRange
/// </summary>
/// <param name="arrMaskedTextBoxMask">MaskTextBox Mask</param>
function Common_MaskFindNonEditPositionInRange(arrMaskedTextBoxMask)
{
    var intNonEditPositionInRange = -1;
    var intIndex = arrMaskedTextBoxMask.length - 1;
    var strMaskChar;

    while (intIndex > -1)
    {
        strMaskChar = arrMaskedTextBoxMask[intIndex];

        if (marrMaskChars.indexOf(strMaskChar) == -1 && marrMaskIgnoreChars.indexOf(strMaskChar) == -1)
        {
            intNonEditPositionInRange = intIndex;
            break;
        }

        intIndex--;
    }

    return intNonEditPositionInRange;
}
/// </method>

/// <method name="Common_MaskFindAssignedEditPositionInRange">
/// <summary>
/// Find the last assigned char position
/// </summary>
/// <param name="objControl">Mask control.</param>
/// <param name="arrMaskedTextBoxMask">MaskTextBox mask</param>
/// <param name="arrMaskedTextBoxState">MaskTextBox state</param>
/// <param name="intNonEditPositionInRange">last position of non edit char</param>
function Common_MaskFindAssignedEditPositionInRange(objControl, arrMaskedTextBoxMask, arrMaskedTextBoxState)
{
    var intInputTextBoxCharIndex = 0;
    var intAssignedEditPositionInRange = -1;
    var intIndex = 0;
    var strPromptChar = String(Web_GetAttribute(objControl, "PromptChar"));

    while (intIndex < arrMaskedTextBoxMask.length)
    {
        //get the mask char
        var strMaskChar = arrMaskedTextBoxMask[intIndex];

        //check if it is a legal masked char
        if (marrMaskChars.indexOf(strMaskChar) != -1)
        {
            //check the input text for prompt char
            if (intInputTextBoxCharIndex < arrMaskedTextBoxState.length &&
				strPromptChar != arrMaskedTextBoxState[intInputTextBoxCharIndex] &&
				mstrMaskNullChar != arrMaskedTextBoxState[intInputTextBoxCharIndex])
            {
                intAssignedEditPositionInRange = intIndex;
            }
            intInputTextBoxCharIndex++;
        }
        else
        {
            //checking for the ignored chars (which are not in the input text)
            //the mask is not an ignored char, so it is part of the input text
            if (marrMaskIgnoreChars.indexOf(strMaskChar) == -1)
            {
                intInputTextBoxCharIndex++;
            }
        }

        //set next mask char
        intIndex++;
    }

    return intAssignedEditPositionInRange;
}
/// </method>

/// <method name="Common_MaskChangePosition">
/// <summary>
/// Changes the current position by a step direction value
/// </summary>
/// <param name="objControl">The masked control.</param>
/// <param name="intDirection">the step value positive or negative.</param>
function Common_MaskChangePosition(objControl, intMaskedTextBoxPosition, intDirection)
{
    // Get the new position
    var intCurrentPosition = intMaskedTextBoxPosition + intDirection;
    var arrMaskedTextBoxState = String(objControl.value).split('');

    // Check valid position index	
    if (intCurrentPosition < arrMaskedTextBoxState.length + 1 && intCurrentPosition > -1)
    {
        // Set cursot in the position		
        Web_SetSelection(objControl, intCurrentPosition, 0);
    }
}
/// </method>

/// <method name="Common_MaskGetMaskForPosition">
/// <summary>
/// Get the current mask for the index position.
/// </summary>
/// <param name="objControl">The masked control.</param>
/// <param name="intPosition">The character position.</param>
function Common_MaskGetMaskForPosition(objControl, intPosition)
{
    // Action flags
    var blnUpperCase = false;
    var blnLowerCase = false;

    var arrMaskedTextBoxMask = String(Web_GetAttribute(objControl, "Mask")).split('');

    // Loop all characters
    for (var intIndex = 0, intOffset = 0; intIndex < arrMaskedTextBoxMask.length; intIndex++)
    {
        // Get the mask character
        var strMaskChar = arrMaskedTextBoxMask[intIndex];

        // If is not in the ignore characters
        if (Aux_ArrayContains(marrMaskIgnoreChars, strMaskChar))
        {
            // Handle ignore character
            switch (strMaskChar)
            {
                case ">": // Upper case sibling
                    blnUpperCase = true;
                    blnLowerCase = false;
                    break;
                case "<": // Lower case sibling
                    blnUpperCase = false;
                    blnLowerCase = true;
                    break;
                case "|": // Cancel previous state
                    blnUpperCase = false;
                    blnLowerCase = false;
                    break;
            }
        }
        else
        {
            // If the offset is equal to position
            if (intOffset == intPosition)
            {
                // Return mask data
                return {
                    MaskChar: strMaskChar,
                    UpperCase: blnUpperCase,
                    LowerCase: blnLowerCase
                };
            }

            // increment offset
            intOffset++;
        }
    }

    // Mask not found
    return null;
}
/// </method>

/// <method name="Common_MaskMoveToEditable">
/// <summary>
/// Moves the cursor to the an editable location
/// </summary>
/// <param name="objControl">The masked control.</param>
/// <param name="intDirection">The direction to search</param>
/// <param name="blnBefore">Requiers a valid before input character.</param>
function Common_MaskMoveToEditable(objControl, intDirection, blnBefore)
{
    // get the current position
    var intMaskedTextBoxPosition = Web_GetCursorPosition(objControl);
    var arrMaskedTextBoxState = String(objControl.value).split('');

    // Check valid mask position
    if (intMaskedTextBoxPosition < arrMaskedTextBoxState.length - 1)
    {
        // Get current mask
        var objMask = Common_MaskGetMaskForPosition(objControl, blnBefore ? intMaskedTextBoxPosition - 1 : intMaskedTextBoxPosition);
        if (objMask)
        {
            // Cheeck if is not an editable position
            if (!Aux_ArrayContains(marrMaskChars, objMask.MaskChar))
            {
                // Change the position
                Common_MaskChangePosition(objControl, intMaskedTextBoxPosition, intDirection);

                // Recursing action to find editable position
                Common_MaskMoveToEditable(objControl, intDirection, blnBefore);
            }
        }
    }
}
/// </method>

/// <method name="Common_MaskIsValid">
/// <summary>
/// Checks if a state character is valid for a specified mask character.
/// </summary>
/// <param name="strStateChar">The state character.</param>
/// <param name="strMaskChar">The mask character.</param>
function Common_MaskIsValid(objControl, strStateChar, strMaskChar, blnAppliedValue)
{
    return Common_MaskIsValidCode(objControl, strStateChar.charCodeAt(0), strMaskChar, false, blnAppliedValue, 0);
}
/// </method>

/// <method name="Common_MaskIsValidCode">
/// <summary>
/// Checks if a state character is valid for a specified mask character.
/// </summary>
/// <param name="intKeyCode">The key code of the state (input) character</param>
/// <param name="strMaskChar">The mask character.</param>
function Common_MaskIsValidCode(objControl, intKeyCode, strMaskChar, blnShift, blnAppliedValue, enmCaseType)
{
    //Get char by key code
    var strStateChar = String.fromCharCode(intKeyCode);

    if (objControl)
    {
        // Get control data id
        var strDataId = Data_GetDataId(objControl.id);

        if (!Aux_IsNullOrEmpty(strDataId))
        {
            //Get Node by Control's element
            var objControlNode = Data_GetNode(strDataId);

            if (objControlNode)
            {
                // Get control's propmt char
                var strPromptChar = Web_GetAttribute(objControl, "PromptChar");

                // If state character (key Code) is equal to the prompt char
                if (strStateChar == strPromptChar)
                {
                    // If ResetOnPrompt set to true, the key is valid
                    if (Xml_GetAttribute(objControlNode, "Attr.ResetOnPrompt", "1") == "1")
                    {
                        return true;
                    }

                    // else If AllowPromptAsInput set to false, the key is not valid
                    if (Xml_GetAttribute(objControlNode, "Attr.AllowPromptAsInput", "1") == "0")
                    {
                        return false;
                    }
                }

                //If state character is sapcebar and ResetOnSpace property is set to true, space is valid for mask
                if ((intKeyCode == mcntSpaceKey) && Xml_GetAttribute(objControlNode, "Attr.ResetOnSpace", "1") == "1")
                {
                    return true;
                }
            }
        }
    }

    // Check if character is not an input character
    if (!Aux_ArrayContains(marrMaskChars, strMaskChar))
    {
        // Check if state is equal to literal
        if (strStateChar == strMaskChar)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        // check validity by mask character types
        switch (strMaskChar)
        {
            case "0":
                //Digit, required. This element will accept any single digit between 0 and 9.
                return !blnShift && Aux_IsDigitKeyCode(intKeyCode, blnAppliedValue);
                break;
            case "9":
                //Digit or space, optional.
                return !blnShift && (Aux_IsDigitKeyCode(intKeyCode, blnAppliedValue) || intKeyCode == mcntSpaceKey);
                break;
            case "#":
                //Digit or space, optional. If this position is blank in the mask, it will be rendered as a space in the Text property. Plus (+) and minus (-) signs are allowed.
                return (!blnShift && (Aux_IsDigitKeyCode(intKeyCode, blnAppliedValue) || [mcntSpaceKey, mcntPlusKey, mcntMinusKey1, mcntMinusKey2].contains(intKeyCode))) || (blnShift && (intKeyCode == mcntEqualKey));
                break;
            case "?":
            case "L":
                return Aux_IsLetterKeyCode(intKeyCode, enmCaseType);
                break;
            case "a":
            case "A":
            case "C":
            case "&":
                return Aux_IsAlphaNumericKeyCode(intKeyCode, blnAppliedValue);
                break;
        }
    }
}
/// </method>

/// <method name="Common_TextChange">
/// <summary>
///
/// </summary>
function Common_TextChange(strGuid, strValue, objWindow, blnIsEnter)
{
    // Get text box node
    var objNode = Data_GetNode(strGuid);
    if (objNode)
    {
        // Even when setting inputs with text-transform:uppercase/lowercase their value can still be "Normal
        // So we change the value to be correct before any logic occurs
        var strCharacterCasingAttribute = Data_GetNodeAttribute(objNode, "Attr.CharacterCasing", null);

        if (strCharacterCasingAttribute)
        {
            switch (strCharacterCasingAttribute)
            {
                case "2":
                    strValue = strValue.toLowerCase();
                    break;
                case "1":
                    strValue = strValue.toUpperCase();
                    break;
            }
        }

        // Normalize value.
        strValue = Aux_EncodeText(strValue);

        // Get validation expression.
        var strExpression = objNode.getAttribute("Attr.ValueValidationExpression");
        if (!Aux_IsNullOrEmpty(strExpression))
        {
            // Check if value is valid.
            if (!Web_ValidateValue(strExpression, strValue, null, objWindow))
            {
                // Redraw cotnrol.
                Controls_RedrawControlByNode(objWindow, objNode);

                // Give a proper message (must be after Controls_RedrawControlByNode, else a second TextBox_Blur will be triggered).
                alert(objNode.getAttribute("Attr.InValidateMessage"));

                return;
            }
        }

        var objVwgEvent;

        // If data has changed
        if ((Xml_HasAttribute(objNode, "Attr.Value") || !Aux_IsNullOrEmpty(strValue)) &&
		    !Xml_IsAttribute(objNode, "Attr.Value", strValue))
        {
            // Update data behind
            Data_SetNodeAttribute(objNode, "Attr.Value", strValue);

            // Create event
            var objValueChangeEvent = Events_CreateTraceableEvent(objWindow, null, strGuid, "ValueChange", null, true);
            var blnScheduled = false;

            // Set event text attribuet
            Events_SetEventAttribute(objValueChangeEvent, "Attr.Text", strValue);

            // Create enter event
            if (blnIsEnter)
            {
                objVwgEvent = Events_CreateEvent(strGuid, "EnterKeyDown", null, true);
            }

            // Raise event if critical
            if (Data_IsCriticalEvent(objNode, "Event.ValueChange", true))
            {
                // Get the RealTimeKeyboardEvents attribute value
                var blnIsRealTimeEvents = Xml_GetAttribute(objNode, "Attr.TextBoxRealTimeKeyboardEvents", "") === "1";
                if (blnIsEnter || blnIsRealTimeEvents)
                {
                    Events_RaiseEvents();
                }
                else
                {
                    // Schedule event raising
                    Events_ScheduleRaiseEvents(100);
                    blnScheduled = true;
                }
            }
            else if (Data_IsCriticalEvent(objNode, "Event.EnterKeyDown", true) && blnIsEnter)
            {
                Events_RaiseEvents();
            }

            if (!blnScheduled)
            {
                Events_ProcessClientEvent(objValueChangeEvent);
            }
            else
            {
                Events_ScheduleProcessClientEvent(objValueChangeEvent, 100);
            }
        }
        else
        {
            // Create enter event
            if (Data_IsCriticalEvent(objNode, "Event.EnterKeyDown", true) && blnIsEnter)
            {
                objVwgEvent = Events_CreateEvent(strGuid, "EnterKeyDown", null, true);

                Events_RaiseEvents();
            }
        }

        Events_ProcessClientEvent(objVwgEvent);
    }
}
/// </method>

/// <method name="Common_SetScrollDimension">
/// <summary>
/// 
/// </summary>
function Common_SetScrollDimension(objWrapperElement, strDimension, blnPreserveChildSize)
{
    var blnHasScroll = false;

    // Validate parameters
    if (objWrapperElement && objWrapperElement.firstChild && (strDimension === 'Height' || strDimension === 'Width'))
    {
        var strLowerDimension = strDimension.toLowerCase(),
            intInitialScroll = 0;

        // Get the inittial scroll of the element to determine the entire scroll area value
        if (objWrapperElement.iScrollElement && objWrapperElement.style.overflow.toLowerCase() !== "hidden") // *Read NOTE
        {
            /*
                NOTE: The previous iScroll (v4) put a overflow = hidden on the objWrapperElement which caused the 'scrollHeight' value to be as high as the content.
                iScroll v5 does not put the overflow attribute so the 'scrollHeight' value returns the area from the top of the container (objWrapperElement) to the bottom of the child (objWrapperElement.firstChild).
                So if the the child is scroller all the way to the top then - objWrapperElement.height = objWrapperElement.scrollHeight.

                If for some reason the overflow will change to be hidden again, then we should remove the 'intInitialScroll' value to the scroll dimention height.
            */

            intInitialScroll = -(strDimension === 'Height' ? objWrapperElement.iScrollElement.y : objWrapperElement.iScrollElement.x);
        }

        // Scroll Width or Height
        var intScrollDimensionValue = objWrapperElement["scroll" + strDimension] + intInitialScroll;
        // Real Width or Height
        var intElementDimensionValue = $(objWrapperElement)[strLowerDimension]();

        // Check that there's a difference between the values (to indicate if the element nedds a scroll)
        if (intScrollDimensionValue != intElementDimensionValue)
        {
            blnHasScroll = true;
            if (!blnPreserveChildSize)
            {
                // Set the child's relevent dimention to be the actual size
                objWrapperElement.firstChild.style[strLowerDimension] = intScrollDimensionValue + "px";
            }

            // Limit the element to be at least 100% (no sense for the contained element to be less than its parent size)
            objWrapperElement.firstChild.style["min" + strDimension] = "100%";
        }
    }

    // Return wheather the element needs a scroll or not.
    return blnHasScroll;
}
/// </method>

/// <method name="Common_GetDefaultIScrollParameters">
/// <summary>
/// 
/// </summary>
function Common_GetDefaultIScrollParameters()
{
    return { bounce: true, scrollbars: true, handleClick: true, probeType: 3, tap: true, mouseWheel: true };
}
/// </method>

/// <method name="Common_CompleteScrollCapabilities">
/// <summary>
/// strScrollbars sets the visible scrollbars : 0 = none, 1 - Horizontal scrollbar, 2 - Vertical scrollbar, 3/undefined = both.
/// </summary>
function Common_CompleteScrollCapabilities(objScrollableElement, blnBounce, strScrollbars, objScrollMoveHandler, objScrollEndHandler)
{
    // Validate scrollable element.
    if (objScrollableElement)
    {
        // Create params object.
        var objParams = Common_GetDefaultIScrollParameters();
            
        objParams.bounce = blnBounce;
        objParams.handleClick = false;

        if (objScrollableElement.firstChild)
        {
            // Check which scrollbars the user defined
            var blnSupportHorizontalScroll = strScrollbars == '3' || strScrollbars == undefined || strScrollbars == '1';
            var blnSupportVerticalScroll = strScrollbars == '3' || strScrollbars == undefined || strScrollbars == '2';

            var blnHasVerticalScroll = false;
            var blnHasHorizontalScroll = false;

            // Determine Vertical scroll values
            if (blnSupportVerticalScroll)
            {
                blnHasVerticalScroll = Common_SetScrollDimension(objScrollableElement, 'Height');
            }

            // Determine Horizontal scroll values
            if (blnSupportHorizontalScroll)
            {
                blnHasHorizontalScroll = Common_SetScrollDimension(objScrollableElement, 'Width');
            }

            // Put the right scroll parametes in the iScroll options
            objParams["scrollY"] = blnHasVerticalScroll;
            objParams["scrollX"] = blnHasHorizontalScroll;

            if (blnSupportHorizontalScroll || blnSupportVerticalScroll)
            {
                // Create a function to refresh the sizes of the scroller element
                objScrollableElement.calculateNewSize = function (orientation)
                {
                    if (objScrollableElement && document.body.contains(objScrollableElement))
                    {
                        if (objScrollableElement.firstChild && objScrollableElement.iScrollElement && objScrollableElement.iScrollElement.options)
                        {
                            if (blnSupportVerticalScroll)
                            {
                                objScrollableElement.iScrollElement.options.scrollY = Common_SetScrollDimension(objScrollableElement, 'Height', true);
                            }

                            if (blnSupportHorizontalScroll)
                            {
                                objScrollableElement.iScrollElement.options.scrollX = Common_SetScrollDimension(objScrollableElement, 'Width', true);
                            }

                            objScrollableElement.iScrollElement.refresh();
                        }
                    }
                    else if (objScrollableElement && !document.body.contains(objScrollableElement))
                    {
                        $(window).off('resize', objScrollableElement.calculateNewSize);

                    }
                };

                if (!objScrollableElement.calculateNewSize.addedHandler)
                {
                    // Refresh the scroller element when certain events are raised
                    $(window).on('resize', objScrollableElement.calculateNewSize);
                    objScrollableElement.calculateNewSize.addedHandler = true;
                }
            }
        }

        // Create and preserve a new IScroll element.
        var objIScroll = objScrollableElement.iScrollElement = new IScroll(objScrollableElement, objParams);

        if (objScrollMoveHandler)
        {
            objIScroll.on("scroll", objScrollMoveHandler);
        }

        if (objScrollEndHandler)
        {
            objIScroll.on("scrollEnd", objScrollEndHandler);
        }
    }
}
/// </method>

/// <method name="Common_ApplySelectableCapability">
/// <summary>
/// 
/// </summary>
function Common_ApplySelectableCapability(strDataID, objJQueryElement)
{
    if (strDataID && objJQueryElement)
    {
        objJQueryElement.selectable({ tolerance: "touch",

            filter: 'div[id*="VWG_"]',
            delay: 150, // Delay for allowing Click and DoubleClick events
            start: function (objEvent, objUI)
            {
                // This prevents the Web_SetStyle from changing css classes
                $(this).data("selectable").selectees.each(function ()
                {
                    Web_SetAttribute(this, "vwgsuspendmouseevents", "1");
                });
            },
            stop: function (objEvent, objUI)
            {
                var arrSelected = [];
                $(".ui-selected", this).each(function ()
                {
                    arrSelected.push(Data_GetDataId(this.id));
                });

                if (arrSelected.length)
                {
                    var strDataID = Data_GetDataId(this.id);

                    if (!Aux_IsNullOrEmpty(strDataID))
                    {
                        // Create ControlSelected event
                        var objEvent = Events_CreateEvent(strDataID, "ControlSelected", null, true);

                        // Set event attributes
                        Events_SetEventAttribute(objEvent, "Attr.Selected", arrSelected.join());

                        // Raise events.
                        Events_RaiseEvents();
                    }
                }

                // Restore Web_SetStyle's operations
                $(this).data("selectable").selectees.each(function ()
                {
                    Web_SetAttribute(this, "vwgsuspendmouseevents", "0");
                });
            }
        });
    }
}
/// </method>

/// <method name="Common_ApplyDraggableCapability">
/// <summary>
/// 
/// </summary>
function Common_ApplyDraggableCapability(strDataID, objJQueryElement, strDraggableParams)
{
    if (strDataID && objJQueryElement)
    {
        // Get dock value.
        var strDock = Data_GetAttribute(strDataID, "Attr.Docking", "");
        if (!strDock)
        {
            objJQueryElement.draggable(
            {
                stop: function (objEvent, objUI)
                {
                    if (objUI && objUI.position)
                    {
                        // Get element data id.
                        var strDataID = Data_GetDataId(this.id);
                        if (!Aux_IsNullOrEmpty(strDataID))
                        {
                            // Get data node
                            var objNode = Data_GetNode(strDataID);
                            if (objNode != null)
                            {
                                // Update data with new size value
                                Data_SetNodeAttribute(objNode, "Attr.Left", objUI.position.left);
                                Data_SetNodeAttribute(objNode, "Attr.Top", objUI.position.top);

                                // Create move event
                                var objEvent = Events_CreateEvent(strDataID, "Move", null, true);

                                // Set event attributes
                                Events_SetEventAttribute(objEvent, "Left", objUI.position.left);
                                Events_SetEventAttribute(objEvent, "Top", objUI.position.top);

                                // If there are alsoResize items, I will create events for them as well.
                                var strAlsoDragSelector = $(this).draggable("option", "alsoDrag");

                                // The is critical indicator
                                var blnIsCritical = Data_IsCriticalEvent(objNode, "Event.LocationChange", true);

                                var scaleXFactor = this.scaleXFactor;
                                var scaleYFactor = this.scaleYFactor;

                                $(strAlsoDragSelector).each(function ()
                                {
                                    var strDataId = Data_GetDataId(this.id);

                                    var objNode = Data_GetNode(strDataID);

                                    // Create resize event
                                    var objEvent = Events_CreateEvent(strDataID, "Move", null, true);

                                    var objJQeuryItem = $(this);

                                    // Update data with new size value
                                    Data_SetNodeAttribute(objNode, "Attr.Left", objJQeuryItem.position().left / scaleXFactor);
                                    Data_SetNodeAttribute(objNode, "Attr.Top", objJQeuryItem.position().top / scaleYFactor);

                                    // Set event attributes
                                    Events_SetEventAttribute(objEvent, "Left", objJQeuryItem.position().left);
                                    Events_SetEventAttribute(objEvent, "Top", objJQeuryItem.position().top);

                                    // Checking is critical for "alsoResize" elements.
                                    blnIsCritical = blnIsCritical || Data_IsCriticalEvent(objNode, "Event.LocationChange", true);

                                    objJQeuryItem.removeData("ui-draggable-alsoDrag");
                                });

                                // Raise event if critical
                                if (blnIsCritical)
                                {
                                    Events_RaiseEvents();
                                }
                            }
                        }
                    }

                    // Clear the memory
                    this.scaleXFactor = undefined;
                    this.scaleYFactor = undefined;
                    $(this).data("ui-draggable").vwgOriginalPosition = undefined;
                },
                start: function (event, objUI) {
                    var objParentContainerWithScale = $(this).closest('div[style*=transform:][style*=scale]');
                    if (objParentContainerWithScale && objParentContainerWithScale.length > 0)
                    {
                        var strMatrix = Common_MatrixToArray(objParentContainerWithScale.css('transform'));
                        if (strMatrix)
                        {
                            // Adding a custom property with the old orioginal posistion, because the originalPosition is set after the start event.                            
                            var draggedElement = $(this).data("ui-draggable");
                            draggedElement.vwgOriginalPosition = { left: objUI.position.left, top: objUI.position.top };

                            objUI.position.left = 0;
                            objUI.position.top = 0;

                            this.scaleXFactor = parseFloat(strMatrix[0]); // The matrix first parameter
                            this.scaleYFactor = parseFloat(strMatrix[3]); // The matrix third parameter
                        }
                    }

                    var strAlsoDragSelector = objUI.helper.draggable("option").alsoDrag;

                    $(strAlsoDragSelector).each(function ()
                    {
                        var draggedElement = $(this);

                        draggedElement.data("ui-draggable-alsoDrag", {
                            top: parseInt(draggedElement.css("top"), 10),
                            left: parseInt(draggedElement.css("left"), 10)
                        });
                    });
                },
                drag: function (event, objUI)
                {
                    var scaleXFactor = this.scaleXFactor;
                    var scaleYFactor = this.scaleYFactor;
                    if (this.scaleXFactor && this.scaleYFactor) {
                        var changeLeft = objUI.position.left - objUI.originalPosition.left; // find change in left
                        var newLeft = objUI.originalPosition.left + changeLeft / scaleXFactor; // adjust new left by our scale factor
                        
                        var changeTop = objUI.position.top - objUI.originalPosition.top; // find change in top
                        var newTop = objUI.originalPosition.top + changeTop / scaleYFactor; // adjust new top by our sacale factor

                        objUI.position.left = newLeft;
                        objUI.position.top = newTop;
                    }
                    
                    // Check if allowNegativeAxes is false and force non negavive axes
                    if (objUI.helper.draggable("option").allowNegativeAxes == false)
                    {
                        if (objUI.position.left < 0)
                        {
                            objUI.position.left = 0;
                        }
                        if (objUI.position.top < 0)
                        {
                            objUI.position.top = 0;
                        }

                        // If there are alsoResize items, I will create events for them as well.
                        var strAlsoDragSelector = objUI.helper.draggable("option").alsoDrag;

                        var draggedElement = $(this).data("ui-draggable");

                        var blnAlsoDragTopNegativePosition = false;
                        var blnAlsoDragLeftNegativePosition = false;

                        $(strAlsoDragSelector).each(function ()
                        {
                            var alsoDraggedElement = $(this);

                            var delta = { top: (objUI.position.top * scaleYFactor - draggedElement.vwgOriginalPosition.top) || 0, left: (objUI.position.left * scaleXFactor - draggedElement.vwgOriginalPosition.left) || 0 };
                            var start = alsoDraggedElement.data("ui-draggable-alsoDrag");

                            if (scaleXFactor && scaleXFactor > 0)
                            {
                                delta.top = delta.top / scaleYFactor;
                            }
                            if (scaleYFactor && scaleYFactor > 0)
                            {
                                delta.left = delta.left / scaleXFactor;
                            }

                            var blnTmpAlsoDragTopNegativePosition = (start.top + delta.top <= 0);
                            var blnTmpAlsoDragLeftNegativePosition = (start.left + delta.left <= 0);
                                                        
                            blnAlsoDragTopNegativePosition |= blnTmpAlsoDragTopNegativePosition;
                            blnAlsoDragLeftNegativePosition |= blnTmpAlsoDragLeftNegativePosition;

                        });

                        if (blnAlsoDragTopNegativePosition)
                        {
                            objUI.position.top = objUI.helper.position().top / scaleYFactor;
                        }

                        if (blnAlsoDragLeftNegativePosition)
                        {
                            objUI.position.left = objUI.helper.position().left / scaleXFactor;
                        }

                        var css = ["top", "left"];

                        $(strAlsoDragSelector).each(function ()
                        {
                            var alsoDraggedElement = $(this);

                            var delta = { top: (objUI.position.top * scaleYFactor - draggedElement.vwgOriginalPosition.top) || 0, left: (objUI.position.left * scaleXFactor - draggedElement.vwgOriginalPosition.left) || 0 };

                            var start = alsoDraggedElement.data("ui-draggable-alsoDrag"), style = {};
                            
                            if (scaleXFactor && scaleXFactor > 0)
                            {
                                delta.top = delta.top / scaleYFactor;
                            }
                            if (scaleYFactor && scaleYFactor > 0)
                            {
                                delta.left = delta.left / scaleXFactor;
                            }

                            $.each(css, function (i, prop)
                            {
                                var sum = (start[prop] || 0) + (delta[prop] || 0);
                                if (sum < 0)
                                {
                                    sum = 0;
                                }
                                style[prop] = sum || 0;
                            });

                            alsoDraggedElement.css(style);
                        });
                    }
                },
                cancel: null
            });

            // Setting the draggable parameters as given.
            if (strDraggableParams)
            {
                var strParams = strDraggableParams.split('|');

                for (var varIndex = 0; varIndex < strParams.length; varIndex++)
                {
                    var strParameter = strParams[varIndex].split(':');
                    if (strParameter.length == 2 && strParameter[0].length > 0 && strParameter[1].length > 0)
                    {
                        // Siblings get a special treatment, in order to create a selector consisting of all item's siblings from same level.
                        // (Using the defgault 'siblings' key word in jQuery gives only the following siblings.
                        if (strParameter[0] == "snap" && strParameter[1] == "siblings")
                        {
                            var strSiblingsIds = [];
                            var objSiblings = objJQueryElement.siblings("div[id^='VWG_']").each(function ()
                            {
                                strSiblingsIds[strSiblingsIds.length] = "#" + $(this).attr('id');
                            });

                            var objParent = objJQueryElement.parents("div[id^='VWG_']:first");

                            if (objParent.length)
                            {
                                strSiblingsIds[strSiblingsIds.length] = "#" + objParent.attr('id');
                            }
                            objJQueryElement.draggable("option", "snap", strSiblingsIds.join(", "));
                        }
                        else
                        {
                            objJQueryElement.draggable("option", strParameter[0], eval(strParameter[1]));
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Common_MatrixToArray">
/// <summary>
/// 
/// </summary>
function Common_MatrixToArray(strMatrix)
{
    if (strMatrix && strMatrix.length > 7)
    {
        return strMatrix.substr(7, strMatrix.length - 8).split(', ');
    }
    else
    {
        return null;
    }
}
/// </method>

/// <method name="Common_ApplyResizableCapability">
/// <summary>
/// 
/// </summary>
function Common_ApplyResizableCapability(strDataID, objJQueryElement, strResizableParams)
{
    if (strDataID && objJQueryElement)
    {
        // Define default resize handlers: if control has defined direction, use it, else set all directions.
        var objSplittedParams = strResizableParams ? strResizableParams.split('|') : "";
        var strDirectionHandles = objSplittedParams.length > 0 ? objSplittedParams[0] : false;
        var strHandles = strDirectionHandles ? strDirectionHandles : "n, e, s, w, ne, se, sw, nw";

        // Switch dock type.
        var strDock = Data_GetAttribute(strDataID, "Attr.Docking", "");
        if (strDock)
        {
            switch (strDock)
            {
                case "L":
                    strHandles = "e";
                    break;
                case "R":
                    strHandles = "w";
                    break;
                case "T":
                    strHandles = "s";
                    break;
                case "B":
                    strHandles = "n";
                    break;
                case "F":
                    strHandles = "";
                    break;
            }

            //If control has diretions limitation, check with docking direction
            if (strDirectionHandles)
            {
                var arrValidDirections = strDirectionHandles.split(",");

                //If docking allow a direction which is not valid by the control, disallow any direction.
                if (arrValidDirections && (!arrValidDirections.contains(strHandles)))
                {
                    strHandles = "";
                }
            }
        }

        // Get data node
        var objNode = Data_GetNode(strDataID);

        //Set resizable only if there is valud direction to set it on
        if ((objNode != null) & (!Aux_IsNullOrEmpty(strHandles)))
        {
            // Get min max bounds
            var intMaxHeight = Xml_GetAttribute(objNode, "Attr.MaximumHeight", null);
            var intMaxWidth = Xml_GetAttribute(objNode, "Attr.MaximumWidth", null);
            var intMinHeight = Xml_GetAttribute(objNode, "Attr.MinimumHeight", null);
            var intMinWidth = Xml_GetAttribute(objNode, "Attr.MinimumWidth", null);


            var varResizableParams = {
                handles: strHandles,
                maxHeight: intMaxHeight,
                maxWidth: intMaxWidth,
                minHeight: intMinHeight,
                minWidth: intMinWidth,
                stop: function (objEvent, objUI)
                {
                    if (objUI && objUI.size) {
                        // Get element data id.
                        var strDataID = Data_GetDataId(this.id);
                        if (!Aux_IsNullOrEmpty(strDataID))
                        {
                            // Get data node
                            var objNode = Data_GetNode(strDataID);
                            if (objNode != null)
                            {
                                // Update data with new size value
                                Data_SetNodeAttribute(objNode, "Attr.Width", objUI.size.width);
                                Data_SetNodeAttribute(objNode, "Attr.Height", objUI.size.height);

                                // Create resize event
                                var objEvent = Events_CreateEvent(strDataID, "Resize", null, true);

                                // Set event attributes
                                Events_SetEventAttribute(objEvent, "Width", objUI.size.width);
                                Events_SetEventAttribute(objEvent, "Height", objUI.size.height);

                                // If there are alsoResize items, I will create events for them as well.
                                var strAlsoResizeSelector = $(this).resizable("option", "alsoResize");

                                // The is critical indicator
                                var blnIsCritical = Data_IsCriticalEvent(objNode, "Event.SizeChange", true);

                                $(strAlsoResizeSelector).each(function ()
                                {
                                    var strDataId = Data_GetDataId(this.id);

                                    var objNode = Data_GetNode(strDataID);

                                    // Create resize event
                                    var objEvent = Events_CreateEvent(strDataID, "Resize", null, true);

                                    var objJQeuryItem = $(this);

                                    // Set event attributes
                                    Events_SetEventAttribute(objEvent, "Width", objJQeuryItem.width());
                                    Events_SetEventAttribute(objEvent, "Height", objJQeuryItem.height());

                                    // Checking is critical for "alsoResize" elements.
                                    blnIsCritical = blnIsCritical || Data_IsCriticalEvent(objNode, "Event.SizeChange", true);
                                });

                                // Raise event if critical
                                if (blnIsCritical)
                                {
                                    Events_RaiseEvents();
                                }
                            }
                        }

                        // Clear the memory
                        this.scaleXFactor = undefined;
                        this.scaleYFactor = undefined;
                    }
                },
                start: function (event, objUI) {
                    var objParentContainerWithScale = $(this).closest('div[style*=transform:][style*=scale]');
                    if (objParentContainerWithScale && objParentContainerWithScale.length > 0) {
                        var strMatrix = Common_MatrixToArray(objParentContainerWithScale.css('transform'));
                        if (strMatrix)
                        {
                            this.scaleXFactor = parseFloat(strMatrix[0]); // The matrix first parameter
                            this.scaleYFactor = parseFloat(strMatrix[3]); // The matrix third parameter

                            objUI.position.top = objUI.originalPosition.top / this.scaleYFactor;
                            objUI.position.left = objUI.originalPosition.left / this.scaleXFactor;
                        }
                    }
                },
                resize: function (event, objUI)
                {
                    if (this.scaleXFactor && this.scaleYFactor)
                    {
                        var changeWidth = objUI.size.width - objUI.originalSize.width; // find change in width
                        var newWidth = objUI.originalSize.width + changeWidth / this.scaleXFactor; // adjust new width by our scale factor

                        var changeHeight = objUI.size.height - objUI.originalSize.height; // find change in height
                        var newHeight = objUI.originalSize.height + changeHeight / this.scaleYFactor; // adjust new height by our scale factor

                        objUI.size.width = newWidth;
                        objUI.size.height = newHeight;

                        // This correction will fix the top position based on the width/height change of the width so changes will leave the 
                        // position of the object at original bottom/right position
                        if (objUI.originalPosition.left / this.scaleYFactor != objUI.position.left)
                        {
                            objUI.position.left = (objUI.originalPosition.left - changeWidth) / this.scaleXFactor;
                        }

                        if (objUI.originalPosition.top / this.scaleYFactor != objUI.position.top)
                        {
                            objUI.position.top = (objUI.originalPosition.top - changeHeight) / this.scaleYFactor;
                        }
                    }
                }
            };

            // Setting the resizable parameters as given.
            if (objSplittedParams.length > 1)
            {
                // Index starts from 1, because the first place is the handlers.
                for (var varIndex = 1; varIndex < objSplittedParams.length; varIndex++)
                {
                    var strParameter = objSplittedParams[varIndex].split(':');
                    if (strParameter.length == 2 && strParameter[0].length > 0 && strParameter[1].length > 0)
                    {
                        // Adding the new parameters to the object.
                        varResizableParams[strParameter[0]] = eval(strParameter[1]);
                    }
                }
            }

            objJQueryElement.resizable(varResizableParams);
        }
    }
}
/// </method>

/// <method name="Common_ApplyDroppableCapability">
/// <summary>
/// 
/// </summary>
function Common_ApplyDroppableCapability(strDataID, objJQueryElement)
{
    if (strDataID && objJQueryElement)
    {
        objJQueryElement.droppable( { drop: function(objEvent, objUI)
                                    {
                                        if(objUI && objUI.draggable)
                                        {
                                            if(!this.contains(objUI.draggable[0]))
                                            {
                                                // Get element data id.
                                                var strDataID = Data_GetDataId(this.id);
                                                if(!Aux_IsNullOrEmpty(strDataID))
                                                {
                                                    // Create ControlDropped event
	                                                var objEvent = Events_CreateEvent(strDataId,"ControlDropped",null,true); 
	
	                                                // Set event attributes
	                                                Events_SetEventAttribute(objEvent,"Attr.DroppedControl",Data_GetDataId(objUI.draggable[0].id));

                                                    // Raise events.
                                                    Events_RaiseEvents();
                                                }
                                            }
                                        }
                                    }});
    }
}
/// </method>

/// <method name="Common_ApplyUICapabilities">
/// <summary>
/// 
/// </summary>
function Common_ApplyUICapabilities(objWindow, strDataID, blnSelectable, blnResizable, blnDraggable, blnDroppable, strDirectionHandles, strDraggableParams)
{
    if (objWindow && !Aux_IsNullOrEmpty(strDataID))
    {
        var objElement = null;

        var objNode = Data_GetNode(strDataId);

        if (objNode.tagName == "WG:F")
        {
            var strFormType = Xml_GetAttribute(objNode, "Attr.Type", "");

            switch (strFormType) 
            {
                case "ModalWindow":
                case "ModalessWindow":
                    objElement = Web_GetElementById("WRP_"+strDataID, objWindow);
                    break;
                case "PopupWindow":
                    objElement = $("*[data-vwg_popupid='"+strDataID+"']")[0];
                    break;
        
            }
        }
        else
        {
            objElement = Web_GetElementByDataId(strDataID, objWindow);
        }

        if (objElement)
        {
            var objJQueryElement = objWindow.$(objElement);

            if (blnSelectable)
            {
                // Apply selectable capabilities.
                Common_ApplySelectableCapability(strDataID, objJQueryElement);
            }

            if (blnResizable)
            {
                // Apply resizable capabilities.
                Common_ApplyResizableCapability(strDataID, objJQueryElement, strDirectionHandles);
            }

            if (blnDraggable)
            {
                // Apply draggable capabilities.
                Common_ApplyDraggableCapability(strDataID, objJQueryElement, strDraggableParams);
            }

            if (blnDroppable)
            {
                // Apply droppable capabilities.
                Common_ApplyDroppableCapability(strDataID, objJQueryElement);
            }
        }
    }
}
/// </method>

/// <method name="Common_OnMouseOver">
/// <summary>
///
/// </summary>
function Common_OnMouseOver(strHandler, objElement, objWindow, objEvent, objExtraParams)
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strHandler) && objElement && objWindow && objEvent)
    {
        // Check if mouse is not already entered recieved element.
        if (!Web_IsAttribute(objElement, "vwgmouseenter", "1", true))
        {
            // Flag that mouse is entered recieved element.
            Web_SetAttribute(objElement, "vwgmouseenter", "1");

            // Get recieved handler's refference.
            var fncHandler = Remoting_GetMethod(strHandler);
            if (!Aux_IsNullOrEmpty(fncHandler))
            {
                // Invoke recieved handler.
                Aux_InvokeMethod(fncHandler, [objElement, 'mouseenter', objWindow, objEvent, objExtraParams]);
            }
        }
    }
}
/// </method>

/// <method name="Common_OnMouseOut">
/// <summary>
///
/// </summary>
function Common_OnMouseOut(strHandler, objElement, objWindow, objEvent, objExtraParams)
{
    // Validate recieved arguments.
    if (!Aux_IsNullOrEmpty(strHandler) && objElement && objWindow && objEvent)
    {
        // Get event related source element.
        var objRelatedSource = Web_GetEventRelatedSource(objEvent);
        if (objRelatedSource)
        {
            // Check if related source element is contained in recieved element.
            if (!Web_ContainsElement(objElement, objRelatedSource))
            {
                // Flag that mouse did not entered recieved element.
                Web_SetAttribute(objElement, "vwgmouseenter", "");

                // Get recieved handler's refference.
                var fncHandler = Remoting_GetMethod(strHandler);
                if (!Aux_IsNullOrEmpty(fncHandler))
                {
                    // Invoke recieved handler.
                    Aux_InvokeMethod(fncHandler, [objElement, 'mouseleave', objWindow, objEvent, objExtraParams]);
                }
            }
        }
    }
}
/// </method>

/// <method name="Common_InitializeDefaultScrollBars">
/// <summary>
///
/// </summary>
function Common_InitializeDefaultScrollBars(strID, strScrollOrientation, objWindow)
{
    // Get the scrollable element inside the control
    var objScrollableElement = Controls_GetScrollableElementByID(strID, objWindow);

    // There's a chance that there's no vwgscrollable element
    if (objScrollableElement)
    {
        switch (strScrollOrientation)
        {
            case "B":
                objScrollableElement.style.overflow = "auto";
                break;
            case "H":
                objScrollableElement.style.overflowY = "hidden";
                objScrollableElement.style.overflowX = "auto";
                break;
            case "V":
                objScrollableElement.style.overflowY = "auto";
                objScrollableElement.style.overflowX = "hidden";
                break;
            default:
                objScrollableElement.style.overflow = "hidden";
                break;
        }
    }

    return objScrollableElement;
}
/// <method name="Common_ApplyAccessibilityFeatures">
/// <summary>
/// This method gets a DOM element (usually body) as objElement
/// It is responsible of drawing a label after every DOM element that has an attribute called data-accessiblename
/// Also, it will add Accessibility events wherever they are missing
/// </summary>
function Common_ApplyAccessibilityFeatures(objElement) {
    //Check if accessibility mode is on
    if (isAccessibilityMode == false){
        return;
	}

    //Draw a label after all inputs with the attribute of data-accessiblename
    $(objElement).find('input[data-accessiblename]').each(function () {
        var strId = $(this).attr('id');
        var strAccessibleName = $(this).attr('data-accessiblename');
        $(this).after('<label for="' + strId + '" style="display:none;">' + strAccessibleName + '</label>');
    });

    $(objElement).completeMissingAccessibilityEvents();
}
/// </method>

/// <method name="Common_EditingControlInputKeyDown">
/// <summary>
///
/// </summary>
function Common_EditingControlInputKeyDown(objInput, strID, objEvent, objWindow)
{
    switch (objEvent.keyCode)
    {
        case 9: // Tab
        case 13:// Enter
            ControlEditing_CreateEditingEvent(strID, objInput.value, objWindow);
            Events_RaiseEvents();
            break;
        case 27: // Escape
            ControlEditing_CancelEditing(strID, true, objWindow);
            break;
    }
}
/// </method>

/// <method name="Common_EditingControlInputKeyBlur">
/// <summary>
///
/// </summary>
function Common_EditingControlInputKeyBlur(objInput, strID, objEvent, objWindow)
{
    if (ControlEditing_CreateEditingEvent(strID, objInput.value, objWindow))
    {
        Events_RaiseEvents();
    }
}
/// </method>


/// <method name="Common_ProcessobjWebScoket">
/// <summary>
/// Process WebSocket 
/// Set the DataNode of the WebSocket component
/// </summary>
function Common_ProcessobjWebScoket(objWebSocketNode) {

    var objExistWebSocketNode = Xml_SelectSingleNode("/WG:Tags.Response/WC:Tags.WebSocket", mobjDataDomObject.documentElement);
    var stWebSocketNodeId = Controls_GetGuid(objExistWebSocketNode);
    objWebSocketNode = Data_SetNode(stWebSocketNodeId, objWebSocketNode.cloneNode(true));
}
