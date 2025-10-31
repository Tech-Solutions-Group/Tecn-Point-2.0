namespace TecnPoint.Interfaces
{
    partial class FormAcompanharChamados
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
            panelDetalhesChamado = new Panel();
            flpPanelCardsChamados = new FlowLayoutPanel();
            panelDetalhesChamado.SuspendLayout();
            SuspendLayout();
            // 
            // panelDetalhesChamado
            // 
            panelDetalhesChamado.Controls.Add(flpPanelCardsChamados);
            panelDetalhesChamado.Location = new Point(0, 0);
            panelDetalhesChamado.Name = "panelDetalhesChamado";
            panelDetalhesChamado.Size = new Size(876, 620);
            panelDetalhesChamado.TabIndex = 0;
            // 
            // flpPanelCardsChamados
            // 
            flpPanelCardsChamados.AutoScroll = true;
            flpPanelCardsChamados.FlowDirection = FlowDirection.TopDown;
            flpPanelCardsChamados.Location = new Point(0, 0);
            flpPanelCardsChamados.Name = "flpPanelCardsChamados";
            flpPanelCardsChamados.Size = new Size(876, 620);
            flpPanelCardsChamados.TabIndex = 0;
            flpPanelCardsChamados.WrapContents = false;
            // 
            // FormAcompanharChamados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 620);
            Controls.Add(panelDetalhesChamado);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAcompanharChamados";
            Text = "FormAcompanharChamados";
            panelDetalhesChamado.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDetalhesChamado;
        public FlowLayoutPanel flpPanelCardsChamados;
    }
}