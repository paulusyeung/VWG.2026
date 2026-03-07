/// <page name="TabControl.js">
/// <summary>
/// This script is used as a shared TabControl script.
/// </summary>
function TabControl_UpdateHandler(objTabControlNode)
{
    if (objTabControlNode) 
    {
        if (Xml_IsAttribute(objTabControlNode, "Attr.Mode", "M"))
        {
            // Clear Selected id
			Xml_SetAttribute(objTabControlNode, "Attr.Selected", "");

            // Redraw control.
			Controls_RedrawControlByNode(Forms_GetWindowByDataId(Xml_GetAttribute(objTabControlNode,"Attr.Id", "")), objTabControlNode);            
        }
        else
        {
            TabControl_InitializeTabs(objTabControlNode, !Xml_IsAttribute(objTabControlNode, "Attr.Expanded", "0"),true);
        }
    }
}

function TabControl_CloseTab(strGuid,objEvent)
{
	var objVwgEvent = Events_CreateEvent(strGuid, "TabClose");

	Events_RaiseEvents();

	Events_ProcessClientEvent(objVwgEvent);
	
	objEvent.cancelBubble=true;
}

function TabControl_OnResize(strGuid, objWindow, blnIsSpread, blnMultiLine, intTabLayout)
{
    if (!Aux_IsNullOrEmpty(strGuid) && objWindow)
    {
        // Get tab control element.
        var objTabControlElement = Web_GetElementByDataId(strGuid, objWindow);
        if (objTabControlElement)
        {
            // Check if tab control element is visible.
            if ($(objTabControlElement).is(":visible"))
            {
                // Get VWGScrollable div
                var objTabsDiv = Web_GetElementById("VWGScrollable_" + strGuid, objWindow);
                if (objTabsDiv)
                {
                    // Get resize handle
                    var intTabControlResizeHandle = objTabsDiv.TabControlResizeHandle;

                    // Check valid intTabControlResizeHandle value
                    if (!Aux_IsNullOrEmpty(intTabControlResizeHandle))
                    {
                        // Clear previous timeout 
                        Web_ClearTimeout(intTabControlResizeHandle);
                    }

                    // Asynch execution of the TabControl_UpdateScrollButtonsEnd function.
                    objTabsDiv.TabControlResizeHandle = mobjApp.Aux_InvokeCallbackDelegateWithDelay(new mobjApp.Aux_CallbackDelegate(mobjApp.TabControl_OnResizeEnd, strGuid, objWindow, blnIsSpread, blnMultiLine, intTabLayout), 10, mobjApp);
                }
            }
        }
    }
}

function TabControl_OnResizeEndSpread(strGuid, objWindow) {
	if (strGuid && objWindow) {
		var blnVisible = false;

		// Get tab headers div element
		var objTabHeadersDiv = Web_GetElementById("TABHEADERS_" + strGuid, objWindow);

		if (objTabHeadersDiv) {
			// Get number if tabs
			var intChildCount = objTabHeadersDiv.childNodes.length;

			if (intChildCount > 0) {
				// Get tab headers div rect
				var objTabHeadersDivRect = Web_GetRect(objTabHeadersDiv);

				var intChild = -1;

				// Loop on all childs
				for (intChild = 0; intChild < intChildCount; intChild++) {
					// Get current child.
					var objChildElement = objTabHeadersDiv.childNodes[intChild];
					if (objChildElement) {
						// Get current child's rectangle.
						var objChildElementRect = Web_GetRect(objChildElement);
						if (objChildElementRect) {
							// Check if current child is hidden.
							if (objChildElementRect.top >= objTabHeadersDivRect.bottom ||
                                objChildElementRect.left >= objTabHeadersDivRect.right) {
								// Set Tab More visiblity flag to true
								blnVisible = true;
								break;
							}
						}
					}
				}

				// Get Tab More element
				var objTabMore = Web_GetElementById("TABMORE_" + strGuid, objWindow);

				if (objTabMore) {
					// Update More button display
					objTabMore.style.display = (blnVisible ? "" : "none");

					// Get tab control node
					var objTabControlNode = Data_GetNode(strGuid);

					if (objTabControlNode) {
						var blnRedraw = false;

						// If More tab should be visible
						if (blnVisible) {
							// Set MoreTabVisible to true
							Data_SetNodeAttribute(objTabControlNode, "Attr.MoreTabVisible", "1");

							var strNewMoreTabStartIndex = intChild.toString();

							// Get MoreTabStartIndex current value
							var strCurrentMoreTabStartIndex = Data_GetNodeAttribute(objTabControlNode, "Attr.MoreTabStartIndex", "");

							// Set MoreTabStartIndex new value
							Data_SetNodeAttribute(objTabControlNode, "Attr.MoreTabStartIndex", strNewMoreTabStartIndex);

							// Check if value change
							if (strCurrentMoreTabStartIndex != strNewMoreTabStartIndex) {
								// Check if More mode is active
								if (Xml_IsAttribute(objTabControlNode, "Attr.Mode", "M")) {
									// Set redraw flag to true
									blnRedraw = true;
								}
							}
						}
						else {
							// Set MoreTabVisible to false
							Data_SetNodeAttribute(objTabControlNode, "Attr.MoreTabVisible", "0");

							// Check if we in More mode
							if (Xml_IsAttribute(objTabControlNode, "Attr.Mode", "M")) {
								// Clear More mode
								Xml_SetAttribute(objTabControlNode, "Attr.Mode", "");

								// Set redraw flag to true
								blnRedraw = true;
							}
						}

						// Redraw tabcontrol if needed
						if (blnRedraw) {
							if (Xml_IsEmptyAttribute(objTabControlNode, "Attr.ClientUpdateHandler")) {
								Controls_RedrawControlByNode(objWindow, objTabControlNode);
							}
							else {
								Controls_ExeceuteClientUpdateHandler(objTabControlNode);
							}
						}
					}
				}
			}
		}
	}

	/// </method>
}

