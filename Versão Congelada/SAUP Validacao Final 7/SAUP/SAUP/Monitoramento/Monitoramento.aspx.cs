using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Control;
using SAUP.Model;
using System.Data;
using SAUP.DAO;

namespace SAUP
{
    public partial class Monitoramento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AcompanhamentoDAO acompDAO = new AcompanhamentoDAO();

                if (Session["User_name"] == null)
                {
                    Response.Redirect("~/Account/Logout.aspx");
                }

                //alimentação da GridView
                GridViewMonitoramento.DataSource = acompDAO.get_Acompanhamentos();
                GridViewMonitoramento.DataBind();

                Page.MaintainScrollPositionOnPostBack = true;

                Label labelPrioridade;
                Label situacao;
                Label proxAtendimento;
                DateTime dataUltimoAcomp;
                foreach (GridViewRow row in GridViewMonitoramento.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {

                        labelPrioridade = (Label)row.FindControl("LabelPrioridade");
                        if (labelPrioridade.Text == "0-Muito Urgente")
                        {
                            Image image = (Image)row.FindControl("Semaforo");
                            image.ImageUrl = "~/Images/redrisk.jpg";

                        }
                        else if (labelPrioridade.Text == "1-Urgente")
                        {

                            Image image = (Image)row.FindControl("Semaforo");
                            image.ImageUrl = "~/Images/riskoragen.jpg";
                        }
                        else if (labelPrioridade.Text == "2-Pouco Urgente")
                        {

                            Image image = (Image)row.FindControl("Semaforo");
                            image.ImageUrl = "~/Images/riskgreen.jpg";

                        }
                        else if (labelPrioridade.Text == "3-Não Urgente")
                        {

                            Image image = (Image)row.FindControl("Semaforo");
                            image.ImageUrl = "~/Images/riskblue.jpg";
                        }

                        proxAtendimento = (Label)row.FindControl("LabelProxAtendimento");
                        dataUltimoAcomp = Convert.ToDateTime(proxAtendimento.Text);

                        if (dataUltimoAcomp < DateTime.Now)
                        {
                            situacao = (Label)row.FindControl("LabelSituacao");
                            situacao.Text = "Atendimento em atraso";
                            situacao.ForeColor = System.Drawing.Color.Red;

                        }
                        else
                        {
                            situacao = (Label)row.FindControl("LabelSituacao");
                            situacao.Text = "Atendimento em dia";
                            situacao.ForeColor = System.Drawing.Color.Blue;

                        }
                    }


                }

                MenuItemCollection menuItems = Menu1.Items;
                MenuItem adminItem = new MenuItem();

                EnfermeiroModel enfModel = new EnfermeiroModel();
                EnfermeiroBC enf = new EnfermeiroBC();
                String username = Session["User_name"].ToString();

                enfModel.User_Name = username;
                String perfillogado = enf.retorna_Perfil_Menu(enfModel);


                if (perfillogado == "Administrativo")
                {

                    foreach (MenuItem menuItem in menuItems)
                    {
                        if (menuItem.Value == "Anamnese")

                            adminItem = menuItem;
                    }
                    menuItems.Remove(adminItem);
                    foreach (MenuItem menuItem in menuItems)
                    {
                        if (menuItem.Value == "Avaliacao")

                            adminItem = menuItem;
                    }
                    menuItems.Remove(adminItem);
                }
                else if (perfillogado == "Assistencial")
                {

                    foreach (MenuItem menuItem in menuItems)
                    {
                        if (menuItem.Value == "ManterTratamento")

                            adminItem = menuItem;
                    }
                    menuItems.Remove(adminItem);
                    foreach (MenuItem menuItem in menuItems)
                    {
                        if (menuItem.Value == "ManterProdutos")

                            adminItem = menuItem;

                    }
                    menuItems.Remove(adminItem);
                    foreach (MenuItem menuItem in menuItems)
                    {
                        if (menuItem.Value == "BuscarEnfermeiros")

                            adminItem = menuItem;
                    }
                    menuItems.Remove(adminItem);
                    foreach (MenuItem menuItem in menuItems)
                    {
                        if (menuItem.Value == "BuscarPaciente")

                            adminItem = menuItem;
                    }
                    menuItems.Remove(adminItem);
                }


            }
            catch (System.NullReferenceException)
            {
                LabelAlert.Visible = true;
                LabelAlert.Text = "<script> alert('Não foi possível acessar o banco de dados, verifique a conexão com o banco de dados com o administrador!') </script>";
            
            
            }
        }

        protected void GridViewMonitoramento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridViewMonitoramento.SelectedDataKey != null)
            {
                Session["ID_ACOMPANHAMENTO_MON"] = GridViewMonitoramento.SelectedDataKey.Value;
                // Session["ID_ACOMPANHAMENTO_MON"] = GridViewMonitoramento.DataKeys[GridViewMonitoramento.SelectedRow].Value;

            }
        }

        protected void GridViewMonitoramento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LabelAlert.Visible = false;
            if (IsPostBack)
            {

                if (e.CommandName == "AcompanhamentoImagem")
                {
                    if (GridViewMonitoramento.SelectedDataKey != null)
                    {
                        Session["ID_ACOMPANHAMENTO_MON"] = GridViewMonitoramento.SelectedDataKey.Value;
                        Response.Redirect("AcompanhamentoporImagem.aspx");

                    }
                    else
                    {

                        LabelAlert.Visible = true;
                        LabelAlert.Text = "<script> alert('Não foram selecionados acompanhamentos') </script>";
                    }
                }
            }

        }

       
    }
}