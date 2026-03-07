/// <method name="TextBox_GetNormalizedValue">
/// <summary>
/// Do nothing
/// </summary>
/// <param name="strValue">TextBox value</param>
function TextBox_GetNormalizedValue(strValue)
{
    if(strValue != null)
    {
        // Replaces the problematic 0x01 character.
        strValue = strValue.replace(String.fromCharCode(0x01), "");
    }
    
    return strValue;
}
/// </method>