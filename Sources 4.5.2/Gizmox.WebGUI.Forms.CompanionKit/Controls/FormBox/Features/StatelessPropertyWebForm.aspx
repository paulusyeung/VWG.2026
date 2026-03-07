<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatelessPropertyWebForm.aspx.cs" Inherits="Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features.StatelessPropertyWebForm" %>

<%@ Register Assembly="Gizmox.WebGUI.Forms, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d"
    Namespace="Gizmox.WebGUI.Forms.Hosts" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET WebForm Page</title>
</head>
<body>
    <form id="form1" runat="server">    
        <center>This is ASP.NET WebForm Page</center>
        <div style="margin-left:auto; margin-right:auto;">
            <table cellpadding="5" >
                <tr>
                    <td>
                        FormBox1: Stateless = <b><%= this.FormBox1.Stateless %></b>
                        <br />
                        <cc1:FormBox ID="FormBox1" runat="server" Stateless="true" BorderWidth="1" BorderColor="RoyalBlue" BorderStyle="Solid" Height="200px" Width="200px" Form="StatelessPropertyTrueForm" />
                    </td>
                    <td>
                        FormBox2: Stateless = <b><%= this.FormBox2.Stateless %></b>
                        <br />
                        <cc1:FormBox ID="FormBox2" runat="server" Stateless="false"  BorderWidth="1" BorderColor="DarkOrange" BorderStyle="Solid" Height="200px" Width="200px" Form="StatelessPropertyFalseForm" />
                    </td>
                </tr>
            </table>            
        </div>
    </form>
</body>
</html>
