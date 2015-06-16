using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.EscalaBraden
{
    public class EscalaBraden
    {  
        private int pontuacao = 0;

        public int calcula_braden(int percepcaoSensorial, int umidade, int atividadefisica, int mobilidade, int nutricao, int friccao_cisalhamento)
    {
        pontuacao = percepcaoSensorial + umidade + atividadefisica + mobilidade + nutricao + friccao_cisalhamento;
    

        return pontuacao;
    
    
    }

    }
}