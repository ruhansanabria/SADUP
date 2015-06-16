<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="EditarAcompanhamento.aspx.cs" Inherits="SAUP.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentEditarAcompanhamento" ContentPlaceHolderID="Conteudo_Master" runat="server">

<html>
<title>SAUP - Avaliação</title>
	<link rel="stylesheet" href="../Scripts/jquery-ui-1.9.2/development-bundle/themes/base/jquery.ui.all.css">
	<script src="../Scripts/jquery-ui-1.9.2/development-bundle/jquery-1.8.3.js"></script>
	<script src="../Scripts/jquery-ui-1.9.2/development-bundle/ui/jquery.ui.core.js"></script>
	<script src="../Scripts/jquery-ui-1.9.2/development-bundle/ui/jquery.ui.widget.js"></script>
    <script src="../Scripts/jquery-ui-1.9.2/development-bundle/ui/jquery.ui.mouse.js"></script>
	<script src="../Scripts/jquery-ui-1.9.2/development-bundle/ui/jquery.ui.resizable.js"></script>
	<script src="../Scripts/jquery-ui-1.9.2/development-bundle/ui/jquery.ui.accordion.js"></script>
	<link rel="stylesheet" href="../Scripts/jquery-ui-1.9.2/development-bundle/demos/demos.css">
	<script src="../Scripts/jquery-ui-1.9.2/development-bundle/ui/jquery.ui.tabs.js"></script>

    <style>
	#accordion-resizer {
		padding: 10px;
		width: 800px;
		height: 300px;
	}
	            
     .ui-tabs-vertical { width:inherit; }
	.ui-tabs-vertical .ui-tabs-nav { padding: .2em .1em .2em .2em; float: left; width: 12em; }
	.ui-tabs-vertical .ui-tabs-nav li { clear: left; width:100%; border-bottom-width: 1px !important; border-right-width: 0 !important; margin: 0 -1px .2em 0; }
	.ui-tabs-vertical .ui-tabs-nav li a { display:block; }
	.ui-tabs-vertical .ui-tabs-nav li.ui-tabs-active { padding-bottom: 0; padding-right: .1em; border-right-width: 1px; border-right-width: 1px; }
	.ui-tabs-vertical .ui-tabs-panel { padding: 1em; float: left; width:auto;}
	</style>
	<script>
	    $(function () {
	        $("#accordion").accordion({
	            heightStyle: "fill"
	        });
	    });
	    $(function () {
	        $("#accordion-resizer").resizable({
	            minHeight: 140,
	            minWidth: 200,
	            resize: function () {
	                $("#accordion").accordion("refresh");
	            }
	        });
	    });
	    $(function () {
	        $("#tabs").tabs();
	    });

	    $(document).ready(function () {

	        $('#tabs').tabs({
	            activate: function () {
	                var newIdx = $('#tabs').tabs('option', 'active');
	                $('#<%=hidLastTab.ClientID%>').val(newIdx);

	            }, heightStyle: "80%",
	            active: previouslySelectedTab,
	            show: { effect: "fadeIn", duration: 1000 }
	        });

	    });
	  	   
	</script>
       <script type="text/javascript" language="javascript">
           /* Manual client-side validation of Validator Groups */
           function fnJSOnFormSubmit() {
               var isAcompanhamento = Page_ClientValidate("Acompanhamento");
               var isPaciente = Page_ClientValidate("Paciente");
               var isTratamento = Page_ClientValidate("Tratamento");
               var isStatus = Page_ClientValidate("Status_Acompanhamento");
               var isRespostas = Page_ClientValidate("Respostas");

               var i;
               for (i = 0; i < Page_Validators.length; i++) {
                   ValidatorValidate(Page_Validators[i]); //this forces validation in all groups
               }

               for (i = 0; i < Page_ValidationSummaries.length; i++) {
                   summary = Page_ValidationSummaries[i];
                   //does this summary need to be displayed?
                   if (fnJSDisplaySummary(summary.validationGroup)) {
                       summary.style.display = "inline"; //"none"; "inline";
                   }
               }


               if (isAcompanhamento && isPaciente && isTratamento && isPaciente && isStatus && isRespostas)
                   return true; //postback only when BOTH validations pass.
               else
                   return false;
           }


           /* determines if a Validation Summary for a given group needs to display */
           function fnJSDisplaySummary(valGrp) {
               var rtnVal = false;
               for (i = 0; i < Page_Validators.length; i++) {
                   if (Page_Validators[i].validationGroup == valGrp) {
                       if (!Page_Validators[i].isvalid) { //at least one is not valid.
                           rtnVal = true;
                           break; //exit for-loop, we are done.
                       }
                   }
               }
               return rtnVal;
           }
