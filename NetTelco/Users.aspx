<%@ Page Title="" Language="C#" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true"
    CodeBehind="Users.aspx.cs" Inherits="NetTelco.Users" EnableTheming="true" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="UserGrid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        DataKeyNames="USER_ID" CellPadding="4" ForeColor="#333333" OnRowCommand="userGrid_RowCommand"
        OnRowEditing="userGrid_RowEditing" OnRowUpdating="userGrid_RowUpdating" OnRowCancelingEdit="userGrid_RowCancelingEdit"
        OnRowDeleting="userGrid_RowDeleting">
        <AlternatingRowStyle BackColor="Red" />
        <Columns>
            <asp:TemplateField HeaderText="Учетно имя" SortExpression="LOGIN">
                <ItemTemplate>
                    <%#Eval("LOGIN")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="UpdateLOGINTextBox" runat="server" Text='<%#Eval("LOGIN")%>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="NewLOGINTextBox" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Пароль" SortExpression="PASSWORD">
                <ItemTemplate>
                    <%#Eval("PASSWORD")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="UpdatePASSWORDTextBox" runat="server" Text='<%#Eval("PASSWORD")%>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="NewPASSWORDTextBox" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Фамилия" SortExpression="LAST_NAME">
                <ItemTemplate>
                    <%#Eval("LAST_NAME")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="UpdateLAST_NAMETextBox" runat="server" Text='<%#Eval("LAST_NAME")%>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="NewLAST_NAMETextBox" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Имя" SortExpression="FIRST_NAME">
                <ItemTemplate>
                    <%#Eval("FIRST_NAME")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="UpdateFIRST_NAMETextBox" runat="server" Text='<%#Eval("FIRST_NAME")%>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="NewFIRST_NAMETextBox" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Отчество" SortExpression="MIDDLE_NAME">
                <ItemTemplate>
                    <%#Eval("MIDDLE_NAME")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="UpdateMIDDLE_NAMETextBox" runat="server" Text='<%#Eval("MIDDLE_NAME")%>' />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="NewMIDDLE_NAMETextBox" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Действия">
                <ItemTemplate>
                    <asp:Button ID="RowEditButton" runat="server" CommandName="Edit" Text="Изменить" />
                    <asp:Button ID="RowDeleteButton" runat="server" CommandName="Delete" Text="Удалить" />
                    <asp:CheckBox ID="RowSelectCheckBox" runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="RowEditSaveButton" runat="server" CommandName="Update" Text="Сохранить" />
                    <asp:Button ID="RowEditCancelButton" runat="server" CommandName="Cancel" Text="Отменить" SkinID="CancelButtonSkin"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="RowNewSaveButton" runat="server" CommandName="Insert" Text="Добавить" />
                    <asp:Button ID="RowNewCancelButton" runat="server" CommandName="InsertCancel" Text="Отменить вставку" SkinID="CancelButtonSkin"/>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="UsersDBSource" runat="server" ConflictDetection="OverwriteChanges"
        ConnectionString="<%$ ConnectionStrings:SecurityDB %>" SelectCommand="SELECT * FROM [Users]"
        DeleteCommand="DELETE FROM [Users] WHERE [USER_ID]=@USER_ID" UpdateCommand="">
        <DeleteParameters>
            <asp:Parameter Name="USER_ID" Type="Int64" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="FIRST_NAME" Type="String" />
            <asp:Parameter Name="LAST_NAME" Type="String" />
            <asp:Parameter Name="MIDDLE_NAME" Type="String" />
            <asp:Parameter Name="LOGIN" Type="String" />
            <asp:Parameter Name="USER_ID" Type="Int64" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <asp:Button ID="AddUserButton" runat="server" Text="Добавить пользователя" 
        OnClick="AddUserButton_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label">AAA</asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="UsersDBSource">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowSelectButton="True" ShowInsertButton="true" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
</asp:Content>
