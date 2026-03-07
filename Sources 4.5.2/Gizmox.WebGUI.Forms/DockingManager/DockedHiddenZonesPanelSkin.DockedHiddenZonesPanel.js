/// <method name="DockedHiddenZonesPanel_OnClick">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_OnClick(strPanelId, strZoneId, objWindow)
{
    var objHiddenPanelItem = Web_GetElementById("HZPH_" + strZoneId, objWindow);

    // check if this item is not already open
    if (objHiddenPanelItem && Web_GetAttribute(objHiddenPanelItem, "vwgOpened") != "true")
    {
        // Disable any async operation
        DockedHiddenZonesPanel_ClearItemTimeout(objHiddenPanelItem);

        // Show the pop up
        DockedHiddenZonesPanel_ShowZonePopUp(strPanelId, strZoneId, objWindow);
    }
}

/// </method>

/// <method name="DockedHiddenZonesPanel_OnMouseOut">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_OnMouseOut(objHiddenPanelItem)
{
    // Disable any async operation
    DockedHiddenZonesPanel_ClearItemTimeout(objHiddenPanelItem);
}
/// </method>

/// <method name="DockedHiddenZonesPanel_OnMouseOut">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_ClearItemTimeout(objItemElement)
{
    // Get the timeout id from he element
    var strTimeOutToken = Web_GetAttribute(objItemElement, "vwgTimeOutToken");

    // Change the style to default
    Web_SetStyle(objItemElement, "clear");

    // Clear the timeout
    if (strTimeOutToken)
    {
        Web_ClearTimeout(strTimeOutToken);
    }
}
/// </method>



/// <method name="DockedHiddenZonesPanel_OnMouseOver">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_OnMouseOver(strPanelId, strZoneId, objWindow)
{
    var objHiddenPanelItem = Web_GetElementById("HZPH_" + strZoneId, objWindow);

    if (objHiddenPanelItem)
    {
        // Change to hover style
        Web_SetStyle(objHiddenPanelItem, "mouseenter");

        // Check if not already opening
        if (Web_GetAttribute(objHiddenPanelItem, "vwgOpened") != "true")
        {
            // Take the delay from the skin
            var intExpandDelay = [Skin.HiddenZoneItemExpantionDelay];

            // start async operation for opening the pop up
            var strTimeOutToken = Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(DockedHiddenZonesPanel_ShowZonePopUp, strPanelId, strZoneId, objWindow), intExpandDelay);

            // Set the timeout ID on the element
            Web_SetAttribute(objHiddenPanelItem, "vwgTimeOutToken", strTimeOutToken);
        }
    }
}
/// </method>

/// <method name="DockedHiddenZonesPanel_ShowZonePopUp">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_ShowZonePopUp(strPanelId, strZoneId, objWindow)
{
    // Get the window if it wasn't given
    if (!objWindow)
    {
        objWindow = Forms_GetWindowByDataId(strPanelId);
    }

    // Create the show zone popup event and raise it
    var objVwgEvent = Events_CreateEvent(strPanelId, "ShowZonePopUp", null, true);
    Events_SetEventAttribute(objVwgEvent, "ZoneId", strZoneId);
    Events_RaiseEvents();
    Events_ProcessClientEvent(objVwgEvent);
}
/// </method>

/// <method name="DockedHiddenZonesPanel_OnZonePopUpFormLoad">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_OnZonePopUpFormLoad(strPanelId, strZoneId)
{
    DockedHiddenZonesPanel_SetHiddenPanelOpenedAttribute(strPanelId, strZoneId, "true");
}
/// </method>

/// <method name="DockedHiddenZonesPanel_OnZonePopUpFormClosed">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_OnZonePopUpFormClosed(strPanelId, strZoneId)
{
    DockedHiddenZonesPanel_SetHiddenPanelOpenedAttribute(strPanelId, strZoneId, "false");
}
/// </method>

/// <method name="DockedHiddenZonesPanel_SetHiddenPanelOpenedAttribute">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_SetHiddenPanelOpenedAttribute(strPanelId, strZoneId, strValue)
{
    var objWindow = Forms_GetWindowByDataId(strPanelId);
    if (objWindow)
    {
        var objHiddenPanelItem = Web_GetElementById("HZPH_" + strZoneId, objWindow);
        if (objHiddenPanelItem)
        {
            Web_SetAttribute(objHiddenPanelItem, "vwgOpened", strValue);
        }
    }
}
/// </method>

/// </method>

/// <method name="DockedHiddenZonesPanel_OnResize">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_OnResize(strDockingManagerGuid, strPanelGuid, strDockingSide, objEvent, objWindow)
{
    DockedHiddenZonesPanel_UpdateScrollers(strDockingManagerGuid, strPanelGuid, strDockingSide, objEvent, objWindow);
}
/// </method>

