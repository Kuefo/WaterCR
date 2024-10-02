namespace Water_CR
{
	// Token: 0x0200000E RID: 14
	public partial class Register : global::DevExpress.XtraEditors.XtraForm
	{
		// Token: 0x060001FB RID: 507 RVA: 0x00039884 File Offset: 0x00037A84
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000398BC File Offset: 0x00037ABC
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.formAssistant1 = new DevExpress.XtraBars.FormAssistant();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.styleController1 = new DevExpress.XtraEditors.StyleController(this.components);
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.email = new DevExpress.XtraEditors.TextEdit();
            this.license = new DevExpress.XtraEditors.TextEdit();
            this.username = new DevExpress.XtraEditors.TextEdit();
            this.password = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.styleController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.license.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton2
            // 
            this.simpleButton2.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.simpleButton2.Location = new System.Drawing.Point(59, 199);
            this.simpleButton2.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(163, 23);
            this.simpleButton2.TabIndex = 36;
            this.simpleButton2.Text = "Back To Login";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.simpleButton1.Location = new System.Drawing.Point(59, 171);
            this.simpleButton1.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(163, 23);
            this.simpleButton1.TabIndex = 33;
            this.simpleButton1.Text = "Register";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 41;
            this.label2.Text = "Water CR | Register";
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
            this.simpleButton3.Location = new System.Drawing.Point(241, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton3.Size = new System.Drawing.Size(27, 20);
            this.simpleButton3.TabIndex = 42;
            this.simpleButton3.Text = "X";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // email
            // 
            this.email.EditValue = "Email";
            this.email.Location = new System.Drawing.Point(60, 100);
            this.email.Name = "email";
            this.email.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.email.Properties.Appearance.Options.UseForeColor = true;
            this.email.Size = new System.Drawing.Size(163, 20);
            this.email.TabIndex = 40;
            // 
            // license
            // 
            this.license.EditValue = "License";
            this.license.Location = new System.Drawing.Point(60, 124);
            this.license.Name = "license";
            this.license.Size = new System.Drawing.Size(163, 20);
            this.license.TabIndex = 39;
            // 
            // username
            // 
            this.username.EditValue = "Username";
            this.username.Location = new System.Drawing.Point(60, 51);
            this.username.Name = "username";
            this.username.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.username.Properties.Appearance.Options.UseForeColor = true;
            this.username.Size = new System.Drawing.Size(163, 20);
            this.username.TabIndex = 38;
            // 
            // password
            // 
            this.password.EditValue = "Password";
            this.password.Location = new System.Drawing.Point(60, 75);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(163, 20);
            this.password.TabIndex = 37;
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Location = new System.Drawing.Point(208, 4);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton4.Size = new System.Drawing.Size(27, 20);
            this.simpleButton4.TabIndex = 43;
            this.simpleButton4.Text = "_";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.email);
            this.Controls.Add(this.license);
            this.Controls.Add(this.username);
            this.Controls.Add(this.password);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Register_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Register_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.styleController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.license.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000310 RID: 784
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000311 RID: 785
		private global::DevExpress.XtraBars.FormAssistant formAssistant1;

		// Token: 0x04000312 RID: 786
		private global::DevExpress.XtraEditors.SimpleButton simpleButton2;

		// Token: 0x04000313 RID: 787
		private global::DevExpress.XtraEditors.SimpleButton simpleButton1;

		// Token: 0x04000314 RID: 788
		private global::DevExpress.XtraEditors.TextEdit username;

		// Token: 0x04000315 RID: 789
		private global::DevExpress.XtraEditors.TextEdit password;

		// Token: 0x04000316 RID: 790
		private global::DevExpress.XtraEditors.TextEdit email;

		// Token: 0x04000317 RID: 791
		private global::DevExpress.XtraEditors.TextEdit license;

		// Token: 0x04000318 RID: 792
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000319 RID: 793
		private global::DevExpress.XtraEditors.StyleController styleController1;

		// Token: 0x0400031A RID: 794
		private global::DevExpress.XtraEditors.SimpleButton simpleButton3;

		// Token: 0x0400031B RID: 795
		private global::DevExpress.XtraEditors.SimpleButton simpleButton4;
	}
}
