/// <method name="compareParents" access="private">
/// <summary>
/// Compares controls's parents and shows result on a label 
/// </summary>
function compareParents() {
    //Getting controls objects
    var objFirstComboBox = vwgContext.provider.getComponentByClientId("firstCombo");
    var objSecondComboBox = vwgContext.provider.getComponentByClientId("secondCombo");
    var objStateLabel = vwgContext.provider.getComponentByClientId("state");
    //Defining empty array
    var objControlArray = [];
    //Filling array with labels
    for (var i = 0; i < 6; i++) {
        var objLabel = vwgContext.provider.getComponentByClientId("label" + (i + 1));
        objControlArray[i] = objLabel;
    }
        //Getting two comparable controls
        var objFirstControl = getControlByText(objFirstComboBox.text(),objControlArray);
        var objSecondControl = getControlByText(objSecondComboBox.text(), objControlArray);
        //Comparing controls and representing result 
        var strState = objFirstControl.parent().id() == objSecondControl.parent().id();
        objStateLabel.text(strState.toString());
        objStateLabel.update();
    }
/// </method>

/// <method name="getControlByText" access="private">
/// <summary>
/// Returns control which contains defined text
/// </summary>
function getControlByText(strText, objControlArray) {
    for (var i = 0; i < objControlArray.length; i++) {
        if (objControlArray[i].text() == strText) {
            return objControlArray[i];
        }
    }
}
/// </method>