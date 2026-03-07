
function vwgTreeView(objNode)
{
    vwgControl.call(this, objNode);
}

var objBaseTreeView = new vwgControl();
vwgTreeView.prototype = objBaseTreeView;
vwgTreeView.prototype.constructor = objBaseTreeView;

/// <method name="typeName">
/// <summary>
/// Gets the type of the object.
/// </summary>
vwgTreeView.prototype.typeName = function ()
{
    return "TreeView";
};

/// <method name="nodes">
/// <summary>
/// Gets the nodes of the control.
/// </summary>
vwgTreeView.prototype.nodes = function ()
{
    var objNodes = TreeView_GetTreeNodes(this.objNode);
    return objNodes;
};


function vwgTreeViewNode(objNode)
{
    vwgComponent.call(this, objNode);
}

var objBaseTreeViewNode = new vwgComponent();
vwgTreeViewNode.prototype = objBaseTreeViewNode;
vwgTreeViewNode.prototype.constructor = objBaseTreeViewNode;

vwgTreeViewNode.prototype.nodes = function ()
{
    var objNodes = TreeView_GetTreeNodes(this.objNode);
    return objNodes;
};

/// <method name="text">
/// <summary>
/// Gets and sets the text of the treeView node.
/// </summary>
vwgTreeViewNode.prototype.text = function (strValue)
{
    if (strValue == undefined)
    {
        return Xml_GetAttribute(this.objNode, "Attr.Text");
    }

    Xml_SetAttribute(this.objNode, "Attr.Text", strValue ? strValue : "");
};
/// </method>

function TreeView_GetTreeNodes(objNode)
{
    // Get child tree nodes
    var arrTreeNodeNodes = Xml_SelectNodes("TN", objNode);

    // Return array of ClientDom elements initialized with provided nodes.
    var arrTreeNodes = [];
    for (var i = 0; i < arrTreeNodeNodes.length; i++)
    {
        var objTreeNodeNode = arrTreeNodeNodes[i];
        var objTreeNode = new vwgTreeViewNode(objTreeNodeNode);
        arrTreeNodes.push(objTreeNode);
    }

    return arrTreeNodes;
}