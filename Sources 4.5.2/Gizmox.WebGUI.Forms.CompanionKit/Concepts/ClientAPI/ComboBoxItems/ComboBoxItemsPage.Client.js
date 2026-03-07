/// <method name="addItem" access="private">
/// <summary>
/// Adds item after "add" button clicking
/// </summary>
function addItem() {

    //Get client ComboBox
    var objComboBox = vwgContext.provider.getComponentByClientId("cb");

    //Get client page
    var objForm = vwgContext.provider.getComponentByClientId("uc");

    //Get client TextBox
    var objNewItemTextBox = vwgContext.provider.getComponentByClientId("tb");

    //Get the text of a new item
    var strNewItemText = objNewItemTextBox.text(); 

    //Get ComboBox's DataSource
    var objDataSource = objComboBox.dataSource();

    //Adds a new item in the end of ComboBox's DataSource
    objDataSource.push({ text: strNewItemText });
    objComboBox.dataSource(objDataSource);
    if (objDataSource.length == 1) {
        objComboBox.selectedIndex(0);
        selectedChanged();
    }
    objComboBox.update();
   
    //Updates new items' TextBox text
    objNewItemTextBox.text("new item");
    objNewItemTextBox.update();

    //Creating and filling attributes
    var objAttributes = {};
    objAttributes.text = strNewItemText;

    //Creating, registering and raising event which adds item on server
    vwgContext.events.performClientEvent(objForm.id(), "addItemOnServer", objAttributes, true);
    vwgContext.events.raiseEvents();

}
/// </method>

/// <method name="removeItem" access="private">
/// <summary>
/// Removes item after "remove" button clicking
/// </summary>
function removeItem() {

    //Get client ComboBox
    var objComboBox = vwgContext.provider.getComponentByClientId("cb");

    //Get client page
    var objForm = vwgContext.provider.getComponentByClientId("uc");

    //Get ComboBox's DataSource
    var objDataSource = objComboBox.dataSource();
    var objCurrentSelected = objComboBox.selectedIndex();

    //Creating, registering and raising event which removes item on server
    vwgContext.events.performClientEvent(objForm.id(), "removeItemOnServer", { index: objCurrentSelected }, true);
    vwgContext.events.raiseEvents();

    //Removes item from data source with index=objCurrentSelected
    objDataSource.splice(objCurrentSelected, 1); 
    objComboBox.dataSource(objDataSource);
 
    //If the first item is deleting
    if (objCurrentSelected == 0) {
        objComboBox.selectedIndex(0);
    }
    else {
        objComboBox.selectedIndex(objCurrentSelected - 1);
    }

    //Updates selected index label's text
    selectedChanged();
    objComboBox.update();    

}
/// </method>

/// <method name="selectedChanged" access="private">
/// <summary>
/// Updates selected item in combobox
/// </summary>
function selectedChanged() {

    //Get client ComboBox
    var objComboBox = vwgContext.provider.getComponentByClientId("cb");

    //Get client selected index Label
    var objSelectedIndexLabel = vwgContext.provider.getComponentByClientId("lblSelectedIndex");

    //Change selected index Label's text
    objSelectedIndexLabel.text("Selected index: " + objComboBox.selectedIndex());
    objSelectedIndexLabel.update();

}
/// </method>
