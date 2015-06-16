using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Control;
using SAUP.Model;
using IBM.Data.DB2;


namespace SAUP
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Label_Pesquisa.Visible = false;
                Label_Pesquisa.Text = "";
            }
           if(Session["User_name"] == null)
            {
               Response.Redirect("~/Account/Logout.aspx");
            }
            
            Page.MaintainScrollPositionOnPostBack = true;
            

        }
        protected void ButtonBuscarAvaliacao_Click1(object sender, EventArgs e)
        {
            AcompanhamentoBC acompBc = new AcompanhamentoBC();
            PacienteModel paciModel = new PacienteModel();


            Session["Filtro"] = TextBoxFiltroAvalicao.Text;
            // Se o filtro existir
            if (IsPostBack)
            {
                Label_Pesquisa.Visible = false;

                if (Session["Filtro"] != "")
                {

                    Session["CampoDrop"] = DropDownListConsultaAvaliacao.SelectedValue;

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
                    //Tratamento para verificar se o banco esta ativo ou não
                    try{
                        //Se o banco estiver ativo então procure


                        if (acompBc.consulta_acompanhamento_By_Paciente(filtroDrop, paciModel).HasRows)
                        {
                            GridViewResultadosAcompanhamento.DataSource = acompBc.consulta_acompanhamento_By_Paciente(filtroDrop, paciModel);
                            GridViewResultadosAcompanhamento.DataBind();
                        }
                        else
                        {


                            TextBoxFiltroAvalicao.Text = "";
                            GridViewResultadosAcompanhamento.DataBind();
                            Label_Pesquisa.Visible = true;
                            Label_Pesquisa.Text = "<script>alert('Não foram encontrados registros de avaliação para o paciente')</script>";
                           // Cache.Get("<script>alert('Não foram encontrados registros de avaliação para o paciente')</script>");
                            InserirAvaliacao.Visible = true;


                        }
                    }catch(DB2Exception)
                    {

                        Label_Pesquisa.Visible = true;
                        Label_Pesquisa.Text = "<script>alert('Houve problemas para acessar o banco para a consulta de dados,verifique com o Administrador do sistema!')</script>";



                    }
                }
                else
                {
                    string script = "<script type=\"text/javascript\">alert('O filtro está em branco, por favor preencha');</script>";
                    GridViewResultadosAcompanhamento.DataBind();
                    // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "alert", script);
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "alert", script);
                    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "alert", "");
                    //Label_Pesquisa.Visible = true;
                     //Label_Pesquisa.Text = "<script>alert('O filtro está em branco, por favor preencha')</script>";


                }


            }
            else {

                Label_Pesquisa.Visible = false;
                }
         
        }

        protected void grid_resultado_busca_avaliacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Label_Pesquisa.Visible = false;
                if (IsPostBack)
                {
                    if (GridViewResultadosAcompanhamento.SelectedDataKey != null)
                    {
                        int index = Convert.ToInt32(e.CommandArgument);
                        GridViewRow row = GridViewResultadosAcompanhamento.Rows[index];

                        //ListItem item = new ListItem();
                        //item.Text = row.Cells[2].Text + "    " +
                        //            row.Cells[3].Text + "    " +
                        //            row.Cells[4].Text + "    " +
                        //            row.Cells[5].Text + "    " +
                        //            row.Cells[6].Text + "    " +
                        //            row.Cells[7].Text + "    " +
                        //            row.Cells[8].Text + "    " +
                        //            row.Cells[9].Text + "    " +
                        //            row.Cells[10].Text;


                        //Session["Nome_Paciente_Acomp"] = row.Cells[2].Text;
                        //Session["RG"] = row.Cells[3].Text;
                        //Session["CPF"] = row.Cells[4].Text;
                        //Session["Status_Acompanhamento"] = row.Cells[5].Text;
                        //Session["Data_Realizacao_Acompanhamento"] = row.Cells[6].Text;

                        // Recupera o id selecionado de acompanhamento para edicao e geracao de novo acompanhamento
                        Session["ID_Acompanhamento_Edicao"] = GridViewResultadosAcompanhamento.SelectedPersistedDataKey.Value;

                        Response.Redirect("EditarAcompanhamento.aspx", true);

                    }
                    else
                    {
                        Label_Pesquisa.Visible = true;
                        Label_Pesquisa.Text = "<script>alert('Selecione um Acompanhamento')</script>";
                    }
                }
            }
        }

        protected void grid_resultado_busca_avaliacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ID_Acompanhamento_Edicao"] = Convert.ToInt32(GridViewResultadosAcompanhamento.SelectedPersistedDataKey.Value);
        }

        protected void DropDownListConsultaAvaliacao_PreRender(object sender, EventArgs e)
        {
            if (DropDownListConsultaAvaliacao.Text == "Nome")
            {
                TextBoxFiltroAvalicao.Text = null;
                RequireValidatorFiltroAcompanhamento.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RequireValidatorFiltroAcompanhamento.ErrorMessage = "Somente letras para o nome";
                TextBoxFiltroAvalicao.MaxLength = 100;

            }
            else if (DropDownListConsultaAvaliacao.Text == "RG")
            {
                TextBoxFiltroAvalicao.Text = null;
                RequireValidatorFiltroAcompanhamento.ValidationExpression = "[0-9]+";
                RequireValidatorFiltroAcompanhamento.ErrorMessage = "Somente números para o RG";

                TextBoxFiltroAvalicao.MaxLength = 8;
            }
            else if (DropDownListConsultaAvaliacao.Text == "CPF")
            {
                TextBoxFiltroAvalicao.Text = null;
                RequireValidatorFiltroAcompanhamento.ValidationExpression = "[0-9]+";
                RequireValidatorFiltroAcompanhamento.ErrorMessage = " Somente números para o CPF";

                TextBoxFiltroAvalicao.MaxLength = 11;
            }
        }

        protected void InserirAvaliacao_Click(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }
            else
            {

                Response.Redirect("~/Acompanhamento/Acompanhamento.aspx");
            }
            
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }
            else
            {

                Response.Redirect("~/Monitoramento/Monitoramento.aspx");
            }
        }


    }
}
