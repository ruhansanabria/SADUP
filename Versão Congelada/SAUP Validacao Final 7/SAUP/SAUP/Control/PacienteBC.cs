using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;
using SAUP.DAO;
using SAUP.Model;

namespace SAUP.Control
{
    public class PacienteBC
    {

public String Inserir_Paciente(PacienteModel paciente)
        {
            PacienteDAO paciDAO = new PacienteDAO();
            return paciDAO.Inserir_Paciente(paciente);
        }
        public String Editar_Paciente(PacienteModel paciente)
        {
            PacienteDAO paciDAO = new PacienteDAO();
            return paciDAO.Editar_Paciente(paciente);
        }
        public DB2DataReader consultar_paciente(String filtroDrop,PacienteModel paciente)
        {       
        
        PacienteDAO paciDAO = new PacienteDAO();
            return paciDAO.consultar_Paciente(filtroDrop,paciente);
        }
        public DB2DataReader consultar_Paciente_Todos_Anamnese()
        {
            PacienteDAO paciDAO = new PacienteDAO();
            return paciDAO.consultar_Paciente_Todos_Anamnese();
        }

        public DB2DataReader consultar_Paciente_Todos_Anamnese_Sem_Acompanhamento(String filtroDrop, PacienteModel paciente)
        {
            PacienteDAO paciDAO = new PacienteDAO();
            return paciDAO.consultar_Paciente_Todos_Anamnese_Sem_Acompanhamento(filtroDrop,paciente);
        }

        public DB2DataReader consultar_CPF_Existente(PacienteModel paciente)

        {
            PacienteDAO paciDAO = new PacienteDAO();
            return paciDAO.consultar_CPF_Existente(paciente);

        }

        public DB2DataReader consultar_RG_Existente(PacienteModel paciente)
        {
            PacienteDAO paciDAO = new PacienteDAO();
            return paciDAO.consultar_RG_Existente(paciente);


        }

        


       
    }
}