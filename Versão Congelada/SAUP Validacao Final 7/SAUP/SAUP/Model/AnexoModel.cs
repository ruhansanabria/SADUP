using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class AnexoModel
    {
        private int ID_ANEXO;
        private System.Nullable<int> ID_AVALIACAO;
        private System.Nullable<int> ID_ACOMPANHAMENTO;
        private System.Nullable<int> ID_TRATAMENTO;
        private String CAMINHO;
        private String NOME_ANEXO;
        private byte[] ARQUIVO;

        public int id_Anexo 
        {
            get { return ID_ANEXO; }
            set { this.ID_ANEXO = value; }
        
        }

        public System.Nullable<int> id_Avaliacao
        {
            get { return ID_AVALIACAO; }
            set { this.ID_AVALIACAO = value; }
        
        }

        public System.Nullable<int> id_Acompanhamento
        {
            get { return ID_ACOMPANHAMENTO; }
            set { this.ID_AVALIACAO = value; }
        }

        public System.Nullable<int> id_Tratamento 
        
        {
            get { return ID_TRATAMENTO; }
            set { this.ID_TRATAMENTO = value; }
        
        }

        public String caminho
        {
            get { return CAMINHO; }
            set { this.CAMINHO = value; }
        
        }

        public String nome_Anexo
        {

            get { return NOME_ANEXO; }
            set { this.NOME_ANEXO = value; }
        
        }

        public byte[] arquivo
        {

            get { return ARQUIVO; }
            set { this.ARQUIVO = value; }
        }
    }
}