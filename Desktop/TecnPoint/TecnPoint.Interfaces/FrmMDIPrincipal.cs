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
        private readonly bool _modoDaltonico;
        private int childFormNumber = 0;
        private Usuario _usuarioLogado;

        public FrmMDIPrincipal(Usuario usuarioLogado, bool modoDaltonico)
        {
            InitializeComponent();
            this._modoDaltonico = modoDaltonico;
            this._usuarioLogado = usuarioLogado;
            CarregaFormLogo();
            ModoDaltonismo();
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
            if (_usuarioLogado.TipoUsuario == Modelos.Enum.TipoUsuario.CLIENTE)
            {
                tspGerenciarUsuarios.Visible = false;
            }

            if (_usuarioLogado.TipoUsuario == Modelos.Enum.TipoUsuario.FUNCIONARIO)
            {
                tspAbrirChamado.Visible = false;
                tspChatBot.Visible = false;
            }
        }

        public void tspAbrirChamado_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            FormAberturaChamado formAberturaChamado = new FormAberturaChamado(_usuarioLogado, this, _modoDaltonico);

            formAberturaChamado.MdiParent = this;

            formAberturaChamado.Dock = DockStyle.Fill;

            formAberturaChamado.Show();
        }

        public void CarregaFormLogo()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            FormLogo formLogo = new FormLogo(_usuarioLogado.Nome, _usuarioLogado.Email, _usuarioLogado.TipoUsuario, _modoDaltonico);

            formLogo.MdiParent = this;

            formLogo.Dock = DockStyle.Fill;

            formLogo.Show();
        }

        private void tspAcompanharChamado_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            FormAcompanharChamados formAcompanharChamados = new FormAcompanharChamados(_usuarioLogado, this, _modoDaltonico);

            formAcompanharChamados.MdiParent = this;

            formAcompanharChamados.Dock = DockStyle.Fill;

            formAcompanharChamados.Show();
        }

        private void tspCadastrarUsuario_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            FormCadastrarUsuario formCadastrarUsuario = new FormCadastrarUsuario(this, _modoDaltonico);

            formCadastrarUsuario.MdiParent = this;

            formCadastrarUsuario.Dock = DockStyle.Fill;

            formCadastrarUsuario.Show();
        }

        private void tspEditarUsuario_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            FormListaUsuarios formListaUsuarios = new FormListaUsuarios(_modoDaltonico, this);

            formListaUsuarios.MdiParent = this;

            formListaUsuarios.Dock = DockStyle.Fill;

            formListaUsuarios.Show();
        }

        private void FrmMDIPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLogin telaLogin = new FormLogin();
            telaLogin.DefinirModoDaltonico(_modoDaltonico);
            telaLogin.Show();
        }

        private void ModoDaltonismo()
        {
            if (_modoDaltonico)
            {
                this.menuStrip.BackgroundImage = Interfaces.Properties.Resources.TelaInicioDaltonico;
            }
            else
            {
                this.menuStrip.BackgroundImage = Interfaces.Properties.Resources.TelaFundo;
            }
        }

        private void tspChatBot_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            FormChatBot formChatBot = new FormChatBot(_modoDaltonico, this, _usuarioLogado);

            formChatBot.MdiParent = this;

            formChatBot.Dock = DockStyle.Fill;

            formChatBot.Show();
        }
    }
}
