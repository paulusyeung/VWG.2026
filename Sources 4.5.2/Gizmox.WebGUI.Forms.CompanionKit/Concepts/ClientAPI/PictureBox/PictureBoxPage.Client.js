/// <method name="onSelectedChanged" access="private">
/// <summary>
/// Change imageUrl according to selectedIndex in ListBox
/// </summary>
function onSelectedChanged() {

    //Get client ListBox
    var objListBox = vwgContext.provider.getComponentByClientId("lb");

    //Get client PictureBox
    var objPictureBox = vwgContext.provider.getComponentByClientId("pb");

    //Change imageUrl according to selectedIndex in ListBox
    objPictureBox.imageUrl("Images." + objListBox.dataSource()[objListBox.selectedIndex()].text + ".jpg.wgx")
    objPictureBox.update();

}
/// </method>