function TabControl_OnResizeEnd(strGuid, objWindow, blnIsSpread, blnMultiLine, intTabLayout)
{
    if (!Aux_IsNullOrEmpty(strGuid) && objWindow)
    {
        // Get VWGScrollable div
        var objTabsDiv = Web_GetElementById("VWGScrollable_" + strGuid, objWindow);
        if (objTabsDiv)
        {
    	    // Check if multiline
    	    if (blnMultiLine && objTabsDiv && !blnIsSpread)
            {
                var intSeperatorHeight = 0;
                var objTabControlSeperator = Web_GetElementById("VWGTCSP_" + strGuid, objWindow);
                if (objTabControlSeperator)
                {
                    if (intTabLayout == 0) // top
                    {
                        // Set tab control seperator top value
                        objTabControlSeperator.style.top = objTabsDiv.clientHeight + "px";
                    }
                    else // bottom
                    {
                        // Set tab control seperator top value
                        objTabControlSeperator.style.bottom = objTabsDiv.clientHeight + "px";
                    }

                    // Get seperator skin height
                    intSeperatorHeight = parseInt(objTabControlSeperator.getAttribute("vwgsepheight"), 10);
                }

                // Get tab control body content
                var objTabControlBodyContent = Web_GetElementById("VWGTCBC_" + strGuid, objWindow);
                if (objTabControlBodyContent)
                {
                    if (intTabLayout == 0) // top
                    {
                        // Set tab control body content top value
                        objTabControlBodyContent.style.top = (intSeperatorHeight + parseInt(objTabsDiv.clientHeight)).toString() + "px";
                    }
                    else // bottom
                    {
                        // Set tab control body content top value
                        objTabControlBodyContent.style.bottom = (intSeperatorHeight + parseInt(objTabsDiv.clientHeight)).toString() + "px";
                    }
                }
            }
            else
            {
            	// If in Spread appearance mode.
            	if (blnIsSpread) {
            		TabControl_OnResizeEndSpread(strGuid, objWindow);
		    	}

            	else {
            		// Check if there should be scrollers
            		var blnDisplyNavigationButtons = (objTabsDiv.scrollWidth > objTabsDiv.clientWidth);

            		// Get scrollers buttons
            		var objNavigatePrevButton = Web_GetElementById("VWG_NavigatePrev_" + strGuid, objWindow);
            		var objNavigateNextButton = Web_GetElementById("VWG_NavigateNext_" + strGuid, objWindow);

                if (objNavigatePrevButton && objNavigateNextButton)
                {
            			//update scrollers buttons visibility
            			objNavigatePrevButton.style.visibility = objNavigateNextButton.style.visibility = (blnDisplyNavigationButtons ? "" : "hidden");
            		}
            	}
            }
        }
    }
}

