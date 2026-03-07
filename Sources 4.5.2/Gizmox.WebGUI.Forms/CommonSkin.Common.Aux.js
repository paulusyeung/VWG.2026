/// <page code="Aux" name="Auxilury Services">
/// <summary>
/// Auxilury methods for common tasks
/// </summary>

/// <method name="Aux_IsNullOrEmpty">
/// <summary>
/// Checks if a string is empty or null
/// </summary>
/// <param name="strInput">The string to be checked.</param>
function Aux_IsNullOrEmpty(strInput)
{
	if(strInput==null||String(strInput)=="")return true;
	return false;
}
/// </method>

/// <method name="Aux_ParseInt">
/// <summary>
/// Gets an integer from a string
/// </summary>
/// <param name="strInteger">The number's string</param>
/// <param name="intDefault">The default integer to return if not a number</param>
function Aux_ParseInt(strInteger,intDefault)
{
    if(isNaN(strInteger))
    {
        return intDefault;
    }
    else
    {
        return parseInt(strInteger);
    }
}
/// </method>

/// <method name="Aux_Trim">
/// <summary>
/// Returns a trimed string
/// </summary>
/// <param name="strValue">The string to be trimed.</param>
function Aux_Trim(strValue)
{
    return strValue.replace(/^[\s\n\t]+|[\s\n\t]+$/g, '');
}
/// </method>

/// <method name="Aux_IsCursorKeyCode">
/// <summary>
/// Check if a key code is a cursor key code
/// </summary>
/// <param name="intKeyCode">The key code to be checked.</param>
function Aux_IsCursorKeyCode(intKeyCode)
{
	if(intKeyCode==UP_KEY||intKeyCode==DOWN_KEY||intKeyCode==LEFT_KEY||intKeyCode==RIGHT_KEY)return true;
	return false
}
/// </method>

/// <method name="Aux_ArrayContains">
/// <summary>
/// Checks if an array contains a specific value
/// </summary>
/// <param name="arrArray">The array to be checked.</param>
/// <param name="objValue">The value to be searched.</param>
function Aux_ArrayContains(arrArray,objValue)
{
	for(var intIndex=0;intIndex<arrArray.length;intIndex++)
	{
		if(arrArray[intIndex]==objValue)
		{
			return true;
		}
	}
	
	return false;
}
/// </method>

/// <method name="Aux_ArrayRemoveSingleItem">
/// <summary>
/// Removes a single item from an array
/// </summary>
/// <param name="arrArray">The array.</param>
/// <param name="objItem">The item to be removed.</param>
function Aux_ArrayRemoveSingleItem(arrArray, objItem)
{
    if (objItem && arrArray)
    {
        var intIndex = $.inArray(objItem, arrArray);

        if (intIndex != -1)
        {
            arrArray.splice(intIndex, 1);
        }
    }
}
/// </method>

/// <method name="Aux_CharFromKeyCode">
/// <summary>
/// Gets a charecter from a given key code
/// </summary>
/// <param name="intKeyCode">The key code to be converted to char.</param>
function Aux_CharFromKeyCode(intKeyCode)
{
	if((intKeyCode>=96)&&(intKeyCode<=105))
	{
		return String.fromCharCode(intKeyCode-48);
	}
	else
	{
		return String.fromCharCode(intKeyCode);
	}
}
/// </method>

/// <method name="Aux_IsDigitKeyCode">
/// <summary>
/// Checks if a given key code is a digit
/// </summary>
/// <param name="intKeyCode">The key code to be checked.</param>
function Aux_IsDigitKeyCode(intKeyCode,blnAppliedValue)
{
	if(((intKeyCode>=48)&&(intKeyCode<=57))||((intKeyCode>=96)&& !blnAppliedValue &&(intKeyCode<=105)))return true;
	else return false
}
/// </method>

/// <method name="Aux_IsLetterKeyCode">
/// <summary>
/// Checks if a given key code is a letter charecter.
/// </summary>
/// <param name="intKeyCode">The key code to be checked.</param>
/// <param name="enmCaseType">case type to check, 0-both, 1-lower, 2-upper</param>
function Aux_IsLetterKeyCode(intKeyCode,enmCaseType)
{
    var blnIsLetterKeyCode = false;
    
    if(Aux_IsNullOrEmpty(enmCaseType))
    {
        enmCaseType = 0;
    }
    
    if(enmCaseType==0 || enmCaseType==1)
    {
        blnIsLetterKeyCode=(intKeyCode>='a'.charCodeAt(0)) && intKeyCode<='z'.charCodeAt(0);
    }
    
    if(enmCaseType==0 || enmCaseType==2)
    {
        blnIsLetterKeyCode|=(intKeyCode>='A'.charCodeAt(0)) && intKeyCode<='Z'.charCodeAt(0);
    }
    
    return blnIsLetterKeyCode;
}
/// </method>

