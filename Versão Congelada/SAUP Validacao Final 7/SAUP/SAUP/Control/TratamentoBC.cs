using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAUP.Model;
using SAUP.DAO;
using IBM.Data.DB2;


namespace SAUP.Control
{
    public class TratamentoBC
    {


        public DB2DataReader consultar_Tratamento(String filtroDrop, TratamentoModel tratamento, TipoTratamentoModel tipoTratamento)
        {

            TratamentoDAO tratDAO = new TratamentoDAO();
            return tratDAO.consultar_Tratamento(filtroDrop, tratamento, tipoTratamento);

        }

        public DB2DataReader retorna_Todos_Tratamentos()
        {

            TratamentoDAO tratDAO = new TratamentoDAO();
            return tratDAO.retorna_Todos_Tratamentos();
        }

        public String vincula_Produto(TratamentoModel tratamento, ProdutoModel produto)
        {

            TratamentoDAO tratDao = new TratamentoDAO();
            return tratDao.vincula_Produto(tratamento, produto);


        }

        public String vincula_Procedimento(TratamentoModel tratamento, ProcedimentoModel procedimento)
        {
            TratamentoDAO tratDAO = new TratamentoDAO();
            return tratDAO.vincula_Procedimento(tratamento, procedimento);



        }

        public int retorna_tipo_Tratamento_By_ID_Tratamento(TratamentoModel tratamento)
        {


            TratamentoDAO TratDAO = new TratamentoDAO();
            return TratDAO.retorna_tipo_Tratamento_By_ID_Tratamento(tratamento);

        }


        public DB2DataReader retorna_procedimento_vinculado(TratamentoModel tratamento)
        {

            TratamentoDAO tratDAO = new TratamentoDAO();
            return tratDAO.retorna_procedimento_vinculado(tratamento);


        }

        public DB2DataReader retorna_produto_vinculado(TratamentoModel tratamento)
        {

            TratamentoDAO tratDAO = new TratamentoDAO();
            return tratDAO.retorna_produto_vinculado(tratamento);




        }



    }
}