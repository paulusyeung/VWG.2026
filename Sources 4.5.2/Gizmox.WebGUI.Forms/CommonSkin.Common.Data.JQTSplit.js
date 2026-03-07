
/// <method name="Data_Initialize"  access="private">
/// <summary>
/// Initializes interface data
/// </summary>
/// <param name="objDomObject">The off-screen buffering data object.</param>
function Data_Initialize(objDomObject)
{
	// Set references
	mobjDataDomObject		= objDomObject;
	mobjDataRootObject		= objDomObject.documentElement;
	
	// Prepare dom for XPath
	Xml_SetXmlDomProperties(mobjDataDomObject,1);
}
/// </method>
