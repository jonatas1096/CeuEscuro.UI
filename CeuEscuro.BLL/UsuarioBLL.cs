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
        UsuarioDAL objBLL = new UsuarioDAL();

        public UsuarioDTO UserAutentication(string objEmail, string objSenha)
        {
            UsuarioDTO user = objBLL.Autenticar(objEmail, objSenha);

            return user;
        }


        public List<UsuarioDTO> GetUser (UsuarioDTO usuario)
        {
            return objBLL.GetUsers();

        }

        public void UpdateUser(UsuarioDTO usuario)
        {
            objBLL.UpdateUser(usuario);
        }

        public void DeleteUsers(int UsuarioId)
        {
            objBLL.DeleteUser(UsuarioId);
        }

        public UsuarioDTO SearchUserById(int usuarioId)
        {
            return objBLL.SearchById(usuarioId);
        }


    }

}




