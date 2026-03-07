var mobjXMLDocument = null;

/// <method name="Xml_LoadDocument">
/// <summary>
/// Loads an xml document async and return callback
/// </summary>
/// <param name="strUrl">The URL of the xml to be retrieved.</param>
/// <param name="fncCallback">The callback function to be called after xml is loaded.</param>
/// <param name="blnXmlHttp">Force xml http usage.</param>
function Xml_LoadDocument(strUrl,fncCallback,blnXmlHttp,strXmlHttpBody,blnIsFormBody)
{
    // IE does not load static resources with XMLHttp (dwgx and swgx are replaced in runtime)
    if(mcntIsIE && (".dwgx"!=".swgx" && !blnXmlHttp))
    {
       Xml_LoadXmlDom(strUrl,fncCallback);
       return;
    }
   
    var objXHR = $.ajax({
        url: strUrl,
        async: true,
        type: strXmlHttpBody?"POST":"GET",
        data: strXmlHttpBody,
        xhrFields: { responseType: (mcntIsIE?"msxml-document":"document") },
        dataType: "xml"
    });

    if(blnIsFormBody)
	{
	    objXHR.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    }
    
    objXHR.done(function (msg) {
        // get response xml body
		var objXmldoc = objXHR.responseXML;

		// get error object
		var objError = objXHR.parseError;
    			
		// get the error code
		var intErrot = objError?objError.errorCode:0;
    			
		// check node error
		if (intErrot == 0)
		{
			// response object 
			var objResponse = null;
    				
			// if response ok
			if(objResponse = objXmldoc.documentElement)
			{
				// Return a xmldocument to the caller
			    if (fncCallback) {
			        fncCallback(objXmldoc);
			    }
			}
			else
			{
				// Open error window and display content
				open().document.write(String(objXHR.responseText).replace("ASP.NET","WebGui"));
			}
		}
    });
}
/// </method>

/// <method name="Xml_DataSourceAdapter">
/// <summary>
/// Provides an abstracted data source usage
/// </summary>
/// <param name="objDataSource">The xml node list or node.</param>
/// <param name="intAction">The action id to perform.</param>
/// <param name="objActionInfo">The action information to complete the action.</param>
function Xml_DataSourceAdapter(objDataSource, intAction, objActionInfo)
{
    switch(intAction)
    {
        case mcntVLRecordCount: return objDataSource.length;
        case mcntVLSetPosition: return objDataSource[objActionInfo];
        case mcntVLMoveNext:    return objDataSource.nextSibling;
        case mcntVLValue:
            var objNodeValue = Xml_SelectSingleNode(objActionInfo,objDataSource);
            return objNodeValue?objNodeValue.value:"";
            break;
    }   
}
/// </method>

/// <method name="Xml_HasAttribute">
/// <summary>
/// Checks if attribute exists and has value.
/// </summary>
/// <param name="objNode">The node to check its attribute.</param>
/// <param name="strAttribute">The attribute name.</param>
function Xml_HasAttribute(objNode,strAttribute)
{
    return !Aux_IsNullOrEmpty(objNode.getAttribute(strAttribute));
}
/// </method>

/// <method name="Xml_IsAttribute">
/// <summary>
/// Checks if attribute equals a given value.
/// </summary>
/// <param name="objNode">The node to check its attribute.</param>
/// <param name="strAttribute">The attribute name.</param>
/// <param name="strValue">The attribute condition value.</param>
function Xml_IsAttribute(objNode,strAttribute,strValue)
{
    // Validate recieved arguments.
    if(objNode!=null && objNode!=undefined && !Aux_IsNullOrEmpty(strAttribute))
    {
        return objNode.getAttribute(strAttribute)==strValue;
    }
    
    return false;
}
/// </method>

/// <method name="Xml_IsNodeName">
/// <summary>
/// Checks the node name
/// </summary>
/// <param name="objNode">The node to check its attribute.</param>
/// <param name="strName">The node name.</param>
function Xml_IsNodeName(objNode, strName)
{
    return objNode.nodeName == strName;
}
/// </method>

/// <method name="Xml_GetAttribute">
/// <summary>
/// Gets an attribute value from a given node.
/// </summary>
/// <param name="objNode">The node to get is attribute.</param>
/// <param name="strAttribute">The attribute name.</param>
/// <param name="strDefault">The default value for missing attribute.</param>
function Xml_GetAttribute(objNode,strAttribute,strDefault,blnDecode)
{
    // Update the default parameter.
    if(strDefault ==  undefined)
    {
        strDefault = null;
    }
    
    if(objNode && objNode.attributes)
    {
        var objValue = objNode.getAttribute(strAttribute);
        
        if(!objValue || objValue=="")
        {
            return strDefault;
        }
        
        if(blnDecode)
	    {
	       objValue = Aux_DecodeText(objValue);	     
	    }
        return objValue;
    }
    else
    {
        return strDefault;
    }
}
/// </method>

