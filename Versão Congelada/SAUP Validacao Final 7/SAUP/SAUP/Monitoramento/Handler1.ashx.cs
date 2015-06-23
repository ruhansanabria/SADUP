using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;

namespace SAUP
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpg";
            
            DB2Connection db2;
            DB2Command comand;
            DB2DataReader reader;
            db2 = new DB2Connection("Database=SAMPLE");
            db2.Open();

            string id_ACOMPANHAMENTO = context.Request.QueryString["ID_ACOMPANHAMENTO"];
            context.Response.ContentType = "image/jpg";
            comand = new DB2Command();
            comand.Connection = db2;

            comand.CommandText = "SELECT  A.ARQUIVO AS ARQUIVO FROM DB2ADMIN.ANEXO A WHERE A.ID_ACOMPANHAMENTO =" + id_ACOMPANHAMENTO;
            reader = comand.ExecuteReader();



         reader.Read();
        // Escreve a resposta (imagem)
        context.Response.BinaryWrite((Byte[])reader["arquivo"]);
        // Fecha a conexão com o banco
        db2.Close();
        // Envia a resposta
        context.Response.End();
            
             
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}