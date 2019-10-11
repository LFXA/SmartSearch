using SmartSearch.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSearch.Business
{
    public class BusinessUsuario
    {
        public Usuario Login(string email, string senha)
        {

            // Efetuar o login
            var _usuario = new Usuario(email.ToLower(), senha.ToLower());
            
            if (_usuario == null)
            {
                throw new Exception("Não foi possível efetuar o logon");
            }


            return _usuario;


        }
    }
}