/// <method name="Xml_SetAttribute">
/// <summary>
/// Sets an attribute value.
/// </summary>
/// <param name="objNode">The node to set is attribute.</param>
/// <param name="strAttribute">The attribute name.</param>
/// <param name="strValue">The attribute value.</param>
function Xml_SetAttribute(objNode,strAttribute,strValue)
{
    objNode.setAttribute(strAttribute,strValue);
}
/// </method>

/// <method name="Xml_RemoveAttribute">
/// <summary>
/// Removes an attribute.
/// </summary>
/// <param name="objNode">The node to set is attribute.</param>
/// <param name="strAttribute">The attribute name.</param>
function Xml_RemoveAttribute(objNode,strAttribute)
{
    objNode.removeAttribute(strAttribute);
}
/// </method>

/// <method name="Xml_RemoveChild">
/// <summary>
/// Removes a child node.
/// </summary>
/// <param name="objNode">The node to set is attribute.</param>
/// <param name="objChildNode">The removed child node.</param>
function Xml_RemoveChild(objNode,objChildNode)
{
    if(objNode && objChildNode)
    {
        // Validate that the child node is realy a child of this node
        if (objChildNode.parentNode == objNode)
        {
            objNode.removeChild(objChildNode);
        }
    }
}
/// </method>

/// <method name="Xml_GetPosition">
/// <summary>
/// Gets a given node position (The position relative to its siblings).
/// </summary>
/// <param name="objNode">The node to get its position.</param>
function Xml_GetPosition(objNode)
{
    if(objNode)
    {
        return Xml_SelectNodes("preceding-sibling::*",objNode).length;
    }
    
    return -1;
}
/// </method>

/// <method name="Xml_GetPositionByTagName">
/// <summary>
/// Gets a given node position (The position relative to its siblings) by its tag name.
/// </summary>
/// <param name="objNode">The node to get its position.</param>
function Xml_GetPositionByTagName(objNode)
{
    if(objNode)
    {
        return Xml_SelectNodes("preceding-sibling::" + objNode.tagName,objNode).length;
    }
    
    return -1;
}
/// </method>

/// <method name="Xml_GetChildByIndex">
/// <summary>
/// Gets a child node by index.
/// </summary>
/// <param name="objNode">The parent node to retrieve.</param>
/// <param name="intIndex">The index of the child.</param>
/// <param name="strTag">The required child tag.</param>
function Xml_GetChildByIndex(objNode,intIndex,strTag)
{
    if(objNode)
    {
        var objCurrentNode = objNode.childNodes[intIndex];
        if(strTag==null || (objCurrentNode!=null && objCurrentNode.nodeName == strTag))
        {
            return objCurrentNode;
        }
    }
}
/// </method>

/// <method name="Xml_HasNods">
/// <summary>
/// Checks if xpath returns nodes
/// </summary>
/// <param name="strXPath">The XPath to execute.</param>
/// <param name="objContext">The search node scope.</param>
/// <param name="objDocument">The containing document (Optional).</param>
function Xml_HasNods(strXPath,objContext,objDocument)
{
	var objNodes = Xml_SelectNodes(strXPath,objContext,objDocument);
	if(objNodes)
	{
		return objNodes.length>0;
	}
	else
	{
		return false;
	}
}
/// </method>

/// <method name="Xml_GetNamedAncestor">
/// <summary>
/// Gets an ancestor node with a given node name
/// </summary>
/// <param name="objNode">The node to get ancestor.</param>
/// <param name="strAncestorName">The ancestor name.</param>
/// <param name="blnEexcludSelf">Exclude self.</param>
function Xml_GetNamedAncestor(objNode,strAncestorName,blnEexcludSelf)
{
    // Validate recieved arguments.
    if(objNode && !Aux_IsNullOrEmpty(strAncestorName))
    {
        return Xml_SelectSingleNode("ancestor"+(blnEexcludSelf?"":"-or-self")+"::"+strAncestorName+"[1]",objNode);
    }
    
    return null;
}
/// </method>

/// <method name="Xml_IsEmptyAttribute">
/// <summary>
/// Checks whether the received attribute is empty or not.
/// </summary>
function Xml_IsEmptyAttribute(objNode,strAttributeName)
{
    var strAttributeValue = Xml_GetAttribute(objNode,strAttributeName,"");
    return (!strAttributeValue || strAttributeValue=="");
}
/// </method>

/// <method name="Xml_GetFirstChild">
/// <summary>
/// Gets the recieved element's first child node.
/// </summary>
function Xml_GetFirstChild(objNode)
{
    if(objNode)
    {
        return objNode.firstChild;
    }
    
    return null;
}
/// </method>
