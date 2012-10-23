<%@ Page Title="" Language="C#" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true"
    CodeBehind="usersedit_telerik.aspx.cs" Inherits="NetTelco.NetTelcoAuth.usersedit_telerik" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>

    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="UsersEditGridView">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="UsersEditGridView" />
                <telerik:AjaxUpdatedControl ControlID="AllowedGroups" />
                <telerik:AjaxUpdatedControl ControlID="NotAllowedGroups" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="AllowedGroups">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="AllowedGroups" />
                <telerik:AjaxUpdatedControl ControlID="NotAllowedGroups" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="NotAllowedGroups">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="AllowedGroups" />
                <telerik:AjaxUpdatedControl ControlID="NotAllowedGroups" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadGrid ID="UsersEditGridView" runat="server" CellSpacing="0" Culture="ru-RU"
        DataSourceID="UsersEDS" GridLines="None" AllowPaging="True" AllowSorting="True"
        GroupingEnabled="False" OnDeleteCommand="DeleteUser">
        <ClientSettings EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="True" CellSelectionMode="SingleCell" EnableDragToSelectRows="False" />
            <Scrolling AllowScroll="true" UseStaticHeaders="true"></Scrolling>
        </ClientSettings>
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="USER_ID" DataSourceID="UsersEDS">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridButtonColumn ConfirmText="Ай ай ай!,Точно удалять пользователя?" ConfirmDialogType="RadWindow" ConfirmTitle="Внимание УДАЛЕНИЕ!" ConfirmDialogHeight="100px" ConfirmDialogWidth="220px"
                    CommandName="Delete" Text="X" UniqueName="column" >
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn DataField="USER_ID" DataType="System.Int64" FilterControlAltText="Filter USER_ID column"
                    HeaderText="USER_ID" ReadOnly="True" SortExpression="USER_ID" UniqueName="USER_ID" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FIRST_NAME" FilterControlAltText="Filter FIRST_NAME column"
                    HeaderText="FIRST_NAME" SortExpression="FIRST_NAME" UniqueName="FIRST_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_NAME" FilterControlAltText="Filter LAST_NAME column"
                    HeaderText="LAST_NAME" SortExpression="LAST_NAME" UniqueName="LAST_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MIDDLE_NAME" FilterControlAltText="Filter MIDDLE_NAME column"
                    HeaderText="MIDDLE_NAME" SortExpression="MIDDLE_NAME" UniqueName="MIDDLE_NAME">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LOGIN" FilterControlAltText="Filter LOGIN column"
                    HeaderText="LOGIN" SortExpression="LOGIN" UniqueName="LOGIN">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PASSWORD" FilterControlAltText="Filter PASSWORD column"
                    HeaderText="PASSWORD" SortExpression="PASSWORD" UniqueName="PASSWORD">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PASSWORD_SALT" FilterControlAltText="Filter PASSWORD_SALT column"
                    HeaderText="PASSWORD_SALT" SortExpression="PASSWORD_SALT" UniqueName="PASSWORD_SALT">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMAIL" FilterControlAltText="Filter EMAIL column"
                    HeaderText="EMAIL" SortExpression="EMAIL" UniqueName="EMAIL">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CREATE_DATE" DataType="System.DateTime" FilterControlAltText="Filter CREATE_DATE column"
                    HeaderText="CREATE_DATE" SortExpression="CREATE_DATE" UniqueName="CREATE_DATE">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_MODIFIED_DATE" DataType="System.DateTime"
                    FilterControlAltText="Filter LAST_MODIFIED_DATE column" HeaderText="LAST_MODIFIED_DATE"
                    SortExpression="LAST_MODIFIED_DATE" UniqueName="LAST_MODIFIED_DATE">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_LOGIN_DATE" DataType="System.DateTime" FilterControlAltText="Filter LAST_LOGIN_DATE column"
                    HeaderText="LAST_LOGIN_DATE" SortExpression="LAST_LOGIN_DATE" UniqueName="LAST_LOGIN_DATE">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_LOGIN_IP" FilterControlAltText="Filter LAST_LOGIN_IP column"
                    HeaderText="LAST_LOGIN_IP" SortExpression="LAST_LOGIN_IP" UniqueName="LAST_LOGIN_IP">
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="IS_ACTIVATED" DataType="System.Boolean" FilterControlAltText="Filter IS_ACTIVATED column"
                    HeaderText="IS_ACTIVATED" SortExpression="IS_ACTIVATED" UniqueName="IS_ACTIVATED">
                </telerik:GridCheckBoxColumn>
                <telerik:GridCheckBoxColumn DataField="IS_LOCKED_OUT" DataType="System.Boolean" FilterControlAltText="Filter IS_LOCKED_OUT column"
                    HeaderText="IS_LOCKED_OUT" SortExpression="IS_LOCKED_OUT" UniqueName="IS_LOCKED_OUT">
                </telerik:GridCheckBoxColumn>
                <telerik:GridBoundColumn DataField="LAST_LOCKED_OUT_DATE" DataType="System.DateTime"
                    FilterControlAltText="Filter LAST_LOCKED_OUT_DATE column" HeaderText="LAST_LOCKED_OUT_DATE"
                    SortExpression="LAST_LOCKED_OUT_DATE" UniqueName="LAST_LOCKED_OUT_DATE">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LAST_LOCKED_OUT_REASON" FilterControlAltText="Filter LAST_LOCKED_OUT_REASON column"
                    HeaderText="LAST_LOCKED_OUT_REASON" SortExpression="LAST_LOCKED_OUT_REASON" UniqueName="LAST_LOCKED_OUT_REASON">
                </telerik:GridBoundColumn>
                <telerik:GridCheckBoxColumn DataField="IS_ADMIN" DataType="System.Boolean" FilterControlAltText="Filter IS_ADMIN column"
                    HeaderText="IS_ADMIN" SortExpression="IS_ADMIN" UniqueName="IS_ADMIN">
                </telerik:GridCheckBoxColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
            <PagerStyle AlwaysVisible="True" />
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>


    <table>
        <tr>
            <td valign="top">
                <telerik:RadListBox ID="AllowedGroups" runat="server" AutoPostBack="True" 
                    Culture="ru-RU" DataSourceID="UserAllowedGroupsEDS"
                    Height="200px" Width="300px" DataTextField="NAME" DataValueField="ACCESSGROUP_ID"
                    AllowTransfer="True" TransferToID="NotAllowedGroups"
                    AllowTransferOnDoubleClick="True" EnableDragAndDrop="True"
                    AutoPostBackOnTransfer="true" ondeleting="AllowedGroups_Deleting" 
                    oninserting="AllowedGroups_Inserting">
                </telerik:RadListBox>
            </td>
            <td valign="top">
                <telerik:RadListBox ID="NotAllowedGroups" runat="server"
                    Culture="ru-RU" DataSourceID="UserNotAllowedGroupsEDS"
                    Height="200px" Width="300px" DataTextField="NAME" DataValueField="ACCESSGROUP_ID"
                    AllowTransferOnDoubleClick="True" EnableDragAndDrop="True">
                </telerik:RadListBox>
            </td>
        </tr>
    </table>


    <asp:EntityDataSource ID="UsersEDS" runat="server" ConnectionString="name=SecurityDBEntities"
        DefaultContainerName="SecurityDBEntities" EnableFlattening="False" EntitySetName="Users">
    </asp:EntityDataSource>

    <asp:EntityDataSource ID="UserAllowedGroupsEDS" runat="server" ConnectionString="name=SecurityDBEntities"
        DefaultContainerName="SecurityDBEntities" EnableFlattening="False" CommandText="select
                       it.[UIAG_ID] as ACCESSGROUP_ID,
                       g.[NAME] as NAME
                     from SecurityDBEntities.UsersInAccessGroups as it 
                     inner join SecurityDBEntities.AccessGroups as g on g.[ACCESSGROUP_ID]=it.[ACCESSGROUP_ID]
                     where it.[USER_ID] = @parUSER_ID">
        <CommandParameters>
            <asp:ControlParameter Name="parUSER_ID" ControlID="UsersEditGridView" Type="Int32"
                DefaultValue="0" PropertyName="SelectedValue" />
        </CommandParameters>
    </asp:EntityDataSource>

    <asp:EntityDataSource ID="UserNotAllowedGroupsEDS" runat="server" ConnectionString="name=SecurityDBEntities"
        DefaultContainerName="SecurityDBEntities" EnableFlattening="False" CommandText="select
                       it.[ACCESSGROUP_ID] as ACCESSGROUP_ID,
                       it.[NAME] as NAME
                     from SecurityDBEntities.AccessGroups as it
                     left join SecurityDBEntities.UsersInAccessGroups as g on g.[USER_ID] = @parUSER_ID and g.[ACCESSGROUP_ID] = it.[ACCESSGROUP_ID]
                     where g.[UIAG_ID] is null">
        <CommandParameters>
            <asp:ControlParameter Name="parUSER_ID" ControlID="UsersEditGridView" Type="Int32"
                DefaultValue="0" PropertyName="SelectedValue" />
        </CommandParameters>
    </asp:EntityDataSource>

    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>

</asp:Content>
