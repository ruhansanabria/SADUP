using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAUP.DAO;
using IBM.Data.DB2;
using SAUP.Model;

namespace SAUP.Control
{
    public class AvaliacaoBC
    {

        public DB2DataReader consulta_avaliacao_By_Paciente(String filtroDrop, PacienteModel paciente)
        {
            AvaliacaoDAO avaliacaoDAO = new AvaliacaoDAO();
            return avaliacaoDAO.consulta_acompanhamento_By_Paciente(filtroDrop, paciente);
        
        }

        public String inserir_avaliacao(EnfermeiroModel enfermeiro, AvaliacaoModel avaliacao, TratamentoModel tratamento, PacienteModel paciente, int pontuacao)
        {
            AvaliacaoDAO avaliacaoDAO = new AvaliacaoDAO();
            return avaliacaoDAO.inserir_avaliacao(enfermeiro, avaliacao, tratamento, paciente, pontuacao);

   
        }

        public String inserir_enfermeiro_avaliacao(EnfermeiroModel enfermeiro, PacienteModel paciente)
        {

            AvaliacaoDAO avaliacaoDAO = new AvaliacaoDAO();
            return avaliacaoDAO.inserir_enfermeiro_avaliacao(enfermeiro, paciente);
        
        }



    }
}