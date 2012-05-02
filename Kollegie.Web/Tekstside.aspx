<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Tekstside" ValidateRequest="false" Codebehind="Tekstside.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript" >
<!--
    function BoldText() {        
        var sel = document.getElementById('Editor').selection;
        if (sel != null) {
            alert("Hej");
            var rng = sel.createRange();
            if (rng != null) {
                rng.pasteHTML("<b>" + rng + "</b>");
            }
        }
    }
//-->
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

		<asp:PlaceHolder runat="server" ID="ContentPlaceHolder" />
		<asp:Label runat="server" ID="ContentLabel"></asp:Label>

</asp:Content>

