namespace Water_CR
{
	// Token: 0x0200000C RID: 12
	public partial class Login : global::DevExpress.XtraEditors.XtraForm
	{
		// Token: 0x060001EF RID: 495 RVA: 0x00038D08 File Offset: 0x00036F08
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00038D40 File Offset: 0x00036F40
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.formAssistant1 = new DevExpress.XtraBars.FormAssistant();
            this.styleController1 = new DevExpress.XtraEditors.StyleController(this.components);
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.username = new DevExpress.XtraEditors.TextEdit();
            this.password = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.token = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.styleController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.token.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 28;
            this.label2.Text = "Water CR | Login";
            // 
            // simpleButton1
            // 
            this.simpleButton1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.simpleButton1.Location = new System.Drawing.Point(9, 149);
            this.simpleButton1.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(163, 23);
            this.simpleButton1.TabIndex = 29;
            this.simpleButton1.Text = "Login";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.simpleButton2.Location = new System.Drawing.Point(9, 178);
            this.simpleButton2.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(163, 23);
            this.simpleButton2.TabIndex = 32;
            this.simpleButton2.Text = "Register";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // styleController1
            // 
            this.styleController1.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.styleController1.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Location = new System.Drawing.Point(330, 8);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton3.Size = new System.Drawing.Size(27, 20);
            this.simpleButton3.TabIndex = 36;
            this.simpleButton3.Text = "X";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(184, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // username
            // 
            this.username.EditValue = "Username";
            this.username.Location = new System.Drawing.Point(12, 70);
            this.username.Name = "username";
            this.username.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.username.Properties.Appearance.Options.UseForeColor = true;
            this.username.Size = new System.Drawing.Size(163, 20);
            this.username.TabIndex = 35;
            // 
            // password
            // 
            this.password.EditValue = "Password";
            this.password.Location = new System.Drawing.Point(12, 97);
            this.password.Name = "password";
            this.password.Properties.PasswordChar = '●';
            this.password.Size = new System.Drawing.Size(163, 20);
            this.password.TabIndex = 34;
            // 
            // simpleButton4
            // 
            this.simpleButton4.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.simpleButton4.Location = new System.Drawing.Point(184, 222);
            this.simpleButton4.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.simpleButton4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(173, 23);
            this.simpleButton4.TabIndex = 39;
            this.simpleButton4.Text = "Save Credentials";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.Location = new System.Drawing.Point(297, 8);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton5.Size = new System.Drawing.Size(27, 20);
            this.simpleButton5.TabIndex = 40;
            this.simpleButton5.Text = "_";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // token
            // 
            this.token.EditValue = "Extend Subscription Token";
            this.token.Location = new System.Drawing.Point(12, 123);
            this.token.Name = "token";
            this.token.Size = new System.Drawing.Size(163, 20);
            this.token.TabIndex = 41;
            // 
            // simpleButton6
            // 
            this.simpleButton6.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.simpleButton6.Location = new System.Drawing.Point(9, 207);
            this.simpleButton6.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.simpleButton6.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(163, 23);
            this.simpleButton6.TabIndex = 42;
            this.simpleButton6.Text = "Extend Subscription";
            this.simpleButton6.Click += new System.EventHandler(this.simpleButton6_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 254);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.token);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.username);
            this.Controls.Add(this.password);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.styleController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.token.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000301 RID: 769
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000302 RID: 770
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000303 RID: 771
		private global::DevExpress.XtraEditors.SimpleButton simpleButton1;

		// Token: 0x04000304 RID: 772
		private global::DevExpress.XtraEditors.SimpleButton simpleButton2;

		// Token: 0x04000305 RID: 773
		private global::DevExpress.XtraBars.FormAssistant formAssistant1;

		// Token: 0x04000306 RID: 774
		private global::DevExpress.XtraEditors.TextEdit password;

		// Token: 0x04000307 RID: 775
		private global::DevExpress.XtraEditors.TextEdit username;

		// Token: 0x04000308 RID: 776
		private global::DevExpress.XtraEditors.StyleController styleController1;

		// Token: 0x04000309 RID: 777
		private global::DevExpress.XtraEditors.SimpleButton simpleButton3;

		// Token: 0x0400030A RID: 778
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400030B RID: 779
		private global::DevExpress.XtraEditors.SimpleButton simpleButton4;

		// Token: 0x0400030C RID: 780
		private global::DevExpress.XtraEditors.SimpleButton simpleButton5;

		// Token: 0x0400030D RID: 781
		private global::DevExpress.XtraEditors.TextEdit token;

		// Token: 0x0400030E RID: 782
		private global::DevExpress.XtraEditors.SimpleButton simpleButton6;
	}
}
