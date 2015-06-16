using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;
using SAUP.DAO;
using SAUP.Model;

namespace SAUP.Control
{
    public class ProcedimentoBC
    {

        public DB2DataReader retorna_Todos_Procedimentos()
        {

            ProcedimentoDAO procDAO = new ProcedimentoDAO();
           return procDAO.retorna_Todos_Procedimentos();
        
        }

    }
}