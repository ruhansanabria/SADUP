<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Manter_Produto.aspx.cs" Inherits="SAUP.Manter_Produto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">

<span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
<asp:ValidationSummary ID="ValidationSummaryPaciente" runat="server"  ValidationGroup="Produto" CssClass="failureNotification"/>
   <center><h1>Produtos</h1>
       <p>
           <asp:LinkButton ID="Cadastrolink" runat="server" onclick="Cadastrolink_Click" 
               Visible="False">Para cadastrar um produto Clique Aqui.</asp:LinkButton>
       </p></center><br />
    <center>
        <asp:GridView ID="GridViewProdutos" runat="server" AutoGenerateColumns="False"
            DataSourceID="ObjectDataSourceProduto" DataKeyNames="ID_PRODUTO" 
            EnablePersistedSelection="True" onrowcommand="GridViewProdutos_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:BoundField DataField="ID_PRODUTO" HeaderText="Código" />
                <asp:BoundField DataField="DESCRICAO" HeaderText="DESCRIÇÃO" />
                <asp:BoundField DataField="UNIDADE" HeaderText="UNIDADE" />
            </Columns>
            <SelectedRowStyle BackColor="#CCFF99" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceProduto" runat="server" 
            SelectMethod="consultar_Produto" TypeName="SAUP.Control.ProdutoBC">
        </asp:ObjectDataSource>
        <br />
        <br />
        </center> 
    <br />
    <center>
        <asp:Label ID="descprocedimento" runat="server" Text="Descrição do Produto" 
        AssociatedControlID="DescProduto"></asp:Label>
    <br />
    <asp:TextBox ID="DescProduto" runat="server" Height="24px" Width="420px" 
            MaxLength="100"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescricaoPro" runat="server" 
        ErrorMessage="Descrição do Produto é obrigatória" ControlToValidate="DescProduto" CssClass="failureNotification" ValidationGroup="Produto"></asp:RequiredFieldValidator>
            </center> 
    <br />
    <center>
        <asp:Label ID="FatorUnidade" runat="server" 
        Text="Unidade" AssociatedControlID="IdentificadorDescricao"></asp:Label>
        <br />
   <asp:TextBox ID="IdentificadorDescricao" runat="server" Height="21px" Width="241px" 
            MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUnidade" runat="server" 
        ErrorMessage="Unidade do Produto é obrigatória-Ex:Litros/Unidade/Pacote" CssClass="failureNotification" ControlToValidate="IdentificadorDescricao" ValidationGroup="Produto"></asp:RequiredFieldValidator>
    <br />
    </center>
    &nbsp;<br />
    <br />
    <center>
        
    &nbsp;<asp:Button ID="Gravar" runat="server" Text="Cadastrar" Width="76px" 
            onclick="Gravar_Click" ValidationGroup="Produto"/>&nbsp;<asp:Button ID="Editar" runat="server" 
            onclick="Editar_Click" Text="Salvar" ValidationGroup="Produto" Visible="False" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Alerta" Visible="False"></asp:Label>
    </center>
    <asp:Button ID="MenuPrincipal" runat="server" Text="Retornar ao Menu Principal" 
        Height="24px" onclick="MenuPrincipal_Click" />
    <br />
</asp:Content>
