using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;
using SAUP.Model;


namespace SAUP.DAO
{
    public class TratamentoDAO
    {
        DB2DataReader reader;
        DB2Connection db2;
        DB2Command comand;
        public DB2DataReader consultar_Tratamento(String filtroDrop, TratamentoModel tratamento, TipoTratamentoModel tipoTratamento)
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
                    case "Tipo Tratamento":
                        condicao = " TPTRAT.classificacao LIKE '%" + tipoTratamento.DESCRICAO + "%'";
                        break;
                    case "Descrição Tratamento":
                        condicao = " TRAT.DESCRICAOTRATAMENTO LIKE '%" + tratamento.descricaotratamento + "%'";
                        break;
                    case "Periodicidade":
                        condicao = " TRAT.PERIODICIDADE LIKE '%" + tratamento.periodicidade + "%'";
                        break;

                }

                comand.CommandText = "SELECT TRAT.ID_TRATAMENTO, " +
                                     "TPTRAT.CLASSIFICACAO, " +
                                     "TRAT.DESCRICAOTRATAMENTO, " +
                                     "TRAT.PERIODICIDADE " +
                                     "FROM DB2ADMIN.TRATAMENTO TRAT " +
                                     "JOIN DB2ADMIN.TIPOTRATAMENTO TPTRAT ON (TPTRAT.ID_TIPO_TRATAMENTO = TRAT.ID_TIPO_TRATAMENTO)" +
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


        public DB2DataReader retorna_Todos_Tratamentos()
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
                db2.Open();
                comand = new DB2Command();
                comand.Connection = db2;

                comand.CommandText = "SELECT ID_TRATAMENTO, ID_TIPO_TRATAMENTO, DESCRICAOTRATAMENTO, PERIODICIDADE " +
                                    "FROM DB2ADMIN.TRATAMENTO";

                reader = comand.ExecuteReader();


                return reader;

            }
            catch (DB2Exception)
            {

                reader = null;
                return reader;
            }


        }

        public String vincula_Produto(TratamentoModel tratamento, ProdutoModel produto)
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
                db2.Open();
                comand = new DB2Command();
                comand.Connection = db2;

                try
                {

                    comand.CommandText = "INSERT INTO DB2ADMIN.TRATAMENTO_POSSUE_PRODUTO (ID_TRATAMENTO, ID_PRODUTO, ID_TIPO_TRATAMENTO) " +
                                         " VALUES (" + tratamento.id_tratamento + "," + produto.id + "," + tratamento.id_tipo_tratamento + ")";

                    reader = comand.ExecuteReader();
                    return "Vinculação realizada com sucesso";
                }
                catch (DB2Exception e)
                {

                    return "Falhas ao realizar a vinculação de produtos. Verifique os dados selecionados em tela. Mensagem de erro:" +  e.Message + "Código do Erro :" +  e.ErrorCode;

                }
            }
            catch (DB2Exception)
            {
                return "Falhas ao realizar a vinculação de produtos, verifique a conexão com o banco de dados.";
            
            }

        }

        public String vincula_Procedimento(TratamentoModel tratamento, ProcedimentoModel procedimento)
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {

                db2.Open();
                comand = new DB2Command();
                comand.Connection = db2;

                try
                {

                    comand.CommandText = "INSERT INTO DB2ADMIN.TRATAMENTO_POSSUE_PROCEDIMENTO (ID_TRATAMENTO, ID_PROCEDIMENTO, ID_TIPO_TRATAMENTO)" +
                                        "VALUES (" + tratamento.id_tratamento + "," + procedimento.id + "," + tratamento.id_tipo_tratamento + ")";

                    reader = comand.ExecuteReader();
                    return "Vinculação de Procedimentos realizada com sucesso";
                }
                catch (DB2Exception e)
                {

                    return "Falhas ao realizar a vinculação de procedimentos. Verifique os dados selecionados em tela. Mensagem de erro:" + e.Message + "Código do Erro :" + e.ErrorCode;

                }

            }
            catch (DB2Exception)
            {
                return "Falhas ao realizar a vinculação de procedimentos. Verifique a conexão com o banco de dados";
            }
        }

        public int retorna_tipo_Tratamento_By_ID_Tratamento(TratamentoModel tratamento) { 
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
                db2.Open();
                comand = new DB2Command();
                comand.Connection = db2;
                int tipo_tratamento = 0;

                try
                {

                    comand.CommandText = "SELECT T.ID_TIPO_TRATAMENTO FROM TRATAMENTO T WHERE T.ID_TRATAMENTO =" + tratamento.id_tratamento;

                    reader = comand.ExecuteReader();

                    if (reader.Read() != null)
                    {
                        tipo_tratamento = Convert.ToInt32(reader.GetValue(0));

                    }
                    return tipo_tratamento;

                }
                catch (DB2Exception)
                {
                    reader = null;
                    return 0;

                }

            }
            catch (DB2Exception)
            {
                reader = null;
                return 0;
            }
          
        
        }

        public DB2DataReader retorna_procedimento_vinculado(TratamentoModel tratamento)
        {
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
                db2.Open();
                comand = new DB2Command();
                comand.Connection = db2;


                try
                {

                    comand.CommandText = "SELECT TTRAT.CLASSIFICACAO,P.DESCRICAO FROM DB2ADMIN.TRATAMENTO_POSSUE_PROCEDIMENTO TP " +
                                        " JOIN PROCEDIMENTO P ON (P.ID_PROCEDIMENTO = TP.ID_PROCEDIMENTO)" +
                                        " JOIN TIPOTRATAMENTO TTRAT ON (TTRAT.ID_TIPO_TRATAMENTO = TP.ID_TIPO_TRATAMENTO)" +
                                        " JOIN TRATAMENTO T ON (T.ID_TRATAMENTO = TP.ID_TRATAMENTO)" +
                                        " WHERE TP.ID_TRATAMENTO=" + tratamento.id_tratamento;

                    reader = comand.ExecuteReader();

                    return reader;


                }
                catch (DB2Exception e)
                {

                    return reader = null;

                }
            }
            catch (DB2Exception)
            {

                return reader = null;
            }
        
        
        }

        public DB2DataReader retorna_produto_vinculado(TratamentoModel tratamento)
        {
             db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
             try
             {
                 db2.Open();
                 comand = new DB2Command();
                 comand.Connection = db2;


                 try
                 {

                     comand.CommandText = "SELECT PROD.DESCRICAO,PROD.UNIDADE" +
                                         " FROM DB2ADMIN.TRATAMENTO_POSSUE_PRODUTO TP" +
                                         " JOIN PRODUTO PROD ON PROD.ID_PRODUTO = TP.ID_PRODUTO" +
                                         " JOIN TIPOTRATAMENTO TPTRAT ON TPTRAT.ID_TIPO_TRATAMENTO = TP.ID_TIPO_TRATAMENTO" +
                                         " JOIN TRATAMENTO T ON T.ID_TRATAMENTO = TP.ID_TRATAMENTO" +
                                         " WHERE TP.ID_TRATAMENTO = " + tratamento.id_tratamento;

                     reader = comand.ExecuteReader();

                     return reader;


                 }
                 catch (DB2Exception)
                 {

                     return reader = null;

                 }
             }
             catch (DB2Exception)
             {
                 return reader = null;
             }
        }
    }
}