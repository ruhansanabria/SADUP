using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class PerfilEnfermeiroModel
    {

        private int id_perfilEnfermeiro;
        private String descricao;

        public int ID_PERFILENFERMEIRO
        {

            get { return id_perfilEnfermeiro; }
            set { this.id_perfilEnfermeiro = value; }
        }

        public String DESCRICAO
        {

            get { return descricao; }
            set { this.descricao = value; }
        }


    }
}