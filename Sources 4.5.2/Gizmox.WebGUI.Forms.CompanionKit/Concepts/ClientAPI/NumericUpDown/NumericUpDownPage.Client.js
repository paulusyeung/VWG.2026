/// <method name="onNUDValueChanged" access="private">
/// <summary>
/// Changes label text to show current value of NumericUpDown
/// </summary>
function onNUDValueChanged() {

    //Get client NumericUpDown
    var objNumericUpDown = vwgContext.provider.getComponentByClientId("nud");

    //Get client label
    var objInfoLabel = vwgContext.provider.getComponentByClientId("info");

    //Changes label text to show current value of NumericUpDown
    objInfoLabel.text("value: "+objNumericUpDown.value());
    objInfoLabel.update();

}
/// </method>

/// <method name="onListBoxSelectedChanged" access="private">
/// <summary>
/// Sets NumericUpDown value according to currently selected item in ListBox, changes label text
/// </summary>
function onListBoxSelectedChanged() {

    //Get client NumericUpDown
    var objNumericUpDown = vwgContext.provider.getComponentByClientId("nud");

    //Get client label
    var objInfoLabel = vwgContext.provider.getComponentByClientId("info");

    //Get client ListBox
    var objListBox = vwgContext.provider.getComponentByClientId("lb");

    //Sets NumericUpDown value according to currently selected item in ListBox
    objNumericUpDown.value(""+(parseInt(objListBox.selectedIndex(), 10) + 1));
    objNumericUpDown.update();

    //Changes label text to show current value of NumericUpDown
    objInfoLabel.text("value: " + objNumericUpDown.value());
    objInfoLabel.update();
}
/// </method>