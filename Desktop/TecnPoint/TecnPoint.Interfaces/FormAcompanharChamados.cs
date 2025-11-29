using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnPoint.Modelos;
using TecnPoint.Modelos.DTO;
using TecnPoint.Modelos.Enum;
using TecnPoint.Services;

namespace TecnPoint.Interfaces
{
    public partial class FormAcompanharChamados : Form
    {
        private UsuarioLogadoDTO _usuarioLogado;
        private ChamadoService _chamadoService;
        private FrmMDIPrincipal frmMDIPrincipal;
        private readonly bool _modoDaltonico;

        public FormAcompanharChamados(UsuarioLogadoDTO usuarioLogado, FrmMDIPrincipal frmMDIPrincipal, bool modoDaltonico)
        {
            this._usuarioLogado = usuarioLogado;
            this._chamadoService = new ChamadoService();
            this.frmMDIPrincipal = frmMDIPrincipal;
            this._modoDaltonico = modoDaltonico;
            InitializeComponent();
            CarregaChamados();
        }

        private void AjustarTamanhosPaineis()
        {
            // Fazer os painéis preencherem todo o formulário
            panelDetalhesChamado.Size = this.ClientSize;
            flpPanelCardsChamados.Size = this.ClientSize;
        }

        public async void CarregaChamados()
        {
            try
            {
                var listaChamados = await _chamadoService.BuscarChamados(_usuarioLogado.idUsuario, _usuarioLogado.tipoUsuario);

                foreach (var chamado in listaChamados)
                {
                    GroupBox card = new GroupBox
                    {
                        Size = new Size(600, 100),
                        Font = new Font("Consolas", 11, FontStyle.Bold),
                        Cursor = Cursors.Hand
                    };

                    Label lblTitulo = new Label { Text = $"{chamado.titulo}", Location = new Point(10, 20), AutoSize = false, Size = new Size(250, 40) };
                    Label lblCliente = new Label { Text = $"Criado por: {chamado.cliente.nome}", Location = new Point(10, 70), AutoSize = true };
                    Label lblFuncionario = new Label { Text = $"Atribuído: {chamado.funcionario.nome}", Location = new Point(375, 70), AutoSize = true };
                    Label lblStatus = new Label { Text = $"Status: {chamado.status}", Location = new Point(375, 20), AutoSize = true, BackColor = FundoStatus(chamado.status, _modoDaltonico) };

                    card.Controls.Add(lblTitulo);
                    card.Controls.Add(lblCliente);
                    card.Controls.Add(lblFuncionario);
                    card.Controls.Add(lblStatus);

                    card.Tag = chamado;

                    card.Click += (s, e) =>
                    {
                        AbrirDetalhes((ChamadoDTO)card.Tag);
                    };

                    lblTitulo.Click += (s, e) => AbrirDetalhes(chamado);
                    lblCliente.Click += (s, e) => AbrirDetalhes(chamado);
                    lblFuncionario.Click += (s, e) => AbrirDetalhes(chamado);
                    lblStatus.Click += (s, e) => AbrirDetalhes(chamado);


                    void AbrirDetalhes(ChamadoDTO chamadoSelecionado)
                    {
                        UsuarioLogadoDTO usuarioParam = _usuarioLogado; 

                        FormDetalhesChamado detalhesChamado = new FormDetalhesChamado(chamadoSelecionado, usuarioParam, frmMDIPrincipal, _modoDaltonico); 
                        detalhesChamado.TopLevel = false; 
                        detalhesChamado.Dock = DockStyle.Fill; 

                        panelDetalhesChamado.Controls.Clear(); 
                        panelDetalhesChamado.Controls.Add(detalhesChamado); 

                        detalhesChamado.Show();
                    }

                    int marginHorizontal = (flpPanelCardsChamados.ClientSize.Width - card.Width) / 2;
                    card.Margin = new Padding(marginHorizontal, 2, 0, 12);

                    flpPanelCardsChamados.Controls.Add(card);
                    flpPanelCardsChamados.Controls.SetChildIndex(card, 0);
                }

                RecentralizarCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os chamados do usuário\n" + ex.Message,
                                       "TechSolutions",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
            }
        }

        private void RecentralizarCards()
        {
            // Recalcular as margens de todos os cards quando o formulário é redimensionado
            foreach (Control control in flpPanelCardsChamados.Controls)
            {
                if (control is GroupBox card)
                {
                    int marginHorizontal = (flpPanelCardsChamados.ClientSize.Width - card.Width) / 2;
                    card.Margin = new Padding(marginHorizontal, 2, 0, 12);
                }
            }
        }

        public void ExibirCards()
        {
            flpPanelCardsChamados.BringToFront();
            RecentralizarCards();
        }

        private Color FundoStatus(StatusChamado status, bool modoDaltonico)
        {
            if (status == StatusChamado.ABERTO) return Color.FromArgb(211, 211, 211);
            if (status == StatusChamado.EM_ANDAMENTO) return modoDaltonico ? Color.FromArgb(235, 181, 102) : Color.FromArgb(236, 169, 44);
            if (status == StatusChamado.PENDENTE) return modoDaltonico ? Color.FromArgb(77, 138, 195) : Color.FromArgb(76, 143, 197);
            if (status == StatusChamado.RESOLVIDO) return modoDaltonico ? Color.FromArgb(93, 162, 176) : Color.FromArgb(67, 180, 128);
            return Color.Gray;
        }

        private void FormAcompanharChamados_Resize(object sender, EventArgs e)
        {
            AjustarTamanhosPaineis();
        }
    }
}
