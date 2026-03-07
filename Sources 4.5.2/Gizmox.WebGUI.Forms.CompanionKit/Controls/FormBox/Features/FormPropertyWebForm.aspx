<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPropertyWebForm.aspx.cs" Inherits="Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features.FormPropertyWebForm" %>

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
        Select Form to show whithin the FormBox: 
        <asp:DropDownList ID="ddlForm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlForm_SelectedIndexChanged">
            <asp:ListItem Value="FormPropertyForm1">Form1</asp:ListItem>
            <asp:ListItem Value="FormPropertyForm2">Form2</asp:ListItem>
        </asp:DropDownList>
    </div>    
    <div style="padding-top:5px">
        <cc1:FormBox ID="FormBox1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Height="200px" Width="550px" />
    </div>
    </form>
</body>
</html>
