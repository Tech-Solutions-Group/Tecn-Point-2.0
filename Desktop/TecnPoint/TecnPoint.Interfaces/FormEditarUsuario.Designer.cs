namespace TecnPoint.Interfaces
{
    partial class FormEditarUsuario
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
            components = new System.ComponentModel.Container();
            lblNome = new Label();
            lblEmail = new Label();
            lblSenha = new Label();
            lblConfirmarSenha = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtSenha = new TextBox();
            txtConfirmaSenha = new TextBox();
            btnSalvar = new Button();
            btnVoltar = new Button();
            errorDadosAtualizarUsuario = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorDadosAtualizarUsuario).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblNome.Location = new Point(268, 123);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(58, 24);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblEmail.Location = new Point(268, 211);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(82, 24);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "E-mail";
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSenha.Location = new Point(268, 297);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(70, 24);
            lblSenha.TabIndex = 2;
            lblSenha.Text = "Senha";
            // 
            // lblConfirmarSenha
            // 
            lblConfirmarSenha.AutoSize = true;
            lblConfirmarSenha.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblConfirmarSenha.Location = new Point(268, 388);
            lblConfirmarSenha.Name = "lblConfirmarSenha";
            lblConfirmarSenha.Size = new Size(190, 24);
            lblConfirmarSenha.TabIndex = 3;
            lblConfirmarSenha.Text = "Confirmar senha";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 14F);
            txtNome.Location = new Point(290, 161);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(338, 32);
            txtNome.TabIndex = 0;
            txtNome.Leave += txtNome_Leave;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 14F);
            txtEmail.Location = new Point(290, 247);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(338, 32);
            txtEmail.TabIndex = 1;
            txtEmail.Leave += txtEmail_Leave;
            // 
            // txtSenha
            // 
            txtSenha.Font = new Font("Segoe UI", 14F);
            txtSenha.Location = new Point(290, 335);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '•';
            txtSenha.Size = new Size(338, 32);
            txtSenha.TabIndex = 2;
            txtSenha.Leave += txtSenha_Leave;
            // 
            // txtConfirmaSenha
            // 
            txtConfirmaSenha.Font = new Font("Segoe UI", 14F);
            txtConfirmaSenha.Location = new Point(290, 430);
            txtConfirmaSenha.Name = "txtConfirmaSenha";
            txtConfirmaSenha.PasswordChar = '•';
            txtConfirmaSenha.Size = new Size(338, 32);
            txtConfirmaSenha.TabIndex = 3;
            txtConfirmaSenha.Leave += txtConfirmaSenha_Leave;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(126, 105, 171);
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvar.ForeColor = SystemColors.ControlLightLight;
            btnSalvar.Location = new Point(531, 482);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(97, 40);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.BackColor = SystemColors.Control;
            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoltar.ForeColor = SystemColors.ControlDarkDark;
            btnVoltar.Location = new Point(290, 482);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(97, 40);
            btnVoltar.TabIndex = 5;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = false;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // errorDadosAtualizarUsuario
            // 
            errorDadosAtualizarUsuario.ContainerControl = this;
            // 
            // FormEditarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(896, 645);
            Controls.Add(btnVoltar);
            Controls.Add(btnSalvar);
            Controls.Add(txtConfirmaSenha);
            Controls.Add(txtSenha);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(lblConfirmarSenha);
            Controls.Add(lblSenha);
            Controls.Add(lblEmail);
            Controls.Add(lblNome);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEditarUsuario";
            Text = "FormEditarUsuario";
            Load += FormEditarUsuario_Load;
            Resize += FormEditarUsuario_Resize;
            ((System.ComponentModel.ISupportInitialize)errorDadosAtualizarUsuario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblEmail;
        private Label lblSenha;
        private Label lblConfirmarSenha;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtSenha;
        private TextBox txtConfirmaSenha;
        private Button btnSalvar;
        private Button btnVoltar;
        private ErrorProvider errorDadosAtualizarUsuario;
    }
}