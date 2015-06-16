using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SAUP.Control;
using SAUP.Model;
using IBM.Data.DB2;
using System.Configuration;


namespace SAUP
{
    public class MonitoramentoDAO
    {
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;
        string condicao = "";


        public DB2DataReader relatorio_media_pontuacao()
        {
            string condicao;
            try
            {
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                comand.CommandText = "SELECT avg(HIST_AC.PONTUACAO_RECALCULADA) AS Media," +
                                     " HIST_AC.PRIORIDADE " +
                                     "  FROM HISTORICO_ACOMPANHAMENTO HIST_AC" +
                                     " GROUP BY HIST_AC.PRIORIDADE";

                reader = comand.ExecuteReader();

                return reader;
            }
            catch (DB2Exception)
            {
                return null;
            }

        }
    }
}