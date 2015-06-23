<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Consulta_Enfermeiro.aspx.cs" Inherits="SAUP.Consulta_Enfermeiro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Consulta_Enfermeiro" ContentPlaceHolderID="Conteudo_Master" runat="server">
    <asp:Panel ID="Panel_Consulta_Enfermeiro" runat="server" 
        GroupingText="Buscar Enfermeiro" CssClass="Panel_General" 
    HorizontalAlign="Center">
    <h1>Busca de Enfermeiro</h1>
<%--<hr class="lineDividor" />--%>
    
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onprerender="DropDownList1_PreRender">

        <asp:ListItem Text="Nome" Value="Nome"></asp:ListItem>
        <%--Validar se sera ativo ou inativo somente--%>
        <asp:ListItem Text="Status" Value="Status"></asp:ListItem>
        <%--Validar se sera Assistencial ou Administrativo--%>
        <asp:ListItem Text="Perfil Enfermeiro" Value="PerfilEnfermeiro"></asp:ListItem>
         <asp:ListItem Text="Código" Value="Codigo"></asp:ListItem>
        </asp:DropDownList>
           <asp:TextBox ID="TextBox_Consulta_Enf" runat="server"></asp:TextBox>

           <asp:Button ID="Button_Consulta_Enf" runat="server" Text="Buscar" 
            onclick="ButtonConsulta_Enf_Click" />
            <asp:Button ID="ButtonInserir" runat="server" onclick="ButtonInserir_Click" 
            Text="Inserir Enfermeiro" />
       
           <br />
       
           
       
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
            runat="server" ControlToValidate="TextBox_Consulta_Enf" 
            ErrorMessage="RegularExpressionValidator" ForeColor="Red" ></asp:RegularExpressionValidator>
       
           
       
           <br />
        <br />
       
           <center><asp:GridView ID="GridView_Result_Enfermeiro" runat="server" 
                   onrowcommand="GridView_Result_Enfermeiro_SelectedIndexChanged" >
               <Columns>
                   <asp:ButtonField Text="Editar" ButtonType="Button" CommandName="Editar"  />
               </Columns>
           </asp:GridView>
               <br />
               <asp:Label ID="Label_Pesquisa" runat="server" BorderColor="Red" 
                   Font-Italic="True" Text="" Visible="False"></asp:Label>
        </center>

        <asp:ObjectDataSource ID="ObjectDataSourceEnfermeiro" runat="server" 
            SelectMethod="consultar_enfermeiro" TypeName="SAUP.DAO.EnfermeiroDAO">
            <SelectParameters>
                <asp:SessionParameter Name="filtro" SessionField="Session[&quot;Filtro&quot;]" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;

       
        <br />

       
    </asp:Panel>
    <asp:Button ID="ButtonRetornarMenu" runat="server" Text="Voltar para o Menu principal" 
        onclick="ButtonRetornarMenu_Click" />
</asp:Content>
