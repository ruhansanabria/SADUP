using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IBM.Data.DB2;
using SAUP.Control;
using System.Configuration;
using SAUP.Model;
using System.Data;

namespace SAUP.DAO
{
    public class AcompanhamentoDAO
    {
        GerenciadorBanco g;
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;
        public AcompanhamentoDAO() 
        { 
        
        }


        public DB2DataReader consulta_acompanhamento_By_Paciente(String filtroDrop, PacienteModel paciente)
        {

            String condicao = "";
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {               

                    db2.Open();

                    comand = new DB2Command();
                    comand.Connection = db2;

                    switch (filtroDrop)
                    {
                        case "Nome":
                            condicao = " P.NOME LIKE '%" + paciente.nome + "%'";
                            break;
                        case "RG":
                            condicao = " P.RG LIKE '%" + paciente.rg + "%'";
                            break;
                        case "CPF":
                            condicao = " P.CPF LIKE '%" + paciente.cpf + "%'";
                            break;

                    }
                        //Select que busca o acompanhamento ativo com FLAG_ALTA = 1 -NAO ESTA EM ALTA
                        // E status acompanhamento = 2 que significa que esta em andamento
                        comand.CommandText = "SELECT max(A.ID_ACOMPANHAMENTO) AS ID_ACOMPANHAMENTO,P.NOME,P.RG,P.CPF, " +
                                             " max(A.DATAREALIZACAO) AS DATAREALIZACAO, " +
                                             " max(SACOMP.DESCRICAO) AS STATUS_ACOMPANHAMENTO_DESCRICAO, " +
                                             " max(TRAT.DESCRICAOTRATAMENTO) AS DESCRICAO_TRATAMENTO, " +
                                             " max(A.INFORMACOESCOMPLEMENTARES) AS INFORMACOESCOMPLEMENTARES, " +
                                             " max(ENF.NOME_ENFERMEIRO) AS NOME_ENFERMEIRO, " +
                                             " max(A.PONTUACAO_RECALCULADA) AS ULTIMA_PONTUACAO, " +
                                             " max(A.PRIORIDADE) AS ULTIMA_PRIORIDADE " +
                                             " FROM DB2ADMIN.ACOMPANHAMENTO A  " +
                                             " JOIN PACIENTE P ON (P.ID_PACIENTE = A.ID_PACIENTE) " +
                                             " JOIN STATUS_ACOMPANHAMENTO SACOMP  ON (SACOMP.ID_STATUS_ACOMPANHAMENTO = A.ID_STATUSACOMPANHAMENTO) " +
                                             " JOIN TRATAMENTO TRAT ON (TRAT.ID_TRATAMENTO = A.ID_TRATAMENTO) " +
                                             " JOIN ENFERMEIRO ENF ON (ENF.ID_ENFERMEIRO = A.ID_ENFERMEIRO)  " +
                                             " WHERE " + condicao +
                                             " AND A.FLAG_ALTA =1 " +
                                             " AND A.ID_STATUSACOMPANHAMENTO =2 "+
                                             " GROUP BY P.NOME,P.RG,P.CPF,SACOMP.DESCRICAO";

                        reader = comand.ExecuteReader();

                        
             
               
            }catch (DB2Exception)
            {
                // Tratamento em View
                return null;
            
            
            }
            return reader;
            
        }
       
        public String inserir_acompanhamento(AcompanhamentoModel acom)
        {

            try
            {
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            db2.Open();

            comand = new DB2Command();
            comand.Connection = db2;

            try
            {

                comand.CommandText = "INSERT INTO ACOMPANHAMENTO (ID_TRATAMENTO, DATAREALIZACAO, ID_STATUSACOMPANHAMENTO, INFORMACOESCOMPLEMENTARES, ID_PACIENTE,FLAG_ALTA, ID_ENFERMEIRO, PONTUACAO_RECALCULADA, PRIORIDADE) " +
                                    " VALUES (" + acom.Id_tratamento + ",  CURRENT TIMESTAMP ," + acom.Status_Acompanhamento + ",'" + acom.Informacoes_Complementares + "'," + acom.Id_Paciente + "," + acom.flag_alta + "," + acom.id_enfermeiro + "," + acom.pontuacao + ",'" + acom.prioridade + "')";
                reader = comand.ExecuteReader();
            }
            catch
            {
                return "Houve problemas com a inserção,";
            }

                db2.Close();

                AcompanhamentoDAO acompanhamento = new AcompanhamentoDAO();
                acompanhamento.inserir_historico(acom);
                              
                return "Inserção de acompanhamento, realizada com sucesso para o paciente";

            }
            catch (DB2Exception)
            {
                return "Falha na inserção do acompanhamento, verifique a conexão com o banco de dados";
            
            }

          
        }

