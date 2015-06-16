using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAUP.Model
{
    public class EnfermeiroModel
    {

        private int id_enfermeiro;
        private String nome;
        private String status_enfermeiro;
        private int id_perfil_enfermeiro;
        private String user_name;
        private String password;

        public EnfermeiroModel()
	{
		
	}

    public int Id_enfermeiro
    {
        get { return id_enfermeiro; }
        set { id_enfermeiro = value; }
       
    }

    public String Nome
    {
        get { return nome; }
        set { nome = value; }
    }
    public String Status
    {
        get { return status_enfermeiro; }
        set { status_enfermeiro = value; }
    }

    public int Id_Perfil_Enf
    {
        get { return id_perfil_enfermeiro; }
        set { id_perfil_enfermeiro = value; }        
    }
    public String User_Name
    {
        get { return user_name; }
        set { user_name = value; }
    }

    public String Password
    {
        get { return password; }
        set { password = value; }
    
    }

    }
}