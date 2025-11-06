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
            pbEnviar = new PictureBox();
            pnlCabecalhoChatBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEnviar).BeginInit();
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
            txtMensagemUsuario.Location = new Point(251, 601);
            txtMensagemUsuario.Multiline = true;
            txtMensagemUsuario.Name = "txtMensagemUsuario";
            txtMensagemUsuario.PlaceholderText = "Digite aqui...";
            txtMensagemUsuario.Size = new Size(370, 36);
            txtMensagemUsuario.TabIndex = 0;
            // 
            // pbEnviar
            // 
            pbEnviar.Image = Properties.Resources.IconEnviar;
            pbEnviar.Location = new Point(627, 601);
            pbEnviar.Name = "pbEnviar";
            pbEnviar.Size = new Size(40, 36);
            pbEnviar.SizeMode = PictureBoxSizeMode.Zoom;
            pbEnviar.TabIndex = 2;
            pbEnviar.TabStop = false;
            pbEnviar.Click += pbEnviar_Click;
            // 
            // FormChatBot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 645);
            Controls.Add(pbEnviar);
            Controls.Add(txtMensagemUsuario);
            Controls.Add(flpConversaChatBot);
            Controls.Add(pnlCabecalhoChatBot);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormChatBot";
            Text = "FormChatBot";
            Load += FormChatBot_Load;
            pnlCabecalhoChatBot.ResumeLayout(false);
            pnlCabecalhoChatBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbEnviar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlCabecalhoChatBot;
        private PictureBox pictureBox1;
        private Label lblTecnBot;
        private FlowLayoutPanel flpConversaChatBot;
        private TextBox txtMensagemUsuario;
        private PictureBox pbEnviar;
    }
}