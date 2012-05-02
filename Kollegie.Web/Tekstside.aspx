<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Tekstside" ValidateRequest="false" Codebehind="Tekstside.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript" >
<!--
    function BoldText() {
        var range = window.getSelection().getRangeAt(0);
        var temp = document.createElement("b");
        temp.innerHTML = range.toString();
        range.deleteContents();
        range.insertNode(temp);
    }
//-->
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

		<asp:PlaceHolder runat="server" ID="ContentPlaceHolder" />
		<asp:Label runat="server" ID="ContentLabel"></asp:Label>

</asp:Content>

