using System;
using System.Windows.Forms;
using Auth.GG_Winform_Example;

namespace Water_CR
{
	// Token: 0x0200000D RID: 13
	internal static class Program
	{
		// Token: 0x060001F1 RID: 497
		[STAThread]
		private static void Main()
		{
			//OnProgramStart.Initialize("Water CR", "381699", "A4wxfE7GEvGR4ZQEOSX5Zjb4OwH5GaN5nIf", "1.0");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}
	}
}
