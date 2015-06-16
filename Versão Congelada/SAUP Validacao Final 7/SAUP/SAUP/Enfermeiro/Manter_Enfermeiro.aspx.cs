using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Control;
using SAUP.Model;
using IBM.Data.DB2;
using System.Web;

namespace SAUP
{
    public partial class Manter_Enfermeiro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }
            else
            {
                Page.MaintainScrollPositionOnPostBack = true;

                if (!IsPostBack)
                {

                    if (Session["nomeEnfConsulta"] != null && Session["UserEnf"] != null && Session["UserEnf"] != null && Session["TipoEnf"] != null)
                    {
                        TextBox_nome.Text = HttpUtility.HtmlDecode(Session["nomeEnfConsulta"].ToString());
                        TextBox_user.Text = HttpUtility.HtmlDecode(Session["UserEnf"].ToString());
                        DropDownList_Status.Text = Session["StatusEnf"].ToString();
                        PerfilAtual.Text = Session["TipoEnf"].ToString();
                        ButtonInserir.Visible = false;
                        ButtonSalvar.Visible = true;
                        Label1.Visible = false;

                    }
                    else
                    {
                        Label1.Visible = false;
                        ButtonSalvar.Visible = false;
                        PerfilAtualLabel.Visible = false;
                        PerfilAtual.Visible = false;
                        ButtonInserir.Visible = true;
                    }
                }
            }
        }

        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            Session["nomeEnfConsulta"] = null;
            Session["UserEnf"] = null;
            Session["StatusEnf"] = null;
            Session["TipoEnf"] = null;
           

            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }

        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            EnfermeiroBC enfBC = new EnfermeiroBC();
            EnfermeiroModel enfModel = new EnfermeiroModel();

            String nome, usuario, Status, senha;
            int Tipo;
            if (Page.IsValid)
            {

                if (Session["User_name"] == null)
                {
                    Response.Redirect("~/Account/Logout.aspx");
                }
                else
                {

                    if (IsPostBack)
                    {
                        if (GridViewPerfilEnfermeiro.SelectedDataKey == null)
                        {
                            TextBoxSelectedPerf.Text = "";
                        }
                        else
                        {
                            TextBoxSelectedPerf.Text = "Selected";
                            if (TextBox_nome.Text != "" && TextBox_user.Text != "" && TextBoxSenha.Text != "")
                            {
                                nome = TextBox_nome.Text.Replace("'", "");
                                usuario = TextBox_user.Text.Replace("'", "");
                                Status = DropDownList_Status.Text;


                                
                                Tipo = Convert.ToInt32(GridViewPerfilEnfermeiro.SelectedDataKey.Value);

                                senha = TextBoxSenha.Text;

                                enfModel.Nome = nome;
                                enfModel.User_Name = usuario;
                                enfModel.Status = Status;
                                enfModel.Password = Encryptor.MD5Hash(senha);
                                enfModel.Id_Perfil_Enf = Tipo;
                                try
                                {
                                    Label1.Visible = true;
                                    Label1.Text = "<script> alert('" + enfBC.inserir_Enfermeiro(enfModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";
                                    
                                }
                                catch (DB2Exception)
                                {
                                    Label1.Text = "<script> alert('Não foi possível inserir, verifique a conexão com o banco de dados!') </script>";
                                
                                }

                                Session["nomeEnfConsulta"] = null;
                                Session["UserEnf"] = null;
                                Session["StatusEnf"] = null;
                                Session["TipoEnf"] = null;

                              
                            }
                            else
                            {
                                Label1.Visible = true;
                                Label1.Text = "<script> alert('Favor verificar os Campos para Inserção') </script>";
                            }
                        }
                    }
                }
            }
        }

        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            EnfermeiroBC enfBC = new EnfermeiroBC();
            EnfermeiroModel enfModel = new EnfermeiroModel();

            String nome, usuario, Status, senha;
            int Tipo;
            if (Page.IsValid)
            {

                if (Session["User_name"] == null)
                {
                    Response.Redirect("~/Account/Logout.aspx");
                }
                else
                {

                    if (IsPostBack)
                    {
                        if (GridViewPerfilEnfermeiro.SelectedDataKey == null)
                        {
                            TextBoxSelectedPerf.Text = "";
                        }
                        else
                        {
                            
                            if (TextBox_nome.Text != "" && TextBox_user.Text != "" && TextBoxSenha.Text != "")
                            {
                                nome = TextBox_nome.Text.Replace("'", "");
                                usuario = TextBox_user.Text.Replace("'", "");
                                Status = DropDownList_Status.Text;
                                Tipo = Convert.ToInt32(GridViewPerfilEnfermeiro.SelectedDataKey.Value);
                                senha = TextBoxSenha.Text;

                                enfModel.Nome = nome;
                                enfModel.User_Name = usuario;
                                enfModel.Status = Status;
                                enfModel.Password = Encryptor.MD5Hash(senha);
                                enfModel.Id_Perfil_Enf = Tipo;

                                Label1.Visible = true;
                                Label1.Text = "<script> alert('" + enfBC.atualizar_enfermeiro(enfModel) + "');location.href='../Monitoramento/Monitoramento.aspx';</script>";
                                
                                Session["nomeEnfConsulta"] = null;
                                Session["UserEnf"] = null;
                                Session["StatusEnf"] = null;
                                Session["TipoEnf"] = null;

                               
                            }
                            else
                            {
                                Label1.Visible = true;
                                Label1.Text = "<script> alert('Favor Verificar os Campos para Edição') </script>";
                            }

                        }
                    }

                }
            }
        }

        protected void Menuprincipal_Click(object sender, EventArgs e)
        {
            Session["nomeEnfConsulta"] = null;
            Session["UserEnf"] = null;
            Session["StatusEnf"] = null;
            Session["TipoEnf"] = null;


            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }

        protected void TextBox_user_TextChanged(object sender, EventArgs e)
        {
            EnfermeiroBC enfBC = new EnfermeiroBC();
            EnfermeiroModel enfModel = new EnfermeiroModel();

            enfModel.User_Name = TextBox_user.Text.Replace("'", "");
            LabelErrorUniqueUserName.Visible = false;
            if (IsPostBack)
            {
               
                Label1.Text = "";
                if (enfBC.retorn_EnfUserNameUniqueByuser_name(enfModel) != null)
                {

                    Label1.Visible = true;
                    Label1.Text = "<script> alert('Nome de usuário já existente no cadastro de enfermeiros, por gentileza digite outro!') </script>";
                    LabelErrorUniqueUserName.Visible = true;
                }
           
            }



        }

        protected void GridViewPerfilEnfermeiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxSelectedPerf.Text = "Selected";
        }     

      
    }
}