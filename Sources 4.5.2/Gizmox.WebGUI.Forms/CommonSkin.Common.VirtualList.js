/// <summary>
/// Virtual list asynchronic navigation memory
/// </summary>
var mobjVirtualListScroller = null;

/// <summary>
/// Virtual list asynchronic navigation timer
/// </summary>
var mintVirtualListTimer = 0;

/// <summary>
/// Creating Binding flag, prevents duplication in Navigate calls
/// </summary>
var mblnCreatingBinding = false;

var mcntVLRecordCount = 0;
var mcntVLMoveNext = 1;
var mcntVLValue = 2;
var mcntVLSetPosition       = 3;

/// <method name="VirtualList_CreateBinding">
/// <summary>
/// Creates list binding using a virtual list
/// </summary>
/// <param name="objVLTemplate">The virtual list template.</param>
/// <param name="objVLScroller">The virtual list scroller.</param>
/// <param name="objVLDataSource">The item node list.</param>
/// <param name="blnVLHasHeadlines">The template has headlines.</param>
function VirtualList_CreateBinding(objVLWindow, objVLTemplate, objVLScroller, objVLDataSource, intStartingIndex, blnVLHasHeadlines, intFactor, fncDataSourceAdapter, intItemHeight)
{
    // Set creating-binding flag on
    mblnCreatingBinding = true;

    // Create a new virtual list info object
    var objVLInfo = {};

    // Set the currne data source provider
    objVLInfo.mfncDataSourceAdapter = fncDataSourceAdapter;

    // Sets the current virtual list data source
    objVLInfo.mobjVLDataSource = objVLDataSource;

    // Set the start from index
    objVLInfo.mintStartFromIndex = intStartingIndex;

    // Set the selected index
    objVLInfo.mintCurrentSelectedIndex = intStartingIndex;

    // Get value/text nodes
    objVLInfo.marrMappings = VirtualList_GetMappings(objVLWindow, objVLTemplate, blnVLHasHeadlines);

    // Get buffer size
    if (objVLInfo.marrMappings.length > 0)
    {
        objVLInfo.mintBufferSize = objVLInfo.marrMappings[0].nodes.length;
    }

    // Get the current record count
    objVLInfo.mintListSize = fncDataSourceAdapter(objVLDataSource, mcntVLRecordCount);

    // Get template nodes
    objVLInfo.marrSelectionNodes = VirtualList_GetTemplateNodes(objVLWindow, objVLTemplate, Web_GetAttribute(objVLTemplate, "vwgvirtuallistelements").split("/"), blnVLHasHeadlines);

    // Calculate smoozing scrolling factor
    objVLInfo.mintFactor = Math.ceil(!Aux_IsNullOrEmpty(intItemHeight) ? intItemHeight : objVLScroller.clientHeight / objVLInfo.mintBufferSize);

    // Set virtual list info object
    if (objVLScroller)
    {
        objVLScroller.mobjVLInfo = objVLInfo;
    }

    // Set creating-binding flag off
    mblnCreatingBinding = false;

    // Return the binding information
    return objVLInfo;
}
/// </method>

/// <method name="VirtualList_AdjustScroller">
/// <summary>
/// Adjusts the virtual list scroller
/// </summary>
/// <param name="objVLScroller">The virtual list scroller.</param>
/// <param name="intStartingIndex">The starting index.</param>
function VirtualList_AdjustScroller(objVLScroller, intStartingIndex, objWindow)
{
    if (objVLScroller && objVLScroller.firstChild)
    {
        // Set current virtual list context
        with (objVLScroller.mobjVLInfo)
        {
            if (mintListSize > mintBufferSize)
            {
                objVLScroller.firstChild.style.height = ((mintListSize * mintFactor) + 1) + "px";
            }
            else
            {
                objVLScroller.firstChild.style.height = (objVLScroller.clientHeight) + "px";
            }

            if (!Web_SupportsMISCBrowserCapability(512))
            {
                objVLScroller.touchScroller = new IScroll(objVLScroller, Common_GetDefaultIScrollParameters());

                objVLScroller.touchScroller.on('scroll', function (e)
                {
                    $(objVLScroller).scroll();
                });

                // Let external components listen to the scroller's tap/click event
                $(objVLScroller.touchScroller.scroller).on('tap click', function (e)
                {
                    $(objVLScroller).trigger("touchScrollerClick", [objVLScroller.touchScroller.pointY, mintFactor, e]);
                });

                Web_SetTimeout(function ()
                {
                    // We need to wait until the UI is ready and refresh the scroller to take the real size
                    objVLScroller.touchScroller.refresh();

                    // Set the scroller initial position after refreshing
                    VirtualList_SetScroller(objVLScroller, intStartingIndex);
                }, 500, objWindow);
            }
            else
            {
                VirtualList_SetScroller(objVLScroller, intStartingIndex);
            }
        }
    }
}
/// </method>

