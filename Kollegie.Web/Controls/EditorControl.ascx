<%@ Control Language="C#" AutoEventWireup="false" Inherits="EditorControl" Codebehind="EditorControl.ascx.cs" %>

<asp:HiddenField runat="server" ID="EditorValue" />
<img onclick="BoldText();" src="fed.png" class="Format_Button" alt="Bold" id="Button_Bold" />
<div contenteditable="true" class="editing_box" runat="server" id="Editor"></div>
<asp:Button runat="server" id="SubmitButton" Text="Gem" OnClick="SubmitButton_Click" />