function TabControl_FireValueChange(objWindow,objEvent,strGuid,strValue,blsEnforceRaise,objCallbackDelegate)
{
    // Fire the value change event and suspend raise event if click or double click are critical.
	var objVWGEvent = Events_CreateTraceableEvent(objWindow, objEvent, strGuid, "ValueChange", null, true);

	Events_SetEventAttribute(objVWGEvent, "Value", strValue);	
	
	// In case that value change is critical - emulate the main on click handler and cacnel buble.
	if (blsEnforceRaise || Data_IsCriticalEvent(strGuid, "Event.ValueChange"))
    {
        if(objEvent)
        {
            if (Web_IsRightClick(objEvent))
            {
                Web_OnRightClick(objEvent, objWindow, true);
            }
            else
            {
                // Handles the click event and forces raise (this 'overload' cancels the click bubble.)
                Web_OnClick(objEvent, objWindow, true, null, objCallbackDelegate);
            }
        }
        else
        {
            Events_RaiseEvents();            
        }
    }

    Events_ProcessClientEvent(objVWGEvent);
}


function TabControl_ChangeTab(strGuid, objWindow, objEvent, blnIsRightClick)
{
	// Get the tab node
	var objNode = Data_GetNode(strGuid);
	if(objNode && !Data_IsDisabled(objNode))
	{
	    // Get tab control node.
		var objTabControlNode = objNode.parentNode;
		var strTabControlDataId = null;
		var blnShowPopup = false;

		if (objTabControlNode)
		{
		    // Get tab control id.
		    strTabControlDataId = Xml_GetAttribute(objTabControlNode, "Id", "");

		    var blnIsCollapsed = Xml_IsAttribute(objTabControlNode, "Attr.Expanded", 0);

		    // Check if selected tab page is not already selected.
		    if (!Xml_IsAttribute(objTabControlNode, "Attr.Selected", strGuid))
		    {
		        if (!Aux_IsNullOrEmpty(strTabControlDataId))
		        {
		            // Check if tab is not loaded
		            var blnIsNotLoaded = Xml_GetAttribute(objNode, "Attr.Loaded", "") == "0";

		            // Check if value change event is critical

		            var blnValueChangeCritical = Data_IsCriticalEvent(strTabControlDataId, "Event.ValueChange");
		            var objShowDropDownDelegate = null;

		            // If tab page is not loaded or value change is critical
		            if (blnIsCollapsed && (blnIsNotLoaded || blnValueChangeCritical))
		            {
		                // Create delegate
		                objShowDropDownDelegate = { fncMethod: TabControl_ShowDropDown, arrArguments: [objWindow, strGuid, objNode, strTabControlDataId, objTabControlNode] };
		            }

		            // Update selected index
		            Xml_SetAttribute(objTabControlNode, "Attr.Selected", strGuid);

		            // If tab is not loaded
		            if (blnIsNotLoaded)
		            {		                
		                TabControl_FireValueChange(objWindow, objEvent, strTabControlDataId, strGuid, true, objShowDropDownDelegate, blnIsRightClick);
		            }
		            else
		            {
		                //if the event is critical the tab will be draw in the event
		                if (!blnValueChangeCritical)
		                {
		                    if (!blnIsCollapsed)
		                    {
		                        if (Xml_IsEmptyAttribute(objTabControlNode, "Attr.ClientUpdateHandler"))
		                        {
		                            // Redraw the control in delay so the infrastructure will handle the mousedown/mouseclick events 
		                            // If we don't delay it, the elements are seperated from the DOM and the events do not bubble to the body handlers
		                            Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Controls_RedrawControlByNode, objWindow, objTabControlNode), 10);
		                        }
		                        else
		                        {
		                            Controls_ExeceuteClientUpdateHandler(objTabControlNode);
		                        }
		                    }
		                    else
		                    {
		                        blnShowPopup = true;
		                    }
		                }

		                TabControl_FireValueChange(objWindow, objEvent, strTabControlDataId, strGuid, false, objShowDropDownDelegate, blnIsRightClick);
		            }
		        }
		    }
		    else
		    {
		        blnShowPopup = blnIsCollapsed;
		    }

            // Check if tab control is collapsed and we need to show popup
		    if (blnShowPopup)
		    {
                // Show popup
		        TabControl_ShowDropDown(objWindow, strGuid, objNode, strTabControlDataId, objTabControlNode);
		    }
		}
	}
}


