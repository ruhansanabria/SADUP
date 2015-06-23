using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;
using SAUP.Control;
using System.Configuration;
using SAUP.Model;
using System.Web.UI.WebControls;

namespace SAUP.DAO
{
    public class PerfilEnfermeiroDAO
    {
        GerenciadorBanco g;
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;
        ObjectDataSource datasource;

        public DB2DataReader consultar_perfil()
        {

            //string condicao;

           // //string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                comand.CommandText = "SELECT p.ID_PERFIL_ENFERMEIRO, " +
                                        " p.DESCRICAO" +
                                      " FROM DB2ADMIN.PERFILENFERMEIRO p";

                reader = comand.ExecuteReader();

                return reader;
            }
            catch (DB2Exception)
            {
                reader = null;
                return reader;
            }
        }
    }
}