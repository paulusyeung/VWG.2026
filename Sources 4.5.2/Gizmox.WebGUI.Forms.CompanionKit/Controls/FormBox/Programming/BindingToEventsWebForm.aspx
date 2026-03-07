<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BindingToEventsWebForm.aspx.cs"
    Inherits="Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Programming.BindingToEventsWebForm" %>

<%@ Register Assembly="Gizmox.WebGUI.Forms, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d"
    Namespace="Gizmox.WebGUI.Forms.Hosts" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript">
    
        // Function that is bind to Button click event
        function AddItem(){
            
            var itemName = document.getElementById('tbItemName').value;
            
            if(itemName != ''){
                // Get FormBox object
                var objFormBox = document.getElementById('FormBox1');
                // Get window object that contains FormBox
                var objWindow = objFormBox.contentWindow;
                // Perform custom function
                objWindow.AddItemToList(itemName);
                return;
            }
            
            // Show alert when itemName is empty
            alert("Please enter Item Name!");
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <center>
            This is ASP.NET WebForm Page</center>
        <br />
        <div>
            <table cellpadding="5">
                <tr>
                    <td>
                        <cc1:FormBox ID="FormBox1" runat="server" BorderColor="Black" BorderStyle="Solid"
                            BorderWidth="1px" Height="220px" Width="300px" Form="BindingToEventsForm" />
                    </td>
                    <td valign="top">
                        Item Name:
                        <input id="tbItemName" type="text" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid" /><input id="btnAddItem" type="button" value="Add Item"
                            onclick="AddItem();" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
