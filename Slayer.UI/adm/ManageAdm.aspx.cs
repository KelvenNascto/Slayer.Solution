using Slayer.BLL;
using Slayer.DTO;
using Slayer.UI.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slayer.UI.adm
{
    public partial class ManageAdm : System.Web.UI.Page
    {
        //Recursos Globais
        UsuarioBLL userBLL = new UsuarioBLL();
        UsuarioDTO userDTO = new UsuarioDTO();
        string msg = "O campo precisa ser preenchido corretamente !!";
        string msg2 = "Usuário não cadastrado na base !!";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGv1();
                LoadDdl1();
                txtIdUsuario.Enabled = false;

            }
        }

        //popular gv1
        public void LoadGv1()
        {
            gv1.DataSource = userBLL.GetUserBLL();
            gv1.DataBind();
        }

        //popular ddl1
        public void LoadDdl1()
        {
            ddl1.DataSource = userBLL.GetTypeUserBLL();
            ddl1.DataBind();
        }

        //validaPage

        public bool ValidaPage()
        {
            bool valid;
            DateTime dt;

            if (string.IsNullOrEmpty(txtNomeUsuario.Text))
            {
                lblNomeUsuario.Text = msg;

                lblEmailUsuario.Text = lblSenhaUsuario.Text = lblDtNascUsuario.Text = string.Empty;

                txtNomeUsuario.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtEmailUsuario.Text))
            {
                lblEmailUsuario.Text = msg;
                txtEmailUsuario.Focus();
                lblNomeUsuario.Text = lblSenhaUsuario.Text = lblDtNascUsuario.Text = string.Empty;

                valid = false;

            }
            else if (string.IsNullOrEmpty(txtSenhaUsuario.Text))
            {
                lblSenhaUsuario.Text = msg;
                txtSenhaUsuario.Focus();
                lblNomeUsuario.Text = lblEmailUsuario.Text = lblDtNascUsuario.Text = string.Empty;
                valid = false;

            }
            else if (string.IsNullOrEmpty(txtDtNascUsuario.Text) || !DateTime.TryParse(txtDtNascUsuario.Text, out dt))
            {
                lblDtNascUsuario.Text = msg;
                txtDtNascUsuario.Focus();
                lblNomeUsuario.Text = lblEmailUsuario.Text = txtSenhaUsuario.Text = string.Empty;
                valid = false;

            }
            else
            {
                valid = true;
            }

            return valid;
        }

        //record
        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {


                //preenchendo as propriedades do objeto
                userDTO.NomeUsuario = txtNomeUsuario.Text;
                userDTO.EmailUsuario = txtEmailUsuario.Text;
                userDTO.SenhaUsuario = txtSenhaUsuario.Text;

                //ajustando a data
                DateTime dt = DateTime.Parse(txtDtNascUsuario.Text);
                userDTO.DtNascUsuario = dt;
                userDTO.UsuarioTp = ddl1.SelectedValue;

                //checando qual procedimento invocar
                if (string.IsNullOrEmpty(txtIdUsuario.Text))
                {
                    //cadastando registro na base
                    userBLL.CreateUserBLL(userDTO);
                    Clear.ClearControl(this);
                    txtNomeUsuario.Focus();
                    LoadGv1();
                    lblMessage.Text = $"Usuário {userDTO.NomeUsuario.ToUpper()} cadastrado com sucesso !!";
                }
                else
                {
                    //editando registro na base
                    userDTO.IdUsuario = int.Parse(txtIdUsuario.Text);
                    userBLL.UpdateUserBLL(userDTO);
                    Clear.ClearControl(this);
                    txtNomeUsuario.Focus();
                    LoadGv1();
                    lblMessage.Text = $"Usuário {userDTO.NomeUsuario.ToUpper()} editado com sucesso !!";
                }
            }
        }

        //clear
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtNomeUsuario.Focus();
            //resetar a cor do gv1
            gv1.SelectedRowStyle.Reset();
        }

        //search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string nomeUser = txtSearch.Text.Trim();
            userDTO = userBLL.SearchBLL(nomeUser);

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                lblMessage.Text = msg;
                txtSearch.Focus();
                return;
            }
            else if (userDTO == null)
            {
                lblMessage.Text = msg2;
                txtSearch.Focus();
                txtSearch.Text = string.Empty;
                return;
            }
            else
            {
                ClearLabel.ClearLabelValid(this);
                PreencheCampos();
                lblMessage.Text = txtSearch.Text = string.Empty;

            }

        }
        //prenche dados
        private void PreencheCampos()
        {
            txtIdUsuario.Text = userDTO.IdUsuario.ToString();
            txtNomeUsuario.Text = userDTO.NomeUsuario;
            txtEmailUsuario.Text = userDTO.EmailUsuario;
            txtSenhaUsuario.Text = userDTO.SenhaUsuario;
            txtDtNascUsuario.Text = userDTO.DtNascUsuario.ToString("dd/MM/yyyy");

            ddl1.SelectedValue = userDTO.UsuarioTp;
        }

        //delete
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            userDTO.IdUsuario = int.Parse(txtIdUsuario.Text.Trim());
            userBLL.DeleteUserBLL(userDTO.IdUsuario);
            Clear.ClearControl(this);
            LoadGv1();
            txtSearch.Focus();
        }
        //private void ClearLabel(Control ctrl)
        //{
        //    foreach (Control control in ctrl.Controls)
        //    {
        //        if (control is Label label)
        //        {
        //            label.Text = string.Empty;
        //        }
        //        else if (control.HasControls())
        //        {
        //            ClearLabel(control);
        //        }
        //    }



        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearLabel.ClearLabelValid(this);
            int idUser = int.Parse(gv1.SelectedRow.Cells[1].Text);
            userDTO = userBLL.SearchBLL(idUser);
            PreencheCampos();
        }
    }
}