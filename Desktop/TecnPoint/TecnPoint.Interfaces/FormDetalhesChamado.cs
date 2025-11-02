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
        private ConversaService conversaService;

        long idUltimaMensagem = 0;

        // Variável para controlar quando disparar o evento de SelectedIndexChanged das Combobox
        private bool carregandoComboBox = true;

        private bool atualizandoDadosChamado = false;

        public FormDetalhesChamado(ChamadoDTO chamadoSelecionado, Usuario usuarioLogado, FormAcompanharChamados formAcompanharChamado)
        {
            this.usuarioLogado = usuarioLogado;
            this.chamado = chamadoSelecionado;
            this.formAcompanharChamados = formAcompanharChamado;
            this.chamadoService = new ChamadoService();
            this.conversaService = new ConversaService();
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
                cbxJornada.Visible = false;
                cbxModulo.Visible = false;
            }

            PreencherDetalhes();
            await CarregaNomeCbxFuncionarios(cbxNomeFuncionario);
            await CarregaMensagens();

            cbxStatus.SelectedIndex = 0;
            cbxPrioridade.SelectedIndex = 0;
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
                        idChamado = chamado.idChamado,
                        idUsuario = idFuncionarioSelecionado
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

                    dadosParaAtualizarChamado.idChamado = chamado.idChamado;
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

                    dadosParaAtualizarChamado.idChamado = chamado.idChamado;
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
                        idChamado = chamado.idChamado,
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
                        idChamado = chamado.idChamado,
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
        private async void pbIconEnviarMensagem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMensagem.Text))
            {
                try
                {
                    MensagemDTO mensagemASerEnviada = new MensagemDTO
                    {
                        idChamado = this.chamado.idChamado,
                        idRemetente = this.usuarioLogado.idUsuario,
                        mensagem = txtMensagem.Text
                    };

                    await conversaService.EnviarMensagem(mensagemASerEnviada);
                    txtMensagem.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível enviar a mensagem,\n" + ex.Message,
                                           "TechSolutions",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                }
            }
        }

        private async Task CarregaMensagens()
        {
            List<ConversaDTO> listaMensagens = new List<ConversaDTO>();
            BuscarMensagemDTO buscarMensagemDTO = new BuscarMensagemDTO
            {
                idChamado = this.chamado.idChamado,
                idUltimaConversa = this.idUltimaMensagem
            };

            listaMensagens = await conversaService.BuscarConversa(buscarMensagemDTO);

            foreach (var mensagem in listaMensagens)
            {
                ExibeMensagens(mensagem); //Exibe as mensagem, passa os dados da listaMensagens para a função

                //Atualiza o idUltimaMensagem
                if (mensagem.idConversa > this.idUltimaMensagem)
                {
                    this.idUltimaMensagem = mensagem.idConversa;
                }
            }
        }

        private async Task CarregaInfosChamado()
        {
            try
            {
                this.chamado = await chamadoService.BuscaChamadoPorId(this.chamado.idChamado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar informações do chamado\n" + ex.Message,
                                           "TechSolutions",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
            }
        }

        private async void timerAtualizaDados_Tick(object sender, EventArgs e)
        {
            if (atualizandoDadosChamado) return;
            try
            {
                atualizandoDadosChamado = true;
                await CarregaInfosChamado();
                await CarregaMensagens();
                PreencherDetalhes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar informações do chamado\n" + ex.Message,
                                           "TechSolutions",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
            }
            finally
            {
                atualizandoDadosChamado = false;
            }

        }

        private void ExibeMensagens(ConversaDTO mensagem)
        {
            Panel mensagemNoPanel = new Panel()
            {
                BackColor = Color.FromArgb(167, 112, 197),
                Width = panelConversa.Width - 30,
                AutoSize = true,
                Margin = new Padding(5),
                Padding = new Padding(10)
            };

            // Nome do remetente
            Label lblRemetente = new Label()
            {
                Text = mensagem.remetente.nome,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(5, 5)
            };

            mensagemNoPanel.Controls.Add(lblRemetente);

            // Data e hora de envio
            Label lblDataHora = new Label()
            {
                Text = mensagem.dataHoraEnvio.ToString("dd/MM/yyyy HH:mm"),
                AutoSize = true,
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = Color.Black,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            lblDataHora.Location = new Point(mensagemNoPanel.Width - lblDataHora.Width - 10, 8);

            // Texto da mensagem
            Label lblMensagem = new Label()
            {
                Text = mensagem.mensagem,
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                MaximumSize = new Size(panelConversa.Width - 70, 0),
                Location = new Point(5, lblRemetente.Bottom + 5)
            };

            // Adiciona os controles
            mensagemNoPanel.Controls.Add(lblMensagem);
            mensagemNoPanel.Controls.Add(lblDataHora);

            // Adiciona o painel ao FlowLayoutPanel
            panelConversa.Controls.Add(mensagemNoPanel);
            panelConversa.ScrollControlIntoView(mensagemNoPanel);

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
