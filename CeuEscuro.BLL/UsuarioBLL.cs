using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CeuEscuro.DAL;
using CeuEscuro.DTO;
using MySql.Data.MySqlClient;

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


        public List<UsuarioDTO> GetUser ()
        {
            return objBLL.GetUsers();

        }

        public void CreateUser(UsuarioDTO usuario)
        {
            objBLL.CreateUser(usuario);
        }

        public void UpdateUser(UsuarioDTO usuario)
        {
            objBLL.UpdateUser(usuario);
        }

        public void DeleteUsers(int UsuarioId)
        {
            objBLL.DeleteUser(UsuarioId);
        }

        public UsuarioDTO SearchUserById(int usuarioId) //Estava usando antes.
        {
            return objBLL.SearchById(usuarioId);
        }

        public UsuarioDTO SearchUserByName(string usuarioName)
        {
            return objBLL.SearchByName(usuarioName);
        }

        public List<TipoUsuarioDTO> LoadDDL_TpUser()
        {
            return objBLL.LoadDDL();
        }

    }

}




