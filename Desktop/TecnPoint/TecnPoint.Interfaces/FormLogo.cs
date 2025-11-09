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

        }
    }
}
