using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CeuEscuro.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEmail.Text = txtSenha.Text = string.Empty;

            /* Também funciona assim:
            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;*/

            txtEmail.Focus();
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuario = new UsuarioDTO();
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            string Email = txtEmail.Text;
            string Senha = txtSenha.Text;

            usuario = usuarioBLL.UserAutentication(Email, Senha);

            if (usuario != null)
            {
                lblMensagem.Text = $"Bem vindo, {usuario.Nome.ToUpper()}!";
            }
            else
            {
                lblMensagem.Text = $"O usuário preenchido não foi encontrado na base de dados.";
            }


        }
    }
}