using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;

namespace SAUP.Control
{
    public class GerenciadorBanco
    {
        private DB2Connection c;

        public DB2Connection CriarConexao()
        {
             c = new DB2Connection();
            //atribuir a conectString
             c.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings.ToString();

            c.Open();
            return c;
        }

        public DB2Connection FecharConexao()
        {
            c.Close();
            return c;
        
        }
    }
}