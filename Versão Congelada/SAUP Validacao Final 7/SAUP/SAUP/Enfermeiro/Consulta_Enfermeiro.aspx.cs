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
    public partial class Consulta_Enfermeiro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            Page.MaintainScrollPositionOnPostBack = true;

            Session["nomeEnf"] = null;
            Session["StatusEnf"] = null;
            Session["TipoEnf"] = null;
            Session["UserEnf"] = null;
        }

        protected void ButtonConsulta_Enf_Click(object sender, EventArgs e)
        {

            EnfermeiroModel enfModel = new EnfermeiroModel();
            PerfilEnfermeiroModel perfEnfModel = new PerfilEnfermeiroModel();
            EnfermeiroBC enf = new EnfermeiroBC();
            Session["Filtro"] = TextBox_Consulta_Enf.Text;
            Label_Pesquisa.Visible = false;

            if (Session["Filtro"] != "")
            {
                
                Session["CampoDrop"] = DropDownList1.SelectedValue;
                String filtroSelected = Session["CampoDrop"].ToString();
                switch(filtroSelected){
                
                    case "Codigo":
                        enfModel.Id_enfermeiro = Convert.ToInt32(Session["Filtro"].ToString());
                        break;
                    case "Nome" :
                        enfModel.Nome = Session["Filtro"].ToString();
                        break;
                    case "Status":
                        enfModel.Status = Session["Filtro"].ToString();
                        break;
                    case "PerfilEnfermeiro":
                        perfEnfModel.DESCRICAO = TextBox_Consulta_Enf.Text;
                        break;
                    
                }
                // Se o banco não estiver ativo e acessível entao mensagem para o usuario
                
                try{
                
                            
                    //Se estiver ativo então consulte 
               
                    if (enf.get_enfermeiros(filtroSelected, enfModel, perfEnfModel).HasRows)
                    {

                        GridView_Result_Enfermeiro.DataSource = enf.get_enfermeiros(Session["CampoDrop"].ToString(), enfModel, perfEnfModel);
                        GridView_Result_Enfermeiro.DataBind();
                    }
                        //Se não tiver linhas então retorne null e atualize a Grid e o campo filtro
                    else
                    {
                        Label_Pesquisa.Visible = true;
                        Label_Pesquisa.Text = "<script>alert('Não foram encontrados registros de Enfermeiros com os filtros selecionados!')</script>";
                        TextBox_Consulta_Enf.Text = "";
                        GridView_Result_Enfermeiro.DataBind();

                    }


                
                }catch(DB2Exception)

                {
                    Label_Pesquisa.Visible = true;
                    Label_Pesquisa.Text = "<script>alert('Não foi possível realizar a consulta, verifique a conexão com o banco de dados!')</script>";
                }
            }
            else
            {
                //Filtro em branco
                Label_Pesquisa.Visible = true;
                Label_Pesquisa.Text = "<script>alert('Filtro em branco , por favor digite algum valor no filtro para buscar')</script>";
                GridView_Result_Enfermeiro.DataBind();
                 
            }
        }

        protected void GridView_Result_Enfermeiro_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar")
            {
                Label_Pesquisa.Visible = false;


                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView_Result_Enfermeiro.Rows[index];

                ListItem item = new ListItem();
                item.Text = row.Cells[2].Text + "    " +
                            row.Cells[3].Text + "    " + 
                            row.Cells[4].Text + "    " + 
                            row.Cells[5].Text;

                Session["nomeEnfConsulta"] = row.Cells[2].Text;
                Session["StatusEnf"]= row.Cells[3].Text;
                Session["TipoEnf"]= row.Cells[4].Text;
                Session["UserEnf"] = row.Cells[5].Text;
               

            Response.Redirect("Manter_Enfermeiro.aspx");
                


            }

        }

        protected void ButtonInserir_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Manter_Enfermeiro.aspx");
        }

        protected void ButtonRetornarMenu_Click(object sender, EventArgs e)
        {
            Session["nomeEnf"] = null;
            Session["StatusEnf"] = null;
            Session["TipoEnf"] = null;
            Session["UserEnf"] = null;

            Response.Redirect("~/Monitoramento/Monitoramento.aspx");
        }

        protected void DropDownList1_PreRender(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Nome")
            {
                TextBox_Consulta_Enf.Text = null;
                RegularExpressionValidator1.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RegularExpressionValidator1.ErrorMessage = "Somente Letras para o nome";
                TextBox_Consulta_Enf.MaxLength = 100;
            }
            else if (DropDownList1.Text == "Status")
            {
                TextBox_Consulta_Enf.Text = null;
                RegularExpressionValidator1.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RegularExpressionValidator1.ErrorMessage = " Somente letras para o Status";
                TextBox_Consulta_Enf.MaxLength = 8;
            }
            else if (DropDownList1.Text == "PerfilEnfermeiro")
            {
                TextBox_Consulta_Enf.Text = null;
                RegularExpressionValidator1.ValidationExpression = "^[a-z\u00C0-\u00ff A-Z]+$";
                RegularExpressionValidator1.ErrorMessage = "Somente letras para o Perfil";
                TextBox_Consulta_Enf.MaxLength = 20;
            }
            else if (DropDownList1.Text == "Codigo")
            {
                TextBox_Consulta_Enf.Text = null;
                RegularExpressionValidator1.ValidationExpression = "[0-9]+";
                RegularExpressionValidator1.ErrorMessage = "Somente números para o Código";
                TextBox_Consulta_Enf.MaxLength = 4;
            }
        }

    }
}