<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="AcompanhamentoporImagem.aspx.cs" Inherits="SAUP.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <title>Acompanhamento Por Imagem</title>
  <link rel="stylesheet" type="text/css" media="all" href="../Scripts/Imagens/css/styles.css">
<script type="text/javascript" src="../Scripts/Imagens/js/jquery.js"></script>
</asp:Content>
<asp:Content ID="ContentAcompanhamentoporImagem" ContentPlaceHolderID="Conteudo_Master" runat="server">
<h3>Acompanhamento de Históricos por imagem - Análise Estado Atual</h3>
   <asp:Panel ID="PanelImagensAcompAtual" runat="server" GroupingText="Histórico de acompanhamentos">


            <asp:GridView ID="GridViewTESTE" runat="server" 
           DataKeyNames="ID_ACOMPANHAMENTO" AutoGenerateColumns="False" Width=100% CellPadding="3" CellSpacing="1">
           <HeaderStyle BackColor="GhostWhite" Font-Bold="true"  />
          <RowStyle BorderStyle="Inset" BorderColor="WindowFrame" BackColor="Transparent" Font-Size="Small" />
            <Columns>
                <asp:BoundField HeaderText ="Data Realização" DataField="DATAREALIZACAO" >
                <HeaderStyle Font-Bold="True" Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField HeaderText ="Descrição Tratamento" 
                    DataField="DESCRICAOTRATAMENTO" >
                <HeaderStyle Font-Bold="True" Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Pontuação" DataField="PONTUACAO_RECALCULADA" >
                <HeaderStyle Font-Bold="True" Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField HeaderText ="Nome do arquivo" DataField="CAMINHO" >
                <FooterStyle Font-Bold="True" Font-Size="Small" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="caminho"
                 DataImageUrlFormatString="~/Images/Anexos/{0}" NullDisplayText="Imagem não disponível" HeaderText="Imagem" ReadOnly="True"  ControlStyle-CssClass="images" AlternateText="Imagem não disponível">
            </asp:ImageField>
            </Columns>
            
            <EmptyDataTemplate>
        Nenhum dado a apresentar. É necessário ao menos um acompanhamento que possua ao menos um anexo.
        </EmptyDataTemplate>
            </asp:GridView>


      
       <asp:Label ID="LabelErro" runat="server" Visible="false"></asp:Label>
        <asp:Button ID="RetornaMenuPrincipal" runat="server" PostBackUrl="~/Monitoramento/Monitoramento.aspx" Text="Retornar Menu Principal" />
    </asp:Panel>

<hr />
  
   
</asp:Content>
