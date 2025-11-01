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
using static System.Windows.Forms.DataFormats;

namespace TecnPoint.Interfaces
{
    public partial class FormDetalhesChamado : Form
    {
        private Usuario usuarioLogado;
        private ChamadoDTO chamado;
        private FormAcompanharChamados formAcompanharChamados;
        private ChamadoService chamadoService;

        // Variável para controlar quando disparar o evento de SelectedIndexChanged das Combobox
        private bool carregandoComboBox = true;

        public FormDetalhesChamado(ChamadoDTO chamadoSelecionado, Usuario usuarioLogado, FormAcompanharChamados formAcompanharChamado)
        {
            this.usuarioLogado = usuarioLogado;
            this.chamado = chamadoSelecionado;
            this.formAcompanharChamados = formAcompanharChamado;
            this.chamadoService = new ChamadoService();
            InitializeComponent();
        }

        private void PreencherDetalhes()
        {
            lblTitulo.Text = chamado.titulo;
            lblStatus.Text = ConverteEnumStatus(chamado.status);
            lblStatus.BackColor = FundoStatus(chamado.status);
            lblPrioridade.Text = ConverteEnumPrioridade(chamado.prioridade);
            lblNomeCliente.Text = chamado.cliente.nome;
            lblNomeFuncionario.Text = chamado.funcionario.nome;
            lblDescricaoDoChamado.Text = chamado.descricao;
            lblJornada.Text = chamado.jornada.jornada;
            lblModulo.Text = chamado.modulo.modulo;
        }

        private async void FormDetalhesChamado_Load(object sender, EventArgs e)
        {
            // Variável para controlar quando disparar o evento de SelectedIndexChanged das Combobox
            carregandoComboBox = true;

            if (usuarioLogado.tipoUsuario == TipoUsuario.CLIENTE)
            {
                cbxStatus.Visible = false;
                cbxPrioridade.Visible = false;
                cbxNomeFuncionario.Visible = false;
            }

            PreencherDetalhes();
            await CarregaNomeCbxFuncionarios(cbxNomeFuncionario);

            cbxStatus.SelectedIndex = 0;
            cbxPrioridade.SelectedIndex = 0;
            //cbxJornada.SelectedIndex = Convert.ToInt32(chamado.jornada.id_jornada);
            //cbxModulo.SelectedIndex = Convert.ToInt32(chamado.modulo.id_modulo);
            cbxJornada.SelectedIndex = 0;
            cbxModulo.SelectedIndex = 0;
            carregandoComboBox = false;
        }

        private async Task CarregaNomeCbxFuncionarios(ComboBox comboBox)
        {
            try
            {
                List<ListagemFuncionariosDTO> listaFunc = await chamadoService.CarregaNomeFuncionarios();
                comboBox.DataSource = listaFunc;
                comboBox.DisplayMember = "nome";
                comboBox.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os funcionários do sistema\n" + ex.Message,
                                       "TechSolutions",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
            }
        }

