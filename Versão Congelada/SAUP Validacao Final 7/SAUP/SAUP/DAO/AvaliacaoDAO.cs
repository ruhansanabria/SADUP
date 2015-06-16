using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;
using SAUP.Model;


namespace SAUP.DAO
{
    public class AvaliacaoDAO
    {
      
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;

        public DB2DataReader consulta_acompanhamento_By_Paciente(String filtroDrop,PacienteModel paciente)
        {

            String condicao ="";
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                switch (filtroDrop)
                {
                    case "RG":
                        condicao = " P.RG LIKE '%" + paciente.rg + "%'";
                        break;
                    case "CPF":
                        condicao = " P.CPF LIKE '%" + paciente.cpf + "%'";
                        break;

                }
                try
                {
                    comand.CommandText = "SELECT A.ID_ACOMPANHAMENTO, A.ID_TRATAMENTO, A.DATAREALIZACAO, A.ID_STATUSACOMPANHAMENTO, A.INFORMACOESCOMPLEMENTARES, A.ID_PACIENTE, A.FLAG_ALTA, ID_ENFERMEIRO, PONTUACAO_RECALCULADA " +
                                        " FROM DB2ADMIN.ACOMPANHAMENTO A, P.NOME " +
                                          " FROM DB2ADMIN.ACOMPANHAMENTO A " +
                                          " JOIN PACIENTE P ON (P.ID_PACIENTE = A.ID_PACIENTE)" +
                                          " WHERE " + condicao;

                    reader = comand.ExecuteReader();
                    return reader;
                }
                catch (DB2Exception)
                {
                    reader = null;
                    return reader;
                }


            }
            catch (DB2Exception)
            {
                reader = null;
                return reader;
            }
        }

        public String inserir_avaliacao(EnfermeiroModel enfermeiro, AvaliacaoModel avaliacao, TratamentoModel tratamento, PacienteModel paciente, int pontuacao)
        {

            String resulta_sucesso = "Avaliação salva com sucesso";
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {
                    comand.CommandText = "INSERT INTO DB2ADMIN.AVALIACAO (ID_TIPO_TRATAMENTO, ID_TRATAMENTO, DATAREALIZACAO, PONTUACAO, ID_PACIENTE)" +
                                         " VALUES ( " + tratamento.id_tipo_tratamento + "," + tratamento.id_tratamento + ", CURRENT TIMESTAMP ," + pontuacao + "," + paciente + ")";


                    return resulta_sucesso;
                }
                catch (DB2Exception e)
                {

                    return "Falhas na inserção, verificar" + "Mensagem de Erro" + e.Message + " Código de Erro :" + e.ErrorCode;

                }
            }
            catch (DB2Exception e)
            {

                return "Ocorreram falhas na inserção, verifique a conexão com o banco. Código do Erro :" + e.ErrorCode;
            }
        }


        public String inserir_enfermeiro_avaliacao(EnfermeiroModel enfermeiro,PacienteModel paciente)
        {

            String resulta_sucesso = "Avaliação salva com sucesso";
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {
                    comand.CommandText = "INSERT INTO DB2ADMIN.ENFERMEIRO_REALIZA_AVALIACAO (ID_ENFERMEIRO, ID_PERFIL_ENFERMEIRO, ID_AVALIACAO, ID_PACIENTE)" +
                                          "VALUES ( " + enfermeiro.Id_enfermeiro + ", " + enfermeiro.Id_Perfil_Enf + " , (SELECT max(id_avaliacao) + 1 FROM AVALIACAO) ," + paciente.id + ")";


                    return resulta_sucesso;
                }
                catch (DB2Exception e)
                {

                    return "Falhas na inserção, verificar" + "Mensagem de Erro" + e.Message + " Código de Erro :" + e.ErrorCode;

                }
            }
            catch (DB2Exception e)
            {

                return "Falhas na inserção, verificar" + "Mensagem de Erro" + e.Message + " Código de Erro :" + e.ErrorCode;
            }
        }

    }
}