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
        private ChamadoService chamadoService;
        private ValidacaoAberturaChamado validacaoAberturaChamado;
        private Usuario usuarioLogado;

        public FormAberturaChamado(Usuario usuarioLogado)
        {
            this.chamadoService = new ChamadoService();
            this.validacaoAberturaChamado = new ValidacaoAberturaChamado();
            this.usuarioLogado = usuarioLogado;
            InitializeComponent();
            cbxPrioridade.SelectedIndex = 0;
            cbxJornada.SelectedIndex = 0;
            cbxModulo.SelectedIndex = 0;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaCamposAberturaChamado())
            {
                PrioridadeChamado prioridadeChamado = ConverterPrioridadeParaEnum(cbxPrioridade.SelectedIndex);

                AberturaChamadoDTO aberturaChamadoDTO = new AberturaChamadoDTO(txtTitulo.Text,
                                                                                txtDescricao.Text,
                                                                                prioridadeChamado,
                                                                                usuarioLogado.id_usuario,
                                                                                cbxModulo.SelectedIndex,
                                                                                cbxJornada.SelectedIndex);
                var chamado = chamadoService.AbrirChamado(aberturaChamadoDTO);

                if (chamado != null)
                {
                    MessageBox.Show("Chamado aberto com sucesso!",
                                    "TechSolutions",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possível abrir o chamado",
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
            return validacaoAberturaChamado.ValidaTitulo(txtTitulo.Text) &&
                validacaoAberturaChamado.ValidaDescricao(txtDescricao.Text) &&
                validacaoAberturaChamado.ValidaPrioridade(cbxPrioridade.SelectedIndex) &&
                validacaoAberturaChamado.ValidaModulo(cbxModulo.SelectedIndex) &&
                validacaoAberturaChamado.ValidaJornada(cbxJornada.SelectedIndex);
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            if (!validacaoAberturaChamado.ValidaTitulo(txtTitulo.Text))
            {
                errorProvider1.SetError(txtTitulo, "O título do chamado deve ser informado");
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (!validacaoAberturaChamado.ValidaDescricao(txtDescricao.Text))
            {
                errorProvider1.SetError(txtDescricao, "A descrição do chamado deve ser informada");
            }
        }

        private void cbxPrioridade_Leave(object sender, EventArgs e)
        {
            if (!validacaoAberturaChamado.ValidaPrioridade(cbxPrioridade.SelectedIndex))
            {
                errorProvider1.SetError(cbxPrioridade, "A prioridade do chamado deve ser informada");
            }
        }

        private void cbxJornada_Leave(object sender, EventArgs e)
        {
            if (!validacaoAberturaChamado.ValidaJornada(cbxJornada.SelectedIndex))
            {
                errorProvider1.SetError(cbxJornada, "A jornada deve ser informada");
            }
        }

        private void cbxModulo_Leave(object sender, EventArgs e)
        {
            if (!validacaoAberturaChamado.ValidaModulo(cbxModulo.SelectedIndex))
            {
                errorProvider1.SetError(cbxModulo, "O módulo deve ser informado");
            }
        }
    }
}
