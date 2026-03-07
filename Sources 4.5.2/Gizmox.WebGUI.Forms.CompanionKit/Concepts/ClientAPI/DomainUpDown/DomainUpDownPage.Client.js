/// <method name="onComboBoxValueChanged" access="private">
/// <summary>
/// Changes selectedIndex for DomainUpDown according to selectedIndex in ComboBox
/// </summary>
function onComboBoxValueChanged() {

    //Get client DomainUpDown
    var objDomainUpDown = vwgContext.provider.getComponentByClientId("dud");

    //Get client ComboBox
    var objComboBox = vwgContext.provider.getComponentByClientId("cb");

    //Get client label
    var objSelectedIndexLabel = vwgContext.provider.getComponentByClientId("lbl");

    //Change seelctedIndex of DomainUpDown
    objDomainUpDown.selectedIndex(objComboBox.selectedIndex());
    objDomainUpDown.update();

    //Change label's text to show DomainUpDown's selectedIndex
    objSelectedIndexLabel.text("Selected index: " + objDomainUpDown.selectedIndex());
    objSelectedIndexLabel.update();

}
/// </method>

/// <method name="onDomainValueChanged" access="private">
/// <summary>
/// Changes label's text to show DomainUpDown's selectedIndex
/// </summary>
function onDomainValueChanged() {

    //Get client DomainUpDown
    var objDomainUpDown = vwgContext.provider.getComponentByClientId("dud");

    //Get client ComboBox
    var objComboBox = vwgContext.provider.getComponentByClientId("cb");

    //Change seelctedIndex of combobox.
    objComboBox.selectedIndex(objDomainUpDown.selectedIndex());
    objComboBox.update();

    //Get client label
    var objSelectedIndexLabel = vwgContext.provider.getComponentByClientId("lbl");

    //Change label's text to show DomainUpDown's selectedIndex
    objSelectedIndexLabel.text("Selected index: " + objDomainUpDown.selectedIndex());
    objSelectedIndexLabel.update();

}
/// </method>



