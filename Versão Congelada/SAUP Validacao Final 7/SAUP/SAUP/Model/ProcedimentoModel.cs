using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class ProcedimentoModel
    {
        private int ID;
        private String DESCRICAO ;
        private String CLASSIFICACAO;

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

        public String classificacao
        {
            get { return CLASSIFICACAO; }
            set { this.CLASSIFICACAO = value; }
        }

            	      
	   
    }
}