using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnPoint.Modelos;
using TecnPoint.Modelos.DTO;
using TecnPoint.Modelos.Enum;
using TecnPoint.Services;
using TecnPoint.Services.Validacoes;

namespace TecnPoint.Interfaces
{
    public partial class FormAberturaChamado : Form
    {
        private ChamadoService _chamadoService;
        private ValidacaoAberturaChamado _validacaoAberturaChamado;
        private Usuario _usuarioLogado;
        private FrmMDIPrincipal frmMDIPrincipal;
        private readonly bool _modoDaltonico;

        public FormAberturaChamado(Usuario usuarioLogado, FrmMDIPrincipal frmMDIPrincipal, bool modoDaltonico)
        {
            this._chamadoService = new ChamadoService();
            this._validacaoAberturaChamado = new ValidacaoAberturaChamado();
            this._usuarioLogado = usuarioLogado;
            this.frmMDIPrincipal = frmMDIPrincipal;
            InitializeComponent();
            cbxPrioridade.SelectedIndex = 0;
            cbxJornada.SelectedIndex = 0;
            cbxModulo.SelectedIndex = 0;
            _modoDaltonico = modoDaltonico;
            ModoDaltonismo();
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaCamposAberturaChamado())
            {
                PrioridadeChamado prioridadeChamado = ConverterPrioridadeParaEnum(cbxPrioridade.SelectedIndex);

                AberturaChamadoDTO aberturaChamadoDTO = new AberturaChamadoDTO(txtTitulo.Text,
                                                                                txtDescricao.Text,
                                                                                prioridadeChamado,
                                                                                _usuarioLogado.idUsuario,
                                                                                cbxModulo.SelectedIndex,
                                                                                cbxJornada.SelectedIndex);
                try
                {
                    var chamado = await _chamadoService.AbrirChamado(aberturaChamadoDTO);

                    MessageBox.Show("Chamado aberto com sucesso!",
                                        "TechSolutions",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    LimparCampos();

                }
                catch (Exception ex) // Exceção lançada pelo Service
                {
                    MessageBox.Show($"Não foi possível abrir o chamado\n{ex.Message}",
                                        "TechSolutions",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Não foi possível abrir o chamado\nPreencha corretamente todos os campos",
                                    "TechSolutions",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private PrioridadeChamado ConverterPrioridadeParaEnum(int selectedIndex)
        {
            if (selectedIndex == 1) return PrioridadeChamado.BAIXA;
            if (selectedIndex == 2) return PrioridadeChamado.MEDIA;
            if (selectedIndex == 3) return PrioridadeChamado.ALTA;
            return PrioridadeChamado.BAIXA;
        }

        // Retorna verdadeiro se todos os campos estiverem preenchidos corretamente
        private bool ValidaCamposAberturaChamado()
        {
            return _validacaoAberturaChamado.ValidaTitulo(txtTitulo.Text) &&
                _validacaoAberturaChamado.ValidaDescricao(txtDescricao.Text) &&
                _validacaoAberturaChamado.ValidaPrioridade(cbxPrioridade.SelectedIndex) &&
                _validacaoAberturaChamado.ValidaModulo(cbxModulo.SelectedIndex) &&
                _validacaoAberturaChamado.ValidaJornada(cbxJornada.SelectedIndex);
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            if (!_validacaoAberturaChamado.ValidaTitulo(txtTitulo.Text))
            {
                errorProvider1.SetError(txtTitulo, "O título do chamado deve ser informado");
            }
            else
            {
                errorProvider1.SetError(txtTitulo, "");
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (!_validacaoAberturaChamado.ValidaDescricao(txtDescricao.Text))
            {
                errorProvider1.SetError(txtDescricao, "A descrição do chamado deve ser informada");
            }
            else
            {
                errorProvider1.SetError(txtDescricao, "");
            }
        }

        private void cbxPrioridade_Leave(object sender, EventArgs e)
        {
            if (!_validacaoAberturaChamado.ValidaPrioridade(cbxPrioridade.SelectedIndex))
            {
                errorProvider1.SetError(cbxPrioridade, "A prioridade do chamado deve ser informada");
            }
            else
            {
                errorProvider1.SetError(cbxPrioridade, "");
            }
        }

        private void cbxJornada_Leave(object sender, EventArgs e)
        {
            if (!_validacaoAberturaChamado.ValidaJornada(cbxJornada.SelectedIndex))
            {
                errorProvider1.SetError(cbxJornada, "A jornada deve ser informada");
            }
            else
            {
                errorProvider1.SetError(cbxJornada, "");
            }
        }

        private void cbxModulo_Leave(object sender, EventArgs e)
        {
            if (!_validacaoAberturaChamado.ValidaModulo(cbxModulo.SelectedIndex))
            {
                errorProvider1.SetError(cbxModulo, "O módulo deve ser informado");
            }
            else
            {
                errorProvider1.SetError(cbxModulo, "");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmMDIPrincipal.CarregaFormLogo();
        }

        private void LimparCampos()
        {
            txtTitulo.Text = "";
            txtDescricao.Text = "";
            cbxPrioridade.SelectedIndex = 0;
            cbxModulo.SelectedIndex = 0;
            cbxJornada.SelectedIndex = 0;
        }

        private void ModoDaltonismo()
        {
            if (_modoDaltonico)
            {
                btnConfirmar.BackColor = Color.FromArgb(171, 126, 105);
                btnConfirmar.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 190, 137);
                btnConfirmar.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 163, 89);

                btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 190, 137);
                btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 163, 89);

                pbInfoJornada.Image = Interfaces.Properties.Resources.logoInfoDaltonico;
                pbInfoModulo.Image = Interfaces.Properties.Resources.logoInfoDaltonico;
            }
            else
            {
                btnConfirmar.BackColor = Color.FromArgb(126, 105, 171);
                btnConfirmar.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 137, 254);
                btnConfirmar.FlatAppearance.MouseOverBackColor = Color.FromArgb(163, 89, 253);

                btnCancelar.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 137, 254);
                btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(163, 89, 253);

                pbInfoModulo.Image = Interfaces.Properties.Resources.icons8_informações_48;
                pbInfoJornada.Image = Interfaces.Properties.Resources.icons8_informações_48;
            }
        }

