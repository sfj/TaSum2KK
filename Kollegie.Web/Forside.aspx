<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Forside" Codebehind="Forside.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="NewsTable">
        <asp:PlaceHolder ID="NewsContent" runat="server"></asp:PlaceHolder>
    </table>
</asp:Content>