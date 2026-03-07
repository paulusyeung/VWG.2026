var mcntMsxmlDOMDocumentProgID = null;

/// <method name="Xml_GetMsxmlDOMDocumentProgID">
/// <summary>
/// Creates an xml element from a given xml string
/// </summary>
function Xml_GetMsxmlDOMDocumentProgID()
{
    if(!mcntMsxmlDOMDocumentProgID)
    {
        var arrProgIDs = [ 'Msxml2.DOMDocument.6.0', 'Msxml2.DOMDocument.5.0', 'Msxml2.DOMDocument.4.0', 'Msxml2.DOMDocument.3.0', 'Msxml2.DOMDocument' ]; 
       
        for (var i = 0; i < arrProgIDs.length; i++) 
        {
            try 
            {
                if(new ActiveXObject(arrProgIDs[i]))
                {
                    mcntMsxmlDOMDocumentProgID = arrProgIDs[i];
                    break;
                }
            }
            catch (objException) {}
        }
    }
       
    return mcntMsxmlDOMDocumentProgID;
}

/// <method name="Xml_CreateElementFromXml">
/// <summary>
/// Creates an xml element from a given xml string
/// </summary>
function Xml_CreateElementFromXml(strXml)
{
    var objDOM = new ActiveXObject(Xml_GetMsxmlDOMDocumentProgID());
    objDOM.loadXML(strXml);
    Xml_SetXmlDomProperties(objDOM, 1);
    return objDOM.documentElement;      
}
/// </method>

/// <method name="Xml_SetXmlDomProperties">
/// <summary>
/// Sets the dom element for XPath queries
/// </summary>
function Xml_SetXmlDomProperties(objXmlDom,intType)
{        
    if(intType==1)
    {
        objXmlDom.setProperty("SelectionNamespaces", "xmlns:WC='wgcontrols' xmlns:WG='http://www.gizmox.com/webgui'");
        objXmlDom.setProperty("SelectionLanguage", "XPath");
    }
}
/// </method>


/// <method name="Xml_LoadXmlDom">
/// <summary>
/// Loads an xml document
/// </summary>
/// <param name="strUrl">The URL of the xml to be retrieved.</param>
/// <param name="callback">The callback function to be called after document is loaded.</param>
function Xml_LoadXmlDom(strUrl,callback)
{
    var objXmlDom = new ActiveXObject(Xml_GetMsxmlDOMDocumentProgID());
    objXmlDom.async = true;
    objXmlDom.onreadystatechange = function () {
      if (objXmlDom.readyState == 4) {
           callback(objXmlDom);
      }
	};
    objXmlDom.load(strUrl);
}
/// </method>




/// <method name="Xml_GetOuterXML">
/// <summary>
/// Gets the xml string of the specified node
/// </summary>
/// <param name="objNode">The notde to get its outer xml.</param>
function Xml_GetOuterXML(objNode)
{
	return objNode.xml;
}
/// </method>

/// <method name="Xml_GetInnerText">
/// <summary>
/// Gets the text string of the specified node
/// </summary>
/// <param name="objNode">The node to get its inner text.</param>
function Xml_GetInnerText(objNode)
{
	return objNode.text;
}
/// </method>

/// <method name="Xml_SetInnerText">
/// <summary>
/// Sets the text string of the specified node
/// </summary>
/// <param name="objNode">The node to set its inner text.</param>
function Xml_SetInnerText(objNode,strText)
{
	objNode.text = strText;
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
	return objContext.selectSingleNode(strXPath);
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
	return objContext.selectNodes(strXPath);
}
/// </method>



/// <method name="Xml_GetEnumerable">
/// <summary>
/// Returns an enumerable object that supports nextNode and reset function.
/// </summary>
/// <param name="objNodeList">The node list to use.</param>
function Xml_GetEnumerable(objNodeList)
{
	return objNodeList;
}
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
        objNode = objXmlDocument.createNode(intNodeType,strTagName,strNamespaceURI);
    }
    
    return objNode;
}
/// </method>