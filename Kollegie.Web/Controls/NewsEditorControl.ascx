<%@ Control Language="C#" AutoEventWireup="false" Inherits="EditorControl" Codebehind="NewsEditorControl.ascx.cs" %>

<asp:HiddenField runat="server" ID="EditorValue" />
<textarea class="editing_box" rows="7" cols="80" id="NewsEditor"></textarea>
<asp:Button runat="server" id="SubmitButton" Text="Gem" OnClick="SubmitButton_Click" />