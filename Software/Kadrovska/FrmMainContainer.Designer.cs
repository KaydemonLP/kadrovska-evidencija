namespace Kadrovska
{
    partial class FrmMainContainer
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
            this.m_pnlNav = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnMyRequests = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnIncomingRequests = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.m_pnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_pnlNav
            // 
            this.m_pnlNav.AutoSize = true;
            this.m_pnlNav.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(127)))), ((int)(((byte)(166)))));
            this.m_pnlNav.Controls.Add(this.btnHome);
            this.m_pnlNav.Controls.Add(this.btnMyRequests);
            this.m_pnlNav.Controls.Add(this.btnProfile);
            this.m_pnlNav.Controls.Add(this.btnIncomingRequests);
            this.m_pnlNav.Controls.Add(this.btnUsers);
            this.m_pnlNav.Controls.Add(this.btnRecord);
            this.m_pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_pnlNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.m_pnlNav.Location = new System.Drawing.Point(0, 0);
            this.m_pnlNav.Margin = new System.Windows.Forms.Padding(0);
            this.m_pnlNav.Name = "m_pnlNav";
            this.m_pnlNav.Size = new System.Drawing.Size(100, 450);
            this.m_pnlNav.TabIndex = 1;
            // 
            // btnHome
            // 
            this.btnHome.AutoSize = true;
            this.btnHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(100, 33);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Početna";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.FrmMainContainer_NavClick);
            // 
            // btnMyRequests
            // 
            this.btnMyRequests.AutoSize = true;
            this.btnMyRequests.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMyRequests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(92)))), ((int)(((byte)(142)))));
            this.btnMyRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyRequests.FlatAppearance.BorderSize = 0;
            this.btnMyRequests.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.btnMyRequests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(56)))), ((int)(((byte)(102)))));
            this.btnMyRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyRequests.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMyRequests.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMyRequests.Location = new System.Drawing.Point(0, 33);
            this.btnMyRequests.Margin = new System.Windows.Forms.Padding(0);
            this.btnMyRequests.Name = "btnMyRequests";
            this.btnMyRequests.Size = new System.Drawing.Size(100, 56);
            this.btnMyRequests.TabIndex = 1;
            this.btnMyRequests.Text = "Moji\r\nzahtjevi";
            this.btnMyRequests.UseVisualStyleBackColor = false;
            this.btnMyRequests.Click += new System.EventHandler(this.FrmMainContainer_NavClick);
            // 
            // btnProfile
            // 
            this.btnProfile.AutoSize = true;
            this.btnProfile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(92)))), ((int)(((byte)(142)))));
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(56)))), ((int)(((byte)(102)))));
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProfile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProfile.Location = new System.Drawing.Point(0, 89);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(0);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(100, 56);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "Moji\r\npodatci";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.FrmMainContainer_NavClick);
            // 
            // btnIncomingRequests
            // 
            this.btnIncomingRequests.AutoSize = true;
            this.btnIncomingRequests.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnIncomingRequests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(92)))), ((int)(((byte)(142)))));
            this.btnIncomingRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIncomingRequests.FlatAppearance.BorderSize = 0;
            this.btnIncomingRequests.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.btnIncomingRequests.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(56)))), ((int)(((byte)(102)))));
            this.btnIncomingRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncomingRequests.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIncomingRequests.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnIncomingRequests.Location = new System.Drawing.Point(0, 145);
            this.btnIncomingRequests.Margin = new System.Windows.Forms.Padding(0);
            this.btnIncomingRequests.Name = "btnIncomingRequests";
            this.btnIncomingRequests.Size = new System.Drawing.Size(100, 56);
            this.btnIncomingRequests.TabIndex = 3;
            this.btnIncomingRequests.Text = "Dolazni\r\nZahtjevi";
            this.btnIncomingRequests.UseVisualStyleBackColor = false;
            this.btnIncomingRequests.Click += new System.EventHandler(this.FrmMainContainer_NavClick);
            // 
            // btnUsers
            // 
            this.btnUsers.AutoSize = true;
            this.btnUsers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(92)))), ((int)(((byte)(142)))));
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(56)))), ((int)(((byte)(102)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUsers.Location = new System.Drawing.Point(0, 201);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(100, 56);
            this.btnUsers.TabIndex = 4;
            this.btnUsers.Text = "Korisnički\r\nračuni";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.FrmMainContainer_NavClick);
            // 
            // btnRecord
            // 
            this.btnRecord.AutoSize = true;
            this.btnRecord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(92)))), ((int)(((byte)(142)))));
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecord.FlatAppearance.BorderSize = 0;
            this.btnRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(76)))), ((int)(((byte)(130)))));
            this.btnRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(56)))), ((int)(((byte)(102)))));
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRecord.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRecord.Location = new System.Drawing.Point(0, 257);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(0);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(100, 56);
            this.btnRecord.TabIndex = 5;
            this.btnRecord.Text = "Evidencija\r\nodsustva";
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.FrmMainContainer_NavClick);
            // 
            // FrmMainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m_pnlNav);
            this.IsMdiContainer = true;
            this.Name = "FrmMainContainer";
            this.Text = "Upravitelj kadrovskih zahtjeva";
            this.Load += new System.EventHandler(this.FrmMainContainer_Load);
            this.m_pnlNav.ResumeLayout(false);
            this.m_pnlNav.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel m_pnlNav;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnMyRequests;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnIncomingRequests;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnRecord;
    }
}