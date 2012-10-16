<%@ Page Title="" Language="C#" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true" CodeBehind="Auth.aspx.cs" Inherits="NetTelco.NetTelcoAuth.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <p>
    Вход в систему
    <asp:Label ID="LoginErrorLabel" runat="server" Visible="False"></asp:Label>
</p>
<p>
    Учетное имя
    <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
</p>
<p>
    Пароль
    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:CheckBox ID="RememberCheckBox" runat="server" />
</p>
<p>
    <asp:Button ID="Button1" runat="server" Text="Вход в систему" 
        onclick="Button1_Click" />
</p>


</asp:Content>
