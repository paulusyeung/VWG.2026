/// <method name="changeStyle" access="private">
/// <summary>
/// Changes button's style according to selected option
/// </summary>
function changeStyle() {
    //Getting objects of components using static vwgProvider class
    var objButton = vwgContext.provider.getComponentByClientId("button");

    // Putting string value of button's type, depending on which radiobutton is checked;  "N" - normal style, "F" - flat style
    var strStyle = objButton.text() == "Normal" ? "N" : "F";

    //Applying selected style, "ES" - CustomStyle attribute
    objButton.property("ES", strStyle);
    objButton.update();
}
/// </method>

/// <method name="printProperties" access="private">
/// <summary>
/// Prints button's properties info to textBox 
/// </summary>
function printProperties() {
    //Creating array with key-value pair, where Key - property name, Value - string value of VWG attribute abbreviation 
    var objPropertyArray = { Height: "H", Width: "W", Text: "TX", Anchor: "A", ClientId: "CID" };

    //Getting objects of Button and Textbox classes using static vwgProvider class
    var objButton = vwgContext.provider.getComponentByClientId("button");
    var objTextBox = vwgContext.provider.getComponentByClientId("text");

    //Creating output string variable and filling it with Id
    var strOutputData = "Id:" + objButton.id() + "\r\n";

    //Putting info to output string about properties, which are contained in array
    for (strPropertyName in objPropertyArray) {
       strOutputData += strPropertyName + ":" + objButton.property(objPropertyArray[strPropertyName]) + "\r\n";
    }

    //Representing output string in textBox
    objTextBox.text(strOutputData);
    objTextBox.update();
}
/// </method>