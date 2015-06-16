<%@ Page Title="" Language="C#" MasterPageFile="~/SAUP.Master" AutoEventWireup="true" CodeBehind="Orientacoes.aspx.cs" Inherits="SAUP.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #TextArea1
        {
            height: 372px;
            width: 1322px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo_Master" runat="server">
    
 <asp:Panel ID="AcoesCuidade"  GroupingText="Ações de Cuidado" runat="server" BorderWidth="0.05px" BorderStyle="Solid">

    <asp:BulletedList ID="BulletedListAcoesCuidadoPerSens" runat="server" BulletStyle="Square">
    <asp:ListItem Text= "Percepção sensorial : Avaliar estado cognitivo de sensação "></asp:ListItem>
    </asp:BulletedList>
    <br />
       <asp:BulletedList ID="BulletedListUmidade" runat="server" BulletStyle="Square">
    <asp:ListItem Text= "Umidade : 
            ° Manter pele limpa e seca 
            ° Minimizar o contato da pele com urina, fezes, suor ou exsudato da ferida, por meio de barreiras de incontinência; 
            ° Evitar o contato com superfícies plásticas; 
            ° Manter a temperatura corporal entre 35,5 e 37ºC; "></asp:ListItem>
    </asp:BulletedList>
    <br />
        <asp:BulletedList ID="BulletedListAtividadeFis" runat="server" BulletStyle="Square">
    <asp:ListItem Text= "Atividade física : 
            ° Utilizar bengala e/ou andador para reabilitação ativa e deambulação; 
            ° Consultar Fisioterapeuta e Terapeuta Ocupacional a fim de complementar cuidado iniciado;
             "></asp:ListItem>
    </asp:BulletedList>
    <br />
            <asp:BulletedList ID="BulletedListMobilidade" runat="server" BulletStyle="Square">
    <asp:ListItem Text= "Mobilidade :
            ° Realizar movimentação e exercícios passivos em membros e articulações; 
            ° Realizar mudança de decúbito a cada 02 horas; 
            ° Reposicionar pacientes de acordo com o esquema de mudança de decúbito (relógio); 
            ° Ensinar aos acompanhantes formas de distribuir a pressão; 
            ° Solicitar avaliação do fisioterapeuta, ou terapeuta ocupacional quando necessário."></asp:ListItem>
    </asp:BulletedList>
    <br />
                <asp:BulletedList ID="BulletedListNutricao" runat="server" BulletStyle="Square">
    <asp:ListItem Text= "Nutrição :
            ° Encorajar ingesta alimentar via oral ou seguir plano nutricional prescrito; 
            ° Avaliar comprometimento nutricional por meio de sinais como enfraquecimento muscular, perda de peso, diminuição de turgor cutâneo. o Acompanhar estado nutricional por meio de dados laboratoriais; 
            ° Monitorar e registrar a perda de fluidos da UP;"></asp:ListItem>
    </asp:BulletedList>
    <br />
           <asp:BulletedList ID="BulletedListFriccaoCisa" runat="server" BulletStyle="Square">
    <asp:ListItem Text= "Fricção/Cisalhamento :
            ° Utilizar lençóis móveis para transferência e mobilização de pacientes (ex. leito-maca); 
            ° Evitar massagens em regiões hiperemiadas, com redução de sensibilidade e/ou sobre proeminências ósseas; 
            ° Manter cabeceira elevada até 30º;
            ° Evitar botas com gel ou acolchoadas o Evitar o uso de anéis de espuma; 
            ° Aplicar coxins sob proeminências ósseas; "></asp:ListItem>
    </asp:BulletedList>  
    
    </asp:Panel>  
    
 
</asp:Content>