/// <method name="VirtualList_SetScroller">
/// <summary>
/// Set the VL scroller position
/// </summary>
/// <param name="objVLScroller">The virtual list scroller.</param>
/// <param name="intStartingIndex">The starting index.</param>
function VirtualList_SetScroller(objVLScroller,intStartingIndex)
{
    // Set current virtual list context
	with(objVLScroller.mobjVLInfo)
	{
	    // Ensure positive starting index.
	    intStartingIndex = (intStartingIndex < 0 ? 0 : intStartingIndex);
	    var intScrollTop = intStartingIndex * mintFactor

	    VirtualList_SetScrollTop(objVLScroller,intScrollTop);
    }
}
/// </method>

/// <method name="VirtualList_UpdateScroller">
/// <summary>
/// Updates the VL scroller position
/// </summary>
/// <param name="objVLScroller">The virtual list scroller.</param>
/// <param name="intOffsetIndex">The offset index.</param>
function VirtualList_UpdateScroller(objVLScroller, intOffsetIndex)
{
    // Set current virtual list context
    with (objVLScroller.mobjVLInfo)
    {
        // Preseve current scrolling position.
        var intScrollTop = VirtualList_GetScrollTop(objVLScroller);
        var intNewPosition = intScrollTop + (intOffsetIndex * mintFactor);

        VirtualList_SetScrollTop(objVLScroller, intNewPosition);
    }
}
/// </method>


/// <method name="VirtualList_GetMappings">
/// <summary>
/// Adjusts the virtual list scroller
/// </summary>
/// <param name="objVLTemplate">The virtual list template.</param>
function VirtualList_GetMappings(objVLWindow, objVLTemplate, blnVLHasHeadlines)
{
    // Get virtual list definitions
    var arrMappingDefinitions = Web_GetAttribute(objVLTemplate, "vwgvirtuallist").split(",");

    // Create mapping array
    var arrMapping = [];

    // Loop and create mapping
    for (var intIndex = 0; intIndex < arrMappingDefinitions.length; intIndex++)
    {
        // Get current mapping
        var strMappingDefinition = Aux_Trim(arrMappingDefinitions[intIndex]);

        // If is a valid mapping
        if (strMappingDefinition != "")
        {
            // Get mapping parts
            var arrMappingDefinition = strMappingDefinition.split(":");

            // Push new mapping
            arrMapping.push({
                type: arrMappingDefinition[0],
                xpath: arrMappingDefinition[1],
                nodes: VirtualList_GetTemplateNodes(objVLWindow, objVLTemplate, arrMappingDefinition[2].split("/"), blnVLHasHeadlines)
            });
        }
    }

    // Return mappings
    return arrMapping;
}
/// </method>

/// <method name="VirtualList_Navigate">
/// <summary>
/// Navigate based on the virtual list scroller
/// </summary>
/// <param name="objVLScroller">The virtual list scroller.</param>
/// <param name="blnInitialize">Do a synchronic navigation.</param>
function VirtualList_Navigate(objVLScroller, intDelay)
{
    // Exit in case of synchronous call and creating-binding flag is on
    if (intDelay && mblnCreatingBinding)
    {
        return;
    }

    // Store previous scroller
    mobjVirtualListScroller = objVLScroller;

    // Clear previous navigation
    Web_ClearTimeout(mintVirtualListTimer);

    // If delay is defined
    if (intDelay)
    {
        // Set the current timeout
        mintVirtualListTimer = Web_SetTimeout("mobjApp.VirtualList_DoNavigate()", intDelay);
    }
    else
    {
        VirtualList_DoNavigate();
    }
}
/// </method>

