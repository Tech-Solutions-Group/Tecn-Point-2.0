namespace TecnPoint.Interfaces
{
    partial class FormListaUsuarios
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaUsuarios));
            dgvUsuarios = new DataGridView();
            nome = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            tipoUsuario = new DataGridViewTextBoxColumn();
            Editar = new DataGridViewImageColumn();
            btnVoltar = new Button();
            pbInformacaoEditar = new PictureBox();
            lblInfoEditar = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbInformacaoEditar).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToOrderColumns = true;
            dgvUsuarios.AllowUserToResizeColumns = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = SystemColors.ControlLightLight;
            dgvUsuarios.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(146, 76, 211);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(168, 124, 209);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { nome, Email, tipoUsuario, Editar });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(168, 124, 209);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUsuarios.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.GridColor = SystemColors.Control;
            dgvUsuarios.Location = new Point(60, 60);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.Size = new Size(776, 531);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            dgvUsuarios.KeyDown += dgvUsuarios_KeyDown;
            // 
            // nome
            // 
            nome.DataPropertyName = "nome";
            nome.HeaderText = "Nome";
            nome.Name = "nome";
            nome.ReadOnly = true;
            // 
            // Email
            // 
            Email.DataPropertyName = "email";
            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // tipoUsuario
            // 
            tipoUsuario.DataPropertyName = "tipoUsuario";
            tipoUsuario.HeaderText = "Tipo Usuário";
            tipoUsuario.Name = "tipoUsuario";
            tipoUsuario.ReadOnly = true;
            // 
            // Editar
            // 
            Editar.HeaderText = "Ações";
            Editar.Image = (Image)resources.GetObject("Editar.Image");
            Editar.ImageLayout = DataGridViewImageCellLayout.Zoom;
            Editar.Name = "Editar";
            Editar.ReadOnly = true;
            Editar.Resizable = DataGridViewTriState.True;
            // 
            // btnVoltar
            // 
            btnVoltar.BackColor = SystemColors.Control;
            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVoltar.ForeColor = Color.DimGray;
            btnVoltar.Location = new Point(60, 597);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(98, 36);
            btnVoltar.TabIndex = 1;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = false;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // pbInformacaoEditar
            // 
            pbInformacaoEditar.Image = (Image)resources.GetObject("pbInformacaoEditar.Image");
            pbInformacaoEditar.Location = new Point(60, 28);
            pbInformacaoEditar.Name = "pbInformacaoEditar";
            pbInformacaoEditar.Size = new Size(30, 28);
            pbInformacaoEditar.SizeMode = PictureBoxSizeMode.Zoom;
            pbInformacaoEditar.TabIndex = 2;
            pbInformacaoEditar.TabStop = false;
            pbInformacaoEditar.Click += pbInformacaoEditar_Click;
            // 
            // lblInfoEditar
            // 
            lblInfoEditar.AutoSize = true;
            lblInfoEditar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfoEditar.Location = new Point(93, 32);
            lblInfoEditar.Name = "lblInfoEditar";
            lblInfoEditar.Size = new Size(468, 21);
            lblInfoEditar.TabIndex = 3;
            lblInfoEditar.Text = "Clique no ícone de edição na tabela para editar o usuário desejado";
            lblInfoEditar.Visible = false;
            // 
            // FormListaUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(896, 645);
            Controls.Add(lblInfoEditar);
            Controls.Add(pbInformacaoEditar);
            Controls.Add(btnVoltar);
            Controls.Add(dgvUsuarios);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListaUsuarios";
            Text = "FormListaUsuarios";
            Load += FormListaUsuarios_Load;
            Resize += FormListaUsuarios_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbInformacaoEditar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button btnVoltar;
        private PictureBox pbInformacaoEditar;
        private Label lblInfoEditar;
        private DataGridViewTextBoxColumn nome;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn tipoUsuario;
        private DataGridViewImageColumn Editar;
    }
}