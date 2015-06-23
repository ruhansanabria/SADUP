<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SAUP.Login" ClientIDMode="Inherit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>             
<center><h2>Gerenciamento da conta</h2></center>
   <center> <p>
        Por favor entre com seu usuário e senha .Qualquer problema contate o administrador de acessos do SAUP.</p>
        
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Informações do usuário</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="Nome de  usuário é obrigatório." ToolTip="Nome de  usuário é obrigatório" 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Senha é obrigatória." ToolTip="Senha é obrigatória" 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>

                </fieldset>
               
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                        ValidationGroup="LoginUserValidationGroup" 
                        style="height: 26px" 
                        onclick="LoginButton_Logar" />
                        
                </p>
            </div></center>

     
        <asp:Label ID="LabelMensagem" runat="server" Text="Label"></asp:Label>
  
    
</body>
</html>
</asp:Content>