/// <method name="VirtualList_GetScrollTop">
/// <summary>
/// 
/// </summary>
function VirtualList_GetScrollTop(objVLScroller)
{
    return objVLScroller.touchScroller ? (0 - objVLScroller.touchScroller.y) : objVLScroller.scrollTop;
}
/// </method>

/// <method name="VirtualList_CreateTouchBindings">
/// <summary>
/// 
/// </summary>
function VirtualList_CreateTouchBindings(objVLScroller, fncTouchHandler, objWindow)
{
    // Register the custom event that is fired on the VirtualList-iScroll element when clicking on it
    objWindow.$(objVLScroller).on("touchScrollerClick", fncTouchHandler);
}
/// </method>


/// <method name="VirtualList_SetScrollTop">
/// <summary>
/// 
/// </summary>
function VirtualList_SetScrollTop(objVLScroller,intScrollTop)
{
	if (objVLScroller.touchScroller)
	{
	    objVLScroller.touchScroller.scrollTo(0, -intScrollTop);
	    $(objVLScroller).scroll();
    }
	else
	{
	    // Calculate new scroller position
	    objVLScroller.scrollTop = intScrollTop;
	}
}
/// </method>

/// <method name="VirtualList_Navigate">
/// <summary>
/// Navigate based on the virtual list scroller
/// </summary>
function VirtualList_DoNavigate(objVLScroller)
{
    // Get scroller local copy 
    if (objVLScroller == null || objVLScroller == undefined)
    {
        objVLScroller = mobjVirtualListScroller;
    }

    if (objVLScroller && objVLScroller.mobjVLInfo)
    {
        // Set current virtual list context
        with (objVLScroller.mobjVLInfo)
        {
            // Get current scrolling position
            var intFrom = Math.floor(VirtualList_GetScrollTop(objVLScroller) / mintFactor);

            // Check maximum starting item index
            if (intFrom + mintBufferSize > mintListSize) intFrom = mintListSize - mintBufferSize;

            // Check minimum starting item index
            if (intFrom < 0) intFrom = 0;

            // Set current from index
            mintStartFromIndex = intFrom;

            // Set the new selection
            VirtualList_UpdateSelection(objVLScroller);

            // Redraw the list acording to the new parameters
            VirtualList_DrawList(objVLScroller);
        }
    }

}
/// </method>

/// <method name="VirtualList_GetSelection">
/// <summary>
/// Get the current selection
/// </summary>
function VirtualList_GetSelection(objVLScroller)
{
    if (objVLScroller && objVLScroller.mobjVLInfo)
    {
        // Set current virtual list context
        with (objVLScroller.mobjVLInfo)
        {
            return mintCurrentSelectedIndex;
        }
    }
    return 0;
}
/// </method>

/// <method name="VirtualList_SetSelection">
/// <summary>
/// The the current selected item and scroll into view if needed
/// </summary>
function VirtualList_SetSelection(objVLScroller, intNewSelectedIndex, blnScrollIntoView, objWindow)
{
    // If there is a valid virtual scroller
    if (objVLScroller && objVLScroller.mobjVLInfo)
    {
        // Selection changed flag
        var blnSelectionChanged = false;

        // Scroll had changed
        var blnScrollChanged = false;

        // Set current virtual list context
        with (objVLScroller.mobjVLInfo)
        {
            // Set the current selected index
            if (mintCurrentSelectedIndex != intNewSelectedIndex)
            {
                // Set the new selected index
                mintCurrentSelectedIndex = intNewSelectedIndex;

                // Indicate selection had changed
                blnSelectionChanged = true;
            }

            // if should scroll into view
            if (blnScrollIntoView)
            {
                // Get the current start from index
                var intNewStartFromIndex = mintStartFromIndex;

                // If start from is before current scroll range
                if (mintStartFromIndex > mintCurrentSelectedIndex)
                {
                    intNewStartFromIndex = mintCurrentSelectedIndex;
                }
                    // If start from is after current scroll range
                else if (mintStartFromIndex + mintBufferSize <= mintCurrentSelectedIndex)
                {
                    intNewStartFromIndex = mintCurrentSelectedIndex - mintBufferSize + 1;
                }

                // Make sure new start index is in range
                if (intNewStartFromIndex < 0)
                {
                    intNewStartFromIndex = 0;
                }
                else if (intNewStartFromIndex >= mintListSize)
                {
                    intNewStartFromIndex = mintListSize - 1;
                }

                // If start from index had changed
                if (mintStartFromIndex != intNewStartFromIndex)
                {
                    // Indicate scroll changed
                    blnScrollChanged = true;

                    // Set the new scrolling position
                    VirtualList_AdjustScroller(objVLScroller, intNewStartFromIndex, objWindow);
                }
            }
        }

        // If the selection had changed
        if (blnSelectionChanged && !blnScrollChanged)
        {
            // Update the current selection
            VirtualList_UpdateSelection(objVLScroller);
        }
    }
}
/// </method>

