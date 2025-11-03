using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnPoint.Modelos.DTO;
using TecnPoint.Modelos.Enum;
using TecnPoint.Services;
using TecnPoint.Services.Validacoes;

namespace TecnPoint.Interfaces
{
    public partial class FormCadastrarUsuario : Form
    {
        private UsuarioService _usuarioService;
        private ValidacaoDadosUsuario _validacaoCadastro;
        private FrmMDIPrincipal frmMDIPrincipal;

        public FormCadastrarUsuario(FrmMDIPrincipal frmMDIPrincipal)
        {
            this._usuarioService = new UsuarioService();
            this._validacaoCadastro = new ValidacaoDadosUsuario();
            this.frmMDIPrincipal = frmMDIPrincipal;
            InitializeComponent();
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidaCadastroUsuario())
            {
                CadastroUsuarioDTO dadosCadastrarUsuario = new CadastroUsuarioDTO
                {
                    nome = txtNomeUsuario.Text,
                    email = txtEmailUsuario.Text,
                    senha = txtSenhaUsuario.Text,
                    tipoUsuario = ConverterTipoUsuarioParaEnum(cbxTipoUsuario.SelectedIndex)
                };

                try
                {
                    UsuarioCadastradoDTO usuarioCadastrado = await _usuarioService.CadastrarUsuario(dadosCadastrarUsuario);

                    if (usuarioCadastrado != null)
                    {
                        MessageBox.Show("Usuário cadastrado com sucesso!",
                                        "Tech Solutions",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível cadastrar o usuário\n" + ex.Message,
                                        "Tech Solutions",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (lblInfoEmail.Visible == false && lblExclamacaoInfoEmail.Visible == false)
            {
                lblInfoEmail.Visible = true;
                lblExclamacaoInfoEmail.Visible = true;
            }
            else
            {
                lblInfoEmail.Visible = false;
                lblExclamacaoInfoEmail.Visible = false;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.frmMDIPrincipal.CarregaFormLogo();
        }

        private bool ValidaCadastroUsuario()
        {
            return _validacaoCadastro.ValidaNome(txtNomeUsuario.Text) &&
                _validacaoCadastro.ValidaEmail(txtEmailUsuario.Text) &&
                _validacaoCadastro.ValidaSenha(txtSenhaUsuario.Text) &&
                _validacaoCadastro.ValidaConfirmacaoDeSenha(txtSenhaUsuario.Text, txtConfirmaSenhaUsuario.Text) &&
                _validacaoCadastro.ValidaTipoUsuario(cbxTipoUsuario.SelectedIndex);
        }

        private TipoUsuario ConverterTipoUsuarioParaEnum(int selectedIndex)
        {
            if (selectedIndex == 1) return TipoUsuario.CLIENTE;
            if (selectedIndex == 2) return TipoUsuario.FUNCIONARIO;
            return TipoUsuario.CLIENTE;
        }

        private void txtNomeUsuario_Leave(object sender, EventArgs e)
        {
            if (!_validacaoCadastro.ValidaNome(txtNomeUsuario.Text))
            {
                errorDadosCadastroInvalidos.SetError(txtNomeUsuario, "Nome inválido");
            }
            else
            {
                errorDadosCadastroInvalidos.SetError(txtNomeUsuario, "");
            }
        }

        private void txtEmailUsuario_Leave(object sender, EventArgs e)
        {
            if (!_validacaoCadastro.ValidaEmail(txtEmailUsuario.Text))
            {
                errorDadosCadastroInvalidos.SetError(txtEmailUsuario, "E-mail inválido");
            }
            else
            {
                errorDadosCadastroInvalidos.SetError(txtEmailUsuario, "");
            }
        }

        private void txtSenhaUsuario_Leave(object sender, EventArgs e)
        {
            if (!_validacaoCadastro.ValidaSenha(txtSenhaUsuario.Text))
            {
                errorDadosCadastroInvalidos.SetError(txtSenhaUsuario, "Senha inválida");
            }
            else
            {
                errorDadosCadastroInvalidos.SetError(txtSenhaUsuario, "");
            }
        }

        private void txtConfirmaSenhaUsuario_Leave(object sender, EventArgs e)
        {
            if (!_validacaoCadastro.ValidaConfirmacaoDeSenha(txtSenhaUsuario.Text, txtConfirmaSenhaUsuario.Text))
            {
                errorDadosCadastroInvalidos.SetError(txtConfirmaSenhaUsuario, "As senhas são diferentes");
            }
            else
            {
                errorDadosCadastroInvalidos.SetError(txtConfirmaSenhaUsuario, "");
            }
        }

        private void cbxTipoUsuario_Leave(object sender, EventArgs e)
        {
            if (!_validacaoCadastro.ValidaTipoUsuario(cbxTipoUsuario.SelectedIndex))
            {
                errorDadosCadastroInvalidos.SetError(cbxTipoUsuario, "Tipo de usuário inválido");
            }
            else
            {
                errorDadosCadastroInvalidos.SetError(cbxTipoUsuario, "");
            }
        }

        private void txtSenhaUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
