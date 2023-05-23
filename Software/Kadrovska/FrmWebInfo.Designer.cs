namespace Kadrovska
{
    partial class FrmWebInfo
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
            this.debug = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(88, 59);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(35, 13);
            this.debug.TabIndex = 0;
            this.debug.Text = "label1";
            // 
            // FrmWebInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.debug);
            this.Name = "FrmWebInfo";
            this.Text = "FrmWebInfo";
            this.Load += new System.EventHandler(this.FrmWebInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label debug;
    }
}