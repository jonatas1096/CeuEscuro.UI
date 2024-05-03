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
    public partial class Filme : System.Web.UI.Page
    {
        FilmeDTO objDTO = new FilmeDTO();
        FilmeBLL objBLL = new FilmeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            if (!IsPostBack)
            {
                LoadGV2();
                LoadDDL1Classifi();
                LoadDDL1Genero();
            }

        }

        public void LoadGV2()
        {
            gv2.DataSource = objBLL.GetMovies();
            gv2.DataBind();
        }

        public void LoadDDL1Classifi()
        {
            ddlClassif.DataSource = objBLL.LoadDDLClassif_Classif();
            ddlClassif.DataBind();
        }

        public void LoadDDL1Genero()
        {
            ddlGenero.DataSource = objBLL.LoadDDLGenero_Genero();
            ddlGenero.DataBind();
        }


        public void SearchMovie()
        {
            string title = txtSearch.Text.Trim();

            objDTO = objBLL.SearchByNameFilm(title);

            txtId.Text = objDTO.Id.ToString();
            txtTitulo.Text = objDTO.Titulo.ToString();
            txtProdutora.Text = objDTO.Produtora.ToString();
            ddlClassif.SelectedValue = objDTO.Classificacao_Id.ToString();
            ddlGenero.SelectedValue = objDTO.Genero_Id.ToString();

            txtSearch.Text = string.Empty;
            txtTitulo.Focus();
            lblSearch.Text = string.Empty;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblSearch.Text = "Campo vazio ou Título inexistente.";
                txtSearch.Focus();
                return;
            }
            else
            {
                SearchMovie();
            }

        }



        protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int filmeId = int.Parse(gv2.SelectedRow.Cells[1].Text);
            objDTO = objBLL.GetMovies(filmeId);

            txtId.Text = objDTO.Id.ToString();
            txtTitulo.Text = objDTO.Titulo.ToString();
            txtProdutora.Text = objDTO.Produtora.ToString();
            ddlClassif.SelectedValue = objDTO.Classificacao_Id.ToString();
            ddlGenero.SelectedValue = objDTO.Genero_Id.ToString();

            
            txtTitulo.Focus();
        }

        public bool ValidaPage()
        {
            bool valid;

            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                lblTitulo.Text = "Digite um título válido.";
                txtTitulo.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = "Informe a produtora.";
                txtProdutora.Focus();
                valid = false;
            }
            else if (!FileUpload.HasFile)
            {
                lblFile.Text = "Carregue uma imagem.";
                FileUpload.Focus();
                valid = false;
            }
            else
            {
                valid = true;
            }

            return valid;
        }

        protected void btnRecord_Click(object sender, EventArgs e)
        {

            if (ValidaPage())
            {
                objDTO.Titulo = txtTitulo.Text.Trim();
                objDTO.Produtora = txtProdutora.Text.Trim();
                objDTO.Classificacao_Id = ddlClassif.SelectedValue;
                objDTO.Genero_Id = ddlGenero.SelectedValue;

                //A parte abaixo serve para pegar a imagem
                string imageName = FileUpload.FileName; //Pegando o nome da imagem que o usuário colocou
                FileUpload.PostedFile.SaveAs(Server.MapPath($"~/img/{imageName}")); //"Concatenando" com o que o servidor pede
                string imagePath = $"~/img/{imageName}";
                objDTO.UrlImg = imagePath;


                if (string.IsNullOrEmpty(txtId.Text))
                {
                    objBLL.CreateMovies(objDTO);
                    LoadGV2();
                    Clear.ClearFields(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O filme {objDTO.Titulo} foi inserido no banco de dados.";
                }
                else
                {
                    objDTO.Id = int.Parse(txtId.Text);
                    objBLL.UpdateMovies(objDTO);
                    LoadGV2();
                    Clear.ClearFields(this);
                    txtSearch.Focus();
                    lblMessage.Text = $"O filme {objDTO.Titulo} sofreu atualizações.";
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearFields(this);
            txtSearch.Focus();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objDTO.Id = int.Parse(txtId.Text);

            objBLL.DeleteMovies(objDTO.Id);
            LoadGV2();
            Clear.ClearFields(this);
            lblMessage.Text = "Filme excluido com sucesso.";
        }



        protected void btnFilter_Click(object sender, EventArgs e)
        {
            objDTO.Genero_Id = txtGenero.Text.ToString().Trim(); //Tentando pegar as informações do filme
            
            
            //Utilizando e carregando as informações no gridView
            gv2.DataSource = objBLL.SearchByFilterFilm(objDTO.Genero_Id);
            gv2.DataBind();

        }

        protected void btnClearGenero_Click(object sender, EventArgs e)
        {

        }
    }
}