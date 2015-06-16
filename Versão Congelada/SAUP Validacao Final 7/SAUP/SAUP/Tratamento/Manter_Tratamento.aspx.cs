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
    public partial class Manter_Tratamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            Page.MaintainScrollPositionOnPostBack = true;
            //zerarlabel de Mensagem
            LabelMensagem.Visible = false;
        }
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {

            Session["ID_TRATAMENTO"] = null;
            Session["CLASSIFICACAO"] = null;
            Session["DESCRICAOTRATAMENTO"] = null;
            Session["PERIODICIDADE"] = null;
            Session["PERIODICIDADE"] = null;
            Session["PROCEDIMENTOS"] = null;

            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }
        protected void Button_Salvar_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                try
                {
                    TratamentoBC tratBC = new TratamentoBC();
                    TratamentoModel tratModel = new TratamentoModel();

                    //Verificar se Clicaram no Tratamento
                    if (GridViewTipoTrat.SelectedDataKey != null)
                    {
                        foreach (GridViewRow row in GridViewProdutos.Rows)
                        {

                            CheckBox checkeditemsproduto = (CheckBox)row.FindControl("CheckBox_ProductSelection");

                            if (checkeditemsproduto != null && checkeditemsproduto.Checked != false)
                            {
                                int produtoID = Convert.ToInt32(GridViewProdutos.DataKeys[row.RowIndex].Value);

                                TratamentoBC trat = new TratamentoBC();
                                ProdutoModel produto = new ProdutoModel();
                                TratamentoModel tratamento = new TratamentoModel();
                                //Captura o tratamento selecionado
                                tratamento.id_tratamento = (int)GridViewTipoTrat.SelectedDataKey.Value;
                                //Captura o tipo de tratamento a partir do tratamento selecionado
                                tratamento.id_tipo_tratamento = (int)trat.retorna_tipo_Tratamento_By_ID_Tratamento(tratamento);
                                produto.id = produtoID;
                                if (trat.vincula_Produto(tratamento, produto) != "")
                                {
                                    trat.vincula_Produto(tratamento, produto);
                                }
                                LabelMensagem.Visible = true;
                                LabelMensagem.Text = "<script>alert('Vinculação de Produtos , realizada com sucesso');location.href='../Monitoramento/Monitoramento.aspx';</script>";

                            }
                        }
                        // Capturar os procedimentos

                        foreach (GridViewRow row in GridViewProcedimentos.Rows)
                        {

                            CheckBox checkeditemsprocedimento = (CheckBox)row.FindControl("CheckBox_ProcedimentoSelection");

                            if (checkeditemsprocedimento != null && checkeditemsprocedimento.Checked != false)
                            {
                                int procedimentoID = Convert.ToInt32(GridViewProcedimentos.DataKeys[row.RowIndex].Value);

                                TratamentoBC trat = new TratamentoBC();
                                ProcedimentoModel procedimento = new ProcedimentoModel();
                                TratamentoModel tratamento = new TratamentoModel();
                                //Captura o tratamento selecionado
                                tratamento.id_tratamento = (int)GridViewTipoTrat.SelectedDataKey.Value;
                                //Captura o tipo de tratamento a partir do tratamento selecionado
                                tratamento.id_tipo_tratamento = (int)trat.retorna_tipo_Tratamento_By_ID_Tratamento(tratamento);
                                procedimento.id = procedimentoID; ;
                                if (trat.vincula_Procedimento(tratamento, procedimento) != "")
                                {
                                    trat.vincula_Procedimento(tratamento, procedimento);
                                }
                                LabelMensagem.Visible = true;
                                LabelMensagem.Text = "<script>alert('Vinculação de Procedimentos/Produtos, realizada com sucesso');location.href='../Monitoramento/Monitoramento.aspx';</script>";

                            }
                        }
                       
                    }
                    else
                    {
                        LabelMensagem.Visible = true;
                        LabelMensagem.Text = "<script>alert('Favor Selecionar um Tratamento!')</script>";

                    }
                }
                catch (DB2Exception)
                {
                    LabelMensagem.Visible = true;
                    LabelMensagem.Text = "<script>alert('Não possível realizar o vínculo de produtos/procedimentos, verifique a conexão com o banco de dados')</script>";
                
                }
            }
        }
        protected void ButtonMenuPrincipal_Click(object sender, EventArgs e)
        {
            Session["ID_TRATAMENTO"] = null;
            Session["CLASSIFICACAO"] = null;
            Session["DESCRICAOTRATAMENTO"] = null;
            Session["PERIODICIDADE"] = null;
            Session["PERIODICIDADE"] = null;
            Session["PROCEDIMENTOS"] = null;

            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }
    }
}
