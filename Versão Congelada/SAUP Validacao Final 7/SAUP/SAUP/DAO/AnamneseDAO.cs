using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBM.Data.DB2;
using SAUP.Model;

namespace SAUP.DAO
{
    public class AnamneseDAO
    {
        DB2Connection db2;
        DB2DataReader reader;
        DB2Command comand;

        public DB2DataReader consultar_AnamnesePaci(string filtroDrop, PacienteModel paciente)
        {
            string condicao;

            db2 = new DB2Connection("Database=SAMPLE;UID=db2admin;PWD=Bigboa!053;");

            try
            {
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
                        condicao = " p.RG LIKE '%" + paciente.rg + "%'";
                        break;
                }
                try
                {

                    comand.CommandText = "SELECT P.ID_PACIENTE , P.NOME,A.DATA_REALIZACAO, A.HISTORICO_DOENCAS, A.HISTORICO_FAMILIAR, A.INFORMACOES_ADICIONAIS "
                                        + "FROM DB2ADMIN.PACIENTE p,DB2ADMIN.ANAMNESE A WHERE " + condicao + " AND P.ID_PACIENTE =A.ID_PACIENTE";



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
    

        public String inserir_anamnese(AnamneseModel anamnese)
        {
            db2 = new DB2Connection("Database=SAMPLE");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {
                    comand.CommandText = "INSERT INTO DB2ADMIN.ANAMNESE (DATA_REALIZACAO, HISTORICO_DOENCAS, HISTORICO_FAMILIAR, INFORMACOES_ADICIONAIS, ID_ENFERMEIRO, ID_PERFIL_ENFERMEIRO, ID_PACIENTE) VALUES (" +
                       "CURRENT TIMESTAMP" + ",'" + anamnese.Historico_Doenca + "','" + anamnese.Historico_Familiar + "','" + anamnese.informacoes_Adicionais + "'," + anamnese.id_Enfermeiro + "," +
                        anamnese.id_perfil_Enfermeiro + "," + anamnese.id_Paciente + ")";


                    reader = comand.ExecuteReader();

                    return "Inserido com Sucesso!";
                }
                catch (DB2Exception)
                {
                    return "Ocorreram  falhas na inserção,verifique os dados novamente que foram inseridos";
                }

            }
            catch (DB2Exception)
            {
                return "Ocorreram falhas na inserção, verifique a conexão com o banco de dados";
            
            }

        }
        //VERIFICAR O MÉTODO ATUALIZAR POIS COMO A GRID DE NOMES PRECISA
        //FICAR INVISIBLE NAO TENHO COMO PASSAR O ID, UMA OPCAO EH USAR SUBSELECT PELO
        //RG OU CPF, ESTE METODO DEVERÁ RECEBER UMA MODEL DE PACIENTE 
        // PARA SETAR O ID E O RG OU CPF PARA ATUALIZAR O REGISTRO CORRETO
        public String atualizar_anamnese(AnamneseModel anamnese)
        {
            db2 = new DB2Connection("Database=SAMPLE");
            try
            {
                db2.Open();

                comand = new DB2Command();
                comand.Connection = db2;

                try
                {
                    comand.CommandText = "UPDATE DB2ADMIN.ANAMNESE SET " +
                                        "HISTORICO_DOENCAS = '" + anamnese.Historico_Doenca + "'," +
                                        "HISTORICO_FAMILIAR = '" + anamnese.Historico_Familiar + "'," +
                                        "INFORMACOES_ADICIONAIS ='" + anamnese.informacoes_Adicionais + "'" +
                                        " WHERE ID_PACIENTE =" + anamnese.id_Paciente;



                    reader = comand.ExecuteReader();

                    return "Atualizado paciente de código " + "(" + anamnese.id_Paciente + ")" + "com sucesso!";
                }
                catch (DB2Exception)
                {
                    return "Erro ao Atualizar,verique se os dados inseridos e selecionados estõ corretos";
                }
            }
            catch (DB2Exception)
            {

                return "Erro ao atualizar, verifique sua conexão com o banco de dados";
            }
        }
    }
}