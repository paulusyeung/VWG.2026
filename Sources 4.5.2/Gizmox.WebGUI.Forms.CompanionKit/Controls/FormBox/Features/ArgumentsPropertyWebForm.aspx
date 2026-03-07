<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArgumentsPropertyWebForm.aspx.cs" Inherits="Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features.ArgumentsPropertyWebForm" %>

<%@ Register Assembly="Gizmox.WebGUI.Forms, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d"
    Namespace="Gizmox.WebGUI.Forms.Hosts" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <center>This is ASP.NET WebForm Page</center>
        <br />
        <div>
            <table cellpadding="5">
                <tr>
                    <td valign="top" align="right">
                        <div>
                            <asp:Label ID="lblColor" runat="server" Text="Color"></asp:Label>
                            <asp:DropDownList ID="ddlColor" runat="server" Width="80px">
                                <asp:ListItem>Red</asp:ListItem>
                                <asp:ListItem>Green</asp:ListItem>
                                <asp:ListItem>Blue</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="lblSize" runat="server" Text="Size"></asp:Label>
                            <asp:DropDownList ID="ddlSize" runat="server" Width="80px">
                                <asp:ListItem>Small</asp:ListItem>
                                <asp:ListItem>Medium</asp:ListItem>
                                <asp:ListItem>Large</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div>
                            <asp:Button ID="btnPass" runat="server" Text="Pass arguments" OnClick="btnPass_Click" />
                        </div>
                    </td>
                    <td valign="top">
                        <div>
                            <cc1:FormBox ID="FormBox" runat="server" Height="100px" Width="200px" BorderColor="royalBlue" BorderStyle="Solid" BorderWidth="1" Form="ArgumentsPropertyForm" Stateless="True" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
