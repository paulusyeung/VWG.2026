<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ResultsPropertyWebForm.aspx.cs"
    Inherits="Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features.ResultsPropertyWebForm" %>

<%@ Register Assembly="Gizmox.WebGUI.Forms, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d"
    Namespace="Gizmox.WebGUI.Forms.Hosts" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <center>This is ASP.NET WebForm Page</center>
        <br />
        <div>
            <table cellspacing="10">
                <tr>
                    <td>
                        <cc1:FormBox ID="FormBox" runat="server" Height="170px" Width="300px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Form="ResultsPropertyForm" />
                    </td>
                    <td align="right" valign="top">
                        <div>
                            <asp:Label ID="lblColor" runat="server" Text="Color:"></asp:Label>
                            <asp:TextBox ID="tbColor" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
                        </div>
                        <br />
                        <div>
                            <asp:Label ID="lblSize" runat="server" Text="Size:"></asp:Label>
                            <asp:TextBox ID="tbSize" runat="server" ReadOnly="True" Width="100px"></asp:TextBox>
                        </div>
                        <br />
                        <div>
                            <asp:Button ID="btnGetResults" runat="server" Text="Get Results" Width="150px" OnClick="btnGetResults_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
