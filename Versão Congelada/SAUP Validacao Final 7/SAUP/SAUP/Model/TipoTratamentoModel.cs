using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class TipoTratamentoModel
    {

        private int id_tipo_Tratamento;
        private string descricao;


            public int ID_TIPO_TRATAMENTO
            {
            
            get {return id_tipo_Tratamento;}
            set{this.id_tipo_Tratamento =value;}
            }

            public string DESCRICAO
            {
                get { return descricao; }
                set { this.descricao = value; }
            
            }


    }
}