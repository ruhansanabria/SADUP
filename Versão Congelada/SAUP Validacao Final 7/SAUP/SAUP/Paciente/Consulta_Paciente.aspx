<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Consulta_Paciente.aspx.cs" Inherits="SAUP.Consulta_Paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">


    <asp:Panel id="painel_busca_Usuarios" GroupingText="Busca de Usuarios" runat="server">
        <center><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onprerender="DropDownList1_PreRender">
              <asp:ListItem>Nome</asp:ListItem>
              <asp:ListItem>RG</asp:ListItem>
              <asp:ListItem>CPF</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBoxConsulta" runat="server" MaxLength="11"></asp:TextBox>
        <asp:Button ID="ButtonBuscar" runat="server" onclick="ButtonBuscar_Click" Text="Buscar" />
        <asp:Button ID="ButtonInserir" runat="server" Text="Inserir Paciente" onclick="ButtonInserir_Click" /></center>
        <br />
        <center><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBoxConsulta" ForeColor="Red" 
            ValidationExpression="[0-9]+"></asp:RegularExpressionValidator></center>
        <h2>Resultados  da Busca</h2>
        <hr />

        <asp:GridView runat="server" ToolTip="Resultados da Busca" 
            ID="grid_resultado_busca_Usuarios" BorderColor="#009900" 
            BorderStyle="Dashed" Caption="Resultados da Busca" CellSpacing="20" 
            HorizontalAlign="Center" PageIndex="2" AutoGenerateColumns="False" 
            onrowcommand="grid_resultado_busca_Usuarios_RowCommand" 
            DataKeyNames="ID_PACIENTE">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar" />
                <asp:BoundField DataField="ID_PACIENTE" HeaderText="ID_PACIENTE" />
                <asp:BoundField DataField="NOME" HeaderText="NOME" />
                <asp:BoundField DataField="RG" HeaderText="RG" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="TELEFONE" HeaderText="TELEFONE" />
                <asp:BoundField DataField="SEXO" HeaderText="SEXO" />
                <asp:BoundField DataField="DATA_NASCIMENTO" HeaderText="DATA_NASCIMENTO" />
            </Columns>
        </asp:GridView>
        <br />
        
        <hr />
        
        <asp:Button ID="ButtonRetornarMenu" runat="server" Height="26px" 
        Text="Voltar para o Menu Principal" UseSubmitBehavior="False" 
        CausesValidation="False" onclick="ButtonRetornarMenu_Click"/>

        <asp:Label ID="Label_Pesquisa" runat="server" Text="Campo Incorreto" 
            Visible="False"></asp:Label>
    </asp:Panel>
</asp:Content>
