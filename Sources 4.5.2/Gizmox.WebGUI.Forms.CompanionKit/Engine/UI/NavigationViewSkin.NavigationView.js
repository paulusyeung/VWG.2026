/// <method name="NavigationView_Toggle">
/// <summary>
///	Expands the folder node if loaded, collapses if expanded
/// If the node is collapsed but not loaded, calls to Click() to load and expand the node.
/// strGuid like: 6_N218 or 6_C152
/// </summary>
function NavigationView_Toggle(strGuid, objElement, objWindow)
{
	var objNode = Data_GetNode(strGuid);
    if( NavigationView_IsLoaded(objNode) )
    {
		var strTarget = Xml_IsAttribute(objNode, "Attr.Expanded", "1") ? "0" : "1";
		var strEvent = strTarget == "0" ? "Collapsed" : "Expanded";
        Xml_SetAttribute(objNode, "Attr.Expanded",  strTarget);
        Events_CreateEvent(strGuid, strEvent, null, true);
        Controls_RedrawControlByNode(objWindow, objNode, false);
    }   
    else
    {
        NavigationView_Click(strGuid, null, objWindow);    
    }
}
/// </method>

/// <method name="NavigationView_IsLoaded">
/// <summary>
///	Indicate where the given node has nodes and they are loaded from server
/// In general we are going to server on first expand of Folder item
/// </summary>
function NavigationView_IsLoaded(objNode)
{
    return Xml_IsAttribute(objNode, "Attr.HasNodes", "1") && objNode.childNodes.length >0;    
}
/// </method>

/// <method name="NavigationView_Click">
/// <summary>
///	Click the item - post event to the server
/// Move the related sub-category node to the first position
/// Example: strGuid: 6_N218 or 6_C152
/// </summary>
function NavigationView_Click(strGuid, objElement, objWindow)
{
    if(objWindow == null)
    {
        objWindow = window;
    }    
    // Get node data
	var objNode = Data_GetNode(strGuid);
    NavigationView_SelectPage(strGuid, objWindow);	
	if(objNode)
	{
        Events_CreateEvent(strGuid,"Click");
		Events_RaiseEvents();
    }
}
/// </method>

/// <method name="NavigationView_GoHome">
/// <summary>
///	Navigates to default item of CK root item
/// </summary>
function NavigationView_GoHome(strGuid)
{
	Events_CreateEvent(strGuid,"OpenHP");
	Events_RaiseEvents();
}
/// </method>

/// <method name="NavigationView_ShowLinks">
/// <summary>
///	Opens a form displaying links to direct access
/// </summary>
function NavigationView_ShowLinks(strGuid)
{
	Events_CreateEvent(strGuid,"Links");
	Events_RaiseEvents();
}
/// </method>


function NavigationView_SelectPage(strGuid, objWindow)
{
    // in case we called from server to client invoke
    if(objWindow == null)
    {
        objWindow = window;
    }
    NavigationView_RaiseSubCategory(strGuid, objWindow);	
    NavigationView_HighlightSelected(strGuid, objWindow);
}

/// <method name="NavigationView_RaiseSubCategory">
/// <summary>
/// Relocate the sub-category node to be the first in tree
/// </summary>
function NavigationView_RaiseSubCategory(strGuid, objWindow)
{
    // in case we called from server to client invoke
    if(objWindow == null)
    {
        objWindow = window;
    }

    // Get related sub-category XML node
	var objSubCategory = NavigationView_GetSubCategory(strGuid, objWindow);
	if(objSubCategory)
	{
	    var objGroupNode = objSubCategory.parentNode;
	    
	    // How-to - Avoid unneeded re-positioning if already done ?
    
        // Get all nodes that was 'expanded' before and mark as collapsed
        var objSubNodes = Xml_SelectNodes("//GZNVIEW/GZND[@Attr.Expanded='1']", objGroupNode);
        for(var intIndex=0; intIndex < objSubNodes.length; intIndex++)
        {
            // don't collapse sub-category of clicked item
            var objCollapsed = objSubNodes[intIndex];
            if(objSubCategory != objCollapsed)
            {
                // Set other sub-category nodes as collapsed
                Xml_SetAttribute(objCollapsed, "Attr.Expanded", "0");
                Xml_SetAttribute(objCollapsed, "CSC", "0");
            }
        }

        // Set clicked sub-category node as expanded	        
        Xml_SetAttribute(objSubCategory, "Attr.Expanded", "1");
        Xml_SetAttribute(objSubCategory, "CSC", "1");        
        
        // Redraw the tree with sub-categories
        Controls_RedrawControlByNode(objWindow,objGroupNode,false);
        
        // Get the top most container and scroll to Top of It.
        $('DIV.GZNV_Container').get(0).scrollTop = 0;

    }
}

