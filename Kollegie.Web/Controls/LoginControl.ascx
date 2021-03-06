﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="Kollegie.Web.Controls.LoginControl" %>

<table cellpadding="0" cellspacing="0" runat="server" id="LoginTable">
    <tr>
        <td class="left"></td>
        <td class="logintext">Login:</td>
		<td class="loginuser"><asp:TextBox ID="userlogin" CssClass="inputfield" AutoPostBack="True" runat="server"></asp:TextBox></td>
		<td class="loginpass"><asp:TextBox ID="userpass" CssClass="inputfield" AutoPostBack="True" runat="server" TextMode="Password"></asp:TextBox></td>
		<td class="loginbutton"><asp:Button ID="loginbutton" Text="Login" runat="server" CssClass="button" /></td>
		<td class="right"></td>
	</tr>
</table>
<table cellpadding="0" cellspacing="0" runat="server" id="LogoutTable">
    <tr>
    <td class="loggedin_left"></td>
    <td class="loggedin_logintext"><label runat="server" id="LoginText" /></td>
    <td class="loginbutton"><asp:Button ID="logoutbutton" Text="Logout" runat="server" CssClass="button" OnClick="LogoutButtonClick" /></td>
    <td class="loggedin_right"></td>
    </tr>
</table>