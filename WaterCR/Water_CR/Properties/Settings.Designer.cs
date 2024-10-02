using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Water_CR.Properties
{
	// Token: 0x02000010 RID: 16
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0003A294 File Offset: 0x00038494
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400031E RID: 798
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