        private void pbInfoJornada_Click(object sender, EventArgs e)
        {
            if (lblInfoJornada.Visible == false)
            {
                lblInfoJornada.Visible = true;
            }
            else
            {
                lblInfoJornada.Visible = false;
            }
        }

        private void pbInfoModulo_Click(object sender, EventArgs e)
        {
            if (lblInfoModulo.Visible == false)
            {
                lblInfoModulo.Visible = true;
            }
            else
            {
                lblInfoModulo.Visible = false;
            }
        }

        private void CentralizarVerticalmente()
        {
            // Calcular altura total dos controles
            int espacamentoVertical = 15;
            int alturaTotal =
                lblTitulo.Height + txtTitulo.Height + espacamentoVertical +
                lblDescricao.Height + txtDescricao.Height + espacamentoVertical +
                lblPrioridade.Height + cbxPrioridade.Height + espacamentoVertical +
                lblJornada.Height + cbxJornada.Height + espacamentoVertical +
                lblModulo.Height + cbxModulo.Height + espacamentoVertical +
                btnConfirmar.Height + 40;

            int topoInicial = (this.ClientSize.Height - alturaTotal) / 2;

            // Posicionar controles verticalmente
            int posicaoAtual = topoInicial;

            lblTitulo.Top = posicaoAtual;
            posicaoAtual += lblTitulo.Height + 10;

            txtTitulo.Top = posicaoAtual;
            posicaoAtual += txtTitulo.Height + espacamentoVertical;

            lblDescricao.Top = posicaoAtual;
            posicaoAtual += lblDescricao.Height + 10;

            txtDescricao.Top = posicaoAtual;
            posicaoAtual += txtDescricao.Height + espacamentoVertical;

            lblPrioridade.Top = posicaoAtual;
            posicaoAtual += lblPrioridade.Height + 10;

            cbxPrioridade.Top = posicaoAtual;
            posicaoAtual += cbxPrioridade.Height + espacamentoVertical;

            lblJornada.Top = posicaoAtual;
            pbInfoJornada.Top = posicaoAtual;
            lblInfoJornada.Top = posicaoAtual;
            posicaoAtual += lblJornada.Height + 10;

            cbxJornada.Top = posicaoAtual;
            posicaoAtual += cbxJornada.Height + espacamentoVertical;

            lblModulo.Top = posicaoAtual;
            pbInfoModulo.Top = posicaoAtual;
            lblInfoModulo.Top = posicaoAtual;
            posicaoAtual += lblModulo.Height + 10;

            cbxModulo.Top = posicaoAtual;
            posicaoAtual += cbxModulo.Height + 20;

            btnCancelar.Top = posicaoAtual;
            btnConfirmar.Top = posicaoAtual;
        }

        private void CentralizarControles()
        {
            // Calcular o centro horizontal do formulário
            int centroHorizontal = this.ClientSize.Width / 2;

            // Largura padrão dos controles (355px conforme seu designer)
            int larguraControles = 355;
            int posicaoEsquerda = centroHorizontal - (larguraControles / 2);

            // Centralizar labels e controles horizontalmente
            lblTitulo.Left = posicaoEsquerda - 15;
            txtTitulo.Left = posicaoEsquerda;

            lblDescricao.Left = posicaoEsquerda - 15;
            txtDescricao.Left = posicaoEsquerda;

            lblPrioridade.Left = posicaoEsquerda - 15;
            cbxPrioridade.Left = posicaoEsquerda;

            lblJornada.Left = posicaoEsquerda - 15;
            cbxJornada.Left = posicaoEsquerda;
            pbInfoJornada.Left = lblJornada.Right + 5;
            lblInfoJornada.Left = pbInfoJornada.Right + 5;

            lblModulo.Left = posicaoEsquerda - 15;
            cbxModulo.Left = posicaoEsquerda;
            pbInfoModulo.Left = lblModulo.Right + 5;
            lblInfoModulo.Left = pbInfoModulo.Right + 5;

            // Centralizar botões
            int espacoEntreBotoes = 20;
            int larguraTotalBotoes = btnCancelar.Width + espacoEntreBotoes + btnConfirmar.Width;
            int posicaoInicioBotoes = centroHorizontal - (larguraTotalBotoes / 2);

            btnCancelar.Left = posicaoInicioBotoes;
            btnConfirmar.Left = btnCancelar.Right + espacoEntreBotoes;

            CentralizarVerticalmente();
        }

        private void FormAberturaChamado_Resize(object sender, EventArgs e)
        {
            CentralizarControles();
        }
    }
}
