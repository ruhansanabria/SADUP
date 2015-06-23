<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Monitoramento.aspx.cs" Inherits="SAUP.Monitoramento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="MonitoramentoPage" ContentPlaceHolderID="Conteudo_Master" runat="server">
 <link href="../Styles/Monitoramento.css" rel="stylesheet" type="text/css" />
 
  <center><asp:Menu ID="Menu1" runat="server" BorderColor="#003300" CssClass="nav" 
        ForeColor="White" Orientation="Horizontal" StaticSubMenuIndent="60px" 
        Width="100%">
        <Items>
            <asp:MenuItem NavigateUrl="~/Anamnese/consulta_Anamnese.aspx" Text="Anamnese" 
                ToolTip="Gerenciar Anamneses" Value="Anamnese"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Acompanhamento/Consulta_Acompanhamento.aspx" 
                Text="Avaliação e Acompanhamento" ToolTip="Gerenciar Avaliações e Acompanhamento" Value="Avaliacao">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="../Tratamento/Consulta_Tratamento.aspx" 
                Text=" Gerenciar Tratamentos" ToolTip="Gerenciar Tratamentos" 
                Value="ManterTratamento"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/Produtos/Manter_Produto.aspx"
                Text=" Gerenciar Produtos" ToolTip="Gerenciar Produtos" Value="ManterProdutos">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="../Enfermeiro/Consulta_Enfermeiro.aspx" 
                Text="Gerenciar Enfermeiros" ToolTip="Buscar e Gerenciar Usuários" 
                Value="BuscarEnfermeiros"></asp:MenuItem>
            <asp:MenuItem Text="Gerenciar Paciente" Value="BuscarPaciente" ToolTip="Buscar e Gerenciar Pacientes" NavigateUrl="~/Paciente/Consulta_Paciente.aspx"></asp:MenuItem>
            
        </Items>
        
        
    </asp:Menu></center>
    <asp:Panel ID="PainelMonitoramento" runat="server">
    <center>
        <asp:GridView ID="GridViewMonitoramento" runat="server"  CssClass="tablestyle"  AutoGenerateColumns="False" 
            EnablePersistedSelection="True" DataKeyNames="ID_ACOMPANHAMENTO" 
            onselectedindexchanged="GridViewMonitoramento_SelectedIndexChanged" 
            onrowcommand="GridViewMonitoramento_RowCommand">
        <Columns>
            
            <asp:CommandField ShowSelectButton="True" />
              <asp:TemplateField HeaderText="Nível de Urgência">
              <HeaderTemplate>
              <p>Nível de Urgência</p>
              </HeaderTemplate>
              <ItemTemplate>
              <asp:Image ID="Semaforo" AlternateText="Sinalizador de Risco" runat="server"  ImageUrl="~/Images/redrisk.jpg"/>
              </ItemTemplate>
              </asp:TemplateField>
               <asp:TemplateField HeaderText="Situação">
              <HeaderTemplate>
              <p>Situação</p>
              </HeaderTemplate>
              <ItemTemplate>
              <asp:Label ID="LabelSituacao" runat="server" ></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
 
              
              <asp:TemplateField HeaderText="Prioridade" SortExpression="prioridade">
              <HeaderTemplate>
              
               <p>Prioridade</p>
              </HeaderTemplate>
              <ItemTemplate>
              <asp:Label ID="LabelPrioridade" runat="server" Text='<%# Eval("prioridade") %>' ></asp:Label>
              
              </ItemTemplate>
              
              </asp:TemplateField>
            
            <asp:BoundField HeaderText="Paciente" DataField="nome">
            <FooterStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Último Atendimento:" DataField="datarealizacao" 
                SortExpression="datarealizacao" />
             <asp:TemplateField HeaderText="Próximo Atendimento:" 
                SortExpression="tempo_restante">
              <HeaderTemplate>
               <p>Próximo Atendimento:</p>
              </HeaderTemplate>
              <ItemTemplate>
              <asp:Label ID="LabelProxAtendimento" runat="server" Text='<%# Eval("tempo_restante") %>' ></asp:Label>
              
              </ItemTemplate>
              </asp:TemplateField>
           
             <asp:BoundField HeaderText="Status do Acompanhamento" 
                DataField="statusacompanhamento" SortExpression="STATUSACOMPANHAMENTO" />          
             <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="ButtonAcompImagens" runat="server"  CommandName="AcompanhamentoImagem" Text="Histórico por imagens"/>
            
            </ItemTemplate>
            
            </asp:TemplateField>
        </Columns>
        
        <AlternatingRowStyle CssClass="altrowstyle" />
        <HeaderStyle CssClass="headerstyle" />
        <RowStyle CssClass="rowstyle" />
        <SelectedRowStyle BackColor="#CCFF99" />

        <EmptyDataTemplate>
        Nenhum dado a apresentar. É necessário ao menos um acompanhamento cadastrado no sistema em andamento.
        </EmptyDataTemplate>
    </asp:GridView></center>
    
   
    
    </asp:Panel>
    
     <asp:ObjectDataSource ID="ObjectDataSourceTeste" runat="server" 
        SelectMethod="get_Acompanhamentos" TypeName="SAUP.DAO.AcompanhamentoDAO"></asp:ObjectDataSource>
   
    <asp:Label ID="LabelAlert" runat="server" Text="" Visible="false"></asp:Label>
   
    <hr />

  
   

</asp:Content>