</script>
 
</head>
<body>
<asp:ValidationSummary ID="ValidacaoGeral" runat="server" ValidationGroup="Acompanhamento" EnableClientScript ="true" CssClass="failureNotification"/>
<asp:ValidationSummary ID="ValidationSummaryPaciente" runat="server" EnableClientScript ="true" ValidationGroup="Paciente" CssClass="failureNotification"/>
<asp:ValidationSummary ID="ValidationSummaryTratamento" runat="server"  ValidationGroup="Tratamento" EnableClientScript ="true" CssClass="failureNotification"/>
<asp:ValidationSummary ID="ValidationSummaryStatusAcompanhamento" runat="server"  ValidationGroup="Status_Acompanhamento" EnableClientScript ="true" CssClass="failureNotification"/>
<asp:ValidationSummary ID="ValidationSummary1" runat="server"  ValidationGroup="Respostas" CssClass="failureNotification"/>

        


<div id="tabs">
	<ul>
		<li><a href="#tabs-1">1º Passo</a></li>
		<li><a href="#tabs-2">2º Passo</a></li>
		<li><a href="#tabs-3">3º Passo</a></li>
        <li><a href="#tabs-6">Listagem dos Procedimentos e Produtos Vinculados ao Tratamento</a></li>
		<li><a href="#tabs-4">4º Passo</a></li>
        <li><a href="#tabs-5">5º Passo</a></li>
     
	</ul>
	<div id="tabs-1">
		 <asp:Panel ID="FiltroBuscaPaciente" runat="server" GroupingText=" 1º Passo :Informações do acompanhamento selecionado para a edição"  BorderStyle="Solid" BorderWidth="0.05px" >
          
             <asp:DetailsView ID="DetailsViewInformacoesAcompSelecionado" runat="server" 
                  Height="50px" Width="286px"  GridLines="Vertical" BackColor="White" 
                  BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                  ForeColor="Black">
                 <AlternatingRowStyle BackColor="White" />
                 <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="#CCFF99" />
                 <FooterStyle BackColor="#CCCC99" />
                 <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                 <RowStyle BackColor="#F7F7DE" />
                 <EmptyDataTemplate>
                 Nenhum dado a apresentar
                 </EmptyDataTemplate>
             </asp:DetailsView>

             <br />
             <h3>Histórico de Acompanhamentos do Paciente</h3>
             <hr />
             <asp:GridView ID="GridViewHistorico" runat="server"          
              AutoGenerateColumns="False" >
             <Columns>

                 <asp:BoundField DataField="DATAREALIZACAO" HeaderText="Data de Realização" />
                 <asp:BoundField DataField="PONTUACAO_RECALCULADA" HeaderText="Pontuação" />
                 <asp:BoundField DataField="DESCRICAOTRATAMENTO" HeaderText="Tratamento" />
                 <asp:BoundField DataField="PRIORIDADE" HeaderText="Prioridade" />
                 <asp:BoundField DataField="INFORMACOESCOMPLEMENTARES" HeaderText="Informações Complementares" />
             
             
             </Columns>
             <EmptyDataTemplate>
            
             Nenhum dado a apresentar
             </EmptyDataTemplate>
             </asp:GridView>
                        
                        </asp:Panel>
	</div>
	<div id="tabs-2">
		  <asp:Panel ID="PainelPerguntasAgrupador" runat="server" GroupingText="Perguntas Escala" BorderStyle="Solid" BorderWidth="0.05px">
