
/// <parameters>
/// <summary>
/// VWG mashup parameters

/// </summary>
/// <param name="mintVWGInstance">The last VWG instace.</param>
var mintVWGInstance = 0;
/// <param name="mobjVWGInstances">A collection of instances.</param>
var mobjVWGInstances = {};
/// </parameters>

/// <method name="VWGForm">
/// <summary>
/// Creates a new VWG form
/// </summary>
function VWGForm(strBaseUrl,strApplication)
{
    // The application base url
    this.mstrBaseUrl = strBaseUrl;        
    
    // The application name
    this.mstrApplication = strApplication;
    
    // Get a unique instance name
    this.mintInstace = mintVWGInstance++;
    
    // Store reference to visual webgui application 
    mobjVWGInstances[this.mintInstace] = this;    
}
/// </method>

/// <method name="showDialog">
/// <summary>
/// Displays the form as a modal dialog
/// </summary>
VWGForm.prototype.showDialog = function(objArguments)
{
    // Store arguments localy
    this.mobjArguments = objArguments;
    
    // Call remote method for token
    this._invokeMethod("token","_callbackshowDialog");
}
/// </method>

/// <method name="_callbackshowDialog">
/// <summary>
/// Returns after recieving token
/// </summary>
VWGForm.prototype._callbackshowDialog = function(strResults)
{
    // Show the dialog frame
    this._showDialogFrame(strResults);
}
/// </method>



/// <method name="showDialog">
/// <summary>
/// Displays the form as a modal dialog
/// </summary>
VWGForm.prototype._showDialogFrame = function(strMashupId)
{
    // Get frame
    var objVwgFrame = this._createFrame();
    if(objVwgFrame)
    {         
        // Enforce valid arguments object   
        if(!this.mobjArguments) this.mobjArguments = {};

        // Add mashup parameters
        this.mobjArguments["$mashuptoken"] = strMashupId;
        this.mobjArguments["$mashuptype"] = 'modaldialog';

        // Create IFrame form with arguments and submit
        objVwgFrame.contentWindow.document.open();
        objVwgFrame.contentWindow.document.write("<html>");
        objVwgFrame.contentWindow.document.write("<body>");
        objVwgFrame.contentWindow.document.write("<script>function dosubmit(){");
        objVwgFrame.contentWindow.document.write("var f = document.getElementById('Form');");
        objVwgFrame.contentWindow.document.write("var args = parent.mobjVWGInstances["+this.mintInstace+"].mobjArguments;");
        objVwgFrame.contentWindow.document.write("for(var i in args){");
        objVwgFrame.contentWindow.document.write("var o = document.createElement('input');");
        objVwgFrame.contentWindow.document.write("o.type='hidden';");
        objVwgFrame.contentWindow.document.write("o.name=i;");
        objVwgFrame.contentWindow.document.write("o.id=i;");
        objVwgFrame.contentWindow.document.write("o.value=args[i];");
        objVwgFrame.contentWindow.document.write("f.appendChild(o);");
        objVwgFrame.contentWindow.document.write("}");
        objVwgFrame.contentWindow.document.write("document.getElementById('Form').submit();}</script>");
        objVwgFrame.contentWindow.document.write("<body onload='dosubmit()'>");
        objVwgFrame.contentWindow.document.write("<form id='Form' method='post' action='"+this.mstrBaseUrl+"/Post."+this.mstrApplication + ".wgx"+"'>");    
        objVwgFrame.contentWindow.document.write("</form>");
        objVwgFrame.contentWindow.document.write("</body>");
        objVwgFrame.contentWindow.document.write("</body>");
        objVwgFrame.contentWindow.document.write("</html>");
        objVwgFrame.contentWindow.document.close();                
    }
}
/// </method>


/// <method name="showDialog">
/// <summary>
/// Displays the form as a modal dialog
/// </summary>
VWGForm.prototype._invokeMethod = function(strMethod,strCallback,strArgs)
{
    // Remove previous script tag
    if(this.mobjScript)
    {
        document.body.removeChild(this.mobjScript);
    }
    
    // Set default args value
    if(!strArgs) 
    {
        strArgs = "";
    }
    else 
    {
        strArgs = "&"+strArgs;
    }
    
    // Create script tag with parameters
    this.mobjScript = document.createElement('script');
    this.mobjScript.defer = "true";
    this.mobjScript.src = this.mstrBaseUrl +"/"+ 'Mashup.'+this.mstrApplication + '.dwgx?method=' + strMethod + '&instace='+this.mintInstace+'&callback=' + strCallback + strArgs;
    document.body.appendChild(this.mobjScript);        
}
/// </method>


VWGForm.prototype._callbackMethod = function(objResults)
{

}


VWGForm.prototype._createFrame = function()
{
    var objVwgFrame = document.createElement("IFRAME");
    
    // Setting the new objVwgFrame sizes.
    objVwgFrame.style.width = "100%";
    objVwgFrame.style.height = "100%";
    objVwgFrame.style.position = "absolute";
    objVwgFrame.style.left = 0;
    objVwgFrame.frameBorder = "no";
    objVwgFrame.style.top = window.document.body.scrollTop;
    
    // Setting the objVwgFrame transparent.
    objVwgFrame.allowTransparency = true;
        
        
    window.document.body.appendChild(objVwgFrame);
    
    return objVwgFrame;
}