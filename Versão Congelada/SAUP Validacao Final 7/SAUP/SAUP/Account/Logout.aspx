<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="SAUP.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Logout_Page" ContentPlaceHolderID="Conteudo_Master" runat="server">
<div class="loginDisplay">
<asp:Label ID="Mensagem_Logout" Text="Voce saiu do sistema clique no link abaixo para logar novamente" runat="server">
</asp:Label>
</br>

<asp:HyperLink ID="Logout_retornar_Login" Text="Clique aqui para retornar a página de Login" NavigateUrl="~/Account/Login.aspx" runat="server">Clique aqui para retornar</asp:HyperLink>
</div>
</asp:Content>
