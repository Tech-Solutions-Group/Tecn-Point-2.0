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
using TecnPoint.Modelos.Enum;
using TecnPoint.Services;

namespace TecnPoint.Interfaces
{
    public partial class FormListaUsuarios : Form
    {
        private UsuarioService _usuarioService;
        private bool _modoDaltonico;
        public FormListaUsuarios(bool modoDaltonico)
        {
            this._usuarioService = new UsuarioService();
            this._modoDaltonico = modoDaltonico;
            InitializeComponent();
            ModoDaltonico();
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
            if (lblInfoEditar.Visible == false)
            {
                lblInfoEditar.Visible = true;
            }
            else
            {
                lblInfoEditar.Visible = false;
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormEditarUsuario formEditarUsuario = new FormEditarUsuario(RecuperaDadosUsuarioSelecionado());
            formEditarUsuario.TopLevel = false;

            flpEditarUsuario.Controls.Clear();
            flpEditarUsuario.Controls.Add(formEditarUsuario);
            formEditarUsuario.Show();
            flpEditarUsuario.Visible = true;
            flpEditarUsuario.BringToFront();
        }

        private EditarUsuarioDTO RecuperaDadosUsuarioSelecionado()
        {
            long idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["idUsuario"].Value);
            string nomeUsuario = dgvUsuarios.CurrentRow.Cells["nome"].Value.ToString();
            string emailUsuario = dgvUsuarios.CurrentRow.Cells["email"].Value.ToString();
            string senhaUsuario = dgvUsuarios.CurrentRow.Cells["senha"].Value.ToString();

            EditarUsuarioDTO usuarioSelecionado = new EditarUsuarioDTO
            {
                idUsuario = idUsuario,
                nome = nomeUsuario,
                email = emailUsuario,
                senha = senhaUsuario
            };

            return usuarioSelecionado;
        }

        private void ModoDaltonico()
        {
            if (_modoDaltonico)
            {
                // 🌈 Cores ajustadas para Deuteranopia
                dgvUsuarios.BackgroundColor = Color.FromArgb(93, 162, 176);        // Versão adaptada do fundo roxo original (146,76,211)
                dgvUsuarios.ForeColor = SystemColors.ControlLightLight;

                dgvUsuarios.DefaultCellStyle.BackColor = Color.FromArgb(93, 162, 176);
                dgvUsuarios.DefaultCellStyle.ForeColor = SystemColors.ControlLightLight;
                dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(148, 115, 189);  // Roxo adaptado (167,112,197)
                dgvUsuarios.DefaultCellStyle.SelectionForeColor = SystemColors.ControlLightLight;

                dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(77, 138, 195);  // Azul mais neutro
                dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlLightLight;
            }
            else
            {
                // 🎨 Cores originais do modo normal
                dgvUsuarios.BackgroundColor = Color.FromArgb(146, 76, 211);
                dgvUsuarios.ForeColor = SystemColors.ControlLightLight;

                dgvUsuarios.DefaultCellStyle.BackColor = Color.FromArgb(146, 76, 211);
                dgvUsuarios.DefaultCellStyle.ForeColor = SystemColors.ControlLightLight;
                dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 124, 209);
                dgvUsuarios.DefaultCellStyle.SelectionForeColor = SystemColors.ControlLightLight;

                dgvUsuarios .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(146, 76, 211);
                dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlLightLight;
            }

            // Garante que os estilos personalizados sejam aplicados
            dgvUsuarios.EnableHeadersVisualStyles = false;
        }
    }
}
