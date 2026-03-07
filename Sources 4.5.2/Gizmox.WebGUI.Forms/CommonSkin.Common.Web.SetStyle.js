/// <method name="Web_SetStyle">
/// <summary>
///	Sets a given style to given element in a given window
/// </summary>
/// <param name="objElement">Reference to styled element.</param>
/// <param name="strType">The style type.</param>
/// <param name="objWindow">The handled window.</param>
/// <param name="objEvent">The handled event.</param>
function Web_SetStyle(objElement, strType, objWindow, objEvent)
{
    // If the element is valid
    if (objElement && mobjApp.Web_GetAttribute(objElement, "vwgsuspendmouseevents") != "1")
    {
        // variable for styling
        var strSubClass = "";

        // save base class if needed
        if (!objElement.guiclassname)
        {
            // Get element class
            var strClass = Web_RemoveWhiteSpace($.trim(objElement.className));

            // Remove selected class
            var arrClass = strClass.split(" ");

            // Check if class is selected
            if (strClass.indexOf("_Selected") != -1)
            {
                objElement.guiclassselected = strClass;


                arrClass.pop();
                strClass = arrClass.join(" ");
            }

            objElement.guilastclassname = arrClass.pop();

            // Set element base class
            objElement.guiclassname = strClass;
        }

        if (strType == "focus")
        {
            objElement.guiclassfocused = true;

            //the focus event occur after mousedown
            //if the last class was mouse mousedown we dont want the class to change to focus
            if (objElement.className.indexOf("_Down") != -1)
            {
                return;
            }
        }
        else if (strType == "blur")
        {
            objElement.guiclassfocused = false;
        }

        // set style
        switch (strType)
        {
            case "mouseenter": strSubClass = " " + objElement.guilastclassname + "_Enter"; break;
            case "mousedown": strSubClass = " " + objElement.guilastclassname + "_Down"; break;
            case "mouseup": strSubClass = " " + objElement.guilastclassname + "_Enter"; break;
            case "stickymode": strSubClass = " " + objElement.guilastclassname + "_Sticky"; break;
            case "selected": strSubClass = " " + objElement.guilastclassname + "_Selected"; break;
            case "focus": strSubClass = " " + objElement.guilastclassname + "_Focus"; break;
            case "disable": strSubClass = " " + objElement.guilastclassname + "_Disabled"; break;
            case "deselected": break;
            case "mouseleave":
            case "clear":
                // If element was previously focused
                if (objElement.guiclassfocused)
                {
                    strSubClass = " " + objElement.guilastclassname + "_Focus";
                }
                // If element was selected
                else if (objElement.guiclassselected)
                {
                    objElement.className = objElement.guiclassselected;
                    return;
                }
                break;
        }

        // apply style
        objElement.className = objElement.guiclassname + strSubClass;
    }
}
/// </method>

/// <method name="Web_RemoveWhiteSpace">
/// <summary>
/// Removes white spaces between words and next line chars
/// </summary>
/// <param name="strInput">The string to be checked.</param>
function Web_RemoveWhiteSpace(strInput)
{
    var strOutput = strInput;

    if (strOutput != "")
    {
        strOutput = strOutput.replace(/[\n\r]/g, "");
        while (strOutput.indexOf("  ") > -1)
        {
            strOutput = strOutput.replace("  ", " ");
        }
    }

    return strOutput;
}
/// </method>