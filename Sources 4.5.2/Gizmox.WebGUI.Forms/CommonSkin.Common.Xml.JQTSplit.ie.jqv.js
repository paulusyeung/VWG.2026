
/// <method name="Xml_TransformToHTML">
/// <summary>
/// Transforms a given node to HTML using templates.
/// </summary>
/// <param name="objNode">The node to be transformed.</param>
function Xml_TransformToHTML(objNode)
{
    var objWriter = $.jqtcreatewriter();
	$.jqtapplytemplate_test(objNode, null, objWriter);
	return objWriter.flush();
}
/// </method>