/// <method name="NavigationView_HighlightSelected">
/// <summary>
/// 
/// </summary>
function NavigationView_HighlightSelected(strGuid, objWindow)
{
	var objNode = Data_GetNode(strGuid);
    
    // We need to reverse highlighting of previously "selected items" both for categories and pages
    if(objNode != null)
    {
        // Get related sub-category XML node
	    var objSubCategory = NavigationView_GetSubCategory(strGuid, objWindow);
	    if(objSubCategory)
	    {
	        var objGroupNode = objSubCategory.parentNode;

	        // Get all nodes that was 'selected' before
	        var objSubNodes = Xml_SelectNodes("//GZND[@Attr.CurrentPage='1']", objGroupNode);
	        for(var intIndex=0; intIndex < objSubNodes.length; intIndex++)
	        {
		        // Get current sub element
		        var objSubNode = objSubNodes[intIndex];
		        Xml_SetAttribute(objSubNode, "Attr.CurrentPage", "");
	            // Redraw the updated node
	            Controls_RedrawControlByNode(objWindow,objSubNode,false);
	        }
	    }
		
		// the current node highlighted on server and redrawn by response

        // Get related category node and highlight it
        var objCategories = Xml_SelectNodes("//ancestor::GZCVIEW", objNode);
        if(objCategories != null && objCategories.length >0)
        {    
            objCategories = objCategories[0];

            // extract from current node the category it belongs to
            var strCategoryID = "C" + Xml_GetAttribute(objNode, "CT");

            //un-highlight all currently highlighted nodes
            var objCatNodes = Xml_SelectNodes("//GZCT[@CC='1']", objCategories);
            for(var intInd=0; intInd < objCatNodes.length; intInd++)
            {
	            // Get previously active category and drop the tag
	            Xml_SetAttribute(objCatNodes[intInd], "CC", "");
            }
            // get the category node under GZCVIEW
            var objCategoryNodes = Xml_SelectNodes("//GZCT[@Attr.MemberID='" + strCategoryID + "']", objCategories);
            
            // highlight the related category node
            if(objCategoryNodes != null && objCategoryNodes.length >0)
            {
                Xml_SetAttribute(objCategoryNodes[0], "CC", "1");
            }
            // Redraw the panel of categories: GZCVIEW, the only template we have suitable for it!
            Controls_RedrawControlByNode(objWindow, objCategories, false);
        }

    }
}
/// </method>


/// <method name="NavigationView_GetSubCategory">
/// <summary>
///	Returns the sub-category xml node that related to given "GZND" node with strGuid.
/// </summary>
function NavigationView_GetSubCategory(strGuid, objWindow)
{
    // Get node data
	var objNode = Data_GetNode(strGuid);
    var objSubCategory = null;
	if(objNode && objNode.nodeName == "GZND")
	{
	    // check that node itself is sub-category
	    if(Xml_IsAttribute(objNode.parentNode, "Attr.MemberID", 'N0'))
	    {
	        objSubCategory = objNode;
	    }
	    else
	    {   
            for(var parent = objNode.parentNode; parent!=null; parent = parent.parentNode)
            {   
                // check that parent of sub-category node has mID=N0
                if(parent.parentNode && Xml_IsAttribute(parent.parentNode, "Attr.MemberID", 'N0'))
                {
                    objSubCategory = parent;
                    break;
                }
            }
        }
    }
    return objSubCategory;
}
/// </method>

