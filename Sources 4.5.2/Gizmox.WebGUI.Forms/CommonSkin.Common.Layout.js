

/// <method name="Layout_PerformLayoutAsynch">
/// <summary>
/// This method performs layout to an unknown element type.
/// </summary>
/// <param name="objElement">The element to perform layout on.</param>
/// <param name="intTimeOut">The required timeout.</param>
function Layout_PerformLayoutAsynch(objElement,intTimeOut)
{
    // Replace empty timeout in default 50 mili-seconds.
    if(intTimeOut==null)
    {
        intTimeOut = 50;
    }
    
    // Perform layout with timeout.	
    Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Layout_PerformLayout,objElement),intTimeOut);
}
/// </method>

/// <method name="Layout_ContainerResized">
/// <summary>
/// This method performs layout after a container had been resized
/// </summary>
/// <param name="objContainer">The container that has been resized.</param>
function Layout_ContainerResized(objContainer)
{
    Layout_PerformContainerLayout(objContainer);
}
/// </method>

function Layout_IsAnchoring(strAnchoring,strValue)
{
    return strAnchoring.indexOf(strValue)>-1;
}

function Layout_GetTopPadding(objContainer)
{
    return Layout_ParseInt(objContainer.style.paddingTop);
}

function Layout_GetBottomPadding(objContainer)
{
    return Layout_ParseInt(objContainer.style.paddingBottom);
}


function Layout_GetLeftPadding(objContainer)
{
    return Layout_ParseInt(objContainer.style.paddingLeft);
}


function Layout_GetRightPadding(objContainer)
{
    return Layout_ParseInt(objContainer.style.paddingRight);
}

function Layout_GetLeft(objControl)
{
    return Layout_ParseInt(Web_GetAttribute(objControl,"vwgleft"));
}

function Layout_GetRight(objControl)
{
    return Layout_ParseInt(Web_GetAttribute(objControl,"vwgright"));
}

function Layout_GetTop(objControl)
{
    return Layout_ParseInt(Web_GetAttribute(objControl,"vwgtop"));
}

function Layout_GetBottom(objControl)
{
    return Layout_ParseInt(Web_GetAttribute(objControl,"vwgbottom"));
}

function Layout_ParseInt(strNumber)
{
    var intNumber = parseInt(strNumber);
    if(isNaN(intNumber))
    {
        return 0;
    }
    return intNumber;
}

function Layout_GetVisiblity(objControl)
{
    return Web_GetAttribute(objControl,"vwgvisible")=="1";
}

function Layout_SetVisiblity(objControl,blnVisible)
{
    objControl.style.display = blnVisible ? "block" : "none";
}

function Layout_GetLayoutType(objElement)
{
    return Web_GetAttribute(objElement,"vwgtype");
}


function Layout_IsContainer(objElement)
{
    // Get element type.
    var strElementType = Web_GetAttribute(objElement,"vwgtype", true);
    
    // Check element type.
    return (strElementType=="container" || strElementType=="subcontainer");
}

function Layout_IsNode(objElement)
{
    return objElement.nodeType==1;
}

function Layout_GetWidth(objElement)
{
    return objElement.offsetWidth;
}

function Layout_GetHeight(objElement)
{
    return objElement.offsetHeight;
}

function Layout_SetWidth(objElement, intWidth)
{
    objElement.style.width = intWidth + "px";
}

function Layout_SetHeight(objElement, intHeight)
{
    objElement.style.height = intHeight + "px";
}

function Layout_SetLeft(objElement, intLeft)
{
    objElement.style.left = intLeft + "px";
}

function Layout_SetRight(objElement, intRight)
{
    objElement.style.right = intRight + "px";
}

function Layout_SetBottom(objElement, intWidth)
{
    objElement.style.bottom = intWidth + "px";
}

function Layout_SetTop(objElement, intTop)
{
    objElement.style.top = intTop + "px";
}

