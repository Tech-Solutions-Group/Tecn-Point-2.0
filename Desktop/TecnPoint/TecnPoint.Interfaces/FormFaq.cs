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
    }
}
