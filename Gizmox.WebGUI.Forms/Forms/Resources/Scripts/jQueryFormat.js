(function($){

	$.format = function(node){
	
		// get the formatted node
		if(node && node.jquery) {
			node = node.get(0);
		}
		
		var buffer = ["<div class='code' >"];

		// Write the code styles
		buffer.push("<style>");
		buffer.push(".code {font-size: 10pt;");
        buffer.push("color: black;");
        buffer.push("font-family: \"Courier New\", Courier, Monospace;");
        buffer.push("background-color: #ffffff;}");	
        buffer.push(".tag, .taglt, .taggt {color:brown;}");
        buffer.push(".attrname {color:red;}");	
        buffer.push(".attrvalue {color:blue;}");
        buffer.push(".setborder {border:1px solid red;}");
        buffer.push(".indent { list-style-type:none;border-left: 1px solid #F0F0E9;margin:0px;padding-left: 30px;}");
        buffer.push("</style>");

		buffer.push("<script type='text/javascript'>");
		buffer.push("function ToggleNode(node){");
		buffer.push(" if(node.parentNode.className!='tag setborder'){");
		buffer.push(" node.parentNode.nextSibling.nextSibling.style.display='none';");
		buffer.push(" node.parentNode.className='tag setborder';}");
		buffer.push(" else{");
		buffer.push(" node.parentNode.nextSibling.nextSibling.style.display='block';");
		buffer.push(" node.parentNode.className='tag';}");
		buffer.push("} </script>");

		_formatNodes(buffer, node);

		buffer.push("</div>");
		
		return buffer.join("");		
	
	};

	function _formatNodes(buffer, node)
	{
		// if node type is element
		if(node.nodeType == 1) {

			buffer.push("<span class='taglt'>", "&lt;","</span>");
			buffer.push("<span class='tag'>");
			
			if( node.childNodes.length == 0){
				buffer.push(node.nodeName);
			}else{
				buffer.push("<span style='cursor:pointer;' onclick=\"ToggleNode(this);\">", node.nodeName, "</span>");
			}
			buffer.push("</span>");
			
			// wrap all attributes
			buffer.push("<span>");

			_formatAttributes(buffer, node);
			
			if(node.childNodes.length > 0) {
				
				buffer.push("<span class='taggt'>", "&gt;","</span></span>");
				
				buffer.push("<ul class='indent'>");

				for(var i=0;i<node.childNodes.length; i++) {
					// Check that it's not a closing node
					if(node.childNodes[i].nodeName.indexOf("/") == -1) {
						buffer.push("<li>");
						_formatNodes(buffer, node.childNodes[i]);
						buffer.push("</li>");
					}
				}

				buffer.push("</ul>");
				buffer.push("<span class='taglt'>&lt;/</span><span class='tag'>",node.nodeName,"<span class='taggt'>", "&gt;","</span><br />");

			} else {
				buffer.push("</span><span class='taggt'>", "/&gt;","</span><br />");
			}
			
		}
		// if node type is text
		else if(node.nodeType == 3){
			buffer.push(escape(String(node.nodeValue), true));
		}
	};
	
	function _formatAttributes(buffer, node)
	{
		var attributes = (node == null ? null : node.attributes);

		if(attributes) {
			$node = $(node);
			// Loop all attributes
			for(var i=0; i<attributes.length; i++) {

				// Get attribute
				var attribute = attributes[i];

				// add attribute start
				buffer.push("<nobr>&nbsp;");
				buffer.push("<span class='attrname'>", attribute.nodeName,"</span>=&quot;");
				buffer.push("<span class='attrvalue'>");
				buffer.push($node.attr(attribute.nodeName));
				buffer.push("</span>")
				buffer.push("&quot;");
				buffer.push("</nobr>");
			}
		}
	};
	
	function escape(s,l) {
		var n = s;
		n = n.replace(/&/g, "&amp;");
		n = n.replace(/</g, "&lt;");
		n = n.replace(/>/g, "&gt;");
		n = n.replace(/"/g, "&quot;");
		
		if(l) {
			n = n.replace(/\s\s/g, "&nbsp; ");
			n = n.replace(/\n/g, "<br/>");
		}
		return n;
	};	
	
})(jQuery);


