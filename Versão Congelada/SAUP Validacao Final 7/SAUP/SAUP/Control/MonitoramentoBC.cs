using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;
using System.Configuration;
using SAUP.DAO;

namespace SAUP.Control
{
    public class MonitoramentoBC
    {

        public DB2DataReader relatorio_media_pontuacao()
        {
            MonitoramentoDAO monitoramento = new MonitoramentoDAO();
             return monitoramento.relatorio_media_pontuacao();
        
        }
    }
}