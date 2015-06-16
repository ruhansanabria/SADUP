<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Manter_Tratamento.aspx.cs" Inherits="SAUP.Manter_Tratamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">
<h1>Informações do  Tratamento</h1><br />
<hr />
  
      <asp:GridView ID="GridViewTipoTrat" runat="server" 
        DataSourceID="ObjectDataSourceTratamento"
        AutoGenerateColumns="False" DataKeyNames="id_tratamento">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="DESCRICAOTRATAMENTO" 
                HeaderText="Descrição Tratamento" />
            <asp:BoundField DataField="PERIODICIDADE" HeaderText="Periodicidade" />
        </Columns>
        <SelectedRowStyle BackColor="#CCFF99" />
        
    </asp:GridView>
    <br />
    <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="A seleção do Tramento é Obrigatoria"
        Visible="False"></asp:Label>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSourceTratamento" runat="server" SelectMethod="retorna_Todos_Tratamentos"
        TypeName="SAUP.Control.TratamentoBC"></asp:ObjectDataSource>
    <br />
    <hr />
    <h3>
        Vincule os produtos ao tratamento selecionado na listagem abaixo</h3>
    <asp:GridView ID="GridViewProdutos" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceProdutos"
        DataKeyNames="ID_PRODUTO">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox_ProductSelection" runat="server" Checked="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID_PRODUTO" HeaderText="Codigo Produto" Visible="false" />
            <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" />
            <asp:BoundField DataField="UNIDADE" HeaderText="Unidade" />
        </Columns>
        <SelectedRowStyle BackColor="#CCFF99" />
    </asp:GridView>
    <br />
    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="A seleção de Algum produto é Obrigatoria"
        Visible="False"></asp:Label>
    <asp:ObjectDataSource ID="ObjectDataSourceProdutos" runat="server" SelectMethod="consultar_Produto"
        TypeName="SAUP.Control.ProdutoBC"></asp:ObjectDataSource>
    <br />
    <hr />
    <h3>
        Vincule os procedimentos ao tratamento selecionado na listagem abaixo</h3>
    <asp:GridView ID="GridViewProcedimentos" runat="server" AutoGenerateColumns="False"
        DataSourceID="ObjectDataSourceProcedimento" DataKeyNames="ID_PROCEDIMENTO">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox_ProcedimentoSelection" runat="server" Checked="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID_PROCEDIMENTO" Visible="false" />
            <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição Procedimento" />
        </Columns>
        <SelectedRowStyle BackColor="#CCFF99" />
    </asp:GridView>
    <br />
    <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="A selecione um Procedimento"
        Visible="False"></asp:Label>
    <asp:ObjectDataSource ID="ObjectDataSourceProcedimento" runat="server" SelectMethod="retorna_Todos_Procedimentos"
        TypeName="SAUP.Control.ProcedimentoBC"></asp:ObjectDataSource>
    <center>
        
        <!-- Button Salvar ficara visible pois somente Enfermeiro administrativo pode inserir-->
        <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" OnClick="Button_Salvar_Click"
            Visible="true" />
        <asp:Button ID="ButtonInserir" runat="server" Text="Inserir" Visible="false" />
        <asp:Label ID="LabelMensagem" runat="server" Text="" Visible="false"></asp:Label>
    </center>
    <asp:Button ID="ButtonMenuPrincipal" runat="server" Text="Retornar ao Menu Principal"
        Height="20px" OnClick="ButtonMenuPrincipal_Click" />
</asp:Content>
