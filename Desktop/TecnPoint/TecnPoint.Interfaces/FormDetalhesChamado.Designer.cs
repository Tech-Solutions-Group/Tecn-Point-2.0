namespace TecnPoint.Interfaces
{
    partial class FormDetalhesChamado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalhesChamado));
            lblTitulo = new Label();
            lblStatusChamado = new Label();
            lblPrioridadeChamado = new Label();
            lblDescricao = new Label();
            lblDescricaoDoChamado = new Label();
            lblJornadaChamado = new Label();
            lblModuloChamado = new Label();
            flpConversa = new FlowLayoutPanel();
            txtMensagem = new TextBox();
            btnEnviarMensagem = new Button();
            lblNomeCliente = new Label();
            lblNomeFuncionario = new Label();
            lblResponsavelChamado = new Label();
            lblCriadoPor = new Label();
            lblJornada = new Label();
            lblModulo = new Label();
            cbxStatus = new ComboBox();
            cbxPrioridade = new ComboBox();
            cbxNomeFuncionario = new ComboBox();
            pbIconPrioridade = new PictureBox();
            pbIconDescricao = new PictureBox();
            pbIconJornada = new PictureBox();
            pbIconModulo = new PictureBox();
            lblStatus = new Label();
            lblPrioridade = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnVoltarDetalhesChamado = new Button();
            ((System.ComponentModel.ISupportInitialize)pbIconPrioridade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIconDescricao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIconJornada).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbIconModulo).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Consolas", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(37, 26);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(389, 70);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título";
            // 
            // lblStatusChamado
            // 
            lblStatusChamado.AutoSize = true;
            lblStatusChamado.Font = new Font("Consolas", 15F, FontStyle.Bold);
            lblStatusChamado.Location = new Point(39, 111);
            lblStatusChamado.Name = "lblStatusChamado";
            lblStatusChamado.Size = new Size(76, 23);
            lblStatusChamado.TabIndex = 1;
            lblStatusChamado.Text = "Status";
            // 
            // lblPrioridadeChamado
            // 
            lblPrioridadeChamado.AutoSize = true;
            lblPrioridadeChamado.Font = new Font("Consolas", 15F, FontStyle.Bold);
            lblPrioridadeChamado.Location = new Point(235, 111);
            lblPrioridadeChamado.Name = "lblPrioridadeChamado";
            lblPrioridadeChamado.Size = new Size(120, 23);
            lblPrioridadeChamado.TabIndex = 2;
            lblPrioridadeChamado.Text = "Prioridade";
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Consolas", 16F, FontStyle.Bold);
            lblDescricao.Location = new Point(37, 320);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(120, 26);
            lblDescricao.TabIndex = 3;
            lblDescricao.Text = "Descrição";
            // 
            // lblDescricaoDoChamado
            // 
            lblDescricaoDoChamado.BackColor = SystemColors.ControlLight;
            lblDescricaoDoChamado.Font = new Font("Consolas", 10F);
            lblDescricaoDoChamado.Location = new Point(48, 358);
            lblDescricaoDoChamado.Name = "lblDescricaoDoChamado";
            lblDescricaoDoChamado.Size = new Size(336, 110);
            lblDescricaoDoChamado.TabIndex = 4;
            lblDescricaoDoChamado.Text = "Descrição do chamado...";
            // 
            // lblJornadaChamado
            // 
            lblJornadaChamado.AutoSize = true;
            lblJornadaChamado.Font = new Font("Consolas", 13F, FontStyle.Bold);
            lblJornadaChamado.Location = new Point(49, 480);
            lblJornadaChamado.Name = "lblJornadaChamado";
            lblJornadaChamado.Size = new Size(80, 22);
            lblJornadaChamado.TabIndex = 5;
            lblJornadaChamado.Text = "Jornada";
            // 
            // lblModuloChamado
            // 
            lblModuloChamado.AutoSize = true;
            lblModuloChamado.Font = new Font("Consolas", 13F, FontStyle.Bold);
            lblModuloChamado.Location = new Point(249, 480);
            lblModuloChamado.Name = "lblModuloChamado";
            lblModuloChamado.Size = new Size(70, 22);
            lblModuloChamado.TabIndex = 6;
            lblModuloChamado.Text = "Módulo";
            // 
            // flpConversa
            // 
            flpConversa.BackColor = SystemColors.ControlLight;
            flpConversa.Location = new Point(432, 26);
            flpConversa.Name = "flpConversa";
            flpConversa.Size = new Size(400, 522);
            flpConversa.TabIndex = 7;
            // 
            // txtMensagem
            // 
            txtMensagem.Location = new Point(432, 554);
            txtMensagem.Multiline = true;
            txtMensagem.Name = "txtMensagem";
            txtMensagem.PlaceholderText = "Digite sua mensagem aqui...";
            txtMensagem.Size = new Size(331, 32);
            txtMensagem.TabIndex = 8;
            // 
            // btnEnviarMensagem
            // 
            btnEnviarMensagem.Location = new Point(769, 554);
            btnEnviarMensagem.Name = "btnEnviarMensagem";
            btnEnviarMensagem.Size = new Size(63, 32);
            btnEnviarMensagem.TabIndex = 9;
            btnEnviarMensagem.Text = "button1";
            btnEnviarMensagem.UseVisualStyleBackColor = true;
            // 
            // lblNomeCliente
            // 
            lblNomeCliente.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNomeCliente.Location = new Point(48, 253);
            lblNomeCliente.Name = "lblNomeCliente";
            lblNomeCliente.Size = new Size(176, 51);
            lblNomeCliente.TabIndex = 10;
            lblNomeCliente.Text = "Nome cliente";
            // 
            // lblNomeFuncionario
            // 
            lblNomeFuncionario.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNomeFuncionario.Location = new Point(229, 253);
            lblNomeFuncionario.Name = "lblNomeFuncionario";
            lblNomeFuncionario.Size = new Size(197, 30);
            lblNomeFuncionario.TabIndex = 11;
            lblNomeFuncionario.Text = "Nome funcionário";
            // 
            // lblResponsavelChamado
            // 
            lblResponsavelChamado.AutoSize = true;
            lblResponsavelChamado.Font = new Font("Consolas", 13F, FontStyle.Bold);
            lblResponsavelChamado.Location = new Point(235, 228);
            lblResponsavelChamado.Name = "lblResponsavelChamado";
            lblResponsavelChamado.Size = new Size(130, 22);
            lblResponsavelChamado.TabIndex = 13;
            lblResponsavelChamado.Text = "Responsável:";
            // 
            // lblCriadoPor
            // 
            lblCriadoPor.AutoSize = true;
            lblCriadoPor.Font = new Font("Consolas", 13F, FontStyle.Bold);
            lblCriadoPor.Location = new Point(37, 228);
            lblCriadoPor.Name = "lblCriadoPor";
            lblCriadoPor.Size = new Size(120, 22);
            lblCriadoPor.TabIndex = 14;
            lblCriadoPor.Text = "Aberto por:";
            // 
            // lblJornada
            // 
            lblJornada.AutoSize = true;
            lblJornada.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblJornada.Location = new Point(49, 509);
            lblJornada.Name = "lblJornada";
            lblJornada.Size = new Size(80, 22);
            lblJornada.TabIndex = 15;
            lblJornada.Text = "jornada";
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblModulo.Location = new Point(255, 509);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(70, 22);
            lblModulo.TabIndex = 16;
            lblModulo.Text = "módulo";
            // 
            // cbxStatus
            // 
            cbxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxStatus.Font = new Font("Consolas", 15F, FontStyle.Bold);
            cbxStatus.FormattingEnabled = true;
            cbxStatus.Items.AddRange(new object[] { "Selecione...", "Aberto", "Em andamento", "Pendente", "Resolvido" });
            cbxStatus.Location = new Point(49, 182);
            cbxStatus.Name = "cbxStatus";
            cbxStatus.Size = new Size(143, 31);
            cbxStatus.TabIndex = 17;
            cbxStatus.SelectedIndexChanged += cbxStatus_SelectedIndexChanged;
            // 
            // cbxPrioridade
            // 
            cbxPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPrioridade.Font = new Font("Consolas", 15F, FontStyle.Bold);
            cbxPrioridade.FormattingEnabled = true;
            cbxPrioridade.Items.AddRange(new object[] { "Selecione...", "Baixa", "Média", "Alta" });
            cbxPrioridade.Location = new Point(249, 182);
            cbxPrioridade.Name = "cbxPrioridade";
            cbxPrioridade.Size = new Size(143, 31);
            cbxPrioridade.TabIndex = 18;
            cbxPrioridade.SelectedIndexChanged += cbxPrioridade_SelectedIndexChanged;
            // 
            // cbxNomeFuncionario
            // 
            cbxNomeFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxNomeFuncionario.Font = new Font("Consolas", 14F, FontStyle.Bold);
            cbxNomeFuncionario.FormattingEnabled = true;
            cbxNomeFuncionario.Location = new Point(234, 286);
            cbxNomeFuncionario.Name = "cbxNomeFuncionario";
            cbxNomeFuncionario.Size = new Size(163, 30);
            cbxNomeFuncionario.TabIndex = 19;
            // 
            // pbIconPrioridade
            // 
            pbIconPrioridade.Image = (Image)resources.GetObject("pbIconPrioridade.Image");
            pbIconPrioridade.Location = new Point(354, 108);
            pbIconPrioridade.Name = "pbIconPrioridade";
            pbIconPrioridade.Size = new Size(25, 29);
            pbIconPrioridade.SizeMode = PictureBoxSizeMode.Zoom;
            pbIconPrioridade.TabIndex = 20;
            pbIconPrioridade.TabStop = false;
            // 
            // pbIconDescricao
            // 
            pbIconDescricao.Image = (Image)resources.GetObject("pbIconDescricao.Image");
            pbIconDescricao.Location = new Point(150, 319);
            pbIconDescricao.Name = "pbIconDescricao";
            pbIconDescricao.Size = new Size(25, 29);
            pbIconDescricao.SizeMode = PictureBoxSizeMode.Zoom;
            pbIconDescricao.TabIndex = 21;
            pbIconDescricao.TabStop = false;
            // 
            // pbIconJornada
            // 
            pbIconJornada.Image = (Image)resources.GetObject("pbIconJornada.Image");
            pbIconJornada.Location = new Point(125, 477);
            pbIconJornada.Name = "pbIconJornada";
            pbIconJornada.Size = new Size(25, 29);
            pbIconJornada.SizeMode = PictureBoxSizeMode.Zoom;
            pbIconJornada.TabIndex = 22;
            pbIconJornada.TabStop = false;
            // 
            // pbIconModulo
            // 
            pbIconModulo.Image = (Image)resources.GetObject("pbIconModulo.Image");
            pbIconModulo.Location = new Point(314, 477);
            pbIconModulo.Name = "pbIconModulo";
            pbIconModulo.Size = new Size(25, 29);
            pbIconModulo.SizeMode = PictureBoxSizeMode.Zoom;
            pbIconModulo.TabIndex = 23;
            pbIconModulo.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Consolas", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(48, 145);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(144, 23);
            lblStatus.TabIndex = 24;
            lblStatus.Text = "status";
            // 
            // lblPrioridade
            // 
            lblPrioridade.Font = new Font("Consolas", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrioridade.Location = new Point(249, 145);
            lblPrioridade.Name = "lblPrioridade";
            lblPrioridade.Size = new Size(143, 23);
            lblPrioridade.TabIndex = 25;
            lblPrioridade.Text = "prioridade";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.GrayText;
            flowLayoutPanel1.Location = new Point(43, 93);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(353, 2);
            flowLayoutPanel1.TabIndex = 26;
            // 
            // btnVoltarDetalhesChamado
            // 
            btnVoltarDetalhesChamado.Location = new Point(24, 552);
            btnVoltarDetalhesChamado.Name = "btnVoltarDetalhesChamado";
            btnVoltarDetalhesChamado.Size = new Size(67, 36);
            btnVoltarDetalhesChamado.TabIndex = 12;
            btnVoltarDetalhesChamado.Text = "Voltar";
            btnVoltarDetalhesChamado.UseVisualStyleBackColor = true;
            btnVoltarDetalhesChamado.Click += btnVoltarDetalhesChamado_Click;
            // 
            // FormDetalhesChamado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 597);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pbIconModulo);
            Controls.Add(pbIconJornada);
            Controls.Add(pbIconDescricao);
            Controls.Add(pbIconPrioridade);
            Controls.Add(cbxNomeFuncionario);
            Controls.Add(cbxPrioridade);
            Controls.Add(cbxStatus);
            Controls.Add(lblModulo);
            Controls.Add(lblJornada);
            Controls.Add(lblCriadoPor);
            Controls.Add(lblResponsavelChamado);
            Controls.Add(btnVoltarDetalhesChamado);
            Controls.Add(lblNomeFuncionario);
            Controls.Add(lblNomeCliente);
            Controls.Add(btnEnviarMensagem);
            Controls.Add(txtMensagem);
            Controls.Add(flpConversa);
            Controls.Add(lblModuloChamado);
            Controls.Add(lblJornadaChamado);
            Controls.Add(lblDescricaoDoChamado);
            Controls.Add(lblDescricao);
            Controls.Add(lblPrioridadeChamado);
            Controls.Add(lblStatusChamado);
            Controls.Add(lblTitulo);
            Controls.Add(lblStatus);
            Controls.Add(lblPrioridade);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDetalhesChamado";
            Text = "FormDetalhesChamado";
            Load += FormDetalhesChamado_Load;
            ((System.ComponentModel.ISupportInitialize)pbIconPrioridade).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIconDescricao).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIconJornada).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbIconModulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblStatusChamado;
        private Label lblPrioridadeChamado;
        private Label lblDescricao;
        private Label lblDescricaoDoChamado;
        private Label lblJornadaChamado;
        private Label lblModuloChamado;
        private FlowLayoutPanel flpConversa;
        private TextBox txtMensagem;
        private Button btnEnviarMensagem;
        private Label lblNomeCliente;
        private Label lblNomeFuncionario;
        private Label lblResponsavelChamado;
        private Label lblCriadoPor;
        private Label lblJornada;
        private Label lblModulo;
        private ComboBox cbxStatus;
        private ComboBox cbxPrioridade;
        private ComboBox cbxNomeFuncionario;
        private PictureBox pbIconPrioridade;
        private PictureBox pbIconDescricao;
        private PictureBox pbIconJornada;
        private PictureBox pbIconModulo;
        private Label lblStatus;
        private Label lblPrioridade;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnVoltarDetalhesChamado;
    }
}