using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAUP.Model;
using IBM.Data.DB2;

namespace SAUP.DAO
{
    public class ImagemDAO
    {
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;

        public String inserir_anexo_avaliacao(AvaliacaoModel avaliacao, String caminho, String nome_anexo, byte arquivo)
        {

            {

                String resulta_sucesso = "Imagem salva com sucesso";
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

                try
                {
                    db2.Open();

                    comand = new DB2Command();
                    comand.Connection = db2;

                    try
                    {
                        comand.CommandText = "INSERT INTO DB2ADMIN.ANEXO (ID_AVALIACAO, ID_ACOMPANHAMENTO, ID_TRATAMENTO, CAMINHO, NOME_ANEXO, ARQUIVO) " +
                                             " VALUES ( (SELECT max(id_avaliacao) + 1 FROM AVALIACAO), " + avaliacao.id_Tratamento + " ," + caminho + "," + nome_anexo + "," + arquivo + ")";


                        return resulta_sucesso;
                    }
                    catch (DB2Exception e)
                    {

                        return "Falhas na inserção, verificar" + "Mensagem de Erro" + e.Message + " Código de Erro :" + e.ErrorCode;

                    }
                }
                catch (DB2Exception)
                {

                    return "Falhas na inserção, verificar a conexão com o banco de dados para proceder a operação.";
                }
            }
        
        }

        public String inserir_anexo_acompanhamento(AvaliacaoModel avaliacao,AcompanhamentoModel acompanhamento, String caminho, String nome_anexo, byte arquivo)
        { 
         String resulta_sucesso = "Imagem salva com sucesso";
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                try
                {
                    db2.Open();

                    comand = new DB2Command();
                    comand.Connection = db2;

                    try
                    {
                        comand.CommandText = "INSERT INTO DB2ADMIN.ANEXO (ID_AVALIACAO, ID_ACOMPANHAMENTO, ID_TRATAMENTO, CAMINHO, NOME_ANEXO, ARQUIVO) " +
                                             " VALUES ( (SELECT max(id_avaliacao) + 1 FROM AVALIACAO)," + acompanhamento.Id_acompanhamento + "," + avaliacao.id_Tratamento + " ," + caminho + "," + nome_anexo + "," + arquivo + ")";


                        return resulta_sucesso;
                    }
                    catch (DB2Exception e)
                    {

                        return "Falhas na inserção, verificar" + "Mensagem de Erro" + e.Message + " Código de Erro :" + e.ErrorCode;

                    }
                }
                catch (DB2Exception)
                {
                    return "Falhas na inserção, verificar conexão com o banco de dados.";
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
                    comand.CommandText = "SELECT ID_ANEXO, ID_HISTORICO_ACOMPANHAMENTO, ID_ACOMPANHAMENTO, CAMINHO, NOME_ANEXO"+
                                        "FROM DB2ADMIN.ANEXO";

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