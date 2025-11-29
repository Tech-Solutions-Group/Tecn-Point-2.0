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

namespace TecnPoint.Interfaces
{
    public partial class FrmMDIPrincipal : Form
    {
        private readonly bool _modoDaltonico;
        private int childFormNumber = 0;
        private UsuarioLogadoDTO _usuarioLogado;

        public FrmMDIPrincipal(UsuarioLogadoDTO usuarioLogado, bool modoDaltonico)
        {
            InitializeComponent();
            this._modoDaltonico = modoDaltonico;
            this._usuarioLogado = usuarioLogado;
            CarregaFormLogo();
            ModoDaltonismo();
            AlterarVisualizacao();
        }

        private void AlterarVisualizacao()
        {
            if (_usuarioLogado.tipoUsuario == Modelos.Enum.TipoUsuario.CLIENTE)
            {
                tspGerenciarUsuarios.Enabled = false;
                tspGerenciarUsuarios.Visible = false;
                tspCadastrarUsuario.Enabled = false;
                tspCadastrarUsuario.Visible = false;
                tspEditarUsuario.Enabled = false;
                tspEditarUsuario.Visible = false;
            }

            if (_usuarioLogado.tipoUsuario == Modelos.Enum.TipoUsuario.FUNCIONARIO)
            {
                tspAbrirChamado.Visible = false;
                tspAbrirChamado.Enabled = false;
                tspChatBot.Enabled = false;
                tspChatBot.Visible = false;
                tspFaq.Enabled = false;
                tspFaq.Visible = false;
            }
        }

        public void tspAbrirChamado_Click(object sender, EventArgs e)
        {
            CarregaAberturaChamado();
        }

        public void CarregaAberturaChamado()
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

            FormLogo formLogo = new FormLogo(_usuarioLogado.nome, _usuarioLogado.email, _usuarioLogado.tipoUsuario, _modoDaltonico);

            formLogo.MdiParent = this;

            formLogo.Dock = DockStyle.Fill;

            formLogo.Show();
        }

        private void tspAcompanharChamado_Click(object sender, EventArgs e)
        {
            CarregaAcompanharChamado();
        }

        public void CarregaAcompanharChamado()
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
            CarregaListaUsuario();
        }

        public void CarregaListaUsuario()
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

        private void tspFaq_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            FormFaq faq = new FormFaq(this, _modoDaltonico);

            faq.MdiParent = this;

            faq.Dock = DockStyle.Fill;

            faq.Show();
        }
    }
}
