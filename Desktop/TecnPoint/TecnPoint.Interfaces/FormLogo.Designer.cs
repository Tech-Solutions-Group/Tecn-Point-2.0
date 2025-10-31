namespace TecnPoint.Interfaces
{
    partial class FormLogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogo));
            pictureBox1 = new PictureBox();
            lblNomeFrmLogo = new Label();
            lblEmailFrmLogo = new Label();
            lblTipoUsuarioFrmLogo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(351, 154);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 176);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblNomeFrmLogo
            // 
            lblNomeFrmLogo.BackColor = Color.Transparent;
            lblNomeFrmLogo.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            lblNomeFrmLogo.ForeColor = SystemColors.ControlLightLight;
            lblNomeFrmLogo.Location = new Point(231, 383);
            lblNomeFrmLogo.Name = "lblNomeFrmLogo";
            lblNomeFrmLogo.Size = new Size(413, 22);
            lblNomeFrmLogo.TabIndex = 1;
            lblNomeFrmLogo.Text = "Nome do usuário";
            lblNomeFrmLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmailFrmLogo
            // 
            lblEmailFrmLogo.BackColor = Color.Transparent;
            lblEmailFrmLogo.Font = new Font("Consolas", 14.25F, FontStyle.Bold);
            lblEmailFrmLogo.ForeColor = SystemColors.ControlLightLight;
            lblEmailFrmLogo.Location = new Point(231, 425);
            lblEmailFrmLogo.Name = "lblEmailFrmLogo";
            lblEmailFrmLogo.Size = new Size(413, 22);
            lblEmailFrmLogo.TabIndex = 2;
            lblEmailFrmLogo.Text = "Email do usuário";
            lblEmailFrmLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTipoUsuarioFrmLogo
            // 
            lblTipoUsuarioFrmLogo.BackColor = Color.Transparent;
            lblTipoUsuarioFrmLogo.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoUsuarioFrmLogo.ForeColor = SystemColors.ControlLightLight;
            lblTipoUsuarioFrmLogo.Location = new Point(231, 338);
            lblTipoUsuarioFrmLogo.Name = "lblTipoUsuarioFrmLogo";
            lblTipoUsuarioFrmLogo.Size = new Size(413, 28);
            lblTipoUsuarioFrmLogo.TabIndex = 3;
            lblTipoUsuarioFrmLogo.Text = "Tipo do usuário";
            lblTipoUsuarioFrmLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormLogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(876, 620);
            Controls.Add(lblTipoUsuarioFrmLogo);
            Controls.Add(lblEmailFrmLogo);
            Controls.Add(lblNomeFrmLogo);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogo";
            Text = "FormLogo";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblNomeFrmLogo;
        private Label lblEmailFrmLogo;
        private Label lblTipoUsuarioFrmLogo;
    }
}