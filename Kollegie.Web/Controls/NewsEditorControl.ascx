<%@ Control Language="C#" AutoEventWireup="false" Inherits="NewsEditorControl" Codebehind="NewsEditorControl.ascx.cs" %>

<tr>
    <td class="overskrift_container">
        <textarea class="editing_box_head" rows="1" cols="80" id="NewsEditorHead" runat="server"></textarea>
    </td>
    <td class="overskrift_container_button">
        <asp:Button runat="server" id="SubmitButton" Text="Gem" OnClick="SubmitButtonClick" CssClass="button" />
    </td>
        <td class="overskrift_container_button">
        <asp:Button runat="server" id="HideButton" Text="Gem" OnClick="HideButtonClick" CssClass="button" />
    </td>
</tr>
<tr>
    <td colspan="2" class="broedtekst_container">
        <textarea class="editing_box" rows="7" cols="80" id="NewsEditor" runat="server"></textarea>
    </td>
</tr>