<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuPunktControl.ascx.cs" Inherits="Kollegie.Web.Controls.MenuPunktControl" %>

<td class="menupunkt" id="mp" runat="server">
    <a href="" class="menu_link" id="Link" runat="server" />
    <div class="dd_div" id="dd" runat="server">
        <table class="dropdown" cellpadding="0" cellspacing="0">
            <asp:PlaceHolder runat="server" ID="sub" />
        </table>
    </div>
</td>