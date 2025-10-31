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

        public FormDetalhesChamado(ChamadoDTO chamadoSelecionado, Usuario usuarioLogado, FormAcompanharChamados formAcompanharChamado)
        {
            this.usuarioLogado = usuarioLogado;
            this.chamado = chamadoSelecionado;
            this.formAcompanharChamados = formAcompanharChamado;
            this.chamadoService = new ChamadoService();
            InitializeComponent();
        }

        private void FormDetalhesChamado_Load(object sender, EventArgs e)
        {
            PreencherDetalhes();
            CarregaNomeCbxFuncionarios(cbxNomeFuncionario);
        }

        private void PreencherDetalhes()
        {
            lblTitulo.Text = chamado.titulo;
            lblStatus.Text = chamado.status.ToString();
            lblStatus.BackColor = FundoStatus(chamado.status);
            lblPrioridade.Text = chamado.prioridade.ToString();
            lblNomeCliente.Text = chamado.cliente.nome;
            lblNomeFuncionario.Text = chamado.funcionario.nome;
            lblDescricaoDoChamado.Text = chamado.descricao;
            lblJornada.Text = chamado.jornada.jornada;
            lblModulo.Text = chamado.modulo.modulo;

            if (usuarioLogado.tipoUsuario == TipoUsuario.CLIENTE)
            {
                cbxStatus.Visible = false;
                cbxPrioridade.Visible = false;
                cbxNomeFuncionario.Visible = false;
            }
        }

        private Color FundoStatus(StatusChamado status)
        {
            if (status == StatusChamado.ABERTO)
            {
                return Color.FromArgb(67, 180, 128);
            }

            if (status == StatusChamado.EM_ANDAMENTO)
            {
                return Color.FromArgb(236, 169, 44);
            }

            if (status == StatusChamado.PENDENTE)
            {
                return Color.FromArgb(76, 143, 197);
            }

            if (status == StatusChamado.RESOLVIDO)
            {
                return Color.FromArgb(211, 211, 211);
            }
            return Color.Gray;
        }

        private void btnVoltarDetalhesChamado_Click(object sender, EventArgs e)
        {
            formAcompanharChamados.flpPanelCardsChamados.Controls.Clear();
            formAcompanharChamados.CarregaChamados();
            formAcompanharChamados.ExibirCards();
        }

        private async void CarregaNomeCbxFuncionarios(ComboBox comboBox)
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
                MessageBox.Show("Não foi possível carregar os funcionário do sistema\n" + ex.Message,
                                       "TechSolutions",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
            }

        }

        private void lblNomeCliente_Click(object sender, EventArgs e)
        {

        }

        private void cbxPrioridade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblDescricao_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private async void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaChamadoDTO dadosParaAtualizarNoChamado = new AtualizaChamadoDTO();
            dadosParaAtualizarNoChamado.status = (StatusChamado) cbxStatus.SelectedIndex;
            await chamadoService.AtualizaChamado(dadosParaAtualizarNoChamado);
        }
        /*
        private AtualizaChamadoDTO InstanciaAtualizaChamadoDTO()
        {
            //return new AtualizaChamadoDTO(chamado)
        }*/
    }
}
