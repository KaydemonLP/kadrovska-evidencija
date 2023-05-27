namespace Kadrovska
{
    partial class FrmMyRequests
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
			this.pnlBodyAndHeader = new System.Windows.Forms.SplitContainer();
			this.m_lblWelcome = new System.Windows.Forms.Label();
			this.pnlDisplayAndAdd = new System.Windows.Forms.SplitContainer();
			this.pnlDisplayAndButtons = new System.Windows.Forms.SplitContainer();
			this.dgvZahtjevi = new System.Windows.Forms.DataGridView();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnErase = new System.Windows.Forms.Button();
			this.pnlAddAndButtons = new System.Windows.Forms.SplitContainer();
			this.pnlAddTable = new System.Windows.Forms.TableLayoutPanel();
			this.lblEndAbsenseInput = new System.Windows.Forms.Label();
			this.lblStartAbsenseInput = new System.Windows.Forms.Label();
			this.Description = new System.Windows.Forms.Label();
			this.lblAbsenseEnd = new System.Windows.Forms.Label();
			this.lblAbsenseStart = new System.Windows.Forms.Label();
			this.lblInputType = new System.Windows.Forms.Label();
			this.cboType = new Kadrovska.components.DockableComboBox();
			this.txtOpis = new System.Windows.Forms.TextBox();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.cldStartAbsense = new System.Windows.Forms.MonthCalendar();
			this.cldEndAbsense = new System.Windows.Forms.MonthCalendar();
			((System.ComponentModel.ISupportInitialize)(this.pnlBodyAndHeader)).BeginInit();
			this.pnlBodyAndHeader.Panel1.SuspendLayout();
			this.pnlBodyAndHeader.Panel2.SuspendLayout();
			this.pnlBodyAndHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlDisplayAndAdd)).BeginInit();
			this.pnlDisplayAndAdd.Panel1.SuspendLayout();
			this.pnlDisplayAndAdd.Panel2.SuspendLayout();
			this.pnlDisplayAndAdd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pnlDisplayAndButtons)).BeginInit();
			this.pnlDisplayAndButtons.Panel1.SuspendLayout();
			this.pnlDisplayAndButtons.Panel2.SuspendLayout();
			this.pnlDisplayAndButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvZahtjevi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pnlAddAndButtons)).BeginInit();
			this.pnlAddAndButtons.Panel1.SuspendLayout();
			this.pnlAddAndButtons.Panel2.SuspendLayout();
			this.pnlAddAndButtons.SuspendLayout();
			this.pnlAddTable.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlBodyAndHeader
			// 
			this.pnlBodyAndHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBodyAndHeader.IsSplitterFixed = true;
			this.pnlBodyAndHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlBodyAndHeader.Name = "pnlBodyAndHeader";
			this.pnlBodyAndHeader.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlBodyAndHeader.Panel1
			// 
			this.pnlBodyAndHeader.Panel1.Controls.Add(this.m_lblWelcome);
			// 
			// pnlBodyAndHeader.Panel2
			// 
			this.pnlBodyAndHeader.Panel2.Controls.Add(this.pnlDisplayAndAdd);
			this.pnlBodyAndHeader.Size = new System.Drawing.Size(855, 510);
			this.pnlBodyAndHeader.SplitterDistance = 49;
			this.pnlBodyAndHeader.TabIndex = 7;
			// 
			// m_lblWelcome
			// 
			this.m_lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblWelcome.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.m_lblWelcome.Location = new System.Drawing.Point(0, 0);
			this.m_lblWelcome.Name = "m_lblWelcome";
			this.m_lblWelcome.Size = new System.Drawing.Size(855, 49);
			this.m_lblWelcome.TabIndex = 7;
			this.m_lblWelcome.Text = "Moji Zahtjevi";
			// 
			// pnlDisplayAndAdd
			// 
			this.pnlDisplayAndAdd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDisplayAndAdd.IsSplitterFixed = true;
			this.pnlDisplayAndAdd.Location = new System.Drawing.Point(0, 0);
			this.pnlDisplayAndAdd.Name = "pnlDisplayAndAdd";
			this.pnlDisplayAndAdd.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlDisplayAndAdd.Panel1
			// 
			this.pnlDisplayAndAdd.Panel1.Controls.Add(this.pnlDisplayAndButtons);
			this.pnlDisplayAndAdd.Panel1.Padding = new System.Windows.Forms.Padding(10);
			// 
			// pnlDisplayAndAdd.Panel2
			// 
			this.pnlDisplayAndAdd.Panel2.Controls.Add(this.pnlAddAndButtons);
			this.pnlDisplayAndAdd.Panel2.Padding = new System.Windows.Forms.Padding(10);
			this.pnlDisplayAndAdd.Size = new System.Drawing.Size(855, 457);
			this.pnlDisplayAndAdd.SplitterDistance = 322;
			this.pnlDisplayAndAdd.TabIndex = 0;
			// 
			// pnlDisplayAndButtons
			// 
			this.pnlDisplayAndButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDisplayAndButtons.Location = new System.Drawing.Point(10, 10);
			this.pnlDisplayAndButtons.Name = "pnlDisplayAndButtons";
			this.pnlDisplayAndButtons.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlDisplayAndButtons.Panel1
			// 
			this.pnlDisplayAndButtons.Panel1.Controls.Add(this.dgvZahtjevi);
			// 
			// pnlDisplayAndButtons.Panel2
			// 
			this.pnlDisplayAndButtons.Panel2.Controls.Add(this.btnEdit);
			this.pnlDisplayAndButtons.Panel2.Controls.Add(this.btnErase);
			this.pnlDisplayAndButtons.Size = new System.Drawing.Size(835, 302);
			this.pnlDisplayAndButtons.SplitterDistance = 266;
			this.pnlDisplayAndButtons.TabIndex = 1;
			// 
			// dgvZahtjevi
			// 
			this.dgvZahtjevi.AllowUserToAddRows = false;
			this.dgvZahtjevi.AllowUserToDeleteRows = false;
			this.dgvZahtjevi.AllowUserToOrderColumns = true;
			this.dgvZahtjevi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvZahtjevi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgvZahtjevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvZahtjevi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvZahtjevi.Location = new System.Drawing.Point(0, 0);
			this.dgvZahtjevi.Name = "dgvZahtjevi";
			this.dgvZahtjevi.ReadOnly = true;
			this.dgvZahtjevi.RowHeadersVisible = false;
			this.dgvZahtjevi.ShowEditingIcon = false;
			this.dgvZahtjevi.Size = new System.Drawing.Size(835, 266);
			this.dgvZahtjevi.TabIndex = 0;
			this.dgvZahtjevi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvZahtjevi_CellFormatting);
			this.dgvZahtjevi.CurrentCellChanged += new System.EventHandler(this.dgvZahtjevi_CurrentCellChanged);
			// 
			// btnEdit
			// 
			this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnEdit.Enabled = false;
			this.btnEdit.Location = new System.Drawing.Point(685, 0);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 32);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Uredi";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnErase
			// 
			this.btnErase.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnErase.Enabled = false;
			this.btnErase.Location = new System.Drawing.Point(760, 0);
			this.btnErase.Name = "btnErase";
			this.btnErase.Size = new System.Drawing.Size(75, 32);
			this.btnErase.TabIndex = 0;
			this.btnErase.Text = "Izbriši";
			this.btnErase.UseVisualStyleBackColor = true;
			this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
			// 
			// pnlAddAndButtons
			// 
			this.pnlAddAndButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlAddAndButtons.IsSplitterFixed = true;
			this.pnlAddAndButtons.Location = new System.Drawing.Point(10, 10);
			this.pnlAddAndButtons.Margin = new System.Windows.Forms.Padding(0);
			this.pnlAddAndButtons.Name = "pnlAddAndButtons";
			this.pnlAddAndButtons.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// pnlAddAndButtons.Panel1
			// 
			this.pnlAddAndButtons.Panel1.Controls.Add(this.pnlAddTable);
			// 
			// pnlAddAndButtons.Panel2
			// 
			this.pnlAddAndButtons.Panel2.Controls.Add(this.btnSubmit);
			this.pnlAddAndButtons.Size = new System.Drawing.Size(835, 111);
			this.pnlAddAndButtons.SplitterDistance = 79;
			this.pnlAddAndButtons.TabIndex = 0;
			// 
			// pnlAddTable
			// 
			this.pnlAddTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
			this.pnlAddTable.ColumnCount = 4;
			this.pnlAddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.pnlAddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.pnlAddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.pnlAddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.pnlAddTable.Controls.Add(this.lblEndAbsenseInput, 0, 1);
			this.pnlAddTable.Controls.Add(this.lblStartAbsenseInput, 0, 1);
			this.pnlAddTable.Controls.Add(this.Description, 3, 0);
			this.pnlAddTable.Controls.Add(this.lblAbsenseEnd, 2, 0);
			this.pnlAddTable.Controls.Add(this.lblAbsenseStart, 1, 0);
			this.pnlAddTable.Controls.Add(this.lblInputType, 0, 0);
			this.pnlAddTable.Controls.Add(this.cboType, 0, 1);
			this.pnlAddTable.Controls.Add(this.txtOpis, 3, 1);
			this.pnlAddTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlAddTable.Location = new System.Drawing.Point(0, 0);
			this.pnlAddTable.Name = "pnlAddTable";
			this.pnlAddTable.RowCount = 2;
			this.pnlAddTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.pnlAddTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.pnlAddTable.Size = new System.Drawing.Size(835, 79);
			this.pnlAddTable.TabIndex = 0;
			// 
			// lblEndAbsenseInput
			// 
			this.lblEndAbsenseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEndAbsenseInput.AutoSize = true;
			this.lblEndAbsenseInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblEndAbsenseInput.Location = new System.Drawing.Point(339, 33);
			this.lblEndAbsenseInput.Name = "lblEndAbsenseInput";
			this.lblEndAbsenseInput.Size = new System.Drawing.Size(159, 44);
			this.lblEndAbsenseInput.TabIndex = 6;
			this.lblEndAbsenseInput.Text = "--/--/--";
			this.lblEndAbsenseInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblEndAbsenseInput.Click += new System.EventHandler(this.lblEndAbsenseInput_Click);
			// 
			// lblStartAbsenseInput
			// 
			this.lblStartAbsenseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblStartAbsenseInput.AutoSize = true;
			this.lblStartAbsenseInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblStartAbsenseInput.Location = new System.Drawing.Point(172, 33);
			this.lblStartAbsenseInput.Name = "lblStartAbsenseInput";
			this.lblStartAbsenseInput.Size = new System.Drawing.Size(159, 44);
			this.lblStartAbsenseInput.TabIndex = 5;
			this.lblStartAbsenseInput.Text = "--/--/--";
			this.lblStartAbsenseInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblStartAbsenseInput.Click += new System.EventHandler(this.lblStartAbsenseInput_Click);
			// 
			// Description
			// 
			this.Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Description.AutoSize = true;
			this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Description.Location = new System.Drawing.Point(506, 2);
			this.Description.Name = "Description";
			this.Description.Size = new System.Drawing.Size(324, 29);
			this.Description.TabIndex = 3;
			this.Description.Text = "Opis";
			this.Description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblAbsenseEnd
			// 
			this.lblAbsenseEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAbsenseEnd.AutoSize = true;
			this.lblAbsenseEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblAbsenseEnd.Location = new System.Drawing.Point(339, 2);
			this.lblAbsenseEnd.Name = "lblAbsenseEnd";
			this.lblAbsenseEnd.Size = new System.Drawing.Size(159, 29);
			this.lblAbsenseEnd.TabIndex = 2;
			this.lblAbsenseEnd.Text = "Kraj odsustva";
			this.lblAbsenseEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblAbsenseStart
			// 
			this.lblAbsenseStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAbsenseStart.AutoSize = true;
			this.lblAbsenseStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblAbsenseStart.Location = new System.Drawing.Point(172, 2);
			this.lblAbsenseStart.Name = "lblAbsenseStart";
			this.lblAbsenseStart.Size = new System.Drawing.Size(159, 29);
			this.lblAbsenseStart.TabIndex = 1;
			this.lblAbsenseStart.Text = "Početak odsustva";
			this.lblAbsenseStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblInputType
			// 
			this.lblInputType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInputType.AutoSize = true;
			this.lblInputType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblInputType.Location = new System.Drawing.Point(5, 2);
			this.lblInputType.Name = "lblInputType";
			this.lblInputType.Size = new System.Drawing.Size(159, 29);
			this.lblInputType.TabIndex = 0;
			this.lblInputType.Text = "Vrsta Zahtjeva";
			this.lblInputType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cboType
			// 
			this.cboType.DisplayMember = "m_strName";
			this.cboType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cboType.FormattingEnabled = true;
			this.cboType.ItemHeight = 38;
			this.cboType.Location = new System.Drawing.Point(2, 33);
			this.cboType.Margin = new System.Windows.Forms.Padding(0);
			this.cboType.Name = "cboType";
			this.cboType.Size = new System.Drawing.Size(165, 44);
			this.cboType.TabIndex = 4;
			// 
			// txtOpis
			// 
			this.txtOpis.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOpis.Location = new System.Drawing.Point(503, 33);
			this.txtOpis.Margin = new System.Windows.Forms.Padding(0);
			this.txtOpis.Multiline = true;
			this.txtOpis.Name = "txtOpis";
			this.txtOpis.Size = new System.Drawing.Size(330, 44);
			this.txtOpis.TabIndex = 7;
			// 
			// btnSubmit
			// 
			this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSubmit.Location = new System.Drawing.Point(734, 0);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(101, 28);
			this.btnSubmit.TabIndex = 2;
			this.btnSubmit.Text = "Stvori Zahtijev";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// cldStartAbsense
			// 
			this.cldStartAbsense.Location = new System.Drawing.Point(264, 471);
			this.cldStartAbsense.MaxSelectionCount = 1;
			this.cldStartAbsense.Name = "cldStartAbsense";
			this.cldStartAbsense.TabIndex = 8;
			this.cldStartAbsense.Visible = false;
			this.cldStartAbsense.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cldStartAbsense_DateSelected);
			this.cldStartAbsense.Leave += new System.EventHandler(this.cld_Leave);
			// 
			// cldEndAbsense
			// 
			this.cldEndAbsense.Location = new System.Drawing.Point(505, 472);
			this.cldEndAbsense.MaxSelectionCount = 1;
			this.cldEndAbsense.Name = "cldEndAbsense";
			this.cldEndAbsense.TabIndex = 9;
			this.cldEndAbsense.Visible = false;
			this.cldEndAbsense.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cldEndAbsense_DateSelected);
			this.cldEndAbsense.Leave += new System.EventHandler(this.cld_Leave);
			// 
			// FrmMyRequests
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(855, 510);
			this.Controls.Add(this.cldEndAbsense);
			this.Controls.Add(this.cldStartAbsense);
			this.Controls.Add(this.pnlBodyAndHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FrmMyRequests";
			this.Text = "Upravitelj Kadrovskih Zahtjeva";
			this.Load += new System.EventHandler(this.FrmMyRequests_Load);
			this.pnlBodyAndHeader.Panel1.ResumeLayout(false);
			this.pnlBodyAndHeader.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlBodyAndHeader)).EndInit();
			this.pnlBodyAndHeader.ResumeLayout(false);
			this.pnlDisplayAndAdd.Panel1.ResumeLayout(false);
			this.pnlDisplayAndAdd.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlDisplayAndAdd)).EndInit();
			this.pnlDisplayAndAdd.ResumeLayout(false);
			this.pnlDisplayAndButtons.Panel1.ResumeLayout(false);
			this.pnlDisplayAndButtons.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlDisplayAndButtons)).EndInit();
			this.pnlDisplayAndButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvZahtjevi)).EndInit();
			this.pnlAddAndButtons.Panel1.ResumeLayout(false);
			this.pnlAddAndButtons.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlAddAndButtons)).EndInit();
			this.pnlAddAndButtons.ResumeLayout(false);
			this.pnlAddTable.ResumeLayout(false);
			this.pnlAddTable.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer pnlBodyAndHeader;
        private System.Windows.Forms.Label m_lblWelcome;
        private System.Windows.Forms.SplitContainer pnlDisplayAndAdd;
        private System.Windows.Forms.DataGridView dgvZahtjevi;
		private System.Windows.Forms.SplitContainer pnlAddAndButtons;
		private System.Windows.Forms.TableLayoutPanel pnlAddTable;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Label lblInputType;
		private System.Windows.Forms.Label Description;
		private System.Windows.Forms.Label lblAbsenseEnd;
		private System.Windows.Forms.Label lblAbsenseStart;
		private Kadrovska.components.DockableComboBox cboType;
		private System.Windows.Forms.MonthCalendar cldStartAbsense;
		private System.Windows.Forms.Label lblEndAbsenseInput;
		private System.Windows.Forms.Label lblStartAbsenseInput;
		private System.Windows.Forms.MonthCalendar cldEndAbsense;
		private System.Windows.Forms.TextBox txtOpis;
		private System.Windows.Forms.SplitContainer pnlDisplayAndButtons;
		private System.Windows.Forms.Button btnErase;
		private System.Windows.Forms.Button btnEdit;
	}
}