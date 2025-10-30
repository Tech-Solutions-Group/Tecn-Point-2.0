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
        UsuarioService _usuarioService;

        public FormLogin()
        {
            _usuarioService = new UsuarioService();
            InitializeComponent();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidaLogin(tbxEmail.Text, tbxSenha.Text);

                LoginUsuarioDTO loginUsuarioDTO = new LoginUsuarioDTO(tbxEmail.Text.ToLower(), tbxSenha.Text);

                Usuario usuarioLogado = await _usuarioService.RealizarLogin(loginUsuarioDTO);

                MessageBox.Show($"Login efetuado com sucesso!\n{usuarioLogado}",
                                "TechSolutions",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                if(usuarioLogado != null)
                {
                    FrmMDIPrincipal frmMDIPrincipal = new FrmMDIPrincipal(usuarioLogado);
                    frmMDIPrincipal.Show();
                    this.Hide();
                }

            }catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message,     
                                "TechSolutions",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "TechSolutions",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }


        }

        private void ValidaLogin(string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("O e-mail deve ser informado!");
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException("A senha deve ser informada!");
        }
    }
}