/// <method name="TabControl_InitializeTabs">
/// <summary>
/// 
/// </summary>
function TabControl_InitializeTabs(objTabControlNode, blnSelectTab, blnSyncTabPages)
{
    var objTempTabControl = null;

    // Validate node
    if (objTabControlNode)
    {
        // Get selected tab id
        var strSelectedTab = null;

        // Get selected tab Id
        strSelectedTab = "VWG_" + Xml_GetAttribute(objTabControlNode, "Attr.Selected");

        var objTabControlTabsContainerCurrent = null;

        var objSelectedTab = null;

        // Get active window
        var objWindow = Web_GetActiveWindow();

        // Validate window
        if (objWindow)
        {
            // Get tabcontrol id
            var strTabControlId = Data_GetNodeAttribute(objTabControlNode, "Attr.Id", "");

            // Validate tabcontrol id
            if (!Aux_IsNullOrEmpty(strTabControlId))
            {
                if (!blnSelectTab)
                {
                    Xml_SetAttribute(objTabControlNode, "Attr.Selected", "");
                }

                // Add TabControlDrawDirtyPages attribute
                Xml_SetAttribute(objTabControlNode, "Attr.TabControlDrawDirtyPages", "1");

                // Get tabcontrol new html
                var strTempTabControl = Controls_GetHtmlFromNode(objTabControlNode, strTabControlId);

                // Remove TabControlDrawDirtyPages attribute
                Xml_RemoveAttribute(objTabControlNode, "Attr.TabControlDrawDirtyPages");

                if (!blnSelectTab)
                {
                    Xml_SetAttribute(objTabControlNode, "Attr.Selected", strSelectedTab);
                }

                if (!Aux_IsNullOrEmpty(strTempTabControl))
                {
                    // Get current tabcontrol tabs container
                    objTabControlTabsContainerCurrent = Web_GetWebElement("VWGTCTC_" + strTabControlId, objWindow);

                    // Create containing span
                    objTempTabControl = objWindow.document.createElement("DIV");

                    // Set temp tab control html
                    Web_SetInnerHtml(objTempTabControl, strTempTabControl);                   

                    // Get current tabcontrol headers table
                    var objTabControlHeadersTableCurrent = Web_GetWebElement("VWGTCHD_" + strTabControlId, objWindow);

                    // Get new tabcontrol headers table
                    var objTabControlHeadersTableNew = Web_GetContextElementById(objTempTabControl, "VWGTCHD_" + strTabControlId);

                    // NOTE: The objTabControlHeadersTableCurrent might be undefined in logical mode. (No headers)
                    if (objTabControlHeadersTableCurrent)
                    {
                        // Replace current tabcontrol headers table with new tabcontrol headers table
                        objTabControlHeadersTableCurrent.parentNode.replaceChild(objTabControlHeadersTableNew, objTabControlHeadersTableCurrent);
                    }
                    
                    if (objTabControlHeadersTableCurrent && blnSyncTabPages)
                    {
                        // Get new tabcontrol tabs container
                        var objTabControlTabsContainerNew = Web_GetContextElementById(objTempTabControl, "VWGTCTC_" + strTabControlId);

                        // Get number of tab pages
                        var intNumberOfTabPages = objTabControlTabsContainerNew.children.length;

                        // Loop on all tab pages on the new tab control and add/replace them to current tab control
                        for (var i = intNumberOfTabPages - 1; i >= 0; i--)
                        {
                            var objNewTabPage = objTabControlTabsContainerNew.children[i];

                            // Get tab page id
                            var strVWGId = objNewTabPage.id;

                            // Get tab page web element
                            var onjCurrentTabPage = Web_GetWebElement(strVWGId, objWindow);
                            if (onjCurrentTabPage)
                            {
                                // Replace tab page element with the new tab page
                                objTabControlTabsContainerCurrent.replaceChild(objNewTabPage, onjCurrentTabPage);
                            }
                            else
                            {
                                // Add New tabpage web element
                                objTabControlTabsContainerCurrent.appendChild(objNewTabPage);
                            }
                        }

                        // Get number of tab pages
                        intNumberOfTabPages = objTabControlTabsContainerCurrent.children.length;

                        // Loop on all tab pages on the current tab control and remove not needed tab pages
                        for (var i = intNumberOfTabPages - 1; i >= 0; i--)
                        {
                            var objTabPage = objTabControlTabsContainerCurrent.children[i];

                            // Get tab page VWG id
                            var strVWGId = objTabPage.id;

                            // Get tab page id
                            var strId = Data_GetDataId(strVWGId);

                            // Get tab page data node
                            var objTabPageNode = Data_GetNode(strId, objTabControlNode);
                            if (!objTabPageNode)
                            {
                                // Remove tab page element
                                objTabControlTabsContainerCurrent.removeChild(objTabPage);
                            }
                            else
                            {
                                var strIsDirty = Xml_GetAttribute(objTabPageNode, "Attr.IsDirty", "");

                                if (strIsDirty == "0" || strIsDirty == "1")
                                {
                                    // remove is dirty attribute attribute.
                                    Xml_RemoveAttribute(objTabPageNode, "Attr.IsDirty");
                                }

                                // If tab page id is the selected id - set selected tab
                                if (blnSelectTab && strVWGId == strSelectedTab)
                                {
                                    objSelectedTab = objTabPage;
                                }
                            }
                        }
                    }
                    else if (blnSelectTab)
                    {
                        // Get selected tab element.
                        objSelectedTab = Web_GetElementById(strSelectedTab, objWindow);
                    }

                    if (objTabControlTabsContainerCurrent && objTabControlTabsContainerCurrent.children)
                    {
                        // Set tab element display value
                        Web_SetElementsDisplay(objTabControlTabsContainerCurrent.children, blnSelectTab ? objSelectedTab : null);
                    }
                }
            }
        }
    }

    return objTempTabControl;
}
/// </method>

