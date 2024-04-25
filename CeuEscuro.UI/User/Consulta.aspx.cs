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
    public partial class Consulta : System.Web.UI.Page
    {
        UsuarioBLL objBLL = new UsuarioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGV2();
            }
        }


        //Carregar as informações do banco
        public void LoadGV2()
        {
            gv2.DataSource = objBLL.GetUser();
            gv2.DataBind();
        }

    }
}