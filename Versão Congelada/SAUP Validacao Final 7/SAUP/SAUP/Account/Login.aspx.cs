using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SAUP.Control;
using SAUP.Model;
using IBM.Data.DB2;

namespace SAUP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            LabelMensagem.Visible = false;
            if (Session["User_name"] != null)
            {
                Response.Redirect("~/Monitoramento/Monitoramento.aspx");
            }
          

        }
        protected void LoginButton_Logar(object sender, EventArgs e)
        {

            System.Threading.Thread.Sleep(2000);
        

            EnfermeiroModel enfmodel = new EnfermeiroModel();
            EnfermeiroBC enfBC = new EnfermeiroBC();
            //Criacao da Session user_name
            Session["User_name"] = UserName.Text.Replace("'", "");
            Session["senha"] = Encryptor.MD5Hash(Password.Text);

            //Teste de Session -Se falhar deve ir para logout
            if (Session["User_name"] != null && Session["senha"] != null)
            {
                //Atribuicao para o objeto para ser passado como paramentro
                enfmodel.User_Name = Session["User_name"].ToString();
                enfmodel.Password = Session["senha"].ToString();
                //Teste de Exceção de Banco de Dados,se disparar cairá no else com mensagem de Banco inacessível

               if((enfBC.retorna_Enfermeiro(Session["User_name"].ToString(), Session["senha"].ToString(), enfmodel)!= null))
               {
                    // Teste para verificar se existe usuario com os dados passasdos como parâmetro
                    if ((enfBC.retorna_Enfermeiro(Session["User_name"].ToString(), Session["senha"].ToString(), enfmodel).HasRows))
                    {
                        Response.Redirect("~/Monitoramento/Monitoramento.aspx");

                    }
                    else
                    {
                        LabelMensagem.Visible = true;
                        LabelMensagem.Text = "<script>alert('Usuário não existente ou usuário inativo!')</script>";
                        Session["User_name"] = null;
                        Session["senha"] = null;
                        UserName.Text = "";
                        Password.Text = "";
                    }
               }
                   //Dispara Exceção
               else
                {

                    LabelMensagem.Visible = true;
                    LabelMensagem.Text = "<script>alert('Não foi possível acessar o banco de dados para consultar o usuário, verifique se o banco de dados está ativo!')</script>";
                    Session["User_name"] = null;
                    Session["senha"] = null;
                    UserName.Text = "";
                    Password.Text = "";


                }


            }
                // Caso Session User name não exista
            else
            {
                LabelMensagem.Text = "<script>alert('Você não está mais logado, Redirecionando para página de Logout!')</script>";
                
                Response.Redirect("~Account/Logout.aspx");
            }
        }

     
    }
}