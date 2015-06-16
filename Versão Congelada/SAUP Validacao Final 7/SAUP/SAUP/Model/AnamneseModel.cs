using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class AnamneseModel
    {
       private int  ID_ANAMNESE;
       private DateTime DATA_REALIZACAO;
       private string HISTORICO_DOENCAS; 
       private string HISTORICO_FAMILIAR;
       private string INFORMACOES_ADICIONAIS;
       private System.Nullable<int> ID_ENFERMEIRO;
       private System.Nullable<int> ID_PERFIL_ENFERMEIRO; 
       private System.Nullable<int> ID_PACIENTE;

       public int id_Anamnese
       {

           get { return ID_ANAMNESE; }
           set { this.ID_ANAMNESE = value; }
       }

       public DateTime Data_Realizacao
       {
           get { return DATA_REALIZACAO; }
           set { this.DATA_REALIZACAO = value; }
       }

       public String Historico_Doenca
       {
           get { return HISTORICO_DOENCAS; }
           set { this.HISTORICO_DOENCAS = value; }
       }

       public String Historico_Familiar
       {
           get { return HISTORICO_FAMILIAR; }
           set { this.HISTORICO_FAMILIAR = value; }
       }
       public String informacoes_Adicionais
       {
           get { return INFORMACOES_ADICIONAIS; }
           set { this.INFORMACOES_ADICIONAIS = value; }
       
       }
       public System.Nullable<int> id_Enfermeiro
       {

           get { return ID_ENFERMEIRO; }
           set { this.ID_ENFERMEIRO = value; }
       }

       public System.Nullable<int> id_perfil_Enfermeiro
       {
           get { return ID_PERFIL_ENFERMEIRO; }
           set { this.ID_PERFIL_ENFERMEIRO = value; }
       
       }

       public System.Nullable<int> id_Paciente
       {
           get { return ID_PACIENTE; }
           set { this.ID_PACIENTE = value; }
       }


    }
}