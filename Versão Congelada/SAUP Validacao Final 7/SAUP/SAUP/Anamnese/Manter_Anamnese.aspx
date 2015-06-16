<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Manter_Anamnese.aspx.cs" Inherits="SAUP.Manter_Anamnese" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="../Scripts/jquery-ui-1.9.2/js/jquery-1.8.3.js"></script>  
<script type="text/javascript" src="../Scripts/jquery-ui-1.9.2/js/jquery-ui-1.9.2.custom.js"></script> 
<script type="text/javascript" src="../Scripts/jquery-ui-1.9.2/js/jquery-ui-1.9.2.custom.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">


   <h3><asp:Label ID="Paciente" runat="server" Text="Paciente :" 
           ToolTip="Nome do Paciente para Anamnese"></asp:Label>
           <asp:TextBox ID="Paciente_TextBox" runat="server" Enabled="False"></asp:TextBox>
           
           </h3>
   <center><h1>Anamnese</h1></center><br />

    <center>
   <asp:GridView ID="Listagem_Pacientes" runat="server"
            DataSourceID="ObjectDataSource1" DataKeyNames="id_paciente" 
            EnablePersistedSelection="True">
       <Columns>
           <asp:CommandField ShowSelectButton="True" />
       </Columns>
       <SelectedRowStyle BackColor="#99FF99" />
       <EmptyDataTemplate>
       Não há nenhum paciente cadastrado sem Anamnese.
       Um paciente sem anamnese já registrada deve ser cadastrado.
       </EmptyDataTemplate>
   </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="consultar_Paciente_Todos_Anamnese" 
            TypeName="SAUP.Control.PacienteBC"></asp:ObjectDataSource>
   
    <br />
    <asp:Label ID="historicoDoencas" runat="server" Text="Histórico Doenças" 
        AssociatedControlID="textHistorico"></asp:Label>
    <br />
   <asp:TextBox ID="textHistorico" runat="server" Height="90px" Width="398px" 
            TextMode="MultiLine" MaxLength="5000"></asp:TextBox></center> 
    <br />
    <center><asp:RequiredFieldValidator ID="RequiredFieldValidatorHistoricoDoencas" 
    runat="server" ErrorMessage="Histórico de doenças é obrigatório" 
    ControlToValidate="textHistorico" CssClass="failureNotification"></asp:RequiredFieldValidator></center>

    <center><asp:Label ID="HistoricoFamiliar" runat="server" Text="Historico Familiar" 
        AssociatedControlID="textHistorico"></asp:Label>
    <br />
   
    <asp:TextBox ID="textFamiliar" runat="server" Height="90px" Width="398px" 
            TextMode="MultiLine" MaxLength="5000"></asp:TextBox></center> 
    <br />
      <center><asp:RequiredFieldValidator ID="RequiredFieldValidatorHistóricoFamiliar" 
    runat="server" ErrorMessage="Histórico de Doenças Familiares é obrigatório" 
    ControlToValidate="textFamiliar" CssClass="failureNotification"></asp:RequiredFieldValidator></center>
    <center><asp:Label ID="InformaçõesAdicionais" runat="server" 
        Text="Informações Adicionais" AssociatedControlID="textInfo"></asp:Label>
    <br />
    <asp:TextBox ID="textInfo" runat="server" Height="90px" Width="398px" 
            TextMode="MultiLine" MaxLength="5000"></asp:TextBox></center>
    &nbsp;<br />
    <br />
    <center> <asp:Button ID="Gravar" runat="server" Text="Cadastrar" Width="76px" 
            onclick="Gravar_Click" Height="26px" />
                <asp:Button ID="Atualizar_Button" runat="server" Text="Atualizar Dados" UseSubmitBehavior="true" 
                    Width="111px" onclick="Atualizar_Button_Click" Visible="False"  />
        <br />
        <asp:Label ID="LabelMensagem" runat="server" Text="Alert" Visible="False"></asp:Label>

       
    </center>
            <center>
                </center>
    <asp:Button ID="RetornarMenuPrincipal" runat="server" 
    Text="Retornar ao Menu Principal" Height="24px" 
    onclick="RetornarMenuPrincipal_Click"  CausesValidation="False" />
    <br />
</asp:Content>
