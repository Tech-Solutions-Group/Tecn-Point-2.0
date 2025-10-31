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

namespace TecnPoint.Interfaces
{
    public partial class FormAcompanharChamados : Form
    {
        private Usuario usuarioLogado;
        private ChamadoService chamadoService;

        public FormAcompanharChamados(Usuario usuarioLogado, FrmMDIPrincipal frmMDIPrincipal)
        {
            this.usuarioLogado = usuarioLogado;
            this.chamadoService = new ChamadoService();
            InitializeComponent();
            CarregaChamados();
        }

        public async void CarregaChamados()
        {
            try
            {
                var listaChamados = await chamadoService.BuscarChamados(usuarioLogado.id_usuario, usuarioLogado.tipoUsuario);

                foreach (var chamado in listaChamados)
                {
                    Panel card = new Panel
                    {
                        Size = new Size(600, 100),
                        Font = new Font("Consolas", 11, FontStyle.Bold),
                        BackColor = Color.FromArgb(160, 83, 232),
                        Cursor = Cursors.Hand
                    };

                    Label lblTitulo = new Label { Text = $"{chamado.titulo}", Location = new Point(10, 20), AutoSize = false, Size = new Size(250, 40) };
                    Label lblCliente = new Label { Text = $"Criado por: {chamado.cliente.nome}", Location = new Point(10, 70), AutoSize = true };
                    Label lblFuncionario = new Label { Text = $"Atribuído: {chamado.funcionario.nome}", Location = new Point(375, 70), AutoSize = true };
                    Label lblStatus = new Label { Text = $"Status: {chamado.status}", Location = new Point(375, 20), AutoSize = true, BackColor = FundoStatus(chamado.status) };

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
                        Usuario usuarioParam = new Usuario();
                        usuarioParam = usuarioLogado;
                        panelDetalhesChamado.BringToFront();

                        FormDetalhesChamado detalhesChamado = new FormDetalhesChamado(chamadoSelecionado, usuarioParam, this);
                        detalhesChamado.TopLevel = false;

                        flpPanelCardsChamados.Controls.Clear();
                        flpPanelCardsChamados.Controls.Add(detalhesChamado);
                        detalhesChamado.Show();
                    }
                    
                    int marginHorizontal = (flpPanelCardsChamados.ClientSize.Width - card.Width) / 2;
                    card.Margin = new Padding(marginHorizontal, 2, 0, 12);

                    flpPanelCardsChamados.Controls.Add(card);
                    flpPanelCardsChamados.Controls.SetChildIndex(card, 0);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os chamados do usuário\n" + ex.Message,
                                       "TechSolutions",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
            }
            
        }

        public void ExibirCards()
        {
            flpPanelCardsChamados.BringToFront();
        }

        private Color FundoStatus(StatusChamado status)
        {
            if(status == StatusChamado.ABERTO)
            {
                return Color.FromArgb(67, 180, 128);
            }
            
            if(status == StatusChamado.EM_ANDAMENTO)
            {
                return Color.FromArgb(236, 169, 44);
            }

            if(status == StatusChamado.PENDENTE)
            {
                return Color.FromArgb(76, 143, 197);
            }

            if(status == StatusChamado.RESOLVIDO)
            {
                return Color.FromArgb(211, 211, 211);
            }
            return Color.Gray;
        }
    }
}
