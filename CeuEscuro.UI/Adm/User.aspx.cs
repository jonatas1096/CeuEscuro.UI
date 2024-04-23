using CeuEscuro.BLL;
using CeuEscuro.DTO;
using CeuEscuro.UI.utilities;
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

            if (Validation())
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
                    Clear.ClearFields(this);
                    lblMessage.Text = $"Usuário {objDTO.Nome} criado com sucesso.";
                    txtSearch.Focus();   
                }
                else
                {
                    objDTO.Id = int.Parse(txtId.Text);
                    objBLL.UpdateUser(objDTO);
                    Clear.ClearFields(this);
                    lblMessage.Text = $"Usuário {objDTO.Nome} atualizado com sucesso.";
                    txtSearch.Focus();
                }
                LoadGV1();
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //objDTO.Id = Convert.ToInt32(txtId.Text);

            objDTO.Id = int.Parse(txtId.Text);

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                objBLL.DeleteUsers(objDTO.Id);
                Clear.ClearFields(this);
                lblMessage.Text = $"Usuário {objDTO.Nome} deletado com sucesso.";
                txtSearch.Focus();
            }
            else {
                lblSearch.Text = "Selecione um usuário para deletar.";
            }

            LoadGV1();
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearFields(this);
            txtSearch.Focus();
        }


        public bool Validation()
        {
            bool valid;
            DateTime dt;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                lblNome.Text = "Digite o nome do usuário.";
                txtNome.Focus();
                valid = false;
            }
            else if(string.IsNullOrEmpty(txtEmail.Text)) {
                lblEmail.Text = "Digite o Email do usuário.";
                txtEmail.Focus();
                valid = false;
            }
            else if(string.IsNullOrEmpty(txtSenha.Text)) 
            {
                lblSenha.Text = "Digite a Senha do usuário.";
                txtSenha.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtDataNascUsuario.Text) || (!DateTime.TryParse(txtDataNascUsuario.Text, out dt)))
            {
                lblDataNascUsuario.Text = "Informe a Data de Nascimento.";
                txtDataNascUsuario.Text = string.Empty;
                txtDataNascUsuario.Focus();
                valid = false;
            }
            else
            {
                valid = true;
            }

            return valid;
            
        }
    }

}