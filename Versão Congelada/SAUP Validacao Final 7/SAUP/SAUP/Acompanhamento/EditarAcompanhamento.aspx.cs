using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Model;
using SAUP.Control;
using System.Text;
using IBM.Data.DB2;
using System.Data;

namespace SAUP
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        private int percepcaoSensorial;
        private int umidade;
        private int atividadefisica;
        private int mobilidade;
        private int nutricao;
        private int friccao_cisalhamento;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            String hiddenFieldValue = hidLastTab.Value;
            StringBuilder js = new StringBuilder();
            js.Append("<script type='text/javascript'>");
            js.Append("var previouslySelectedTab = ");
            js.Append(hiddenFieldValue);
            js.Append(";</script>");
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "acttab", js.ToString());
            //this.Header.Controls.Add(new LiteralControl(js.ToString()));
            Page.MaintainScrollPositionOnPostBack = true;

            // Validacao Session User name
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            if (Session["ID_Acompanhamento_Edicao"] != null)
            {
                AcompanhamentoModel acomp = new AcompanhamentoModel();
                AcompanhamentoBC acomBc = new AcompanhamentoBC();

                acomp.Id_acompanhamento = Convert.ToInt32(Session["ID_Acompanhamento_Edicao"].ToString());
                DetailsViewInformacoesAcompSelecionado.DataSource = acomBc.consulta_acompanhamentoByID(acomp);
                DetailsViewInformacoesAcompSelecionado.DataBind();
                if (acomBc.consulta_Historico_AcompanhamentoByID(acomp) != null)
                {
                    GridViewHistorico.DataSource = acomBc.consulta_Historico_AcompanhamentoByID(acomp);
                    
                    GridViewHistorico.DataBind();
                }
                else
                {
                    GridViewHistorico.DataBind();
                }

            }
            else
            {
                Response.Redirect("~/Acompanhamento/Consulta_Acompanhamento.aspx");
            }
            TextBoxInformacoes.Attributes.Add("maxlength", "1000");
            TextBoxNomeAnexo.Attributes.Add("maxlength", "300");
        }

        protected void Button_GravarRespostas_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                if (RadioPercepcaoSensorial.SelectedItem != null &
                   RadioButtonListUmidade.SelectedItem != null &
                   RadioButtonListAtividadeFisica.SelectedItem != null &
                   RadioButtonListMobilidade.SelectedItem != null &
                   RadioButtonListNutricao.SelectedItem != null &
                   RadioButtonListFriccaoCisalhamento.SelectedItem != null)
                {


                    percepcaoSensorial = Convert.ToInt32(RadioPercepcaoSensorial.SelectedValue);
                    umidade = Convert.ToInt32(RadioButtonListUmidade.SelectedValue);
                    atividadefisica = Convert.ToInt32(RadioButtonListAtividadeFisica.SelectedValue);
                    mobilidade = Convert.ToInt32(RadioButtonListMobilidade.SelectedValue);
                    nutricao = Convert.ToInt32(RadioButtonListNutricao.SelectedValue);
                    friccao_cisalhamento = Convert.ToInt32(RadioButtonListFriccaoCisalhamento.SelectedValue);


                    EscalaBraden.EscalaBraden escala = new EscalaBraden.EscalaBraden();

                    TextBox_Pontuacao.Text = Convert.ToString(escala.calcula_braden(percepcaoSensorial, umidade, atividadefisica, mobilidade, nutricao, friccao_cisalhamento));
                    // TextBox_Pontuacao.Enabled=false;
                    //Conjunto de testes para definir qual cor e qual mensagem aparecera para informar
                    // O risco para desenvolver Up

                    // Risco Alto  menor que 13
                    if (Convert.ToInt32(TextBox_Pontuacao.Text) < 13)
                    {

                        TextBox_Pontuacao.BackColor = System.Drawing.Color.Red;
                        LabelMensagemRiscoUP.Visible = true;
                        LabelMensagemRiscoUP.Text = "Alto Risco";
                        ImageRisk.Visible = true;
                        ImageRisk.ImageUrl = "~/Images/redrisk.jpg";
                        ImageRisk.AlternateText = "Red";
                        LabelMensagemRiscoUP.ForeColor = System.Drawing.Color.Red;
                    }
                    // Se for entre 13 e 15, risco moderado
                    else if (Convert.ToInt32(TextBox_Pontuacao.Text) >= 13 && Convert.ToInt32(TextBox_Pontuacao.Text) <= 15)
                    {

                        TextBox_Pontuacao.BackColor = System.Drawing.Color.Orange;
                        LabelMensagemRiscoUP.Visible = true;
                        LabelMensagemRiscoUP.Text = "Risco Moderado";
                        ImageRisk.Visible = true;
                        ImageRisk.ImageUrl = "~/Images/riskoragen.jpg";
                        ImageRisk.AlternateText = "Orange";
                        LabelMensagemRiscoUP.ForeColor = System.Drawing.Color.Orange;

                    }
                    // Se for entre 15 e  18, então baixo risco
                    else if (Convert.ToInt32(TextBox_Pontuacao.Text) > 15 && Convert.ToInt32(TextBox_Pontuacao.Text) <= 18)
                    {
                        TextBox_Pontuacao.BackColor = System.Drawing.Color.Green;
                        LabelMensagemRiscoUP.Visible = true;
                        LabelMensagemRiscoUP.Text = "Baixo Risco";
                        ImageRisk.Visible = true;
                        ImageRisk.ImageUrl = "~/Images/riskgreen.jpg";
                        ImageRisk.AlternateText = "Green";
                        LabelMensagemRiscoUP.ForeColor = System.Drawing.Color.Green;

                    }
                    else if (Convert.ToInt32(TextBox_Pontuacao.Text) > 18)
                    {
                        TextBox_Pontuacao.BackColor = System.Drawing.Color.Blue;
                        LabelMensagemRiscoUP.Visible = true;
                        LabelMensagemRiscoUP.Text = "Nenhum risco";
                        ImageRisk.Visible = true;
                        ImageRisk.ImageUrl = "~/Images/riskblue.jpg";
                        ImageRisk.AlternateText = "Blue";
                        LabelMensagemRiscoUP.ForeColor = System.Drawing.Color.Blue;

                    }
                }
            }
        }

        protected void ButtonGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {

                    if (Session["ID_Acompanhamento_Edicao"] != null)
                    {
                        if (Session["User_name"] == null)
                        {
                            Response.Redirect("~/Account/Logout.aspx");

                        }
                        else
                        {
                            //Se for nulo joga mensagem em tela e não grava
                            if (gridviewlistagemStatusAcomp.SelectedDataKey == null)
                            {

                                TextBoxStatusValidator.Text = "";

                            }
                            else
                            {

                                AcompanhamentoBC acompBC = new AcompanhamentoBC();
                                AcompanhamentoModel acompModel = new AcompanhamentoModel();
                                EnfermeiroBC enfBC = new EnfermeiroBC();
                                EnfermeiroModel enfModel = new EnfermeiroModel();
                                AnexoModel anexo = new AnexoModel();


                                acompModel.Id_acompanhamento = Convert.ToInt32(Session["ID_Acompanhamento_Edicao"].ToString());

                                acompModel.Id_tratamento = Convert.ToInt32(GridViewLIstagem.SelectedDataKey.Value);
                                //Retorna o ID_do_Status do Acompanhamento  que sera atualizado

                                acompModel.Status_Acompanhamento = Convert.ToInt32(acompBC.retorna_StatusAcompahamentoByID(acompModel));
                                //retorna o ID do paciente deste acompanhamento
                                acompModel.Id_Paciente = Convert.ToInt32(acompBC.retorna_PacienteAcompahamentoByID(acompModel));
                                //Recuperar o user_name logado
                                ////Recuperar o user_name logado
                                enfModel.Nome = Session["User_name"].ToString();


                                acompModel.id_enfermeiro = enfBC.retorna_EnfIDByUsername(enfModel);

                                acompModel.Informacoes_Complementares = TextBoxInformacoes.Text.Replace("'", "");
                                acompModel.prioridade = DropPrioridade.SelectedValue;
                                acompModel.pontuacao = Convert.ToInt32(TextBox_Pontuacao.Text);

                                //Se for nulo joga mensagem em tela e não grava
                                if (GridViewLIstagem.SelectedDataKey == null)
                                {
                                    TextBoxSelectedTrat.Text = "";



                                }
                                else
                                {
                                    TextBoxSelectedTrat.Text = "selected";
                                    acompModel.Id_tratamento = Convert.ToInt32(GridViewLIstagem.SelectedDataKey.Value);
                                }
                                if (gridviewlistagemStatusAcomp.SelectedDataKey != null & GridViewLIstagem.SelectedDataKey != null)
                                {

                                    //finalizado
                                    if (Convert.ToInt32(gridviewlistagemStatusAcomp.SelectedDataKey.Value) == 1)
                                    {
                                        acompModel.flag_alta = 0;
                                    }
                                    //Em andamento
                                    else if (Convert.ToInt32(gridviewlistagemStatusAcomp.SelectedDataKey.Value) == 2)
                                    {
                                        acompModel.flag_alta = 1;
                                    }

                                    try
                                    {
                                        mensagem.Visible = true;
                                        mensagem.Text = "<script>alert('" + acompBC.atualizar_acompanhamento(acompModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";

                                        if (FileUpload_Anexo.HasFile)
                                        {

                                            string pastaimagens = Server.MapPath("~/Images/Anexos/");
                                            FileUpload_Anexo.SaveAs(pastaimagens + FileUpload_Anexo.FileName);
                                            anexo.nome_Anexo = TextBoxNomeAnexo.Text.Replace("'", "");
                                            anexo.caminho = FileUpload_Anexo.FileName;

                                            acompBC.inserir_anexo(anexo, acompModel);

                                        }
                                    }


                                    catch (DB2Exception)
                                    {
                                        String errorFile = "<script>alert('Não foi possível salvar os dados, verifique a conexão com o banco de dados com o administrador do sistema')</script>";
                                        mensagem.Visible = true;
                                        mensagem.Text = errorFile;

                                    }


                                }
                            }
                        }
                    }
                }//fecha if is valid
                else
                {
                    Response.Redirect("~/Account/Logout.aspx");
                }

            }
            catch (System.NullReferenceException)
            {
                String errorFile = "<script>alert('Não foi possível salvar os dados, verifique a conexão com o banco de dados com o administrador do sistema')</script>";
                mensagem.Visible = true;
                mensagem.Text = errorFile;
                           
            }

            }//fecha

        

                
        protected void GridViewResultPaciente_Load(object sender, EventArgs e)
        {
          //  GridViewResultPaciente.DataBind();
            //int selected_last = Convert.ToInt32(Session["ID_Acompanhamento_Edicao"].ToString());
            //GridViewResultPaciente.SelectedPersistedDataKey = (DataKey)GridViewResultPaciente.SelectedDataKey[selected_last];
        }

        protected void Button_Busca_Click(object sender, EventArgs e)
        {

        }

       

        protected void GridViewLIstagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxSelectedTrat.Text = "Selected";
              TratamentoBC tratBC = new TratamentoBC();
            TratamentoModel tratamento = new TratamentoModel();
            tratamento.id_tratamento = (int)GridViewLIstagem.SelectedDataKey.Value;
            GridViewProcedimentosVinculados.DataSource = tratBC.retorna_procedimento_vinculado(tratamento);
            GridViewProcedimentosVinculados.DataBind();
            GridViewProdutosVinculados.DataSource = tratBC.retorna_produto_vinculado(tratamento);
            GridViewProdutosVinculados.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }
      

        protected void ButtonCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Acompanhamento/Consulta_Acompanhamento.aspx");
        }

        protected void gridviewlistagemStatusAcomp_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxStatusValidator.Text = "Selected";
        }
    }
}