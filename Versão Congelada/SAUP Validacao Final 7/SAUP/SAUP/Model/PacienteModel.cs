using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class PacienteModel
    {
        private int ID;
        private String NOME;
        private String RG; 
        private String CPF;
        private String TELEFONE;
        private String SEXO;
        private String DATA_NASCIMENTO;

        public int id
        {
            get { return ID; }
            set { this.ID = value; }
        }
        public String nome
        {
            get { return NOME; }
            set { this.NOME = value; }
        }

        public String rg
        {
            get { return RG; }
            set { this.RG = value; }
        }

        public String cpf
        {
            get { return CPF; }
            set { this.CPF = value; }
        }

        public String telefone
        {
            get { return TELEFONE; }
            set { this.TELEFONE = value; }
        }

        public String sexo
        {
            get { return SEXO; }
            set { this.SEXO = value; }
        }
        public String Data_Nascimento

        {
            get { return DATA_NASCIMENTO; }
            set { this.DATA_NASCIMENTO = value; }
        }

  


    }
}