
function NavigationView_ThemeHighlightBtn(element)
{
	$(element).toggleClass('entered');
}

function NavigationView_ThemeToggleOpen(objElement)
{
	try
	{
		var objNode = Xml_SelectSingleNode("//WC:GZNV/GZMVIEW", mobjDataDomObject.documentElement);
		var strControlId = Xml_GetAttribute(objNode, "Attr.OwnerID");
		var objRect = Web_GetRect(objElement);
	    
		// Create a tag element node.
		var objTagElement = Xml_CreateNode(mobjDataDomObject,1,"WG:GZTS","http://www.gizmox.com/webgui");
		if(objTagElement)
		{
			// Append tag element to the receieved component's node.
			objNode.appendChild(objTagElement);
	        
			if(objNode && strControlId != "")
			{
				var intX = objRect.right - 528;
				intX = intX < 0 ? 0 : intX;
				var intY = objRect.bottom+1;
				var objPopUp = Popups_CreatePopup(null, strControlId, null, intX, intY, 550, 550, objTagElement, true, false, true);
				$(objPopUp).fadeIn();
			}        
	        
			// Remove the tag element from the receieved component's node.
			objNode.removeChild(objTagElement);
		}
	}
	catch(e)
	{
	}
}

function NavigationView_ThemeHighlight(element)
{
	$(element).toggleClass('highlighted');
}

function NavigationView_ThemeClick(element)
{
	// Drop seleciton of previous
	$(element).parent().find('.themeimagecontainer').removeClass('selectedtheme');

	// Apply selection to the style
	$(element).addClass('selectedtheme');
	
	// Hide the container
	$('#themecontainer').fadeOut().attr('vwgopen', '0');
	
	// Raise event
	NavigationView_SetTheme($(element).parent().attr('vwgowner'), $(element).attr('vwgtheme'));
}

function NavigationView_ThemeLinkClick(element)
{
	// Hide the container
	$('#themecontainer').fadeOut().attr('vwgopen', '0');
	
	// Raise event
	NavigationView_SetTheme($(element).parent().parent().parent().parent().attr('vwgowner'), 
		$(element).attr('vwgtheme'));
}

function NavigationView_SetTheme(strGuid, strThemeName)
{
    var objEvent = Events_CreateEvent(strGuid,"ThemeSet");
    Events_SetEventAttribute(objEvent, "Name" , strThemeName);
    Events_RaiseEvents();
}



