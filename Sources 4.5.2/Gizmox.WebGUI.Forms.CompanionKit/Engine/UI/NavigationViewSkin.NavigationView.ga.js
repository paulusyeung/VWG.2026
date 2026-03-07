// Include the Asynchronous Tracking Code Snippet
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-2183896-3']);
(function() {
  var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
  ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
  var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();

// Include the addthis code snippet
(function() {
  var st = document.createElement('script'); st.type = 'text/javascript';
  st.async = true;
  st.src = 'http://s7.addthis.com/js/250/addthis_widget.js#username=xa-4b5321ff2b30138b';
  var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(st, s);
})();


// Call to track page view with Item link
function GA_TrackPageview()
{
	if( window.location.hostname.toLowerCase() != 'localhost')
	{
		var result = GetPageInfo();
		if(result.url.length >0){
			_gaq.push(['_trackPageview', result.url]);	
		}
	}
}

// Call to track event with Name and event Value
function GA_TrackEvent(strName, strValue)
{
	if( strValue != null && strValue.length >0 && 
	    window.location.hostname.toLowerCase() != 'localhost')
	{
		//alert('Event:' + strName + ' Value:' + strValue);
		_gaq.push(['_trackEvent', strName, strValue]);	
	}
}


// Call to set updated properties of the page
function RenderSharingToolbox()
{
	// required to ensure that addthis API script loaded
	$(document).ready(function() 
	{
		// Get share toolbox
		var tbx = Web_GetElementById("toolbox", window);
		// Check if available, not always shown on the page
		if(tbx){
			var result = GetPageInfo();
			if(result.url.length >0){
				var svcs = {email: '', twitter: '', facebook: '', gmail: '', expanded: ''};
				for (var s in svcs){
					tbx.innerHTML += '<a class="addthis_button_'+s+'">'+svcs[s]+'</a>';
				}
				addthis.toolbox("#toolbox",
								{
									// configuration object
									ui_click: true
								},
								{
									// sharing info object
									url: result.url,
									title: result.title,
									description: result.description
								});
			}
		}
	});
}

// get information from page node
function GetPageInfo()
{
	var result = {
		url: "",
		title: "",
		description: ""
	};

	if(mobjDataDomObject)
	{
		var objNodes	= Xml_SelectNodes("//WC:GZNV/GZMVIEW",mobjDataDomObject.documentElement);
		var objNode		= objNodes.length >0 ? objNodes[0] : null;
		if(objNode)
		{
			// direct link to the presented code snippet
			result.url	= Xml_GetAttribute(objNode, "Link", "");
			result.title	= Xml_GetAttribute(objNode, "Attr.Title", "");
			result.description = Xml_GetAttribute(objNode, "Desc", "");
		}
	}
	return result;
}


