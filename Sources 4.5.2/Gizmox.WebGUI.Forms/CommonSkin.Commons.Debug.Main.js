
var mstrCurrentTab = null;


var mobjDebugOutputTBody = null;

var mobjDebugEventsTBody = null;

var mobjDebugResourcesTBody = null;
var mobjApplicationWindow = null;

var mintDebugSwitchTimeout = null;


function Debug_Initialize()
{
    top.Debug_SetDebugWindow(window);
    
    mobjDebugOutputTBody = Debug_GetElementById("VWG_TBODYOUTPUT");
    mobjDebugEventsTBody = Debug_GetElementById("VWG_TBODYEVENTS");
    
    mobjDebugResourcesTBody = Debug_GetElementByID("VWG_CNTRESOURCES");
}

// Print the message to 'Output' tab
function Debug_Log(strText)
{
    var objLogTR = mobjDebugOutputTBody.insertRow(mobjDebugOutputTBody.rows.length);
    var objLogTD = objLogTR.insertCell(0);
    objLogTD.appendChild(document.createTextNode(strText));
    
    Debug_ScrollIntoView(objLogTD);
}

function Debug_ClearOutput()
{
    while (mobjDebugOutputTBody.rows.length > 0) 
    {
        mobjDebugOutputTBody.deleteRow(0);
    }
}


// Load resources details page into the content container
function Debug_ShowResources(blnNewWindow, blnRoot)
{
    Settings_EnsureApplication();

	// Get URL of root resource page
	var strURL = mobjApplicationWindow.mstrBaseURL + "Resources.Manifest.wgx";
	
	// Get container
	var container = mobjApplicationWindow.$(mobjDebugResourcesTBody).children("iframe");
	
	// Decide whether to refresh the view
	var blnRefresh = (typeof container.attr("src") == "undefined") || container.attr("src") == "" || blnRoot;
	
	if(blnNewWindow){
		
		// open the current shown page in independent window
		mobjApplicationWindow.open(strURL);
	
	}else if(blnRefresh){
		
		// show root page of resources
		container.attr("src", strURL).show();
	}
}




/// <method name="Debug_LogEvent">
/// <summary>
/// Writes an event to the event viewer
/// </summary>
/// <param name="strSource"></param>
/// <param name="strMessage"></param>
/// <param name="strBody"></param>
/// <param name="objTag">An object to associate with log entry for further use when double clicked to inspect</param>
/// <param name="fncCallBack">Function to call when the log entry row double clicked. If not provided standard handler attached.</param>
function Debug_LogEvent(strSource,strSubject,strBody, strStats, objTag, fncCallBack)
{
    var objLogTR = mobjDebugEventsTBody.insertRow(mobjDebugEventsTBody.rows.length);
    
    var objLogTD = objLogTR.insertCell(0);
    objLogTD.appendChild(document.createTextNode(strSource));
    objLogTD = objLogTR.insertCell(1);
    objLogTD.appendChild(document.createTextNode(""));
    objLogTD = objLogTR.insertCell(2);
    objLogTD.appendChild(document.createTextNode(strStats ? strStats : ""));
    objLogTD = objLogTR.insertCell(3);
    objLogTD.appendChild(document.createTextNode(""));
    objLogTD = objLogTR.insertCell(4);
    objLogTD.appendChild(document.createTextNode(strSubject));
    objLogTD = objLogTR.insertCell(5);
    objLogTD.appendChild(document.createTextNode(""));
    objLogTD = objLogTR.insertCell(6);
    objLogTD.appendChild(document.createTextNode(String(strBody).substr(0,120)));
    objLogTD = objLogTR.insertCell(7);
    objLogTD.appendChild(document.createTextNode(""));
    
    
    objLogTR.title = objLogTR.vwgcontent = String(strBody); 
    
    // Provide objects related with log entry for further
    // use when double clicked to inspect
    if(objTag)
    {
		objLogTR.vwgtag = objTag.cloneNode(true);
    }

    // Attach provided event handler or the default one
    if(fncCallBack)
    {
		objLogTR.ondblclick = fncCallBack;
    }
    else
    {
		objLogTR.ondblclick = Debug_LogEventClick;
    }
    
    Debug_ScrollIntoView(objLogTD);
    
}

function Debug_ClearEvents()
{
    while (mobjDebugEventsTBody.rows.length > 0) 
    {
        mobjDebugEventsTBody.deleteRow(0);
    }
}

