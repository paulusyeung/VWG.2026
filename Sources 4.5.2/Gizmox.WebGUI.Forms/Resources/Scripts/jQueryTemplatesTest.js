(function($){

    /// <summary>
    /// Wrapper of template apply to distinguish the performance
    /// </summary>
    $.jqtapplytemplateroot= function(objNode, strMode, objWriter)
    {
	    return $.jqtapplytemplate(objNode, strMode, objWriter);
    };


    $.jqtapplytemplate_test = function(objNode, strMode, objWriter)
    {
	    var blnRenderDOM = !objWriter;

	    if(!objWriter)
	    {
		    objWriter = $.jqtcreatewriter();
	    }	
    	
		// Transform node with JS templating
		$.jqtapplytemplateroot(objNode, strMode, objWriter);
    			
		if(blnRenderDOM){
			return $(objWriter.flush());
		}			
    };

})(jQuery);