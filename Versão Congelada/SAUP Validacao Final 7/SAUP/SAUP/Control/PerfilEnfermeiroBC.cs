using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAUP.Model;
using SAUP.Control;
using SAUP.DAO;
using IBM.Data.DB2;

namespace SAUP.Control
{
    public class PerfilEnfermeiroBC
    {
        public DB2DataReader consultar_perfil()
        {
            PerfilEnfermeiroDAO perfEnf = new PerfilEnfermeiroDAO();
           return   perfEnf.consultar_perfil();

            

        }
    }
}