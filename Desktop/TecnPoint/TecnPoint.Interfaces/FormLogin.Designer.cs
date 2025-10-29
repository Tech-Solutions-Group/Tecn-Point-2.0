namespace TecnPoint.Interfaces
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            lblNomeEmpresa = new Label();
            lblDescricaoLogin = new Label();
            lblEmail = new Label();
            lblSenha = new Label();
            tbxEmail = new TextBox();
            tbxSenha = new TextBox();
            btnEntrar = new Button();
            lblDescSistemaDeSuporteAoCliente = new Label();
            lblCriadoPor = new Label();
            SuspendLayout();
            // 
            // lblNomeEmpresa
            // 
            lblNomeEmpresa.AutoSize = true;
            lblNomeEmpresa.BackColor = Color.Transparent;
            lblNomeEmpresa.Font = new Font("Consolas", 30F, FontStyle.Bold);
            lblNomeEmpresa.Location = new Point(235, 75);
            lblNomeEmpresa.Name = "lblNomeEmpresa";
            lblNomeEmpresa.Size = new Size(328, 47);
            lblNomeEmpresa.TabIndex = 0;
            lblNomeEmpresa.Text = "Lar dos Sonhos";
            // 
            // lblDescricaoLogin
            // 
            lblDescricaoLogin.AutoSize = true;
            lblDescricaoLogin.BackColor = Color.Transparent;
            lblDescricaoLogin.Font = new Font("Consolas", 10F);
            lblDescricaoLogin.ForeColor = SystemColors.ControlDarkDark;
            lblDescricaoLogin.Location = new Point(295, 131);
            lblDescricaoLogin.Name = "lblDescricaoLogin";
            lblDescricaoLogin.Size = new Size(216, 17);
            lblDescricaoLogin.TabIndex = 1;
            lblDescricaoLogin.Text = "Entre com suas credenciais";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Consolas", 13F);
            lblEmail.Location = new Point(247, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 22);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.BackColor = Color.Transparent;
            lblSenha.Font = new Font("Consolas", 13F);
            lblSenha.Location = new Point(247, 244);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(60, 22);
            lblSenha.TabIndex = 3;
            lblSenha.Text = "Senha";
            // 
            // tbxEmail
            // 
            tbxEmail.Font = new Font("Consolas", 11F);
            tbxEmail.Location = new Point(265, 195);
            tbxEmail.Name = "tbxEmail";
            tbxEmail.PlaceholderText = "Digite seu e-mail";
            tbxEmail.Size = new Size(270, 25);
            tbxEmail.TabIndex = 4;
            // 
            // tbxSenha
            // 
            tbxSenha.Font = new Font("Consolas", 11F);
            tbxSenha.Location = new Point(265, 274);
            tbxSenha.Name = "tbxSenha";
            tbxSenha.PlaceholderText = "Digite sua senha";
            tbxSenha.Size = new Size(270, 25);
            tbxSenha.TabIndex = 5;
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.FromArgb(126, 105, 171);
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Consolas", 11F);
            btnEntrar.ForeColor = SystemColors.ButtonHighlight;
            btnEntrar.Location = new Point(325, 319);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(150, 30);
            btnEntrar.TabIndex = 6;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // lblDescSistemaDeSuporteAoCliente
            // 
            lblDescSistemaDeSuporteAoCliente.AutoSize = true;
            lblDescSistemaDeSuporteAoCliente.BackColor = Color.Transparent;
            lblDescSistemaDeSuporteAoCliente.Font = new Font("Consolas", 11F);
            lblDescSistemaDeSuporteAoCliente.ForeColor = SystemColors.ControlDarkDark;
            lblDescSistemaDeSuporteAoCliente.Location = new Point(280, 361);
            lblDescSistemaDeSuporteAoCliente.Name = "lblDescSistemaDeSuporteAoCliente";
            lblDescSistemaDeSuporteAoCliente.Size = new Size(240, 18);
            lblDescSistemaDeSuporteAoCliente.TabIndex = 7;
            lblDescSistemaDeSuporteAoCliente.Text = "Sistema de Suporte ao Cliente";
            // 
            // lblCriadoPor
            // 
            lblCriadoPor.AutoSize = true;
            lblCriadoPor.BackColor = Color.Transparent;
            lblCriadoPor.Font = new Font("Consolas", 8F);
            lblCriadoPor.Location = new Point(318, 382);
            lblCriadoPor.Name = "lblCriadoPor";
            lblCriadoPor.Size = new Size(157, 13);
            lblCriadoPor.TabIndex = 8;
            lblCriadoPor.Text = "Criado por Tech Solutions";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(100, 52, 144);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCriadoPor);
            Controls.Add(lblDescSistemaDeSuporteAoCliente);
            Controls.Add(btnEntrar);
            Controls.Add(tbxSenha);
            Controls.Add(tbxEmail);
            Controls.Add(lblSenha);
            Controls.Add(lblEmail);
            Controls.Add(lblDescricaoLogin);
            Controls.Add(lblNomeEmpresa);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNomeEmpresa;
        private Label lblDescricaoLogin;
        private Label lblEmail;
        private Label lblSenha;
        private TextBox tbxEmail;
        private TextBox tbxSenha;
        private Button btnEntrar;
        private Label lblDescSistemaDeSuporteAoCliente;
        private Label lblCriadoPor;
    }
}