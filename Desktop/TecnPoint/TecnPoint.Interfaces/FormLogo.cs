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

namespace TecnPoint.Interfaces
{
    public partial class FormLogo : Form
    {
        public FormLogo(string nomeUsuario, string emailUsuario, TipoUsuario tipoUsuario)
        {
            InitializeComponent();
            this.lblNomeFrmLogo.Text = nomeUsuario;
            this.lblEmailFrmLogo.Text = emailUsuario;
            this.lblTipoUsuarioFrmLogo.Text = tipoUsuario.ToString();
        }
    }
}
