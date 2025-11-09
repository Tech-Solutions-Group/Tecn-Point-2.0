using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnPoint.Modelos.Enum;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TecnPoint.Interfaces
{
    public partial class FormLogo : Form
    {
        private readonly bool _modoDaltonico;

        public FormLogo(string nomeUsuario, string emailUsuario, TipoUsuario tipoUsuario, bool modoDaltonico)
        {
            InitializeComponent();
            this._modoDaltonico = modoDaltonico;
            this.lblNomeFrmLogo.Text = nomeUsuario;
            this.lblEmailFrmLogo.Text = emailUsuario;
            this.lblTipoUsuarioFrmLogo.Text = tipoUsuario == Modelos.Enum.TipoUsuario.CLIENTE ? "Cliente" : "Funcionário";
            ModoDaltonismo();
        }

        private void ModoDaltonismo()
        {
            if (_modoDaltonico)
            {
                this.BackgroundImage = Interfaces.Properties.Resources.ImagemLogo_Daltonico;
            }
            else
            {
                this.BackgroundImage = Interfaces.Properties.Resources.ImagemFundoForm21;
            }
        }

        private void FormLogo_Resize(object sender, EventArgs e)
        {
            CentralizarControles();
        }

        private void CentralizarControles()
        {
            // Centraliza o PictureBox horizontalmente
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;

            // Centraliza as labels horizontalmente
            lblTipoUsuarioFrmLogo.Left = (this.ClientSize.Width - lblTipoUsuarioFrmLogo.Width) / 2;
            lblNomeFrmLogo.Left = (this.ClientSize.Width - lblNomeFrmLogo.Width) / 2;
            lblEmailFrmLogo.Left = (this.ClientSize.Width - lblEmailFrmLogo.Width) / 2;

            // Opcional: Ajustar posição vertical para manter proporção
            int alturaTotal = pictureBox1.Height + lblTipoUsuarioFrmLogo.Height +
                              lblNomeFrmLogo.Height + lblEmailFrmLogo.Height + 60; // 60 = espaçamentos

            int topoInicial = (this.ClientSize.Height - alturaTotal) / 2;

            pictureBox1.Top = topoInicial;
            lblTipoUsuarioFrmLogo.Top = pictureBox1.Bottom + 10;
            lblNomeFrmLogo.Top = lblTipoUsuarioFrmLogo.Bottom + 15;
            lblEmailFrmLogo.Top = lblNomeFrmLogo.Bottom + 15;
        }
    }    
}
