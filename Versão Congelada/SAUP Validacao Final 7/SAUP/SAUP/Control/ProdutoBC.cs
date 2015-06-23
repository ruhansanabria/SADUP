using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAUP.Model;
using SAUP.Control;
using SAUP.DAO;
using IBM.Data.DB2;

namespace SAUP.Control
{
    public class ProdutoBC
    {

        public DB2DataReader consultar_Produto()
        {
            ProdutoDAO produto = new ProdutoDAO();
            return produto.consultar_Produto();
        }

        public String Inserir_Produto(ProdutoModel produtos)
        {
            ProdutoDAO produto = new ProdutoDAO();
            return produto.Inserir_Produto(produtos);
        }

        public String Editar_Produto(ProdutoModel produtos)
        {
            ProdutoDAO produto = new ProdutoDAO();
            return produto.Editar_Produto(produtos);
        }


    }
}