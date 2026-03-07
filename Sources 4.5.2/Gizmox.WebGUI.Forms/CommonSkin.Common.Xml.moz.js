/// <method name="Xml_CreateElementFromXml">
/// <summary>
/// Creates an xml element from a given xml string
/// </summary>
function Xml_CreateElementFromXml(strXml)
{
    var objDOMParser = new DOMParser();
    var objDOM = objDOMParser.parseFromString(strXml, "text/xml");
    return objDOM.documentElement;      
}
/// </method>

/// <method name="Xml_SetXmlDomProperties">
/// <summary>
/// Sets the dom element for XPath queries
/// </summary>
function Xml_SetXmlDomProperties(objXmlDom,intType)
{        

}
/// </method>

/// <method name="Xml_NSResolver" access="private">
/// <summary>
/// Used for mozilla name space resolving
/// </summary>
/// <param name="strPrefix">The prefix to get its URI.</param>
function Xml_NSResolver(strPrefix) 
{
    if(strPrefix == "WG") 
    {
        return 'http://www.gizmox.com/webgui';
    }
    else if(strPrefix == "WC") 
    {
        return 'wgcontrols';
    }
    
    return null;
}
/// </method>

/// <method name="Xml_GetOuterXML">
/// <summary>
/// Gets the xml string of the specified node
/// </summary>
/// <param name="objNode">The notde to get its outer xml.</param>
function Xml_GetOuterXML(objNode)
{
	// Serialize to xml string
	var objSerializer = new XMLSerializer();
	return objSerializer.serializeToString(objNode);
}
/// </method>

/// <method name="Xml_GetInnerText">
/// <summary>
/// Gets the text string of the specified node
/// </summary>
/// <param name="objNode">The node to get its inner text.</param>
function Xml_GetInnerText(objNode)
{
	return objNode.textContent;
}
/// </method>

/// <method name="Xml_SetInnerText">
/// <summary>
/// Sets the text string of the specified node
/// </summary>
/// <param name="objNode">The node to set its inner text.</param>
function Xml_SetInnerText(objNode,strText)
{
	objNode.textContent = strText;
}
/// </method>

/// <method name="Xml_SelectSingleNode">
/// <summary>
/// Selects a single node
/// </summary>
/// <param name="strXPath">The XPath value to retrieve node by.</param>
/// <param name="objContext">The search node context.</param>
/// <param name="objDocument">The node document (optional).</param>
function Xml_SelectSingleNode(strXPath,objContext,objDocument)
{
    // Validate recieved arguments.
    if(objContext && !Aux_IsNullOrEmpty(strXPath))
    {
	    // Get document object if needed
	    if(!objDocument)
	    {
		    objDocument = objContext.ownerDocument;
	    }
    	
    	// Validate document.
	    if(objDocument)
	    {
	        // Get XPathResult node.
	        var objNode = objDocument.evaluate(strXPath, objContext, Xml_NSResolver, XPathResult.FIRST_ORDERED_NODE_TYPE, null);
	        if(objNode)
	        {
	            // Get node's value.
	            return objNode.singleNodeValue;
	        }
	    }
	}
	
	return null;
}
/// </method>

/// <method name="Xml_SelectNodes">
/// <summary>
/// Selects a collection of node 
/// </summary>
/// <param name="strXPath">The XPath value to retrieve nodes by.</param>
/// <param name="objContext">The search node context.</param>
/// <param name="objDocument">The node document (optional).</param>
function Xml_SelectNodes(strXPath,objContext,objDocument)
{
	var objResults	= [];

    // Validate recieved arguments.
    if(objContext && !Aux_IsNullOrEmpty(strXPath))
    {
	    // Get document object if needed
	    if(!objDocument)
	    {
		    objDocument = objContext.ownerDocument;
	    }
    	
	    // get XPathResult object
	    var objNodes	= objDocument.evaluate(strXPath, objContext, Xml_NSResolver, XPathResult.ORDERED_NODE_ITERATOR_TYPE , null);
	    var objNode		= null;
	    while(objNode = objNodes.iterateNext())
	    {
		    objResults[objResults.length]=objNode;
	    }	
	}
	
	return objResults;
}
/// </method>

/// <method name="Xml_TransformToHTML">
/// <summary>
/// Transforms a given node to HTML using templates.
/// </summary>
/// <param name="objNode">The node to be transformed.</param>
function Xml_TransformToHTML(objNode)
{   
	return Xml_GetOuterXML(Xml_TransformToDom(objNode));
}
/// </method>



/// <method name="Xml_GetEnumerable">
/// <summary>
/// Returns an enumerable object that supports nextNode and reset function.
/// </summary>
/// <param name="objNodeList">The node list to use.</param>
function Xml_GetEnumerable(objNodeList)
{
	return new Xml_Enumerator(objNodeList);
}
/// </method>



/// <method name="Xml_Enumerator" access="private">
/// <summary>
/// Enumerator simulating object
/// </summary>
function Xml_Enumerator(objNodeList)
{
	this.mobjNodeList = objNodeList;
	this.length = objNodeList.length;
	this.mintIndex = 0;
}
/// </method>

/// <method name="Xml_Enumerator.nextNode" access="private">
/// <summary>
/// 
/// </summary>
Xml_Enumerator.prototype.nextNode = function()
{
	var objObject = null;
	if(this.mintIndex<this.mobjNodeList.length)
	{
		objObject = this.mobjNodeList[this.mintIndex];
		this.mintIndex++;
	}
	return objObject;
};
/// </method>

/// <method name="Xml_Enumerator.reset" access="private">
/// <summary>
/// 
/// </summary>
Xml_Enumerator.prototype.reset = function()
{
	this.mintIndex = 0;
};
/// </method>

/// <method name="Xml_CreateNode">
/// <summary>
/// 
/// </summary>
function Xml_CreateNode(objXmlDocument,intNodeType,strTagName,strNamespaceURI)
{
    var objNode = null;
    
    // Validate arguments.
    if(objXmlDocument && strTagName)
    {
        objNode = objXmlDocument.createElementNS(strNamespaceURI,strTagName);
    }
    
    return objNode;
}
/// </method>
