using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAUP.DAO;
using SAUP.Model;
using IBM.Data.DB2;

namespace SAUP.Control
{
    public class AnamneseBC
    {

        public DB2DataReader consultar_AnamnesePaci(String filtroDrop,PacienteModel paciente)
        {
            AnamneseDAO anamneseDAO = new AnamneseDAO();
           return anamneseDAO.consultar_AnamnesePaci(filtroDrop, paciente);
        
        }

        public String inserir_anamnese(AnamneseModel anamnese)
        {
            AnamneseDAO anamneseDAO = new AnamneseDAO();
            return anamneseDAO.inserir_anamnese(anamnese);
        }

        public String atualizar_anamnese(AnamneseModel anamnese)
        {

            AnamneseDAO anamneseDAO = new AnamneseDAO();
            return anamneseDAO.atualizar_anamnese(anamnese);
        
        }
    }
}