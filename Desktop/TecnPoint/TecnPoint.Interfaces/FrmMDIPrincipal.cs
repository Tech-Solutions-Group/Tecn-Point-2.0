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
    public partial class FrmMDIPrincipal : Form
    {
        private int childFormNumber = 0;
        private Usuario usuarioLogado;

        public FrmMDIPrincipal(Usuario usuarioLogado)
        {
            InitializeComponent();
            this.usuarioLogado = usuarioLogado;
            AlterarVisualizacao();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void AlterarVisualizacao()
        {
            if(usuarioLogado.TipoUsuario == "CLIENTE")
            {
                tspGerenciarUsuarios.Visible = false;
            }
        }
    }
}