function NavigationView_TabClick(objHeaderElement, objDocument)
{
    // Get current source
    var strSource = Web_GetAttribute(objHeaderElement,"vwgsrc");
    var strTitle = Web_GetAttribute(objHeaderElement,"title");
    var strType = Web_GetAttribute(objHeaderElement,"type");
    
    if(!Aux_IsNullOrEmpty(strSource))
    {
        // update the source for iframe
        var objFrame = objDocument.getElementById("GZNV_CodePane");
        if(objFrame)
        {
            objFrame.src = strSource;
            objFrame.style.display = "block";
        }
        
        // we need to correct links on the images in the drop down
        var element = $(objDocument).find('img.DDLinkImage')
        element.attr("vwgsrc", strSource);
        element.attr("vwgtitle", strTitle);
        
        if(strType == "File")
        {
			$(objDocument).find('#DDLinkContainer').children('div:eq(0)').show();
			$(objDocument).find('#DDLinkContainer').children('div:eq(1)').hide();
		}
		else if(strType == "Article")
		{
			$(objDocument).find('#DDLinkContainer').children('div:eq(0)').hide();
			$(objDocument).find('#DDLinkContainer').children('div:eq(1)').show();
		}
    }
    
    $(objHeaderElement).parents('tbody:eq(0)').children('tr').children('td[class*=GZNVCP_buttonTextSelected]').removeClass('GZNVCP_buttonTextSelected');
    $(objHeaderElement).addClass('GZNVCP_buttonTextSelected');
    
}

function NavigationView_ActivateTab(objHeaderElement)
{
    // we just switched the tab
    if( objHeaderElement )
    {
        // click the highlighted/selected item to load updated value in the IFRAME
        var objSelected = $(objHeaderElement).parents('div.tabberlive').children('div[class!=tabbertab tabinactive]').find('td.GZNVCP_buttonTextSelected').get();
        if(objSelected.length >0)
        {
            NavigationView_TabClick(objSelected[0], document);
        }
    }
}

/// <method name="NavigationView_Edit">
/// <summary>
///	
/// </summary>
function NavigationView_Edit(strGuid, objEvent, objWindow)
{
    NavigationView_SelectPage(strGuid);	
    Events_CreateEvent(strGuid,"Edit");
	Events_RaiseEvents();

    Web_StopPropagation(objEvent);
}
/// </method>

/// <method name="NavigationView_Mode">
/// <summary>
///	Switch mode - Admin to Main and backwards
/// </summary>
function NavigationView_Mode(strGuid)
{
    Events_CreateEvent(strGuid,"Mode");
	Events_RaiseEvents();
}
/// </method>

/// <method name="NavigationView_ReIndex">
/// <summary>
///	Raise an event to Recreate and optimize search index for all CompanionKit items.
/// </summary>
function NavigationView_ReIndex(strGuid)
{
	var result = confirm("Are you sure to start re-indexing?");
	if(result)
	{
		Events_CreateEvent(strGuid,"ReIndex");
		Events_RaiseEvents();
	}
}

/// </method>
/// <method name="NavigationView_EditLE">
/// <summary>
///	Initiate lobby element edit - Element / Section
/// </summary>
function NavigationView_EditLE(strGuid, event, strSectionID, strElementType, strIndex)
{
	// if an element has associated link - "anchor", we need to prevent jump on click
	if (!event) var event = window.event;
		event.cancelBubble = true;
	if (event.stopPropagation) 
		event.stopPropagation();

    var objEvent = Events_CreateEvent(strGuid,"EditLE");
    Events_SetEventAttribute(objEvent, "SectionID" , strSectionID);
    Events_SetEventAttribute(objEvent, "Type" , strElementType);
    Events_SetEventAttribute(objEvent, "Index" , strIndex);
    
	Events_RaiseEvents();
}
/// </method>


/// <method name="NavigationView_Create">
/// <summary>
///	
/// </summary>
function NavigationView_Create(strGuid)
{
    NavigationView_SelectPage(strGuid);	
    Events_CreateEvent(strGuid,"Create");
	Events_RaiseEvents();
}
/// </method>

/// <method name="NavigationView_Search">
/// <summary>
/// trigger the search on the server side
/// </summary>
function NavigationView_Search(strGuid, strWildcard)
{
	if(!Aux_IsNullOrEmpty(strWildcard) && strWildcard != 'Search text ...')
	{
		var objEvent = Events_CreateEvent(strGuid,"Search");
		Events_SetEventAttribute(objEvent, "Wildcard" , strWildcard);
		Events_RaiseEvents();
		
		// set value of input, if function called from search results, by clicking the keyword
		$('div.GZNV_NodeSearch').find('input').removeClass('GZVN_SearchGrayed').val(strWildcard);
		
		// track searched tokens
		GA_TrackEvent('search', strWildcard);
	}
}
/// </method>

