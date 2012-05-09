<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Forside" Codebehind="Forside.aspx.cs"  ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="NewsTable" cellpadding="0" cellspacing="0">
        <asp:PlaceHolder ID="NewsContent" runat="server"></asp:PlaceHolder>
    </table>
</asp:Content>