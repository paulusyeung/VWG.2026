/// <method name="CustomAnchorListBox_ChangeAnchor" access="private">
/// <summary>
/// Changes control's anchor 
/// </summary>
function CustomAnchorListBox_ChangeAnchor(objEventArgs, strId) {
    //Getting instance of listBox by Id
    var objListBox = vwgContext.provider.getComponentById(strId);
    //Creating empty array 
    var objArray = [];
    //Getting current anchor's values
    var objAnchor = objListBox.anchor();
    switch (objEventArgs.keyCode) {
        // left arrow  
        case 37:
            objAnchor.left = !objAnchor.left;
            break;
        // up arrow  
        case 38:
            objAnchor.top = !objAnchor.top;
            break;
        // right arrow  
        case 39:
            objAnchor.right = !objAnchor.right;
            break;
        // down arrow  
        case 40:
            objAnchor.bottom = !objAnchor.bottom;
            break;
    }

    //Adding items to source array
    objArray.push({ text: "left: " + objAnchor.left });
    objArray.push({ text: "right: " + objAnchor.right });
    objArray.push({ text: "top: " + objAnchor.top });
    objArray.push({ text: "bottom: " + objAnchor.bottom });

    //Setting data source
    objListBox.dataSource(objArray);
    //Setting anchor
    objListBox.anchor(objAnchor);
    //Updating and focusing control 
    objListBox.update();
    objListBox.focus();
}
/// </method>