/// <method name="Aux_IsAlphaNumericKeyCode">
/// <summary>
/// Checks if a given key code is a letter or digit charecter.
/// </summary>
/// <param name="intKeyCode">The key code to be checked.</param>
function Aux_IsAlphaNumericKeyCode(intKeyCode,blnAppliedValue)
{
    return (Aux_IsDigitKeyCode(intKeyCode, blnAppliedValue) || Aux_IsLetterKeyCode(intKeyCode,0));
}
/// </method>

/// <method name="Aux_Stack">
/// <summary>
/// Represents a stack object (should be used with new keyword).
/// </summary>
function Aux_Stack()
{
	this.mobjData = [];
	this.mintIndex = -1;
}
/// </method>

/// <method name="Aux_StackPush">
/// <summary>
/// Pushes a value into the stack.
/// </summary>
/// <param name="objStack">The stack to push value into.</param>
/// <param name="objValue">The value to puch into the stack.</param>
function Aux_StackPush(objStack,objValue)
{
	objStack.mintIndex++;
	return objStack.mobjData[objStack.mintIndex]=objValue;
}
/// </method>

/// <method name="Aux_StackPop">
/// <summary>
/// Pops the last entered value from the stack.
/// </summary>
/// <param name="objStack">The stack to pop value from.</param>
function Aux_StackPop(objStack)
{
	var objValue = objStack.mintIndex==-1?null:objStack.mobjData[objStack.mintIndex];
	if(objStack.mintIndex>-1) objStack.mintIndex--;
	return objValue;
	
}
/// </method>



/// <method name="Events_RaiseEventsCallback">
/// <summary>
/// Callback delegate for the raise events method.
/// </summary>
/// <param name="fncMethod">The callback function.</param>
/// <param name="arguments...">Arguments to invoke the callback function with.</param>
function Aux_CallbackDelegate(fncMethod)
{
    // Create temporary array
    var arrTemp = [];
    
    // Loop all arguments except for the first one
    for(var intIndex=1;intIndex<arguments.length;intIndex++)
    {
        arrTemp.push(arguments[intIndex]);
    }
    
    // Store local variables
    this.arrArguments = arrTemp;    
    this.fncMethod = fncMethod;
    
}
/// </method>

/// <method name="Aux_InvokeCallbackDelegate">
/// <summary>
/// Invokes a callback delegate.
/// </summary>
/// <param name="objCallbackDelegate">The callback delegate.</param>
function Aux_InvokeCallbackDelegate(objCallbackDelegate)
{
    return Aux_InvokeMethod(objCallbackDelegate.fncMethod,objCallbackDelegate.arrArguments);
}
/// </method>

/// <method name="Aux_InvokeCallbackDelegateWithDelay">
/// <summary>
/// Invokes a callback delegate with delay.
/// </summary>
/// <param name="objCallbackDelegate">The callback delegate.</param>
/// <param name="intDelay">Delay in milliseconds.</param>

function Aux_InvokeCallbackDelegateWithDelay(objCallbackDelegate,intDelay, objWindow)
{
    return Web_SetTimeout( function(){Aux_InvokeCallbackDelegate(objCallbackDelegate);},intDelay, objWindow);
}
/// </method>

/// <method name="Aux_InvokeMethod">
/// <summary>
/// Invoke a method using method reference and arguments array.
/// </summary>
/// <param name="fncMethod">The function reference.</param>
/// <param name="arrArguments">The function arguments.</param>
function Aux_InvokeMethod(fncMethod,arrArguments)
{
    if (fncMethod.apply != undefined) 
    {
        return fncMethod.apply(this, arrArguments);
    }
    else 
    {
        // Create string command
        var strCommand = ["fncMethod("];

        // Add all arguments
        if (arrArguments) 
        {
            for (var intIndex = 0; intIndex < arrArguments.length; intIndex++) 
            {
                // Add comma if required
                if (intIndex > 0) 
                {
                    strCommand.push(",");
                }
                // Add argument
                strCommand.push("arrArguments[" + intIndex + "]");
            }
        }

        // Add closing mothod call
        strCommand.push(")");

        // Return method evaluation
        return eval(strCommand.join(""));
    }
}
/// </method>


/// <method name="Aux_Point">
/// <summary>
/// Serves as a point struct
/// </summary>
/// <param name="intLeft">The left position.</param>
/// <param name="intTop">The top position.</param>
function Aux_Point(intLeft,intTop)
{
    this.left = intLeft;
    this.top = intTop;
}
/// </method>

