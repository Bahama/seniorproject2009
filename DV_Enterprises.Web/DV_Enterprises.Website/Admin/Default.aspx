<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Smart Greenhouse Solutions Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="title grid_16">Smart Greenhouse Solutions Administration</h2>
    <div class="users">
        <h3 class="title grid_16">Users</h3>
        <div class="grid_8">
            <p>In order to display all users whose name begin with letter click on link letter</p>
            <asp:Repeater ID="rptAlphabet" runat="server" 
                onitemcommand="rptAlphabet_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lbutLetter" runat="server" CommandArgument="<%# Container.DataItem %>"
                        Text="<%# Container.DataItem %>">
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="grid_8">
            <p>Use the following to search users by partial username or email:</p>
            <asp:DropDownList ID="ddlUserSearchTypes" runat="server">
                <asp:ListItem>UserName</asp:ListItem>
                <asp:ListItem>E-mail</asp:ListItem>
            </asp:DropDownList>
            contains
            <asp:TextBox ID="txtUserSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnUserSearch" runat="server" Text="Search" onclick="btnUserSearch_Click" />
        </div>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" 
            CssClass="grid_16" onrowdatabound="gvUsers_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Username">
                    <ItemTemplate>
                        <asp:Literal ID="litUserName" runat="server" Text='<%# Bind("UserName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Literal ID="litName" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Email" HeaderText="E-Mail" DataFormatString="&lt;a href=mailto:{0}&gt;{0}&lt;a&gt;" HtmlEncode="false" />
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Literal ID="litAddress" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Literal ID="litPhone" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEdit" runat="server" Text="Details" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No users found.
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>