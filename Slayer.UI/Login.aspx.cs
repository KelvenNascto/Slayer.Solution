using Slayer.BLL;
using Slayer.DTO;
using Slayer.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slayer.UI
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioDTO user = new UsuarioDTO();
        UsuarioBLL userBLL = new UsuarioBLL();

        //load Page
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResult.Text = "Bem vindo a nossa aplicação tosca!!!";
        }


        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //pegar as informacoes digitadas pelo usuario
            string nome = txtNome.Text.Trim();
            string senha = txtSenha.Text.Trim();

            //chamando o procedimento de autenticacao
            user = userBLL.AuthenticateUserBLL(nome, senha);
            if (user != null)
            {
                switch (user.UsuarioTp)
                {
                    case "1":
                        //ManageAdm.aspx
                        Session["User"] = user.NomeUsuario.Trim();
                        Response.Redirect("adm/ManageAdm.aspx");
                        break;
                    case "2":
                        //ConsultaUser.aspx
                        Session["User"] = user.NomeUsuario.Trim();
                        Response.Redirect("user/ConsultaUser.aspx");
                        break;
                }

                //lblResult.Text = $"usuário {nome} com acesso permitido !!";
            }
            else
            {

                lblResult.Text = $"Usuario {nome.ToUpper()} não cadastrado na base de dados";
                txtNome.Focus();
                //lblResult.Text = $"usuário não cadastrado !!";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtNome.Focus();
        }
    }
}