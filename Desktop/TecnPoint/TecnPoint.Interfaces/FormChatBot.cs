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

namespace TecnPoint.Interfaces
{
    public partial class FormChatBot : Form
    {
        private FrmMDIPrincipal frmMDIPrincipal;
        private Usuario _usuarioLogado;
        private bool _modoDaltonico;

        public FormChatBot(FrmMDIPrincipal frmMDIPrincipal, Usuario usuarioLogado, bool modoDaltonico)
        {
            this.frmMDIPrincipal = frmMDIPrincipal;
            this._usuarioLogado = usuarioLogado;
            this._modoDaltonico = modoDaltonico;
            InitializeComponent();
        }
    }
}
