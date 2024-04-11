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
                    Console.WriteLine("leu");
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


        //



    }
}
