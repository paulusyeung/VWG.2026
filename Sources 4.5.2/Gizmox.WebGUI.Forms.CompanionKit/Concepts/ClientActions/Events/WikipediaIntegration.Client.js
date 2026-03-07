var mstrResultHtmlBoxID = null;

/// <method name="onWikiPediaCallBack" access="private">
/// <summary>
/// Wikipedia search call baack. 
/// </summar
function onWikiPediaCallBack(objData) 
{
    // Validate result HtmlBox id.
    if (mstrResultHtmlBoxID) 
    {
        // Get client HtmlBox.
        var objResultHtmlBox = vwgContext.provider.getComponentById(mstrResultHtmlBoxID);
        if (objResultHtmlBox) 
        {
            // Define a deafult result.
            var strResult = "Term was not found";

            // Validate callback data.
            if (objData && objData[1] && objData[1].length>0) 
            {
                // Open a containg div element.
                strResult = "<div style=\"height:100%;width:100%;overflow:auto;\">";

                // Loop all terms recieved.
                for (var i = 0; i < objData[1].length; i++) 
                {
                    // Add current term as a link.
                    strResult += ("<a style=\"color:#1122CC; font:15px arial;\" target=\"_blank\" href=\"" + 'http://en.wikipedia.org/wiki/' + objData[1][i] + "\">" + objData[1][i] + "</a><br/>");
                }

                // Close containg div element.
                strResult += "<\div>";
            }

            // Set the client HtmlBox source.
            objResultHtmlBox.source(strResult);

            // Redraw the client HtmlBox.
            objResultHtmlBox.update();
        }

        // Clear result HtmlBox id.
        mstrResultHtmlBoxID = null;
    }

    // Try getting the temporary wikipedia search script.
    var objScriptElement = document.getElementById("WikipediaSearch");
    if(objScriptElement)
    {
        if(objScriptElement.parentNode)
        {
            // Remove temporary wikipedia search script from page.
            objScriptElement.parentNode.removeChild(objScriptElement);
        }
    }
}
/// </method>

/// <method name="searchWikiPedia" access="private">
/// <summary>
/// Searches wikipedia. 
/// </summar
function searchWikiPedia(strText, strResultHtmlBoxId) 
{
    // Preserve result HtmlBox id.
    mstrResultHtmlBoxID = strResultHtmlBoxId;

    // Create a wikipedia search url.
    strUrl = 'http://en.wikipedia.org/w/api.php?action=opensearch&search=' + strText + '&format=json&callback=onWikiPediaCallBack';

    // Create a temporary wikipedia search script. 
    var objScriptElement = document.createElement('script');
    objScriptElement.setAttribute('src', strUrl);
    objScriptElement.setAttribute('type', 'text/javascript');
    objScriptElement.id="WikipediaSearch";

    // Add the temporary wikipedia search script to page.
    document.getElementsByTagName('head')[0].appendChild(objScriptElement);
}
/// </method>

/// <method name="invokeSearchhWikiPedia" access="private">
/// <summary>
/// Searches wikipedia. 
/// </summar
function invokeSearchhWikiPedia(strTextBoxId, strHtmlBoxId)
{
    var mobjQueryTextBox = vwgContext.provider.getComponentById(strTextBoxId);
    var mobjResultHtmlBox = vwgContext.provider.getComponentById(strHtmlBoxId);
    var objQueryText = mobjQueryTextBox.text();
    window.searchWikiPedia(objQueryText, mobjResultHtmlBox.id());
}
/// </method>