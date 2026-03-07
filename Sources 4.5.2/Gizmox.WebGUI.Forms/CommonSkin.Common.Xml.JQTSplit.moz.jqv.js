

/// <method name="Xml_TransformToDom">
/// <summary>
/// Transforms a given node to HTML dom using templates.
/// </summary>
/// <param name="objNode">The node to be transformed.</param>
function Xml_TransformToDom(objNode)
{
    var objFragment = null;
    
    // Transform the whole response node.
    objFragment = $.jqtapplytemplate_test(objNode).get(0);

	 // Validate fragment.
        if(objFragment)
        {
            // Check if should execute the WebKit inner fetching.
                if(Web_IsAttribute(objFragment,"vwg_fetchedElement","1"))
                {
                    // Get matched element.
                    var objElement = Web_GetContextElementByAttribute(objFragment,"vwg_matchedelement","1",true);
                    if(objElement)
                    {
                        objFragment=objElement;
                    }
                }
        }
        
    return objFragment;
}
/// </method>