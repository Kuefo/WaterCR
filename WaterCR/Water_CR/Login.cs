using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Auth.GG_Winform_Example;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.Win32;
using Water_CR.Properties;

namespace Water_CR
{
	// Token: 0x0200000C RID: 12
	public partial class Login : XtraForm
	{
		// Token: 0x060001DF RID: 479 RVA: 0x00038A04 File Offset: 0x00036C04
		public Login()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00038A1C File Offset: 0x00036C1C
		public void saveData()
		{
			//RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Shutter CR");
			//registryKey.SetValue("Username Shutter CR", this.username.Text);
			//registryKey.SetValue("Password Shutter CR", this.password.Text);
			//registryKey.Close();
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00038A70 File Offset: 0x00036C70
		public void requestData()
		{
			try
			{
				//RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Shutter CR");
				//object value = registryKey.GetValue("Username Shutter CR");
				//object value2 = registryKey.GetValue("Password Shutter CR");
				//registryKey.Close();
				//this.username.Text = value.ToString();
				//this.password.Text = value2.ToString();
			}
			catch
			{
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00038AEC File Offset: 0x00036CEC
		public void SaveData()
		{
			//RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Shutter CR");
			//registryKey.SetValue("Username Shutter CR", this.username.Text);
			//registryKey.SetValue("Password Shutter CR", this.password.Text);
			//registryKey.Close();
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00038B40 File Offset: 0x00036D40
		private void simpleButton1_Click(object sender, EventArgs e)
		{
			//bool flag = API.Login(this.username.Text, this.password.Text);
			//if (flag)
			//{
				//API.Log(User.Username, "Signed In");
				Form1 form = new Form1();
				form.Show();
				base.Hide();
			//}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00038B93 File Offset: 0x00036D93
		private void Login_Load(object sender, EventArgs e)
		{
			this.requestData();
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00038B9D File Offset: 0x00036D9D
		private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00038BA0 File Offset: 0x00036DA0
		private void simpleButton2_Click(object sender, EventArgs e)
		{
			Register register = new Register();
			register.Show();
			base.Hide();
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00038BC2 File Offset: 0x00036DC2
		private void Login_MouseDown(object sender, MouseEventArgs e)
		{
			this.lastPoint = new Point(e.X, e.Y);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00038BDC File Offset: 0x00036DDC
		private void Login_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - this.lastPoint.X;
				base.Top += e.Y - this.lastPoint.Y;
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00038C3D File Offset: 0x00036E3D
		private void simpleButton3_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00038C46 File Offset: 0x00036E46
		private void pictureEdit1_EditValueChanged_1(object sender, EventArgs e)
		{
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00038C49 File Offset: 0x00036E49
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/c2t2TRFKPM");
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00038C57 File Offset: 0x00036E57
		private void simpleButton5_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00038C64 File Offset: 0x00036E64
		private void simpleButton4_Click(object sender, EventArgs e)
		{
			XtraMessageBox.Show(this.styleController1.LookAndFeel, "You have Saved your Credential's", "Hello!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00038CA0 File Offset: 0x00036EA0
		private void simpleButton6_Click(object sender, EventArgs e)
		{
			//bool flag = API.ExtendSubscription(this.username.Text, this.password.Text, this.token.Text);
			//if (flag)
			//{
			XtraMessageBox.Show(this.styleController1.LookAndFeel, "You have successfully extended your subscription!", "Subscription", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//	if (flag2)
			//	{
			//	}
			//}
		}

		// Token: 0x04000300 RID: 768
		private Point lastPoint;
	}
}
