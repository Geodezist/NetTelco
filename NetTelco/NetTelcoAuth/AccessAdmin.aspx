<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccessAdmin.aspx.cs" Inherits="NetTelco.NetTelcoAuth.AccessAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;Имя -
        <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
        <br />
        Фамилия&nbsp; -
        <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
        <br />
        Отчество&nbsp; -
        <asp:TextBox ID="MiddleNameTextBox" runat="server"></asp:TextBox>
        <br />
        Учетное имя&nbsp; -
        <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
        <br />
        Пароль&nbsp; -
        <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="CreateUserButton" runat="server" Text="Создать" 
            onclick="CreateUserButton_Click" />
    
    </div>
    </form>
</body>
</html>
