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
    public class EnfermeiroDAO
    {
        GerenciadorBanco g;
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;
        public EnfermeiroDAO() 
        {                
         
        }

        public DB2DataReader consultar_enfermeiro(String filtroDrop,EnfermeiroModel enf, PerfilEnfermeiroModel perfEnfModel) 
        {
            
            string condicao;

            ////string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                switch (filtroDrop)
                {
                    case "Nome":
                       condicao = " enf.NOME_ENFERMEIRO LIKE '%" + enf.Nome + "%'";
                        break;
                    case "Codigo":
                        condicao = " enf.ID_ENFERMEIRO = " + enf.Id_enfermeiro;
                        break;
                    case "Status":
                        condicao = " enf.STATUS_ENFERMEIRO LIKE '%" + enf.Status + "%'";
                        break;
                    case "PerfilEnfermeiro":
                        condicao = " pf.DESCRICAO LIKE '%" + perfEnfModel.DESCRICAO + "%'";
                        break;
                    default:
                        condicao = " enf.NOME_ENFERMEIRO LIKE '%" + enf.Nome + "%'";
                        break;
                }
                try
                {
                    comand.CommandText = "SELECT " +
                                            " enf.ID_ENFERMEIRO," +
                                            " enf.NOME_ENFERMEIRO," +
                                            " enf.STATUS_ENFERMEIRO," +
                                            " pf.DESCRICAO," +
                                            " enf.USER_NAME " +

                                        " FROM DB2ADMIN.ENFERMEIRO enf " +
                                         "   JOIN DB2ADMIN.PERFILENFERMEIRO pf ON pf.ID_PERFIL_ENFERMEIRO=enf.PERFIL_ENFERMEIRO_ID" +
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

        public DB2DataReader consultar_user(String user_name,String senha,EnfermeiroModel enf)
        {

            //string condicao;

            ////string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                comand.CommandText = "SELECT " +
                                        " enf.USER_NAME," +
                                        " enf.SENHA " +
                                    " FROM DB2ADMIN.ENFERMEIRO enf " +
                                    " WHERE enf.USER_NAME ='" + enf.User_Name + "'" + " AND enf.senha='" + enf.Password + "' AND enf.status_enfermeiro = 'Ativo'";



                reader = comand.ExecuteReader();


                return reader;

            }
            catch (DB2Exception e)
            {
                e.Errors.ToString();
                reader = null;
                return reader;
            }


        }

        public String inserir_enfermeiro(EnfermeiroModel enf)
        { 
        
         db2 = new DB2Connection("Database=SAMPLE");

         try
         {
             db2.Open();

             comand = new DB2Command();
             comand.Connection = db2;

             try
             {

                 comand.CommandText = "INSERT INTO DB2ADMIN.ENFERMEIRO (NOME_ENFERMEIRO, STATUS_ENFERMEIRO, PERFIL_ENFERMEIRO_ID, USER_NAME, SENHA) VALUES ('" + enf.Nome + "','" + enf.Status + "'," + enf.Id_Perfil_Enf + ",'" + enf.User_Name + "','" + enf.Password + "')";
                 reader = comand.ExecuteReader();


                 return "Inserido com Sucesso!";
             }
             catch (DB2Exception )
             {
                 return "Falhas na inserção, verique os dados inseridos em tela e tente novamente.Verifique se foi selecionado um perfil.";
             }
         }
         catch (DB2Exception)
         {
             return "Falhas na inserção, verifique a conexão com o banco de dados.";
         
         }
       }

        public String excluir_enfermeiro(EnfermeiroModel enf)
        {
            String resultado_banco = "Excluído com sucesso.";
            db2 = new DB2Connection("Database=SAMPLE");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                return resultado_banco;
            }
            catch (DB2Exception)
            {
                return "Não foi possível realizar a exclusão, enfermeiro já realicionado a acompanhamentos. Pode inativa-lo.";
             
            }

        }

        public String atualizar_enfermeiro(EnfermeiroModel enf)
        {
            
            db2 = new DB2Connection("Database=SAMPLE");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;
                try
                {
                    comand.CommandText = "UPDATE DB2ADMIN.ENFERMEIRO ENF " +
                                         " SET ENF.NOME_ENFERMEIRO = '" + enf.Nome + "' ," +
                                         " ENF.STATUS_ENFERMEIRO = '" + enf.Status + "' ," +
                                         " ENF.PERFIL_ENFERMEIRO_ID =" + enf.Id_Perfil_Enf + "," +
                                         " ENF.USER_NAME  = '" + enf.User_Name + "' ," +
                                         " ENF.SENHA = '" + enf.Password + "'" +
                                         " WHERE ENF.USER_NAME = '" + enf.User_Name + "'";

                    reader = comand.ExecuteReader();

                    return "Atualização Realizada com sucesso";
                }
                catch (DB2Exception)
                {

                    return "Houveram falhas na atualização , por gentileza verifique com o administrador";
                }
            }
            catch (DB2Exception)
            {

                return "Houveram falhas na atualização, verifique a conexão com o banco de dados";
            }
        }

        public List<EnfermeiroModel> get_Enfermeiros() {

            List<EnfermeiroModel> list_enf = new List<EnfermeiroModel>();

            return list_enf;     
        
        }


        public DB2DataReader retorn_EnfPerfById(AnamneseModel anamnese)
        {
            db2 = new DB2Connection("Database=SAMPLE");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                comand.CommandText = "SELECT ENF.PERFIL_ENFERMEIRO_ID FROM DB2ADMIN.ENFERMEIRO ENF WHERE ENF.ID_ENFERMEIRO = " + anamnese.id_Enfermeiro;



                reader = comand.ExecuteReader();


                return reader;

            }
            catch (DB2Exception)
            {

                reader = null;
                return reader;
            }
            
        }

        public DB2DataReader retorn_EnfIDByuser_name(EnfermeiroModel enf)
        {
            db2 = new DB2Connection("Database=SAMPLE");

            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                comand.CommandText = "SELECT ENF.ID_ENFERMEIRO FROM DB2ADMIN.ENFERMEIRO ENF WHERE ENF.USER_NAME LIKE '%" + enf.User_Name + "%'";


                reader = comand.ExecuteReader();


                return reader;

            }
            catch (DB2Exception) {

                reader = null;
                return reader;
            }

        }

        public DB2DataReader SelectedMenu(EnfermeiroModel enf)
        {
            db2 = new DB2Connection("Database=SAMPLE");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                comand.CommandText = "SELECT " +
                                        "pf.DESCRICAO " +
                                     "FROM " +
                                        "DB2ADMIN.ENFERMEIRO ENF " +
                                        "JOIN DB2ADMIN.PERFILENFERMEIRO PF ON PF.ID_PERFIL_ENFERMEIRO = ENF.PERFIL_ENFERMEIRO_ID  " +
                                     "WHERE " +
                                        " ENF.USER_NAME= '" + enf.User_Name + "'";

                reader = comand.ExecuteReader();


                return reader;

            }
            catch (DB2Exception)
            {
                reader = null;
                return reader;
            }

        }

        public DB2DataReader retorn_EnfUserNameUniqueByuser_name(EnfermeiroModel enf)
        {
            db2 = new DB2Connection("Database=SAMPLE");

            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                comand.CommandText = "SELECT ENF.USER_NAME FROM DB2ADMIN.ENFERMEIRO ENF WHERE ENF.USER_NAME= '" + enf.User_Name + "'";


                reader = comand.ExecuteReader();

                if (reader.HasRows)
                {

                    return reader;
                }
                else
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