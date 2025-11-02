namespace TecnPoint.Interfaces
{
    partial class FrmMDIPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMDIPrincipal));
            menuStrip = new MenuStrip();
            tspAbrirChamado = new ToolStripMenuItem();
            tspAcompanharChamado = new ToolStripMenuItem();
            tspGerenciarUsuarios = new ToolStripMenuItem();
            tspCadastrarUsuario = new ToolStripMenuItem();
            tspDeletarUsuario = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.AutoSize = false;
            menuStrip.BackColor = Color.MediumOrchid;
            menuStrip.BackgroundImage = (Image)resources.GetObject("menuStrip.BackgroundImage");
            menuStrip.Dock = DockStyle.Left;
            menuStrip.Items.AddRange(new ToolStripItem[] { tspAbrirChamado, tspAcompanharChamado, tspGerenciarUsuarios });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(219, 645);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // tspAbrirChamado
            // 
            tspAbrirChamado.BackColor = Color.Transparent;
            tspAbrirChamado.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            tspAbrirChamado.ForeColor = SystemColors.ControlLightLight;
            tspAbrirChamado.ImageAlign = ContentAlignment.MiddleLeft;
            tspAbrirChamado.Margin = new Padding(10);
            tspAbrirChamado.Name = "tspAbrirChamado";
            tspAbrirChamado.Padding = new Padding(5);
            tspAbrirChamado.Size = new Size(191, 36);
            tspAbrirChamado.Text = "Abrir Chamado";
            tspAbrirChamado.TextImageRelation = TextImageRelation.Overlay;
            tspAbrirChamado.Click += tspAbrirChamado_Click;
            // 
            // tspAcompanharChamado
            // 
            tspAcompanharChamado.BackColor = Color.Transparent;
            tspAcompanharChamado.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tspAcompanharChamado.ForeColor = SystemColors.ControlLightLight;
            tspAcompanharChamado.ImageAlign = ContentAlignment.MiddleLeft;
            tspAcompanharChamado.Margin = new Padding(10);
            tspAcompanharChamado.Name = "tspAcompanharChamado";
            tspAcompanharChamado.Padding = new Padding(5);
            tspAcompanharChamado.Size = new Size(191, 36);
            tspAcompanharChamado.Text = "Acompanhar Chamado";
            tspAcompanharChamado.TextImageRelation = TextImageRelation.Overlay;
            tspAcompanharChamado.Click += tspAcompanharChamado_Click;
            // 
            // tspGerenciarUsuarios
            // 
            tspGerenciarUsuarios.BackColor = Color.Transparent;
            tspGerenciarUsuarios.DropDownItems.AddRange(new ToolStripItem[] { tspCadastrarUsuario, tspDeletarUsuario });
            tspGerenciarUsuarios.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            tspGerenciarUsuarios.ForeColor = SystemColors.ControlLightLight;
            tspGerenciarUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            tspGerenciarUsuarios.Margin = new Padding(10);
            tspGerenciarUsuarios.Name = "tspGerenciarUsuarios";
            tspGerenciarUsuarios.Padding = new Padding(5);
            tspGerenciarUsuarios.Size = new Size(191, 36);
            tspGerenciarUsuarios.Text = "Gerenciar Usuários";
            // 
            // tspCadastrarUsuario
            // 
            tspCadastrarUsuario.BackColor = Color.Thistle;
            tspCadastrarUsuario.Name = "tspCadastrarUsuario";
            tspCadastrarUsuario.Size = new Size(250, 26);
            tspCadastrarUsuario.Text = "Cadastrar Usuário";
            // 
            // tspDeletarUsuario
            // 
            tspDeletarUsuario.BackColor = Color.Thistle;
            tspDeletarUsuario.Name = "tspDeletarUsuario";
            tspDeletarUsuario.Size = new Size(250, 26);
            tspDeletarUsuario.Text = "Deletar Usuário";
            // 
            // FrmMDIPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1119, 645);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmMDIPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMDIPrincipal";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem tspAbrirChamado;
        private ToolStripMenuItem tspAcompanharChamado;
        private ToolStripMenuItem tspGerenciarUsuarios;
        private ToolStripMenuItem tspCadastrarUsuario;
        private ToolStripMenuItem tspDeletarUsuario;
    }
}



