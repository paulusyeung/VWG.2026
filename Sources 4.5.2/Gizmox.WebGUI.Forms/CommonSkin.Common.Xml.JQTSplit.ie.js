



/// <method name="Xml_TransformToHTML">
/// <summary>
/// Transforms a given node to HTML using templates.
/// </summary>
/// <param name="objNode">The node to be transformed.</param>
function Xml_TransformToHTML(objNode)
{
    return objNode.transformNode(mobjXSLDocument);
}
/// </method>

/// <method name="Xml_LoadXSLDocument">
/// <summary>
/// Returns the xsl document 
/// </summary>
/// <param name="strXSLUrl">The XSL URL.</param>
/// <param name="fncCallback">The callback function to be called after xsl is loaded.</param>
function Xml_LoadXSLDocument(strXSLUrl,fncCallback)
{
	Xml_LoadDocument(strXSLUrl,fncCallback);
}
/// </method>
