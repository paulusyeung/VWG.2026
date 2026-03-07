var mobjSidesCounterparts = { 'right': 'left', 'left': 'right', 'top': 'bottom', 'bottom': 'top' };

/// <method name="Common_InitializeArrowScrollBars">
/// <summary>
///
/// </summary>
function Common_InitializeArrowScrollBars(strID, strScrollOrientation, strArrowsBaseClass, intTopThickness, intRightThickness, intBottomThickness, intLeftThickness, intHorizontalHoverSpeed, intHorizontalDownSpeed, intVerticalHoverSpeed, intVerticalDownSpeed, objWindow)
{
    // Get the scrollable element
    var objElement = Controls_GetScrollableElementByID(strID, objWindow);

    if(objElement)
    {
        // Listen to the resize event of the control and initialize it again if necessary
        objElement.setAttribute("onresize", "mobjApp.Common_UpdateArrowScrollBars('" + strID + "','" + strScrollOrientation + "','" + strArrowsBaseClass + "', 400, " + intTopThickness + ", " + intRightThickness + ", " + intBottomThickness + ", " + intLeftThickness + "," + intHorizontalHoverSpeed + "," + intHorizontalDownSpeed + "," + intVerticalHoverSpeed + "," + intVerticalDownSpeed + ", window)");

        // Call the update to with delay of 0 to initialize the arrows
        Common_UpdateArrowScrollBars(strID, strScrollOrientation, strArrowsBaseClass, 0 /* delay */, intTopThickness, intRightThickness, intBottomThickness, intLeftThickness, intHorizontalHoverSpeed, intHorizontalDownSpeed, intVerticalHoverSpeed, intVerticalDownSpeed, objWindow);
    }
}
/// </method>

/// <method name="Common_HandleArrowScroll">
/// <summary>
///
/// </summary>
function Common_HandleArrowScroll(objArrowElement, strType, objWindow, objEvent, objExtraParams)
{
    var jqArrowElement = objWindow.$(objArrowElement);

    // Disabled arrows do not need to do any logic
    if (!jqArrowElement.attr("arrowDisabled"))
    {
        // Make sure there are extra parameters
        objExtraParams = objExtraParams || {};

        // Get the arrow side 
        var strSide = jqArrowElement.attr("side");

        switch (strType)
        {
            case 'mouseenter':
                // Scroll slow
                Common_StartScroll(jqArrowElement, objWindow, strSide, objExtraParams.slow || 50);
                break;
            case 'mouseleave':
                // Stop scrolling
                Common_StopScroll(jqArrowElement, objWindow);
                break;
            case 'mousedown':
                // Stop scrolling
                Common_StopScroll(jqArrowElement, objWindow);

                // Scroll fast
                Common_StartScroll(jqArrowElement, objWindow, strSide, objExtraParams.fast || 20);
                break;
            case 'mouseup':
                // Stop scrolling
                Common_StopScroll(jqArrowElement, objWindow);
                // Scroll slow
                Common_StartScroll(jqArrowElement, objWindow, strSide, objExtraParams.slow || 50);
                break;
        }

        // Set the element's style
        Web_SetStyle(objArrowElement, strType, objWindow, objEvent);
    }
}
/// </method>

/// <method name="Common_GetScrollableElementFromArrowScrollerAsJquery">
/// <summary>
/// 
/// </summary>
function Common_GetScrollableElementFromArrowScrollerAsJquery(jqArrowElement)
{
    return jqArrowElement.siblings("[data-vwgscrollable='1']");
}
/// </method>

/// <method name="Common_StopScroll">
/// <summary>
/// 
/// </summary>
function Common_StopScroll(jqArrowElement, objWindow)
{
    if (jqArrowElement.length && jqArrowElement.attr("scrollingInterval"))
    {
        // Release the lock for the scrolling update
        Common_GetScrollableElementFromArrowScrollerAsJquery(jqArrowElement).attr("preventScrollerUpdate", "");

        // Clear previous scrolling interval.
        Web_ClearInterval(jqArrowElement.attr("scrollingInterval"), objWindow);
        
        jqArrowElement.attr("scrollingInterval", null);
    }
}
/// </method>