/// <method name="Aux_EncodeText">
/// <summary>
/// Encodes text to prevent data loss when using xml attributes.
/// </summary>
/// <remarks>
/// The methods encodes a text value to prevent data loss when using
/// attributes. This allows to use attributes for text values without loosing information
/// due to xml attribute normalization.
/// </remarks>
/// <param name="strText"></param>
function Aux_EncodeText(strText)
{
    if(strText)
    {
        return strText.replace(/(^\s)|(\s$)|(\s\s)|[\t\n\r\\]/gm,Aux_EncodeMatch);   
    }
    return "";
}
/// </method>

/// <method name="Aux_EncodeMatch"  access="private">
/// <summary>
/// Encodes a specific match
/// </summary>
/// <param name="strMatch">The current match to encode.</param>
function Aux_EncodeMatch(strMatch)
{
    switch(strMatch)
    {
        case " ": return "\\b"; 
        case "  ": return " \\b"; 
        case "\t": return "\\t"; 
        case "\n": return "\\n"; 
        case "\r": return ""; 
        case "\\": return "\\\\"; 
    }
    return strMatch;
}
/// </method>


/// <method name="Aux_DecodeText">
/// <summary>
/// Decode an encoded text.
/// </summary>
/// <remarks>
/// The methods decodes a text value that was encoded to prevent data loss when using
/// attributes. This allows to use attributes for text values without loosing information
/// due to xml attribute normalization.
/// </remarks>
/// <param name="strText"></param>
function Aux_DecodeText(strText, blnDecodeAsHtml)
{
    if (!Aux_IsNullOrEmpty(strText))
    {
        var objFunction;
        if(blnDecodeAsHtml)
        {
            objFunction = Aux_HtmlDecodeMatch;
        }
        else
        {
            objFunction = Aux_TextDecodeMatch;
        }

        return strText.replace(/(\\\\)|(\\s)|(\\t)|(\\n)|(\\r)|(\\b)/gm, objFunction);
    }
    else
    {
        return strText;
    }
}
/// </method>


/// <method name="Aux_TextDecodeMatch"  access="private">
/// <summary>
/// Decodes a specific match
/// </summary>
/// <param name="strMatch">The current match to get its replacing value.</param>
function Aux_TextDecodeMatch(strMatch)
{
    switch(strMatch)
    {
        case "\\b": return " "; 
        case "\\t": return "\t"; 
        case "\\n": return "\n"; 
        case "\\r": return ""; 
        case "\\\\": return "\\"; 
    }
    return strMatch;
}
/// </method>

/// <method name="Aux_HtmlDecodeMatch"  access="private">
/// <summary>
/// Decodes a specific match
/// </summary>
/// <param name="strMatch">The current match to get its replacing value.</param>
function Aux_HtmlDecodeMatch(strMatch)
{
    switch(strMatch)
    {
        case "\\b": return String.fromCharCode(160);
        case "\\t": return String.fromCharCode(160,160,160,160);
        case "\\n": return "<br/>"; 
        case "\\r": return ""; 
        case "\\\\": return "\\"; 
    }
    return strMatch;
}
/// </method>

/// <method name="Aux_IsCharacterKeyCode">
/// <summary>
/// Checks if a given key code is a charecter.
/// </summary>
/// <param name="intKeyCode">The key code to be checked.</param>
function Aux_IsCharacterKeyCode(intKeyCode)
{
    // Use upper case for letter key code validation as it is the only correct codes range.
    return Aux_IsDigitKeyCode(intKeyCode, false) || Aux_IsLetterKeyCode(intKeyCode, 2) || [32, 106, 107, 109, 110, 111].contains(intKeyCode) || (intKeyCode >= 186 && intKeyCode <= 192) || (intKeyCode >= 219 && intKeyCode <= 222);  
}
/// </method>

/// <method name="Aux_GenerateGuid"  access="private">
/// <summary>
/// Generates guid string.
/// </summary>
function Aux_GenerateGuid()
{
    var s = [];
    var hexDigits = "0123456789abcdef";
    for (var i = 0; i < 36; i++)
    {
        s[i] = hexDigits.substr(Math.floor(Math.random() * 0x10), 1);
    }
    s[14] = "4";  // bits 12-15 of the time_hi_and_version field to 0010
    s[19] = hexDigits.substr((s[19] & 0x3) | 0x8, 1);  // bits 6-7 of the clock_seq_hi_and_reserved to 01
    s[8] = s[13] = s[18] = s[23] = "-";

    var uuid = s.join("");
    return uuid;
}
/// </method>

/// </page>

