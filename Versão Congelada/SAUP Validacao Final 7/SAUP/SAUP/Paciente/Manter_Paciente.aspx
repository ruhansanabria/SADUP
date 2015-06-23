<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Manter_Paciente.aspx.cs" Inherits="SAUP.Manter_Paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">

<script src="../Scripts/JqueryMask/lib/jquery-1.9.0.min.js" type="text/javascript" charset="utf-8"></script>
<script src="../Scripts/JqueryMask/dist/jquery.maskedinput.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        $.mask.definitions['~'] = '[+-]';
        //        $(".TextBoxTEL").mask("(99)9999-9999");
        $(".TextBoxTEL").mask("(99) 9999-9999?9").ready(function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unmask();
            if (phone.length > 10) {
                element.mask("(99) 99999-999?9");
            } else {
                element.mask("(99) 9999-9999?9");
            }
        });
        $(".TextBoxRG").mask("9.999.999-9");
        $(".TextBoxCPF").mask("999.999.999-99");
        $(".TextBoxData").mask("99/99/9999");
        
        
     });

</script>
<span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
<asp:ValidationSummary ID="ValidationSummaryPaciente" runat="server" EnableClientScript ="true" ValidationGroup="Paciente" CssClass="failureNotification"/>
<asp:Panel ID="panel" runat="server" GroupingText="Informações do Paciente">

    <center><h1><asp:Label ID="LabelInformacao" runat="server" Text="Inserir Paciente"></asp:Label></h1>
        <asp:Label ID="Label_Nome_Paciente" runat="server" Text="Nome"></asp:Label>
        <asp:TextBox ID="TextBox_Nome_Paciente" runat="server" MaxLength="100"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Sexo"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Masculino</asp:ListItem>
            <asp:ListItem>Feminino</asp:ListItem>
        </asp:DropDownList>
        <br />
        <center>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox_Nome_Paciente" 
                ErrorMessage="Somente letras para o nome" ForeColor="Red" 
                ValidationExpression="^[a-z\u00C0-\u00ff A-Z]+$"></asp:RegularExpressionValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNomePaciente" 
                runat="server" ControlToValidate="TextBox_Nome_Paciente" 
                CssClass="failureNotification" ErrorMessage="Nome do paciente é obrigatório" 
                SetFocusOnError="true" ValidationGroup="Paciente"></asp:RequiredFieldValidator>
        </center>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;<asp:Label ID="Label7" runat="server" AssociatedControlID="TextBoxRG" 
            ForeColor="Red" Text="*" Visible="False"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="RG"></asp:Label>
        <asp:TextBox ID="TextBoxRG" runat="server" AutoPostBack="true" 
            class="TextBoxRG" ontextchanged="TextBoxRG_TextChanged1" ToolTip="9.999.999-9"></asp:TextBox>
        <br />
       <center> <asp:Label ID="LabelRG" runat="server" AssociatedControlID="TextBoxRG" 
            ForeColor="Red" Text="RG já existente" Visible="False"></asp:Label>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRG" runat="server" 
            ControlToValidate="TextBoxRG" CssClass="failureNotification" 
            ErrorMessage="RG é obrigatório" SetFocusOnError="true" 
            ValidationGroup="Paciente"></asp:RequiredFieldValidator></center>
        <br />
&nbsp;<asp:Label ID="Label3" runat="server" Text="CPF"></asp:Label>
        <asp:TextBox ID="TextBoxCPF" runat="server" AutoPostBack="true" 
            class="TextBoxCPF" ontextchanged="TextBoxCPF_TextChanged" 
            ToolTip="999.999.999-99"></asp:TextBox>
        <br />
       <center><asp:RequiredFieldValidator ID="RequiredFieldValidatorCPF" runat="server" 
            ControlToValidate="TextBoxCPF" CssClass="failureNotification" 
            ErrorMessage="CPF é obrigatório" SetFocusOnError="true" 
            ValidationGroup="Paciente"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label8" runat="server" AssociatedControlID="TextBoxCPF" 
            ForeColor="Red" Text="CPF já existente" Visible="False"></asp:Label></center>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />
        <asp:Label ID="Label9" runat="server" AssociatedControlID="TextBoxTEL" 
            ForeColor="Red" Text="*" Visible="False"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Telefone"></asp:Label>
        <asp:TextBox ID="TextBoxTEL" runat="server" class="TextBoxTEL" 
            ToolTip="41 99999999"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTEL" runat="server" 
            ControlToValidate="TextBoxTEL" CssClass="failureNotification" 
            ErrorMessage="Telefone é obrigatório" SetFocusOnError="true" 
            ValidationGroup="Paciente"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label10" runat="server" AssociatedControlID="TextBoxData" 
            ForeColor="Red" Text="*" Visible="False"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Data de Nascimento"  ></asp:Label>
        <asp:TextBox ID="TextBoxData" runat="server" class="TextBoxData" 
            ontextchanged="TextBoxData_TextChanged" AutoPostBack="true"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorData" runat="server" 
                        ErrorMessage="Data de Nascimento é obrigatório" ControlToValidate="TextBoxData" ValidationGroup="Paciente" 
                        CssClass="failureNotification" SetFocusOnError="true"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        
        &nbsp;<asp:Button ID="Button_Gravar" runat="server" onclick="Button_Gravar_Click" 
            Text="Gravar" Visible="False" ValidationGroup="Paciente" />
        &nbsp;<asp:Button ID="Button_inserir" runat="server" onclick="Button_inserir_Click" 
            Text="Inserir" Visible="False" ValidationGroup="Paciente"/>
        <br />
        <asp:Label ID="LabelAlerta" runat="server" Text="Alerta" Visible="False"></asp:Label>
        <br />
    </center>
    <asp:Button ID="MenuPrincipal" runat="server" Height="23px" 
    Text="Retornar ao Menu Principal" onclick="MenuPrincipal_Click" />

    </asp:Panel>
</asp:Content>
