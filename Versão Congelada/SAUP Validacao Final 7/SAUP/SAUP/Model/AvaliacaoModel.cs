using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class AvaliacaoModel
    {
        private int ID_AVALIACAO;
        private System.Nullable<int> ID_TIPO_TRATAMENTO; 
        private System.Nullable<int> ID_ESCALABRADEN;
        private System.Nullable<int>ID_TRATAMENTO; 
        private String DATAREALIZACAO; 
        private int PONTUACAO;

        public int id_Avaliacao
        {
            get { return ID_AVALIACAO; }
            set { this.ID_AVALIACAO = value; }
        
        }

        public System.Nullable<int> id_tipo_Tratamento
        {
            get { return ID_TIPO_TRATAMENTO; }
            set { this.ID_TIPO_TRATAMENTO = value; }
        
        }

        public System.Nullable<int> id_EscalaBraden
        {
            get { return ID_ESCALABRADEN; }
            set { this.ID_ESCALABRADEN = value; }

        }

        public System.Nullable<int> id_Tratamento
        {
            get { return ID_TRATAMENTO; }
            set { this.ID_TRATAMENTO = value; }

        }

        public String data_Realizacao
        
        {

            get { return DATAREALIZACAO; }
            set { this.DATAREALIZACAO = value; }
        
        }

        public int pontuacao_Escala
        {
            get { return PONTUACAO; }
            set { this.PONTUACAO = value; }
        }

    }
}