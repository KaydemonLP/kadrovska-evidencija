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
            this.m_pnlMain = new System.Windows.Forms.FlowLayoutPanel();
            this.m_pnlNav = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.m_pnlBody = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_pnlMain.SuspendLayout();
            this.m_pnlNav.SuspendLayout();
            this.m_pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlMain
            // 
            this.m_pnlMain.AutoScroll = true;
            this.m_pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_pnlMain.Controls.Add(this.m_pnlNav);
            this.m_pnlMain.Controls.Add(this.m_pnlBody);
            this.m_pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlMain.Location = new System.Drawing.Point(0, 0);
            this.m_pnlMain.Name = "m_pnlMain";
            this.m_pnlMain.Size = new System.Drawing.Size(800, 450);
            this.m_pnlMain.TabIndex = 2;
            this.m_pnlMain.WrapContents = false;
            // 
            // m_pnlNav
            // 
            this.m_pnlNav.AutoSize = true;
            this.m_pnlNav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_pnlNav.Controls.Add(this.button1);
            this.m_pnlNav.Controls.Add(this.button2);
            this.m_pnlNav.Controls.Add(this.button3);
            this.m_pnlNav.Controls.Add(this.button4);
            this.m_pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_pnlNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.m_pnlNav.Location = new System.Drawing.Point(3, 3);
            this.m_pnlNav.Name = "m_pnlNav";
            this.m_pnlNav.Size = new System.Drawing.Size(117, 208);
            this.m_pnlNav.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 107);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(3, 159);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 46);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // m_pnlBody
            // 
            this.m_pnlBody.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_pnlBody.Controls.Add(this.label1);
            this.m_pnlBody.Controls.Add(this.flowLayoutPanel1);
            this.m_pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pnlBody.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.m_pnlBody.Location = new System.Drawing.Point(126, 3);
            this.m_pnlBody.Name = "m_pnlBody";
            this.m_pnlBody.Size = new System.Drawing.Size(200, 208);
            this.m_pnlBody.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(100, 100);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // FrmHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_pnlMain);
            this.Name = "FrmHomePage";
            this.Text = "FrmHomePage";
            this.Load += new System.EventHandler(this.FrmHomePage_Load);
            this.m_pnlMain.ResumeLayout(false);
            this.m_pnlMain.PerformLayout();
            this.m_pnlNav.ResumeLayout(false);
            this.m_pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel m_pnlMain;
        private System.Windows.Forms.FlowLayoutPanel m_pnlNav;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FlowLayoutPanel m_pnlBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}