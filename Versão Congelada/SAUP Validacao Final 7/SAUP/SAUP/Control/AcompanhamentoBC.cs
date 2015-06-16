using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAUP.Model;
using SAUP.DAO;
using IBM.Data.DB2;

namespace SAUP.Control
{
    public class AcompanhamentoBC
    {

        private AcompanhamentoModel acompModel;
        private AcompanhamentoDAO acompDAO;
        List<AcompanhamentoModel> listaModel = new List<AcompanhamentoModel>();
        public AcompanhamentoBC()
        {

            acompModel = new AcompanhamentoModel();
            acompDAO = new AcompanhamentoDAO();

        }

        public DB2DataReader consulta_acompanhamento_By_Paciente(String filtroDrop, PacienteModel paciente)
        {
            AcompanhamentoDAO acompDAO = new AcompanhamentoDAO();
            return acompDAO.consulta_acompanhamento_By_Paciente(filtroDrop, paciente);
        
        }
        public DB2DataReader consulta_Historico_AcompanhamentoByID(AcompanhamentoModel acompanhamento)
        {
            AcompanhamentoDAO acompDAO = new AcompanhamentoDAO();
            return acompDAO.consulta_Historico_AcompanhamentoByID(acompanhamento);
        
        }
        public DB2DataReader consulta_acompanhamentoByID(AcompanhamentoModel acompanhamento)
        {

            return acompDAO.consulta_acompanhamentoByID(acompanhamento);
        }

        public String inserir_acompanhamento(AcompanhamentoModel acompanhamento)
        {

            listaModel.Add(acompanhamento);
            return acompDAO.inserir_acompanhamento(acompanhamento);


        }
        public String atualizar_acompanhamento(AcompanhamentoModel acompanhamento)
        {
            return acompDAO.atualizar_acompanhamento(acompanhamento);
        }

        public List<AcompanhamentoModel> get_acompanhamento(AcompanhamentoModel acompanhamento)
        {

            return listaModel;

        }

        public int retorna_StatusAcompahamentoByID(AcompanhamentoModel acomp)
        {
            int value = 0;
            DB2DataReader reader = acompDAO.retorna_StatusAcompahamentoByID(acomp);
            try
            {
                while (reader.Read())
                {
                    value = reader.GetInt32(0);
                }

                return value;
            }
            catch (DB2Exception)
            {
                value =0;
                return value;
            }
       
        }

        public int retorna_PacienteAcompahamentoByID(AcompanhamentoModel acomp)
        {

            int value = 0;
            DB2DataReader reader = acompDAO.retorna_PacienteAcompahamentoByID(acomp);
            while (reader.Read())
            {
                value = reader.GetInt32(0);
            }

            return value;   

        }

        public DB2DataReader retorna_Status_Acomp()
        {

            return acompDAO.retorna_Status_Acomp();
        }

        public String inserir_anexo(AnexoModel a, AcompanhamentoModel acompanhamento)
        {

            return acompDAO.inserir_anexo(a, acompanhamento);
        
        }
        public DB2DataReader retorna_Imagem_Acomp_Atual(int id_acompanhamento)
        {

            return acompDAO.retorna_Imagem_Acomp_Atual(id_acompanhamento);

        }

        public DB2DataReader retorna_Anexos()
        {
            return acompDAO.retorna_anexos();
        }
    }
}