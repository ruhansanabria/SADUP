using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.DAO;
using SAUP.Control;
using SAUP.Model;
using IBM.Data.DB2;

namespace SAUP
{
    public partial class Consulta_Tratamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void ButtonTrat_Click(object sender, EventArgs e)
        {
            TratamentoBC tratBc = new TratamentoBC();
            TratamentoModel tratModel = new TratamentoModel();
            TipoTratamentoModel tipoTratModel = new TipoTratamentoModel();

            Session["FiltroTrat"] = TextBoxFiltro.Text;
            Label_Pesquisa.Visible = false;
                if (Session["FiltroTrat"] != "")
                {

                    Session["CampoDropTrat"] = DropDownListTrat.SelectedValue;
                    String filtroTrat = Session["CampoDropTrat"].ToString();
                    switch (filtroTrat)
                    {
                        // Adiciona no TipoTratModel para usar no join depois
                        case "Tipo Tratamento":
                            tipoTratModel.DESCRICAO = Session["FiltroTrat"].ToString();
                            break;
                        case "Descrição Tratamento":
                            tratModel.descricaotratamento = Session["FiltroTrat"].ToString();
                            break;
                        case "Periodicidade":
                            tratModel.periodicidade = Session["FiltroTrat"].ToString();
                            break;
                    }
                    try
                    {
                        if (tratBc.consultar_Tratamento(filtroTrat, tratModel, tipoTratModel).HasRows)
                        {
                            grid_resultado_busca_Tratamento.DataSource = tratBc.consultar_Tratamento(filtroTrat, tratModel, tipoTratModel);
                            grid_resultado_busca_Tratamento.DataBind();
                        }
                    }
                    catch (DB2Exception)
                    {
                        Label_Pesquisa.Visible = true;
                        Label_Pesquisa.Text = "<script>alert('Não foi possível realizar a busca, verifique a conexão com o banco de dados!')</script>";
                    }
                   
                }
                else
                {
                    Label_Pesquisa.Visible = true;
                    Label_Pesquisa.Text = "<script>alert('Digite um valor para busca')</script>";
                    grid_resultado_busca_Tratamento.DataBind();
                }
        }

        protected void grid_resultado_busca_Tratamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            TratamentoBC tratBC = new TratamentoBC();
            TratamentoModel tratamento = new TratamentoModel();
            tratamento.id_tratamento = (int)grid_resultado_busca_Tratamento.SelectedDataKey.Value;
            GridViewProcedimentosVinculados.DataSource = tratBC.retorna_procedimento_vinculado(tratamento);
            GridViewProcedimentosVinculados.DataBind();
            GridViewProdutosVinculados.DataSource = tratBC.retorna_produto_vinculado(tratamento);
            GridViewProdutosVinculados.DataBind();
        }

        protected void ButtonManter_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manter_Tratamento.aspx");
        }

        protected void DropDownListTrat_PreRender(object sender, EventArgs e)
        {
            if (DropDownListTrat.Text == "Descrição Tratamento")
            {
                TextBoxFiltro.Text = null;
                RegularExpressionValidator1.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RegularExpressionValidator1.ErrorMessage = "Somente letras para a descrição";
                TextBoxFiltro.MaxLength = 50;
                TextBoxFiltro.ToolTip = "Tratamento Estágio I \n"  +
                                        "Tratamento Estágio II \n" +
                                        "Tratamento Estágio III \n" +
                                        "Tratamento Estágio IV";
            }
            else if (DropDownListTrat.Text == "Tipo Tratamento")
            {
                TextBoxFiltro.Text = null;
                RegularExpressionValidator1.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RegularExpressionValidator1.ErrorMessage = "Somente letras para o tipo de tratamento";
                TextBoxFiltro.MaxLength = 30;
                TextBoxFiltro.ToolTip = "Preventivo \n" +
                                        "Corretivo";
            }
            else if (DropDownListTrat.Text == "Periodicidade")
            {
                TextBoxFiltro.Text = null;
                RegularExpressionValidator1.ValidationExpression = "^([0-9,a-z,A-Z]+)";
                RegularExpressionValidator1.ErrorMessage = "Números e letras para a periodicidade";
                TextBoxFiltro.MaxLength = 30;
                TextBoxFiltro.ToolTip = "12Horas \n"+
                                        "24Horas";
            }
        }
    }
}