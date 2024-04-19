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
            if (!IsPostBack)
            {
                txtId.Enabled = false;
                LoadGV1();
                LoadDDL1();
            }
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
                string userName = txtSearch.Text.Trim();

                objDTO = objBLL.SearchUserByName(userName);

                txtId.Text = objDTO.Id.ToString();
                txtNome.Text = objDTO.Nome.ToString();
                txtEmail.Text = objDTO.Email.ToString();
                txtSenha.Text = objDTO.Senha.ToString();
                txtDataNascUsuario.Text = objDTO.DataNascUsuario.ToString("dd/MM/yyyy");
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
            txtDataNascUsuario.Text = objDTO.DataNascUsuario.ToString("dd/MM/yyyy");
            ddl1.SelectedValue = objDTO.TipoUsuario_Id.ToString();

            LoadGV1();
        }

        //Função para criar um usuário no banco
        protected void btnRecord_Click(object sender, EventArgs e)
        {

            objDTO.Nome = txtNome.Text.Trim();
            objDTO.Email = txtEmail.Text.Trim();
            objDTO.Senha = txtSenha.Text.Trim();

            //objDTO.DataNascUsuario = Convert.ToDateTime(txtDataNascUsuario.Text.Trim()); Acho que dessa forma padrão também leva ao mesmo resultado
            DateTime dt = DateTime.Parse(txtDataNascUsuario.Text.Trim());
            objDTO.DataNascUsuario = dt;
            objDTO.TipoUsuario_Id = ddl1.SelectedValue;

            if (string.IsNullOrEmpty(txtId.Text))
            {
                objBLL.CreateUser(objDTO);
                lblSearch.Text = "Usuário criado com sucesso.";
            }
            else
            {
                objDTO.Id = int.Parse(txtId.Text);
                objBLL.UpdateUser(objDTO);
                lblSearch.Text = "Usuário atualizado com sucesso.";
            }

            LoadGV1();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //objDTO.Id = Convert.ToInt32(txtId.Text);

            objDTO.Id = int.Parse(txtId.Text);

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                objBLL.DeleteUsers(objDTO.Id);
            }
            else {
                lblSearch.Text = "Selecione um usuário para deletar.";
            }

            LoadGV1();
            
        }
    }
}