<%@ Control Language="C#" AutoEventWireup="false" Inherits="NewsEditorControl" Codebehind="NewsEditorControl.ascx.cs" %>

<tr>
    <td>
        <textarea class="editing_box_head" rows="1" cols="80" id="NewsEditorHead" runat="server"></textarea>
    </td>
    <td>
        <asp:Button runat="server" id="SubmitButton" Text="Gem" OnClick="SubmitButton_Click" />
    </td>
</tr>
<tr>
    <td colspan="2">
        <textarea class="editing_box" rows="7" cols="80" id="NewsEditor" runat="server"></textarea>
    </td>
</tr>