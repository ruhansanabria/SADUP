<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Consulta_Tratamento.aspx.cs" Inherits="SAUP.Consulta_Tratamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">
<center>
    <asp:Panel id="painel_busca_tratamento" GroupingText="Busca de Tratamento por Paciente" runat="server">
        <asp:DropDownList ID="DropDownListTrat" runat="server" AutoPostBack="True" onprerender="DropDownListTrat_PreRender" >
             <asp:ListItem Value="Descrição Tratamento">Descrição</asp:ListItem>
             <asp:ListItem Value="Tipo Tratamento">Tipo Tratamento</asp:ListItem>
             <asp:ListItem  Value="Periodicidade">Periodicidade</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBoxFiltro" runat="server">
        </asp:TextBox>
        <asp:Button ID="ButtonTrat0" runat="server" OnClick="ButtonTrat_Click" 
            Text="Buscar" />
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBoxFiltro" ErrorMessage="RegularExpressionValidator" 
            ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        <h2>Resultados  da Busca</h2>
        <hr />

        <asp:GridView runat="server" ToolTip="Resultados da Busca" 
            ID="grid_resultado_busca_Tratamento" BorderColor="#009900" 
            BorderStyle="Dashed" Caption="Resultados da Busca" CellSpacing="20" 
            HorizontalAlign="Center" PageIndex="2" EnablePersistedSelection="True" 
            DataKeyNames="ID_TRATAMENTO"      
            AutoGenerateColumns="False" 
            onselectedindexchanged="grid_resultado_busca_Tratamento_SelectedIndexChanged">
            <Columns>
            <asp:CommandField ShowSelectButton="true" SelectText="Selecionar" ButtonType="Button"/>
                
                <asp:BoundField HeaderText="Codigo Tratamento" DataField="ID_TRATAMENTO" Visible="false" />
                <asp:BoundField HeaderText="Descrição Tratamento" DataField="DESCRICAOTRATAMENTO" />
                <asp:BoundField HeaderText="Tipo do Tratamento" DataField="CLASSIFICACAO" />
                <asp:BoundField HeaderText="Periodicidade" DataField="PERIODICIDADE" />
            </Columns>
            
            <SelectedRowStyle BackColor="#CCFF99" />
        </asp:GridView>
        <br />
        <br />
        <hr />
   
        <br />
        <h2>Procedimentos Vinculados ao Tratamento Selecionado</h2>
        <asp:Label ID="Label_Pesquisa" runat="server" Text="Digite um valor correto" Visible="false"></asp:Label>
        <asp:GridView ID="GridViewProcedimentosVinculados" runat="server">
            <EmptyDataTemplate>
                Nenhum procedimento vinculado ao tratamento selecionado
            </EmptyDataTemplate>
        </asp:GridView>
        
        <hr />
        <h2>Produtos Vinculados ao Tratamento Selecionado</h2>
        <asp:GridView ID="GridViewProdutosVinculados" runat="server">
        <EmptyDataTemplate>
                Nenhum produto vinculado ao tratamento selecionado
            </EmptyDataTemplate>
        </asp:GridView>
        

    </asp:Panel></center>
      <center><asp:Button ID="ButtonManter" runat="server" Text="Vincular Tratamentos" 
              onclick="ButtonManter_Click" /></center> 
    <asp:Button ID="ButtonRetornar" runat="server" Text="Retornar ao menu principal" PostBackUrl="~/Monitoramento/Monitoramento.aspx" />

 

</asp:Content>