        public DB2DataReader consulta_acompanhamentoByID(AcompanhamentoModel acompanhamento)
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                try
                {
                    comand.CommandText = "SELECT TRAT.DESCRICAOTRATAMENTO, A.DATAREALIZACAO, " +
                                         " SACOMP.DESCRICAO, A.INFORMACOESCOMPLEMENTARES, " +
                                        " p.NOME, ENF.NOME_ENFERMEIRO, " +
                                        "A.PONTUACAO_RECALCULADA,A.PRIORIDADE " +
                                       " FROM DB2ADMIN.ACOMPANHAMENTO A " +
                                       " JOIN PACIENTE P ON (P.ID_PACIENTE = A.ID_PACIENTE) " +
                                       " JOIN STATUS_ACOMPANHAMENTO SACOMP  ON (SACOMP.ID_STATUS_ACOMPANHAMENTO = A.ID_STATUSACOMPANHAMENTO) " +
                                       " JOIN TRATAMENTO TRAT ON (TRAT.ID_TRATAMENTO = A.ID_TRATAMENTO) " +
                                       " JOIN ENFERMEIRO ENF ON (ENF.ID_ENFERMEIRO = A.ID_ENFERMEIRO) " +
                                       "WHERE A.ID_ACOMPANHAMENTO =" + acompanhamento.Id_acompanhamento;
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
                //Tratamento em View
                return null;
            
            }
        
        }
        public DB2DataReader consulta_Historico_AcompanhamentoByID(AcompanhamentoModel acompanhamento)
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                try
                {
                    comand.CommandText = "SELECT A.DATAREALIZACAO, TRAT.DESCRICAOTRATAMENTO, " +
                                         " A.PRIORIDADE, A.INFORMACOESCOMPLEMENTARES, " +
                                         " A.PONTUACAO_RECALCULADA " +
                                       " FROM DB2ADMIN.HISTORICO_ACOMPANHAMENTO A " +
                                       " JOIN TRATAMENTO TRAT ON (TRAT.ID_TRATAMENTO = A.ID_TRATAMENTO) " +
                                      "WHERE A.ID_ACOMPANHAMENTO =" + acompanhamento.Id_acompanhamento;
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
                //Tratamento em View
                return null;

            }

        }
        public String atualizar_acompanhamento(AcompanhamentoModel acom)
        {

            try
            {

                db2 = new DB2Connection("Database=SAMPLE");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {

                    comand.CommandText = "UPDATE DB2ADMIN.ACOMPANHAMENTO A " +
                                       " SET  " +
                                       "     A.ID_TRATAMENTO = " + acom.Id_tratamento + " ," +
                                       "     A.DATAREALIZACAO = CURRENT TIMESTAMP, " +
                                       "     A.ID_STATUSACOMPANHAMENTO = " + acom.Status_Acompanhamento + " ," +
                                       "     A.INFORMACOESCOMPLEMENTARES = '" + acom.Informacoes_Complementares + "' ," +
                                       "     A.ID_PACIENTE = " + acom.Id_Paciente + " ," +
                                       "     A.FLAG_ALTA = " + acom.flag_alta + ", " +
                                       "     A.ID_ENFERMEIRO = " + acom.id_enfermeiro + " ," +
                                       "     A.PONTUACAO_RECALCULADA = " + acom.pontuacao + " ," +
                                       "     A.PRIORIDADE = '" + acom.prioridade + "' " +
                                       " WHERE  A.ID_ACOMPANHAMENTO = " + acom.Id_acompanhamento;
                    reader = comand.ExecuteReader();

                    db2.Close();

                    AcompanhamentoDAO acompanhamento = new AcompanhamentoDAO();
                    acompanhamento.inserir_historico(acom);


                    return "Atualizada com sucesso!!";
                }
                catch (DB2Exception)
                {
                    return "Ocorreu um erro na atualização, verifique os dados que foram selecionados em tela !";
                }

            }
            catch (DB2Exception)
            {

                return "Não foi possível realização a atualização, verifique a conexão com o banco de dados";
            
            }


        }

        public DB2DataReader selectAcompanhamento(String filtro, String valorcampo)
        {
            String condicao = "";
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
                db2.Open();

                comand = new DB2Command();

                switch (valorcampo)
                {
                    case "Codigo":
                        condicao = " AC.ID_ACOMPANHAMENTO = " + filtro;
                        break;
                    case "Nome":
                        condicao = " PAC.NOME LIKE '%" + filtro + "%'";
                        break;

                }

                comand.Connection = db2;

                try
                {
                    comand.CommandText = "SELECT " +
                                        " AC.ID_ACOMPANHAMENTO, " +
                                        " TPTRAT.CLASSIFICACAO, " +
                                        " TRAT.DESCRICAOTRATAMENTO," +
                                        " AC.DATAREALIZACAO, " +
                                        " STATUS_ACOM.DESCRICAO," +
                                        " AC.INFORMACOESCOMPLEMENTARES," +
                                        " PAC.NOME " +
                                    " FROM ACOMPANHAMENTO AC " +
                                    "JOIN PACIENTE PAC ON PAC.ID_PACIENTE = AC.ID_PACIENTE " +
                                    " JOIN TIPOTRATAMENTO TPTRAT ON TPTRAT.ID_TIPO_TRATAMENTO = AC.ID_TIPO_TRATAMENTO " +
                                    " JOIN TRATAMENTO TRAT ON TRAT.ID_TRATAMENTO = AC.ID_TRATAMENTO " +
                                    " JOIN STATUS_ACOMPANHAMENTO STATUS_ACOM ON STATUS_ACOM.ID_STATUS_ACOMPANHAMENTO = AC.ID_STATUSACOMPANHAMENTO " +
                                    " where" + condicao;

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

        public DataTable get_Acompanhamentos()
        {
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            DataTable data = new DataTable();
            DB2DataReader reader;
            try
            {
                db2.Open();
                
                comand = new DB2Command();
                comand.Connection = db2;

                try
                {

                    comand.CommandText = "SELECT AC.ID_ACOMPANHAMENTO,AC.PRIORIDADE, P.NOME," +
                                        "AC.DATAREALIZACAO, " +
                                        "(AC.DATAREALIZACAO + 1 DAY) AS TEMPO_RESTANTE, " +
                                        "(SC.DESCRICAO) AS STATUSACOMPANHAMENTO " +
                                        "FROM ACOMPANHAMENTO AC " +
                                        "JOIN PACIENTE P ON (P.ID_PACIENTE = AC.ID_PACIENTE ) " +
                                        "JOIN STATUS_ACOMPANHAMENTO SC ON (SC.ID_STATUS_ACOMPANHAMENTO = AC.ID_STATUSACOMPANHAMENTO) " +
                                        "WHERE  AC.FLAG_ALTA =1 " +
                                        "AND AC.ID_STATUSACOMPANHAMENTO =2 " +
                                         "ORDER BY TEMPO_RESTANTE, AC.PRIORIDADE";
                                        
                                       
                                       

                    reader = comand.ExecuteReader();
                    data.Load(reader,LoadOption.OverwriteChanges);
                    return data;
                }
                catch (DB2Exception)
                {
                    data = null;
                    return data;
                
                }

            }
            catch (DB2Exception)
            {
                data = null;
                return data;
            
            }
        }

        public DB2DataReader retorna_StatusAcompahamentoByID(AcompanhamentoModel acomp)
        {

            db2 = new DB2Connection("Database=SAMPLE");

            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;
                try
                {
                    comand.CommandText = "SELECT A.ID_STATUSACOMPANHAMENTO FROM DB2ADMIN.ACOMPANHAMENTO A WHERE A.ID_ACOMPANHAMENTO = " + acomp.Id_acompanhamento;

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

        public DB2DataReader retorna_PacienteAcompahamentoByID(AcompanhamentoModel acomp)
        {

            db2 = new DB2Connection("Database=SAMPLE");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;
                try
                {
                    comand.CommandText = "SELECT A.ID_PACIENTE FROM DB2ADMIN.ACOMPANHAMENTO A WHERE A.ID_ACOMPANHAMENTO = " + acomp.Id_acompanhamento;

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

        public DB2DataReader retorna_Status_Acomp()
        {

            db2 = new DB2Connection("Database=SAMPLE");

            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;
                try
                {
                    comand.CommandText = "SELECT ID_STATUS_ACOMPANHAMENTO, DESCRICAO " +
                                          "FROM DB2ADMIN.STATUS_ACOMPANHAMENTO";

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

        public String inserir_historico(AcompanhamentoModel acom)
        {
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
            db2.Open();

            comand = new DB2Command();
            comand.Connection = db2;

            try
            {
                comand.CommandText = "INSERT INTO DB2ADMIN.HISTORICO_ACOMPANHAMENTO (ID_ACOMPANHAMENTO, ID_TRATAMENTO, DATAREALIZACAO, ID_STATUSACOMPANHAMENTO, INFORMACOESCOMPLEMENTARES, ID_PACIENTE, FLAG_ALTA, ID_ENFERMEIRO, PONTUACAO_RECALCULADA,PRIORIDADE) " +
                                           "VALUES ((SELECT max(ID_ACOMPANHAMENTO) FROM ACOMPANHAMENTO WHERE ID_PACIENTE= " + acom.Id_Paciente + ")," + acom.Id_tratamento + ",  CURRENT TIMESTAMP ," + acom.Status_Acompanhamento + ",'" + acom.Informacoes_Complementares + "'," + acom.Id_Paciente + "," + acom.flag_alta + "," + acom.id_enfermeiro + "," + acom.pontuacao + ",'" + acom.prioridade + "')";

                reader = comand.ExecuteReader();

                return "Inserido Historico com sucesso";
            }
            catch (DB2Exception)
            {

                return "Não foi possível inserir o histórico do acompanhamento.O acompanhamento atual já foi salvo.";
            }

            }catch(DB2Exception)
            {
            
            
            return "Ocorreram falhas ao salvar o acompanhamento, verifique a conexão com o banco de dados";
            
            }
        
        }


        public String inserir_anexo(AnexoModel a,AcompanhamentoModel acompanhamento)
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {
                    if ((acompanhamento.Id_acompanhamento) == 0)
                    {
                        comand.CommandText = "INSERT INTO DB2ADMIN.ANEXO (ID_HISTORICO_ACOMPANHAMENTO, ID_ACOMPANHAMENTO, CAMINHO, NOME_ANEXO) " +
                                              "VALUES ((select max(id_historico_acompanhamento) from historico_acompanhamento where id_paciente=" + acompanhamento.Id_Paciente + ")," + "(select max(id_acompanhamento) from acompanhamento where id_paciente=" + acompanhamento.Id_Paciente + ") ,'" + a.caminho + "' ,'" + a.nome_Anexo + "')";
                    }
                    else
                    {

                        comand.CommandText = "INSERT INTO DB2ADMIN.ANEXO (ID_HISTORICO_ACOMPANHAMENTO, ID_ACOMPANHAMENTO, CAMINHO, NOME_ANEXO) " +
                                         "VALUES ((select max(id_historico_acompanhamento) from historico_acompanhamento where id_paciente=" + acompanhamento.Id_Paciente + ")," + acompanhamento.Id_acompanhamento + ",'" + a.caminho + "' ,'" + a.nome_Anexo+"')";
                    }
                    reader = comand.ExecuteReader();

                    return "Inserido Anexo com sucesso";

                }
                catch (DB2Exception)
                {
                    return "Ocorreram falhas ao salvar o anexo,verifique o formato ou o tamanho do arquivo. Limite 10MB.";

                }
            }
            catch (DB2Exception)
            {
                return "Não possível gravar o anexo, verifique se a conexão está ativa";
            
            }
        
        
        
        }

        public DB2DataReader retorna_Imagem_Acomp_Atual(int id_acompanhamento)
        {

            db2 = new DB2Connection("Database=SAMPLE");

            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {
                    comand.CommandText = "SELECT A.ID_ACOMPANHAMENTO, A.CAMINHO, AC.DATAREALIZACAO, TRAT.DESCRICAOTRATAMENTO, AC.PONTUACAO_RECALCULADA "+
                                          "FROM DB2ADMIN.ANEXO A "+
                                          "JOIN DB2ADMIN.HISTORICO_ACOMPANHAMENTO AC ON (A.ID_HISTORICO_ACOMPANHAMENTO = AC.ID_HISTORICO_ACOMPANHAMENTO) "+
                                          "JOIN DB2ADMIN.TRATAMENTO TRAT ON (TRAT.ID_TRATAMENTO = AC.ID_TRATAMENTO) "+
                                           "WHERE A.ID_ACOMPANHAMENTO = " + id_acompanhamento;
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


        public DB2DataReader retorna_anexos()
        {
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {
                    comand.CommandText = "SELECT ID_ANEXO, ID_HISTORICO_ACOMPANHAMENTO, ID_ACOMPANHAMENTO, CAMINHO, NOME_ANEXO" +
                                        " FROM DB2ADMIN.ANEXO";

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
       
    }
}