/// <method name="DockedHiddenZonesPanel_UpdateScrollers">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_UpdateScrollers(strDockingManagerGuid,strPanelGuid, strDockingSide, objEvent, objWindow)
{
    // Indicate that the DockedHiddenZonesPanel_UpdateScrollers has made a decision about showing the scrollers or not
    Data_SetAttribute(strPanelGuid, "vwgShowScrollers", "1");

    // Get the scrollable panel element
    var objItemsContainerElement = Web_GetElementById("HPIC_" + strDockingManagerGuid + strDockingSide, objWindow),
        blnShow = false;

    // Check the current scrollers' state
    var blnHasScrollers = Web_GetAttribute(objItemsContainerElement, "vwgHasScrollers");

    // Check the orientation and if the scrollers should be shown
    if (strDockingSide == 'T' || strDockingSide == 'B')
    {
        // Check if scroll is needed
        if (objItemsContainerElement.scrollWidth > objItemsContainerElement.clientWidth)
        {
            // Set attribute to scroll = visible
            Data_SetAttribute(strPanelGuid, "vwgShowScrollers", "2");
            
            //Indicate that the desired state is 'show'
            blnShow = true;
        }
    }
    else
    {
        // Check if scroll is needed
        if (objItemsContainerElement.scrollHeight > objItemsContainerElement.clientHeight)
        {
            // Set attribute to scroll = visible
            Data_SetAttribute(strPanelGuid, "vwgShowScrollers", "2");

            //Indicate that the desired state is 'show'
            blnShow = true;
        }
    }

    // Check if the state of the scrollers should be changed
    if ((blnHasScrollers == "0" && blnShow) || (blnHasScrollers == "1" && !blnShow))
    {
        Controls_RedrawControlById(objWindow, strPanelGuid);
    }
}
/// </method>

/// <method name="DockedHiddenZonesPanel_Scroll">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_Scroll(obThis,strMouseEventType,objWindow,objEvent)
{
    var objHiddenPanelItem = $(obThis);

    var strPanelId = objHiddenPanelItem.attr("vwgPanelId");
    var strSide = objHiddenPanelItem.attr("vgwScrollSide");

    // Do scroll according to the mouse event type
    switch (strMouseEventType)
    {
        case 'mouseenter':
            // Scroll slow
            DockedHiddenZonesPanel_StartScroll(obThis, objWindow, strPanelId, strSide, 50);
            break;
        case 'mouseleave':
            // Stop scrolling
            DockedHiddenZonesPanel_StopScroll(obThis, objWindow);
            break;
        case 'mousedown':
            // Stop scrolling
            DockedHiddenZonesPanel_StopScroll(obThis, objWindow);

            // Scroll fast
            DockedHiddenZonesPanel_StartScroll(obThis, objWindow, strPanelId, strSide, 20);
            break;
        case 'mouseup':
            // Stop scrolling
            DockedHiddenZonesPanel_StopScroll(obThis, objWindow);

            // Scroll slow
            DockedHiddenZonesPanel_StartScroll(obThis, objWindow, strPanelId, strSide, 50);
            break;
    }

    // Set the element's style
    Web_SetStyle(obThis, strMouseEventType, objWindow, objEvent);
}
/// </method>

/// <method name="DockedHiddenZonesPanel_StopScroll">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_StopScroll(objScrollingElement, objWindow)
{
    if (objScrollingElement != null && objScrollingElement.ScrollingInterval != null)
    {
        // Clear previous scrolling interval.
        Web_ClearInterval(objScrollingElement.ScrollingInterval, objWindow);

        objScrollingElement.ScrollingInterval = null;
    }
}
/// </method>

/// <method name="DockedHiddenZonesPanel_StartScroll">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_StartScroll(obScrollerElement, objWindow, strPanelId, strSide, intInterval)
{
    // Get the scrollable panel
    var objScrollablePanel = Web_GetElementById(strPanelId, objWindow);

    // Call the scroll logic async
    obScrollerElement.ScrollingInterval = Web_SetInterval(function ()
    {
        DockedHiddenZonesPanel_StartScrollAsynch(objScrollablePanel, strSide, objWindow);
    }, intInterval, objWindow);
}
/// </method>

/// <method name="DockedHiddenZonesPanel_StartScrollAsynch">
/// <summary>
/// 
/// </summary>
function DockedHiddenZonesPanel_StartScrollAsynch(objScrollablePanel, strSide, objWindow)
{
    // Do the actual scrolling according to the side
    switch (strSide)
    {
        case 'top':
            objScrollablePanel.scrollTop -= 10;
            break;
        case 'bottom':
            objScrollablePanel.scrollTop += 10;
            break;
        case 'left':
            objScrollablePanel.scrollLeft -= 10;
            break;
        case 'right':
            objScrollablePanel.scrollLeft += 10;
            break;
    }
}
/// </method>
