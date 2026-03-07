/*
highlight v3
Highlights arbitrary terms.
It is a permissive license, meaning that it permits reuse within proprietary software on the condition 
that the license is distributed with that software. The license is also GPL-compatible, meaning that the GPL permits combination and redistribution with software that uses the MIT License.
<http://johannburkard.de/blog/programming/javascript/highlight-javascript-text-higlighting-jquery-plugin.html>
MIT license.
Johann Burkard
<http://johannburkard.de>
<mailto:jb@eaio.com>

Nov 2010, A.Chirlin, added a callback when the item is matched, fnMatch callback will be called to hide irrelevant items.

*/

jQuery.fn.highlight = function(pat, fnMatch) {
 function innerHighlight(node, pat) {
  var skip = 0;
  if (node.nodeType == 3) {
   var pos = node.data.toUpperCase().indexOf(pat);
   if (pos >= 0) {
    var spannode = document.createElement('span');
    spannode.className = 'GZNVS_Highlight';
    var middlebit = node.splitText(pos);
    var endbit = middlebit.splitText(pat.length);
    var middleclone = middlebit.cloneNode(true);
    spannode.appendChild(middleclone);
    middlebit.parentNode.replaceChild(spannode, middlebit);
    skip = 1;
   }
  }
  else if (node.nodeType == 1 && node.childNodes && !/(script|style)/i.test(node.tagName)) {
   // Counts matches
   var skips = 0;
   for (var i = 0; i < node.childNodes.length; ++i) {
    var skip = innerHighlight(node.childNodes[i], pat);
    i += skip;
    skips += skip;
   }
   fnMatch(node, skips >0);
  }
  return skip;
 }
 return this.each(function() {
  innerHighlight(this, pat.toUpperCase());
 });
};

jQuery.fn.removeHighlight = function() {
 return this.find("span.GZNVS_Highlight").each(function() {
  this.parentNode.firstChild.nodeName;
  with (this.parentNode) {
   replaceChild(this.firstChild, this);
   normalize();
  }
 }).end();
};

var mintFilterText = -1;

// clear highlight and value
function GZNVS_SetInitial()
{
	$('#VWGFilterValue').val('');
	GZNVS_ApplyFilter();
}

// handles keyup events with small timeout
function GZNVS_Filter()
{
	//debugger;
    if(mintFilterText != -1) 
		clearTimeout(mintFilterText);
    mintFilterText = setTimeout("GZNVS_ApplyFilter()", 200);
}

// search and highlight results
function GZNVS_ApplyFilter()
{
	var element = $('#VWGFilterValue'),
	    items   = element.closest('table').parent().find('DIV.GZNVS_ItemContainer');
	var text    = element.val();
	var hits	= 0; // count of Items matching the criteria
	items.each(function() {
		
		var item = $(this);
		if( text.length >0 )
		{
			var hit = 0;
			item.find('div.GZNVS_Filterable').removeHighlight().each(function(){
				
				$(this).highlight(text, function(node, match){hit += match ? 1 : 0});
				if(hit == 0)
					item.hide();
				else
					item.show();
			});
			hits += hit >0 ? 1 : 0;
		}
		else
			item.show().find('div.GZNVS_Filterable').removeHighlight();
	});
}
