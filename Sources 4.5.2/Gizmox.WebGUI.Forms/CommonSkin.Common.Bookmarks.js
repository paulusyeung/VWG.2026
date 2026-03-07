
var mintFormsCurrentBookmarkID = 0;

function Bookmarks_NavigateUrl(objDocument)
{
    var intBookmarkID = parseInt(mobjApp.Web_GetQueryStringParam(objDocument.location.href,"id"));
    
    objDocument.title = Bookmarks_GetTitle(objDocument.location.href);
    if(mintFormsCurrentBookmarkID!=intBookmarkID)
    {
        mintFormsCurrentBookmarkID = intBookmarkID;
        
        var objEvent = Events_CreateEvent("0","NavigateBookmark",null,true);
        Events_SetEventAttribute(objEvent,"Attr.Value",intBookmarkID);
	    Events_ScheduleRaiseEvents(50);
	}

	
}

function Bookmarks_GetTitle(strUrl)
{
    return unescape(mobjApp.Web_GetQueryStringParam(strUrl,"title"));
}

function Bookmarks_SetBookmark(intBookmarkID,strBookmarkTitle)
{
    mintFormsCurrentBookmarkID = intBookmarkID;
    
    var objBookmarksFrame = $$("VWG_BookmarksBox");
    if(objBookmarksFrame)
    {
        objBookmarksFrame.contentWindow.document.location.href = "[Skin.CommonPath]Common.Bookmarks.htm.wgx?id="+intBookmarkID + "&title="+escape(strBookmarkTitle);
    }
}
