using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Control;
using SAUP.Model;
using SAUP.Validadores;
using System.Text.RegularExpressions;
using System.Globalization;
using IBM.Data.DB2;


namespace SAUP
{
    public partial class Manter_Paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            Page.MaintainScrollPositionOnPostBack = true;
            LabelAlerta.Visible = false;
            if (!IsPostBack)
            { 
            
            if (Session["NomePaciente"] == null &
            Session["RGPaciente"] == null &
            Session["CPFPaciente"] == null &
            Session["TelefonePaciente"] == null &
            Session["Sexo"] == null &
            Session["DataNacimentoPaciente"] == null &
            Session["opcao"].ToString() == "opcaoinserir")
            {

                Button_inserir.Visible = true;
                
            }
            else
            {
                Button_Gravar.Visible = true;
                LabelInformacao.Text = "Edição de Paciente";
               
                TextBox_Nome_Paciente.Text = HttpUtility.HtmlDecode(Session["NomePaciente"].ToString());
                TextBoxRG.Text = Session["RGPaciente"].ToString();
                TextBoxCPF.Text = Session["CPFPaciente"].ToString();
                TextBoxTEL.Text = Session["TelefonePaciente"].ToString();
                DropDownList1.Text = Session["Sexo"].ToString();
                TextBoxData.Text = Session["DataNacimentoPaciente"].ToString();
            }
          }
        }
        //Inserir
        protected void Button_inserir_Click(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }
            Label8.Visible = false;
            LabelRG.Visible = false;

            Page.MaintainScrollPositionOnPostBack = true;

            if (TextBox_Nome_Paciente.Text != "" & TextBoxRG.Text != "" & TextBoxCPF.Text != "" & DropDownList1.Text != "" & TextBoxTEL.Text != "" & TextBoxData.Text != "")
            {
                Boolean cpfValidar = false;
                ValCPF validarCPF = new ValCPF();
                PacienteBC pacienteBC = new PacienteBC();
                PacienteModel pacienteModel = new PacienteModel();
                TextBoxRG.Text = TextBoxRG.Text.Replace(".", "").Replace("-", "").Replace("'", "");
                TextBoxCPF.Text = TextBoxCPF.Text.Replace(".", "").Replace("-", "").Replace("'", "");
                TextBoxTEL.Text = TextBoxTEL.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace("'", "");

                cpfValidar = (Boolean)validarCPF.IsCpf(TextBoxCPF.Text);

                if (cpfValidar == true)
                {

                    pacienteModel.nome = TextBox_Nome_Paciente.Text.Replace("'", "");
                    pacienteModel.rg = TextBoxRG.Text;
                    pacienteModel.cpf = TextBoxCPF.Text;
                    pacienteModel.sexo = DropDownList1.Text;
                    pacienteModel.telefone = TextBoxTEL.Text.Replace("'", "");
                    pacienteModel.Data_Nascimento = TextBoxData.Text.Replace("'", "");
                    try
                    {

                        LabelAlerta.Visible = true;
                        LabelAlerta.Text = "<script>alert('" + pacienteBC.Inserir_Paciente(pacienteModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";
                    }
                    catch (DB2Exception)
                    {
                        LabelAlerta.Visible = true;
                        LabelAlerta.Text = "<script>alert('Não foi possível realizar a consulta, verifique a conexão com o banco de dados!')</script>";
                    
                    }
                }
                else
                {
                    Label8.Visible = true;
                }

            }
            else
            {
                Label7.Visible = true;
                Label8.Visible = true;
                Label9.Visible = true;
                Label10.Visible = true;

                LabelAlerta.Visible = true;
                LabelAlerta.Text = "<script>alert('Campos em Vermelho são Obrigatorios')</script>";
                
            }
        }
        //Editar
        protected void Button_Gravar_Click(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            Page.MaintainScrollPositionOnPostBack = true;
            Label8.Visible = false;
            LabelRG.Visible = false;

            PacienteBC pacienteBC = new PacienteBC();
            PacienteModel pacienteModel = new PacienteModel();

            if (TextBox_Nome_Paciente.Text != "" & TextBoxRG.Text != "" & TextBoxCPF.Text != "" & TextBoxTEL.Text != "" & TextBoxData.Text != "")
            {
                Boolean cpfValidar = false;
                ValCPF validarCPF = new ValCPF();
                TextBoxRG.Text = TextBoxRG.Text.Replace(".", "").Replace("-", "").Replace("'", "");
                TextBoxCPF.Text = TextBoxCPF.Text.Replace(".", "").Replace("-", "").Replace("'", "");
                TextBoxTEL.Text = TextBoxTEL.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace("'", "");


                 cpfValidar = (Boolean)validarCPF.IsCpf(TextBoxCPF.Text);

                 if (cpfValidar == true)
                 {
                     pacienteModel.id = Convert.ToInt32(Session["idPaciente"].ToString());
                     pacienteModel.nome = TextBox_Nome_Paciente.Text.Replace("'", "");
                     pacienteModel.rg = TextBoxRG.Text;
                     pacienteModel.cpf = TextBoxCPF.Text;
                     pacienteModel.sexo = DropDownList1.Text;
                     pacienteModel.telefone = TextBoxTEL.Text.Replace("'", "");
                     pacienteModel.Data_Nascimento = TextBoxData.Text.Replace("'", "");


                     LabelAlerta.Visible = true;
                     LabelAlerta.Text = "<script>alert('" + pacienteBC.Editar_Paciente(pacienteModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";
                     

                     Session["idPaciente"] = null;
                     Session["NomePaciente"] = null;
                     Session["RGPaciente"] = null;
                     Session["CPFPaciente"] = null;
                     Session["TelefonePaciente"] = null;
                     Session["Sexo"] = null;
                     Session["DataNacimentoPaciente"] = null;
                     Session["opcao"] = null;
                     Session["idPaciente"] = null;
                 }
                 else {
                     Label8.Visible = true;
                 
                 }
            }
            else
            {
                LabelAlerta.Visible = true;
                LabelAlerta.Text = "<script>alert('Verificar os Campos Antes da Edição')</script>";
            }
            
        }

       protected void MenuPrincipal_Click(object sender, EventArgs e)
        {
            Session["idPaciente"] = null;
            Session["NomePaciente"] = null;
            Session["RGPaciente"] = null;
            Session["CPFPaciente"] = null;
            Session["TelefonePaciente"] = null;
            Session["Sexo"] = null;
            Session["DataNacimentoPaciente"] = null;
            Session["opcao"] = null;
            Session["idPaciente"] = null;

            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }

       protected void TextBoxData_TextChanged(object sender, EventArgs e)
       {
           if (IsPostBack)
           {
               LabelAlerta.Visible = false;
               DateTime date = new DateTime();
               date.ToString("g", CultureInfo.CreateSpecificCulture("pt-BR"));
               try
               {

                   date = Convert.ToDateTime(TextBoxData.Text);


                   DateTime datemin = new DateTime();
                   datemin.ToString("g", CultureInfo.CreateSpecificCulture("pt-BR"));
                   datemin = Convert.ToDateTime("01/01/1850");
                   if (date > DateTime.Now)
                   {
                       LabelAlerta.Visible = true;
                       LabelAlerta.Text = "<script>alert('Data maior que a data a atual!')</script>";

                   }
                   else if (date < datemin)
                   {
                       LabelAlerta.Visible = true;
                       LabelAlerta.Text = "<script>alert('Data inválida!')</script>";

                   }
               }
               catch (FormatException)
               {
                   LabelAlerta.Visible = true;
                   LabelAlerta.Text = "<script>alert('Data em formato inválido, verifique mês/dia e ano!')</script>";
               }
           }
       }
        // Método que irá verificar se o cpf é válido
        // Se for irá buscar se o mesmo já existe
        // Se existir irá limpar o  text e mostrar mensagem
       protected void TextBoxCPF_TextChanged(object sender, EventArgs e)
       {
           Boolean cpfValidar;
           ValCPF validarCPF = new ValCPF();
           cpfValidar = validarCPF.IsCpf(TextBoxCPF.Text.Replace(".", "").Replace("-", "").Replace("'", ""));
           if (IsPostBack)
           {
               if (cpfValidar == false)
               {
                   TextBoxCPF.Text = "";
                   Label8.Text = "CPF Invalido";
                   Label8.Visible = true;
               }
               else {
                   PacienteBC paciBC = new PacienteBC();
                   PacienteModel paciModel = new PacienteModel();
                   TextBoxCPF.Text = TextBoxCPF.Text.Replace(".", "").Replace("-", "").Replace("'", "");

                   paciModel.cpf = TextBoxCPF.Text;
                   try
                   {
                       if (paciBC.consultar_CPF_Existente(paciModel).HasRows)
                       {
                           Label8.Visible = true;
                           Label8.Text = "CPF anterior já existente no cadastro de outro paciente";
                           TextBoxCPF.Text = "";
                          

                       }
                       else
                       {
                           Label8.Visible = false;
                       
                       }
                   }
                   catch (DB2Exception)
                   {
                       LabelAlerta.Visible = true;
                       LabelAlerta.Text = "<script>alert('Não foi possível verificar se o CPF já existe no banco de dados, por gentileza verifique a conexão com o banco de dados com o administrador!')</script>";
                   }
                   
               }
           }
       }

       protected void TextBoxRG_TextChanged1(object sender, EventArgs e)
       {
           PacienteBC paciBC = new PacienteBC();
           PacienteModel paciModel = new PacienteModel();
           TextBoxRG.Text = TextBoxRG.Text.Replace(".", "").Replace("-", "").Replace("'", "");
           paciModel.rg = TextBoxRG.Text;
           

           try
           {
               if (paciBC.consultar_RG_Existente(paciModel).HasRows)
               {

                   LabelRG.Visible = true;
                   LabelRG.Text = "RG anterior já existente no cadastro de outro paciente";
                   TextBoxRG.Text = "";

               }
               else {
                   LabelRG.Visible = true;
                   LabelRG.Text = "";
               }
           }
           catch (DB2Exception)
           {
               LabelAlerta.Visible = true;
               LabelAlerta.Text = "<script>alert('Não foi possível verificar se o RG já existe no banco de dados, por gentileza verifique a conexão com o banco de dados com o administrador!')</script>";
           }


       }
    }
}