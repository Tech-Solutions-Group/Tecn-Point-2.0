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
            lblNomeEmpresa = new Label();
            lblDescricaoLogin = new Label();
            lblEmail = new Label();
            lblSenha = new Label();
            tbxEmail = new TextBox();
            tbxSenha = new TextBox();
            btnEntrar = new Button();
            lblDescSistemaDeSuporteAoCliente = new Label();
            lblCriadoPor = new Label();
            chcbModoDaltonico = new CheckBox();
            SuspendLayout();
            // 
            // lblNomeEmpresa
            // 
            lblNomeEmpresa.AutoSize = true;
            lblNomeEmpresa.BackColor = Color.Transparent;
            lblNomeEmpresa.Font = new Font("Consolas", 39.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeEmpresa.Location = new Point(343, 119);
            lblNomeEmpresa.Name = "lblNomeEmpresa";
            lblNomeEmpresa.Size = new Size(433, 62);
            lblNomeEmpresa.TabIndex = 0;
            lblNomeEmpresa.Text = "Lar dos Sonhos";
            // 
            // lblDescricaoLogin
            // 
            lblDescricaoLogin.AutoSize = true;
            lblDescricaoLogin.BackColor = Color.Transparent;
            lblDescricaoLogin.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescricaoLogin.ForeColor = SystemColors.ControlDarkDark;
            lblDescricaoLogin.Location = new Point(432, 206);
            lblDescricaoLogin.Name = "lblDescricaoLogin";
            lblDescricaoLogin.Size = new Size(243, 19);
            lblDescricaoLogin.TabIndex = 1;
            lblDescricaoLogin.Text = "Entre com suas credenciais";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(387, 247);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(70, 24);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.BackColor = Color.Transparent;
            lblSenha.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSenha.Location = new Point(387, 330);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(70, 24);
            lblSenha.TabIndex = 3;
            lblSenha.Text = "Senha";
            // 
            // tbxEmail
            // 
            tbxEmail.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxEmail.Location = new Point(415, 283);
            tbxEmail.Name = "tbxEmail";
            tbxEmail.PlaceholderText = "Digite seu e-mail";
            tbxEmail.Size = new Size(270, 26);
            tbxEmail.TabIndex = 1;
            // 
            // tbxSenha
            // 
            tbxSenha.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxSenha.Location = new Point(415, 366);
            tbxSenha.Name = "tbxSenha";
            tbxSenha.PasswordChar = '•';
            tbxSenha.PlaceholderText = "Digite sua senha";
            tbxSenha.Size = new Size(270, 26);
            tbxSenha.TabIndex = 2;
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.FromArgb(126, 105, 171);
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntrar.ForeColor = SystemColors.ButtonHighlight;
            btnEntrar.Location = new Point(474, 409);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(171, 43);
            btnEntrar.TabIndex = 3;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // lblDescSistemaDeSuporteAoCliente
            // 
            lblDescSistemaDeSuporteAoCliente.AutoSize = true;
            lblDescSistemaDeSuporteAoCliente.BackColor = Color.Transparent;
            lblDescSistemaDeSuporteAoCliente.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescSistemaDeSuporteAoCliente.ForeColor = SystemColors.ControlDarkDark;
            lblDescSistemaDeSuporteAoCliente.Location = new Point(424, 464);
            lblDescSistemaDeSuporteAoCliente.Name = "lblDescSistemaDeSuporteAoCliente";
            lblDescSistemaDeSuporteAoCliente.Size = new Size(270, 19);
            lblDescSistemaDeSuporteAoCliente.TabIndex = 7;
            lblDescSistemaDeSuporteAoCliente.Text = "Sistema de Suporte ao Cliente";
            // 
            // lblCriadoPor
            // 
            lblCriadoPor.AutoSize = true;
            lblCriadoPor.BackColor = Color.Transparent;
            lblCriadoPor.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCriadoPor.Location = new Point(468, 485);
            lblCriadoPor.Name = "lblCriadoPor";
            lblCriadoPor.Size = new Size(182, 15);
            lblCriadoPor.TabIndex = 8;
            lblCriadoPor.Text = "Criado por Tech Solutions";
            // 
            // chcbModoDaltonico
            // 
            chcbModoDaltonico.AutoSize = true;
            chcbModoDaltonico.BackColor = Color.Transparent;
            chcbModoDaltonico.Font = new Font("Segoe UI", 10F);
            chcbModoDaltonico.ForeColor = Color.LightGray;
            chcbModoDaltonico.Location = new Point(12, 610);
            chcbModoDaltonico.Name = "chcbModoDaltonico";
            chcbModoDaltonico.Size = new Size(127, 23);
            chcbModoDaltonico.TabIndex = 4;
            chcbModoDaltonico.Text = "Modo Daltônico";
            chcbModoDaltonico.UseVisualStyleBackColor = false;
            chcbModoDaltonico.CheckedChanged += chcbModoDaltonico_CheckedChanged;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(100, 52, 144);
            BackgroundImage = Properties.Resources.TelaFundoLogin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1119, 645);
            Controls.Add(chcbModoDaltonico);
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
            Text = "Tecn Point";
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
        private CheckBox chcbModoDaltonico;
    }
}