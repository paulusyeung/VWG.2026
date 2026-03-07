/// <method name="changeSize" access="private">
/// <summary>
/// Check which key was pressed and change width or height of TextBox accordingly
/// </summary>
function MyTextBox_changeSize(objEventArgs, clientId) {

    // Prevent symbol to appear in textbox.
    Web_PreventDefault(objEventArgs);

    //IE8 support
    var intCharCode = Web_GetEventKeyCode(objEventArgs);

    //Get client TextBox
    var objTextBox = vwgContext.provider.getComponentById(clientId);

    //If 'A' key is pressed and width is not minimal
    if ((intCharCode == 97) && (objTextBox.width() > 85)) {
        
        objTextBox.width(objTextBox.width() - 5);
    }
    //If 'W' key is pressedand height is not maximal
    else if ((intCharCode == 119) && (objTextBox.height() < 235)) {
        objTextBox.height(objTextBox.height() + 5);
    }
    //If 'D' key is pressed and width is not maximal
    else if ((intCharCode == 100) && (objTextBox.width() < 500)) {
        objTextBox.width(objTextBox.width() + 5);
    }
    //If 'S' key is pressed and height is not minimal
    else if ((intCharCode == 115) && (objTextBox.height() > 20)) {
        objTextBox.height(objTextBox.height() - 5);
    }

    //Set textBox text to the current size
    objTextBox.text(" W: " + objTextBox.width() + " H: " + objTextBox.height());
    objTextBox.update();

    //Move focus on TextBox
    objTextBox.focus();
}
/// </method>
