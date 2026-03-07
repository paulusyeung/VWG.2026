/// <method name="printRootNodesInfo" access="private">
/// <summary>
/// Prints info about all root nodes in textBox
/// </summary>
function printRootNodesInfo() {
    //Getting instances of components
    var objTreeView = vwgContext.provider.getComponentByClientId("treeView");
    var objTextBox = vwgContext.provider.getComponentByClientId("textBox");

    //Declaration of string variable of output data
    var strOutputData = "";

    //Putting nodes array into variable
    var objNodes = objTreeView.nodes();

    //Gets information about all nodes
    for (var i = 0; i < objNodes.length; i++) {
        strOutputData += "[" + i + "] - item, has child(s):" + ((objNodes[i].nodes().length > 0) ? ("true, count:" + objNodes[i].nodes().length) : "false") + "\r\n";
    }

    //Represents result it textBox
    objTextBox.text(strOutputData);
    objTextBox.update();
}
/// </method>