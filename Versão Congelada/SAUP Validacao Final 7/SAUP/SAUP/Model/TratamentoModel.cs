using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class TratamentoModel
    {
         private System.Nullable<int> ID_TRATAMENTO;
         private System.Nullable<int> ID_TIPOTRATAMENTO;
         private String DESCRICAOTRATAMENTO;
         private String   PERIODICIDADE;
         private String PROCEDIMENTOS;

         public System.Nullable<int> id_tratamento
         {
             get { return ID_TRATAMENTO; }
             set { this.ID_TRATAMENTO = value; }
         
         }

         public System.Nullable<int> id_tipo_tratamento
         {
             get { return ID_TIPOTRATAMENTO; }
             set { this.ID_TIPOTRATAMENTO = value; }
         }

         public String descricaotratamento
         {

             get { return DESCRICAOTRATAMENTO; }
             set { this.DESCRICAOTRATAMENTO = value; }
         }

         public String periodicidade
         {
             get { return PERIODICIDADE; }
             set { this.PERIODICIDADE = value; }
         }

         public String procedimentos
         {
             get { return PROCEDIMENTOS; }
             set { this.PROCEDIMENTOS = value; }
         }







    }
}