/// <method name="Common_StartScroll">
/// <summary>
/// 
/// </summary>
function Common_StartScroll(jqArrowElement, objWindow, strSide, intInterval)
{
    // Get the arrow on the other side
    var jqScrollablePanelCounterpart = jqArrowElement.siblings("[side='" + mobjSidesCounterparts[strSide] + "']");

    if (jqScrollablePanelCounterpart.attr("arrowDisabled"))
    {
        // Enable the counterpart arrow
        Common_EnableArrowScrollerElement(jqScrollablePanelCounterpart, objWindow);
    }

    // Call the scroll logic with an interval to get the continuous scroll feeling
    jqArrowElement.attr("scrollingInterval", Web_SetInterval(function ()
    {
        Common_StartScrollAsync(jqArrowElement, strSide, objWindow);
    }, intInterval, objWindow));
}
/// </method>

/// <method name="Common_DisableArrowScrollerElement">
/// <summary>
/// 
/// </summary>
function Common_DisableArrowScrollerElement(jqArrowScroller, jqScrollableElement, objWindow)
{
    // Clear the scroll intervar = stop scrolling
    if (jqArrowScroller.attr("scrollingInterval"))
    {
        objWindow.clearInterval(jqArrowScroller.attr("scrollingInterval"));
    }

    // Release the lock for the scrolling update
    jqScrollableElement.attr("preventScrollerUpdate", "");

    Web_SetStyle(jqArrowScroller[0], 'disable', objWindow);

    // Indicate that this arrow element has been disabled
    jqArrowScroller.attr("arrowDisabled", true);
}
/// </method>

/// <method name="Common_EnableArrowScrollerElement">
/// <summary>
/// 
/// </summary>
function Common_EnableArrowScrollerElement(jqScrollerElement, objWindow)
{
    Web_SetStyle(jqScrollerElement[0], 'clear', objWindow);
    jqScrollerElement.attr("arrowDisabled", null);
}
/// </method>

/// <method name="Common_StartScrollAsync">
/// <summary>
/// 
/// </summary>
function Common_StartScrollAsync(jqArrowElement, strSide, objWindow)
{
    var blnShouldDisable = false;
    var jqScrollableElement = Common_GetScrollableElementFromArrowScrollerAsJquery(jqArrowElement);

    // Set lock for the scrolling update
    jqScrollableElement.attr("preventScrollerUpdate", "1");

    // Do the actual scrolling according to the side
    switch (strSide)
    {
        case 'top':
            jqScrollableElement[0].scrollTop -= 10;
            blnShouldDisable = jqScrollableElement.scrollTop() == 0;
            break;
        case 'bottom':
            jqScrollableElement[0].scrollTop += 10;
            blnShouldDisable = jqScrollableElement.scrollTop() == jqScrollableElement.scrollHeight() - jqScrollableElement.clientHeight();
            break;
        case 'left':
            jqScrollableElement[0].scrollLeft -= 10;
            blnShouldDisable = jqScrollableElement.scrollLeft() == 0;
            break;
        case 'right':
            jqScrollableElement[0].scrollLeft += 10;
            blnShouldDisable = jqScrollableElement.scrollLeft() == jqScrollableElement.scrollWidth() - jqScrollableElement.clientWidth();
            break;
    }
    
    // If element has reach the end, disable it
    if (blnShouldDisable)
    {
        Common_DisableArrowScrollerElement(jqArrowElement, jqScrollableElement, objWindow);
    }
}
/// </method>