/// <method name="TabControl_ScrollIntoView">
/// <summary>
/// Scrolls tab header into view.
/// </summary>
/// <param name="objWindow">The handled window.</param>
/// <param name="strTabGuid">ID of header to scroll into view.</param>
/// <param name="strContainerGuid">The scrollable element ID.</param>
/// <param name="intMode">The scrolling mode - 0 for vertical and 1 for horizontal.</param>
function TabControl_ScrollIntoView(objWindow,strTabGuid, strContainerGuid, intMode)
{
    // Get scrollable container.
    
    var objScrollableContainer = null;

    if(!Aux_IsNullOrEmpty(strContainerGuid))
    {
        objScrollableContainer = Web_GetElementByDataId(strContainerGuid);
    
        if(objScrollableContainer)
        {
            objScrollableContainer = Controls_GetScrollableElement(objScrollableContainer);
        }
    }
    
    // Get the tab element.
    var objTabElement = null;
    
    if(!Aux_IsNullOrEmpty(strTabGuid))
    {        
        objTabElement = Web_GetElementById("TAB_" + strTabGuid,objWindow);
    }
    
    if(objScrollableContainer && objTabElement && intMode)
    {
        //scroll into view
        Web_ScrollIntoView(objTabElement, objScrollableContainer, intMode);
    }
}
/// </method>

/// <method name="TabControl_StartScroll">
/// <summary>
///
/// </summary>
/// <param name="objElement">The scrollable element.</param>
/// <param name="intPixelsToScroll">The amount of pixels to scroll.</param>
/// <param name="intIntervalTime">The amount of milliseconds to interval the scrolling.</param>
/// <param name="intOrientation">The scrolling orientation - 0 for vertical and 1 for horizontal</param>
/// <param name="objWindow">The handled window.</param>
/// <param name="objEvent">The mouse down event.</param>
function TabControl_StartScroll(objElement,intPixelsToScroll,intIntervalTime,intOrientation,objWindow,objEvent)
{
    // Check if left click has been done.
    if(Web_IsLeftClick(objEvent))
    {
        // Preserve function parameters. 
        TabControl_StartScroll.Element = objElement;
        TabControl_StartScroll.PixelsToScroll = intPixelsToScroll;
        TabControl_StartScroll.Orientation = intOrientation;
        TabControl_StartScroll.Window = objWindow;    
        TabControl_StartScroll.ScrollingInterval = Web_SetInterval("mobjApp.TabControl_StartScrollAsynch()",intIntervalTime,objWindow);
    }
}
/// </method>

/// <method name="TabControl_StartScrollAsynch">
/// <summary>
///
/// </summary>
function TabControl_StartScrollAsynch()
{
    // Restore function parameters. 
    var objElement = TabControl_StartScroll.Element;
    var intPixelsToScroll = TabControl_StartScroll.PixelsToScroll;
    var intOrientation = TabControl_StartScroll.Orientation;    
    if(objElement)
    {
        // Vertical scrolling.
        if(intOrientation == 0)
        {
            objElement.scrollTop +=intPixelsToScroll;
        }
        
        // Horizontal scrolling.
        else if(intOrientation == 1)
        {
            objElement.scrollLeft +=intPixelsToScroll;
        }
    }
}
/// </method>

