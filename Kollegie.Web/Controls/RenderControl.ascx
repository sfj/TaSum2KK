﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RenderControl.ascx.cs" Inherits="Kollegie.Web.Controls.RenderControl" %>

<tr><td><label class="overskrift" runat="server" id="overskrift"></label></td><td><asp:Button runat="server" Text="Rediger" ID="EditButton" OnClick="EditButtonClick" Visible="false" /></td></tr>
<tr><td><label class="broedtekst" runat="server" id="broedtekst"></label></td></tr>