        private async void cbxNomeFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoComboBox && cbxNomeFuncionario.SelectedValue != null)
            {
                try
                {
                    long idFuncionarioSelecionado = Convert.ToInt64(cbxNomeFuncionario.SelectedValue);

                    AtualizaChamadoDTO dadosParaAtualizarChamado = new AtualizaChamadoDTO
                    {
                        id_chamado = chamado.id_chamado,
                        id_usuario = idFuncionarioSelecionado
                    };

                    this.chamado = await chamadoService.AtualizaChamado(dadosParaAtualizarChamado);

                    lblNomeFuncionario.Text = chamado.funcionario.nome;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível atualizar o funcionário do chamado,\nselecione um item válido\n" + ex.Message,
                                           "TechSolutions",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                }
            }
        }


        private async void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoComboBox && cbxStatus.SelectedIndex > 0)
            {
                try
                {
                    AtualizaChamadoDTO dadosParaAtualizarChamado = new AtualizaChamadoDTO();

                    dadosParaAtualizarChamado.id_chamado = chamado.id_chamado;
                    dadosParaAtualizarChamado.status = (StatusChamado)cbxStatus.SelectedIndex - 1;

                    this.chamado = await chamadoService.AtualizaChamado(dadosParaAtualizarChamado);

                    lblStatus.Text = ConverteEnumStatus(chamado.status);
                    lblStatus.BackColor = FundoStatus(chamado.status);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível atualizar o status do chamado,\nselecione um item válido\n" + ex.Message,
                                           "TechSolutions",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                }
            }
        }

        private async void cbxPrioridade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoComboBox && cbxPrioridade.SelectedIndex > 0)
            {
                try
                {
                    AtualizaChamadoDTO dadosParaAtualizarChamado = new AtualizaChamadoDTO();

                    dadosParaAtualizarChamado.id_chamado = chamado.id_chamado;
                    dadosParaAtualizarChamado.prioridade = (PrioridadeChamado)cbxPrioridade.SelectedIndex - 1;

                    this.chamado = await chamadoService.AtualizaChamado(dadosParaAtualizarChamado);

                    lblPrioridade.Text = ConverteEnumPrioridade(chamado.prioridade);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível atualizar a prioridade do chamado,\nselecione um item válido\n" + ex.Message,
                                           "TechSolutions",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                }
            }
        }

        private async void cbxJornada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoComboBox && cbxJornada.SelectedIndex > 0)
            {
                try
                {
                    AtualizaChamadoDTO dadosParaAtualizarNoChamado = new AtualizaChamadoDTO
                    {
                        id_chamado = chamado.id_chamado,
                        idJornada = cbxJornada.SelectedIndex
                    };

                    this.chamado = await chamadoService.AtualizaChamado(dadosParaAtualizarNoChamado);

                    lblJornada.Text = this.chamado.jornada.jornada;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível atualizar a jornada do chamado,\nselecione um item válido\n" + ex.Message,
                                           "TechSolutions",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                }
            }
        }

        private async void cbxModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!carregandoComboBox && cbxModulo.SelectedIndex > 0)
            {
                try
                {
                    AtualizaChamadoDTO dadosParaAtualizarChamado = new AtualizaChamadoDTO
                    {
                        id_chamado = chamado.id_chamado,
                        idModulo = cbxModulo.SelectedIndex
                    };

                    this.chamado = await chamadoService.AtualizaChamado(dadosParaAtualizarChamado);

                    lblModulo.Text = this.chamado.modulo.modulo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível atualizar o módulo do chamado,\nselecione um item válido\n" + ex.Message,
                                           "TechSolutions",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                }
            }
        }

        private void pbIconVoltar_Click(object sender, EventArgs e)
        {
            formAcompanharChamados.flpPanelCardsChamados.Controls.Clear();
            formAcompanharChamados.CarregaChamados();
            formAcompanharChamados.ExibirCards();
        }

        private Color FundoStatus(StatusChamado status)
        {
            if (status == StatusChamado.ABERTO) return Color.FromArgb(211, 211, 211);
            if (status == StatusChamado.EM_ANDAMENTO) return Color.FromArgb(236, 169, 44);
            if (status == StatusChamado.PENDENTE) return Color.FromArgb(76, 143, 197);
            if (status == StatusChamado.RESOLVIDO) return Color.FromArgb(67, 180, 128);
            return Color.Gray;
        }

        private string ConverteEnumStatus(StatusChamado status)
        {
            if (status == StatusChamado.ABERTO) return "Aberto";
            if (status == StatusChamado.EM_ANDAMENTO) return "Em andamento";
            if (status == StatusChamado.PENDENTE) return "Pendente";
            if (status == StatusChamado.RESOLVIDO) return "Resolvido";
            return "";
        }

        private string ConverteEnumPrioridade(PrioridadeChamado prioridade)
        {
            if (prioridade == PrioridadeChamado.BAIXA) return "Baixa";
            if (prioridade == PrioridadeChamado.MEDIA) return "Média";
            if (prioridade == PrioridadeChamado.ALTA) return "Alta";
            return "";
        }
    }
}
