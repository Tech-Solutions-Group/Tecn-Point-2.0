namespace TecnPoint.Interfaces
{
    partial class FormCadastrarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastrarUsuario));
            lblNomeUsuario = new Label();
            lblEmailUsuario = new Label();
            lblSenhaUsuario = new Label();
            lblTipoUsuario = new Label();
            txtNomeUsuario = new TextBox();
            txtEmailUsuario = new TextBox();
            txtSenhaUsuario = new TextBox();
            btnCadastrar = new Button();
            cbxTipoUsuario = new ComboBox();
            lblConfirmaSenha = new Label();
            txtConfirmaSenhaUsuario = new TextBox();
            pictureBox1 = new PictureBox();
            lblInfoEmail = new Label();
            lblExclamacaoInfoEmail = new Label();
            errorDadosCadastroInvalidos = new ErrorProvider(components);
            btnVoltar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorDadosCadastroInvalidos).BeginInit();
            SuspendLayout();
            // 
            // lblNomeUsuario
            // 
            lblNomeUsuario.AutoSize = true;
            lblNomeUsuario.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeUsuario.Location = new Point(255, 62);
            lblNomeUsuario.Name = "lblNomeUsuario";
            lblNomeUsuario.Size = new Size(58, 24);
            lblNomeUsuario.TabIndex = 0;
            lblNomeUsuario.Text = "Nome";
            // 
            // lblEmailUsuario
            // 
            lblEmailUsuario.AutoSize = true;
            lblEmailUsuario.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblEmailUsuario.Location = new Point(255, 163);
            lblEmailUsuario.Name = "lblEmailUsuario";
            lblEmailUsuario.Size = new Size(82, 24);
            lblEmailUsuario.TabIndex = 1;
            lblEmailUsuario.Text = "E-mail";
            // 
            // lblSenhaUsuario
            // 
            lblSenhaUsuario.AutoSize = true;
            lblSenhaUsuario.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblSenhaUsuario.Location = new Point(255, 264);
            lblSenhaUsuario.Name = "lblSenhaUsuario";
            lblSenhaUsuario.Size = new Size(70, 24);
            lblSenhaUsuario.TabIndex = 2;
            lblSenhaUsuario.Text = "Senha";
            // 
            // lblTipoUsuario
            // 
            lblTipoUsuario.AutoSize = true;
            lblTipoUsuario.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblTipoUsuario.Location = new Point(255, 455);
            lblTipoUsuario.Name = "lblTipoUsuario";
            lblTipoUsuario.Size = new Size(190, 24);
            lblTipoUsuario.TabIndex = 3;
            lblTipoUsuario.Text = "Tipo de usuário";
            // 
            // txtNomeUsuario
            // 
            txtNomeUsuario.Cursor = Cursors.IBeam;
            txtNomeUsuario.Font = new Font("Segoe UI", 14F);
            txtNomeUsuario.Location = new Point(267, 98);
            txtNomeUsuario.Name = "txtNomeUsuario";
            txtNomeUsuario.PlaceholderText = "Insira o nome";
            txtNomeUsuario.Size = new Size(375, 32);
            txtNomeUsuario.TabIndex = 4;
            txtNomeUsuario.Leave += txtNomeUsuario_Leave;
            // 
            // txtEmailUsuario
            // 
            txtEmailUsuario.Font = new Font("Segoe UI", 14F);
            txtEmailUsuario.Location = new Point(267, 202);
            txtEmailUsuario.Name = "txtEmailUsuario";
            txtEmailUsuario.PlaceholderText = "exemplo@gmail.com";
            txtEmailUsuario.Size = new Size(375, 32);
            txtEmailUsuario.TabIndex = 5;
            txtEmailUsuario.Leave += txtEmailUsuario_Leave;
            // 
            // txtSenhaUsuario
            // 
            txtSenhaUsuario.Font = new Font("Segoe UI", 14F);
            txtSenhaUsuario.Location = new Point(267, 301);
            txtSenhaUsuario.Name = "txtSenhaUsuario";
            txtSenhaUsuario.PlaceholderText = "Insira a senha";
            txtSenhaUsuario.Size = new Size(375, 32);
            txtSenhaUsuario.TabIndex = 6;
            txtSenhaUsuario.Leave += txtSenhaUsuario_Leave;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.FromArgb(126, 105, 171);
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = SystemColors.ControlLightLight;
            btnCadastrar.Location = new Point(508, 536);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(134, 45);
            btnCadastrar.TabIndex = 9;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // cbxTipoUsuario
            // 
            cbxTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTipoUsuario.Font = new Font("Segoe UI", 14F);
            cbxTipoUsuario.FormattingEnabled = true;
            cbxTipoUsuario.Items.AddRange(new object[] { "Selecione o tipo de usuário", "Cliente", "Funcionário" });
            cbxTipoUsuario.Location = new Point(267, 486);
            cbxTipoUsuario.Name = "cbxTipoUsuario";
            cbxTipoUsuario.Size = new Size(375, 33);
            cbxTipoUsuario.TabIndex = 10;
            cbxTipoUsuario.Leave += cbxTipoUsuario_Leave;
            // 
            // lblConfirmaSenha
            // 
            lblConfirmaSenha.AutoSize = true;
            lblConfirmaSenha.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblConfirmaSenha.Location = new Point(255, 360);
            lblConfirmaSenha.Name = "lblConfirmaSenha";
            lblConfirmaSenha.Size = new Size(190, 24);
            lblConfirmaSenha.TabIndex = 11;
            lblConfirmaSenha.Text = "Confirmar senha";
            // 
            // txtConfirmaSenhaUsuario
            // 
            txtConfirmaSenhaUsuario.Font = new Font("Segoe UI", 14F);
            txtConfirmaSenhaUsuario.Location = new Point(267, 397);
            txtConfirmaSenhaUsuario.Name = "txtConfirmaSenhaUsuario";
            txtConfirmaSenhaUsuario.PlaceholderText = "Digite a senha novamente";
            txtConfirmaSenhaUsuario.Size = new Size(375, 32);
            txtConfirmaSenhaUsuario.TabIndex = 12;
            txtConfirmaSenhaUsuario.Leave += txtConfirmaSenhaUsuario_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(343, 164);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(21, 24);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblInfoEmail
            // 
            lblInfoEmail.AutoSize = true;
            lblInfoEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoEmail.ForeColor = SystemColors.ControlDarkDark;
            lblInfoEmail.Location = new Point(370, 166);
            lblInfoEmail.Name = "lblInfoEmail";
            lblInfoEmail.Size = new Size(229, 21);
            lblInfoEmail.TabIndex = 14;
            lblInfoEmail.Text = "O e-mail deve conter '@' e '.'";
            lblInfoEmail.Visible = false;
            // 
            // lblExclamacaoInfoEmail
            // 
            lblExclamacaoInfoEmail.AutoSize = true;
            lblExclamacaoInfoEmail.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExclamacaoInfoEmail.ForeColor = Color.Red;
            lblExclamacaoInfoEmail.Location = new Point(596, 166);
            lblExclamacaoInfoEmail.Name = "lblExclamacaoInfoEmail";
            lblExclamacaoInfoEmail.Size = new Size(18, 25);
            lblExclamacaoInfoEmail.TabIndex = 15;
            lblExclamacaoInfoEmail.Text = "!";
            lblExclamacaoInfoEmail.Visible = false;
            // 
            // errorDadosCadastroInvalidos
            // 
            errorDadosCadastroInvalidos.ContainerControl = this;
            // 
            // btnVoltar
            // 
            btnVoltar.BackColor = SystemColors.Control;
            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoltar.ForeColor = Color.DimGray;
            btnVoltar.Location = new Point(267, 538);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(134, 45);
            btnVoltar.TabIndex = 16;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = false;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // FormCadastrarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 645);
            Controls.Add(btnVoltar);
            Controls.Add(lblExclamacaoInfoEmail);
            Controls.Add(lblInfoEmail);
            Controls.Add(pictureBox1);
            Controls.Add(txtConfirmaSenhaUsuario);
            Controls.Add(lblConfirmaSenha);
            Controls.Add(cbxTipoUsuario);
            Controls.Add(btnCadastrar);
            Controls.Add(txtSenhaUsuario);
            Controls.Add(txtEmailUsuario);
            Controls.Add(txtNomeUsuario);
            Controls.Add(lblTipoUsuario);
            Controls.Add(lblSenhaUsuario);
            Controls.Add(lblEmailUsuario);
            Controls.Add(lblNomeUsuario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCadastrarUsuario";
            Text = "FormCadastrarUsuario";
            Resize += FormCadastrarUsuario_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorDadosCadastroInvalidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNomeUsuario;
        private Label lblEmailUsuario;
        private Label lblSenhaUsuario;
        private Label lblTipoUsuario;
        private TextBox txtNomeUsuario;
        private TextBox txtEmailUsuario;
        private TextBox txtSenhaUsuario;
        private Button btnCadastrar;
        private ComboBox cbxTipoUsuario;
        private Label lblConfirmaSenha;
        private TextBox txtConfirmaSenhaUsuario;
        private PictureBox pictureBox1;
        private Label lblInfoEmail;
        private Label lblExclamacaoInfoEmail;
        private ErrorProvider errorDadosCadastroInvalidos;
        private Button btnVoltar;
    }
}