using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CeuEscuro.DAL;
using CeuEscuro.DTO;

namespace CeuEscuro.BLL
{
    public class FilmeBLL
    {
        FilmeDAL objBLL = new FilmeDAL();

        public void CreateMovies(FilmeDTO movie)
        {
            objBLL.CreateMovie(movie);
        }

        public List<FilmeDTO> GetMovies()
        {
            return objBLL.GetMovie();
        }

        public void UpdateMovies(FilmeDTO movie)
        {
            objBLL.UpdateMovie(movie);
        }

        public void DeleteMovies(int movieid)
        {
            objBLL.DeleteMovie(movieid);
        }

        public FilmeDTO GetMovies(int movieid) 
        { 
          return objBLL.SearchMovieById(movieid);
        }


    }
}
