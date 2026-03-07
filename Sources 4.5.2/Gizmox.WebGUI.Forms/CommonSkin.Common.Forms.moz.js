

/// <method name="Forms_OpenLink">
/// <summary>
/// Opens a link.
/// </summary>
function Forms_OpenLink(strUrl,strName,strParams,strArguments,strMode)
{
    if (!Aux_IsNullOrEmpty(strUrl))
    {
        // Check if url is not absolute url.
        if (!Web_IsAbsoluteUrl(strURL))
        {
            // Get 'Router' string position
            var intRouterIndex = mstrBaseURL.indexOf("/Route/");

            if (intRouterIndex > -1)
            {
                // Remove start leading slashs
                if (strUrl.indexOf("/") == 0 || strUrl.indexOf("\\") == 0)
                {
                    strUrl = strUrl.substring(1, strUrl.length);
                }

                // Concat with base url
                strUrl = mstrBaseURL.substring(0, intRouterIndex) + "/" + strUrl;
            }
        }
    }

	if(Aux_IsNullOrEmpty(strArguments))
    {
	    window.open(strUrl,strName,strParams);
	}
	else
	{
	    Web_SubmitForm(Web_CreateForm(strUrl,strName,strArguments));		
	}
}
/// </method>

/// <method name="Forms_GetWindow">
/// <summary>
/// Gets a browser window object from a window or an element.
/// </summary>
/// <param name="objWindow">The window object or the window element.</param>

function Forms_GetWindow(objWindow)
{
	// TODO: check that it is a valid assumption
	return window;
}
/// </method>