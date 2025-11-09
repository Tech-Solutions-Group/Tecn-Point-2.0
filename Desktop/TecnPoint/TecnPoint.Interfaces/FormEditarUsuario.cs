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
using TecnPoint.Services;
using TecnPoint.Services.Validacoes;

namespace TecnPoint.Interfaces
{
    public partial class FormEditarUsuario : Form
    {
        private UsuarioService _usuarioService;
        private EditarUsuarioDTO _editarUsuarioDTO;
        private ValidacaoDadosUsuario _validacaoDadosUsuario;
        private FrmMDIPrincipal frmMDIPrincipal;
        private bool _modoDaltonico;

        public FormEditarUsuario(EditarUsuarioDTO editarUsuarioDTO, bool modoDaltonico, FrmMDIPrincipal frmMDIPrincipal)
        {
            this._usuarioService = new UsuarioService();
            this._editarUsuarioDTO = editarUsuarioDTO;
            this._validacaoDadosUsuario = new ValidacaoDadosUsuario();
            this.frmMDIPrincipal = frmMDIPrincipal;
            this._modoDaltonico = modoDaltonico;
            InitializeComponent();
            ModoDaltonico();
            CentralizarControles();
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaCadastroUsuario())
            {
                try
                {
                    if (!VerificaAtualizacao())
                    {
                        MessageBox.Show("Não houve alteração em nenhum dos dados",
                                            "Tech Solutions",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        return;
                    }

                    UsuarioAtualizadoDTO usuarioAtualizado = await _usuarioService.EditarDadosUsuario(_editarUsuarioDTO);

                    if (usuarioAtualizado != null)
                    {
                        MessageBox.Show("Usuário atualizado com sucesso!",
                                            "Tech Solutions",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        // Voltar para a tabela de usuários
                        frmMDIPrincipal.CarregaListaUsuario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível atualizar os dados do usuário\n" + ex.Message,
                                            "Tech Solutions",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Informe os dados corretamente",
                                            "Tech Solutions",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
            }
        }

        private void PreencherDadosParaEdicao()
        {
            txtNome.Text = _editarUsuarioDTO.nome;
            txtEmail.Text = _editarUsuarioDTO.email;
            txtSenha.Text = _editarUsuarioDTO.senha;
        }

        private void FormEditarUsuario_Load(object sender, EventArgs e)
        {
            PreencherDadosParaEdicao();
            CentralizarControles();
        }

        private bool VerificaAtualizacao()
        {
            bool houveAlteracao = false;
            if (!txtNome.Text.Equals(_editarUsuarioDTO.nome))
            {
                _editarUsuarioDTO.nome = txtNome.Text;
                houveAlteracao = true;
            }

            if (!txtEmail.Text.Equals(_editarUsuarioDTO.email))
            {
                _editarUsuarioDTO.email = txtEmail.Text;
                houveAlteracao = true;
            }

            if (!txtSenha.Text.Equals(_editarUsuarioDTO.senha))
            {
                _editarUsuarioDTO.senha = txtSenha.Text;
                houveAlteracao = true;
            }
            return houveAlteracao;
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (!_validacaoDadosUsuario.ValidaNome(txtNome.Text))
            {
                errorDadosAtualizarUsuario.SetError(txtNome, "Nome inválido");
            }
            else
            {
                errorDadosAtualizarUsuario.SetError(txtNome, "");
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!_validacaoDadosUsuario.ValidaEmail(txtEmail.Text))
            {
                errorDadosAtualizarUsuario.SetError(txtEmail, "E-mail inválido");
            }
            else
            {
                errorDadosAtualizarUsuario.SetError(txtEmail, "");
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (!_validacaoDadosUsuario.ValidaSenha(txtSenha.Text))
            {
                errorDadosAtualizarUsuario.SetError(txtSenha, "Senha inválida");
            }
            else
            {
                errorDadosAtualizarUsuario.SetError(txtSenha, "");
            }
        }

        private void txtConfirmaSenha_Leave(object sender, EventArgs e)
        {
            if (!_validacaoDadosUsuario.ValidaConfirmacaoDeSenha(txtSenha.Text, txtConfirmaSenha.Text))
            {
                errorDadosAtualizarUsuario.SetError(txtConfirmaSenha, "As senhas não são iguais");
            }
            else
            {
                errorDadosAtualizarUsuario.SetError(txtConfirmaSenha, "");
            }
        }
        private bool ValidaCadastroUsuario()
        {
            return _validacaoDadosUsuario.ValidaNome(txtNome.Text) &&
                _validacaoDadosUsuario.ValidaEmail(txtEmail.Text) &&
                _validacaoDadosUsuario.ValidaSenha(txtSenha.Text) &&
                _validacaoDadosUsuario.ValidaConfirmacaoDeSenha(txtSenha.Text, txtConfirmaSenha.Text);
        }

        private void ModoDaltonico()
        {
            if (_modoDaltonico)
            {
                btnSalvar.BackColor = Color.FromArgb(171, 126, 105);
                btnSalvar.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 190, 137);
                btnSalvar.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 163, 89);

                btnVoltar.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 190, 137);
                btnVoltar.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 163, 89);
            }
            else
            {
                btnSalvar.BackColor = Color.FromArgb(126, 105, 171);
                btnSalvar.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 137, 254);
                btnSalvar.FlatAppearance.MouseOverBackColor = Color.FromArgb(163, 89, 253);

                btnVoltar.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 137, 254);
                btnVoltar.FlatAppearance.MouseOverBackColor = Color.FromArgb(163, 89, 253);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMDIPrincipal.CarregaFormLogo();
        }

