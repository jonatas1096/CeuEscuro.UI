using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CeuEscuro.DAL
{
    public class Conexao
    {
        protected MySqlConnection conn;
        protected MySqlCommand cmd;
        protected MySqlDataReader dr;

        //Conexão com o banco de dados
        protected void Conectar()
        {
            try
            {
                conn = new MySqlConnection("Data Source = localhost; initial Catalog = ceuescurodb;  Uid = root; Pwd= ;");
                conn.Open();
            }

            catch (Exception ex)
            {
                throw new Exception($"Problema na conexão: {ex.Message}");

            }
        }


        //Desconectar
        protected void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
