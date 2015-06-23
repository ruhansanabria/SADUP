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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_name"] == null)
            {
                Response.Redirect("~/Account/Logout.aspx");
            }

            Page.MaintainScrollPositionOnPostBack = true;
            AcompanhamentoBC acompBC = new AcompanhamentoBC();
            


             int ID_ACOMPANHAMENTO = Convert.ToInt32(Session["ID_ACOMPANHAMENTO_MON"].ToString());
             if (acompBC.retorna_Imagem_Acomp_Atual(ID_ACOMPANHAMENTO).HasRows == false)
             {
               
                GridViewTESTE.DataBind();
                 

             }
             else
             {

                 GridViewTESTE.DataSource = acompBC.retorna_Imagem_Acomp_Atual(ID_ACOMPANHAMENTO);
                 // GridViewTESTE.DataSource = acompBC.retorna_Anexos();
                 GridViewTESTE.DataBind();
             }
        }
    }
}