/// <method name="CustomFocusableTextBox_FocusControl" access="private">
/// <summary>
/// Focusing control
/// </summary>
function CustomFocusableTextBox_FocusControl(strId) {
    //Getting control's object
    var objControl = vwgContext.provider.getComponentById(strId);
    //Get control focused
    objControl.focus();
}
/// </method>