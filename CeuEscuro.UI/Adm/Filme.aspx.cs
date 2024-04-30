using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.UI.Adm
{
    public partial class Filme : System.Web.UI.Page
    {
        FilmeDTO objDTO = new FilmeDTO();
        FilmeBLL objBLL = new FilmeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGV2();
            }

        }

        public void LoadGV2()
        {
            gv2.DataSource = objBLL.GetMovies();
            gv2.DataBind();
        }
    }



}