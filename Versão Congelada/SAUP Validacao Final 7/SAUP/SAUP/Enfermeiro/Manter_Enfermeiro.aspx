<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Manter_Enfermeiro.aspx.cs" Inherits="SAUP.Manter_Enfermeiro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content_Manter_Enfermeiro" ContentPlaceHolderID="Conteudo_Master" runat="server">
  <script type="text/javascript" language="javascript">
      /* Manual client-side validation of Validator Groups */
      function fnJSOnFormSubmit() {
          var isManterEnf = Page_ClientValidate("ManterEnf");
          

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


          if (isManterEnf == true)
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
<span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
<asp:ValidationSummary ID="ValidacaoManterEnf" runat="server" ValidationGroup="ManterEnf" EnableClientScript ="true" CssClass="failureNotification"/>
<br />


   
   <center> <asp:Label ID="Label_nome" runat="server" Text="Nome" 
            AssociatedControlID="TextBox_nome"></asp:Label>
    <asp:TextBox ID="TextBox_nome" runat="server" MaxLength="100" ></asp:TextBox></center>
    
        <center><asp:RegularExpressionValidator ID="RegularExpressionValidatorNome" runat="server" 
            ControlToValidate="TextBox_nome" ErrorMessage="Somente letras para o nome do usuário" 
            ForeColor="#FF3300" ValidationExpression="^[a-z\u00C0-\u00ff A-Z]+$"></asp:RegularExpressionValidator>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNome" runat="server" 
            ErrorMessage="Nome é obrigatório" ControlToValidate="TextBox_nome" ValidationGroup="ManterEnf" CssClass="failureNotification"></asp:RequiredFieldValidator></center><br />

<center>&nbsp;&nbsp;&nbsp; <asp:Label ID="Label_user" runat="server" Text="Usuário"     
            AssociatedControlID="TextBox_user"></asp:Label>
    <asp:TextBox ID="TextBox_user" runat="server" MaxLength="30" 
           ontextchanged="TextBox_user_TextChanged" AutoPostBack="true"></asp:TextBox>
           
            <br />
&nbsp;&nbsp;
           
           <center> <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server"
         ErrorMessage="Nome de usuário é obrigatório" 
        ValidationGroup="ManterEnf" ControlToValidate="TextBox_user" CssClass="failureNotification"></asp:RequiredFieldValidator>
    
    <asp:Label ID="LabelErrorUniqueUserName" ForeColor="Red" Text="Por gentileza, digite outro nome" Visible="false" runat="server" ></asp:Label></center>
        
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorUserName" runat="server" 
            ControlToValidate="TextBox_user" ErrorMessage="Somente letras e caracteres exceto números." 
            ForeColor="#FF3300" ValidationExpression="[^0-9]+"></asp:RegularExpressionValidator></center><br />

       
    
     <center> <asp:Label ID="LabelSituacaoEnf" runat="server" AssociatedControlID="DropDownList_Status" Text="Situação do Enfermeiro :"></asp:Label>
    <asp:DropDownList ID="DropDownList_Status" runat="server">
        <asp:ListItem>Ativo</asp:ListItem>
        <asp:ListItem>Inativo</asp:ListItem>
    </asp:DropDownList></center><br />
   <center> <asp:Label ID="PerfilAtualLabel" Text="Perfil Atual do Enfermeiro :" AssociatedControlID="PerfilAtual" runat="server"></asp:Label>
    <asp:TextBox ID="PerfilAtual" runat="server" Enabled="false"></asp:TextBox>

        <h4>Listagem dos Perfis Disponíveis</h4>
  
   
        <asp:GridView ID="GridViewPerfilEnfermeiro" runat="server" 
            DataSourceID="ObjectDataSource1" EnablePersistedSelection="True" 
            DataKeyNames="id_perfil_enfermeiro" 
           onselectedindexchanged="GridViewPerfilEnfermeiro_SelectedIndexChanged">
           <Columns>
               <asp:CommandField ButtonType="Button" SelectText="Selecionar" 
                   ShowSelectButton="True" />
           
           </Columns>
           
            <SelectedRowStyle BackColor="#CCFF99" />
           <EmptyDataTemplate>
           Não há dados a apresentar, ou não foi possível conectar ao banco de dados.
           </EmptyDataTemplate> 
        </asp:GridView>

        <br />
    <asp:TextBox ID="TextBoxSelectedPerf" runat="server" Text="" CssClass="fields_Grids_Validador"></asp:TextBox>

                  <asp:RequiredFieldValidator ID="RequiredFieldValidatorTratamento" runat="server" 
                        ErrorMessage="Selecionar Perfil do Enfermeiro é obrigatório"  ControlToValidate="TextBoxSelectedPerf" ValidationGroup="ManterEnf" 
                        CssClass="failureNotification" SetFocusOnError="true"></asp:RequiredFieldValidator>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="consultar_perfil" TypeName="SAUP.DAO.PerfilEnfermeiroDAO">
        </asp:ObjectDataSource>
       
        
      
    </center>
   <center><asp:Label ID="LabelSenha" runat="server" Text="Senha" 
           AssociatedControlID="TextBoxSenha"></asp:Label>

    <asp:TextBox ID="TextBoxSenha" runat="server"  ToolTip="Senha até 20 caracteres." TextMode="Password" MaxLength="20"></asp:TextBox><br />
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="TextBoxSenha" ErrorMessage="Senha é obrigatório" 
     CssClass="failureNotification" ValidationGroup="ManterEnf"></asp:RequiredFieldValidator></center>
          
  
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
   
  
  
    <center>
    
        
        <asp:Button ID="ButtonInserir" runat="server" Text="Inserir" 
            onclick="ButtonInserir_Click" Visible="False" ValidationGroup="ManterEnf"  OnClientClick="return (fnJSOnFormSubmit());" />
         <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" ValidationGroup="ManterEnf"  OnClientClick="return (fnJSOnFormSubmit());" onclick="ButtonSalvar_Click"/>
    </center>
    <asp:Button ID="Menuprincipal" runat="server" Height="23px" 
    Text="Retornar ao Menu Principal" onclick="Menuprincipal_Click" />

</asp:Content>