<html>
    <div id="accordion-resizer" class="ui-widget-content" align="center">
<div id="accordion">
	<h3>Percepção Sensorial</h3>
	<div>
            <asp:RadioButtonList ID="RadioPercepcaoSensorial" runat="server" RepeatDirection="Horizontal" >
             <asp:ListItem Text="1 -Totalmente Limitada" Value="1"></asp:ListItem>
             <asp:ListItem Text="2 - Muito limitada " Value="2"></asp:ListItem>
             <asp:ListItem Text="3 - Levemente Limitada" Value="3"></asp:ListItem>
             <asp:ListItem Text ="4 - Nenhuma Limitação" Value="4"></asp:ListItem>
             </asp:RadioButtonList>
              
	        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="RadioPercepcaoSensorial" 
                ErrorMessage="Favor selecionar uma resposta - Percepção Sensorial - Passo 2" ValidationGroup="Respostas" CssClass="failureNotification" ForeColor="Red"></asp:RequiredFieldValidator>
              
	</div>
            
	<h3>Umidade</h3>
	<div>
		<asp:RadioButtonList ID="RadioButtonListUmidade" runat="server" RepeatDirection="Horizontal" >
             <asp:ListItem Text="1 - Completamente Molhada" Value="1"></asp:ListItem>
             <asp:ListItem Text="2 - Muito Molhada" Value="2"></asp:ListItem>
             <asp:ListItem Text="3 - Ocasionalmente Molhada" Value="3"></asp:ListItem>
             <asp:ListItem Text="4 - Molhada" Value="4"></asp:ListItem>
             </asp:RadioButtonList>
            
	    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="RadioButtonListUmidade" 
            ErrorMessage="Selecionar um Resposta- Umidade - Passo 2" ValidationGroup="Respostas" CssClass="failureNotification" ForeColor="Red"></asp:RequiredFieldValidator>
            
	</div>
	<h3>Atividade Física</h3>
	<div>
       
             <asp:RadioButtonList ID="RadioButtonListAtividadeFisica" runat="server" RepeatDirection="Horizontal" >
             <asp:ListItem Text="1 - Acamado" Value="1"></asp:ListItem>
             <asp:ListItem Text="2 - Confinado à cadeira" Value="2"></asp:ListItem>
             <asp:ListItem Text="3 - Caminha Ocasionalmente" Value="3"></asp:ListItem>
             <asp:ListItem Text="4 - Anda Frequentemente" Value="4"></asp:ListItem>
             </asp:RadioButtonList>
              
	
	         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 ControlToValidate="RadioButtonListAtividadeFisica" 
                 ErrorMessage="Selecionar um Resposta- Atividade Física - Passo 2" ValidationGroup="Respostas" CssClass="failureNotification" ForeColor="Red"></asp:RequiredFieldValidator>
              
	
	</div>
	<h3>Mobilidade</h3>
	<div>
        <asp:RadioButtonList ID="RadioButtonListMobilidade" runat="server" RepeatDirection="Horizontal" >
             <asp:ListItem Text="1 - Totalmente Imóvel" Value="1"></asp:ListItem>
             <asp:ListItem Text="2 - Bastante limitada" Value="2"></asp:ListItem>
             <asp:ListItem Text="3 - Levemente limitada" Value="3"></asp:ListItem>
             <asp:ListItem Text="4 - Sem limitações" Value="4"></asp:ListItem>
             </asp:RadioButtonList>
                      
	
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="RadioButtonListMobilidade" 
            ErrorMessage="Selecionar um Resposta _ Mobilidade - Passo 2" ValidationGroup="Respostas" CssClass="failureNotification" ForeColor="Red"></asp:RequiredFieldValidator>
                      
	
    </div>
    <h3>Nutrição</h3>
	<div>
             <asp:RadioButtonList ID="RadioButtonListNutricao" runat="server" RepeatDirection="Horizontal" >
             <asp:ListItem Text="1 - Muito pobre" Value="1"></asp:ListItem>
             <asp:ListItem Text="2 - Provavelmente inadequada" Value="2"></asp:ListItem>
             <asp:ListItem Text="3 - Adequada" Value="3"></asp:ListItem>
             <asp:ListItem Text="4 - Excelente" Value="4"></asp:ListItem>
             </asp:RadioButtonList>        
	
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                 ControlToValidate="RadioButtonListNutricao" 
                 ErrorMessage="Selecionar um Resposta - Nutrição - Passo 2" ValidationGroup="Respostas" CssClass="failureNotification" ForeColor="Red"></asp:RequiredFieldValidator>
	
    </div>
    <h3>Fricção e Cisalhamento</h3>
	<div>
       
         <asp:RadioButtonList ID="RadioButtonListFriccaoCisalhamento" runat="server" RepeatDirection="Horizontal" >
             <asp:ListItem  Text="1 - Problema" Value="1"></asp:ListItem>
             <asp:ListItem Text="2 - Problema em potencial" Value="2"></asp:ListItem>
             <asp:ListItem Text="3 - Nenhum problema aparente" Value="3"></asp:ListItem>
             </asp:RadioButtonList>              

	
         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
             ControlToValidate="RadioButtonListFriccaoCisalhamento" 
             ErrorMessage="Selecionar um Resposta - Fricção e Cisalhamento - Passo 2" ValidationGroup="Respostas" CssClass="failureNotification" ForeColor="Red"></asp:RequiredFieldValidator>

	
    </div>
  </div>
  </div>
      
    <asp:Button ID="Button_GravarRespostas" runat="server" Text="Gravar Respostas" 
          onclick="Button_GravarRespostas_Click" UseSubmitBehavior="False" ValidationGroup="Respostas" CausesValidation="True" />
                        </asp:Panel>

                        <br />
                         <asp:Panel ID="PanelArquivoPontuacao" runat="server" GroupingText="Arquivo e informações da Pontuação" BorderStyle="Solid" BorderWidth="0.05px" HorizontalAlign="Center">
                     <br />
                     <br />                
                      <asp:Label ID="pontuacao" runat="server" Text="Pontuação da Escala: " 
                          AssociatedControlID="TextBox_Pontuacao"></asp:Label>
                  
                      <asp:TextBox ID="TextBox_Pontuacao" runat="server" Text="Não Calculado" ForeColor="White" Enabled="false"></asp:TextBox><br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidatorRespotasGeral" runat="server" 
                        ErrorMessage="Selecionar todas as perguntas é obrigatório-Passo 2"  ControlToValidate="TextBox_Pontuacao" ValidationGroup="Respostas" 
                        CssClass="failureNotification" SetFocusOnError="true"></asp:RequiredFieldValidator>
                      <asp:Label ID="LabelMensagemRiscoUP" runat="server" Text="" Visible="false"></asp:Label>
                      <asp:Image ID="ImageRisk" runat="server"  Visible="false"  />

                      </asp:Panel>
	</div>
    <div id="tabs-3">
       <asp:Panel ID="ListagemTratamentos" runat="server" GroupingText="Listagem dos  Tratamentos"  BorderStyle="Solid" BorderWidth="0.05px">
            <asp:GridView ID="GridViewLIstagem" runat="server" 
                DataSourceID="ObjectDataSourceListagemTratamentos" 
                EnablePersistedSelection="True" DataKeyNames="ID_TRATAMENTO" 
                onselectedindexchanged="GridViewLIstagem_SelectedIndexChanged" 
                AutoGenerateColumns="False" >
                  <Columns>
                      <asp:CommandField ShowSelectButton="True" />
                       <asp:BoundField DataField="ID_TRATAMENTO" HeaderText="ID_TRATAMENTO" 
                          Visible="False" />
                      <asp:BoundField DataField="ID_TIPO_TRATAMENTO" HeaderText="ID_TIPO_TRATAMENTO" 
                          Visible="False" />
                      <asp:BoundField DataField="DESCRICAOTRATAMENTO" 
                          HeaderText="Descrição do Tratamento" />
                      <asp:BoundField DataField="PERIODICIDADE" 
                          HeaderText="PERIODICIDADE DE ATENDIMENTO" />
                  </Columns>
                  <EmptyDataTemplate>
                  
                  Nenhum Dado a apresentar
                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidatorTratamento" runat="server" 
                        ErrorMessage="Selecionar Tratamento é obrigatório-Passo 3"  ControlToValidate="DescricaoTrat" ValidationGroup="Acompanhamento" 
                        CssClass="failureNotification" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                  </EmptyDataTemplate>
                  <SelectedRowStyle BackColor="#CCFF99" />
                  </asp:GridView>
                  <br />

                  <asp:TextBox ID="TextBoxSelectedTrat" runat="server" Text="" CssClass="fields_Grids_Validador"></asp:TextBox>

                  <asp:RequiredFieldValidator ID="RequiredFieldValidatorTratamento" runat="server" 
                        ErrorMessage="Selecionar Tratamento é obrigatório-Passo 3"  ControlToValidate="TextBoxSelectedTrat" ValidationGroup="Tratamento" 
                        CssClass="failureNotification" SetFocusOnError="true"></asp:RequiredFieldValidator>

                  <asp:ObjectDataSource ID="ObjectDataSourceListagemTratamentos" 
                runat="server" SelectMethod="retorna_Todos_Tratamentos" 
                TypeName="SAUP.Control.TratamentoBC"></asp:ObjectDataSource>
                  </asp:Panel>
                  <br />
                  <asp:Panel ID="PanelInformacoesTratamentoOrientacoes" runat="server"  GroupingText=" Informações do Tratamento e Orientações" BorderStyle="Solid" BorderWidth="0.05px">
                                         
                      <asp:HyperLink ID="HyperLinkOrientacoes" NavigateUrl="~/Orientacoes_Procedimentos/Orientacoes.aspx" runat="server">Ações de Cuidado</asp:HyperLink>
                    <br /><br />
                     <asp:DropDownList ID="DropPrioridade" runat="server">
                    
                    <asp:ListItem>0-Muito Urgente</asp:ListItem>
                    <asp:ListItem>1-Urgente</asp:ListItem>
                    <asp:ListItem>2-Pouco Urgente</asp:ListItem>
                    <asp:ListItem>3-Não Urgente</asp:ListItem>
                    </asp:DropDownList> 
                    
                  </asp:Panel>

                  <asp:Panel ID="PanelStatusAcompanhamento" runat="server" GroupingText ="Selecionar o Status do Acompanhamento">
                  
                  <asp:GridView ID="gridviewlistagemStatusAcomp" runat="server" 
                          AutoGenerateSelectButton="True" 
                          EnablePersistedSelection="True" AutoGenerateColumns="False" 
                          DataSourceID="ObjectDataSourceStatusAcompanhamento" 
                          DataKeyNames="id_status_acompanhamento" 
                          onselectedindexchanged="gridviewlistagemStatusAcomp_SelectedIndexChanged" >
                  
                  
                      <Columns>
                          <asp:BoundField DataField="descricao" HeaderText="Status do Acompanhamento" />
                      </Columns>
                      <EmptyDataTemplate>
                      Nenhum dado a apresentar
                      </EmptyDataTemplate>
                  <SelectedRowStyle BackColor="#CCFF99" />
                  
                  </asp:GridView>
                  <br />
                  <asp:TextBox ID="TextBoxStatusValidator" runat="server" Text="" CssClass="fields_Grids_Validador"></asp:TextBox>
                 
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorStatusAcompanhamento" runat="server" 
                        ErrorMessage="Selecionar Status do Acompanhamento é obrigatório-Passo 3"  ControlToValidate="TextBoxStatusValidator" ValidationGroup="Status_Acompanhamento" 
                        CssClass="failureNotification" SetFocusOnError="true"></asp:RequiredFieldValidator>
                  
                      
                      <asp:ObjectDataSource ID="ObjectDataSourceStatusAcompanhamento" runat="server" 
                          SelectMethod="retorna_Status_Acomp" TypeName="SAUP.Control.AcompanhamentoBC">
                      </asp:ObjectDataSource>
                      <br />
                  
                  
                  </asp:Panel>
                  
    
    </div>
    <div id="tabs-6">
    

        <h3>Procedimentos Vinculados ao Tratamento Selecionado</h3>
        <asp:Label ID="Label_Pesquisa" runat="server" Text="Digite um valor correto" Visible="false"></asp:Label>
        <asp:GridView ID="GridViewProcedimentosVinculados" runat="server">
            <EmptyDataTemplate>
                Nenhum dado a apresentar
            </EmptyDataTemplate>
        </asp:GridView>
        
        <hr />
        <h3>Produtos Vinculados ao Tratamento Selecionado</h3>
        <asp:GridView ID="GridViewProdutosVinculados" runat="server">
        <EmptyDataTemplate>
                Nenhum dado a apresentar
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div id="tabs-4">
    
     <asp:Panel ID="Anexos" runat="server" GroupingText="Arquivos vinculados" BorderStyle="Solid" BorderWidth="0.05px">
                       <asp:FileUpload ID="FileUpload_Anexo"  accept=".jpg,.png" 
                           AllowMultiple="False"  runat="server" />  
        
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ControlToValidate="FileUpload_Anexo"
         ValidationExpression="^.*\.(jpg|JPG|png|PNG)$"
         ErrorMessage="Somente arquivos .jpg e .png são aceitos para upload e correto funcionamento do acompanhamento por imagens " CssClass="failureNotification"></asp:RegularExpressionValidator>              
                      <br />
                          <asp:Label ID="LabelNomeAnexo"  AssociatedControlID="TextBoxNomeAnexo" runat="server" Text="Descrição do anexo:"></asp:Label>
                      <br />
                          <asp:TextBox ID="TextBoxNomeAnexo" runat="server" MaxLength="300" ToolTip="Nome do Anexo, 300 caracteres"></asp:TextBox>
                      </asp:Panel>
    </div>
    <div id="tabs-5">
    <asp:Panel ID="PanelInformacoesComplementares"  runat="server" GroupingText="Informações Complementares" BorderStyle="Solid" BorderWidth="0.5px">
    
    
        <asp:TextBox ID="TextBoxInformacoes" runat="server" TextMode="MultiLine" MaxLength="700" ToolTip="Descreva os procedimentos realizados, e alguma informação relevante observado durante 
        o acompanhamento" Width="400px" Height="200px"></asp:TextBox>
    </asp:Panel>
    
    
    
    </div>

</div>

      
      <asp:Label ID="mensagem" runat="server" Visible="False"></asp:Label>
       
       <center>
       <asp:Button ID="ButtonGravar" runat="server" Text="Gravar" 
       OnClientClick="return (fnJSOnFormSubmit());" 
       onclick="ButtonGravar_Click" /></center>

  <asp:HiddenField ID="hidLastTab" Value="0" runat="server" />
    <br />
   <asp:Button ID="Button1" runat="server" Height="26px" 
        Text="Voltar para o Menu Principal" UseSubmitBehavior="False" 
        CausesValidation="False" onclick="Button1_Click"  />
</body>         
    
     </html>

</asp:Content>
