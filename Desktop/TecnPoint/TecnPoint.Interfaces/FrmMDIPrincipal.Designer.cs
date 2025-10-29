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
            toolStrip = new ToolStrip();
            newToolStripButton = new ToolStripButton();
            openToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            printToolStripButton = new ToolStripButton();
            printPreviewToolStripButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            helpToolStripButton = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
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
            menuStrip.Size = new Size(219, 523);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // tspAbrirChamado
            // 
            tspAbrirChamado.BackColor = Color.Transparent;
            tspAbrirChamado.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tspAbrirChamado.ForeColor = SystemColors.ControlText;
            tspAbrirChamado.Image = (Image)resources.GetObject("tspAbrirChamado.Image");
            tspAbrirChamado.ImageAlign = ContentAlignment.MiddleLeft;
            tspAbrirChamado.Margin = new Padding(10, 115, 10, 10);
            tspAbrirChamado.Name = "tspAbrirChamado";
            tspAbrirChamado.Padding = new Padding(5);
            tspAbrirChamado.Size = new Size(191, 32);
            tspAbrirChamado.Text = "Abrir Chamado";
            tspAbrirChamado.TextImageRelation = TextImageRelation.Overlay;
            // 
            // tspAcompanharChamado
            // 
            tspAcompanharChamado.BackColor = Color.Transparent;
            tspAcompanharChamado.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tspAcompanharChamado.Image = (Image)resources.GetObject("tspAcompanharChamado.Image");
            tspAcompanharChamado.ImageAlign = ContentAlignment.MiddleLeft;
            tspAcompanharChamado.Margin = new Padding(10);
            tspAcompanharChamado.Name = "tspAcompanharChamado";
            tspAcompanharChamado.Padding = new Padding(5);
            tspAcompanharChamado.Size = new Size(191, 32);
            tspAcompanharChamado.Text = "Acompanhar Chamado";
            tspAcompanharChamado.TextImageRelation = TextImageRelation.Overlay;
            // 
            // tspGerenciarUsuarios
            // 
            tspGerenciarUsuarios.BackColor = Color.Transparent;
            tspGerenciarUsuarios.DropDownItems.AddRange(new ToolStripItem[] { tspCadastrarUsuario, tspDeletarUsuario });
            tspGerenciarUsuarios.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tspGerenciarUsuarios.Margin = new Padding(10);
            tspGerenciarUsuarios.Name = "tspGerenciarUsuarios";
            tspGerenciarUsuarios.Padding = new Padding(5);
            tspGerenciarUsuarios.Size = new Size(191, 32);
            tspGerenciarUsuarios.Text = "Gerenciar Usuários";
            // 
            // tspCadastrarUsuario
            // 
            tspCadastrarUsuario.BackColor = Color.Thistle;
            tspCadastrarUsuario.Name = "tspCadastrarUsuario";
            tspCadastrarUsuario.Size = new Size(212, 22);
            tspCadastrarUsuario.Text = "Cadastrar Usuário";
            // 
            // tspDeletarUsuario
            // 
            tspDeletarUsuario.BackColor = Color.Thistle;
            tspDeletarUsuario.Name = "tspDeletarUsuario";
            tspDeletarUsuario.Size = new Size(212, 22);
            tspDeletarUsuario.Text = "Deletar Usuário";
            // 
            // toolStrip
            // 
            toolStrip.Dock = DockStyle.Left;
            toolStrip.Items.AddRange(new ToolStripItem[] { newToolStripButton, openToolStripButton, saveToolStripButton, toolStripSeparator1, printToolStripButton, printPreviewToolStripButton, toolStripSeparator2, helpToolStripButton, toolStripButton1 });
            toolStrip.Location = new Point(219, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(24, 523);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "ToolStrip";
            // 
            // newToolStripButton
            // 
            newToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newToolStripButton.Image = (Image)resources.GetObject("newToolStripButton.Image");
            newToolStripButton.ImageTransparentColor = Color.Black;
            newToolStripButton.Name = "newToolStripButton";
            newToolStripButton.Size = new Size(21, 20);
            newToolStripButton.Text = "Novo";
            newToolStripButton.Click += ShowNewForm;
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = Color.Black;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(21, 20);
            openToolStripButton.Text = "Abrir";
            openToolStripButton.Click += OpenFile;
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = (Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = Color.Black;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(21, 20);
            saveToolStripButton.Text = "Salvar";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(21, 6);
            // 
            // printToolStripButton
            // 
            printToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printToolStripButton.Image = (Image)resources.GetObject("printToolStripButton.Image");
            printToolStripButton.ImageTransparentColor = Color.Black;
            printToolStripButton.Name = "printToolStripButton";
            printToolStripButton.Size = new Size(21, 20);
            printToolStripButton.Text = "Imprimir";
            // 
            // printPreviewToolStripButton
            // 
            printPreviewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printPreviewToolStripButton.Image = (Image)resources.GetObject("printPreviewToolStripButton.Image");
            printPreviewToolStripButton.ImageTransparentColor = Color.Black;
            printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            printPreviewToolStripButton.Size = new Size(21, 20);
            printPreviewToolStripButton.Text = "Vizualizer Impressão";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(21, 6);
            // 
            // helpToolStripButton
            // 
            helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpToolStripButton.Image = (Image)resources.GetObject("helpToolStripButton.Image");
            helpToolStripButton.ImageTransparentColor = Color.Black;
            helpToolStripButton.Name = "helpToolStripButton";
            helpToolStripButton.Size = new Size(21, 20);
            helpToolStripButton.Text = "Ajuda";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(21, 20);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(243, 501);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(577, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(39, 17);
            toolStripStatusLabel.Text = "Status";
            // 
            // FrmMDIPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(820, 523);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmMDIPrincipal";
            Text = "FrmMDIPrincipal";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripButton toolStripButton1;
        private ToolStripMenuItem tspAbrirChamado;
        private ToolStripMenuItem tspAcompanharChamado;
        private ToolStripMenuItem tspGerenciarUsuarios;
        private ToolStripMenuItem tspCadastrarUsuario;
        private ToolStripMenuItem tspDeletarUsuario;
    }
}



