using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class AcompanhamentoModel
    {

       private int ID_ACOMPANHAMENTO;
       private int ID_TRATAMENTO;
       private String DATAREALIZACAO;
       private int ID_STATUSACOMPANHAMENTO;
       private String INFORMACOESCOMPLEMENTARES;
       private int ID_PACIENTE;
       private int FLAG_ALTA;
       private int ID_ENFERMEIRO;
       private int PONTUACAO_RECALCULADA;
       private String PRIORIDADE;


        public int Id_acompanhamento
        {
            get { return ID_ACOMPANHAMENTO;}
            set { this.ID_ACOMPANHAMENTO = value; }
        }

        public int flag_alta
        {
            get { return FLAG_ALTA; }
            set { this.FLAG_ALTA = value; }     
        }

        public int Id_tratamento
        {

            get { return ID_TRATAMENTO; }
            set { this.ID_TRATAMENTO = value; }
        }

        public String Data_Realizacao
        {
            get { return DATAREALIZACAO; }
            set { this.DATAREALIZACAO = value; }
        
        }
        public int Status_Acompanhamento
        {
            get { return ID_STATUSACOMPANHAMENTO; }
            set { this.ID_STATUSACOMPANHAMENTO = value; }
        }

        public String Informacoes_Complementares
        {
            get { return INFORMACOESCOMPLEMENTARES; }
            set { this.INFORMACOESCOMPLEMENTARES = value; }
        
        }

        public int Id_Paciente
        {
            get { return ID_PACIENTE; }
            set { this.ID_PACIENTE = value; }
        
        }

        public int id_enfermeiro
        {
            get { return ID_ENFERMEIRO; }
            set { this.ID_ENFERMEIRO = value; }

        }

        public int pontuacao
        {
            get { return PONTUACAO_RECALCULADA; }
            set { this.PONTUACAO_RECALCULADA = value; }
        
        }

        public String prioridade
        {
            get { return PRIORIDADE; }
            set { this.PRIORIDADE = value; }

        }
    }
}