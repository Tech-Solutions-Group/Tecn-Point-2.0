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
            CarregaChamadosAPI();
        }

        public async void CarregaChamadosAPI()
        {
            var listaChamados = await chamadoService.BuscarChamadosCliente(usuarioLogado.id_usuario);

            foreach (var chamado in listaChamados)
            {
                Panel card = new Panel
                {
                    Size = new Size(600, 100),
                    Font = new Font("Consolas", 11, FontStyle.Bold),
                    BackColor = Color.FromArgb(160, 83, 232),


                    Cursor = Cursors.Hand,

                };

                Label lblTitulo = new Label { Text = $"{chamado.titulo}", Location = new Point(10, 20), AutoSize = false, Size = new Size(250, 40), ForeColor = Color.White };
                Label lblCliente = new Label { Text = $"Criado por: {chamado.cliente.nome}", Location = new Point(10, 70), AutoSize = true, ForeColor = Color.White };
                Label lblFuncionario = new Label { Text = $"Atribuído: {chamado.funcionario.nome}", Location = new Point(375, 70), AutoSize = true, ForeColor = Color.White };
                Label lblStatus = new Label { Text = $"Status: {chamado.status}", Location = new Point(375, 20), AutoSize = true, ForeColor = Color.White, BackColor = FundoStatus(chamado.status) };

                card.Controls.Add(lblTitulo);
                card.Controls.Add(lblCliente);
                card.Controls.Add(lblFuncionario);
                card.Controls.Add(lblStatus);

                card.Tag = chamado;

                int marginHorizontal = (flpPanelCardsChamados.ClientSize.Width - card.Width) / 2;
                card.Margin = new Padding(marginHorizontal, 2, 0, 12);

                flpPanelCardsChamados.Controls.Add(card);
                flpPanelCardsChamados.Controls.SetChildIndex(card, 0);
            }
        }

        private Color FundoStatus(StatusChamado status)
        {
            if(status == StatusChamado.ABERTO)
            {
                return Color.Red;
            }
            return Color.Green;
        }
    }
}
