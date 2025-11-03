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
        private Usuario _usuarioLogado;
        private ChamadoDTO _chamado;
        private FormAcompanharChamados formAcompanharChamados;
        private ChamadoService _chamadoService;
        private ConversaService _conversaService;
        private readonly bool _modoDaltonico;

        long idUltimaMensagem = 0;

        // Variável para controlar quando disparar o evento de SelectedIndexChanged das Combobox
        private bool carregandoComboBox = true;

        private bool atualizandoDadosChamado = false;

        public FormDetalhesChamado(ChamadoDTO chamadoSelecionado, Usuario usuarioLogado, FormAcompanharChamados formAcompanharChamado, bool modoDaltonico)
        {
            this._usuarioLogado = usuarioLogado;
            this._chamado = chamadoSelecionado;
            this.formAcompanharChamados = formAcompanharChamado;
            this._chamadoService = new ChamadoService();
            this._conversaService = new ConversaService();
            InitializeComponent();
            _modoDaltonico = modoDaltonico;
            ModoDaltonismo();
        }

        private void PreencherDetalhes()
        {
            lblTitulo.Text = _chamado.titulo;
            lblStatus.Text = ConverteEnumStatus(_chamado.status);
            lblStatus.BackColor = FundoStatus(_chamado.status, _modoDaltonico);
            lblPrioridade.Text = ConverteEnumPrioridade(_chamado.prioridade);
            lblNomeCliente.Text = _chamado.cliente.nome;
            lblNomeFuncionario.Text = _chamado.funcionario.nome;
            lblDescricaoDoChamado.Text = _chamado.descricao;
            lblJornada.Text = _chamado.jornada.jornada;
            lblModulo.Text = _chamado.modulo.modulo;
        }

        private async void FormDetalhesChamado_Load(object sender, EventArgs e)
        {
            timerAtualizaDados.Enabled = true;
            // Variável para controlar quando disparar o evento de SelectedIndexChanged das Combobox
            carregandoComboBox = true;

            if (_usuarioLogado.TipoUsuario == TipoUsuario.CLIENTE)
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
                List<ListagemFuncionariosDTO> listaFunc = await _chamadoService.CarregaNomeFuncionarios();
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
                        idChamado = _chamado.idChamado,
                        idUsuario = idFuncionarioSelecionado
                    };

                    this._chamado = await _chamadoService.AtualizaChamado(dadosParaAtualizarChamado);
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

                    dadosParaAtualizarChamado.idChamado = _chamado.idChamado;
                    dadosParaAtualizarChamado.status = (StatusChamado)cbxStatus.SelectedIndex - 1;

                    this._chamado = await _chamadoService.AtualizaChamado(dadosParaAtualizarChamado);
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

                    dadosParaAtualizarChamado.idChamado = _chamado.idChamado;
                    dadosParaAtualizarChamado.prioridade = (PrioridadeChamado)cbxPrioridade.SelectedIndex - 1;

                    this._chamado = await _chamadoService.AtualizaChamado(dadosParaAtualizarChamado);

                    lblPrioridade.Text = ConverteEnumPrioridade(_chamado.prioridade);
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
                        idChamado = _chamado.idChamado,
                        idJornada = cbxJornada.SelectedIndex
                    };

                    this._chamado = await _chamadoService.AtualizaChamado(dadosParaAtualizarNoChamado);
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
                        idChamado = _chamado.idChamado,
                        idModulo = cbxModulo.SelectedIndex
                    };

                    this._chamado = await _chamadoService.AtualizaChamado(dadosParaAtualizarChamado);

                    lblModulo.Text = this._chamado.modulo.modulo;
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
                        idChamado = this._chamado.idChamado,
                        idRemetente = this._usuarioLogado.idUsuario,
                        mensagem = txtMensagem.Text
                    };

                    await _conversaService.EnviarMensagem(mensagemASerEnviada);
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
                idChamado = this._chamado.idChamado,
                idUltimaConversa = this.idUltimaMensagem
            };

            listaMensagens = await _conversaService.BuscarConversa(buscarMensagemDTO);

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
                this._chamado = await _chamadoService.BuscaChamadoPorId(this._chamado.idChamado);
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.formAcompanharChamados.flpPanelCardsChamados.Controls.Clear();
            this.formAcompanharChamados.CarregaChamados();
            this.formAcompanharChamados.ExibirCards();
        }

        private void ExibeMensagens(ConversaDTO mensagem)
        {
            Panel mensagemNoPanel = new Panel()
            {
                BackColor = _modoDaltonico ? Color.FromArgb(171, 126, 105) : Color.FromArgb(167, 112, 197),
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

        private Color FundoStatus(StatusChamado status, bool modoDaltonico)
        {
            if (status == StatusChamado.ABERTO) return Color.FromArgb(211, 211, 211);
            if (status == StatusChamado.EM_ANDAMENTO) return modoDaltonico ? Color.FromArgb(235, 181, 102) : Color.FromArgb(236, 169, 44);
            if (status == StatusChamado.PENDENTE) return modoDaltonico ? Color.FromArgb(77, 138, 195) : Color.FromArgb(76, 143, 197);
            if (status == StatusChamado.RESOLVIDO) return modoDaltonico ? Color.FromArgb(93, 162, 176) : Color.FromArgb(67, 180, 128);
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

        private void ModoDaltonismo()
        {
            if (_modoDaltonico)
            {
                pbIconPrioridade.Image = Interfaces.Properties.Resources.IconPrioridadeDaltonico;
                pbIconDescricao.Image = Interfaces.Properties.Resources.IconsDocumentoDaltonico;
                pbIconJornada.Image = Interfaces.Properties.Resources.IconMarcadorDaltonico;
                pbIconModulo.Image = Interfaces.Properties.Resources.IconEngrenagemDaltonico;
                pbIconEnviarMensagem.Image = Interfaces.Properties.Resources.IconEnviarDaltonico;
            }
            else
            {
                pbIconPrioridade.Image = Interfaces.Properties.Resources.icons8_alta_prioridade_48;
                pbIconDescricao.Image = Interfaces.Properties.Resources.icons8_documento_48;
                pbIconJornada.Image = Interfaces.Properties.Resources.icons8_marcador_48;
                pbIconModulo.Image = Interfaces.Properties.Resources.icons8_configurações_48;
                pbIconEnviarMensagem.Image = Interfaces.Properties.Resources.IconEnviar;
            }
        }
    }
}
