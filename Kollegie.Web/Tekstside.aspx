﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Tekstside" ValidateRequest="false" Codebehind="Tekstside.aspx.cs" %>

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

    function format_text(type, name) {
        document.getElementById(name).focus();
        document.execCommand(type);
    }

    function format_text_new(type, name) {
        var sText = document.selection.createRange();
        if (sText.text != "") {
            document.getElementById(name).focus();
            document.execCommand(type);
        }
        else {
            alert("Please select some text!");
        }
    }

    function ItalicText() {
        var range = window.getSelection().getRangeAt(0);
        var temp = document.createElement("i");
        temp.innerHTML = range.toString();
        range.deleteContents();
        range.insertNode(temp);
    }
    function UnderlineText() {
        var range = window.getSelection().getRangeAt(0);
        var temp = document.createElement("u");
        temp.innerHTML = range.toString();
        range.deleteContents();
        range.insertNode(temp);
    }
//-->
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

		<asp:PlaceHolder runat="server" ID="ContentPlaceHolder" />

</asp:Content>