/// <method name="TabControl_StopScroll">
/// <summary>
/// Stop the received element from interval scrolling.
/// </summary>
/// <param name="objElement">The scrollable element.</param>
function TabControl_StopScroll(objElement)
{
    if(TabControl_StartScroll.ScrollingInterval!=null && TabControl_StartScroll.Window!=null)
    {
        // Clear previous scrolling interval.
        Web_ClearInterval(TabControl_StartScroll.ScrollingInterval,TabControl_StartScroll.Window);
        
        TabControl_StartScroll.ScrollingInterval=null;
    }
}
/// </method>

/// <method name="TabControl_ExpandToggle">
/// <summary>
/// toggle expand button.
/// </summary>
function TabControl_ExpandToggle(strTabControlDataId, objWindow, objEvent)
{
    // Define a raise event flag.
    var blnRaiseEvents = false;

    // Get node data
    var objTabControlNode = Data_GetNode(strTabControlDataId);
    if (objTabControlNode)
    {
        // Exit on disabled control
        if (Data_IsDisabled(objTabControlNode)) return;

        // Get new collapsed state
        var blnCollapsed = !Xml_IsAttribute(objTabControlNode, "Attr.Expanded", "0");

        // If not collapsed
        if (!blnCollapsed) 
        {
            // Get restored height
            var intRestoredHeight = parseInt(Xml_GetAttribute(objTabControlNode, "Attr.RestoredHeight", "0"));

            // Check vaild height
            if (!isNaN(intRestoredHeight) && intRestoredHeight > 0) 
            {
                // Update height to original
                TabControl_UpdateHeight(objTabControlNode, intRestoredHeight);
            }
        }
        // If collapsed
        else 
        {
            // Update height to header height
            TabControl_UpdateHeight(objTabControlNode, TabControl_GetTabHeaderHeight(objWindow, strTabControlDataId, objTabControlNode));
        }

        // Update state
        Xml_SetAttribute(objTabControlNode, "Attr.Expanded", blnCollapsed ? "0" : "1");

        // Create the expand change event
        var objExpandEvent = Events_CreateEvent(strTabControlDataId, "Expand", "", true, false);

        // Set event parameter to the current state
        Events_SetEventAttribute(objExpandEvent, "Attr.Expanded", blnCollapsed ? "false" : "true");

        // Set the raise event flag
        var strEventId = ["Event.SizeChange"];
        strEventId.push(blnCollapsed ? "Event.Collapse" : "Event.Expand");
        blnRaiseEvents = Data_IsCriticalEvent(objTabControlNode, strEventId, true);

        // Redraw control
        Controls_RedrawControlByNode(objWindow, objTabControlNode);

        // Raise event if needed
        if (blnRaiseEvents)
        {
            Events_RaiseEvents();
        }

        Events_ProcessClientEvent(objExpandEvent);
    }
}
/// </method>

/// <method name="TabControl_UpdateHeight">
/// <summary>
/// Updates tab control height.
/// </summary>
function TabControl_UpdateHeight(objTabControlNode, intHeight)
{
    if (objTabControlNode)
    {
        // Set height
        Xml_SetAttribute(objTabControlNode, "Attr.Height", intHeight);
    }
}
/// </method>

