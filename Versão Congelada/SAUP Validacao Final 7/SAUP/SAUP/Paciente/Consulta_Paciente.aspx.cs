using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Control;
using SAUP.Model;
using SAUP.Validadores;
using IBM.Data.DB2;

namespace SAUP
{
    public partial class Consulta_Paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            Page.MaintainScrollPositionOnPostBack = true;

        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
             try       {
            PacienteModel pacienteModel = new PacienteModel();
            PacienteBC pacienteBC = new PacienteBC();
            Session["Filtro"] = TextBoxConsulta.Text;
            Label_Pesquisa.Visible = false;

                if (RegularExpressionValidator1.IsValid)
                {
                    if (Session["Filtro"] != "")
                    {

                        Session["CampoDrop"] = DropDownList1.SelectedValue;

                        String filtroSelected = Session["CampoDrop"].ToString();

                        switch (filtroSelected)
                        {
                            case "Nome":
                                pacienteModel.nome = Session["Filtro"].ToString();
                                break;
                            case "RG":
                                pacienteModel.rg = Session["Filtro"].ToString();
                                break;
                            case "CPF":
                                pacienteModel.cpf = Session["Filtro"].ToString();
                                break;
                        }
                        // Banco sem acesso
                        try
                        {
                            if (pacienteBC.consultar_paciente(filtroSelected, pacienteModel).HasRows)
                            {

                                grid_resultado_busca_Usuarios.DataSource = pacienteBC.consultar_paciente(filtroSelected, pacienteModel);
                                grid_resultado_busca_Usuarios.DataBind();
                            }
                            else
                            {
                                Label_Pesquisa.Visible = true;
                                Label_Pesquisa.Text = "<script>alert('Não foram encontrados pacientes de acordo com os filtros selecionados!')</script>";
                                TextBoxConsulta.Text = "";
                                ButtonInserir.Visible = true;
                                grid_resultado_busca_Usuarios.DataBind();
                            }
                        }
                        catch (System.NullReferenceException)
                        {
                            Label_Pesquisa.Visible = true;
                            Label_Pesquisa.Text = "<script>alert('Não foi possível realizar a consulta, verifique a conexão com o banco de dados!')</script>";
                        
                        }
                        
                        

                           
                            

                        }
                    }
                    else
                    {
                        Label_Pesquisa.Visible = true;
                        Label_Pesquisa.Text = "<script>alert('Filtro em branco, por gentileza digite algum valor para buscar!')</script>";
                        grid_resultado_busca_Usuarios.DataBind();
                    }
                }    catch(DB2Exception)
                        {
                             Label_Pesquisa.Visible = true;
                             Label_Pesquisa.Text = "<script>alert('Não foi possível realizar a consulta, verifique a conexão com o banco de dados!')</script>";
                            }
        }    

        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            Session["opcao"] = "opcaoinserir";
            Session["NomePaciente"] = null;
            Session["RGPaciente"] = null;
            Session["CPFPaciente"] = null;
            Session["TelefonePaciente"] = null;
            Session["Sexo"] = null;
            Session["DataNacimentoPaciente"] = null;
            
            Response.Redirect("Manter_Paciente.aspx");
        }

        protected void grid_resultado_busca_Usuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Label_Pesquisa.Visible = true;
              

                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grid_resultado_busca_Usuarios.Rows[index];

                    ListItem item = new ListItem();
                    item.Text = row.Cells[1].Text + "    " +
                                row.Cells[2].Text + "    " +
                                row.Cells[3].Text + "    " +
                                row.Cells[4].Text + "    " +
                                row.Cells[5].Text + "    " +
                                row.Cells[6].Text + "    " +
                                row.Cells[7].Text;
                    Session["idPaciente"] = row.Cells[1].Text;
                    Session["NomePaciente"] = row.Cells[2].Text;
                    Session["RGPaciente"] = row.Cells[3].Text;
                    Session["CPFPaciente"] = row.Cells[4].Text;
                    Session["TelefonePaciente"] = row.Cells[5].Text;
                    Session["Sexo"] = row.Cells[6].Text;
                    Session["DataNacimentoPaciente"] = row.Cells[7].Text;


                    Session["opcao"] = "opcaoeditar";
                    Master.Page.Response.Redirect("Manter_Paciente.aspx", true);
                }
            
        }
        //Verificação dos Dados DropDownlist de Consulta, tratando com Regular Expression
        protected void DropDownList1_PreRender(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Nome")
            {
                TextBoxConsulta.Text = null;
                RegularExpressionValidator1.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RegularExpressionValidator1.ErrorMessage = "Somente letras para o nome";
                TextBoxConsulta.MaxLength = 100;
            }
            else if (DropDownList1.Text == "RG")
            {
                TextBoxConsulta.Text = null;
                RegularExpressionValidator1.ValidationExpression = "[0-9]+";
                RegularExpressionValidator1.ErrorMessage = "Somente números para o RG";
                TextBoxConsulta.MaxLength = 8;
            }
            else if (DropDownList1.Text == "CPF")
            {
                TextBoxConsulta.Text = null;
                RegularExpressionValidator1.ValidationExpression = "[0-9]+";
                RegularExpressionValidator1.ErrorMessage = " Somente números para o CPF";
                TextBoxConsulta.MaxLength = 11;
            }
        }

        protected void ButtonRetornarMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }
    }
}