using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SAUP
{
    public partial class SAUP : System.Web.UI.MasterPage
    {
        private string login;

        public string loginbuttonTxt
        {

            get { return login; }
            set { login = value; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
          
          
            // User.Text = login;
            if (Session["User_name"] != null)
            {
                user_logged.Visible = true;
                HyperLinkLogout.Visible = true;
                user_logged.Text = "[Olá Seja Bem-Vindo :" + Session["User_name"].ToString() + " ]";
              
            }
            else {
                user_logged.Visible = false;
                HyperLinkLogout.Visible = false;
                user_logged.Text = "";
                        
            }

            }
        
    }
}