/// <method name="TabControl_ShowDropDown">
/// <summary>
/// 
/// </summary>
function TabControl_ShowDropDown(objWindow, strTabPageDataId, objTabPageNode, strTabControlDataId, objTabControlNode)
{
    if (!Aux_IsNullOrEmpty(strTabPageDataId) && objTabPageNode && objTabControlNode && !Aux_IsNullOrEmpty(strTabControlDataId) && objWindow)
    {
        // Get current tab page's form.
        var objFormNode = Data_GetFormNodeByDataId(strTabPageDataId);
        if (objFormNode)
        {
            // Check if current tab page's form is the active form.
            if (Xml_IsAttribute(objFormNode, "Attr.Id", Data_GetDataId(mstrActiveWindowGuid)))
            {
                // Get a tab control tabs container element.
                var objTabControlTabsContainerElement = Web_GetElementById("VWGTCTC_" + strTabControlDataId, objWindow);
                if (objTabControlTabsContainerElement)
                {
                    // Create a dropdown element.
                    var objDropDownElement = objWindow.document.createElement("DIV");

                    // Set dropdown element's id and style.
                    objDropDownElement.id = "VWGTCDD_" + strTabControlDataId;
                    objDropDownElement.style.width = "100%";
                    objDropDownElement.style.height = "100%";
                    objDropDownElement.style.top = "0";
                    objDropDownElement.style.left = "0";
                    objDropDownElement.style.position = "absolute";

                    objDropDownElement.className = objTabControlTabsContainerElement.className;

                    // Get tab page element
                    var objTabPageElement = Web_GetElementById("VWG_" + strTabPageDataId, objWindow);

                    // if we have valid tab page
                    if (objTabPageElement)
                    {
                        // Add tab page to drop down element
                        objDropDownElement.appendChild(objTabPageElement);
                    }

                    // Create an id to drop down popup.
                    var strDropDownID = strTabControlDataId + "_DD";

                    // Try getting drop down form node.
                    var objFormNode = Xml_SelectSingleNode("WG:Tags.Form[@Attr.Type='PopupWindow' and @Attr.Id='" + strDropDownID + "']", objTabControlNode);

                    // Check if form node does not exist.
                    if (!objFormNode)
                    {
                        // Create a new form node.
                        objFormNode = Xml_CreateNode(mobjDataDomObject, 1, "WG:Tags.Form", "http://www.gizmox.com/webgui");

                        // Set new form as poopup window.
                        Xml_SetAttribute(objFormNode, "Attr.Type", "PopupWindow");

                        // Set form's id.
                        Xml_SetAttribute(objFormNode, "Attr.Id", strDropDownID);

                        // Add form node to tool strip node.
                        objTabControlNode.appendChild(objFormNode);
                    }

                    // Get tab layout
                    var intTabLayout = parseInt(Xml_GetAttribute(objTabControlNode, "Attr.TabLayout", "0"));

                    // Get restored height
                    var intRestoredHeight = parseInt(Xml_GetAttribute(objTabControlNode, "Attr.RestoredHeight", "0"));

                    var intPopupHeight = intRestoredHeight - TabControl_GetTabHeaderHeight(objWindow, strTabControlDataId, objTabControlNode);
                    var intPopupWidth = 0;
                    var intPopupLeft = 0;
                    var intPopupTop = 0;

                    var objTabControlElement = Web_GetElementByDataId(strTabControlDataId, objWindow);
                    if (objTabControlElement)
                    {
                        intPopupWidth = objTabControlElement.clientWidth;

                        var strAlignedPosition = "B";

                        // Set align to above
                        if (intTabLayout == 1)
                        {
                            strAlignedPosition = "A";
                        }

                        // Get popup rect
                        var objRect = Popups_GetAlignedRectangleByElement(objTabControlElement, strAlignedPosition, intPopupWidth, intPopupHeight);
                        if (objRect)
                        {
							// Update popup position.
                            intPopupLeft = objRect.X;
                            intPopupTop = objRect.Y;

							// Update popup size.
                            intPopupWidth = objRect.Width;
                            intPopupHeight = objRect.Height;
                        }
                    }

                    // Set form's size.
                    Xml_SetAttribute(objFormNode, "Attr.Width", intPopupWidth);
                    Xml_SetAttribute(objFormNode, "Attr.Height", intPopupHeight);

                    // Define an empty owner popup id.
                    var strOwnerPopupId = null;

                    // Get current tabcontrol's form node.
                    var objOwnerFormNode = Data_GetFormNodeByDataId(strTabControlDataId);
                    if (objOwnerFormNode)
                    {
                        // Check if toolstrip's form is a popup window.
                        if (Xml_IsAttribute(objOwnerFormNode, "Attr.Type", "PopupWindow"))
                        {
                            // Get owner form id.
                            strOwnerPopupId = Xml_GetAttribute(objOwnerFormNode, "Attr.Id", "");
                        }
                    }

                    // Create popup
                    var objPopupElement = Popups_CreatePopup(null, strTabControlDataId, strOwnerPopupId, intPopupLeft, intPopupTop, intPopupWidth, intPopupHeight, objFormNode, false, false, false, TabControl_OnDropDownClosed);

                    if (objPopupElement)
                    {
                        var objPopupFormelement = Web_GetElementById("VWG_" + strDropDownID, objWindow);

                        if (objPopupFormelement)
                        {
                            // Clear popup frame element childs
                            $(objPopupFormelement).empty();

                            // Add tab pages to center frame of the popup
                            $(objPopupFormelement).append(objDropDownElement);
                        }

                        // Update tabcontrols headers
                        TabControl_InitializeTabs(objTabControlNode, true);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="TabControl_OnDropDownClosed">
/// <summary>
/// 
/// </summary>
function TabControl_OnDropDownClosed()
{
    // Try getting control id from popup element.
    var strDropDownID = Web_GetAttribute(this, "vwg_ControlId", true);
    if (!Aux_IsNullOrEmpty(strDropDownID))
    {
        // Remove the "_DD" suffix.
        strControlID = strDropDownID.replace("_DD", "");

        // Get window as for control id.
        var objWindow = Forms_GetWindowByDataId(strControlID);
        if (objWindow)
        {
            // Get tab control tab container element.
            var objTabControlTabsContainerElement = Web_GetElementById("VWGTCTC_" + strControlID, objWindow);
            if (objTabControlTabsContainerElement)
            {
                // Get drop down element.
                var objDropDownElement = Web_GetElementById("VWGTCDD_" + strControlID, objWindow);
                if (objDropDownElement)
                {
                    // Get tab control node.
                    var objTabControlNode = Data_GetNode(strControlID);
                    if (objTabControlNode)
                    {
                        if (objDropDownElement.childNodes.length > 0)
                        {
                            var objTabPageElement = objDropDownElement.childNodes[0];

                            if (objTabPageElement)
                            {
                                // Append current tab page element to tab control element.
								$(objTabControlTabsContainerElement).append(objTabPageElement);
                            }
                        }

                        // Update tabcontrols headers
                        TabControl_InitializeTabs(objTabControlNode, false);
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="TabControl_GetTabHeaderHeight">
/// <summary>
/// get tab control header height.
/// </summary>
function TabControl_GetTabHeaderHeight(objWindow, strTabControlDataId, objTabControlNode)
{
    if (objTabControlNode)
    {
        // Get tab control main table
        var objTabControlMainDivElement = Web_GetElementById("VWGTCMD_" + strTabControlDataId, objWindow);

        // Check valid tab control main table
        if (objTabControlMainDivElement)
        {
            // Check if tabcontrol have groups and return height according to result
            var intGroupCount = Xml_SelectNodes("Tags.Group", objTabControlNode).length;
            if (intGroupCount > 0)
            {
                return Number(Web_GetAttribute(objTabControlMainDivElement, "vwggroupedtabheight", true));
            }
            else
            {
                return Number(Web_GetAttribute(objTabControlMainDivElement, "vwgtabheight", true));
            }
        }
    }

    return 0;

}
/// </method>

/// <method name="TabControl_MoreTab">
/// <summary>
/// Showing the "more" tab special view.
/// </summary>
function TabControl_MoreTab(strGuid, objWindow) 
{
	// Get the tab control node (containing all the objects)
	var objNode = Data_GetNode(strGuid);
	if (objNode) 
    {
		// Check if not already in More mode
        if (!Xml_IsAttribute(objNode, "Attr.Mode", "M")) 
        {
			// Change mode to More
			Xml_SetAttribute(objNode, "Attr.Mode", "M");

			// Redraw control
			if (Xml_IsEmptyAttribute(objNode, "Attr.ClientUpdateHandler")) 
            {
				Controls_RedrawControlByNode(objWindow, objNode);
			}
			else 
            {
				Controls_ExeceuteClientUpdateHandler(objNode);
			}
		}
	}
}
/// </method>

/// <method name="TabControl_ClearMode">
/// <summary>
/// 
/// </summary>
function TabControl_ClearMode(strTabControlId) 
{
	// Get the tab control node
	var objNode = Data_GetNode(strTabControlId);
	if (objNode) 
    {
		// Check if in More mode
        if (Xml_IsAttribute(objNode, "Attr.Mode", "M")) 
        {
			// Clear More mode value
			Xml_SetAttribute(objNode, "Attr.Mode", "");

			// Clear Selected id
			Xml_SetAttribute(objNode, "Attr.Selected", "");
		}
	}
}
/// </method>

/// <method name="TabControl_HandleMouseEvents">
/// <summary>
/// Handle tab control mouse events.
/// </summary>
function TabControl_HandleMouseEvents(objElement, strType, objWindow, objEvent)
{
    // Set the tab page visual style
    Web_SetStyle(objElement, strType, objWindow, objEvent);

    if (strType == "mousedown")
    {
        // Get tab control element
        var objTabControlElement = Web_GetVwgElement(objElement);

        if (objTabControlElement)
        {
            // Set tab page mouse down flag
            objTabControlElement.SuspendCollapsedTCTabsInit = true;
        }
    }
}
/// </method>