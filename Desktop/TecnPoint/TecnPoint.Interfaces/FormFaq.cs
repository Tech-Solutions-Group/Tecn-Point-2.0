using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TecnPoint.Interfaces
{
    public partial class FormFaq : Form
    {
        private FrmMDIPrincipal frmMDIPrincipal;
        private bool _modoDaltonico;

        public FormFaq(FrmMDIPrincipal frmMDIPrincipal, bool modoDaltonico)
        {
            this.frmMDIPrincipal = frmMDIPrincipal;
            this._modoDaltonico = modoDaltonico;
            InitializeComponent();
            ModoDaltonico();
        }

        private void ModoDaltonico()
        {
            if (_modoDaltonico)
            {
                lblDuvidas.ForeColor = Color.FromArgb(171, 126, 105);
            }
            else
            {
                lblDuvidas.ForeColor = Color.FromArgb(126, 105, 171);
            }
        }

        private void CentralizarControlesFaq()
        {
            // Calcula o tamanho total vertical de todos os painéis e labels principais
            int espacamentoVertical = 15;
            int alturaTotal =
                lblDuvidas.Height +
                lblFrequentes.Height +
                pnlPergunta1.Height +
                panel1.Height +
                pnlPergunta3.Height +
                panel2.Height +
                (espacamentoVertical * 6);

            // Calcula a posição inicial vertical (para centralizar na altura da tela)
            int topoInicial = (this.ClientSize.Height - alturaTotal) / 2;
            int centroHorizontal = this.ClientSize.Width / 2;

            // Centraliza os títulos
            lblDuvidas.Left = centroHorizontal - (lblDuvidas.Width + lblFrequentes.Width + 10) / 2;
            lblFrequentes.Left = lblDuvidas.Right + 10;

            lblDuvidas.Top = topoInicial;
            lblFrequentes.Top = topoInicial;

            // Posiciona os painéis abaixo dos títulos
            int posicaoAtual = lblFrequentes.Bottom + espacamentoVertical;

            foreach (var painel in new[] { pnlPergunta1, panel1, pnlPergunta3, panel2 })
            {
                painel.Left = (this.ClientSize.Width - painel.Width) / 2;
                painel.Top = posicaoAtual;
                posicaoAtual += painel.Height + espacamentoVertical;
            }
        }

        private void FormFaq_Load(object sender, EventArgs e)
        {
            CentralizarControlesFaq();
        }

        private void FormFaq_Resize(object sender, EventArgs e)
        {
            CentralizarControlesFaq();
        }
    }
}
