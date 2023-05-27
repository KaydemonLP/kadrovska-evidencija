namespace Kadrovska
{
    partial class FrmHomePage
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.m_lblWelcome = new System.Windows.Forms.Label();
			this.btnGDPR = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.m_lblWelcome);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnGDPR);
			this.splitContainer1.Size = new System.Drawing.Size(800, 450);
			this.splitContainer1.SplitterDistance = 96;
			this.splitContainer1.TabIndex = 7;
			// 
			// m_lblWelcome
			// 
			this.m_lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblWelcome.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.m_lblWelcome.Location = new System.Drawing.Point(0, 0);
			this.m_lblWelcome.Name = "m_lblWelcome";
			this.m_lblWelcome.Size = new System.Drawing.Size(800, 96);
			this.m_lblWelcome.TabIndex = 7;
			this.m_lblWelcome.Text = "Dobro došli\r\n";
			// 
			// btnGDPR
			// 
			this.btnGDPR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGDPR.BackColor = System.Drawing.Color.Gray;
			this.btnGDPR.FlatAppearance.BorderSize = 0;
			this.btnGDPR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnGDPR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
			this.btnGDPR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGDPR.Font = new System.Drawing.Font("Calibri", 8.25F);
			this.btnGDPR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnGDPR.Location = new System.Drawing.Point(690, 300);
			this.btnGDPR.Name = "btnGDPR";
			this.btnGDPR.Size = new System.Drawing.Size(98, 38);
			this.btnGDPR.TabIndex = 0;
			this.btnGDPR.Text = "Zahtjevaj GDPR\r\npodatke";
			this.btnGDPR.UseVisualStyleBackColor = false;
			this.btnGDPR.Click += new System.EventHandler(this.btnGDPR_Click);
			// 
			// FrmHomePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmHomePage";
			this.Text = "Upravitelj Kadrovskih Zahtjeva";
			this.Load += new System.EventHandler(this.FrmHomePage_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label m_lblWelcome;
        private System.Windows.Forms.Button btnGDPR;
    }
}