/// <method name="setTagNames" access="private">
/// <summary>
/// Sets tagNames to checkboxes
/// </summary>
function setTagNames() {

    // Define array of checkboxes client Ids
    var objIdsArray = ["chb1", "chb2", "chb3"];

    // Define array of checked checkboxes text
    var objTagsArray = [];

    // For all checkboxes
    for (var i = 0; i < objIdsArray.length; i++) {

        // Get current client checkbox
        var objControl = vwgContext.provider.getComponentByClientId(objIdsArray[i]);

        // If checkbox is checked, add its text to objTagsArray
        if (objControl.checked() == true) {            
            objTagsArray.push({ text: objControl.text() });
        }
    }

    return objTagsArray;

}
/// </method>

/// <method name="fillListBox" access="private">
/// <summary>
/// Fills ListBox with the values of controls tagNames
/// </summary>
function fillListBox() {

    // Get client ListBox
    var objListBox = vwgContext.provider.getComponentByClientId("lbox");

    // Set dataSource of ListBox to checked checkboxes text array
    objListBox.dataSource(setTagNames());
    objListBox.update();

}
/// </method>

/// <method name="clearListBox" access="private">
/// <summary>
/// Clears ListBox
/// </summary>
function clearListBox() {

    // Get client ListBox
    var objListBox = vwgContext.provider.getComponentByClientId("lbox");

    // Set dataSource of ListBox to an empty array
    objListBox.dataSource([]);
    objListBox.update();

}
/// </method>
