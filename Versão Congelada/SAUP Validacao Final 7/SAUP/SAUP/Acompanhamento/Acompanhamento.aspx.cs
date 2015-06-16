using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
using SAUP.Control;
using SAUP.Model;
using System.Text;
using IBM.Data.DB2;

namespace SAUP
{
    public partial class WebForm5 : System.Web.UI.Page
    {
       private int percepcaoSensorial;
        private int umidade;
        private int atividadefisica;
        private int mobilidade;
        private int nutricao;
        private int friccao_cisalhamento;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Carrega a Grid com Empty Template
            if (!IsPostBack)
            {
                GridViewResultPaciente.DataBind();
            }
            TextBoxNomeAnexo.Attributes.Add("maxlength", "300");


            String hiddenFieldValue = hidLastTab.Value;
            StringBuilder js = new StringBuilder();
            js.Append("<script type='text/javascript'>");
            js.Append("var previouslySelectedTab = ");
            js.Append(hiddenFieldValue);
            js.Append(";</script>");
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "acttab", js.ToString());
            //this.Header.Controls.Add(new LiteralControl(js.ToString()));
            if (IsPostBack)
            {
               
                mensagem.Visible = false;
            }
            
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }
            Page.MaintainScrollPositionOnPostBack = true;
            TextBoxInformacoes.Attributes.Add("maxlength", "1000");

        }

        protected void OnPreRender(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }
            if (DropDownListFiltro.Text == "Nome")
            {
                TextBox_Consulta.Text = null;
                RequireValidatorFiltroPacienteAcomp.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RequireValidatorFiltroPacienteAcomp.ErrorMessage = "Somente letras para o nome";
                TextBox_Consulta.MaxLength = 100;
                RequireValidatorFiltroPacienteAcomp.SetFocusOnError = true;

            }
            else if (DropDownListFiltro.Text == "RG")
            {
                TextBox_Consulta.Text = null;
                RequireValidatorFiltroPacienteAcomp.ValidationExpression = "[0-9]+";
                RequireValidatorFiltroPacienteAcomp.ErrorMessage = "Somente números para o RG";
                RequireValidatorFiltroPacienteAcomp.SetFocusOnError = true;

                TextBox_Consulta.MaxLength = 8;
            }
            else if (DropDownListFiltro.Text == "CPF")
            {
                TextBox_Consulta.Text = null;
                RequireValidatorFiltroPacienteAcomp.ValidationExpression = "[0-9]+";
                RequireValidatorFiltroPacienteAcomp.ErrorMessage = " Somente números para o CPF";
                RequireValidatorFiltroPacienteAcomp.SetFocusOnError = true;

                TextBox_Consulta.MaxLength = 11;
            }
            else if (TextBox_Consulta.Text == "")
            {
                TextBox_Consulta.Text = null;
                RequireValidatorFiltroPacienteAcomp.ErrorMessage = "Filtro de Busca de paciente em branco,por gentileza verifique-o.";
            }
        
        }

        protected void Button_GravarRespostas_Click(object sender, EventArgs e)
        {

            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            
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


        protected void ButtonGravar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {

                    if (Session["User_name"] == null)
                    {
                        Response.Redirect("~/Account/Logout.aspx");
                    }
                    else
                    {
                        AcompanhamentoBC acompBC = new AcompanhamentoBC();
                        AcompanhamentoModel acompModel = new AcompanhamentoModel();
                        EnfermeiroBC enfBC = new EnfermeiroBC();
                        EnfermeiroModel enfModel = new EnfermeiroModel();
                        AnexoModel anexo = new AnexoModel();


                        //Se for nulo joga mensagem em tela e não grava
                        if (gridviewlistagemStatusAcomp.SelectedDataKey == null)
                        {

                            TextBoxStatusValidator.Text = "";


                        }
                        else
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
                            //Retorna o ID_do_Status do Acompanhamento  que sera atualizado
                            acompModel.Status_Acompanhamento = Convert.ToInt32(gridviewlistagemStatusAcomp.SelectedDataKey.Value);
                        }
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

                        ////retorna o ID do paciente deste acompanhamento
                        //Se for nulo joga mensagem em tela e não grava
                        if (GridViewResultPaciente.SelectedDataKey == null)
                        {
                            //TextBoxPaciente.Text = "";
                            //RequiredFieldValidatorSelectedPaciente.ControlToValidate="TextBoxPaciente" ;
                            //RequiredFieldValidatorSelectedPaciente.ErrorMessage = "Favor selecionar um paciente - Passo 1";
                            //Page.Validate();

                        }
                        else
                        {
                            acompModel.Id_Paciente = Convert.ToInt32(GridViewResultPaciente.SelectedDataKey.Value);
                        }

                        ////Recuperar o user_name logado
                        enfModel.Nome = Session["User_name"].ToString();
                        ////Faz o select para obter o id do user
                        acompModel.id_enfermeiro = enfBC.retorna_EnfIDByUsername(enfModel);
                        acompModel.Informacoes_Complementares = TextBoxInformacoes.Text.Replace("'", "");
                        acompModel.prioridade = DropPrioridade.SelectedValue;
                        acompModel.pontuacao = Convert.ToInt32(TextBox_Pontuacao.Text);
                        try
                        {
                            mensagem.Visible = true;
                            mensagem.Text = "<script>alert('" + acompBC.inserir_acompanhamento(acompModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";
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
                            String errorFile = "<script>alert('Não foi possível salvar os dados, verifique a conexão com o banco de dados com o administrador do sistema'')</script>";
                            mensagem.Visible = true;
                            mensagem.Text = errorFile;

                        }

                    }


                }
            }
            catch (System.NullReferenceException)
            {

                String errorFile = "<script>alert('Não foi possível salvar os dados, verifique a conexão com o banco de dados com o administrador do sistema')</script>";
                mensagem.Visible = true;
                mensagem.Text = errorFile;
            }
                    
            
        }

        protected void Button_Busca_Click(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }
            else
            {
                PacienteModel paciModel = new PacienteModel();
                PacienteBC paciBC = new PacienteBC();
                Session["Filtro"] =  TextBox_Consulta.Text;



                if (TextBox_Consulta.Text != "")
                {

                    Session["CampoDrop"] = DropDownListFiltro.SelectedValue;
                    String filtroSelected = Session["CampoDrop"].ToString();
                    switch (filtroSelected)
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
                    if (paciBC.consultar_paciente(Session["CampoDrop"].ToString(), paciModel) != null)
                    {
                        if (paciBC.consultar_paciente(Session["CampoDrop"].ToString(), paciModel).HasRows)
                        {
                            GridViewResultPaciente.DataSource = paciBC.consultar_Paciente_Todos_Anamnese_Sem_Acompanhamento(Session["CampoDrop"].ToString(), paciModel);
                            GridViewResultPaciente.DataBind();

                        }
                        else
                        {
                            GridViewResultPaciente.DataBind();
                            TextBox_Consulta.Text = null;
                            mensagem.Visible = true;
                            mensagem.Text = "<script>alert('Não foram encontrados pacientes com os filtros selecionados')</script>";

                        }

                    }
                    else
                    {

                        mensagem.Visible = true;
                        mensagem.Text = "<script>alert('Não foi possível realizar a consulta, verifique a conexão com o Banco de Dados')</script>";


                    }
                }
                else
                {

                    mensagem.Visible = true;
                    mensagem.Text = "<script>alert('O campo de filtro está em branco, por gentileza verifique-o.')</script>";
                }

            }

        }

        protected void GridViewLIstagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxSelectedTrat.Text = "selected";
            
            TratamentoBC tratBC = new TratamentoBC();
            TratamentoModel tratamento = new TratamentoModel();
            tratamento.id_tratamento = (int)GridViewLIstagem.SelectedDataKey.Value;
            //Se for diferente de nulo entao carrega pagina
            if (tratBC.retorna_procedimento_vinculado(tratamento) != null)
            {
                GridViewProcedimentosVinculados.DataSource = tratBC.retorna_procedimento_vinculado(tratamento);
                GridViewProcedimentosVinculados.DataBind();

            }
                //Senao mostr Empty
            else {


                GridViewProcedimentosVinculados.DataBind();
                
            }
            if (tratBC.retorna_produto_vinculado(tratamento) != null)
            {
                GridViewProdutosVinculados.DataSource = tratBC.retorna_produto_vinculado(tratamento);
                GridViewProdutosVinculados.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
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

        protected void GridViewResultPaciente_PreRender(object sender, EventArgs e)
        {
         
            
        }

        protected void gridviewlistagemStatusAcomp_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxStatusValidator.Text = "selected";
        }

        protected void GridViewResultPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxPacienteValidator.Text = "selected";
        }

        }
    }

