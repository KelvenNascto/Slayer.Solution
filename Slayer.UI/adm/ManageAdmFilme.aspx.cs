using Slayer.BLL;
using Slayer.DTO;
using Slayer.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slayer.UI.adm
{
    public partial class ManageAdmFilme : System.Web.UI.Page
    {
        FilmeDTO filmDTO = new FilmeDTO();
        FilmeBLL filmBLL = new FilmeBLL();
        string msg = "O campo precisa ser preenchido corretamente !!";
        string msg2 = "Filme não cadastrado na base de dados !!";
        string msg3 = "Selecione um arquivo de imagem valido !!";

        //loadPage
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGv2();
                LoadDDLClassif();
                LoadDDLGenre();
                txtId.Enabled = false;
            }
        }

        //LoadGv2
        public void LoadGv2()
        {
            gv2.DataSource = filmBLL.GetFilmBLL();
            gv2.DataBind();
        }

        //LoadDDLClassif
        public void LoadDDLClassif()
        {
            ddlClassif.DataSource = filmBLL.LoadDDLClassificationBLL();
            ddlClassif.DataBind();
        }

        //LoadDDLGenre
        public void LoadDDLGenre()
        {
            ddlGenero.DataSource = filmBLL.LoadDDLGenreBLL();
            ddlGenero.DataBind();
        }

        //FilterByGenero
        public void FilterByGenre(string genero)
        {
            string filter = txtFiltro.Text.Trim();
            gv2.DataSource = filmBLL.FilterByGenreBLL(filter);
            gv2.DataBind();
            gv2.SelectedRowStyle.Reset();
        }


        //ValidaPage
        public bool ValidaPage()
        {
            bool valid;


            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                lblTitulo.Text = msg;

                lblProdutora.Text = lblFup.Text = string.Empty;

                txtTitulo.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtProdutora.Text))
            {
                lblProdutora.Text = msg;
                txtProdutora.Focus();
                lblTitulo.Text = lblFup.Text = string.Empty;

                valid = false;

            }

            else if (!Fup.HasFile && img1.ImageUrl == string.Empty)
            {
                lblFup.Text = msg3;
                Fup.Focus();
                lblTitulo.Text = lblProdutora.Text = string.Empty;
                valid = false;

            }
            else
            {
                valid = true;
            }

            return valid;
        }

        //PreencheCampos
        public void PreencheCampos()
        {
            txtId.Text = filmDTO.IdFilme.ToString();
            txtTitulo.Text = filmDTO.TituloFilme;
            txtProdutora.Text = filmDTO.ProdutoraFilme;
            ddlClassif.SelectedValue = filmDTO.ClassificacaoId;
            ddlGenero.SelectedValue = filmDTO.GeneroId;
            img1.ImageUrl = filmDTO.UrlFilme;
        }

        //Record
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {
                //preenchendo as propriedades do objeto
                filmDTO.TituloFilme = txtTitulo.Text.Trim();
                filmDTO.ProdutoraFilme = txtProdutora.Text.Trim();

                filmDTO.ClassificacaoId = ddlClassif.SelectedValue;
                filmDTO.GeneroId = ddlGenero.SelectedValue;
                //imagem

                if (Fup.HasFile)
                {
                    string str = Fup.FileName;
                    Fup.PostedFile.SaveAs(Server.MapPath($"~/img/{str}"));
                    string pathImg = $"~/img/{str}";
                    filmDTO.UrlFilme = pathImg;

                }
                else
                {
                    filmDTO.UrlFilme = img1.ImageUrl;
                }

                //checando qual procedimento invocar
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    //cadastando registro na base
                    filmBLL.CreateFilmBLL(filmDTO);
                    Clear.ClearControl(this);
                    txtTitulo.Focus();
                    LoadGv2();
                    lblMessage.Text = $"Usuário {filmDTO.TituloFilme.ToUpper()} cadastrado com sucesso !!";
                }
                else
                {
                    //editando registro na base
                    filmDTO.IdFilme = int.Parse(txtId.Text);
                    filmBLL.UpdateFilmBLL(filmDTO);
                    Clear.ClearControl(this);
                    txtTitulo.Focus();
                    LoadGv2();
                    lblMessage.Text = $"Usuário {filmDTO.TituloFilme.ToUpper()} editado com sucesso !!";
                }
            }
            
        }


        //Clear
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtTitulo.Focus();
            //resetar a cor do gv1
            gv2.SelectedRowStyle.Reset();
            LoadGv2();
        }

        //Delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            filmDTO.TituloFilme = txtTitulo.Text.Trim();
            filmDTO.IdFilme = int.Parse(txtId.Text.Trim());
            filmBLL.DeleteFilmBLL(filmDTO.IdFilme);
            Clear.ClearControl(this);
            LoadGv2();
            txtSearch.Focus();
            lblMessage.Text = $"Filme {filmDTO.TituloFilme.ToUpper()} eliminado com sucesso !!";
        }

        //Search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string nomeFilme = txtSearch.Text.Trim();
            filmDTO = filmBLL.SearchFilmTitleBLL(nomeFilme);

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblMessage.Text = msg;
                txtSearch.Focus();
                return;
            }
            else if (filmDTO == null)
            {
                lblMessage.Text = msg2;
                txtSearch.Focus();
                txtSearch.Text = string.Empty;
                return;
            }
            else
            {
                PreencheCampos();
                lblMessage.Text = txtSearch.Text = string.Empty;

            }
        }

        //Filter
        protected void btnFilter_Click(object sender, EventArgs e)
        {
           string filter = txtFiltro.Text.Trim();
           var result = filmBLL.FilterByGenreBLL(filter);

            if (string.IsNullOrEmpty(txtFiltro.Text) || result.Count == 0)
            {
                Clear.ClearControl(this);
                lblFilter.Text = "Digite um gênero existente!";
                lblFilter.Text = string.Empty;
                txtFiltro.Focus();
                LoadGv2();
            }
            else
            {
                FilterByGenre(filter);
                ClearLabel.ClearLabelValid(this);
                txtFiltro.Focus();
            }
        }

        //ClearFilter
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            LoadGv2();
            txtFiltro.Text = string.Empty;
            txtFiltro.Focus();
        }

        //gv2Selected
        protected void gv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearLabel.ClearLabelValid(this);
            int idFilme = int.Parse(gv2.SelectedRow.Cells[1].Text);
            filmDTO = filmBLL.SearchFilmIdBLL(idFilme);
            PreencheCampos();
        }

    }
}