/// <method name="Common_DoUpdateArrowScrollers">
/// <summary>
/// 
/// </summary>
function Common_DoUpdateArrowScrollers(strID, jqScrollerElement, strThicknessDimention, strOrientation, strBackwardsSide, strForwardsSide, strBackwardThickness, strForwardThickness, strArrowsBaseClass, objLocationProperties, intHoverSpeed, intDownSpeed, objWindow)
{
    // Get the arrows elements with the specific orientation (as jQuery elements)
    var jqArrowScrollers = Common_GetArrowScrollers(strID, strOrientation, objWindow);

    var strMarginThicknessBackward = null,
        strMarginThicknessForward = null,
        strThicknessDimentionLower = strThicknessDimention.toLowerCase(),
        strBackwardsSideLower = strBackwardsSide.toLowerCase(),
        strForwardsSideLower = strForwardsSide.toLowerCase(),
        blnHasVisibleHorizontalScrollers = false;

    // Check for overflow
    if (jqScrollerElement["scroll" + strThicknessDimention]() > jqScrollerElement["client" + strThicknessDimention]())
    {
        blnHasVisibleHorizontalScrollers = true;

        // Set the margin for the scroller element so it will make room for the scrolling arrows
        strMarginThicknessBackward = strBackwardThickness + "px";
        strMarginThicknessForward = strForwardThickness + "px";

        var objBackwardArrow = null;
        var objForwardArrow = null;

        if (jqArrowScrollers.length) // The scrolling elements exist
        {
            // Make sure they are visible
            jqArrowScrollers.css("display", "");
            jqArrowScrollers.css(objLocationProperties);
        }
        else
        {
            // Create the backwards arrow       Set relevant attributes                                                                        Set location properties    Set specific relevant dimention thickness             Dock to relevant position         Set base class with relevant side
            objBackwardArrow = objWindow.$('<div style="position:absolute"></div>').attr({ "parentID": "" + strID, "orientation": strOrientation, "side": strBackwardsSideLower }).css(objLocationProperties).css(strThicknessDimentionLower, strBackwardThickness).css(strBackwardsSideLower, "0px").addClass(strArrowsBaseClass + "_" + strBackwardsSideLower);
            objForwardArrow = objWindow.$('<div style="position:absolute"></div>').attr({ "parentID": "" + strID, "orientation": strOrientation, "side": strForwardsSideLower }).css(objLocationProperties).css(strThicknessDimentionLower, strForwardThickness).css(strForwardsSideLower, "0px").addClass(strArrowsBaseClass + "_" + strForwardsSideLower);

            // Set scrolling speed
            var objSpeedAttributes = { 'slow': intHoverSpeed, 'fast': intDownSpeed };

            // Add event listeners for mouse events (hover, down, up, leave)
            Web_SetMouseEvents(objBackwardArrow[0], "Common_HandleArrowScroll", objWindow, objSpeedAttributes);
            Web_SetMouseEvents(objForwardArrow[0], "Common_HandleArrowScroll", objWindow, objSpeedAttributes);

            // Add the elements to the DOM
            jqScrollerElement.parent().append(objBackwardArrow).append(objForwardArrow);
        }
    }
    else
    {
        // If scrollers in the relevant dimention are visible
        if (jqArrowScrollers.is(":visible"))
        {
            // the scrollers are gone, so set margin to 0 
            strMarginThicknessBackward = strMarginThicknessForward = "0px";

            // Hide scrolling elements
            if (jqArrowScrollers)
            {
                jqArrowScrollers.css("display", "none");
            }
        }
    }

    // Set margin
    if (strMarginThicknessBackward && strMarginThicknessForward)
    {
        var objStyle = {};
        objStyle["margin-" + strBackwardsSideLower] = strMarginThicknessBackward;
        objStyle["margin-" + strForwardsSideLower] = strMarginThicknessForward;
        jqScrollerElement.css(objStyle);
    }

    return blnHasVisibleHorizontalScrollers;
}
/// </method>

