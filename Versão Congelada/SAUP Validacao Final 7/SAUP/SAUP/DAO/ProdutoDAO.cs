using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;
using SAUP.Control;
using System.Configuration;
using SAUP.Model;


namespace SAUP.DAO
{
    public class ProdutoDAO
    {
        GerenciadorBanco g;
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;

        public DB2DataReader consultar_Produto()
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                comand.CommandText = "SELECT p.ID_PRODUTO, p.DESCRICAO, p.UNIDADE FROM DB2ADMIN.PRODUTO p";

                reader = comand.ExecuteReader();


                return reader;
            }
            catch (DB2Exception)
            {
                reader = null;
                return reader;
            }


        }

        public String Inserir_Produto(ProdutoModel produto)
        {
          
            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {

                    comand.CommandText = "INSERT INTO DB2ADMIN.PRODUTO (DESCRICAO, UNIDADE) VALUES ('" + produto.descricao + "','" + produto.unidade + "')";

                    reader = comand.ExecuteReader();

                    return "Cadastrado com Sucesso!";

                }
                catch (DB2Exception)
                {
                    return "Falhas na Inserção de Produto, verifique se os dados inseridos estão corretos.";
                }
            }
            catch (DB2Exception)
            {
                return "Falhas na inserção de produtos,verifique a conexão com o banco de dados.";
            }
        }


        public String Editar_Produto(ProdutoModel produto)
        {

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {

                    comand.CommandText = "UPDATE PRODUTO SET DESCRICAO ='" + produto.descricao + "', UNIDADE ='" + produto.unidade + "' WHERE ID_PRODUTO=" + produto.id;

                    reader = comand.ExecuteReader();


                    return " Produto atualizado com sucesso!";

                }
                catch (DB2Exception)
                {
                    return "Falhas na atualização do produto verifique as informações inseridas";
                }
            }
            catch (DB2Exception)
            {

                return "Falhas na atualização do produto, verifique a conexão com o banco de dados";
            }
        }




    }
}