using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.User
{
    public partial class ConsultaFilme : System.Web.UI.Page
    {
        FilmeBLL objBLL = new FilmeBLL();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGV2();
        }

        public void LoadGV2()
        {
            gv1.DataSource = objBLL.GetMovies();
            gv1.DataBind();
        }
    }
}