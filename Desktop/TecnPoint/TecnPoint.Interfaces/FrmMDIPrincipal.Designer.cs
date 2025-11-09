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
            menuStrip = new MenuStrip();
            tspAcompanharChamado = new ToolStripMenuItem();
            tspAbrirChamado = new ToolStripMenuItem();
            tspGerenciarUsuarios = new ToolStripMenuItem();
            tspCadastrarUsuario = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tspEditarUsuario = new ToolStripMenuItem();
            tspChatBot = new ToolStripMenuItem();
            tspFaq = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.AutoSize = false;
            menuStrip.BackColor = Color.MediumOrchid;
            menuStrip.BackgroundImage = Properties.Resources.TelaFundo;
            menuStrip.Dock = DockStyle.Left;
            menuStrip.Items.AddRange(new ToolStripItem[] { tspAcompanharChamado, tspAbrirChamado, tspGerenciarUsuarios, tspChatBot, tspFaq });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(219, 645);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
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
            tspAcompanharChamado.ShortcutKeys = Keys.Alt | Keys.D1;
            tspAcompanharChamado.Size = new Size(191, 36);
            tspAcompanharChamado.Text = "Acompanhar Chamado";
            tspAcompanharChamado.TextImageRelation = TextImageRelation.Overlay;
            tspAcompanharChamado.Click += tspAcompanharChamado_Click;
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
            tspAbrirChamado.ShortcutKeys = Keys.Alt | Keys.D2;
            tspAbrirChamado.Size = new Size(191, 36);
            tspAbrirChamado.Text = "Abrir Chamado";
            tspAbrirChamado.TextImageRelation = TextImageRelation.Overlay;
            tspAbrirChamado.Click += tspAbrirChamado_Click;
            // 
            // tspGerenciarUsuarios
            // 
            tspGerenciarUsuarios.BackColor = Color.Transparent;
            tspGerenciarUsuarios.DropDownItems.AddRange(new ToolStripItem[] { tspCadastrarUsuario, toolStripSeparator1, tspEditarUsuario });
            tspGerenciarUsuarios.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            tspGerenciarUsuarios.ForeColor = SystemColors.ControlLightLight;
            tspGerenciarUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            tspGerenciarUsuarios.Margin = new Padding(10);
            tspGerenciarUsuarios.Name = "tspGerenciarUsuarios";
            tspGerenciarUsuarios.Padding = new Padding(5);
            tspGerenciarUsuarios.ShortcutKeys = Keys.Alt | Keys.D3;
            tspGerenciarUsuarios.Size = new Size(191, 36);
            tspGerenciarUsuarios.Text = "Gerenciar Usuários";
            // 
            // tspCadastrarUsuario
            // 
            tspCadastrarUsuario.BackColor = Color.Transparent;
            tspCadastrarUsuario.ForeColor = SystemColors.ControlText;
            tspCadastrarUsuario.Name = "tspCadastrarUsuario";
            tspCadastrarUsuario.ShortcutKeys = Keys.Alt | Keys.D3;
            tspCadastrarUsuario.Size = new Size(310, 26);
            tspCadastrarUsuario.Text = "Cadastrar usuário";
            tspCadastrarUsuario.Click += tspCadastrarUsuario_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(307, 6);
            // 
            // tspEditarUsuario
            // 
            tspEditarUsuario.BackColor = Color.Transparent;
            tspEditarUsuario.Name = "tspEditarUsuario";
            tspEditarUsuario.ShortcutKeys = Keys.Alt | Keys.D4;
            tspEditarUsuario.Size = new Size(310, 26);
            tspEditarUsuario.Text = "Editar usuário";
            tspEditarUsuario.Click += tspEditarUsuario_Click;
            // 
            // tspChatBot
            // 
            tspChatBot.BackColor = Color.Transparent;
            tspChatBot.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            tspChatBot.ForeColor = SystemColors.ControlLightLight;
            tspChatBot.Margin = new Padding(10);
            tspChatBot.Name = "tspChatBot";
            tspChatBot.Padding = new Padding(5, 0, 4, 0);
            tspChatBot.ShortcutKeys = Keys.Alt | Keys.D3;
            tspChatBot.Size = new Size(191, 26);
            tspChatBot.Text = "Chatbot";
            tspChatBot.Click += tspChatBot_Click;
            // 
            // tspFaq
            // 
            tspFaq.BackColor = Color.Transparent;
            tspFaq.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            tspFaq.ForeColor = SystemColors.ControlLightLight;
            tspFaq.Margin = new Padding(10);
            tspFaq.Name = "tspFaq";
            tspFaq.Padding = new Padding(5);
            tspFaq.ShortcutKeys = Keys.Alt | Keys.D4;
            tspFaq.Size = new Size(191, 36);
            tspFaq.Text = "FAQ";
            tspFaq.Click += tspFaq_Click;
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
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "FrmMDIPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tecn Point";
            WindowState = FormWindowState.Maximized;
            FormClosed += FrmMDIPrincipal_FormClosed;
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
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tspEditarUsuario;
        private ToolStripMenuItem tspChatBot;
        private ToolStripMenuItem tspFaq;
    }
}



