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
    public partial class User : System.Web.UI.Page
    {
        UsuarioBLL objBLL = new UsuarioBLL();
        UsuarioDTO objDTO = new UsuarioDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGV1();
            LoadDDL1();
        }

        public void LoadGV1()
        {
            gv1.DataSource = objBLL.GetUser();
            gv1.DataBind();
        }

        public void LoadDDL1()
        {
            ddl1.DataSource = objBLL.LoadDDL_TpUser();
            ddl1.DataBind();
        }

        public void SearchUser()
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblSearch.Text = "Campo vazio ou ID inexistente.";
                txtSearch.Focus();
            }
            else
            {
                int userId = Convert.ToInt32(txtSearch.Text.Trim());
                objDTO = objBLL.SearchUserById(userId);

                txtId.Text = objDTO.Id.ToString();
                txtNome.Text = objDTO.Nome.ToString();
                txtEmail.Text = objDTO.Email.ToString();
                txtSenha.Text = objDTO.Senha.ToString();
                txtDataNascUsuario.Text = objDTO.DataNascUsuario.ToString("dd/MM/YYYY");
                ddl1.SelectedValue = objDTO.TipoUsuario_Id.ToString();
                txtSearch.Text = string.Empty;
                txtNome.Focus();
                lblSearch.Text = string.Empty;
            }
            
        }

        //Função que está no btnSearch:
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUser();
        }

        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(gv1.SelectedRow.Cells[1].Text);

            objDTO = objBLL.SearchUserById(usuarioId);

            txtId.Text = objDTO.Id.ToString();
            txtNome.Text = objDTO.Nome.ToString();
            txtEmail.Text = objDTO.Email.ToString();
            txtSenha.Text = objDTO.Senha.ToString();
            txtDataNascUsuario.Text = objDTO.DataNascUsuario.ToString("dd/MM/YYYY");
            ddl1.SelectedValue = objDTO.TipoUsuario_Id.ToString();

            LoadGV1();
        }
    }
}