        private void CentralizarControles()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0) return;

            // Calcular o centro horizontal do formulário
            int centroHorizontal = this.ClientSize.Width / 2;

            // Largura padrão dos controles
            int larguraControles = 338;
            int posicaoEsquerda = centroHorizontal - (larguraControles / 2);

            // Centralizar labels e controles horizontalmente
            lblNome.Left = posicaoEsquerda;
            txtNome.Left = posicaoEsquerda;
            txtNome.Width = larguraControles;

            lblEmail.Left = posicaoEsquerda;
            txtEmail.Left = posicaoEsquerda;
            txtEmail.Width = larguraControles;

            lblSenha.Left = posicaoEsquerda;
            txtSenha.Left = posicaoEsquerda;
            txtSenha.Width = larguraControles;

            lblConfirmarSenha.Left = posicaoEsquerda;
            txtConfirmaSenha.Left = posicaoEsquerda;
            txtConfirmaSenha.Width = larguraControles;

            // Centralizar botões
            int espacoEntreBotoes = 20;
            int larguraTotalBotoes = btnVoltar.Width + espacoEntreBotoes + btnSalvar.Width;
            int posicaoInicioBotoes = centroHorizontal - (larguraTotalBotoes / 2);

            btnVoltar.Left = posicaoInicioBotoes;
            btnSalvar.Left = btnVoltar.Right + espacoEntreBotoes;

            // Centralizar verticalmente
            CentralizarVerticalmente();
        }

        private void CentralizarVerticalmente()
        {
            int espacamento = 15;

            // Calcular altura total de todos os controles
            int alturaTotal =
                lblNome.Height + txtNome.Height + espacamento +
                lblEmail.Height + txtEmail.Height + espacamento +
                lblSenha.Height + txtSenha.Height + espacamento +
                lblConfirmarSenha.Height + txtConfirmaSenha.Height + espacamento +
                btnSalvar.Height + 40; // 40 = margem extra

            int topoInicial = (this.ClientSize.Height - alturaTotal) / 2;
            int posicaoAtual = topoInicial;

            // Posicionar verticalmente
            lblNome.Top = posicaoAtual;
            posicaoAtual += lblNome.Height + 5;

            txtNome.Top = posicaoAtual;
            posicaoAtual += txtNome.Height + espacamento;

            lblEmail.Top = posicaoAtual;
            posicaoAtual += lblEmail.Height + 5;

            txtEmail.Top = posicaoAtual;
            posicaoAtual += txtEmail.Height + espacamento;

            lblSenha.Top = posicaoAtual;
            posicaoAtual += lblSenha.Height + 5;

            txtSenha.Top = posicaoAtual;
            posicaoAtual += txtSenha.Height + espacamento;

            lblConfirmarSenha.Top = posicaoAtual;
            posicaoAtual += lblConfirmarSenha.Height + 5;

            txtConfirmaSenha.Top = posicaoAtual;
            posicaoAtual += txtConfirmaSenha.Height + 20;

            btnVoltar.Top = posicaoAtual;
            btnSalvar.Top = posicaoAtual;
        }

        private void FormEditarUsuario_Resize(object sender, EventArgs e)
        {
            CentralizarControles();
        }
    }
}
