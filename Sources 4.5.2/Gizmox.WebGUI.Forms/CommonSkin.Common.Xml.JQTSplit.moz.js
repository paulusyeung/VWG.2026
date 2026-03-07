


/// <method name="Xml_TransformToDom">
/// <summary>
/// Transforms a given node to HTML dom using templates.
/// </summary>
/// <param name="objNode">The node to be transformed.</param>
function Xml_TransformToDom(objNode)
{
    var objFragment = null;
    
    if(mcntIsWebKit)
    {
        // Set the recieved node's redraw attribute.
        Xml_SetAttribute(objNode,"vwg_redraw","1");
        
        try
        {
            // Transform the whole response node.
            objFragment = mobjXSLDocument.transformToFragment(objNode.ownerDocument.documentElement, document);
        }
        catch(e)
        {
            // Remove the recieved node's redraw attribute.
            Xml_RemoveAttribute(objNode,"vwg_redraw");
            
            // Throws original exception.
            throw e;
        }
        
        // Remove the recieved node's redraw attribute.
        Xml_RemoveAttribute(objNode,"vwg_redraw");
        
        // Validate fragment.
        if(objFragment)
        {
            // Get root element.
            var objFragmentFirstChild = objFragment.firstChild;
            if(objFragmentFirstChild)
            {
                // Check if should execute the WebKit inner fetching.
                if(Web_IsAttribute(objFragmentFirstChild,"vwg_fetchedElement","1"))
                {
                	// Get matched element.
                    var objElement = Web_GetContextElementByAttribute(objFragment,"vwg_matchedelement","1",true);
                    if(objElement)
                    {
                        objFragment=objElement;
                    }
                }
            }
        }
    }
    else
    {
        objFragment = mobjXSLDocument.transformToFragment(objNode, document);
    }
    
    return objFragment;
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
    if(mcntIsWebKit)
    {
        var objXHR = $.ajax({
            url: strXSLUrl,
            async: true,
            xhrFields: { responseType: "document" },
            type: "GET"
        });
        
        objXHR.done(function (msg) {
            var objXSLTProcessor = new XSLTProcessor();
	        objXSLTProcessor.importStylesheet(objXHR.responseXML.documentElement);	         
	        fncCallback(objXSLTProcessor);
        });
    }
    else
    {
	    // Get xsl procesor
	    var objStylesheet=document.implementation.createDocument("","",null);
	    objStylesheet.async=false;
	    objStylesheet.load(strXSLUrl);

	    var objXSLTProcessor = new XSLTProcessor();
	    objXSLTProcessor.importStylesheet(objStylesheet);
	    fncCallback(objXSLTProcessor);
	}
}
/// </method>
