namespace GS_ABATTOIRE.Gestion_Des_Ventes
{
    partial class Form_Travail
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
            this.autre_Travail1 = new GS_ABATTOIRE.Autre_Travail.Autre_Travail();
            this.SuspendLayout();
            // 
            // autre_Travail1
            // 
            this.autre_Travail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autre_Travail1.Location = new System.Drawing.Point(0, 0);
            this.autre_Travail1.Name = "autre_Travail1";
            this.autre_Travail1.Size = new System.Drawing.Size(1153, 694);
            this.autre_Travail1.TabIndex = 0;
            // 
            // Form_Travail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 694);
            this.Controls.Add(this.autre_Travail1);
            this.Name = "Form_Travail";
            this.Text = "Form_Travail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Autre_Travail.Autre_Travail autre_Travail1;
    }
}