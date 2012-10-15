<%@ Page Title="" Language="C#" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true"
    CodeBehind="groupsedit.aspx.cs" Inherits="NetTelco.NetTelcoAuth.groupsedit" ViewStateMode="Enabled" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="AccessGroupNameLabel" runat="server" Text="Системное название" CssClass="bold"
                    ForeColor="#333333"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="AccessGroupNameTextBox" runat="server" Style="background-color: #FFCCCC"
                    TabIndex="1" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="AccessGroupLabelLabel" runat="server" Text="Название" CssClass="bold"
                    ForeColor="#333333"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="AccessGroupLabelTextBox" runat="server" Style="background-color: #FFCCCC"
                    TabIndex="1" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="AccessGroupDescriptionLabel" runat="server" Text="Описание" CssClass="bold"
                    ForeColor="#333333"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="AccessGroupDescriptionTextBox" runat="server" Height="75px" Style="background-color: #CCFFCC"
                    TextMode="MultiLine" TabIndex="2" Width="180px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="AddAccessGroupButton" runat="server" Text="Создать группу" OnClick="AddAccessGroupButton_Click"
                    TabIndex="3" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="AccessGroupsGridView" runat="server" CellPadding="4" DataSourceID="AccessGroupsEDS"
        ForeColor="#333333" GridLines="None" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ACCESSGROUP_ID" HeaderText="ID" SortExpression="ID"/>
            <asp:BoundField DataField="NAME" HeaderText="Системное название" SortExpression="NAME" />
            <asp:BoundField DataField="LABEL" HeaderText="Название" SortExpression="LABEL" />
            <asp:BoundField DataField="DESCRIPTION" HeaderText="Описание" SortExpression="DESCRIPTION" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:EntityDataSource ID="AccessGroupsEDS" runat="server" ConnectionString="name=SecurityDBEntities"
        DefaultContainerName="SecurityDBEntities" EnableFlattening="False" EntitySetName="AccessGroups"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True">
        <DeleteParameters>
        
        </DeleteParameters>
    </asp:EntityDataSource>
</asp:Content>
