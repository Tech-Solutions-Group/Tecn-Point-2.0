using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnPoint.Modelos.DTO;
using TecnPoint.Services;

namespace TecnPoint.Interfaces
{
    public partial class FormListaUsuarios : Form
    {
        private UsuarioService _usuarioService;
        public FormListaUsuarios()
        {
            this._usuarioService = new UsuarioService();
            InitializeComponent();
        }

        private async void FormListaUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                List<ListagemUsuarioDTO> listaUsuarios = await _usuarioService.BuscarUsuarios();

                dgvUsuarios.DataSource = listaUsuarios;

                dgvUsuarios.Columns["idUsuario"].Visible = false;
                dgvUsuarios.Columns["senha"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os funcionários do sistema\n" + ex.Message,
                                       "TechSolutions",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
            }

        }

        private void pbInformacaoEditar_Click(object sender, EventArgs e)
        {
            if(lblInfoEditar.Visible == false)
            {
                lblInfoEditar.Visible = true;
            }
            else
            {
                lblInfoEditar.Visible = false;
            }
        }
    }
}
