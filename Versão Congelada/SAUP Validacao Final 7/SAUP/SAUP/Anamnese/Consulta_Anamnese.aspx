<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Consulta_Anamnese.aspx.cs" Inherits="SAUP.Consulta_Anamnese" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">
         <center> <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onprerender="DropDownList1_PreRender">
              <asp:ListItem >Nome</asp:ListItem>
              <asp:ListItem>RG</asp:ListItem>
              <asp:ListItem>CPF</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox_Consulta" runat="server" >
        </asp:TextBox>
        
        <asp:Button ID="Button_Busca" runat="server" Text="Buscar" 
                onclick="Button_Busca_Click" OnClientClick="retun btnSelete_Click();" />
           <asp:Button ID="Insert_Anamnese_Button" runat="server" Text="Inserir Anamnese" 
                CommandName="Insert" onclick="Insert_Anamnese_Button_Click" 
                Width="153px" />
            <br />

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox_Consulta" ForeColor="Red" 
                ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>

        
            <br />
            <h2>Resultados  da Busca</h2>
        <hr />

        <asp:GridView runat="server" ToolTip="Resultados da Busca" 
            ID="grid_resultado_busca_anamnese" runat="server" 
                OnRowCommand=" grid_resultado_busca_anamnese_SelectedIndexChanged" 
                EnablePersistedSelection="True" DataKeyNames="id_paciente" 
                SelectedRowStyle-BackColor="#99FF66" AutoGenerateSelectButton="True" 
                AutoGenerateColumns="False" >
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:BoundField HeaderText="Nome" DataField="NOME" />
                <asp:BoundField HeaderText="Data_Realizacao" DataField="DATA_REALIZACAO" />
                <asp:BoundField HeaderText="Historico_Doencas" DataField="HISTORICO_DOENCAS"/>
                <asp:BoundField HeaderText="Historico_Familiar" DataField="HISTORICO_FAMILIAR" />
                <asp:BoundField HeaderText="Informacoes_Adicionais" DataField="INFORMACOES_ADICIONAIS" />

            </Columns>
            
        </asp:GridView>
        <br />
        <asp:Label ID="Label_Pesquisa" runat="server" Visible="False"> </asp:Label>
        
            <asp:Label ID="dialog_confirm" runat="server" Visible="true"    ></asp:Label>
            <br />
            <asp:Label ID="Alerta" runat="server" Text="Alerta" Visible="False"></asp:Label>
        <br />
        <hr />
        </center><br />
         <asp:Button ID="ButtonCancelar" runat="server" 
        Text="Retornar ao menu principal" 
       onclick="ButtonCancelar_Click" CausesValidation="False" />
</asp:Content>
