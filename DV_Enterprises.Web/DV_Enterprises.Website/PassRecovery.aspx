<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="PassRecovery.aspx.cs" Inherits="PassRecoveryPage" Title="Recover Password &mdash; Smart Greenhouse Solutions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="grid_16">
   <h4 class ="title">
       <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
       </asp:PasswordRecovery>
   </h4>
</div>
</asp:Content>

