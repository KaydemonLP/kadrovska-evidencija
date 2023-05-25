using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System;
using System.Windows.Forms;

namespace Kadrovska.components
{
	public class DockableComboBox: ComboBox
	{

		public DockableComboBox()
		{
			DrawMode = DrawMode.OwnerDrawFixed;
			DisplayMember = "m_strName";
		}
		protected override void SetBoundsCore( int x, int y, int width, int height, BoundsSpecified specified )
		{
			base.SetBoundsCore(x, y, width, height, specified);
			if (Dock == DockStyle.Fill ||
				Dock == DockStyle.Left ||
				Dock == DockStyle.Right)
			{
				var d = SystemInformation.FixedFrameBorderSize.Height;
				ItemHeight = height - 2 * d;
			}
			else
			{
				ItemHeight = FontHeight + 2;
			}
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			e.DrawBackground();
			var text = e.Index >= 0 ? this.Items[e.Index].ToString() : string.Empty;
			TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds, e.ForeColor,
				TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
			base.OnDrawItem(e);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			this.ResumeLayout(false);

		}
	}
}
