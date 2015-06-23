using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class EscalaBradenModel
    {
        private int	PONTUACAO ;
        private String DESCRICAOESTAGIO;

        public int pontuacao
        {
            get { return PONTUACAO; }
            set { this.PONTUACAO = value; }
        }

        public String rg
        {
            get { return DESCRICAOESTAGIO; }
            set { this.DESCRICAOESTAGIO = value; }
        }

    }
}