using Dados;
using GUI.Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Waiter
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var objBlUsuario = new DLUsuario();
            try
            {
                #region
                //if (txtLogin.Text.Equals("admams") && txtSenha.Text.Equals("ams2018@"))
                //{
                //    // lblErro.InnerText = @"Ativação em fase de impementação! ", "AMS", MessageIcon.Error, MessageButton.OK);
                //    if (DateTime.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Informe a data de validade da Licença!", "Licença", ""), out DateTime dataExpiracao))
                //    {
                //        new DLConfiguracaoGeral().Atualizar(new MLConfiguracaoGeral() { DataExpiracaoLicenca = dataExpiracao });
                //         lblErro.InnerText = "Licença alterada com sucesso!\n\nNova Validade: " + dataExpiracao.ToShortDateString(), "Atenção", MessageIcon.Error, MessageButton.OK);
                //        lblValidadeLicenca.Text = "Licença valida até " + dataExpiracao.ToShortDateString();
                //        txtLogin.Clear();
                //        txtSenha.Clear();
                //        txtLogin.Focus();
                //    }
                //    else
                //    {
                //         lblErro.InnerText = @"Data Inválida!\n\nInforme a data no formato dd/mm/aaaa.", "Atenção", MessageIcon.Error, MessageButton.OK);
                //    }
                //    return;
                //}
                #endregion

                if (string.IsNullOrEmpty(txtLogin.Text) || String.IsNullOrEmpty(txtSenha.Text))
                {
                    lblErro.InnerText = @"Informe Usuário e Senha! ";
                    return;
                }
                string senha = "";
                if (string.IsNullOrEmpty(txtSenha.Text) || txtSenha.Text == "Insira a Senha")
                    senha = "";
                else
                    senha = txtSenha.Text;

                var usuario = objBlUsuario.Consultar(new MLUsuario() { Login = txtLogin.Text, Senha = senha });


                if (usuario.Tentativas >= 5)
                {
                    lblErro.InnerText = "Número de tentativas excedido!!!\n\nUsuário bloqueado.\n\nContate o Adminitrador!";
                    return;
                }
                //var validadeLicenca = Convert.ToDateTime(lblValidadeLicenca.Text.Replace("Licença valida até ", "")).Date;
                //var hoje = DateTime.Now.Date;

                //var diasDiferenca = (validadeLicenca - hoje);

                //if (diasDiferenca.Days >= 0 && diasDiferenca.Days <= 5)
                //{
                //    if (diasDiferenca.Days > 0)
                //         lblErro.InnerText = "Faltam " + diasDiferenca.Days + " dia(s) para expiração da Licença!\n\nPara renovação entre em contato com a SuppSys Sistemas! ", "Atenção", MessageIcon.Information, MessageButton.OK);
                //    else
                //         lblErro.InnerText = "Sua Licença expira hoje!!\n\nPara renovação entre em contato com a SuppSys Sistemas! ", "Atenção", MessageIcon.Information, MessageButton.OK);
                //}

                //if (Convert.ToDateTime(lblValidadeLicenca.Text.Replace("Licença valida até ", "")).Date < DateTime.Now.Date)
                //{
                //     lblErro.InnerText = "Licença expirada!\n\nContate a SuppSys Sistemas! ", "Atenção", MessageIcon.Information, MessageButton.OK);
                //    return;
                //}

                if (!(bool)usuario.Ativo)
                {
                    lblErro.InnerText = "Por motivos de Segurança seu usuário foi bloqueado!!!\n\nContate a SuppSys Sistemas! ";
                    return;
                }

                if (txtLogin.Text == usuario.Login && txtSenha.Text == usuario.Senha)
                {
                    Sessao.Instance.Usuario = usuario;
                    HttpContext.Current.Response.Redirect("Mesas");
                }
                else
                    lblErro.InnerText = @"Usuario ou Senha inválidos!!";

                if (usuario.Tentativas == 4)
                {
                    lblErro.InnerText = "Você possui apenas uma tentativa!\n\nNa próxima tentativa errada seu usuário será inativado!!";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    lblErro.InnerText = @"Erro: " + ex.InnerException.InnerException.Message;
                else
                    lblErro.InnerText = @"Erro: " + ex.Message;
            }
        }
    }
}