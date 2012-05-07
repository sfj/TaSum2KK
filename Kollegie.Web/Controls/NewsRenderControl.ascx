<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsRenderControl.ascx.cs" Inherits="Kollegie.Web.Controls.RenderControl" %>

<tr>
    <td class="overskrift_container">
        <label class="overskrift" runat="server" id="overskrift"></label>
    </td>
    <td class="overskrift_container_button">
        <asp:Button runat="server" Text="X" ID="DeleteButton" OnClick="DeleteButtonClick" Visible="false" CssClass="button" />
        <asp:Button runat="server" Text="Rediger" ID="EditButton" OnClick="EditButtonClick" Visible="false" CssClass="button" />
    </td>
</tr>
<tr>
    <td colspan="2" class="broedtekst_container">
        <label class="broedtekst" runat="server" id="broedtekst"></label>
    </td>
</tr>