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
    public partial class Manter_Anamnese: System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LabelMensagem.Visible = false;
                LabelMensagem.Text = "";
            }

            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }
            else
            {
                textInfo.Attributes.Add("maxlength", "1000");
                textHistorico.Attributes.Add("maxlength", "1000");
                textFamiliar.Attributes.Add("maxlength", "1000");

                Page.MaintainScrollPositionOnPostBack = true;
                if (Session["Nome_Paciente"] != null & Session["Data_Realizacao"] != null & Session["Histor_Doencas"] != null &
                    Session["Histor_Familiar"] != null & Session["Infor_Adi"] != null)
                {
                    //Session["Data_Realizacao"].ToString();
                    Paciente_TextBox.Text = HttpUtility.HtmlDecode(Session["Nome_Paciente"].ToString());
                    //Data_Realizacao_TextBox.Text = Session["Data_Realizacao"].ToString();
                    textHistorico.Text = HttpUtility.HtmlDecode(Session["Histor_Doencas"].ToString());
                    textFamiliar.Text = HttpUtility.HtmlDecode(Session["Histor_Familiar"].ToString());
                    textInfo.Text = HttpUtility.HtmlDecode(Session["Infor_Adi"].ToString());
                    //Se eu estou editando logo habilito o botao atulizar e desabilito a grid
                    Atualizar_Button.Visible = true;
                    Gravar.Visible = false;
                    Listagem_Pacientes.Visible = false;
                }

                //Se o nome não existir significa que esta tentando inserir logo desabilito o botao Atualizar, so inserir aparece
                if (Session["ID_PACIENTE"] == null)
                {
                    Paciente.Visible = false;
                    Paciente_TextBox.Visible = false;
                    Gravar.Visible = true;
                    Listagem_Pacientes.Visible = true;
                    Atualizar_Button.Visible = false;
                }
                Session["Nome_Paciente"] = null;
                Session["Data_Realizacao"] = null;
                Session["Histor_Doencas"] = null;
                Session["Histor_Familiar"] = null;
                Session["Infor_Adi"] = null;
            }

        }
            protected void Button_Cancelar_Click(object sender, EventArgs e)
            {

                Session["Nome_Paciente"] = null;
                Session["Histor_Doencas"] = null;
                Session["Histor_Familiar"] = null;
                Session["Infor_Adi"] = null;

                Response.Redirect("~/Monitoramento/Monitoramento.aspx");
            
            }

            protected void Gravar_Click(object sender, EventArgs e)
            {
                AnamneseModel anamneseModel = new AnamneseModel();
                EnfermeiroModel enfModel = new EnfermeiroModel();
                AnamneseBC anamneseBC = new AnamneseBC();
                EnfermeiroBC enfBc = new EnfermeiroBC();

                if (IsPostBack)
                {

                    if (Listagem_Pacientes.SelectedDataKey != null)
                    {
                        if (textInfo.Text != "" || textFamiliar.Text != "" || textHistorico.Text != "")
                        {
                           
                            Session["Nome_Paciente"] = Paciente_TextBox.Text.Replace("'","");
                            // Session["Data_Realizacao"]  = Data_Realizacao_TextBox.Text;
                            Session["Histor_Doencas"] = textHistorico.Text.Replace("'","");
                            Session["Histor_Familiar"] = textFamiliar.Text.Replace("'", "");
                            Session["Infor_Adi"] = textInfo.Text.Replace("'", "");

                            // anamneseModel.Data_Realizacao = Convert.ToDateTime(Session["Data_Realizacao"].ToString());
                            anamneseModel.Historico_Doenca = Session["Histor_Doencas"].ToString();
                            anamneseModel.Historico_Familiar = Session["Histor_Familiar"].ToString();
                            anamneseModel.informacoes_Adicionais = Session["Infor_Adi"].ToString();
                            // Se Session nao for nula entao armazena no objeto de enf e faz
                            // a busca para  poder realizar o  insert de dados atraves do user selecionado
                            if (Session["User_name"] != null)
                            {
                                enfModel.User_Name = Session["User_name"].ToString();

                            }
                            anamneseModel.id_Enfermeiro = enfBc.retorna_EnfIDByUsername(enfModel);
                            // captura o perfil do banco para realizar o insert correto 
                            anamneseModel.id_perfil_Enfermeiro = enfBc.retorna_EnfPerfById(anamneseModel);

                            anamneseModel.id_Paciente = Convert.ToInt32(Listagem_Pacientes.SelectedPersistedDataKey.Value);



                            LabelMensagem.Visible = true;
                            LabelMensagem.Text = "<script>alert('" + anamneseBC.inserir_anamnese(anamneseModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";
                                
                                 
                                Paciente_TextBox.Text = "";
                                textHistorico.Text = "";
                                textFamiliar.Text = "";
                                textInfo.Text = "";
                                
                            }
                            
                        
                        
                    
                    
                    }
                    else {
                        LabelMensagem.Visible = true;
                        LabelMensagem.Text = "<script>alert('É obrigatório selecionar um paciente para inserir Anamnese.')</script>";
                    
                    }
                }
            }

            protected void Atualizar_Button_Click(object sender, EventArgs e)
            {
                AnamneseModel anamneseModel = new AnamneseModel();
                AnamneseBC anamneseBC = new AnamneseBC();
                if (IsPostBack)
                {
                    if (Paciente_TextBox.Text != "" && textFamiliar.Text != "" && textHistorico.Text != "")
                    {
                        Session["Nome_Paciente"] = Paciente_TextBox.Text;
                        // Session["Data_Realizacao"]  = Data_Realizacao_TextBox.Text;
                        Session["Histor_Doencas"] = textHistorico.Text;
                        Session["Histor_Familiar"] = textFamiliar.Text;
                        Session["Infor_Adi"] = textInfo.Text;

                        // anamneseModel.Data_Realizacao = Convert.ToDateTime(Session["Data_Realizacao"].ToString());
                        anamneseModel.Historico_Doenca = Session["Histor_Doencas"].ToString();
                        anamneseModel.Historico_Familiar = Session["Histor_Familiar"].ToString();
                        anamneseModel.informacoes_Adicionais = Session["Infor_Adi"].ToString();

                        if (Session["ID_PACIENTE"] != null)
                        {
                            anamneseModel.id_Paciente = (int)Session["ID_PACIENTE"];
                        }
                       
                            LabelMensagem.Visible = true;
                            LabelMensagem.Text = "<script>alert('" + anamneseBC.atualizar_anamnese(anamneseModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";
                           
                            
                            
                            
                           // Atualizar_Button.Attributes.Add("OnClientClick", "getMessage(" + LabelMensagem.Text + ")");
                           // Atualizar_Button.OnClientClick = "getMessage(" + LabelMensagem.Text + ")";
                            Paciente_TextBox.Text = "";
                            textHistorico.Text = "";
                            textFamiliar.Text = "";
                            textInfo.Text = "";
                           
                          
                        
                    }
                    else {
                        LabelMensagem.Visible = true;
                        LabelMensagem.Text = "<script>alert('Existem campos Vazios para Edição')</script>";
                    }
                   
                }
                //Page.Response.Redirect("~/Monitoramento/Monitoramento.aspx", false);
            }

            protected void RetornarMenuPrincipal_Click(object sender, EventArgs e)
            {
                Session["Nome_Paciente"] = null;
                Session["Data_Realizacao"] = null;
                Session["Histor_Doencas"] = null;
                Session["Histor_Familiar"] = null;
                Session["Infor_Adi"] = null;

                Response.Redirect("~/Monitoramento/Monitoramento.aspx");
            }

            public void Redirect()
            {

                
                
            }
    }
}