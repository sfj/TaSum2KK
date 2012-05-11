<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpretRedigerBoligControl.ascx.cs"
    Inherits="Kollegie.Web.Controls.OpretRedigerBoligControl" %>
<table class="oprettable" runat="server" id="OpretRedigerTable"> 
    <tr>
        <td>
            Afdeling:<br />
            <select id="departments" name="departments" runat="server">
            </select>
            <br />
            Område:<br />
            <input type="text" name="area" id="area" runat="server" /><br />
            Kvm:<br />
            <input type="text" name="surfacearea" id="surfacearea" runat="server" /><br />
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
            Beskrivelse (dansk):<br />
            <textarea name="description_dk" class="rediger" runat="server" id="description_dk"></textarea><br />
            Beskrivelse (engelsk):<br />
            <textarea name="description_en" class="rediger" id="description_en" runat="server"></textarea><br />
        </td>
    </tr>
</table>
<table id="SletBoligTable" class="boliger" runat="server">
    <tr>
        <td valign="top" class="housephoto">
            <img src="http://ungdomsboligaarhus.dk/web/512/ktp.nsf/Pics/AFD53532.JPG/$File/AFD53532.JPG?OpenElement"
                height="180" width="220" />
        </td>
        <td width="125">
            <span class="bold">Pris pr. måned:</span><br />
            <asp:Label runat="server" ID="MonthlyPriceLabel" />
            kr<br />
            <br />
            <span class="bold">A/C udgifter:</span><br />
            <asp:Label runat="server" ID="ACExpensesLabel" />
            kr<br />
            <br />
            <span class="bold">Samlet:</span><br />
            <asp:Label runat="server" ID="TotalLabel" />
            kr<br />
            <br />
            <span class="bold">Depositum:</span><br />
            <asp:Label runat="server" ID="DepositLabel" />
            kr<br />
            <br />
            <span class="bold">Ventetid:</span><br />
            <asp:Label runat="server" ID="DerpLabel" /><br />
            <br />
        </td>
        <td valign="top">
            <asp:Label runat="server" ID="DescriptionLabel" /><br />
            <br />
            <span class="bold">Afdeling:</span><br />
            <asp:Label runat="server" ID="DepartmentLabel" />
        </td>
        <td valign="top">
            Område:<br />
            <asp:Label runat="server" ID="AreaLabel" />
        </td>
    </tr>
</table>
<asp:Button runat="server" ID="derp" Text="Gem" OnClick="derp_OnClick" CssClass="button" />