/// <method name="NavigationView_SearchKeyPress">
/// <summary>
///	Trigger the search only by pressing the enter
/// </summary>
function NavigationView_SearchKeyPress(strGuid, strWildcard, objEvent)
{
	if(objEvent.keyCode == mcntEnterKey)
        NavigationView_Search(strGuid, strWildcard);
}
/// </method>

/// <method name="NavigationView_Navigate">
/// <summary>
///	Navigates to clicked item after was found in search results
/// </summary>
function NavigationView_Navigate(strGuid, strItemID)
{
    var objEvent = Events_CreateEvent(strGuid,"Navigate");
    Events_SetEventAttribute(objEvent, "ItemID" , strItemID);
	Events_RaiseEvents();
}
/// </method>

/// <method name="NavigationView_Validate">
/// <summary>
/// </summary>
function NavigationView_Validate(strGuid, objWindow)
{
    Events_CreateEvent(strGuid,"Validate");
	Events_RaiseEvents();
}
/// </method>

function NavigationView_DropDownClick(strGuid, strAction, objHeaderElement)
{
    var objEvent = Events_CreateEvent(strGuid,"Browse");
    var strSource = Web_GetAttribute(objHeaderElement,"vwgsrc");
    var strTitle = Web_GetAttribute(objHeaderElement,"vwgtitle");
    
    if(!Aux_IsNullOrEmpty(strSource))
    {
        Events_SetEventAttribute(objEvent, "Action" , strAction);
        Events_SetEventAttribute(objEvent, "RelPath" , strSource);
        Events_SetEventAttribute(objEvent, "Title" , strTitle);
	    Events_RaiseEvents();
	    
	    GA_TrackEvent('browse_' + strAction, strSource);
	}
}

/// <method name="NavigationView_ZipClick">
/// <summary>
/// The implementation of click on ZIP icon to download package of example files
/// </summary>
function NavigationView_ZipClick(strGuid, strAction, strLink)
{
    var objEvent = Events_CreateEvent(strGuid,"Browse");
    Events_SetEventAttribute(objEvent, "Action" , strAction);
    Events_RaiseEvents();
    
    GA_TrackEvent('download_' + strAction, strLink);
}
/// </method>

var mintHeightDelta = 100;
var mintMinHeight   = 680;
var mintBottonAdd   = 100;

// make article frame larger
function NavigationView_EnlargeView()
{
	var height = new Number($("#ArticleFrame")[0].height) + mintHeightDelta;
	$("#ArticleFrame")[0].height = height;
	$("#ArticleCell")[0].height = height;
}

// make article frame smaller
function NavigationView_MakeSmallerView()
{
	var height = new Number($("#ArticleFrame")[0].height) - mintHeightDelta;
	height = height < mintMinHeight ? mintMinHeight : height;
	$("#ArticleCell")[0].height = height;
	$("#ArticleFrame")[0].height = height;
}

// make article frame fit to the content
function NavigationView_ResizeIframe()
{
    var currentfr = $("#ArticleFrame")[0];
    var framecell = $("#ArticleCell")[0];
    if (currentfr)
    {
		var intHeight = 0;
    
        if (currentfr.contentDocument && currentfr.contentDocument.body.offsetHeight) //FF
        {
            intHeight = currentfr.contentDocument.body.offsetHeight + mintBottonAdd; 
        }
        else if (currentfr.Document && currentfr.Document.body.scrollHeight) //ie5+ syntax
        {
            intHeight = currentfr.Document.body.scrollHeight + mintBottonAdd;
        }
        // Also resize parent TD[for IE] to expand to accomodate the content of iframe
		intHeight = intHeight < mintMinHeight ? mintMinHeight : intHeight;
		intHeight += 50; // for the height of editing panel
		currentfr.height = intHeight;
        if(framecell)
        {
			framecell.height = currentfr.height;
		}
    }
}

// the function will be called from Lobby Items to allow executing a sciprt with onclick()
// without jumping to HREF/Inner link associated with the Item
function GZNVStop(e)
{
    e = e || window.event;
	e.cancelBubble = true;
	if (e.stopPropagation)
		e.stopPropagation();
}