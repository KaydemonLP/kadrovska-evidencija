namespace Kadrovska
{
	partial class FrmEditRequest
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
			this.cldEndAbsense = new System.Windows.Forms.MonthCalendar();
			this.cldStartAbsense = new System.Windows.Forms.MonthCalendar();
			this.pnlAddAndButtons = new System.Windows.Forms.SplitContainer();
			this.pnlAddTable = new System.Windows.Forms.TableLayoutPanel();
			this.lblEndAbsenseInput = new System.Windows.Forms.Label();
			this.lblStartAbsenseInput = new System.Windows.Forms.Label();
			this.Description = new System.Windows.Forms.Label();
			this.lblAbsenseEnd = new System.Windows.Forms.Label();
			this.lblAbsenseStart = new System.Windows.Forms.Label();
			this.lblInputType = new System.Windows.Forms.Label();
			this.txtOpis = new System.Windows.Forms.TextBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.cboType = new Kadrovska.components.DockableComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pnlAddAndButtons)).BeginInit();
			this.pnlAddAndButtons.Panel1.SuspendLayout();
			this.pnlAddAndButtons.Panel2.SuspendLayout();
			this.pnlAddAndButtons.SuspendLayout();
			this.pnlAddTable.SuspendLayout();
			this.SuspendLayout();
			// 
			// cldEndAbsense
			// 
			this.cldEndAbsense.Location = new System.Drawing.Point(322, 3);
			this.cldEndAbsense.MaxSelectionCount = 1;
			this.cldEndAbsense.Name = "cldEndAbsense";
			this.cldEndAbsense.TabIndex = 12;
			this.cldEndAbsense.Visible = false;
			this.cldEndAbsense.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cldEndAbsense_DateSelected);
			this.cldEndAbsense.Leave += new System.EventHandler(this.cld_Leave);
			// 
			// cldStartAbsense
			// 
			this.cldStartAbsense.Location = new System.Drawing.Point(81, 2);
			this.cldStartAbsense.MaxSelectionCount = 1;
			this.cldStartAbsense.Name = "cldStartAbsense";
			this.cldStartAbsense.TabIndex = 11;
			this.cldStartAbsense.Visible = false;
			this.cldStartAbsense.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cldStartAbsense_DateSelected);
			this.cldStartAbsense.Leave += new System.EventHandler(this.cld_Leave);
			// 
			// pnlAddAndButtons
			// 
			this.pnlAddAndButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlAddAndButtons.IsSplitterFixed = true;
			this.pnlAddAndButtons.Location = new System.Drawing.Point(0, 0);
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
			this.pnlAddAndButtons.Panel2.Controls.Add(this.btnReset);
			this.pnlAddAndButtons.Panel2.Controls.Add(this.btnEdit);
			this.pnlAddAndButtons.Size = new System.Drawing.Size(796, 200);
			this.pnlAddAndButtons.SplitterDistance = 167;
			this.pnlAddAndButtons.TabIndex = 10;
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
			this.pnlAddTable.Size = new System.Drawing.Size(796, 167);
			this.pnlAddTable.TabIndex = 0;
			// 
			// lblEndAbsenseInput
			// 
			this.lblEndAbsenseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEndAbsenseInput.AutoSize = true;
			this.lblEndAbsenseInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblEndAbsenseInput.Location = new System.Drawing.Point(323, 68);
			this.lblEndAbsenseInput.Name = "lblEndAbsenseInput";
			this.lblEndAbsenseInput.Size = new System.Drawing.Size(151, 97);
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
			this.lblStartAbsenseInput.Location = new System.Drawing.Point(164, 68);
			this.lblStartAbsenseInput.Name = "lblStartAbsenseInput";
			this.lblStartAbsenseInput.Size = new System.Drawing.Size(151, 97);
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
			this.Description.Location = new System.Drawing.Point(482, 2);
			this.Description.Name = "Description";
			this.Description.Size = new System.Drawing.Size(309, 64);
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
			this.lblAbsenseEnd.Location = new System.Drawing.Point(323, 2);
			this.lblAbsenseEnd.Name = "lblAbsenseEnd";
			this.lblAbsenseEnd.Size = new System.Drawing.Size(151, 64);
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
			this.lblAbsenseStart.Location = new System.Drawing.Point(164, 2);
			this.lblAbsenseStart.Name = "lblAbsenseStart";
			this.lblAbsenseStart.Size = new System.Drawing.Size(151, 64);
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
			this.lblInputType.Size = new System.Drawing.Size(151, 64);
			this.lblInputType.TabIndex = 0;
			this.lblInputType.Text = "Vrsta Zahtjeva";
			this.lblInputType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtOpis
			// 
			this.txtOpis.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOpis.Location = new System.Drawing.Point(479, 68);
			this.txtOpis.Margin = new System.Windows.Forms.Padding(0);
			this.txtOpis.Multiline = true;
			this.txtOpis.Name = "txtOpis";
			this.txtOpis.Size = new System.Drawing.Size(315, 97);
			this.txtOpis.TabIndex = 7;
			// 
			// btnReset
			// 
			this.btnReset.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnReset.Location = new System.Drawing.Point(594, 0);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(101, 29);
			this.btnReset.TabIndex = 3;
			this.btnReset.Text = "Vrati početno";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnEdit.Location = new System.Drawing.Point(695, 0);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(101, 29);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Uredi zahtjev";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// cboType
			// 
			this.cboType.DisplayMember = "m_strName";
			this.cboType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cboType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cboType.FormattingEnabled = true;
			this.cboType.ItemHeight = 91;
			this.cboType.Location = new System.Drawing.Point(2, 68);
			this.cboType.Margin = new System.Windows.Forms.Padding(0);
			this.cboType.Name = "cboType";
			this.cboType.Size = new System.Drawing.Size(157, 97);
			this.cboType.TabIndex = 4;
			// 
			// FrmEditRequest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(796, 200);
			this.Controls.Add(this.cldEndAbsense);
			this.Controls.Add(this.cldStartAbsense);
			this.Controls.Add(this.pnlAddAndButtons);
			this.Name = "FrmEditRequest";
			this.Text = "Edit Request";
			this.Load += new System.EventHandler(this.FrmEditRequest_Load);
			this.pnlAddAndButtons.Panel1.ResumeLayout(false);
			this.pnlAddAndButtons.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pnlAddAndButtons)).EndInit();
			this.pnlAddAndButtons.ResumeLayout(false);
			this.pnlAddTable.ResumeLayout(false);
			this.pnlAddTable.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MonthCalendar cldEndAbsense;
		private System.Windows.Forms.MonthCalendar cldStartAbsense;
		private System.Windows.Forms.SplitContainer pnlAddAndButtons;
		private System.Windows.Forms.TableLayoutPanel pnlAddTable;
		private System.Windows.Forms.Label lblEndAbsenseInput;
		private System.Windows.Forms.Label lblStartAbsenseInput;
		private System.Windows.Forms.Label Description;
		private System.Windows.Forms.Label lblAbsenseEnd;
		private System.Windows.Forms.Label lblAbsenseStart;
		private System.Windows.Forms.Label lblInputType;
		private components.DockableComboBox cboType;
		private System.Windows.Forms.TextBox txtOpis;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnReset;
	}
}