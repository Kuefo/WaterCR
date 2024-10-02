using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Auth.GG_Winform_Example;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Water_CR
{
	// Token: 0x0200000E RID: 14
	public partial class Register : XtraForm
	{
		// Token: 0x060001F2 RID: 498 RVA: 0x00039748 File Offset: 0x00037948
		public Register()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00039760 File Offset: 0x00037960
		private void simpleButton1_Click(object sender, EventArgs e)
		{

		    XtraMessageBox.Show(this.styleController1.LookAndFeel, "Register has been successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000397CC File Offset: 0x000379CC
		private void simpleButton2_Click(object sender, EventArgs e)
		{
			Login login = new Login();
			login.Show();
			base.Hide();
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x000397EE File Offset: 0x000379EE
		private void Register_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00039808 File Offset: 0x00037A08
		private void Register_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00039869 File Offset: 0x00037A69
		private void Register_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0003986C File Offset: 0x00037A6C
		private void checkEdit1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0003986F File Offset: 0x00037A6F
		private void simpleButton3_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00039878 File Offset: 0x00037A78
		private void simpleButton4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0400030F RID: 783
		private Point lastPoint;
	}
}
