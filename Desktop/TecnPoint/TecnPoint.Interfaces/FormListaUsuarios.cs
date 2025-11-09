using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnPoint.Modelos;
using TecnPoint.Modelos.DTO;
using TecnPoint.Modelos.Enum;
using TecnPoint.Services;

namespace TecnPoint.Interfaces
{
    public partial class FormListaUsuarios : Form
    {
        private UsuarioService _usuarioService;
        private bool _modoDaltonico;
        private FrmMDIPrincipal frmMDIPrincipal;
        public FormListaUsuarios(bool modoDaltonico, FrmMDIPrincipal frmMDIPrincipal)
        {
            this._usuarioService = new UsuarioService();
            this._modoDaltonico = modoDaltonico;
            this.frmMDIPrincipal = frmMDIPrincipal;
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

                CentralizarControles();

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
            AbreFormDeEdicao();
        }

        private void AbreFormDeEdicao()
        {
            // Criar o formulário de edição
            FormEditarUsuario formEditarUsuario = new FormEditarUsuario(
                RecuperaDadosUsuarioSelecionado(),
                _modoDaltonico,
                frmMDIPrincipal
            );
            formEditarUsuario.TopLevel = false;
            formEditarUsuario.Dock = DockStyle.Fill;

            // Adicionar ao painel
            this.Controls.Add(formEditarUsuario);

            // Ocultar os controles da lista
            dgvUsuarios.Visible = false;
            btnVoltar.Visible = false;
            pbInformacaoEditar.Visible = false;
            lblInfoEditar.Visible = false;

            // Mostrar o formulário
            formEditarUsuario.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMDIPrincipal.CarregaFormLogo();
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
            var colunaAcoes = (DataGridViewImageColumn)dgvUsuarios.Columns["Editar"];
            if (_modoDaltonico)
            {
                Color cabecalho = Color.FromArgb(93, 162, 176);     // Adaptação do roxo (146,76,211)
                Color selecao = Color.FromArgb(148, 115, 189);      // Adaptação do roxo claro (168,124,209)
                Color fundo = Color.White;
                Color texto = SystemColors.ControlText;

                dgvUsuarios.BackgroundColor = fundo;
                dgvUsuarios.ForeColor = texto;
                dgvUsuarios.DefaultCellStyle.SelectionBackColor = selecao;
                dgvUsuarios.DefaultCellStyle.SelectionForeColor = SystemColors.ControlLightLight;

                dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = cabecalho;
                dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlLightLight;

                btnVoltar.FlatAppearance.MouseDownBackColor = Color.FromArgb(254, 190, 137);
                btnVoltar.FlatAppearance.MouseOverBackColor = Color.FromArgb(253, 163, 89);

                pbInformacaoEditar.Image = Interfaces.Properties.Resources.logoInfoDaltonico;

                colunaAcoes.Image = Interfaces.Properties.Resources.IconEditarDaltonico;
            }
            else
            {
                // Cores normais
                Color cabecalho = Color.FromArgb(146, 76, 211);
                Color selecao = Color.FromArgb(168, 124, 209);
                Color fundo = Color.White;

                dgvUsuarios.BackgroundColor = fundo;
                dgvUsuarios.ForeColor = SystemColors.ControlText;
                dgvUsuarios.DefaultCellStyle.SelectionBackColor = selecao;
                dgvUsuarios.DefaultCellStyle.SelectionForeColor = SystemColors.ControlLightLight;

                dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = cabecalho;
                dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlLightLight;

                btnVoltar.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 137, 254);
                btnVoltar.FlatAppearance.MouseOverBackColor = Color.FromArgb(163, 89, 253);

                pbInformacaoEditar.Image = Interfaces.Properties.Resources.icons8_informações_48;

                colunaAcoes.Image = Interfaces.Properties.Resources.icons8_crie_um_novo_48;
            }
            dgvUsuarios.EnableHeadersVisualStyles = false;
        }

        private void CentralizarControles()
        {
            if (this.ClientSize.Width == 0 || this.ClientSize.Height == 0) return;

            int larguraForm = this.ClientSize.Width;
            int alturaForm = this.ClientSize.Height;
            int margem = 40;

            // Calcular tamanho do DataGridView (ocupará a maior parte do formulário)
            int larguraDataGrid = larguraForm - (margem * 2);
            int alturaDataGrid = alturaForm - 150; // Deixar espaço para botão e informações

            // Centralizar horizontalmente
            int posXCentral = margem;

            // Ícone de informação e label no topo
            pbInformacaoEditar.Left = posXCentral;
            pbInformacaoEditar.Top = margem - 10;

            lblInfoEditar.Left = pbInformacaoEditar.Right + 5;
            lblInfoEditar.Top = pbInformacaoEditar.Top + 4;

            // DataGridView centralizado
            dgvUsuarios.Left = posXCentral;
            dgvUsuarios.Top = pbInformacaoEditar.Bottom + 10;
            dgvUsuarios.Width = larguraDataGrid;
            dgvUsuarios.Height = alturaDataGrid;

            // Botão Voltar abaixo do DataGridView
            btnVoltar.Left = posXCentral;
            btnVoltar.Top = dgvUsuarios.Bottom + 10;
        }

        private void flpEditarUsuario_Resize(object sender, EventArgs e)
        {
        }

        private void FormListaUsuarios_Resize(object sender, EventArgs e)
        {
            CentralizarControles();
        }

        private void dgvUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            // Pressionar Enter para editar o usuário selecionado
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Impede o comportamento padrão do Enter

                if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.Index >= 0)
                {
                    // Simular o clique na célula atual
                    AbreFormDeEdicao();
                }
            }
        }
    }
}
