<%@ Page Title="" Language="C#" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true"
    CodeBehind="UsersODS.aspx.cs" Inherits="NetTelco.UsersODS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    
        <asp:GridView ID="GridView1" runat="server" 
            DataSourceID="UsersObjectDataSource" AutoGenerateColumns="False" DataKeyNames="ID">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="FIRST_NAME" HeaderText="FIRST_NAME" 
                    SortExpression="FIRST_NAME" />
                <asp:BoundField DataField="LAST_NAME" HeaderText="LAST_NAME" 
                    SortExpression="LAST_NAME" />
                <asp:BoundField DataField="MIDDLE_NAME" HeaderText="MIDDLE_NAME" 
                    SortExpression="MIDDLE_NAME" />
                <asp:BoundField DataField="LOGIN" HeaderText="LOGIN" SortExpression="LOGIN" />
                <asp:BoundField DataField="PASSWORD" HeaderText="PASSWORD" SortExpression="PASSWORD" />
            </Columns>
        </asp:GridView>
    
        <asp:ObjectDataSource ID="UsersObjectDataSource" runat="server" 
            SelectMethod="GetAllUsers"
            DeleteMethod="DeleteUserByID"
            TypeName="NetTelco.BIZ.BizUserLogic">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    
    </div>

</asp:Content>
