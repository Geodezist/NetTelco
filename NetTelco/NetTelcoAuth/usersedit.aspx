<%@ Page Title="" Language="C#" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true" CodeBehind="usersedit.aspx.cs" Inherits="NetTelco.NetTelcoAuth.usersedit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:GridView ID="UsersEditGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        AllowSorting="True" CellPadding="4" DataSourceID="UsersEDS" 
        ForeColor="#333333" GridLines="None" DataKeyNames="USER_ID" 
        SelectedIndex="0">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />

            <asp:BoundField DataField="LAST_NAME" HeaderText="Фамилия" SortExpression="LAST_MANE" />
            <asp:BoundField DataField="FIRST_NAME" HeaderText="Имя" SortExpression="FIRST_NAME" />
            <asp:BoundField DataField="MIDDLE_NAME" HeaderText="Отчество" SortExpression="MIDDLE_NAME" />
            <asp:BoundField DataField="LOGIN" HeaderText="Логин" SortExpression="LOGIN" />
            <asp:BoundField DataField="EMAIL" HeaderText="Email" SortExpression="EMAIL" />
            <asp:CheckBoxField DataField="IS_ADMIN" HeaderText="Администратор" />
            <asp:CheckBoxField DataField="IS_ACTIVATED" HeaderText="Активный" />
            <asp:CheckBoxField DataField="IS_LOCKED_OUT" HeaderText="Блокирован" />
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
    <br />
    <br />
    <br />
    <asp:DetailsView ID="UsersDetailGridView" runat="server" CellPadding="4" AutoGenerateRows="False"
        DataSourceID="UsersDetailEDS" DataKeyNames="USER_ID"
        ForeColor="#333333" GridLines="None" Height="50px" 
        Width="125px"
        OnItemCommand="NewUserCommand" 
        OnItemCreated="UsersDetailGridView_ItemCreated">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:TemplateField HeaderText="Фамилия">
                <ItemTemplate>
                    <%#Eval("LAST_NAME")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="LAST_NAMETextBox" runat="server" Text='<%#Eval("LAST_NAME")%>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Имя">
                <ItemTemplate>
                    <%#Eval("FIRST_NAME")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="FIRST_NAMETextBox" runat="server" Text='<%#Eval("FIRST_NAME")%>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Отчество">
                <ItemTemplate>
                    <%#Eval("MIDDLE_NAME")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="MIDDLE_NAMETextBox" runat="server" Text='<%#Eval("MIDDLE_NAME")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Логин">
                <ItemTemplate>
                    <%#Eval("LOGIN")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="LOGINTextBox" runat="server" Text='<%#Eval("LOGIN")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Пароль">
                <EditItemTemplate>
                    <asp:TextBox ID="PASSWORDTextBox" runat="server"/>
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Пароль (еще раз)">
                <EditItemTemplate>
                    <asp:TextBox ID="PASSWORDChekTextBox" runat="server"/>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <%#Eval("EMAIL")%>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="EMAILTextBox" runat="server" Text='<%#Eval("EMAIL")%>' />
                </EditItemTemplate>
            </asp:TemplateField>         
            
            <asp:TemplateField HeaderText="Администратор">
                <ItemTemplate>
                    <asp:CheckBox runat="server" Checked='<%#Eval("IS_ADMIN")%>' Enabled="false"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="IS_ADMINCheckBox" runat="server" Checked='<%#Eval("IS_ADMIN")%>'/>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:CheckBox ID="IS_ADMINInsertCheckBox" runat="server" Checked='false'/>
                </InsertItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Активный">
                <ItemTemplate>
                    <asp:CheckBox runat="server" Checked='<%#Eval("IS_ACTIVATED")%>' Enabled="false"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="IS_ACTIVATEDCheckBox" runat="server" Checked='<%#Eval("IS_ACTIVATED")%>'/>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:CheckBox ID="IS_ACTIVATEDInsertCheckBox" runat="server" Checked='false'/>
                </InsertItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Блокирован">
                <ItemTemplate>
                    <asp:CheckBox runat="server" Checked='<%#Eval("IS_LOCKED_OUT")%>' Enabled="false"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="IS_LOCKED_OUTCheckBox" runat="server" Checked='<%#Eval("IS_LOCKED_OUT")%>'/>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:CheckBox ID="IS_LOCKED_OUTInsertCheckBox" runat="server" Checked='false'/>
                </InsertItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:Button ID="EditStartButton" CommandName="Edit" runat="server" Text="Изменить"/>
                    <asp:Button ID="InsertStartButton" CommandName="New" runat="server" Text="Создать"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="EditSaveButton" CommandName="Update" runat="server" Text="Сохранить"/>
                    <asp:Button ID="CancelEditButton" CommandName="Cancel" runat="server" Text="Отменить"/>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:Button ID="InsertSaveButton" CommandName="InsertNewUser" runat="server" Text="Сохранить"/>
                    <asp:Button ID="CancelInsertButton" CommandName="Cancel" runat="server" Text="Отменить"/>
                </InsertItemTemplate>
            </asp:TemplateField>
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
    <br />
    <br />
    <asp:EntityDataSource ID="UsersEDS" runat="server" 
        ConnectionString="name=SecurityDBEntities" 
        DefaultContainerName="SecurityDBEntities" EnableDelete="True" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Users" EntityTypeFilter="Users"
        OrderBy="it.[LAST_NAME]">
    </asp:EntityDataSource>
    <br />
    <asp:EntityDataSource ID="UsersDetailEDS" runat="server" 
        ConnectionString="name=SecurityDBEntities" 
        DefaultContainerName="SecurityDBEntities" EnableFlattening="False" EnableUpdate="True" 
        EntitySetName="Users"
        Where="it.[USER_ID] = @parUSER_ID" EntityTypeFilter="Users">
        <WhereParameters>
            <asp:ControlParameter Name="parUSER_ID" ControlID="UsersEditGridView" 
                Type="Int32" DefaultValue="0" PropertyName="SelectedValue"/>
        </WhereParameters>
    </asp:EntityDataSource>
    </asp:Content>