/// <method name="Common_UpdateArrowScrollBars">
/// <summary>
/// This method occurs the first time, and everytime a resize occurs
/// </summary>
function Common_UpdateArrowScrollBars(strID, strScrollOrientation, strArrowsBaseClass, intDelay, intTopThickness, intRightThickness, intBottomThickness, intLeftThickness, intHorizontalHoverSpeed, intHorizontalDownSpeed, intVerticalHoverSpeed, intVerticalDownSpeed, objWindow)
{
    var jqScrollableElement = objWindow.$(Controls_GetScrollableElementByID(strID, objWindow));
    if (jqScrollableElement.length && strScrollOrientation)
    {
        if (jqScrollableElement.attr('timeOutArrowScroll'))
        {
            objWindow.clearTimeout(jqScrollableElement.attr('timeOutArrowScroll'));
        }

        if (!jqScrollableElement.attr("data-initialized"))
        {
            jqScrollableElement.attr("data-initialized", true);

            jqScrollableElement.scroll(function ()
            {
                // Check if the lock is set (means that the scrolling is coming from the UI)
                if (!jqScrollableElement.attr("preventScrollerUpdate"))
                {
                    Common_UpdateArrowScrollersForScrollPosition(jqScrollableElement, objWindow);
                }
            });

            // Set overflow to hidden so the native scrollbars will NOT be shown
            jqScrollableElement.css("overflow", "hidden");
        }

        var fncInitialization = function ()
        {
            // Reset timeout
            jqScrollableElement.attr('timeOutArrowScroll', null);

            var blnHasVisibleHorizontalScrollers = null;

            // Set horizontal scroll
            if (strScrollOrientation == "B" || strScrollOrientation == "H")
            {
                blnHasVisibleHorizontalScrollers = Common_DoUpdateArrowScrollers(strID, jqScrollableElement, "Width", "horizontal", "Left", "Right", intLeftThickness, intRightThickness, strArrowsBaseClass, { "top": "0px", "bottom": "0px" }, intHorizontalHoverSpeed, intHorizontalDownSpeed, objWindow);
            }

            // Set vertical scroll
            if (strScrollOrientation == "B" || strScrollOrientation == "V")
            {
                var strLeftVerticalMarginValue = "0px";
                var strRighVerticalMarginValue = "0px";

                // If there's already a vertical scroll then shring the horizontal scrolls (so they wont be on top of each other)
                if (blnHasVisibleHorizontalScrollers)
                {
                    strLeftVerticalMarginValue = intLeftThickness + "px";
                    strRighVerticalMarginValue = intRightThickness + "px";
                }

                Common_DoUpdateArrowScrollers(strID, jqScrollableElement, "Height", "vertical", "Top", "Bottom", intTopThickness, intBottomThickness, strArrowsBaseClass, { "left": strLeftVerticalMarginValue, "right": strRighVerticalMarginValue }, intVerticalHoverSpeed, intVerticalDownSpeed, objWindow);
            }

            Common_UpdateArrowScrollersForScrollPosition(jqScrollableElement, objWindow);
        };
        if (intDelay)
        {
            jqScrollableElement.attr('timeOutArrowScroll', Web_SetTimeout(fncInitialization,intDelay, objWindow));
        }
        else
        {
            fncInitialization();
        }
    }
}
/// </method>

/// <method name="Common_GetArrowScrollers">
/// <summary>
/// 
/// </summary>
function Common_GetArrowScrollers(strID, strOrientation, objWindow)
{
    if (strID)
    {
        return objWindow.$("[parentID='" + strID + "'][orientation" + (strOrientation ? "=" + strOrientation : "") + "]");
    }

    return null;
}
/// </method>

/// <method name="Common_UpdateArrowScrollersForScrollPosition">
/// <summary>
/// Enables or disables the arrows according to the current scrolling position
/// </summary>
function Common_UpdateArrowScrollersForScrollPosition(jqScrollerElement, objWindow)
{
    var jqParent = jqScrollerElement.parent();

    var jqScrollerTop = objWindow.$("[side=top]", jqParent);
    var jqScrollerRight = objWindow.$("[side=right]", jqParent);
    var jqScrollerBottom = objWindow.$("[side=bottom]", jqParent);
    var jqScrollerLeft = objWindow.$("[side=left]", jqParent);

    // Top
    if (jqScrollerTop.length)
    {
        if (jqScrollerElement.scrollTop() == 0)
        {
            Common_DisableArrowScrollerElement(jqScrollerTop, jqScrollerElement, objWindow);
        }
        else
        {
            Common_EnableArrowScrollerElement(jqScrollerTop, objWindow);
        }
    }

    // Left
    if (jqScrollerLeft.length)
    {
        if (jqScrollerElement.scrollLeft() == 0)
        {
            Common_DisableArrowScrollerElement(jqScrollerLeft, jqScrollerElement, objWindow);
        }
        else
        {
            Common_EnableArrowScrollerElement(jqScrollerLeft, objWindow);
        }
    }

    // Bottom
    if (jqScrollerBottom.length)
    {
        if (jqScrollerElement.scrollTop() == jqScrollerElement.scrollHeight() - jqScrollerElement.clientHeight())
        {
            Common_DisableArrowScrollerElement(jqScrollerBottom, jqScrollerElement, objWindow);
        }
        else
        {
            Common_EnableArrowScrollerElement(jqScrollerBottom, objWindow);
        }
    }

    // Right
    if (jqScrollerRight.length)
    {
        if (jqScrollerElement.scrollLeft() == jqScrollerElement.scrollWidth() - jqScrollerElement.clientWidth())
        {
            Common_DisableArrowScrollerElement(jqScrollerRight, jqScrollerElement, objWindow);
        }
        else
        {
            Common_EnableArrowScrollerElement(jqScrollerRight, objWindow);
        }
    }
}
/// </method>
