/// <method name="addItem" access="private">
/// <summary>
/// Adds new item to ListView 
/// </summary>
function addItem() {

    //Get client page
    var objForm = vwgContext.provider.getComponentByClientId("uc");

    //Get client ListView
    var objListView = vwgContext.provider.getComponentByClientId("lw");
    var objLength = 0;
    
    //If ListView items collection is not empty
    if (objListView.items()) {

        //Define length of ListView items collection
        objLength = objListView.items().length; 
        
    }    

    //Add new item in the end of current array
    fillListView.objItemsArray.push({ "col1": "item" + (objLength + 1)});//, "col2": "subitem" + (objLength + 1) });

    //Set new array to ListView's dataSource
    objListView.dataSource(fillListView.objItemsArray);
    objListView.update();

    //Creating, registering and raising event which adds listView item on server
    vwgContext.events.performClientEvent(objForm.id(), "addItemOnServer", { text: "item" + (objLength + 1) }, true);
    vwgContext.events.raiseEvents();

}
/// </method>

/// <method name="removeItem" access="private">
/// <summary>
/// Removes last item from ListView 
/// </summary>
function removeItem() {

    //Get client page
    var objForm = vwgContext.provider.getComponentByClientId("uc");

    //Get client ListView
    var objListView = vwgContext.provider.getComponentByClientId("lw");

    //Remove one item from the end of array
    fillListView.objItemsArray.pop();

    //Set new array to ListView's dataSource
    objListView.dataSource(fillListView.objItemsArray);
    objListView.update();

    //Creating, registering and raising event which removes listView item on server
    vwgContext.events.performClientEvent(objForm.id(), "removeItemOnServer", "", true);
    vwgContext.events.raiseEvents();


}
/// </method>

/// <method name="removeAllFromListView" access="private">
/// <summary>
/// Removes all items from ListView
/// </summary>
function removeAllFromListView() {

    //Get client Label and reset it's text
    var objLabel = vwgContext.provider.getComponentByClientId("lbl");
    objLabel.text("--");
    objLabel.update();

    //Get client page
    var objForm = vwgContext.provider.getComponentByClientId("uc");

    //Get client ListView
    var objListView = vwgContext.provider.getComponentByClientId("lw");

    //Get items array of ListView
    var objListViewItems = objListView.items();

    //Set ListView's dataSource to an empty array
    objListView.dataSource([]);
    objListView.update();
    
    //Alert how many items were removed
    alert(objListViewItems.length + " items removed");

    //Set ListView items array to an empty array
    fillListView.objItemsArray = [];

    //Creating, registering and raising event which removes all listView items on server
    vwgContext.events.performClientEvent(objForm.id(), "removeAllOnServer", "", true);
    vwgContext.events.raiseEvents();

}
/// </method>

/// <method name="fillListView" access="private">
/// <summary>
/// Fills ListView with default data source
/// </summary>
function fillListView() {

    //Get client Label and reset it's text
    var objLabel = vwgContext.provider.getComponentByClientId("lbl");
    objLabel.text("--");
    objLabel.update();

    //Get client page
    var objForm = vwgContext.provider.getComponentByClientId("uc");

    //Get client ListView
    var objListView = vwgContext.provider.getComponentByClientId("lw");

    //Create new array
    var objSource = [];

    //Fill data source array with 5 items
    for (var i = 0; i < 5; i++) {
        objSource.push({ "col1": "item"+(i+1), "col2": "subitem"+(i+1)});
    }

    //Set ListView's dataSource to filled array
    objListView.dataSource(objSource);
    objListView.update();

    //Set ListView items array to the added default data source
    fillListView.objItemsArray = objSource;

    //Creating, registering and raising event which fills listView on server
    vwgContext.events.performClientEvent(objForm.id(), "fillOnServer", "", true);
    vwgContext.events.raiseEvents();

}
/// </method>

/// <method name="showSelectedItems" access="private">
/// <summary>
/// Update Label's text to show number of currently selected items or number of subItems, if there is 1 item selected
/// </summary>
function showSelectedItems() {

    //Get client ListView
    var objListView = vwgContext.provider.getComponentByClientId("lw");
    //Get client Label
    var objLabel = vwgContext.provider.getComponentByClientId("lbl");
    //Define selected items array
    var objSelectedItemsArray = objListView.selectedItems();

    //if there are more than 1 item selected
    if (objSelectedItemsArray.length > 1) {

        //Set Label's text to number of selected items
        objLabel.text("Selected: " + objSelectedItemsArray.length + " items");

    } 

    //If there is 1 item selected
    else if (objSelectedItemsArray.length === 1) {

        //Define subItems of selected item
        var objSubItems = objSelectedItemsArray[0].subItems();

        //If selected item has only 1 subitem
        if (objSubItems.length===1) {
            //Set Label's text to the text of selected item's subitem
            objLabel.text("Item has 1 subitem: " + objSubItems[0].text());
        }
        //If selected item has 0 or more than 1 subitems
        else {
            //Set Label's text to number of subItems of selected item
            objLabel.text("Item has " + objSubItems.length + " subitems");
        }

    }

    objLabel.update();

}
/// </method>