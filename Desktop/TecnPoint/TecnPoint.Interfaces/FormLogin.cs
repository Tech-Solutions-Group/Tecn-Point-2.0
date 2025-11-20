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
using TecnPoint.Services;

namespace TecnPoint.Interfaces
{
    public partial class FormLogin : Form
    {
        private UsuarioService _usuarioService;

        public FormLogin()
        {
            _usuarioService = new UsuarioService();
            InitializeComponent();
        }

        public void DefinirModoDaltonico(bool modoDaltonico)
        {
            chcbModoDaltonico.Checked = modoDaltonico;
        }

        public bool ModoDaltonicoAtivo => chcbModoDaltonico.Checked;

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaLogin(tbxEmail.Text, tbxSenha.Text);

                UsuarioLogadoDTO usuarioRetornado = await _usuarioService.RealizarLogin(new LoginUsuarioDTO(tbxEmail.Text.ToLower(), tbxSenha.Text));

                Usuario usuarioLogado = new Usuario
                {
                    idUsuario = usuarioRetornado.idUsuario,
                    Nome = usuarioRetornado.nome,
                    Email = usuarioRetornado.email,
                    TipoUsuario = usuarioRetornado.tipoUsuario,
                };

                MessageBox.Show("Login efetuado com sucesso!",
                                "TechSolutions",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                if (usuarioLogado != null)
                {
                    FrmMDIPrincipal frmMDIPrincipal = new FrmMDIPrincipal(usuarioLogado, ModoDaltonicoAtivo);
                    frmMDIPrincipal.Show();
                    this.Hide();
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message,
                                "TechSolutions",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "TechSolutions",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void ValidaLogin(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("O e-mail deve ser informado!");
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("A senha deve ser informada!");
        }

        private void AtivarModoDaltonico()
        {
            this.BackgroundImage = Interfaces.Properties.Resources.TelaInicioDaltonico;

            btnEntrar.BackColor = Color.FromArgb(171, 126, 105);
        }

        private void DesativarModoDaltonico()
        {
            this.BackgroundImage = Interfaces.Properties.Resources.TelaFundoLogin;

            btnEntrar.BackColor = Color.FromArgb(126, 105, 171);
        }

        private void chcbModoDaltonico_CheckedChanged(object sender, EventArgs e)
        {
            if (chcbModoDaltonico.Checked)
            {
                AtivarModoDaltonico();
            }
            else
            {
                DesativarModoDaltonico();
            }
        }
    }
}
