<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true"  CodeBehind="Consulta_Acompanhamento.aspx.cs" Inherits="SAUP.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">

<center>
 <asp:Panel id="painel_avaliacao" 
        GroupingText="Busca de Acompanhamentos por Paciente" runat="server" 
          Wrap="False">
        <%--Pagina foi renomeada--%>
      
       <asp:DropDownList ID="DropDownListConsultaAvaliacao" runat="server" 
           onprerender="DropDownListConsultaAvaliacao_PreRender" AutoPostBack="True">
              <asp:ListItem Text="Nome" Value="Nome"></asp:ListItem>
              <asp:ListItem Text="RG" Value="RG"></asp:ListItem>
              <asp:ListItem Text="CPF" Value="CPF"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBoxFiltroAvalicao" runat="server">
        </asp:TextBox>
        <asp:Button ID="ButtonBuscarAvaliacao" runat="server" Text="Buscar" 
           onclick="ButtonBuscarAvaliacao_Click1"  />
             <asp:Button ID="InserirAvaliacao" runat="server"   
            Text="Inserir Acompanhamento" Visible="true" onclick="InserirAvaliacao_Click" />
        <br />
       <asp:RegularExpressionValidator ID="RequireValidatorFiltroAcompanhamento" runat="server" 
           ControlToValidate="TextBoxFiltroAvalicao"
            ForeColor="Red"  ></asp:RegularExpressionValidator>
        
        <h2>Resultados  da Busca</h2>
        <hr/>
     <asp:GridView ID="GridViewResultadosAcompanhamento" runat="server" 
           DataKeyNames ="ID_ACOMPANHAMENTO" EnablePersistedSelection="True"
           SelectedRowStyle-BackColor="#99FF66" AutoGenerateSelectButton="True" 
           onrowcommand="grid_resultado_busca_avaliacao_RowCommand" 
           AutoGenerateColumns="False" >
           
         <Columns>
             <asp:ButtonField ButtonType="Button" CommandName="Editar" 
                 Text="Atualizar Acompanhamento" />
             <asp:BoundField DataField="ID_ACOMPANHAMENTO" 
                 HeaderText="Código Acompanhamento" />
             <asp:BoundField DataField="NOME" HeaderText="Nome" />
             <asp:BoundField DataField="DATAREALIZACAO" HeaderText="Data Realização" />
             <asp:BoundField DataField="STATUS_ACOMPANHAMENTO_DESCRICAO" 
                 HeaderText="Status Acompanhamento" />
         </Columns>

     <SelectedRowStyle BackColor="#CCFF99" />
     </asp:GridView>
        <br />
        <br />
        <hr />
        
       <br />
     <asp:Label ID="Label_Pesquisa"  runat="server" 
           Visible="False"></asp:Label>
         
    </asp:Panel></center>
    <asp:Button ID="ButtonCancelar" runat="server" 
        Text="Retornar ao menu principal" 
       onclick="ButtonCancelar_Click" CausesValidation="False" />
</asp:Content>
