using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CeuEscuro.DTO;

namespace CeuEscuro.DAL
{
    public class FilmeDAL : Conexao //Essa classe tem que herdar de conexao pra usar os bang de lá
    {
        public void CreateMovie(FilmeDTO filme) //Funcao com o objeto do FilmeDTO
        {
			try
			{
				Conectar(); //Tentando conectar ao banco

				cmd = new MySqlCommand("INSERT INTO filme (Titulo, Produtora, UrlImg, Classificacao_Id, Genero_Id) values (@Titulo, @Produtora, @UrlImg, @Classificacao_Id, @Genero_Id);", conn); //A query em si
				cmd.Parameters.AddWithValue("Titulo", filme.Titulo); //Adicionando os parâmetros (os que tem @ no nome)
                cmd.Parameters.AddWithValue("Produtora", filme.Produtora);
                cmd.Parameters.AddWithValue("UrlImg", filme.UrlImg);
                cmd.Parameters.AddWithValue("Classificacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("Genero_Id", filme.Genero_Id);

                cmd.ExecuteNonQuery(); //Executando ela.
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

		public List<FilmeDTO> GetMovie() 
		{
            try
            {
                Conectar(); //Tentando conectar ao banco

                cmd = new MySqlCommand("SELECT Filme.Id, Titulo, Produtora, UrlImg, classificacao.DescricaoClassificacao, genero.descricao FROM filme INNER JOIN classificacao ON filme.id LIKE classificacao.id INNER JOIN genero ON filme.Genero_Id LIKE genero.Id;", conn); //A query em si         
                dr = cmd.ExecuteReader(); //Dr é da classe conexão, utilizamos apenas para ler, diferente da ExecuteNonQuery.

                List<FilmeDTO> list = new List<FilmeDTO>(); //Nova lista do tipo filme

                while (dr.Read())
                {
                    FilmeDTO movie = new FilmeDTO();
                    movie.Id = Convert.ToInt32(dr["Id"]);
                    movie.Titulo = dr["Titulo"].ToString();
                    movie.Produtora = dr["Produtora"].ToString();
                    movie.UrlImg = dr["UrlImg"].ToString();
                    movie.Classificacao_Id = dr["DescricaoClassificacao"].ToString();
                    movie.Genero_Id = dr["Descricao"].ToString();

                    list.Add(movie); //Depois de popular o objeto, adicionamos ele na lista. Então, vira uma lista de varios objetos. Isso vai acontecendo enquanto houver filmes para ler.
                }

                return list;
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

        public void UpdateMovie(FilmeDTO filme)
        {
            try
            {
                Conectar(); //Tentando conectar ao banco

                cmd = new MySqlCommand("UPDATE filme SET Id=@Id, Titulo=@Titulo, Produtora=@Produtora, UrlImg=@UrlImg, Classificacao_Id=@Classificacao_Id, Genero_Id=@Genero_Id;", conn); //A query em si         
                cmd.Parameters.AddWithValue("Id", filme.Id);
                cmd.Parameters.AddWithValue("Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("Produtora", filme.Produtora);
                cmd.Parameters.AddWithValue("UrlImg", filme.UrlImg);
                cmd.Parameters.AddWithValue("Classificacao_Id", filme.Classificacao_Id);
                cmd.Parameters.AddWithValue("Genero_Id", filme.Genero_Id);
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

        public void DeleteMovie(int movieid)
        {
            try
            {
                Conectar(); //Tentando conectar ao banco

                cmd = new MySqlCommand("DELETE FROM filme WHERE filme.Id like @movieid", conn); //A query em si         
                cmd.Parameters.AddWithValue("movieid", movieid);
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

        public FilmeDTO SearchMovieById(int movieid)
        {
            try
            {
                Conectar(); //Tentando conectar ao banco

                cmd = new MySqlCommand("SELECT * FROM filme INNER JOIN classificacao ON filme.id LIKE classificacao.id INNER JOIN genero ON filme.Genero_Id LIKE genero.Id WHERE filme.Id like @movie", conn); //A query em si         
                cmd.Parameters.AddWithValue("movieid", movieid);
                dr = cmd.ExecuteReader();

                FilmeDTO movie = new FilmeDTO();

                if (dr.Read())
                {
                    movie.Id = Convert.ToInt32(dr["Id"]);
                    movie.Titulo = dr["Titulo"].ToString();
                    movie.Produtora = dr["Produtora"].ToString();
                    movie.UrlImg = dr["UrlImg"].ToString();
                    movie.Classificacao_Id = dr["DescricaoClassificacao"].ToString();
                    movie.Genero_Id = dr["Descricao"].ToString();
                }
               
                return movie;

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
    }
}
