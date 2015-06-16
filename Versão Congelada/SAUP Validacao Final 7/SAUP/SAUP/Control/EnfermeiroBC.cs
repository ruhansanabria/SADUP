using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAUP.Model;
using SAUP.Control;
using SAUP.DAO;
using IBM.Data.DB2;
using System.Data.Common;

namespace SAUP.Control
{
    /*
       Classe de controle para a camada de acesso a Dados, recebe sempre
     *  o objeto.
     */
    public class EnfermeiroBC
    {
        private EnfermeiroModel enfModel;
        private EnfermeiroDAO   enfDAO;
        List<EnfermeiroModel> listaModel = new List<EnfermeiroModel>();
        public EnfermeiroBC()
        {

            enfModel = new EnfermeiroModel();
            enfDAO = new EnfermeiroDAO();
            
        }

        public String inserir_Enfermeiro(EnfermeiroModel enf)
        {
            listaModel.Add(enf);
            return enfDAO.inserir_enfermeiro(enf); 
        
        
        }
        public String atualizar_enfermeiro(EnfermeiroModel enf)
        { 
            
            return enfDAO.atualizar_enfermeiro(enf);
        }

        public DB2DataReader get_enfermeiros(String filtroDrop, EnfermeiroModel enf, PerfilEnfermeiroModel perfilEnfModel)
        {
            EnfermeiroDAO enfDao = new EnfermeiroDAO();

            return enfDao.consultar_enfermeiro(filtroDrop, enf, perfilEnfModel);
        }

        public String excluir_enfermeiro(EnfermeiroModel enf)
        { 
            return enfDAO.excluir_enfermeiro(enf);
        
        
        }

        public DB2DataReader retorna_Enfermeiro(String user_name,String password,EnfermeiroModel enf)
        {
            EnfermeiroDAO enfDao = new EnfermeiroDAO();
            return enfDao.consultar_user(user_name,password, enf);
        }

        public int retorna_EnfPerfById(AnamneseModel anamnese)
        {

            EnfermeiroDAO enfDAO = new EnfermeiroDAO();
            int value = 0;
            DB2DataReader reader = enfDAO.retorn_EnfPerfById(anamnese);
            
                while (reader.Read())
                {
                    value = reader.GetInt32(0);
                }


                return value;

            }
        

        public int retorna_EnfIDByUsername(EnfermeiroModel enf)
        {

            EnfermeiroDAO enfDAO = new EnfermeiroDAO();
            int value=0;
            DB2DataReader reader = enfDAO.retorn_EnfIDByuser_name(enf);
            while (reader.Read())
            {
                value= reader.GetInt32(0);
            }

            return value;      
                   
        }
        public String retorna_Perfil_Menu(EnfermeiroModel enf)
        {

            EnfermeiroDAO enfDAO = new EnfermeiroDAO();
            string value = "";
            DB2DataReader reader = enfDAO.SelectedMenu(enf);
            while (reader.Read())
            {
                value = reader.GetString(0);
            }

            return value;

        }

        public DB2DataReader retorn_EnfUserNameUniqueByuser_name(EnfermeiroModel enf)
        {
            EnfermeiroDAO enfDAO = new EnfermeiroDAO();
             return enfDAO.retorn_EnfUserNameUniqueByuser_name(enf);

               
        
        }
       
    }
}