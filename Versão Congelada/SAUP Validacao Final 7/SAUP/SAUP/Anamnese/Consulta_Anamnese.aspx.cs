using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Control;
using SAUP.Model;

namespace SAUP
{
    public partial class Consulta_Anamnese : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }


            if (IsPostBack)
            {
                Alerta.Visible = false;
                Alerta.Text = "";
            }
            Page.MaintainScrollPositionOnPostBack = true;

        }

        protected void Button_Busca_Click(object sender, EventArgs e)
        {
            PacienteModel paciModel = new PacienteModel();
            AnamneseBC anamneseBC = new AnamneseBC();
            Session["Filtro"] = TextBox_Consulta.Text;
            Label_Pesquisa.Visible = false;


            if (RegularExpressionValidator1.IsValid)
            {

                if (Session["Filtro"] != "")
                {

                    Session["CampoDrop"] = DropDownList1.SelectedValue;

                    String filtroDrop = Session["CampoDrop"].ToString();
                    switch (filtroDrop)
                    {
                        case "Nome":
                            paciModel.nome = Session["Filtro"].ToString();
                            break;
                        case "RG":
                            paciModel.rg = Session["Filtro"].ToString();
                            break;
                        case "CPF":
                            paciModel.cpf = Session["Filtro"].ToString();
                            break;

                    }

                    //Se houver registros de retorno de acordo com o filtro, logo atribua ao Data Source
                    //Senao View deve tratar com mensagem
                    if(anamneseBC.consultar_AnamnesePaci(Session["CampoDrop"].ToString(), paciModel)!= null)
                    {
                    if (anamneseBC.consultar_AnamnesePaci(Session["CampoDrop"].ToString(), paciModel).HasRows)
                    {
                        grid_resultado_busca_anamnese.DataSource = anamneseBC.consultar_AnamnesePaci(Session["CampoDrop"].ToString(), paciModel);
                        grid_resultado_busca_anamnese.DataBind();

                    }
                    //View retorna mensagem
                    else
                    {
                        Label_Pesquisa.Visible = true;
                        Label_Pesquisa.Text = "<script>alert('Não foram encontrados registros de Anamnese com os critérios selecionados!')</script>";
                        TextBox_Consulta.Text = "";
                        Insert_Anamnese_Button.Visible = true;
                        grid_resultado_busca_anamnese.DataBind();


                    }
                    }else
                    {
                         Label_Pesquisa.Visible = true;
                         Label_Pesquisa.Text = "<script>alert('Não foi possível realizar a consulta, verifique a conexão com o banco de dados!')</script>";
                    
                    }

                }
                else
                {

                    Label_Pesquisa.Visible = true;
                    Label_Pesquisa.Text = "<script>alert('Filtro em Branco, por gentileza preencher com um critério')</script>";
                    grid_resultado_busca_anamnese.DataBind();


                }

            }
            else
            {
                Label_Pesquisa.Visible = true;
                Label_Pesquisa.Text = "<script>alert('Favor Somente Numeros para Busca')</script>";
            }


        }

        protected void grid_resultado_busca_anamnese_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            if (IsPostBack)
            { 
            if (e.CommandName == "Editar")
            {
                if (grid_resultado_busca_anamnese.SelectedDataKey != null)
                {
                    Alerta.Visible = false;


                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grid_resultado_busca_anamnese.Rows[index];

                    ListItem item = new ListItem();
                    item.Text = row.Cells[2].Text + "    " +
                                row.Cells[3].Text + "    " +
                                row.Cells[4].Text + "    " +
                                row.Cells[5].Text + "    " +
                                row.Cells[6].Text;

                    Session["Nome_Paciente"] = row.Cells[2].Text;
                    Session["Data_Realizacao"] = row.Cells[3].Text;
                    Session["Histor_Doencas"] = row.Cells[4].Text;
                    Session["Histor_Familiar"] = row.Cells[5].Text;
                    Session["Infor_Adi"] = row.Cells[6].Text;



                    AnamneseModel anamneseMOdel = new AnamneseModel();

                    //grid_resultado_busca_anamnese.SelectRow(grid_resultado_busca_anamnese.SelectedRow.RowIndex);
                    anamneseMOdel.id_Paciente = Convert.ToInt32(grid_resultado_busca_anamnese.SelectedPersistedDataKey.Value);


                    Session["ID_PACIENTE"] = (int)anamneseMOdel.id_Paciente;
                    Master.Page.Response.Redirect("Manter_Anamnese.aspx", true);
                }
                else {
                    Alerta.Visible = true;
                    Alerta.Text = "<script>alert('Por favor, selecione Anamnese para Edição')</script>";
                   
                }
            }

        }

       
        }
        protected void Insert_Anamnese_Button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manter_Anamnese.aspx");
        }

        protected void DropDownList1_PreRender(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Nome")
            {
                TextBox_Consulta.Text = null;
                RegularExpressionValidator1.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RegularExpressionValidator1.ErrorMessage = "Somente Letras para Nome";
                TextBox_Consulta.MaxLength = 100;
            }
            else if (DropDownList1.Text == "RG")
            {
                TextBox_Consulta.Text = null;
                RegularExpressionValidator1.ValidationExpression = "[0-9]+";
                RegularExpressionValidator1.ErrorMessage = " Somente números para RG";
                TextBox_Consulta.MaxLength = 8;
            }
            else if (DropDownList1.Text == "CPF")
            {
                TextBox_Consulta.Text = null;
                RegularExpressionValidator1.ValidationExpression = "[0-9]+";
                RegularExpressionValidator1.ErrorMessage = " Somente números para CPF";
                TextBox_Consulta.MaxLength = 11;
            }
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }


       

       
    }
}