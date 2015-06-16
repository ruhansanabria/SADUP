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
    public class PacienteDAO
    {

        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;
        string condicao = "";


        public String Inserir_Paciente(PacienteModel paciente)
        {

            string condicao;
            try
            {
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                comand.CommandText = "INSERT INTO DB2ADMIN.PACIENTE (NOME, RG, CPF, TELEFONE, SEXO, DATA_NASCIMENTO)" +
                          "VALUES ('" + paciente.nome + "','" + paciente.rg + "','" + paciente.cpf + "','" + paciente.telefone + "','" + paciente.sexo + "',TO_DATE('" + paciente.Data_Nascimento + "','dd-mm-YYYY')" + " )";



                reader = comand.ExecuteReader();
                return "Inserido com Sucesso!";

            }
            catch (DB2Exception)
            {
                return "Problemas ao realizar a inserção de dados, verifique a conexão com o banco de dados";
            }



        }

        public String Editar_Paciente(PacienteModel paciente)
        {

            try
            {
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;



                comand.CommandText = "UPDATE PACIENTE " +
                                    "SET NOME ='" + paciente.nome + "'," +
                                        "RG =" + paciente.rg + "," +
                                       " CPF =" + paciente.cpf + "," +
                                        "TELEFONE =" + paciente.telefone + "," +
                                        "SEXO ='" + paciente.sexo + "'," +
                                       " DATA_NASCIMENTO ='" + paciente.Data_Nascimento + "'" +
                                   " WHERE" +
                                       " ID_PACIENTE =" + paciente.id;




                reader = comand.ExecuteReader();
                return "Editado com Sucesso!";
            }
            catch (DB2Exception)
            {

                return "Não foi possível realizar a edição , verifique a conexão com o banco de dados!";
            }


        }

        public DB2DataReader consultar_Paciente(String filtroDrop, PacienteModel paciente)
        {

            string condicao;
            try
            {
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                switch (filtroDrop)
                {
                    case "Nome":
                        condicao = " p.NOME LIKE '%" + paciente.nome + "%'";
                        break;
                    case "RG":
                        condicao = " p.RG LIKE '%" + paciente.rg + "%'";
                        break;
                    case "CPF":
                        condicao = " p.CPF LIKE '%" + paciente.cpf + "%'";
                        break;
                    default:
                        condicao = " p.NOME LIKE '%" + paciente.nome + "%'";
                        break;
                }

                comand.CommandText = "SELECT p.ID_PACIENTE, p.NOME, p.RG, p.CPF, p.TELEFONE, p.SEXO, p.DATA_NASCIMENTO FROM PACIENTE p WHERE " + condicao;



                reader = comand.ExecuteReader();

                return reader;
            }
            catch (DB2Exception)
            {
                return null;
            }


        }
        //Pacientes que não possuem anamnese
        public DB2DataReader consultar_Paciente_Todos_Anamnese()
        {

            try
            {
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                comand.CommandText = "SELECT p.id_paciente , p.nome, p.rg,p.cpf,p.sexo,p.data_nascimento FROM PACIENTE p WHERE ID_PACIENTE NOT IN (SELECT a.ID_PACIENTE  FROM ANAMNESE a)";



                reader = comand.ExecuteReader();
                return reader;
            }
            catch (DB2Exception)
            {

                return null;
            }


        }
        //Pacientes que possuam ananmese e não possuam acompanhamento
        public DB2DataReader consultar_Paciente_Todos_Anamnese_Sem_Acompanhamento(String filtroDrop, PacienteModel paciente)
        {

            try
            {
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;
                string condicao;
                
                    db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                    db2.Open();

                    comand = new DB2Command();
                    comand.Connection = db2;

                    switch (filtroDrop)
                    {
                        case "Nome":
                            condicao = " p.NOME LIKE '%" + paciente.nome + "%'";
                            break;
                        case "RG":
                            condicao = " p.RG LIKE '%" + paciente.rg + "%'";
                            break;
                        case "CPF":
                            condicao = " p.CPF LIKE '%" + paciente.cpf + "%'";
                            break;
                        default:
                            condicao = " p.NOME LIKE '%" + paciente.nome + "%'";
                            break;
                    }


                    comand.CommandText = "SELECT p.ID_PACIENTE, p.NOME, p.RG, p.CPF, p.TELEFONE, p.SEXO, p.DATA_NASCIMENTO" +
                                         " from PACIENTE p " +
                                         " WHERE " + condicao +
                                         " AND  P.ID_PACIENTE  IN (SELECT a.ID_PACIENTE  FROM ANAMNESE a) " +
                                         " AND  P.ID_PACIENTE  NOT IN (SELECT AC.ID_PACIENTE FROM ACOMPANHAMENTO AC WHERE AC.ID_STATUSACOMPANHAMENTO = 2 AND AC.FLAG_ALTA =1)";



                    reader = comand.ExecuteReader();
                    return reader;
                }
                catch (DB2Exception)
                {

                    return null;
                }


            }

        public DB2DataReader consultar_CPF_Existente(PacienteModel paciente)
        {
            try
            {
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                comand.CommandText = "SELECT p.cpf FROM PACIENTE p WHERE p.cpf='" + paciente.cpf +"'";



                reader = comand.ExecuteReader();
                return reader;
            }
            catch (DB2Exception)
            {

                return null;
            }

        }

        public DB2DataReader consultar_RG_Existente(PacienteModel paciente)
        {
            try
            {
                db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;


                comand.CommandText = "SELECT p.rg FROM PACIENTE p WHERE p.rg='" + paciente.rg+ "'";



                reader = comand.ExecuteReader();
                return reader;
            }
            catch (DB2Exception)
            {
                reader = null;
                return reader;
            }

        }
    }
}