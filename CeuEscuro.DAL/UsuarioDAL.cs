using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CeuEscuro.DTO;
using MySql.Data.MySqlClient;

namespace CeuEscuro.DAL
{
    public class UsuarioDAL : Conexao
    {
        //Tentativa de autenticar o usuario validando no banco de dados
        public UsuarioDTO Autenticar(string Email, string Senha)
        {
            try
            {                
                Conectar();
                cmd = new MySqlCommand("SELECT Id, Nome, Email, Senha, TipoUsuario_Id FROM usuario WHERE Email like @Email AND Senha like @Senha",conn);

                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Senha", Senha);

                dr = cmd.ExecuteReader();

                UsuarioDTO obj = null;

                if (dr.Read()) 
                {
                    obj = new UsuarioDTO();

                    obj.Email = dr["Email"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.Nome = dr["Nome"].ToString();
                    obj.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();             
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"Usuário não cadastrado na base. Erro: {ex.Message}");
            }
            finally
            {
                Desconectar();
            }


        }


        //Criar um novo usuário
        public void CreateUser(UsuarioDTO usuario)
        {
            try
            {
                Conectar();

                cmd = new MySqlCommand("INSERTO INTO Usuario (Nome, Email, Senha, DataNascUsuario, TipoUsuario_Id) VALUES (@Nome, @Email, @Senha, @DataNascUsuario, @TipoUsuario_Id)", conn);

                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@DataNascUsuario", usuario.DataNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id); 

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }



        //Read
        public List<UsuarioDTO> GetUsers() {

            try
            {
                Conectar();

                cmd = new MySqlCommand("SELECT usuario.Id, Nome, Email, Senha, DataNascUsuario, Descricao FROM Usuario INNER JOIN tipousuario ON Usuario.Id like tipousuario.Id ORDER BY Usuario.Nome ASC;", conn);
                dr = cmd.ExecuteReader();

               

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Desconectar();
            }

            return null;
        }

    }
}