/// <method name="VirtualList_UpdateSelection">
/// <summary>
/// 
/// </summary>
function VirtualList_UpdateSelection(objVLScroller)
{
    if (objVLScroller && objVLScroller.mobjVLInfo)
    {
        // Set current virtual list context
        with (objVLScroller.mobjVLInfo)
        {
            // Get current selected index in the bufgger
            var intCurrentSelectionIndex = mintCurrentSelectedIndex - mintStartFromIndex;

            // Loop all template items and update selection
            for (var intIndex = 0; intIndex < mintBufferSize; intIndex++)
            {
                // If item is selected
                if (intIndex == intCurrentSelectionIndex)
                {
                    // Set selection
                    Web_SetStyle(marrSelectionNodes[intIndex], "selected");
                }
                else
                {
                    // Remove selected
                    Web_SetStyle(marrSelectionNodes[intIndex], "clear");
                }
            }
        }
    }
}
/// </method>


/// <method name="VirtualList_DrawList">
/// <summary>
/// Draws the virtual list according to the binding information
/// </summary>
/// <param name="objVLScroller">The virtual list scroller.</param>
function VirtualList_DrawList(objVLScroller)
{
    // Set current virtual list context
    with (objVLScroller.mobjVLInfo)
    {
        if (mintListSize > 0)
        {
            // Get the first node
            var objDataSource = mfncDataSourceAdapter(mobjVLDataSource, mcntVLSetPosition, mintStartFromIndex);

            // Loop buffer indexes
            for (var intIndex = 0; intIndex < mintBufferSize; intIndex++)
            {
                // Get actual item index
                var intItemIndex = intIndex + mintStartFromIndex;

                // Check valid indexes
                if (intItemIndex <= mintListSize)
                {
                    // Loop all mappings
                    for (var intMappingIndex = 0; intMappingIndex < marrMappings.length; intMappingIndex++)
                    {
                        // Get current mapping
                        var objMapping = marrMappings[intMappingIndex];

                        // Get current value node
                        var strValue = mfncDataSourceAdapter(objDataSource, mcntVLValue, objMapping.xpath);
                        if (strValue != null || objMapping.type == "S")
                        {
                            // Check mapping type
                            switch (objMapping.type)
                            {
                                case "T": // Text mapping type
                                    Web_SetInnerText(objMapping.nodes[intIndex], strValue, 1);
                                    break;
                                case "H": // HTML mapping type						            
                                    Web_SetInnerHtml(objMapping.nodes[intIndex], strValue);
                                    break;
                                case "A": // Attribute mapping type
                                    objMapping.nodes[intIndex].value = strValue;
                                    break;
                                case "S": // Set the current style
                                    if (objMapping.nodes[intIndex].cssText != strValue)
                                    {
                                        objMapping.nodes[intIndex].cssText = strValue;
                                    }
                                    break;
                            }
                        }
                    }

                    // Move to the next record
                    objDataSource = mfncDataSourceAdapter(objDataSource, mcntVLMoveNext);

                    // If there are no more items
                    if (!objDataSource) break;
                }
            }
        }
    }
}
/// </method>

