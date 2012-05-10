﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpretRedigerBoligControl.ascx.cs"
    Inherits="Kollegie.Web.Controls.OpretRedigerBoligControl" %>
<table class="oprettable" runat="server" id="OpretRedigerTable">
    <tr>
        <td>
            <select id="departments" name="departments" runat="server">
            </select>
            Område:<br />
            <input type="text" name="area" id="area" runat="server" /><br />
            Kvm:<br />
            <input type="text" name="surfacearea" id="surfacearea" runat="server" /><br />
            Beskrivel(Dansk):<br />
            <textarea name="description_dk" runat="server" id="description_dk"></textarea><br />
            Beskrivel(Engelsk):<br />
            <textarea name="description_en" id="description_en" runat="server"></textarea><br />
        </td>
        <td>
            Antal værelse:<br />
            <input type="text" name="rooms" id="rooms" runat="server" /><br />
            Antal personer:<br />
            <input type="text" name="persons" id="persons" runat="server" /><br />
            Børn:<br />
            <input type="checkbox" name="children" id="children" runat="server" /><br />
            Antal katte:<br />
            <input type="text" name="cats" id="cats" runat="server" /><br />
            Antal hunde:<br />
            <input type="text" name="dogs" id="dogs" runat="server" /><br />
        </td>
        <td>
            Antal små kæledyr:<br />
            <input type="text" name="small_pets" id="small_pets" runat="server" /><br />
            Eget badeværelse:<br />
            <input type="checkbox" id="bath" runat="server" /><br />
            Eget køkken:<br />
            <input type="checkbox" name="kitchen" id="kitchen" runat="server" /><br />
            Husleje:<br />
            <input type="text" name="monthly_price" id="monthly_price" runat="server" /><br />
            A/C udgifter:<br />
            <input type="text" name="ac_expenses" id="ac_expenses" runat="server" /><br />
            Depositum:<br />
            <input type="text" name="deposit" id="deposit" runat="server" /><br />
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button runat="server" ID="derp" Text="Gem" OnClick="derp_OnClick" CssClass="button" />
        </td>
    </tr>
</table>