// Toggle position of debug panel - dock to right/bottom
function Debug_TogglePosition()
{
    Settings_EnsureApplication();
    var objAppWindow = mobjApplicationWindow;
	var objFrameSet = objAppWindow.$(window.parent.document.getElementById("VWG_DEBUG"));

	// if has cols turn to rows
	if(objFrameSet.attr("cols")){
		objFrameSet.attr("rows", objFrameSet.attr("cols")).removeAttr("cols");
	// else, has rows turn to cols
	}else{
		objFrameSet.attr("cols", objFrameSet.attr("rows")).removeAttr("rows");
	}
}

// Toggle filtering of response/request events
function Debug_ToggleFilterEvents(objButton)
{
    Settings_EnsureApplication();
	mobjApplicationWindow.mblnDebugEvents =! mobjApplicationWindow.mblnDebugEvents;

	if(objButton){
		if( mobjApplicationWindow.mblnDebugEvents ){
		    Debug_ButtonToggleOff(objButton, "Filter debug events");
		}else{
			Debug_ButtonToggleOn(objButton, "Resume debug events");
		}
	}
	
}

// Default handler for double click on log entry
function Debug_LogEventClick()
{
    Settings_EnsureApplication();
	
	var objWindow;
    var strProperties = "menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes";

    // Check whether the tag object provided and it's an element, format and print in a new window
    if(this.vwgtag && this.vwgtag.nodeName){
		objWindow = mobjApplicationWindow.open("", "_blank", strProperties, false);
		objWindow.document.write(mobjApplicationWindow.$.format((this.vwgtag)));
		objWindow.document.close();
    }
}

function Debug_ScrollIntoView(objElement)
{
    try {objElement.scrollIntoView(false);} catch(e) {}
}

function Settings_EnsureApplication()
{
    if(!mobjApplicationWindow){
        mobjApplicationWindow = top.Debug_GetApplicationWindow();        
    }
}


function Debug_Activate(strTab)
{
    clearTimeout(mintDebugSwitchTimeout);
    mintDebugSwitchTimeout = setTimeout("Debug_DoActivate('"+strTab+"');",50);
}

function Debug_DoActivate(strTab)
{
    if(mstrCurrentTab!=strTab)
    {
        if(mstrCurrentTab!=null)
        {
            Debug_Deactivate(mstrCurrentTab);
        }
        
        var objTab = Debug_GetElementById("VWG_TAB"+strTab);
        objTab.className="Debug-PageBarButton Debug-PageBarButton_Selected";
        
        var objContent = Debug_GetElementById("VWG_CNT"+strTab);
        objContent.style.display = "block";
        
        var objLabel = Debug_GetElementById("VWG_LBL"+strTab);
        objLabel.style.display = "block";
        
        var objButtons = Debug_GetElementById("VWG_BTN"+strTab);
        objButtons.style.display = "block";

        mstrCurrentTab = strTab;

        // On activate, show the results in the resources tab
        if( mstrCurrentTab == "RESOURCES" ){
			Debug_ShowResources(false, false);
        }
        
    }
}

function Debug_Deactivate(strTab)
{
    var objTab = Debug_GetElementById("VWG_TAB"+strTab);
    objTab.className="Debug-PageBarButton";
    
    var objContent = Debug_GetElementById("VWG_CNT"+strTab);
    objContent.style.display = "none";
    
    var objLabel = Debug_GetElementById("VWG_LBL"+strTab);
    objLabel.style.display = "none";
    
    var objButtons = Debug_GetElementById("VWG_BTN"+strTab);
    objButtons.style.display = "none";
}


function Debug_GetElementById(strId)
{
    return document.getElementById(strId);
}

function Debug_ButtonOn(objButton)
{
    objButton.className += " Debug-ToolBarBTN_Enter";
}

function Debug_ButtonOff(objButton)
{
	// We have to use non inline regex style, because obscuring is not indexing class name string well enough.
    objButton.className = objButton.className.replace(new RegExp(" Debug-ToolBarBTN_Enter", "g"), "");
}

function Debug_ButtonToggleOn(objButton, strTitle)
{
    objButton.className += " Debug-ToolBarBTN_Toggle";
    if(strTitle){
		Debug_SetTitle(objButton, strTitle);
    }
}

function Debug_ButtonToggleOff(objButton, strTitle)
{
    objButton.className = objButton.className.replace(new RegExp(" Debug-ToolBarBTN_Toggle", "g"), "");
    if(strTitle){
		Debug_SetTitle(objButton, strTitle);
    }
}

// Change the title attribute for the given "button" on the panel.
// The button (actually) should be a TD element with an image
function Debug_SetTitle(objButton, strTitle)
{
    if(!mobjApplicationWindow){
		Settings_EnsureApplication();
	}
	if(objButton){
		mobjApplicationWindow.$(objButton).children("img").get(0).title = strTitle;
	}
}
