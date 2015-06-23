using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;

namespace SAUP.DAO
{
    public class ProcedimentoDAO
    {
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;

        public DB2DataReader retorna_Todos_Procedimentos()
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                comand.CommandText = "SELECT PROC.ID_PROCEDIMENTO,PROC.DESCRICAO FROM DB2ADMIN.PROCEDIMENTO PROC";

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