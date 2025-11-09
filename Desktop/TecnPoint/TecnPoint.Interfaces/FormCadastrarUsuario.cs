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
        private bool _modoDaltonico;

        public FormCadastrarUsuario(FrmMDIPrincipal frmMDIPrincipal, bool modoDaltonico)
        {
            this._usuarioService = new UsuarioService();
            this._validacaoCadastro = new ValidacaoDadosUsuario();
            this.frmMDIPrincipal = frmMDIPrincipal;
            InitializeComponent();
            _modoDaltonico = modoDaltonico;
            ModoDaltonico();
            CentralizarControles();
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

        private void ModoDaltonico()
        {
            if (_modoDaltonico)
            {
                btnCadastrar.BackColor = Color.FromArgb(171, 126, 105);
                btnCadastrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 190, 137);
                btnCadastrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 163, 89);

                btnVoltar.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 190, 137);
                btnVoltar.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 163, 89);

                pictureBox1.Image = Interfaces.Properties.Resources.logoInfoDaltonico;
            }
            else
            {
                btnCadastrar.BackColor = Color.FromArgb(126, 105, 171);
                btnCadastrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 137, 254);
                btnCadastrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(163, 89, 253);

                btnVoltar.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 137, 254);
                btnVoltar.FlatAppearance.MouseOverBackColor = Color.FromArgb(163, 89, 253);

                pictureBox1.Image = Interfaces.Properties.Resources.icons8_informações_48;
            }
        }

        private void CentralizarControles()
        {
            // Calcular o centro horizontal do formulário
            int centroHorizontal = this.ClientSize.Width / 2;

            // Largura padrão dos controles
            int larguraControles = 375;
            int posicaoEsquerda = centroHorizontal - (larguraControles / 2);

            // Centralizar labels e controles horizontalmente
            lblNomeUsuario.Left = posicaoEsquerda;
            txtNomeUsuario.Left = posicaoEsquerda;
            txtNomeUsuario.Width = larguraControles;

            lblEmailUsuario.Left = posicaoEsquerda;
            pictureBox1.Left = lblEmailUsuario.Right + 5;
            lblInfoEmail.Left = pictureBox1.Right + 5;
            lblExclamacaoInfoEmail.Left = lblInfoEmail.Right + 5;
            txtEmailUsuario.Left = posicaoEsquerda;
            txtEmailUsuario.Width = larguraControles;

            lblSenhaUsuario.Left = posicaoEsquerda;
            txtSenhaUsuario.Left = posicaoEsquerda;
            txtSenhaUsuario.Width = larguraControles;

            lblConfirmaSenha.Left = posicaoEsquerda;
            txtConfirmaSenhaUsuario.Left = posicaoEsquerda;
            txtConfirmaSenhaUsuario.Width = larguraControles;

            lblTipoUsuario.Left = posicaoEsquerda;
            cbxTipoUsuario.Left = posicaoEsquerda;
            cbxTipoUsuario.Width = larguraControles;

            // Centralizar botões
            int espacoEntreBotoes = 20;
            int larguraTotalBotoes = btnVoltar.Width + espacoEntreBotoes + btnCadastrar.Width;
            int posicaoInicioBotoes = centroHorizontal - (larguraTotalBotoes / 2);

            btnVoltar.Left = posicaoInicioBotoes;
            btnCadastrar.Left = btnVoltar.Right + espacoEntreBotoes;

            // Centralizar verticalmente
            CentralizarVerticalmente();
        }

        private void CentralizarVerticalmente()
        {
            int espacamento = 15;

            // Calcular altura total de todos os controles
            int alturaTotal =
                lblNomeUsuario.Height + txtNomeUsuario.Height + espacamento +
                lblEmailUsuario.Height + txtEmailUsuario.Height + espacamento +
                lblSenhaUsuario.Height + txtSenhaUsuario.Height + espacamento +
                lblConfirmaSenha.Height + txtConfirmaSenhaUsuario.Height + espacamento +
                lblTipoUsuario.Height + cbxTipoUsuario.Height + espacamento +
                btnCadastrar.Height + 40; // 40 = margem extra

            int topoInicial = (this.ClientSize.Height - alturaTotal) / 2;
            int posicaoAtual = topoInicial;

            // Posicionar verticalmente
            lblNomeUsuario.Top = posicaoAtual;
            posicaoAtual += lblNomeUsuario.Height + 5;

            txtNomeUsuario.Top = posicaoAtual;
            posicaoAtual += txtNomeUsuario.Height + espacamento;

            lblEmailUsuario.Top = posicaoAtual;
            pictureBox1.Top = posicaoAtual;
            lblInfoEmail.Top = posicaoAtual;
            lblExclamacaoInfoEmail.Top = posicaoAtual;
            posicaoAtual += lblEmailUsuario.Height + 5;

            txtEmailUsuario.Top = posicaoAtual;
            posicaoAtual += txtEmailUsuario.Height + espacamento;

            lblSenhaUsuario.Top = posicaoAtual;
            posicaoAtual += lblSenhaUsuario.Height + 5;

            txtSenhaUsuario.Top = posicaoAtual;
            posicaoAtual += txtSenhaUsuario.Height + espacamento;

            lblConfirmaSenha.Top = posicaoAtual;
            posicaoAtual += lblConfirmaSenha.Height + 5;

            txtConfirmaSenhaUsuario.Top = posicaoAtual;
            posicaoAtual += txtConfirmaSenhaUsuario.Height + espacamento;

            lblTipoUsuario.Top = posicaoAtual;
            posicaoAtual += lblTipoUsuario.Height + 5;

            cbxTipoUsuario.Top = posicaoAtual;
            posicaoAtual += cbxTipoUsuario.Height + 20;

            btnVoltar.Top = posicaoAtual;
            btnCadastrar.Top = posicaoAtual;
        }

        private void FormCadastrarUsuario_Resize(object sender, EventArgs e)
        {
            CentralizarControles();
        }
    }
}
