<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="Admin.User" %>
<%@ Import Namespace="DV_Enterprises.Web.Data.Domain"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid_8">
        <h2 class="title"><asp:Literal ID="litName" runat="server" /></h2>
        <dl class="table_display clearfix">
            <h3 class="title">Details</h3>
            <dt>User name:</dt>
            <dd><asp:Literal ID="litUserName" runat="server" /></dd>
            <dt>Email:</dt>
            <dd><asp:HyperLink ID="linkEmail" runat="server" /></dd>
            <dt>Address:</dt>
            <dd><asp:Literal ID="litFullAddress" runat="server" /></dd>
            <dt>Phone:</dt>
            <dd><asp:Literal ID="litPhone" runat="server" /></dd>
            <dt>Roles:</dt>
            <dd><asp:Literal ID="litRoles" runat="server" /></dd>
        </dl>
    </div>
    <div class="grid_8">
        <h2 class="title">Greenhouses</h2>
        <asp:ListView ID="lvGreenhouses" runat="server" onitemdatabound="lvGreenhouses_ItemDataBound">
            <LayoutTemplate>
                <dl class="greenhouses table_display clearfix">
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                </dl>
            </LayoutTemplate>
            
            <ItemTemplate>
                <asp:Literal ID="litGreenhouseID" runat="server" Text="<%# ((Greenhouse)Container.DataItem).ID %>" Visible="false" />
                <dt>
                    <asp:Literal ID="litGreenhouseName" runat="server" Text="<%# ((Greenhouse)Container.DataItem).ToString() %>" />
                </dt>
                <dd>
                    <asp:HyperLink ID="linkView" runat="server" Text="view" />
                </dd>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