/// <method name="Layout_PerformContainerLayout">
/// <summary>
/// This method performs layout to a container.
/// </summary>
/// <param name="objContainer">The container to perform layout on.</param>
function Layout_PerformContainerLayout(objContainer)
{
    // Get children collection
    var objChildren = objContainer.childNodes;

    var intLeft = 0;
    var intTop = 0;
    var intRight = 0;
    var intBottom = 0;

    if (objContainer)
    {
        // Get the element
        var elContainerElement = Web_GetVwgElement(objContainer);

        // Get the parent node from the XML
        if (elContainerElement)
        {
            var objContainerNode = Data_GetNode(Data_GetDataId(elContainerElement.id));

            // Try to get the PaddingAll attribute
            var intPaddingAll = parseInt(Xml_GetAttribute(objContainerNode, "Attr.PaddingAll", null));

            // If PaddingAll was not defined
            if (isNaN(intPaddingAll))
            {
                // Get Defined padding 
                intTop = parseInt(Xml_GetAttribute(objContainerNode, "Attr.PaddingTop", 0));
                intTop = isNaN(intTop) ? 0 : intTop;
                intLeft = parseInt(Xml_GetAttribute(objContainerNode, "Attr.PaddingLeft", 0));
                intLeft = isNaN(intLeft) ? 0 : intLeft;
                intRight = parseInt(Xml_GetAttribute(objContainerNode, "Attr.PaddingRight", 0));
                intRight = isNaN(intRight) ? 0 : intRight;
                intBottom = parseInt(Xml_GetAttribute(objContainerNode, "Attr.PaddingBottom", 0));
                intBottom = isNaN(intBottom) ? 0 : intBottom;
            }
            else
            {
                // Set Padding all
                intLeft = intTop = intRight = intBottom = intPaddingAll;
            }
        }
    }

    // Loop all child nodes
    for (var intIndex = 0; intIndex < objChildren.length; intIndex++)
    {
        // Get current element.
        var objElement = objChildren[intIndex];

        // If node is element
        if (Layout_IsNode(objElement))
        {
            // Get element type.
            var strElementType = Web_GetAttribute(objElement, "vwgtype");

            // If is control
            if (strElementType == "control")
            {
                // Get the control docking
                var strDocking = Web_GetAttribute(objElement, "vwgdocking");
                if (!Aux_IsNullOrEmpty(strDocking))
                {
                    // If control should be visible
                    if (Layout_GetVisiblity(objElement))
                    {
                        // Select docking type
                        switch (strDocking)
                        {
                            case "L":
                                Layout_SetLeft(objElement, intLeft);
                                Layout_SetTop(objElement, intTop);
                                Layout_SetBottom(objElement, intBottom);
                                intLeft += Layout_GetWidth(objElement);
                                break;
                            case "R":
                                Layout_SetRight(objElement, intRight);
                                Layout_SetTop(objElement, intTop);
                                Layout_SetBottom(objElement, intBottom);
                                intRight += Layout_GetWidth(objElement);
                                break;
                            case "B":
                                Layout_SetBottom(objElement, intBottom);
                                Layout_SetLeft(objElement, intLeft);
                                Layout_SetRight(objElement, intRight);
                                intBottom += Layout_GetHeight(objElement);
                                break;
                            case "T":
                                Layout_SetTop(objElement, intTop);
                                Layout_SetLeft(objElement, intLeft);
                                Layout_SetRight(objElement, intRight);
                                intTop += Layout_GetHeight(objElement);
                                break;
                            case "F":
                                Layout_SetTop(objElement, intTop);
                                Layout_SetLeft(objElement, intLeft);
                                Layout_SetBottom(objElement, intBottom);
                                Layout_SetRight(objElement, intRight);
                                break;
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="Layout_PerformLayout">
/// <summary>
/// This method performs layout to an unknown element type.
/// </summary>
/// <param name="objElement">The element to perform layout on.</param>
function Layout_PerformLayout(objElement)
{
    // If is not container
    if(Layout_IsContainer(objElement))
    {
        // Perform layout container
        Layout_PerformContainerLayout(objElement);
    }
}
/// </method>