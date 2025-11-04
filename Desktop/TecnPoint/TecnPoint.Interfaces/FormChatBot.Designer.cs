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
            txtUsuario = new TextBox();
            pbEnviar = new PictureBox();
            pnlCabecalhoChatBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbEnviar).BeginInit();
            SuspendLayout();
            // 
            // pnlCabecalhoChatBot
            // 
            pnlCabecalhoChatBot.BackColor = Color.FromArgb(126, 105, 171);
            pnlCabecalhoChatBot.Controls.Add(pictureBox1);
            pnlCabecalhoChatBot.Controls.Add(lblTecnBot);
            pnlCabecalhoChatBot.Location = new Point(0, 0);
            pnlCabecalhoChatBot.Name = "pnlCabecalhoChatBot";
            pnlCabecalhoChatBot.Size = new Size(896, 96);
            pnlCabecalhoChatBot.TabIndex = 0;
            // 
            // pictureBox1
            // 
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
            flpConversaChatBot.Location = new Point(0, 94);
            flpConversaChatBot.Name = "flpConversaChatBot";
            flpConversaChatBot.Size = new Size(896, 501);
            flpConversaChatBot.TabIndex = 1;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(251, 601);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Digite aqui...";
            txtUsuario.Size = new Size(370, 36);
            txtUsuario.TabIndex = 0;
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
            // 
            // FormChatBot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 645);
            Controls.Add(pbEnviar);
            Controls.Add(txtUsuario);
            Controls.Add(flpConversaChatBot);
            Controls.Add(pnlCabecalhoChatBot);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormChatBot";
            Text = "FormChatBot";
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
        private TextBox txtUsuario;
        private PictureBox pbEnviar;
    }
}