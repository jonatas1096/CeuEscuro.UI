using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CeuEscuro.DAL;
using CeuEscuro.DTO;

namespace CeuEscuro.BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL objDLL = new UsuarioDAL();

        public UsuarioDTO UserAutentication(string objEmail, string objSenha)
        {
            UsuarioDTO user = objDLL.Autenticar(objEmail, objSenha);

            return user;
        }

    }

}