/// <method name="VirtualList_GetTemplateNodes">
/// <summary>
/// Gets HTML nodes from the template based on the "0/*/0.." format
/// </summary>
/// <param name="objVLTemplate">The virtual list template.</param>
/// <param name="arrXPath">The array of xpath parts.</param>
function VirtualList_GetTemplateNodes(objVLWindow, objVLTemplate, arrXPath, blnVLHasHeadlines)
{
    // Collect template nodes
    return VirtualList_CollectTemplateNodes(objVLWindow, objVLTemplate, arrXPath, 0, [], blnVLHasHeadlines);
}
/// </method>

/// <method name="VirtualList_CollectTemplateNodes">
/// <summary>
/// Collect template nodes from the virtual list template
/// </summary>
/// <param name="objNode">The current node that is being analyzed.</param>
/// <param name="arrXPath">An array of xpath parts</param>
/// <param name="intIndex">The current working index with in the xpath path.</param>
/// <param name="arrNodes">The collected nodes.</param>
function VirtualList_CollectTemplateNodes(objVLWindow, objNode, arrXPath, intIndex, arrNodes, blnVLHasHeadlines)
{
    // Get current template xpath part
    var strXPath = arrXPath[intIndex];

    // If is a valid node
    if (objNode != null)
    {
        // If at end of xpath add node
        if (intIndex == arrXPath.length)
        {
            arrNodes.push(objNode);
        }
        else
        {
            // If is not a number
            if (isNaN(strXPath))
            {
                // If is look on child nodes
                if (strXPath == "*")
                {
                    // Loop all nodes
                    for (var intSubIndex = 0; intSubIndex < objNode.childNodes.length; intSubIndex++)
                    {
                        // If is headline
                        if ((blnVLHasHeadlines && intSubIndex != 0) || !blnVLHasHeadlines)
                        {

                            // Collect template nodes with in nodes
                            VirtualList_CollectTemplateNodes(objVLWindow, objNode.childNodes[intSubIndex], arrXPath, intIndex + 1, arrNodes, blnVLHasHeadlines);
                        }
                    }
                }
                    // If is attribute node
                else if (strXPath == "style")
                {
                    arrNodes.push(objNode.style);
                }
                    // If is attribute node
                else if (strXPath.charAt(0) == "#")
                {
                    // Get tag name
                    var strTagName = strXPath.substr(1);

                    // Loop all nodes
                    for (var intSubIndex = 0; intSubIndex < objNode.childNodes.length; intSubIndex++)
                    {
                        var objSubNode = objNode.childNodes[intSubIndex];
                        // If is headline
                        if (objSubNode.nodeType == 1 && objSubNode.nodeName.toLowerCase() == strTagName)
                        {

                            // Collect template nodes with in nodes
                            VirtualList_CollectTemplateNodes(objVLWindow, objSubNode, arrXPath, intIndex + 1, arrNodes, blnVLHasHeadlines);
                        }
                    }
                }
                    // If is attribute node
                else if (strXPath.charAt(0) == "@")
                {
                    // Get attribute name
                    var strAttrName = strXPath.substr(1);

                    // Get attribute node
                    var objAttrNode = objNode.attributes.getNamedItem(strAttrName);

                    // If not found attribute node create one
                    if (objAttrNode == null)
                    {
                        // Create attribute node
                        objAttrNode = objVLWindow.document.createAttribute(strAttrName);
                        objAttrNode.value = "";
                        objNode.attributes.setNamedItem(objAttrNode);
                    }

                    // Add to node array
                    arrNodes.push(objAttrNode);
                }
            }
            else
            {
                // Get node at related index
                VirtualList_CollectTemplateNodes(objVLWindow, objNode.childNodes[parseInt(strXPath)], arrXPath, intIndex + 1, arrNodes, blnVLHasHeadlines);
            }
        }
    }

    // Return collected nodes
    return arrNodes;
}
/// </method>



/// <method name="VirtualList_NavigateToPosition">
/// <summary>
/// Move the scroller to the selected item position
/// </summary>
/// <param name="objVLScroller">The list scroller</param>
/// <param name="intPosition">The selected item position</param>
function VirtualList_NavigateToPosition(objVLScroller, intPosition, objWindow)
{
    if (objVLScroller)
    {
        // Initialize scroller state
        VirtualList_AdjustScroller(objVLScroller, intPosition, objWindow);

        // Initial navigation
        VirtualList_Navigate(objVLScroller);
    }
}
/// </method>