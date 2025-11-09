namespace TecnPoint.Interfaces
{
    partial class FormChatBot
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
            pnlCabecalhoChatBot = new Panel();
            pictureBox1 = new PictureBox();
            lblTecnBot = new Label();
            flpConversaChatBot = new FlowLayoutPanel();
            txtMensagemUsuario = new TextBox();
            lblAtalho = new Label();
            btnEnviar = new Button();
            pnlCabecalhoChatBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlCabecalhoChatBot
            // 
            pnlCabecalhoChatBot.BackColor = Color.FromArgb(126, 105, 171);
            pnlCabecalhoChatBot.BackgroundImage = Properties.Resources.TelaFundoLogin;
            pnlCabecalhoChatBot.Controls.Add(pictureBox1);
            pnlCabecalhoChatBot.Controls.Add(lblTecnBot);
            pnlCabecalhoChatBot.Location = new Point(0, 0);
            pnlCabecalhoChatBot.Name = "pnlCabecalhoChatBot";
            pnlCabecalhoChatBot.Size = new Size(896, 96);
            pnlCabecalhoChatBot.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.icons8_bot_48;
            pictureBox1.Location = new Point(24, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 57);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblTecnBot
            // 
            lblTecnBot.AutoSize = true;
            lblTecnBot.BackColor = Color.Transparent;
            lblTecnBot.Font = new Font("Consolas", 17.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTecnBot.ForeColor = SystemColors.ControlLightLight;
            lblTecnBot.Location = new Point(77, 36);
            lblTecnBot.Name = "lblTecnBot";
            lblTecnBot.Size = new Size(116, 27);
            lblTecnBot.TabIndex = 0;
            lblTecnBot.Text = "TECN BOT";
            // 
            // flpConversaChatBot
            // 
            flpConversaChatBot.AutoScroll = true;
            flpConversaChatBot.FlowDirection = FlowDirection.TopDown;
            flpConversaChatBot.Location = new Point(0, 94);
            flpConversaChatBot.Name = "flpConversaChatBot";
            flpConversaChatBot.Size = new Size(896, 501);
            flpConversaChatBot.TabIndex = 1;
            flpConversaChatBot.WrapContents = false;
            // 
            // txtMensagemUsuario
            // 
            txtMensagemUsuario.Font = new Font("Segoe UI", 11F);
            txtMensagemUsuario.Location = new Point(251, 596);
            txtMensagemUsuario.Multiline = true;
            txtMensagemUsuario.Name = "txtMensagemUsuario";
            txtMensagemUsuario.PlaceholderText = "Digite aqui...";
            txtMensagemUsuario.Size = new Size(370, 47);
            txtMensagemUsuario.TabIndex = 0;
            // 
            // lblAtalho
            // 
            lblAtalho.AutoSize = true;
            lblAtalho.Location = new Point(628, 621);
            lblAtalho.Name = "lblAtalho";
            lblAtalho.Size = new Size(39, 15);
            lblAtalho.TabIndex = 3;
            lblAtalho.Text = "&Enviar";
            lblAtalho.Click += lblAtalho_Click;
            // 
            // btnEnviar
            // 
            btnEnviar.BackgroundImage = Properties.Resources.IconEnviar;
            btnEnviar.Location = new Point(628, 596);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(49, 47);
            btnEnviar.TabIndex = 1;
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // FormChatBot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 645);
            Controls.Add(btnEnviar);
            Controls.Add(txtMensagemUsuario);
            Controls.Add(flpConversaChatBot);
            Controls.Add(pnlCabecalhoChatBot);
            Controls.Add(lblAtalho);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormChatBot";
            Text = "FormChatBot";
            Load += FormChatBot_Load;
            Resize += FormChatBot_Resize;
            pnlCabecalhoChatBot.ResumeLayout(false);
            pnlCabecalhoChatBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlCabecalhoChatBot;
        private PictureBox pictureBox1;
        private Label lblTecnBot;
        private FlowLayoutPanel flpConversaChatBot;
        private TextBox txtMensagemUsuario;
        private Label lblAtalho;
        private Button btnEnviar;
    }
}