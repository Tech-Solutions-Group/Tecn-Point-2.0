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
            pbInfoModulo = new PictureBox();
            pbInfoJornada = new PictureBox();
            errorProvider1 = new ErrorProvider(components);
            lblInfoJornada = new Label();
            lblInfoModulo = new Label();
            ((System.ComponentModel.ISupportInitialize)pbInfoModulo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbInfoJornada).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblModulo.Location = new Point(263, 461);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(82, 24);
            lblModulo.TabIndex = 1;
            lblModulo.Text = "Módulo";
            // 
            // lblJornada
            // 
            lblJornada.AutoSize = true;
            lblJornada.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblJornada.Location = new Point(263, 373);
            lblJornada.Name = "lblJornada";
            lblJornada.Size = new Size(94, 24);
            lblJornada.TabIndex = 2;
            lblJornada.Text = "Jornada";
            // 
            // lblPrioridade
            // 
            lblPrioridade.AutoSize = true;
            lblPrioridade.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblPrioridade.Location = new Point(263, 278);
            lblPrioridade.Name = "lblPrioridade";
            lblPrioridade.Size = new Size(130, 24);
            lblPrioridade.TabIndex = 3;
            lblPrioridade.Text = "Prioridade";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Consolas", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(263, 61);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(82, 24);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Título";
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Consolas", 15.75F, FontStyle.Bold);
            lblDescricao.Location = new Point(263, 145);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(118, 24);
            lblDescricao.TabIndex = 5;
            lblDescricao.Text = "Descrição";
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 12F);
            txtTitulo.Location = new Point(278, 97);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Descreva brevemente o problema";
            txtTitulo.Size = new Size(355, 29);
            txtTitulo.TabIndex = 6;
            txtTitulo.Leave += txtTitulo_Leave;
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Segoe UI", 12F);
            txtDescricao.Location = new Point(278, 176);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.PlaceholderText = "Detalhe o problema encontrado";
            txtDescricao.ScrollBars = ScrollBars.Vertical;
            txtDescricao.Size = new Size(355, 81);
            txtDescricao.TabIndex = 7;
            txtDescricao.Leave += txtDescricao_Leave;
            // 
            // cbxPrioridade
            // 
            cbxPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPrioridade.Font = new Font("Segoe UI", 12F);
            cbxPrioridade.FormattingEnabled = true;
            cbxPrioridade.Items.AddRange(new object[] { "Selecione a prioridade...", "Baixa", "Média", "Alta" });
            cbxPrioridade.Location = new Point(278, 315);
            cbxPrioridade.Name = "cbxPrioridade";
            cbxPrioridade.Size = new Size(355, 29);
            cbxPrioridade.TabIndex = 8;
            cbxPrioridade.Leave += cbxPrioridade_Leave;
            // 
            // cbxJornada
            // 
            cbxJornada.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxJornada.Font = new Font("Segoe UI", 12F);
            cbxJornada.FormattingEnabled = true;
            cbxJornada.Items.AddRange(new object[] { "Selecione a jornada...", "Financeiro", "Marketing", "Recursos Humanos" });
            cbxJornada.Location = new Point(278, 410);
            cbxJornada.Name = "cbxJornada";
            cbxJornada.Size = new Size(353, 29);
            cbxJornada.TabIndex = 9;
            cbxJornada.Leave += cbxJornada_Leave;
            // 
            // cbxModulo
            // 
            cbxModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxModulo.Font = new Font("Segoe UI", 12F);
            cbxModulo.FormattingEnabled = true;
            cbxModulo.Items.AddRange(new object[] { "Selecione o módulo...", "Hardware", "Software", "Rede" });
            cbxModulo.Location = new Point(276, 500);
            cbxModulo.Name = "cbxModulo";
            cbxModulo.Size = new Size(355, 29);
            cbxModulo.TabIndex = 10;
            cbxModulo.Leave += cbxModulo_Leave;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(126, 105, 171);
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Consolas", 11F);
            btnConfirmar.ForeColor = SystemColors.ControlLightLight;
            btnConfirmar.Location = new Point(526, 545);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(107, 38);
            btnConfirmar.TabIndex = 11;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Consolas", 11F);
            btnCancelar.ForeColor = Color.DimGray;
            btnCancelar.Location = new Point(278, 545);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 38);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pbInfoModulo
            // 
            pbInfoModulo.Image = (Image)resources.GetObject("pbInfoModulo.Image");
            pbInfoModulo.Location = new Point(348, 463);
            pbInfoModulo.Name = "pbInfoModulo";
            pbInfoModulo.Size = new Size(22, 21);
            pbInfoModulo.SizeMode = PictureBoxSizeMode.Zoom;
            pbInfoModulo.TabIndex = 13;
            pbInfoModulo.TabStop = false;
            pbInfoModulo.Click += pbInfoModulo_Click;
            // 
            // pbInfoJornada
            // 
            pbInfoJornada.Image = Properties.Resources.icons8_informações_48;
            pbInfoJornada.Location = new Point(359, 376);
            pbInfoJornada.Name = "pbInfoJornada";
            pbInfoJornada.Size = new Size(22, 21);
            pbInfoJornada.SizeMode = PictureBoxSizeMode.Zoom;
            pbInfoJornada.TabIndex = 14;
            pbInfoJornada.TabStop = false;
            pbInfoJornada.Click += pbInfoJornada_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // lblInfoJornada
            // 
            lblInfoJornada.AutoSize = true;
            lblInfoJornada.Font = new Font("Consolas", 9F);
            lblInfoJornada.Location = new Point(387, 379);
            lblInfoJornada.Name = "lblInfoJornada";
            lblInfoJornada.Size = new Size(273, 14);
            lblInfoJornada.TabIndex = 15;
            lblInfoJornada.Text = "Setor em que está ocorrendo o problema";
            lblInfoJornada.Visible = false;
            // 
            // lblInfoModulo
            // 
            lblInfoModulo.Font = new Font("Consolas", 9F);
            lblInfoModulo.Location = new Point(376, 450);
            lblInfoModulo.Name = "lblInfoModulo";
            lblInfoModulo.Size = new Size(244, 47);
            lblInfoModulo.TabIndex = 16;
            lblInfoModulo.Text = "Hardware = Componente físico; \r\nSoftware = Programa/Aplicativo; \r\nRede = Internet.";
            lblInfoModulo.Visible = false;
            // 
            // FormAberturaChamado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(896, 645);
            Controls.Add(lblInfoModulo);
            Controls.Add(lblInfoJornada);
            Controls.Add(pbInfoJornada);
            Controls.Add(pbInfoModulo);
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
            ((System.ComponentModel.ISupportInitialize)pbInfoModulo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbInfoJornada).EndInit();
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
        private PictureBox pbInfoModulo;
        private PictureBox pbInfoJornada;
        private ErrorProvider errorProvider1;
        private Label lblInfoModulo;
        private Label lblInfoJornada;
    }
}