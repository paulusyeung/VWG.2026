

/// <method name="TextBox_GetNormalizedValue">
/// <summary>
/// Replace a string \r\n with only \n
/// </summary>
/// <param name="strValue">TextBox value</param>
function TextBox_GetNormalizedValue(strValue)
{
    if(strValue != null)
    {
        // Replaces new lines.
        strValue = strValue.replace(/\r\n/g,"\n");
        
        // Replaces the problematic 0x01 character.
        strValue = strValue.replace(String.fromCharCode(0x01), "");
    }
    
    return strValue;
}
/// </method>
