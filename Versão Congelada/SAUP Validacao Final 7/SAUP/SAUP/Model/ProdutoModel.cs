using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class ProdutoModel
    {
        private int ID;
        private String 	DESCRICAO;
        private String UNIDADE;

        public int id
        {
            get { return ID; }
            set { this.ID = value; }
        }

        public String descricao
        {
            get { return DESCRICAO; }
            set { this.DESCRICAO = value; }
        }

        public String unidade
        {
            get { return UNIDADE; }
            set { this.UNIDADE = value; }
        }



    }
}