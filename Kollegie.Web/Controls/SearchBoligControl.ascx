﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/Controls/SearchBoligControl.ascx.cs"
    Inherits="Kollegie.Web.Controls.SearchBoligControl" %>
<table class="oprettable" runat="server" id="OpretRedigerTable"> 
    <tr>
        <td>
            Afdelinger:
            <select id="departments" name="departments" runat="server" multiple="multiple">
            </select>
            Område:<br />
            <select id="Select1" name="departments" runat="server" multiple="multiple">
            </select><br />
            Kvm:<br />
            <input type="text" name="surfacearea" id="surfacearea" runat="server" /><br />
            Fritekst:<br />
            <textarea name="description_dk" runat="server" id="description_dk" rows="5"></textarea><br />
        </td>
        <td>
            Antal værelser:<br />
            <input type="text" name="rooms" id="rooms" runat="server" /><br />
            Antal personer:<br />
            <select id="Select2" name="departments" runat="server">
            <option>1</option>
            <option>2</option>
            </select><br />
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
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button runat="server" ID="derp" Text="Gem" OnClick="derp_OnClick" CssClass="button" />
        </td>
    </tr>
</table>