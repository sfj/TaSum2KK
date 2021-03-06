﻿<%@ Page Title="Boliger" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Boliger.aspx.cs" Inherits="Boliger" %>

    

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <br />
    <table class="boliger" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="4" align="right">
                <asp:Label runat="server" ID="sortby" /> &nbsp; <a href="#"><asp:Label runat="server" ID="price" /></a> &nbsp; <a href="#"><asp:Label runat="server" ID="waittime" /></a> &nbsp;
                <a href="#"><asp:Label runat="server" ID="department" /></a> &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <asp:PlaceHolder runat="server" ID="OpretTableRow"></asp:PlaceHolder>
        <asp:PlaceHolder ID="BoligContent" runat="server"></asp:PlaceHolder>
        <tr>
            <td colspan="4" align="right">
                Sorter efter: &nbsp; <a href="#">Pris</a> &nbsp; <a href="#">Ventetid</a> &nbsp;
                <a href="#">Afdeling</a> &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
