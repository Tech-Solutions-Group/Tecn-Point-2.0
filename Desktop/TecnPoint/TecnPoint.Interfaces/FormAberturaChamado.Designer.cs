namespace TecnPoint.Interfaces
{
    partial class FormAberturaChamado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAberturaChamado));
            lblModulo = new Label();
            lblJornada = new Label();
            lblPrioridade = new Label();
            lblTitulo = new Label();
            lblDescricao = new Label();
            txtTitulo = new TextBox();
            txtDescricao = new TextBox();
            cbxPrioridade = new ComboBox();
            cbxJornada = new ComboBox();
            cbxModulo = new ComboBox();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Consolas", 13F);
            lblModulo.Location = new Point(162, 366);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(70, 22);
            lblModulo.TabIndex = 1;
            lblModulo.Text = "Módulo";
            // 
            // lblJornada
            // 
            lblJornada.AutoSize = true;
            lblJornada.Font = new Font("Consolas", 13F);
            lblJornada.Location = new Point(162, 295);
            lblJornada.Name = "lblJornada";
            lblJornada.Size = new Size(80, 22);
            lblJornada.TabIndex = 2;
            lblJornada.Text = "Jornada";
            // 
            // lblPrioridade
            // 
            lblPrioridade.AutoSize = true;
            lblPrioridade.Font = new Font("Consolas", 13F);
            lblPrioridade.Location = new Point(162, 221);
            lblPrioridade.Name = "lblPrioridade";
            lblPrioridade.Size = new Size(110, 22);
            lblPrioridade.TabIndex = 3;
            lblPrioridade.Text = "Prioridade";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Consolas", 13F);
            lblTitulo.Location = new Point(162, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(70, 22);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Título";
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Consolas", 13F);
            lblDescricao.Location = new Point(162, 98);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(100, 22);
            lblDescricao.TabIndex = 5;
            lblDescricao.Text = "Descrição";
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 12F);
            txtTitulo.Location = new Point(168, 51);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Descreva brevemente o problema";
            txtTitulo.Size = new Size(332, 29);
            txtTitulo.TabIndex = 6;
            txtTitulo.Leave += txtTitulo_Leave;
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Segoe UI", 12F);
            txtDescricao.Location = new Point(168, 126);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "Detalhe o problema encontrado";
            txtDescricao.ScrollBars = ScrollBars.Vertical;
            txtDescricao.Size = new Size(332, 81);
            txtDescricao.TabIndex = 7;
            txtDescricao.Leave += txtDescricao_Leave;
            // 
            // cbxPrioridade
            // 
            cbxPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPrioridade.Font = new Font("Segoe UI", 12F);
            cbxPrioridade.FormattingEnabled = true;
            cbxPrioridade.Items.AddRange(new object[] { "Selecione a prioridade...", "Baixa", "Média", "Alta" });
            cbxPrioridade.Location = new Point(170, 252);
            cbxPrioridade.Name = "cbxPrioridade";
            cbxPrioridade.Size = new Size(330, 29);
            cbxPrioridade.TabIndex = 8;
            cbxPrioridade.Leave += cbxPrioridade_Leave;
            // 
            // cbxJornada
            // 
            cbxJornada.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxJornada.Font = new Font("Segoe UI", 12F);
            cbxJornada.FormattingEnabled = true;
            cbxJornada.Items.AddRange(new object[] { "Selecione a jornada...", "Financeiro", "Marketing", "Recursos Humanos" });
            cbxJornada.Location = new Point(170, 324);
            cbxJornada.Name = "cbxJornada";
            cbxJornada.Size = new Size(330, 29);
            cbxJornada.TabIndex = 9;
            cbxJornada.Leave += cbxJornada_Leave;
            // 
            // cbxModulo
            // 
            cbxModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxModulo.Font = new Font("Segoe UI", 12F);
            cbxModulo.FormattingEnabled = true;
            cbxModulo.Items.AddRange(new object[] { "Selecione o módulo...", "Hardware", "Software", "Rede" });
            cbxModulo.Location = new Point(168, 396);
            cbxModulo.Name = "cbxModulo";
            cbxModulo.Size = new Size(332, 29);
            cbxModulo.TabIndex = 10;
            cbxModulo.Leave += cbxModulo_Leave;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(126, 105, 171);
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Consolas", 11F);
            btnConfirmar.ForeColor = SystemColors.ControlLightLight;
            btnConfirmar.Location = new Point(393, 440);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(107, 38);
            btnConfirmar.TabIndex = 11;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ButtonHighlight;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Consolas", 11F);
            btnCancelar.ForeColor = SystemColors.ControlDarkDark;
            btnCancelar.Location = new Point(168, 440);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 38);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(229, 369);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(22, 21);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(240, 297);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(22, 21);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FormAberturaChamado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(659, 517);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(cbxModulo);
            Controls.Add(cbxJornada);
            Controls.Add(cbxPrioridade);
            Controls.Add(txtDescricao);
            Controls.Add(txtTitulo);
            Controls.Add(lblDescricao);
            Controls.Add(lblTitulo);
            Controls.Add(lblPrioridade);
            Controls.Add(lblJornada);
            Controls.Add(lblModulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAberturaChamado";
            Text = "FormAberturaChamado";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblModulo;
        private Label lblJornada;
        private Label lblPrioridade;
        private Label lblTitulo;
        private Label lblDescricao;
        private TextBox txtTitulo;
        private TextBox txtDescricao;
        private ComboBox cbxPrioridade;
        private ComboBox cbxJornada;
        private ComboBox cbxModulo;
        private Button btnConfirmar;
        private Button btnCancelar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ErrorProvider errorProvider1;
    }
}