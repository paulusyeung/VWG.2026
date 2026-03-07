


/// <method name="Common_InitializeUI">
/// <summary>
/// Initializes the UI
/// </summary>
function Common_InitializeUI()
{
    // Load designs
	Xml_LoadXSLDocument("Resources.Browser.Form.xslt.wgx",Common_InitializeXsl);
}
/// </method>

/// <method name="Common_InitializeXsl">
/// <summary>
/// Initialize the runtime templates.
/// </summary>
/// <param name="objXSLDocument">The xsl document.</param>
function Common_InitializeXsl(objXSLDocument)
{
	// Set designs
	mobjXSLDocument = objXSLDocument;
	
	// Initialize the content
    Common_LoadContent();
}
/// </method>
