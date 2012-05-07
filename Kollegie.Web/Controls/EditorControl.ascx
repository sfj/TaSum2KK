<%@ Control Language="C#" AutoEventWireup="false" Inherits="EditorControl" Codebehind="EditorControl.ascx.cs" %>

<asp:HiddenField runat="server" ID="EditorValue" />
<div class="overskrift_container">
    <img onclick="format_text_new('Bold', 'Button_Bold');" src="img/fed.png" class="format_button" alt="Bold" id="Button_Bold" /> 
    <img onclick="format_text_new('Italic', 'Button_Bold');" src="img/kursiv.png" class="format_button" alt="Italic" id="Button_Italic" /> 
    <img onclick="format_text_new('Underline', 'Button_Bold');" src="img/underline.png" class="format_button" alt="Underline" id="Button_Underline" />
    <asp:Button runat="server" id="SubmitButton" Text="Gem" OnClick="SubmitButton_Click" CssClass="button" />
</div>
<div contenteditable="true" class="editing_box" runat="server" id="Editor"></div>