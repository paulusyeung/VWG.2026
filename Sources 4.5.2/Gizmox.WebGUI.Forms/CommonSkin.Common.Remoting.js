var mintRemotingMethodID	= 1;
var mobjRemotingMethods		= {};

/// <method name="Remoting_ObjectToString" access="private">
/// <summary>
///
/// </summary>
/// <param name="objObject"></param>
function Remoting_ObjectToString(objObject)
{
	if(objObject==null)
	{
		return "";
	}
	else
	{
		return String(objObject);
	}
}
/// </method>

/// <method name="Remoting_ServerInvoke" access="private">
/// <summary>
///
/// </summary>
/// <param name="objMethodInvoke"></param>
function Remoting_ServerInvoke(objMethodInvoke)
{    
    // Get remoting method
    var strMethodName = Remoting_GetMethod(objMethodInvoke.getAttribute("Attr.MethodName"));
	var intIndex = 0;
	var arrArguments = [];
	    
	// While argument exists
	while (objMethodInvoke.attributes.getNamedItem("Attr.Argument" + intIndex))
	{
	    var strArgument = objMethodInvoke.getAttribute("Attr.Argument" + intIndex);

        // Get argument type.
	    var strArgumentType = objMethodInvoke.getAttribute("Attr.ArgumentType" + intIndex);

        // Convert the string argument value to the actual argumenet by the argument type.
	    // NOTE: By default is String (Also if the Attr.ArgumentType is not set at all)
	    var objArgument = strArgument;
	    if (strArgumentType == "N") // Number
	    {
	        objArgument = Number(strArgument);
	    }
	    else if (strArgumentType == "D") // DateTime
	    {
	        objArgument = Web_GetDateFromTicks(parseFloat(strArgument));	        
	    }
	    else if (strArgumentType == "J") // Json
	    {
	        objArgument = jQuery.parseJSON(strArgument);
	    }
	    else if (strArgumentType == "B") // boolean
	    {
	        if (strArgument == "true")
	        {
	            objArgument = true;
	        }
	        else
	        {
	            objArgument = false;
	        }
	    }
	    else if (strArgumentType == "U") // Undefined
	    {
	        objArgument = undefined;
	    }

	    arrArguments[intIndex] = objArgument;
	    intIndex++;
	}
	    
	// Invoke method
	Aux_InvokeMethod(strMethodName, arrArguments);
}
/// </method>


/// <method name="Remoting_ServerInvokeTargetMember">
/// <summary>
/// Invokes a method on a target content window
/// </summary>
/// <param name="strGuid">The component id.</param>
/// <param name="strMember">The method member name.</param>
function Remoting_ServerInvokeTargetMember(strId,strMember)
{
    // Get the iframe element
    var objIFrame = Web_GetTargetElementByDataId(strId);
    if(objIFrame && objIFrame.contentWindow)
    {
        // Get the method from the content window
        var fncMethod = objIFrame.contentWindow[strMember];
        if(fncMethod)
        {
            // Get method arguments
            var arrArguments = [];                
            for(var intIndex=2;intIndex<arguments.length;intIndex++)
            {
                arrArguments.push(arguments[intIndex]);
            }
            
            // Invoke method
            Aux_InvokeMethod(fncMethod,arrArguments);
        }
    }
}
/// </method>

/// <method name="Remoting_GetMethod" access="private">
/// <summary>
///
/// </summary>
/// <param name="strMember"></param>
function Remoting_GetMethod(strMember)
{
    if(strMember!=null)
    {
        if(strMember.indexOf("_Callback_")==0)
	    {
		    strMember = strMember.replace("_Callback_","");
		    return mobjRemotingMethods[strMember];
        }
        else
        {
            return eval(strMember);
        }
    }
    else
    {
        return null;
    }		
}
/// </method>

/// <method name="Remoting_Clear" access="private">
/// <summary>
///
/// </summary>
function Remoting_Clear()
{
	mintRemotingMethodID	= 1;
	mobjRemotingMethods		= {};
}
/// </method>
