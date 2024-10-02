using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auth.GG_Winform_Example;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DiscordRPC;
using Imaging.DDSReader;
using JRPC_Client;
using Leaf.xNet;
using Newtonsoft.Json.Linq;
using Water_CR.Properties;
using XDevkit;

namespace Water_CR
{
	public partial class Form1 : XtraForm
	{
		public Form1()
		{
			InitializeComponent();
			_rpcClient.Initialize();
		}

		public string Length { get; private set; }

		public void Toast(int client, string Icon, string Title, string Desc, int Dur)
		{
			try
			{
				Console.CallVoid(0x82454800, new object[]
				{
					client,
					Icon,
					Title,
					Desc,
					Dur * 1000
				});
			}
			catch (Exception ex)
			{
			}
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				base.Left += e.X - lastPoint.X;
				base.Top += e.Y - lastPoint.Y;
			}
		}

		private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
		{

		}

		private void BO2_MP_CMD(string command)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				command
			});
		}

		private void simpleButton3_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void simpleButton4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void simpleButton2_Click(object sender, EventArgs e)
		{

		}

		private void setgamertag(string gt)
		{
            Console.SetMemory(0x82C55D00, new byte[] { 0x7C, 0x83, 0x23, 0x78, 0x3D, 0x60, 0x82, 0xC5, 0x38, 0x8B, 0x5D, 0x60, 0x3D, 0x60, 0x82, 0x4A, 0x39, 0x6B, 0xDC, 0xA0, 0x38, 0xA0, 0x0, 0x20, 0x7D, 0x69, 0x3, 0xA6, 0x4E, 0x80, 0x4, 0x20 });
            Console.SetMemory(0x8293D724, new byte[] { 0x3D, 0x60, 0x82, 0xC5, 0x39, 0x6B, 0x5D, 0x0, 0x7D, 0x69, 0x3, 0xA6, 0x4E, 0x80, 0x4, 0x20 });
            Console.SetMemory(0x8259B6A7, new byte[1]);
            Console.SetMemory(0x822D1110, new byte[] { 0x40 });
            Console.SetMemory(0x82C55D60, Encoding.UTF8.GetBytes(gt + "\0"));
        }

		public string GeoLocationCityState(string IP)
		{
			string result;
			try
			{
				WebClient webClient = new WebClient();
				string[] array = webClient.DownloadString("http:ip-api.com/csv/" + IP + "?fields=regionName,city").Replace(",", Environment.NewLine).Replace("\"", "").Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None);
				string text = array[1] + ", " + array[0];
				result = text;
			}
			catch
			{
				result = "Error";
			}
			return result;
		}

		public string GeoLocationCity(string IP)
		{
			string result;
			try
			{
				WebClient webClient = new WebClient();
				string[] array = webClient.DownloadString("http:ip-api.com/csv/" + IP + "?fields=city").Replace(",", Environment.NewLine).Replace("\"", "").Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None);
				string text = array[0];
				result = text;
			}
			catch
			{
				result = "Error";
			}
			return result;
		}
		public string ISP(string IP)
		{
			string result;
			try
			{
				WebClient webClient = new WebClient();
				string[] array = webClient.DownloadString("http:ip-api.com/csv/" + IP + "?fields=isp").Replace(",", Environment.NewLine).Replace("\"", "").Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None);
				string text = array[0];
				result = text;
			}
			catch
			{
				result = "Error";
			}
			return result;
		}

		public string GeoLocationState(string IP)
		{
			string result;
			try
			{
				WebClient webClient = new WebClient();
				string[] array = webClient.DownloadString("http:ip-api.com/csv/" + IP + "?fields=regionName").Replace(",", Environment.NewLine).Replace("\"", "").Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None);
				string text = array[0];
				result = text;
			}
			catch
			{
				result = "Error";
			}
			return result;
		}

		private void simpleButton10_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton7_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton9_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton13_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton12_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton11_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton8_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton14_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton5_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton15_Click(object sender, EventArgs e)
		{

		}

		public string smethod_19(string string_14)
		{
            byte[] data = new byte[8];
            Console.SetMemory(0x81AA18F0, data);
            object[] arguments = new object[]
            {
                0x9000006F93463,
                0x0,
                string_14,
                0x18,
                0x81AA18F0,
                0x0
            };
            Console.CallVoid(0x81829158, arguments);
            Thread.Sleep(1000);
            byte[] memory = Console.GetMemory(0x81AA18F0, 0x8);
            string result = BitConverter.ToString(memory).Replace("-", "");
            Console.SetMemory(0x81AA18F0, data);
            return result;
        }

		private void simpleButton16_Click(object sender, EventArgs e)
		{

		}

		public void dashmessage(string string_9, string string_10, string string_11)
		{
            object[] arguments = new object[]
                        {
                255,
                1
                        };
            uint num = Console.Call<uint>(Console.ResolveFunction("xam.xex", 0x489), arguments);
            object[] arguments2 = new object[]
            {
                1024,
                1
            };
            uint num2 = Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments2);

            object[] arguments3 = new object[]
            {
                8,
                1
            };
            uint num3 = Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments3);
            object[] arguments4 = new object[]
            {
                12,
                1
            };
            uint num4 = Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments4);
            object[] arguments5 = new object[]
            {
                32,
                1
            };
            uint num5 = Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments5);
            object[] arguments6 = new object[]
            {
                32,
                1
            };
            uint num6 = Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments6);
            Console.SetMemory(num, messagemethod(string_9));
            Console.SetMemory(num2, messagemethod(string_10));
            Console.WriteUInt32(num3, num6);
            Console.SetMemory(num6, messagemethod(string_11));
            uint address = Console.ResolveFunction("xam.xex", 714U);
            object[] arguments7 = new object[]
            {
                0,
                num,
                num2,
                1,
                num3,
                0,
                2,
                num4,
                num5
            };
            Console.CallVoid(address, arguments7);
            object[] arguments8 = new object[]
            {
                num,
                1
            };
            Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments8);
            object[] arguments9 = new object[]
            {
                num2,
                1
            };
            Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments9);
            object[] arguments10 = new object[]
            {
                num3,
                1
            };
            Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments10);
            object[] arguments11 = new object[]
            {
                num4,
                1
            };
            Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments11);
            object[] arguments12 = new object[]
            {
                num5,
                1
            };
            Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments12);
            object[] arguments13 = new object[]
            {
                num6,
                1
            };
            Console.Call<uint>(Console.ResolveFunction("xam.xex", 1161), arguments13);
        }

		private byte[] messagemethod(string string_9)
		{
			byte[] array = new byte[string_9.Length * 2 + 2];
			int num = 1;
			array[0] = 0;
			foreach (char value in string_9)
			{
				array[num] = Convert.ToByte(value);
				num += 2;
			}
			return array;
		}

		private void simpleButton17_Click(object sender, EventArgs e)
		{
			setgamertag(textEdit29.Text);
			string text = Console.ReadString(0x81AA285C, 0x8);
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"userinfo \"\\name\\" + textEdit29.Text + "\\xuid\\"
			});
		}

		public static int strlen(string s)
		{
			int num = 0;
			foreach (char c in s)
			{
				num++;
			}
			return num;
		}

		private void simpleButton18_Click(object sender, EventArgs e)
		{
			int num = strlen(textEdit30.Text);
			bool flag = num == 1;
			if (flag)
			{
				Length = "\u0001";
			}
			bool flag2 = num == 2;
			if (flag2)
			{
				Length = "\u0002";
			}
			bool flag3 = num == 3;
			if (flag3)
			{
				Length = "\u0003";
			}
			bool flag4 = num == 4;
			if (flag4)
			{
				Length = "\u0004";
			}
			bool flag5 = num == 5;
			if (flag5)
			{
				Length = "\u0005";
			}
			bool flag6 = num == 6;
			if (flag6)
			{
				Length = "\u0006";
			}
			bool flag7 = num == 7;
			if (flag7)
			{
				Length = "\a";
			}
			bool flag8 = num == 8;
			if (flag8)
			{
				Length = "\b";
			}
			bool flag9 = num == 9;
			if (flag9)
			{
				Length = "\t";
			}
			bool flag10 = num == 10;
			if (flag10)
			{
				Length = "\n";
			}
			bool flag11 = num == 11;
			if (flag11)
			{
				Length = "\v";
			}
			bool flag12 = num == 12;
			if (flag12)
			{
				Length = "\f";
			}
			bool flag13 = num == 13;
			if (flag13)
			{
				Length = "\r";
			}
			bool flag14 = num == 14;
			if (flag14)
			{
				Length = "\u000e";
			}
			bool flag15 = num == 15;
			if (flag15)
			{
				Length = "\u000f";
			}
			bool flag16 = num == 16;
			if (flag16)
			{
				Length = "\u0010";
			}
			bool flag17 = num == 17;
			if (flag17)
			{
				Length = "\u0011";
			}
			bool flag18 = num == 18;
			if (flag18)
			{
				Length = "\u0012";
			}
			bool flag19 = num == 19;
			if (flag19)
			{
				Length = "\u0013";
			}
			bool flag20 = num == 20;
			if (flag20)
			{
				Length = "\u0014";
			}
			bool flag21 = num == 21;
			if (flag21)
			{
				Length = "\u0015";
			}
			bool flag22 = num == 22;
			if (flag22)
			{
				Length = "\u0016";
			}
			bool flag23 = num == 23;
			if (flag23)
			{
				Length = "\u0017";
			}
			bool flag24 = num == 24;
			if (flag24)
			{
				Length = "\u0018";
			}
			bool flag25 = num == 25;
			if (flag25)
			{
				Length = "\u0019";
			}
			bool flag26 = num == 26;
			if (flag26)
			{
				Length = "\u001a";
			}
			bool flag27 = num == 27;
			if (flag27)
			{
				Length = "\u001b";
			}
			bool @checked = checkEdit2.Checked;
			if (@checked)
			{
				bool flag28 = num > 27;
				if (!flag28)
				{
					setgamertag("^H\u007f?" + Length + textEdit30.Text);
				}
			}
			else
			{
				bool checked2 = checkEdit5.Checked;
				if (checked2)
				{
					bool flag29 = num > 27;
					if (!flag29)
					{
						setgamertag("^H" + Length + textEdit30.Text);
					}
				}
				else
				{
					bool flag30 = num <= 27;
					if (flag30)
					{
						setgamertag("^H\u007f\u007f" + Length + textEdit30.Text);
					}
				}
			}
		}

		private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        { 
			if (checkEdit4.Checked)
			{
				timer1.Start();
			}
			else
			{
				timer1.Stop();
				setgamertag(checkEdit4.Text);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (!(strlen(textEdit29.Text) >= 31))
			{
				setgamertag(textEdit29.Text);
			}
		}

		private void checkEdit1_CheckedChanged(object sender, EventArgs e)
		{

			if (checkEdit1.Checked)
			{
				timer2.Start();
			}
			else
			{
				timer2.Stop();
				setgamertag(textEdit29.Text);
			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			bool flag = strlen(textEdit29.Text + "_") >= 31;
			if (!flag)
			{
				setgamertag(textEdit29.Text + "_");
			}
		}

		private void checkEdit3_CheckedChanged(object sender, EventArgs e)
		{
			bool @checked = checkEdit3.Checked;
			if (@checked)
			{
				timer3.Start();
			}
			else
			{
				timer3.Stop();
				setgamertag(textEdit29.Text);
			}
		}

		private void timer3_Tick(object sender, EventArgs e)
		{
			int num = new Random().Next(1, 9);
			bool flag = strlen("^" + num + textEdit29.Text) >= 31;
			if (!flag)
			{
				setgamertag("^" + num + textEdit29.Text);
			}
		}

		private void simpleButton19_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				";statwriteddl clantagstats clanname " + textEdit31.Text + ";"
			});
		}

		public IXboxConsole XDK { get; private set; }

		public bool Exper { get; private set; }

		private void simpleButton24_Click(object sender, EventArgs e)
		{
			gridControl1.DataSource = null;
			GrabbedClients.Clear();
			for (int i = 0; i < 18; i++)
			{
				string gamertag = Encoding.ASCII.GetString(Console.GetMemory((uint)(-0x3BFC3C58 + 328 * i), 15U)).TrimEnd(new char[1]);
				string externalIP = new IPAddress(Console.GetMemory((uint)(-0x3BFC3BE4 + 328 * i), 4U)).ToString();
				string internalIP = new IPAddress(Console.GetMemory((uint)(-0x3BFC3BE8 + 328 * i), 4U)).ToString();
				string text = BitConverter.ToString(Console.GetMemory((uint)(-0x3BFC3C60 + 328 * i), 8U)).Replace("-", "");
				string port = int.Parse(BitConverter.ToString(Console.GetMemory((uint)(-0x3BFC3BE1 + 328 * i), 2U)).Replace("-", ""), NumberStyles.HexNumber).ToString();
				string mac = BitConverter.ToString(Console.GetMemory((uint)(-0x3BFC3BDE + 328 * i), 6U)).Replace("-", "");
				WebClient webClient = new WebClient();
				bool flag = text != "0000000000000000";
				if (flag)
				{
					GrabbedClients.Add(new Client
					{
						Index = i,
						Gamertag = gamertag,
						XUID = text,
						ExternalIP = externalIP,
						InternalIP = internalIP,
						Port = port,
						Mac = mac
					});
				}
			}
			gridControl1.DataSource = GrabbedClients;
		}

		private void simpleButton23_Click(object sender, EventArgs e)
		{
            Console.SetMemory(0xC37586FC, new byte[66]);
            Console.SetMemory(0xC3771F34, new byte[66]);
            Console.SetMemory(0xC376271C, new byte[66]);
            Console.SetMemory(0xC378C73C, new byte[66]);
            Console.SetMemory(0xC377CF24, new byte[66]);
            Console.SetMemory(0xC377772C, new byte[66]);
            Console.SetMemory(0xC3767F14, new byte[66]);
            Console.SetMemory(0xC37436EC, new byte[66]);
            Console.SetMemory(0xC3752F04, new byte[66]);
            Console.SetMemory(0xC375DEF4, new byte[66]);
            Console.SetMemory(0xC376D70C, new byte[66]);
            Console.SetMemory(0xC3786F44, new byte[66]);
            string str = new WebClient().DownloadString("http://icanhazip.com");
            byte[] bytes = Encoding.ASCII.GetBytes("^6Slam Me ^5-> ^1" + str);
            Console.SetMemory(0xC37586FC, bytes);
            Console.SetMemory(0xC3771F34, bytes);
            Console.SetMemory(0xC376271C, bytes);
            Console.SetMemory(0xC378C73C, bytes);
            Console.SetMemory(0xC377CF24, bytes);
            Console.SetMemory(0xC377772C, bytes);
            Console.SetMemory(0xC3767F14, bytes);
            Console.SetMemory(0xC37436EC, bytes);
            Console.SetMemory(0xC3752F04, bytes);
            Console.SetMemory(0xC375DEF4, bytes);
            Console.SetMemory(0xC376D70C, bytes);
            Console.SetMemory(0xC3786F44, bytes);
        }

		public void SetPlayerGamertag(int SelectedIndex, string Gamertag)
		{
			try
			{
				Console.SetMemory((uint)(-0x7CAAE5F0 + SelectedIndex * 0x57F8 + 0x5534), new byte[32]);
				Console.SetMemory((uint)(-0x7CAAE5F0 + SelectedIndex * 0x57F8 + 0x5534), Encoding.ASCII.GetBytes(Gamertag));
			}
			catch
			{
			}
		}

		private void simpleButton26_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 18; i++)
			{
				string str = Encoding.ASCII.GetString(Console.GetMemory((uint)(-0x3BFC3C58 + 328 * i), 15U)).TrimEnd(new char[1]);
				string str2 = new IPAddress(Console.GetMemory((uint)(-0x3BFC3BE4 + 328 * i), 4U)).ToString();
				SetPlayerGamertag(i, str + " =^1 " + str2);
			}
		}

		private void simpleButton25_Click(object sender, EventArgs e)
		{
			Tools.Ping(textEdit33.Text);
		}

		private void simpleButton20_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x8242FB70, new object[]
			{
				0,
				textEdit32.Text
			});
		}

		private void simpleButton22_Click(object sender, EventArgs e)
		{
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]) ?? "");
			string text = Console.ReadString(0x81AA285C, 8U);
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"userinfo \"\\name\\" + Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]) + "\\xuid\\"
			});
		}

		private void simpleButton21_Click(object sender, EventArgs e)
		{
			string text = Console.ReadString(0x81AA285C, 8U);
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"userinfo \"\\name\\[{+}][{+}][{+}][{+}][{+}][{+}][[S]\\xuid\\"
			});
			setgamertag("[{+}][{+}][{+}][{+}][{+}][{+}][[S]");
		}

		private void simpleButton33_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton33.Text == "Force Host [OFF]";
			if (flag)
			{
				simpleButton33.Text = "Force Host [ON]";
				Console.CallVoid(0x824015E0, new object[]
				{
					0,
					"party_connectToOthers 00; partyMigrate_disabled 01; sv_endGameIfISuck 0; badhost_endgameifisuck 0​; set allowAllNAT 1"
				});
			}
			else
			{
				simpleButton33.Text = "Force Host [OFF]";
				Console.CallVoid(0x824015E0, new object[]
				{
					0,
					"party_connectToOthers 01; partyMigrate_disabled 00"
				});
			}
		}

		private void simpleButton27_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton27.Text == "Spoof Mic [OFF]";
			if (flag)
			{
				simpleButton27.Text = "Spoof Mic [ON]";
				Console.WriteUInt32(0x8228D108, 0x38600001);
			}
			else
			{
				simpleButton27.Text = "Spoof Mic [OFF]";
				Console.WriteUInt32(0x8228D108, 0x38600000);
			}
		}

		private void simpleButton31_Click(object sender, EventArgs e)
		{
			Console.XNotify("Read ~ Game Has Started!");
            Console.SetMemory(0x8227A500, new byte[] { 0x60, 0x00, 0x00, 0x00});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"set party_minplayers 1; xpartygo"
			});
		}

		private void simpleButton30_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton30.Text == "Show Host [OFF]";
			if (flag)
			{
				simpleButton30.Text = "Show Host [ON]";
				Console.SetMemory(0x82003F70, new byte[18]);
				Console.WriteBool(0x83C5A3BB, true);
			}
			else
			{
				simpleButton30.Text = "Show Host [OFF]";
				Console.SetMemory(0x82003F70, new byte[18]);
				Console.WriteBool(0x83C5A3BB, false);
			}
		}

		private void simpleButton32_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton32.Text == "Lag Meter [OFF]";
			if (flag)
			{
				simpleButton32.Text = "Lag Meter [ON]";
				Console.WriteBool(0x821C5567, true);
			}
			else
			{
				simpleButton32.Text = "Lag Meter [OFF]";
				Console.WriteBool(0x821C5567, false);
			}
		}

		private void simpleButton29_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"cmd sl"
			});
		}

		private void simpleButton28_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"cmd mr " + Console.ReadInt32(0x82C15758) + " -1 endround"
			});
		}

		private void simpleButton34_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				string.Format("cmd mr {0} -1 killserverpc", Console.ReadInt32(0x82C15758))
			});
		}

		private void simpleButton37_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"xstartpartyhost"
			});
		}

		private void simpleButton36_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"wait 320; fast_restart"
			});
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				"< \"^5Restarting..... ^6Please Wait.....\""
			});
		}

		private void simpleButton35_Click(object sender, EventArgs e)
		{
			object[] arguments = new object[]
			{
				0,
				"fast_restart"
			};
			Console.CallVoid(0x824015E0, arguments);
		}

		private void simpleButton38_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"disconnect"
			});
		}

		private void simpleButton40_Click(object sender, EventArgs e)
		{
			int num = -1;
			bool flag = num == 21;
			if (!flag)
			{
				try
				{
					IXboxConsole console = Console;
					console.CallVoid(0x8242FB70, new object[]
					{
						num,
						0,
						"; \"^5Get Fucked\""
					});
					console.CallVoid(0x8242FB70, new object[]
					{
						num,
						0,
						"< \"^6You Are Now Frozen ^1Nigger\""
					});
					Thread.Sleep(200);
					console.CallVoid(0x8242FB70, new object[]
					{
						num,
						0,
						"7 30 90"
					});
				}
				catch
				{
				}
			}
		}

		private void simpleButton41_Click(object sender, EventArgs e)
		{
			Console.SetMemory(0x82717D48, new byte[] { 0x60, 0x00, 0x00, 0x00});
			object[] arguments = new object[]
			{
				0,
				"userinfo \"\\name\\^6Get Kicked Kid\\clanabbrev\\^1\\xuid\\1E0200F003F252F7\\invited\\1\""
			};
			Console.CallVoid(0x822786E0, arguments);
		}

		private void simpleButton39_Click(object sender, EventArgs e)
		{
            Console.SetMemory(0x82717D48, new byte[] { 0x60, 0x00, 0x00, 0x00 });
			Console.XNotify("Anti-Freeze ON, Restart game to undo turn it off");
		}

		private void simpleButton42_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"set lowAmmoWarningNoReloadColor1 0 1 1 1; set lowAmmoWarningNoReloadColor2 0 0 0 1; set lowAmmoWarningColor1 0 1 1 1; set lowAmmoWarningColor2 0 0 0 1; set lowAmmoWarningNoAmmoColor1 0 1 1 1;"
			});
		}

		private void simpleButton43_Click(object sender, EventArgs e)
		{
			setgamertag("^Hÿÿÿ\u0001\u0002\n\u0015SHÿÿÿ\0");
			setgamertag("^Hÿÿÿ\u0001\u0002\n\u0015SIÿÿÿ\0");
			Thread.Sleep(250);
			Console.XNotify("Read ~ Pre-Game Host Frozen!");
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton44_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton44.Text == "God Mode All [OFF]";
			if (flag)
			{
				simpleButton44.Text = "God Mode All [ON]";
				for (int i = 0; i < 4; i++)
				{
					Console.SetMemory((uint)(i * 0x57F8 -0x7CAAE5F0 + 0x1B), new byte[]
					{
						5
					});
					Console.CallVoid(0x8242FB70, new object[]
					{
						i,
						0,
						"; \"^7God Mode All - [^2ON^7]\""
					});
				}
			}
			else
			{
				simpleButton44.Text = "God Mode All [OFF]";
				for (int j = 0; j < 4; j++)
				{
					Console.SetMemory((uint)(j * 22520 - 2091574768 + 27), new byte[]
					{
						4
					});
					Console.CallVoid(0x8242FB70, new object[]
					{
						j,
						0,
						"; \"^7God Mode All - [^1OFF^7]\""
					});
				}
			}
		}

		private void simpleButton46_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton46.Text == "Super Speed [OFF]";
			if (flag)
			{
				simpleButton46.Text = "Super Speed [ON]";
				Console.CallVoid(0x824015E0, new object[]
				{
					0,
					"seta g_speed 400"
				});
				Console.CallVoid(0x8242FB70, new object[]
				{
					-1,
					0,
					"< \"Super Speed: [^2ON^7]\""
				});
			}
			else
			{
				simpleButton46.Text = "Super Speed [OFF]";
				Console.CallVoid(0x824015E0, new object[]
				{
					0,
					"seta g_speed 165"
				});
				Console.CallVoid(0x8242FB70, new object[]
				{
					-1,
					0,
					"< \"Super Speed: [^1OFF^7]\""
				});
			}
		}

		private void simpleButton48_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton48.Text == "Super Jump [OFF]";
			if (flag)
			{
				simpleButton48.Text = "Super Jump [ON]";
				Console.WriteFloat(0x82085654, 1000.0f);
				Console.CallVoid(BO2CMD, new object[]
				{
					0,
					"bg_gravity 135"
				});
				Console.CallVoid(BO2SV, new object[]
				{
					-1,
					0,
					"< \"^2SuperJump ON :)\""
				});
			}
			else
			{
				simpleButton48.Text = "Super Jump [OFF]";
				Console.WriteFloat(0x82085654, 39f);
				Console.CallVoid(BO2CMD, new object[]
				{
					0,
					"bg_gravity 800"
				});
				Console.CallVoid(BO2SV, new object[]
				{
					-1,
					0,
					"< \"^1SuperJump OFF :(\""
				});
			}
		}

		private void simpleButton47_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"cmd mr " + Console.ReadUInt32(0x82C15758) + " -1 changeteam;"
			});
		}

		private void simpleButton45_Click(object sender, EventArgs e)
		{
			IXboxConsole console = Console;
            Console.SetMemory(0x826BE71C, new byte[] { 0x60, 0x00, 0x00, 0x00 });
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				"< \"Unlimited Ammo: ^2Enabled\""
			});
		}

		private void simpleButton54_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton54.Text == "Wall Hack [OFF]";
			if (flag)
			{
				simpleButton54.Text = "Wall Hack [ON]";
				Console.SetMemory(0x821FC04C, new byte[]
				{
					0x38,
					0xC0,
					byte.MaxValue,
					byte.MaxValue
				});
			}
			else
			{
				simpleButton54.Text = "Wall Hack [OFF]";
				Console.SetMemory(0x821FC04C, new byte[]
				{
					0x7F,
					0xA6,
					0xEB,
					0x78
				});
			}
		}

		private void simpleButton53_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton53.Text == "VSAT [OFF]";
			if (flag)
			{
				simpleButton53.Text = "VSAT [ON]";
				Console.SetMemory(0x821B8FD3, new byte[]
				{
					1
				});
			}
			else
			{
				simpleButton53.Text = "VSAT [OFF]";
				Console.SetMemory(0x821B8FD3U, new byte[1]);
			}
		}

		private void simpleButton52_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton52.Text == "No Recoil [OFF]";
			if (flag)
			{
				simpleButton52.Text = "No Recoil [ON]";
				Console.SetMemory(0x82259BC8, new byte[] { 0x60, 0x00, 0x00, 0x00 });
			}
			else
			{
				simpleButton52.Text = "No Recoil [OFF]";
				Console.SetMemory(0x82259BC8, new byte[]
				{
					0x48,
					0x46,
					0x13,
					0x41
				});
			}
		}

		private void simpleButton50_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton50.Text == "Red Boxes [OFF]";
			if (flag)
			{
				simpleButton50.Text = "Red Boxes [ON]";
				Console.WriteByte(0x821F5B7F, 1);
			}
			else
			{
				simpleButton50.Text = "Red Boxes [OFF]";
				Console.WriteByte(0x821F5B7F, 0);
			}
		}

		private void simpleButton51_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton51.Text == "Laser [OFF]";
			if (flag)
			{
				simpleButton51.Text = "Laser [ON]";
				Console.SetMemory(0x82255E1C, new byte[]
				{
					0x2B,
					0xB,
					0x00,
					0x1
				});
			}
			else
			{
				simpleButton51.Text = "Laser [OFF]";
				Console.SetMemory(0x82255E1C, new byte[]
                {
                    0x2B,
                    0xB,
                    0x00,
                    0x00
                });
			}
		}

		private void simpleButton49_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton49.Text == "No Sway [OFF]";
			if (flag)
			{
				simpleButton49.Text = "No Sway [ON]";
				Console.SetMemory(0x826C6E6C, new byte[] { 0x60, 0x00, 0x00, 0x00 });
			}
			else
			{
				simpleButton49.Text = "No Sway [OFF]";
				Console.SetMemory(0x826C6E6C, new byte[]
				{
					0x4B,
					0xFF,
					0xE9,
					0x75
				});
			}
		}

		private void simpleButton62_Click(object sender, EventArgs e)
		{
			File.WriteAllBytes("Saved Emblem.bin", Console.GetMemory(Console.ReadUInt32(0x83BA0798), 0x57C));
			XtraMessageBox.Show(styleController1.LookAndFeel, "Emblem Saved To Saved Emblem.bin", "Message From Developer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

		}

		private void simpleButton60_Click(object sender, EventArgs e)
		{
			if (!File.Exists("Saved Emblem.bin"))
			{
				XtraMessageBox.Show(styleController1.LookAndFeel, "Try Saving an Emblem First", "Message From Developer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				byte[] array = File.ReadAllBytes("Saved Emblem.bin");
				array.Reverse<byte>();
				Console.SetMemory(Console.ReadUInt32(0x83BA0798), array);
				XtraMessageBox.Show(styleController1.LookAndFeel, "Emblem Set From Saved Emblem.bin", "Message From Developer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				
			}
		}

		private void simpleButton57_Click(object sender, EventArgs e)
		{
			byte[] memory = Console.GetMemory(0x84353A45, 0x216);
			File.WriteAllBytes("Saved Classes.bin", memory);
			XtraMessageBox.Show(styleController1.LookAndFeel, "Classes Saved To Saved Classes.bin", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

		}

		private void simpleButton55_Click(object sender, EventArgs e)
		{
			byte[] data = File.ReadAllBytes("Saved Classes.bin");
			Console.SetMemory(0x84353A45, data);
			XtraMessageBox.Show(styleController1.LookAndFeel, "Classes Set From Saved Classes.bin", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

		}

		private void simpleButton63_Click(object sender, EventArgs e)
		{
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Just End or leave the game, then itll be fixed", "Message From Devloper", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void Angleup()
		{
			Console.WriteFloat(0x83C3FE98, 360f);
		}

		private void Angledown()
		{
			Console.WriteFloat(0x83C3FE38, 360f);
		}

		private void Ladder360()
		{
			Console.WriteFloat(0x83C40078U, 360f);
		}

		private void simpleButton59_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"cg_fov 160; cg_fovscale 2"
			});
		}

		private void simpleButton58_Click(object sender, EventArgs e)
		{
			Console.CallVoid(Console.ResolveFunction("xam.xex", 0xAFC), new object[]
			{
				0
			});
		}

		private void simpleButton61_Click(object sender, EventArgs e)
		{
			Angleup();
			Angledown();
			Ladder360();
		}

		private void simpleButton56_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				"5 \"" + textEdit34.Text + "\""
			});
		}

		private void simpleButton65_Click(object sender, EventArgs e)
		{
            Console.SetMemory(0xC37586FC, new byte[66]);
            Console.SetMemory(0xC3771F34, new byte[66]);
            Console.SetMemory(0xC376271C, new byte[66]);
            Console.SetMemory(0xC378C73C, new byte[66]);
            Console.SetMemory(0xC377CF24, new byte[66]);
            Console.SetMemory(0xC377772C, new byte[66]);
            Console.SetMemory(0xC3767F14, new byte[66]);
            Console.SetMemory(0xC37436EC, new byte[66]);
            Console.SetMemory(0xC3752F04, new byte[66]);
            Console.SetMemory(0xC375DEF4, new byte[66]);
            Console.SetMemory(0xC376D70C, new byte[66]);
            Console.SetMemory(0xC3786F44, new byte[66]);
			byte[] bytes = Encoding.ASCII.GetBytes(textEdit36.Text);
			Console.SetMemory(0xC37586FC, bytes);
			Console.SetMemory(0xC3771F34, bytes);
			Console.SetMemory(0xC376271C, bytes);
			Console.SetMemory(0xC378C73C, bytes);
			Console.SetMemory(0xC377CF24, bytes);
			Console.SetMemory(0xC377772C, bytes);
			Console.SetMemory(0xC3767F14, bytes);
			Console.SetMemory(0xC37436EC, bytes);
			Console.SetMemory(0xC3752F04, bytes);
			Console.SetMemory(0xC375DEF4, bytes);
			Console.SetMemory(0xC376D70C, bytes);
            Console.SetMemory(0xC3786F44, bytes);
        }

		private void simpleButton64_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"cg_fov " + textEdit35.Text
			});
		}

		private void simpleButton66_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton66.Text == "Set HostName/FPS [OFF]";
			if (flag)
			{
				simpleButton66.Text = "Set HostName/FPS [ON]";
				Console.WriteString(0x82003F70, textEdit37.Text + "\0");
				Console.WriteBool(0x83C5A3BB, true);
			}
			else
			{
				simpleButton66.Text = "Set HostName/FPS [OFF]";
				Console.WriteString(0x82003F70, textEdit37.Text + "\0");
				Console.WriteBool(0x83C5A3BB, false);
			}
		}

		private void simpleButton1_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton68_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton67_Click(object sender, EventArgs e)
		{

		}

		private void simpleButton77_Click(object sender, EventArgs e)
		{
			Console.WriteString(0xA679CE32, textEdit62.Text);
			Console.WriteString(0xA67AD112, textEdit69.Text);
			Console.WriteString(0xA6791F2C, textEdit70.Text);
			Console.WriteString(0xA67A0650, textEdit68.Text);
			Console.WriteString(0xA67A2CB4, textEdit60.Text);
			Console.WriteString(0xA67C7918, textEdit66.Text);
			Console.WriteString(0xA67BEF33, textEdit64.Text);
			Console.WriteString(0xA67764D2, textEdit67.Text);
			Console.WriteString(0xA6775FF0, textEdit61.Text);
			Console.WriteString(0xA679B1DE, textEdit63.Text);
			Console.WriteString(0xA6792191, textEdit65.Text);
			Console.XNotify("Zones Set Successfully!");
		}

		private void simpleButton78_Click(object sender, EventArgs e)
		{
			Console.WriteString(0xA679CE32, "PUBLIC MATCH");
			Console.WriteString(0xA67AD112, "CUSTOM GAMES");
			Console.WriteString(0xA6791F2C, "CREATE A CLASS");
			Console.WriteString(0xA67A0650, "BARRACKS");
			Console.WriteString(0xA67A2CB4, "THEATER");
			Console.WriteString(0xA67C7918, "LEAGUE");
			Console.WriteString(0xA67BEF33, "STORE");
			Console.WriteString(0xA67764D2, "XBOX LIVE");
			Console.WriteString(0xA6775FF0, "SYSTEM LINK");
			Console.WriteString(0xA679B1DE, "MAIN MENU");
			Console.WriteString(0xA6792191, "SCORESTREAKS");
			Console.XNotify("Reseted Zones Set Successfully!");
		}

		private void simpleButton80_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 0 " + textEdit59.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 1 " + textEdit58.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 2 " + textEdit57.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 3 " + textEdit56.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 4 " + textEdit55.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 5 " + textEdit53.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 6 " + textEdit52.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 7 " + textEdit54.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 8 " + textEdit50.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 9 " + textEdit49.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setPublicMatchClassSetNameFromLocString 0 " + textEdit50.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 0 " + textEdit59.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 1 " + textEdit58.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 2 " + textEdit57.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 3 " + textEdit56.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 4 " + textEdit55.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setCustomMatchClassSetNameFromLocString 0 " + textEdit50.Text + "\0"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			bool flag = Console.XamGetCurrentTitleId() == 0x415608C3U;
			if (flag)
			{
				Toast(0, "thumbsup", "^5Set All Custom Class Names", "^6Class Names Set!", 8);
			}
		}

		private void simpleButton79_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 0 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 1 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 2 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 3 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 4 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 5 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 6 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 7 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 8 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 9 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setPublicMatchClassSetNameFromLocString 0 \"^5~^6Read#4363^5~\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 0 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 1 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 2 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 3 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 4 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 0 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 1 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 2 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 3 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 4 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setCustomMatchClassSetNameFromLocString 0 \"^5~^6Read#4363^5~\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.XNotify("Read ~ Class Names Set!");
		}

		private void simpleButton71_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				0x48,
				0x0,
				0x0,
				0xC8
			};
			Console.SetMemory(0x825C5394, data);
		}

		private void simpleButton73_Click(object sender, EventArgs e)
		{
			Console.SetMemory(0x84352AC8, new byte[]
			{
				0xC0,
				0x3F
			});
		}

		private void simpleButton74_Click(object sender, EventArgs e)
		{
			Console.XNotify("Read ~ Setting Unlimted Classes");
			byte[] data = new byte[]
			{
				0x3B,
				0x55,
                0x55,
                0x55
            };
			Console.SetMemory(0x826A5FBC, data);
			Console.XNotify("Read ~ Set Unlimted Classes");
		}

		private void simpleButton72_Click(object sender, EventArgs e)
		{
			Console.SetMemory(0x843546B2, new byte[]
			{
				0x44,
				0x80,
				0x8,
				0x10,
				0x1,
				0x22,
				0x40,
				0x4
			});
		}

		private void simpleButton70_Click(object sender, EventArgs e)
		{
            Console.SetMemory(0x84353A50, new byte[] { 0x51, 0xA1 });
            Console.SetMemory(0x84353A5D, new byte[] { 0x00, 0xA8 });
            Console.SetMemory(0x84353A83, new byte[] { 0x00, 0x0, 0x15 });
            Console.SetMemory(0x84353A92, new byte[] { 0x00, 0xA8 });
            Console.SetMemory(0x84353AB9, new byte[] { 0x50, 0x1 });
            Console.SetMemory(0x84353AC6, new byte[] { 0x00, 0xA8 });
            Console.SetMemory(0x84353AED, new byte[] { 0x00, 0x15 });
            Console.SetMemory(0x84353AFB, new byte[] { 0x80, 0xA });
            Console.SetMemory(0x84353B22, new byte[] { 0x50, 0x1 });
            Console.SetMemory(0x84353B30, new byte[] { 0xA8, 0x00 });
            Console.SetMemory(0x84353B56, new byte[] { 0x00, 0x15 });
            Console.SetMemory(0x84353B64, new byte[] { 0x80, 0xA });
            Console.SetMemory(0x84353B8B, new byte[] { 0x50, 0x1 });
            Console.SetMemory(0x84353B99, new byte[] { 0x80, 0xA });
            Console.SetMemory(0x84353BBF, new byte[] { 0x0, 0x15 });
            Console.SetMemory(0x84353BCD, new byte[] { 0x80, 0xA });
            Console.SetMemory(0x84353BF4, new byte[] { 0x50, 0x1 });
            Console.SetMemory(0x84353C02, new byte[] { 0xA8, 0x00 });
            Console.SetMemory(0x84353C28, new byte[] { 0x0, 0x15 });
            Console.SetMemory(0x84353C36, new byte[] { 0x80, 0xA });
            Console.XNotify("Read ~ Ghost Camo Set! [Make Sure You Have Rogue Camo]");
        }

		private void simpleButton69_Click(object sender, EventArgs e)
		{
			Console.SetMemory(0x843491A4, unlocks1);
		}

		private void simpleButton76_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 0 \"^H¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 1 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 2 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 3 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 4 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 5 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 6 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 7 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 8 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 9 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setPublicMatchClassSetNameFromLocString 0 \"^H¤¤¤¤¤¤ ^B¤¤¤¤^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 0 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 1 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 2 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 3 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 4 \"^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setCustomMatchClassSetNameFromLocString 0 \"^H¤¤¤¤¤¤ ^B¤¤¤¤^H¤¤¤¤¤¤ ^B¤¤¤¤\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.XNotify("Read ~ All Classes Are Now Frozen");
		}

		private void simpleButton75_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 0 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 1 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 2 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 3 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 4 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 5 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 6 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 7 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 8 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 9 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setPublicMatchClassSetNameFromLocString 0 \"^6Read\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 0 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 1 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 2 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 3 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString custommatchcacloadouts customclassname 4 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 0 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 1 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 2 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 3 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString leaguecacloadouts customclassname 4 \"Read^5#4363\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setCustomMatchClassSetNameFromLocString 0 \"^6Read\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.XNotify("Read ~ Classes Unfrozen!");
		}

		private void simpleButton81_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName PLEVEL " + textEdit38.Text + ";updategamerprofile;uploadstats"
			});
		}

		private void simpleButton82_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName RANKXP " + textEdit41.Text + ";updategamerprofile;uploadstats"
			});
		}

		private void simpleButton84_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName SCORE " + textEdit40.Text + ";updategamerprofile;uploadstats"
			});
		}

		private void simpleButton83_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName KILLS " + textEdit45.Text + ";updategamerprofile;uploadstats"
			});
		}

		private void simpleButton86_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName DEATHS " + textEdit44.Text + ";updategamerprofile;uploadstats"
			});
		}

		private void simpleButton85_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName WINS " + textEdit43.Text + ";updategamerprofile;uploadstats"
			});
		}

		private void simpleButton87_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName LOSSES " + textEdit39.Text + ";updategamerprofile;uploadstats"
			});
		}

		private void simpleButton88_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName PLEVEL " + textEdit38.Text + ";updategamerprofile;uploadstats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName RANKXP " + textEdit41.Text + ";updategamerprofile;uploadstats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName SCORE " + textEdit40.Text + ";updategamerprofile;uploadstats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName KILLS " + textEdit45.Text + ";updategamerprofile;uploadstats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName DEATHS " + textEdit44.Text + ";updategamerprofile;uploadstats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName WINS " + textEdit43.Text + ";updategamerprofile;uploadstats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"statSetByName LOSSES " + textEdit39.Text + ";updategamerprofile;uploadstats"
			});
		}

		private void simpleButton89_Click(object sender, EventArgs e)
		{
			Console.XNotify("Unlock All [50]");
			Console.SetMemory(0x843491BC, BitConverter.GetBytes(Convert.ToInt32("4354399")));
			Console.SetMemory(0x843491A4, BitConverter.GetBytes(Convert.ToInt32(pre11)));
			Console.SetMemory(0x8435429F, unlocks1);
			byte[] data = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(0x843543AC, data);
			byte[] data2 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(0x843543A9, data2);
			Console.SetMemory(0x8434AF80, unlock2);
			byte[] data3 = new byte[]
			{
				192,
				63
			};
			Console.SetMemory(0x84352AC8, data3);
			byte[] data4 = new byte[]
			{
				192,
				63
			};
			Console.SetMemory(0x84352AC8, data4);
			Console.XNotify("Unlock All [100] Completed!");
		}

		private void simpleButton92_Click(object sender, EventArgs e)
		{
			textEdit38.Text = "11";
			textEdit41.Text = "1197150";
			textEdit40.Text = "9,442,600";
			textEdit45.Text = "";
			textEdit44.Text = "";
			textEdit43.Text = "9,442,600";
			textEdit39.Text = "";
		}

		private void simpleButton90_Click(object sender, EventArgs e)
		{
			textEdit38.Text = "11";
			textEdit41.Text = "92,442,600";
			textEdit40.Text = "92,442,600";
			textEdit45.Text = "92,442,600";
			textEdit44.Text = "92,442,600";
			textEdit43.Text = "92,442,600";
			textEdit39.Text = "92,442,600";
		}

		private void simpleButton91_Click(object sender, EventArgs e)
		{
			textEdit38.Text = "11";
			textEdit41.Text = "1197150";
			textEdit40.Text = "4,826,523";
			textEdit45.Text = "40,077";
			textEdit44.Text = "15,204";
			textEdit43.Text = "836";
			textEdit39.Text = "570";
		}

        private void ChangeMap(string mapname) //Had to
        {
            byte[] memory = Console.GetMemory(0x82497ED8, 0x4);
            byte[] array = new byte[] { 0x39, 0x60, 0x00, 0x00 };

            if (!memory.SequenceEqual(array))
                Console.SetMemory(0x82497ED8, array);
            
            Console.CallVoid(0x824015E0, new object[] { 0, mapname });
        }

        private void simpleButton94_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_drone");
        }


		private void simpleButton106_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_nuketown_2020");
        }

		private void simpleButton105_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_socotra");
        }

		private void simpleButton104_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_hijacked");
        }

		private void simpleButton103_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_dockside");
        }

		private void simpleButton102_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_carrier");
        }

		private void simpleButton96_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_express");
        }

		private void simpleButton101_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_meltdown");
        }

		private void simpleButton100_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_nightclub");
        }

		private void simpleButton99_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_village");
        }

		private void simpleButton98_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_turbine");
        }

		private void simpleButton97_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_raid");
        }

		private void simpleButton95_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_slums");
        }

		private void simpleButton108_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_overflow");
        }

		private void simpleButton107_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_aftermath");
        }

		private void simpleButton123_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_Studio");
        }

		private void simpleButton111_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_downhill");
        }

		private void simpleButton112_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_mirage");
		}

		private void simpleButton113_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_hydro");
        }

		private void simpleButton114_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_skate");
        }

		private void simpleButton115_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_concert");
        }

		private void simpleButton121_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_magma");
        }

		private void simpleButton116_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_vertigo");
        }

		private void simpleButton117_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_Uplink");
        }

		private void simpleButton118_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_Detour");
        }

		private void simpleButton119_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_Cove");
        }

		private void simpleButton120_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_paintball");
        }

		private void simpleButton122_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_dig");
        }

		private void simpleButton109_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_frostbite");
		}

		private void simpleButton110_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_pod");
		}

		private void simpleButton124_Click(object sender, EventArgs e)
		{
            ChangeMap("map mp_takeoff");
		}

		private void simpleButton126_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				"; \"" + textEdit46.Text + "\""
			});
		}

		private void simpleButton125_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				"< \"" + textEdit42.Text + "\""
			});
		}

		private void simpleButton140_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton140.Text == "Send Center + Kill Feed [OFF]";
			if (flag)
			{
				simpleButton140.Text = "Send Center + Kill Feed [ON]";
				timer4.Start();
			}
			else
			{
				simpleButton140.Text = "Send Center + Kill Feed [OFF]";
				timer4.Stop();
			}
		}

		private void timer4_Tick(object sender, EventArgs e)
		{
			int num = new Random().Next(0, 7);
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				string.Concat(new object[]
				{
					"< \"^",
					num,
					textEdit48.Text,
					"\""
				})
			});
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				string.Concat(new object[]
				{
					"; \"^",
					num,
					textEdit71.Text,
					"\""
				})
			});
		}

		private void simpleButton127_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"callvote map \"mp_hijacked\rstatsetbyname RANKXP 1\rstatsetbyname PLEVEL 0\rstatsetbyname RANK 1\r\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"disconnect"
			});
		}

		private void simpleButton128_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"callvote map \"mp_hijacked\runbindall\runbindallaxis\r\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"disconnect"
			});
		}

		private void simpleButton129_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"callvote map \"mp_hijacked\rquit\r\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"disconnect"
			});
		}

		private void simpleButton132_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"callvote map \"mp_hijacked\rstartSingleplayer\r\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"disconnect"
			});
		}

		private void simpleButton130_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"callvote map \"mp_hijacked\rstartZombies\r\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"disconnect"
			});
		}

		private void simpleButton131_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"callvote map \"mp_hijackedÜg_fov 90\r\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"disconnect"
			});
		}

		private void simpleButton133_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x822786E0, new object[]
			{
				0,
				"userinfo \"\\name\\^H^2UTR <3\\clanabbrev\\^H69^1\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"disconnect"
			});
		}

		private void simpleButton139_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			try
			{
				IXboxConsole console = Console;
				listView1.Items.Add("0 = " + Console.ReadString(0x83556EBC, 0x10));
				listView1.Items.Add("1 = " + Console.ReadString(0x8355C6B4, 0x10));
				listView1.Items.Add("2 = " + Console.ReadString(0x83561EAC, 0x10));
				listView1.Items.Add("3 = " + Console.ReadString(0x835676A4, 0x10));
				listView1.Items.Add("4 = " + Console.ReadString(0x8356CE9C, 0x10));
				listView1.Items.Add("5 = " + Console.ReadString(0x83572694, 0x10));
				listView1.Items.Add("6 = " + Console.ReadString(0x83577E8C, 0x10));
				listView1.Items.Add("7 = " + Console.ReadString(0x8357D684, 0x10));
				listView1.Items.Add("8 = " + Console.ReadString(0x83582E7C, 0x10));
				listView1.Items.Add("9 = " + Console.ReadString(0x83588674, 0x10));
				listView1.Items.Add("10 = " + Console.ReadString(0x8358DE6C, 0x10));
				listView1.Items.Add("11 = " + Console.ReadString(0x83593664, 0x10));
				listView1.Items.Add("12 = " + Console.ReadString(0x83598E5C, 0x10));
				listView1.Items.Add("13 = " + Console.ReadString(0x8359E654, 0x10));
				listView1.Items.Add("14 = " + Console.ReadString(0x835A3E4C, 0x10));
				listView1.Items.Add("15 = " + Console.ReadString(0x835A9644, 0x10));
				listView1.Items.Add("16 = " + Console.ReadString(0x835AEE3C, 0x10));
				listView1.Items.Add("17 = " + Console.ReadString(0x835B4634, 0x10));
            }
			catch
			{
			}
		}

		private void simpleButton138_Click(object sender, EventArgs e)
		{
			int num = listView1.SelectedItems[0].Index;
			bool flag = num == 21;
			bool flag2 = !flag;
			if (flag2)
			{
				try
				{
					bool flag3 = num < 19 && num > -1;
					bool flag4 = flag3;
					if (flag4)
					{
						Console.CallVoid(0x8242FB70, new object[]
						{
							num,
							0,
							"; \"^2Nigger Frozen By ^1Water CR!\""
						});
						Console.CallVoid(0x8242FB70, new object[]
						{
							num,
							0,
							"< \"^1Nigger Frozen By ^2Water CR!\""
						});
						Thread.Sleep(200);
						Console.CallVoid(0x8242FB70, new object[]
						{
							num,
							0,
							"7 30 90"
						});
					}
				}
				catch
				{
				}
			}
		}

		private void simpleButton137_Click(object sender, EventArgs e)
		{
			int num = listView1.SelectedItems[0].Index;
			bool flag = num == 21;
			bool flag2 = !flag;
			if (flag2)
			{
				try
				{
					bool flag3 = num < 19 && num > -1;
					bool flag4 = flag3;
					if (flag4)
					{
						Console.CallVoid(0x8242FB70, new object[]
						{
							selectedIndex,
							0,
							"5 \"" + textEdit47.Text + "\""
						});
					}
				}
				catch
				{
				}
			}
		}

		private void simpleButton134_Click(object sender, EventArgs e)
		{
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Go into a private match with the victim you want as host, Just have it be you and him, Choose any option once you are in the game, It will kick you from the game and pass the vote to them!", "Thanks To Heaventh For These Options!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void simpleButton136_Click(object sender, EventArgs e)
		{
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Restart your game to make it come off", "How to Fix?", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void simpleButton148_Click(object sender, EventArgs e)
		{
			setgamertag("Listen here ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("gotta tape up my speakers cuz..");
			Thread.Sleep(2000);
			setgamertag("ur queer ass smells like cheese");
			Thread.Sleep(2000);
			setgamertag("go drown in a bowl of soup");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton147_Click(object sender, EventArgs e)
		{
			setgamertag("Aye ^1" + textEdit72.Text + "!");
			Thread.Sleep(2000);
			setgamertag("ima stick my pp in ur fat bitch");
			Thread.Sleep(2000);
			setgamertag("then gonna pee in her butthole");
			Thread.Sleep(2000);
			setgamertag("hoe got dinner plate nipples");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton145_Click(object sender, EventArgs e)
		{
			setgamertag("Dis nigga ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("is the type of dumbass to..");
			Thread.Sleep(2000);
			setgamertag("lick his fingers before");
			Thread.Sleep(2000);
			setgamertag("flippin the page on an ipad");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton142_Click(object sender, EventArgs e)
		{
			setgamertag("Hey ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("go slit ur wrists and");
			Thread.Sleep(2000);
			setgamertag("do a handstand in lemonade");
			Thread.Sleep(2000);
			setgamertag("u smelly crosseyed dickwad");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton149_Click(object sender, EventArgs e)
		{
			setgamertag("Stfu ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("go papercut ur entire body");
			Thread.Sleep(2000);
			setgamertag("and roll around in piss");
			Thread.Sleep(2000);
			setgamertag("you flappy titt'd slob");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton152_Click(object sender, EventArgs e)
		{
			setgamertag("kill urself ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("go slit your eyes");
			Thread.Sleep(2000);
			setgamertag("and stare at the sun");
			Thread.Sleep(2000);
			setgamertag("you clearly have foreskin");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton141_Click(object sender, EventArgs e)
		{
			setgamertag("Yoohoo ^1" + textEdit72.Text + "!");
			Thread.Sleep(2000);
			setgamertag("U FCKN INDIAN RESTROOM SCENTED..");
			Thread.Sleep(2000);
			setgamertag("ABORTION TUBESOCK SIMULATOR");
			Thread.Sleep(2000);
			setgamertag("HEAR MY ICE FISHING FAGGOT");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton146_Click(object sender, EventArgs e)
		{
			setgamertag(" ^1" + textEdit72.Text + " is..");
			Thread.Sleep(2000);
			setgamertag("that one nigga that..");
			Thread.Sleep(2000);
			setgamertag("sat at the back of class with..");
			Thread.Sleep(2000);
			setgamertag("a pencil up his nose");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void xtraTabPage5_Paint(object sender, PaintEventArgs e)
		{

		}

		private void simpleButton143_Click(object sender, EventArgs e)
		{
			setgamertag("Listen here ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("ur big ass nose looks like..");
			Thread.Sleep(2000);
			setgamertag("the iceburg that..");
			Thread.Sleep(2000);
			setgamertag("sunk the titanic");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton144_Click(object sender, EventArgs e)
		{
			setgamertag("Hey ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("Stfu u smelly fucking..");
			Thread.Sleep(2000);
			setgamertag("empty jar of peanutbutter..");
			Thread.Sleep(2000);
			setgamertag("rusty guitar string lookin ass..");
			Thread.Sleep(2000);
			setgamertag("bag of doughnuts");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton151_Click(object sender, EventArgs e)
		{
			setgamertag("OI ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("Your secrets are always safe..");
			Thread.Sleep(2000);
			setgamertag("With me");
			Thread.Sleep(2000);
			setgamertag("I never even listen when");
			Thread.Sleep(2000);
			setgamertag("you tell me them.");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton150_Click(object sender, EventArgs e)
		{
			setgamertag("Hey ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("If your brain was dynamite");
			Thread.Sleep(2000);
			setgamertag("there wouldn’t be enough..");
			Thread.Sleep(2000);
			setgamertag("to blow your hat off");
			Thread.Sleep(2000);
			setgamertag("You sad fuck");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private async void simpleButton168_ClickAsync(object sender, EventArgs e)
		{
			setgamertag("8m===D");
			await Task.Delay(500);
			setgamertag("8=m==D");
			await Task.Delay(500);
			setgamertag("8==m=D");
			await Task.Delay(500);
			setgamertag("8===mD");
			await Task.Delay(500);
			setgamertag("8==m=D");
			await Task.Delay(500);
			setgamertag("8=m==D");
			await Task.Delay(500);
			setgamertag("8m===D");
			await Task.Delay(500);
			setgamertag("8=m==D");
			await Task.Delay(500);
			setgamertag("8==m=D ~");
			await Task.Delay(500);
			setgamertag("8===mD ~ ~");
			await Task.Delay(500);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton178_Click(object sender, EventArgs e)
		{
			setgamertag("Hey catch! ^H\u007f\u007f\vhud_icon_c4");
		}

		private void simpleButton176_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\vhint_mantle^5is a virgin");
		}

		private void simpleButton177_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f?\u0014headiconyouinkillcamSUCK!");
		}

		private void simpleButton172_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\fmenu_mp_esrb< cheat codes");
		}

		private void simpleButton174_Click(object sender, EventArgs e)
		{
			setgamertag("Marry Me^H\u007f\u007f\u0010dualoptic_down_9");
		}

		private void simpleButton171_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\breflex_8Hi im gay");
		}

		private void simpleButton175_Click(object sender, EventArgs e)
		{
			setgamertag("Official^H\u007f\u007f\u0004logoAdmin");
		}

		private void simpleButton173_Click(object sender, EventArgs e)
		{
			setgamertag("ui_globe");
		}

		private async void simpleButton169_ClickAsync(object sender, EventArgs e)
		{
			Process proc = Process.GetProcessesByName("Spotify").FirstOrDefault((Process p) => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
			bool flag = proc == null;
			if (flag)
			{
			}
			bool flag2 = string.Equals(proc.MainWindowTitle, "Spotify", StringComparison.InvariantCultureIgnoreCase);
			if (flag2)
			{
			}
			setgamertag("^6L");
			await Task.Delay(250);
			setgamertag("^5Li");
			await Task.Delay(250);
			setgamertag("^6Lis");
			await Task.Delay(250);
			setgamertag("^5List");
			await Task.Delay(250);
			setgamertag("^6Liste");
			await Task.Delay(250);
			setgamertag("^5Listen");
			await Task.Delay(250);
			setgamertag("^6Listeni");
			await Task.Delay(250);
			setgamertag("^5Listenin");
			await Task.Delay(250);
			setgamertag("^6Listening");
			await Task.Delay(250);
			setgamertag("^5Listening T");
			await Task.Delay(250);
			setgamertag("^6Listening To");
			await Task.Delay(250);
			setgamertag("^5Listening To.");
			await Task.Delay(250);
			setgamertag("^6Listening To..");
			await Task.Delay(250);
			setgamertag("^5Listening To...");
			await Task.Delay(250);
			setgamertag("^6Listening To.");
			await Task.Delay(250);
			setgamertag("^5Listening To..");
			await Task.Delay(250);
			setgamertag("^6Listening To...");
			await Task.Delay(250);
			setgamertag("^5" + proc.MainWindowTitle);
			await Task.Delay(250);
			setgamertag("^6" + proc.MainWindowTitle);
			await Task.Delay(250);
			setgamertag("^5" + proc.MainWindowTitle);
			await Task.Delay(250);
			setgamertag("^6" + proc.MainWindowTitle);
			await Task.Delay(250);
			setgamertag("^5" + proc.MainWindowTitle);
			await Task.Delay(250);
			setgamertag("^6" + proc.MainWindowTitle);
			await Task.Delay(250);
			setgamertag("^5" + proc.MainWindowTitle);
			await Task.Delay(250);
			setgamertag("^6" + proc.MainWindowTitle);
			await Task.Delay(250);
			setgamertag("on ^2Spotify");
			await Task.Delay(2500);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton170_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\bthumbsup");
		}

		private void simpleButton167_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\vperk_hacker");
		}

		private void simpleButton166_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\u0013cac_mods_dual_wield");
		}

		private void simpleButton155_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\u0013compass_map_flicker");
		}

		private void simpleButton153_Click(object sender, EventArgs e)
		{
			setgamertag("[{+forward}] FAGS [{+back}]");
		}

		private void simpleButton165_Click(object sender, EventArgs e)
		{
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]) + "^0[]");
		}

		private async void simpleButton154_ClickAsync(object sender, EventArgs e)
		{
			setgamertag("^6R^7ead");
			await Task.Delay(500);
			setgamertag("^7R^6e^7ad");
			await Task.Delay(500);
			setgamertag("^7R^7e^6a^7d");
			await Task.Delay(500);
			setgamertag("^7R^7e^7a^6d");
			await Task.Delay(500);
			setgamertag("^7R^7e^6a^7d");
			await Task.Delay(500);
			setgamertag("^7R^6e^7a^7d");
			await Task.Delay(500);
			setgamertag("^6R^7e^7a^7d");
			await Task.Delay(500);
			setgamertag("^6Read");
			await Task.Delay(630);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton159_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\u0017menu_lobby_icon_twitter");
		}

		private void simpleButton160_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\fyoutube_logo");
		}

		private void simpleButton158_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\u0017playlist_search_destroy");
		}

		private void simpleButton157_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\vhint_mantlethis fgt tho");
		}

		private void simpleButton156_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\bui_smoke");
		}

		private void simpleButton162_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u000ecac_restrictedFAGS AHEAD!");
		}

		private void simpleButton161_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\u000ehud_anim_cobra");
		}

		private void simpleButton181_Click(object sender, EventArgs e)
		{
			setgamertag("^H\rxenonbutton_x");
		}

		private void simpleButton180_Click(object sender, EventArgs e)
		{
			setgamertag("^H\rxenonbutton_y");
		}

		private void simpleButton179_Click(object sender, EventArgs e)
		{
			setgamertag("^H\rxenonbutton_b");
		}

		private void simpleButton164_Click(object sender, EventArgs e)
		{
			setgamertag("^H\rxenonbutton_a");
		}

		private void simpleButton183_Click(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\u0019menu_codtv_icon_mychannel");
		}

		private async void simpleButton182_ClickAsync(object sender, EventArgs e)
		{
			setgamertag("^5W^7ater");
			await Task.Delay(500);
			setgamertag("^7W^5a^7ter");
			await Task.Delay(500);
			setgamertag("^7W^7a^5t^7er");
			await Task.Delay(500);
			setgamertag("^7W^7a^7t^5e^7r");
			await Task.Delay(500);
			setgamertag("^7W^7a^7t^7e^5r");
			await Task.Delay(500);
			setgamertag("^7Water");
			await Task.Delay(500);
			setgamertag("^5Water CR");
			await Task.Delay(630);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton184_Click(object sender, EventArgs e)
		{
			setgamertag("Gonzo");
		}

		private void simpleButton185_Click(object sender, EventArgs e)
		{
			setgamertag("^6LMD Team");
		}

		private void simpleButton186_Click(object sender, EventArgs e)
		{
			Console.XNotify("Troll Activated Against: \"" + textEdit73.Text + "\"");
			setgamertag("^6Hey, ^5 \"" + textEdit73.Text + "\"");
			Thread.Sleep(2200);
			setgamertag("^1Liking that Wifi??");
			Thread.Sleep(2200);
			setgamertag("^5Keep being a ^6Retard...");
			Thread.Sleep(2200);
			setgamertag("^3And that shit's gonna go");
			Thread.Sleep(1750);
			setgamertag("^H\u007f\u007f\vping_bar_04");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\vping_bar_03");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\vping_bar_02");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\vping_bar_01");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\u0011net_new_animation");
			Thread.Sleep(2750);
			setgamertag("^H\u007f\u007f\u000ecompass_static");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\u000ecompass_static #OFFLINE");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\u000ecompass_static");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\u000ecompass_static #OFFLINE");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\u000ecompass_static");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\u000ecompass_static #OFFLINE");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\u000ecompass_static");
			Thread.Sleep(750);
			setgamertag("^H\u007f\u007f\u000ecompass_static #OFFLINE");
			Thread.Sleep(750);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton187_Click(object sender, EventArgs e)
		{
			setgamertag("Hey ^5" + textEdit74.Text);
			Thread.Sleep(2000);
			setgamertag("Ya wanna fokin go offline m8 ??");
			Thread.Sleep(2000);
			setgamertag("Quit being a retard or");
			Thread.Sleep(2000);
			setgamertag("Ur router bouta be like..");
			Thread.Sleep(2000);
			setgamertag("^H\u007f\u007f\vping_bar_04");
			Thread.Sleep(300);
			setgamertag("^H\u007f\u007f\vping_bar_03");
			Thread.Sleep(300);
			setgamertag("^H\u007f\u007f\vping_bar_02");
			Thread.Sleep(300);
			setgamertag("^H\u007f\u007f\vping_bar_01");
			Thread.Sleep(300);
			setgamertag("^H\u007f\u007f\u0011net_new_animation");
			Thread.Sleep(3000);
			setgamertag("^H\u007f\u007f\u000ecompass_static");
			Thread.Sleep(500);
			setgamertag("^H\u007f\u007f\u000ecompass_static #OFFLINE");
			Thread.Sleep(500);
			setgamertag("^H\u007f\u007f\u000ecompass_static");
			Thread.Sleep(500);
			setgamertag("^H\u007f\u007f\u000ecompass_static #OFFLINE");
			Thread.Sleep(500);
			setgamertag("^H\u007f\u007f\u000ecompass_static");
			Thread.Sleep(500);
			setgamertag("^H\u007f\u007f\u000ecompass_static #OFFLINE");
			Thread.Sleep(500);
			setgamertag("^H\u007f\u007f\u000ecompass_static");
			Thread.Sleep(500);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton188_Click(object sender, EventArgs e)
		{
			setgamertag("Im Drinking ^5Water!");
		}

		private void simpleButton189_Click(object sender, EventArgs e)
		{
			setgamertag("Hey ^1" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("get outta here with ur");
			Thread.Sleep(2000);
			setgamertag("$3 gonzo mic you");
			Thread.Sleep(2000);
			setgamertag("utter sped looking bitch");
			Thread.Sleep(2000);
			setgamertag("ass nigga");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton190_Click(object sender, EventArgs e)
		{
			HttpRequest httpRequest = new HttpRequest();
			string str = textEdit75.Text;
			string json = httpRequest.Get("http:ip-api.com/json/" + str, null).ToString();
			JObject jobject = JObject.Parse(json);
			label15.Text = jobject.SelectToken("country").ToString();
			label20.Text = jobject.SelectToken("regionName").ToString();
			label18.Text = jobject.SelectToken("city").ToString();
			label19.Text = jobject.SelectToken("zip").ToString();
			label16.Text = jobject.SelectToken("isp").ToString();
			label17.Text = jobject.SelectToken("org").ToString();
		}

		private void label15_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(label15.Text);
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Copy To Clipboard", "Copied Country!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void label20_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(label20.Text);
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Copy To Clipboard", "Copied Reigon!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void label18_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(label18.Text);
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Copy To Clipboard", "Copied City!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void label16_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(label16.Text);
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Copy To Clipboard", "Copied ISP!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void label19_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(label19.Text);
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Copy To Clipboard", "Copied ZIP!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void label17_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(label17.Text);
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Copy To Clipboard", "Copied ORG!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void simpleButton191_Click(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Welcome " + "Gonzo"/*Auth.GG_Winform_Example.User.Username*/ + "\n\nTime to Sip on me Water", "Hello!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void simpleButton191_Click_1(object sender, EventArgs e)
		{
		}

		private void label21_Click(object sender, EventArgs e)
		{
		}

		private void simpleButton192_Click(object sender, EventArgs e)
		{
		}

		private void simpleButton191_Click_2(object sender, EventArgs e)
		{
			textEdit76.Text = BitConverter.ToInt32(Console.GetMemory(0x83732B5B, 4), 0).ToString();
			textEdit77.Text = BitConverter.ToInt32(Console.GetMemory(0x83732B6B, 4), 0).ToString();
			textEdit79.Text = BitConverter.ToInt32(Console.GetMemory(0x83732B6F, 4), 0).ToString();
			textEdit78.Text = BitConverter.ToInt32(Console.GetMemory(0x83732B4F, 4), 0).ToString();
			textEdit76.Enabled = true;
			textEdit77.Enabled = true;
			textEdit79.Enabled = true;
			textEdit78.Enabled = true;
			simpleButton191.Enabled = false;
			simpleButton192.Enabled = true;
		}

		private void simpleButton192_Click_1(object sender, EventArgs e)
		{
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(textEdit76.Text));
			Console.SetMemory(0x83732B5B, bytes);
			byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(textEdit77.Text));
			Console.SetMemory(0x83732B6B, bytes2);
			byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(textEdit79.Text));
			Console.SetMemory(0x83732B6F, bytes3);
			byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(textEdit78.Text));
			Console.SetMemory(0x83732B4F, bytes4);
			textEdit76.Enabled = false;
			textEdit77.Enabled = false;
			textEdit79.Enabled = false;
			textEdit78.Enabled = false;
			simpleButton191.Enabled = true;
			simpleButton192.Enabled = false;
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "Stats set.", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void simpleButton194_Click(object sender, EventArgs e)
		{
		}


		private void simpleButton193_Click(object sender, EventArgs e)
		{
			Console.SetMemory(0x83732B57, new byte[]
			{
				5
			});
		}

		private void label10_Click(object sender, EventArgs e)
		{
			Process.Start("https:discord.gg/c2t2TRFKPM");
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "This Tool was copy pasted by Read, Support\n\nHelper: Heaventh", "Water CR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void simpleButton6_Click(object sender, EventArgs e)
		{

		}

		private void checkEdit2_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void simpleButton194_Click_1(object sender, EventArgs e)
		{
			setgamertag(DateTime.Now.ToLongTimeString() ?? "");
		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
		{

		}

		private void simpleButton195_Click(object sender, EventArgs e)
		{
			setgamertag("^1Infection ^4Police");
		}

		private void simpleButton196_Click(object sender, EventArgs e)
		{
			setgamertag("^1Hey! ^2" + textEdit72.Text);
			Thread.Sleep(2000);
			setgamertag("you fucking saggy tit bitch");
			Thread.Sleep(2000);
			setgamertag("gonzo looking cheeto dust");
			Thread.Sleep(2000);
			setgamertag("slit ya wrist fat fuck");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton197_Click(object sender, EventArgs e)
		{
			setgamertag("^5Exultah Being a Pedo");
			Thread.Sleep(2000);
			setgamertag("^6https:missroduniverse.com/");
			Thread.Sleep(2000);
			setgamertag("^5Exultah Being a Pedo");
			Thread.Sleep(2000);
			setgamertag("^6https:missroduniverse.com/");
			Thread.Sleep(2000);
			setgamertag("^5Exultah Being a Pedo");
			Thread.Sleep(2000);
			setgamertag("^6https:missroduniverse.com/");
			Thread.Sleep(2000);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		private void simpleButton198_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"xstartpartyhost"
			});
            Console.SetMemory(0x8227A500, new byte[] { 0x60, 0x00, 0x00, 0x00 });
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"set party_minplayers 1; xpartygo"
			});
		}

		private void simpleButton199_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton199.Text == "Long Knife [OFF]";
			if (flag)
			{
				simpleButton199.Text = "Long Knife [ON]";
				Console.CallVoid(BO2CMD, new object[]
				{
					0,
					"player_meleeRange 999; cg_meleerange 999"
				});
				Console.CallVoid(BO2SV, new object[]
				{
					-1,
					0,
					"< \"LongKnife [^2ON^\""
				});
			}
			else
			{
				simpleButton199.Text = "Long Knife [OFF]";
				Console.CallVoid(BO2CMD, new object[]
				{
					0,
					"player_meleeRange 1; cg_meleerange 1"
				});
				Console.CallVoid(BO2SV, new object[]
				{
					-1,
					0,
					"< \"^1LongKnife OFF :(\""
				});
			}
		}

		private void simpleButton211_Click(object sender, EventArgs e)
		{
			if (Console.Connect(out Console))
			{
                simpleButton211.Text = "Re-Connect To Console";
				simpleButton211.ForeColor = Color.White;
				Console.XNotify("Welcome '" + Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]) + "' To Water CR!\nTime Left: " + "Gozno"/*Auth.GG_Winform_Example.User.Expiry*/);
				textEdit29.Text = (Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]) ?? "");
			}
			else
			{
				simpleButton211.Text = "Error Connecting!";
				simpleButton211.ForeColor = Color.White;
				XtraMessageBox.Show(styleController1.LookAndFeel, "ERROR: Please check that you have JRPC2 as a Plugin!\nMake Sure your console is set as Default on Xbox 360 Neighborhood\nMake sure all .dlls are in the Water File", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			_rpcClient.SetPresence(new RichPresence
			{
				Details = "Connected",
				State = "Water CR Tool",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageKey = "watercr",
                    LargeImageText = "Cracked By Heaventh"
				}
			});
		}

		private AV_PACK GetAVPack()
		{
			uint num = Console.ResolveFunction("xam.xex", 2601U) + 12288U;
			Array.Clear(SMCMessage, 0, SMCMessage.Length);
			SMCMessage[0] = 15;
			IXboxConsole console = Console;
			string module = "xboxkrnl.exe";
			int ordinal = 41;
			object[] array = new object[3];
			array[0] = SMCMessage;
			array[1] = num;
			Console.CallVoid(module, ordinal, array);
			byte[] memory = Console.GetMemory(num, 4U);
			return (AV_PACK)memory[1];
		}

		private void simpleButton210_Click(object sender, EventArgs e)
		{
			textEdit97.Text = "CPU Key: " + Console.GetCPUKey();
			textEdit93.Text = "Kernel: " + Console.GetKernalVersion();
			textEdit96.Text = "Console IP: " + Console.XboxIP();
			textEdit95.Text = "Console Type: " + Console.ConsoleType();
			textEdit94.Text = "GPU Temperature: " + Console.GetTemperature(JRPC.TemperatureType.GPU).ToString();
			textEdit90.Text = "CPU Temperature: " + Console.GetTemperature(JRPC.TemperatureType.CPU).ToString();
			textEdit92.Text = "MotherBoard Temperature: " + Console.GetTemperature(JRPC.TemperatureType.MotherBoard);
			textEdit91.Text = "RAM Temperature: " + Console.GetTemperature(JRPC.TemperatureType.EDRAM);
			textEdit89.Text = "Hash: " + Console.GetHashCode();
			textEdit86.Text = "Console Name: " + Console.Name;
			textEdit88.Text = "Title ID: " + Console.XamGetCurrentTitleId().ToString();
			textEdit87.Text = "Game ID: " + Console.XamGetCurrentTitleId().ToString("X");
			textEdit83.Text = "Gamertag: " + Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]);
			textEdit85.Text = "City: " + GeoLocationCity(MyIP);
			textEdit84.Text = "State: " + GeoLocationState(MyIP);
		}

		private void simpleButton205_Click(object sender, EventArgs e)
		{
			Console.Reboot(null, null, null, XboxRebootFlags.Cold);
		}

		private void simpleButton208_Click(object sender, EventArgs e)
		{
			Console.ShutDownConsole();
		}

		private void simpleButton206_Click(object sender, EventArgs e)
		{
			Console.Reboot(null, null, null, XboxRebootFlags.Warm);
		}

		private void simpleButton203_Click(object sender, EventArgs e)
		{
			Console.XNotify(textEdit82.Text);
		}

		private void simpleButton209_Click(object sender, EventArgs e)
		{
			Console.CallVoid("xboxkrnl.exe", 434, new object[]
			{
				69
			});
		}

		private void simpleButton207_Click(object sender, EventArgs e)
		{
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "^1 - Red\n^2 - Green\n^3 - Light Yellow\n^4 - Blue\n^5 - Cyan\n^6 - Pink\n^7 - White\n^8 - Grey\n^9 - Brown", "Colours", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		private void Cbuff_Addtext(string text)
		{
			Console.CallVoid(0x82224990, new object[]
			{
				0,
				text
			});
		}

		private void simpleButton202_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				textEdit81.Text
			});
		}

		private void simpleButton204_Click(object sender, EventArgs e)
		{
			foreach (Process process in Process.GetProcessesByName("Discord"))
			{
				process.Kill();
			}
		}

		private void simpleButton200_Click(object sender, EventArgs e)
		{
			dashmessage(textEdit80.Text, textBox2.Text, textEdit98.Text);
		}

		private void simpleButton201_Click(object sender, EventArgs e)
		{
             Array.Clear(SMCMessage, 0, SMCMessage.Length);
             SMCMessage[0] = 0x94;
             bool flag = zoomTrackBarControl2.Value < 45;
             if (flag)
             {
             	SMCMessage[1] = 127;
             }
             else
             {
             	byte b = Convert.ToByte(zoomTrackBarControl2.Value);
                 SMCMessage[1] = b;
             }
             
             Console.Call<uint>(Console.ResolveFunction("xboxkrnl.exe", 41), SMCMessage);
             SMCMessage[0] = 0x89;
             object[] array2 = new object[2];
             array2[0] = SMCMessage;
             Console.Call<uint>(Console.ResolveFunction("xboxkrnl.exe", 41), array2);
        }

		private void zoomTrackBarControl2_EditValueChanged(object sender, EventArgs e)
		{
			int value = zoomTrackBarControl2.Value;
			label9.Text = zoomTrackBarControl2.Value + "%".ToString();
		}

		private void simpleButton2_Click_1(object sender, EventArgs e)
		{
			textEdit1.Text = "Welcome back, " + "Gonzo" /*Auth.GG_Winform_Example.User.Username*/ + "!";
			textEdit3.Text = "IP: " + "1.1.1.1"/*Auth.GG_Winform_Example.User.IP*/;
			textEdit2.Text = "Expiry: " + "Gozno"/*Auth.GG_Winform_Example.User.Expiry*/;
			textEdit9.Text = "Last Login: " + "like idk right now i guess"/*Auth.GG_Winform_Example.User.LastLogin*/;
			textEdit8.Text = "Register Date: " + "Idk yesterday"/*Auth.GG_Winform_Example.User.RegisterDate*/;
			textEdit5.Text = "Email: " + "Gonzo@GonzoMagic.com"/*Auth.GG_Winform_Example.User.Email*/;
			textEdit7.Text = "HWID: " + "Careful read is going to rat your HWID"/*Auth.GG_Winform_Example.User.HWID*/;
			textEdit6.Text = "ID: " + 123453432/*Auth.GG_Winform_Example.User.ID*/;
			textEdit4.Text = "Password: " + "passw0rd123" /*Auth.GG_Winform_Example.User.Password*/;
		}

		private void label10_Click_1(object sender, EventArgs e)
		{
			Process.Start("https:discord.gg/jPgQYS6Jut");
		}

		private void simpleButton7_Click_1(object sender, EventArgs e)
		{
			bool flag = File.Exists("screenshot.dds");
			if (flag)
			{
				File.Delete("screenshot.dds");
			}
			Console.ScreenShot("screenshot.dds");
			bool flag2 = File.Exists("screenshot.dds");
			if (flag2)
			{
				pictureEdit2.Image = DDS.LoadImage("screenshot.dds", true);
				File.Delete("screenshot.dds");
			}
			GC.Collect();
		}

		 //0x0600016A RID: 362 RVA: 0x0000CE34 File Offset: 0x0000B034
		private void simpleButton5_Click_1(object sender, EventArgs e)
		{
			bool flag = pictureEdit2.Image == null;
			if (flag)
			{
				bool flag2 = XtraMessageBox.Show(styleController1.LookAndFeel, "Try taking a screenshot first.", "Dumb Ass!", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK;
				if (flag2)
				{
				}
			}
			else
			{
				Clipboard.SetImage(pictureEdit2.Image);
			}
			bool flag3 = XtraMessageBox.Show(styleController1.LookAndFeel, "Screenshot\nCopied To Clipboard.", "Hello!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag3)
			{
			}
		}

		 //0x0600016B RID: 363 RVA: 0x0000CEB4 File Offset: 0x0000B0B4
		private void simpleButton6_Click_1(object sender, EventArgs e)
		{
			bool flag = pictureEdit2.Image == null;
			if (flag)
			{
				bool flag2 = XtraMessageBox.Show(styleController1.LookAndFeel, "Try taking a screenshot first.", "Dumb Ass!", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK;
				if (flag2)
				{
				}
			}
			else
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "*Images|*.png";
				ImageFormat png = ImageFormat.Png;
				bool flag3 = saveFileDialog.ShowDialog() != DialogResult.OK;
				if (!flag3)
				{
					pictureEdit2.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
				}
			}
		}

		 //0x0600016C RID: 364 RVA: 0x0000CF48 File Offset: 0x0000B148
		private async void simpleButton1_Click_1Async(object sender, EventArgs e)
		{
		}

		 //0x0600016D RID: 365 RVA: 0x0000CF92 File Offset: 0x0000B192
		private void simpleButton10_Click_1(object sender, EventArgs e)
		{
			Console.SetMemory(2218650804U, textEdit19.Text.ToByteArray());
		}

		 //0x0600016E RID: 366 RVA: 0x0000CFB8 File Offset: 0x0000B1B8
		private void simpleButton11_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton11.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton11.ForeColor = Color.White;
				IXboxConsole console = Console;
				uint address = 2187524876U;
				byte[] array = new byte[4];
				array[0] = 96;
				console.SetMemory(address, array);
			}
			else
			{
				simpleButton11.ForeColor = ForeColor;
				Console.SetMemory(2187524876U, new byte[]
				{
					65,
					130,
					0,
					28
				});
			}
		}

		 //0x0600016F RID: 367 RVA: 0x0000D054 File Offset: 0x0000B254
		private void simpleButton12_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton12.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton12.ForeColor = Color.White;
				IXboxConsole console = Console;
				uint address = 2187627756U;
				byte[] array = new byte[4];
				array[0] = 96;
				console.SetMemory(address, array);
			}
			else
			{
				simpleButton12.ForeColor = ForeColor;
				Console.SetMemory(2187627756U, new byte[]
				{
					65,
					130,
					0,
					32
				});
			}
		}

		 //0x06000170 RID: 368 RVA: 0x0000D0F0 File Offset: 0x0000B2F0
		private void simpleButton13_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton13.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton13.ForeColor = Color.White;
				IXboxConsole console = Console;
				uint address = 2187622048U;
				byte[] array = new byte[4];
				array[0] = 96;
				console.SetMemory(address, array);
			}
			else
			{
				simpleButton13.ForeColor = ForeColor;
				Console.SetMemory(2187622048U, new byte[]
				{
					66,
					154,
					0,
					32
				});
			}
		}

		 //0x06000171 RID: 369 RVA: 0x0000D18C File Offset: 0x0000B38C
		private void simpleButton14_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton14.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton14.ForeColor = Color.White;
				Console.SetMemory(2187355548U, new byte[]
				{
					56,
					192,
					0,
					105
				});
				Console.SetMemory(2187489132U, new byte[]
				{
					56,
					192,
					0,
					105
				});
			}
			else
			{
				simpleButton14.ForeColor = ForeColor;
				Console.SetMemory(2187355548U, new byte[]
				{
					127,
					198,
					243,
					120
				});
				Console.SetMemory(2187489132U, new byte[]
				{
					124,
					102,
					27,
					120
				});
			}
		}

		 //0x06000172 RID: 370 RVA: 0x0000D268 File Offset: 0x0000B468
		private void simpleButton15_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton15.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton15.ForeColor = Color.White;
				IXboxConsole console = Console;
				uint address = 2187517800U;
				byte[] array = new byte[4];
				array[0] = 96;
				console.SetMemory(address, array);
				IXboxConsole console2 = Console;
				uint address2 = 2187519544U;
				byte[] array2 = new byte[4];
				array2[0] = 96;
				console2.SetMemory(address2, array2);
				IXboxConsole console3 = Console;
				uint address3 = 2187544512U;
				byte[] array3 = new byte[4];
				array3[0] = 96;
				Console.SetMemory(address3, array3);
			}
			else
			{
				simpleButton15.ForeColor = ForeColor;
				Console.SetMemory(2186183908U, new byte[]
				{
					65,
					130,
					0,
					40
				});
				Console.SetMemory(2187519544U, new byte[]
				{
					125,
					74,
					72,
					46
				});
				Console.SetMemory(2187544512U, new byte[]
				{
					65,
					152,
					0,
					228
				});
			}
		}

		 //0x06000173 RID: 371 RVA: 0x0000D3A0 File Offset: 0x0000B5A0
		private void simpleButton16_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton16.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton16.ForeColor = Color.White;
				IXboxConsole console = Console;
				uint address = 2187673960U;
				byte[] array = new byte[4];
				array[0] = 96;
				console.SetMemory(address, array);
			}
			else
			{
				simpleButton16.ForeColor = ForeColor;
				Console.SetMemory(2187673960U, new byte[]
				{
					145,
					126,
					3,
					76
				});
			}
		}

		 //0x06000174 RID: 372 RVA: 0x0000D43C File Offset: 0x0000B63C
		private void simpleButton212_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton212.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton212.ForeColor = Color.White;
				Console.SetMemory(2206915247U, new byte[1]);
			}
			else
			{
				simpleButton212.ForeColor = ForeColor;
				Console.SetMemory(2206915247U, new byte[]
				{
					100
				});
			}
		}

		 //0x06000175 RID: 373 RVA: 0x0000D4C4 File Offset: 0x0000B6C4
		private void simpleButton68_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton68.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton68.ForeColor = Color.White;
				Console.SetMemory(2206238222U, new byte[]
				{
					byte.MaxValue,
					byte.MaxValue
				});
				Console.SetMemory(2206238270U, new byte[]
				{
					byte.MaxValue,
					byte.MaxValue
				});
				Console.SetMemory(2206238246U, new byte[]
				{
					byte.MaxValue,
					byte.MaxValue,
					0,
					0,
					byte.MaxValue,
					byte.MaxValue
				});
				Console.SetMemory(2206238294U, new byte[]
				{
					byte.MaxValue,
					byte.MaxValue,
					0,
					0,
					byte.MaxValue,
					byte.MaxValue
				});
			}
			else
			{
				simpleButton68.ForeColor = ForeColor;
				Console.SetMemory(2206238222U, new byte[2]);
				Console.SetMemory(2206238270U, new byte[2]);
				Console.SetMemory(2206238246U, new byte[6]);
				Console.SetMemory(2206238294U, new byte[6]);
			}
		}

		 //0x06000176 RID: 374 RVA: 0x0000D608 File Offset: 0x0000B808
		private void simpleButton67_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton67.ForeColor == ForeColor;
			bool flag2 = flag;
			if (flag2)
			{
				simpleButton67.ForeColor = Color.White;
				Console.SetMemory(2201815019U, new byte[1]);
			}
			else
			{
				bool flag3 = simpleButton67.ForeColor == Color.Lime;
				bool flag4 = flag3;
				if (flag4)
				{
					simpleButton67.ForeColor = ForeColor;
					Console.SetMemory(2201815019U, new byte[]
					{
						100
					});
				}
			}
		}

		 //0x06000177 RID: 375 RVA: 0x0000D6AC File Offset: 0x0000B8AC
		private void simpleButton224_Click(object sender, EventArgs e)
		{
			byte[] memory = Console.GetMemory(2208743937U, 4U);
			byte[] memory2 = Console.GetMemory(2208743897U, 4U);
			byte[] memory3 = Console.GetMemory(2208743761U, 4U);
			byte[] memory4 = Console.GetMemory(2208743917U, 4U);
			byte[] memory5 = Console.GetMemory(2208743921U, 4U);
			byte[] memory6 = Console.GetMemory(2208743978U, 4U);
			byte[] memory7 = Console.GetMemory(2208744022U, 4U);
			byte[] memory8 = Console.GetMemory(2208743829U, 4U);
			byte[] memory9 = Console.GetMemory(2208744006U, 4U);
			uint num = BitConverter.ToUInt32(memory, 0);
			uint num2 = BitConverter.ToUInt32(memory2, 0);
			uint num3 = BitConverter.ToUInt32(memory3, 0);
			uint num4 = BitConverter.ToUInt32(memory4, 0);
			uint num5 = BitConverter.ToUInt32(memory5, 0);
			uint num6 = BitConverter.ToUInt32(memory6, 0);
			uint num7 = BitConverter.ToUInt32(memory7, 0);
			uint num8 = BitConverter.ToUInt32(memory8, 0);
			uint num9 = BitConverter.ToUInt32(memory9, 0);
			textEdit23.Text = Text;
			textEdit22.Text = Text;
			textEdit26.Text = Text;
			textEdit25.Text = Text;
			textEdit28.Text = Text;
			textEdit24.Text = Text;
			textEdit21.Text = Text;
			textEdit27.Text = Text;
			textEdit20.Text = Text;
		}

		 //0x06000178 RID: 376 RVA: 0x0000D85C File Offset: 0x0000BA5C
		private void simpleButton223_Click(object sender, EventArgs e)
		{
			Console.SetMemory(2208743937U, new byte[4]);
			byte[] bytes = BitConverter.GetBytes(Convert.ToUInt32(textEdit23.Text));
			Console.SetMemory(2208743937U, bytes);
			Console.SetMemory(2208743897U, new byte[4]);
			byte[] bytes2 = BitConverter.GetBytes(Convert.ToUInt32(textEdit22.Text));
			Console.SetMemory(2208743897U, bytes2);
			Console.SetMemory(2208743761U, new byte[4]);
			byte[] bytes3 = BitConverter.GetBytes(Convert.ToUInt32(textEdit26.Text));
			Console.SetMemory(2208743761U, bytes3);
			Console.SetMemory(2208743917U, new byte[4]);
			byte[] bytes4 = BitConverter.GetBytes(Convert.ToUInt32(textEdit25.Text));
			Console.SetMemory(2208743917U, bytes4);
			Console.SetMemory(2208743921U, new byte[4]);
			byte[] bytes5 = BitConverter.GetBytes(Convert.ToUInt32(textEdit28.Text));
			Console.SetMemory(2208743921U, bytes5);
			Console.SetMemory(2208743978U, new byte[4]);
			byte[] bytes6 = BitConverter.GetBytes(Convert.ToUInt32(textEdit24.Text));
			Console.SetMemory(2208743978U, bytes6);
			Console.SetMemory(2208744022U, new byte[4]);
			byte[] bytes7 = BitConverter.GetBytes(Convert.ToUInt32(textEdit21.Text));
			Console.SetMemory(2208744022U, bytes7);
			Console.SetMemory(2208743829U, new byte[4]);
			byte[] bytes8 = BitConverter.GetBytes(Convert.ToUInt32(textEdit27.Text));
			Console.SetMemory(2208743829U, bytes8);
			Console.SetMemory(2208744006U, new byte[4]);
			byte[] bytes9 = BitConverter.GetBytes(Convert.ToUInt32(textEdit20.Text));
			Console.SetMemory(2208744006U, bytes9);
		}

		 //0x06000179 RID: 377 RVA: 0x0000DAAC File Offset: 0x0000BCAC
		private void simpleButton225_Click(object sender, EventArgs e)
		{
			byte[] array = new byte[30];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte.MaxValue;
			}
			Console.SetMemory(2208780154U, array);
		}

		 //0x0600017A RID: 378 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
		private void simpleButton222_Click(object sender, EventArgs e)
		{
			Console.SetMemory(2208767550U, new byte[]
			{
				80,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				5,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				20,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				40,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				15,
				0,
				0,
				5,
				5,
				0,
				125,
				0,
				100,
				0,
				6,
				0,
				80,
				0,
				80,
				0,
				15,
				0,
				0,
				0,
				5,
				0,
				125,
				0,
				100,
				0,
				6,
				0,
				80,
				0,
				80,
				0,
				15,
				0,
				0,
				0,
				5,
				0,
				125,
				0,
				100,
				0,
				6,
				0,
				80,
				0,
				80,
				0,
				15,
				0,
				5,
				0,
				125,
				0,
				100,
				0,
				6,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				80,
				0,
				80,
				0,
				10,
				0,
				40,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				7,
				0,
				30,
				0,
				30,
				0,
				25,
				0,
				10,
				0,
				50,
				0,
				25,
				0,
				6,
				0,
				30,
				0,
				30,
				0,
				25,
				0,
				10,
				0,
				50,
				0,
				25,
				0,
				6,
				0,
				30,
				0,
				30,
				0,
				25,
				0,
				10,
				0,
				50,
				0,
				25,
				0,
				6,
				0,
				30,
				0,
				30,
				0,
				25,
				0,
				10,
				0,
				50,
				0,
				25,
				0,
				6,
				0,
				75,
				0,
				25,
				0,
				10,
				0,
				5,
				0,
				3,
				0,
				5,
				0,
				5,
				0,
				7,
				0,
				75,
				0,
				25,
				0,
				10,
				0,
				5,
				0,
				3,
				0,
				5,
				0,
				5,
				0,
				7,
				0,
				75,
				0,
				25,
				0,
				10,
				0,
				5,
				0,
				3,
				0,
				5,
				0,
				5,
				0,
				7,
				0,
				30,
				0,
				30,
				0,
				10,
				0,
				5,
				0,
				5,
				0,
				25,
				0,
				50,
				0,
				6,
				0,
				25,
				0,
				25,
				0,
				10,
				0,
				10,
				0,
				10,
				0,
				75,
				0,
				50,
				0,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				80,
				0,
				80,
				0,
				40,
				0,
				0,
				0,
				40,
				0,
				200,
				0,
				150,
				0,
				6
			});
		}

		 //0x0600017B RID: 379 RVA: 0x0000DB19 File Offset: 0x0000BD19
		private void simpleButton226_Click(object sender, EventArgs e)
		{
		}

		 //0x0600017C RID: 380 RVA: 0x0000DB1C File Offset: 0x0000BD1C
		private void simpleButton227_Click(object sender, EventArgs e)
		{
			Console.SetMemory(2203393598U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			});
			Console.SetMemory(2203393602U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			});
			Console.SetMemory(2203393606U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			});
		}

		 //0x0600017D RID: 381 RVA: 0x0000DB9F File Offset: 0x0000BD9F
		private void simpleButton228_Click(object sender, EventArgs e)
		{
			Cbuff_Addtext("set xblive_privatematch 1;wait 200;xpartygo;wait 200;set xblive_privatematch 0");
		}

		 //0x0600017E RID: 382 RVA: 0x0000DBAE File Offset: 0x0000BDAE
		private void simpleButton231_Click(object sender, EventArgs e)
		{
		}

		 //0x0600017F RID: 383 RVA: 0x0000DBB4 File Offset: 0x0000BDB4
		private void simpleButton236_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2184154064U, 19.6f);
			Console.WriteFloat(2184153920U, -11f);
			Console.WriteFloat(2182565592U, 1456.35f);
			Console.WriteFloat(2181667224U, 1.92f);
			Console.XNotify("Flip God Mod Set Enabled !");
		}

		 //0x06000180 RID: 384 RVA: 0x0000DC2C File Offset: 0x0000BE2C
		private void simpleButton235_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2184154064U, 140f);
			Console.WriteFloat(2184153920U, -120f);
			Console.WriteFloat(2182565592U, 1356f);
			Console.WriteFloat(2181667224U, 15f);
			Console.SetMemory(2187149664U, new byte[]
			{
				85,
				100,
				64,
				0
			});
			Console.XNotify("Water Skate 3 Mod Set Enabled !");
		}

		 //0x06000181 RID: 385 RVA: 0x0000DCC5 File Offset: 0x0000BEC5
		private void simpleButton234_Click(object sender, EventArgs e)
		{
			Console.SetMemory(2187149664U, new byte[]
			{
				85,
				100,
				64,
				0
			});
		}

		 //0x06000182 RID: 386 RVA: 0x0000DCEC File Offset: 0x0000BEEC
		private void simpleButton233_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2184154064U, 19.6f);
			Console.WriteFloat(2184153920U, -9.8f);
			Console.WriteFloat(2182565592U, 1456.35f);
			Console.WriteFloat(2181667224U, 1.92f);
			Console.SetMemory(2187149664U, new byte[]
			{
				85,
				100,
				6,
				62
			});
			Console.XNotify("Water Mod Sets Disabled");
		}

		 //0x06000183 RID: 387 RVA: 0x0000DD88 File Offset: 0x0000BF88
		private void simpleButton232_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2184154064U, 19.6f);
			Console.WriteFloat(2184153920U, -9.8f);
			Console.WriteFloat(2182565592U, 1456.35f);
			Console.WriteFloat(2181667224U, 1.92f);
			Console.WriteFloat(2181812836U, 55f);
			Console.XNotify("Skate 3 Ghost Skater Set Enabled !");
		}

		 //0x06000184 RID: 388 RVA: 0x0000DE18 File Offset: 0x0000C018
		private void simpleButton258_Click(object sender, EventArgs e)
		{
			float value = float.Parse(textEdit99.Text);
			Console.WriteFloat(2184153920U, value);
		}

		 //0x06000185 RID: 389 RVA: 0x0000DE4C File Offset: 0x0000C04C
		private void simpleButton257_Click(object sender, EventArgs e)
		{
			float value = float.Parse(textEdit100.Text);
			Console.WriteFloat(2184154064U, value);
		}

		 //0x06000186 RID: 390 RVA: 0x0000DE80 File Offset: 0x0000C080
		private void simpleButton256_Click(object sender, EventArgs e)
		{
			float value = float.Parse(textEdit101.Text);
			Console.WriteFloat(2181812836U, value);
		}

		 //0x06000187 RID: 391 RVA: 0x0000DEB4 File Offset: 0x0000C0B4
		private void simpleButton255_Click(object sender, EventArgs e)
		{
			float value = float.Parse(textEdit102.Text);
			Console.WriteFloat(2182565592U, value);
		}

		 //0x06000188 RID: 392 RVA: 0x0000DEE8 File Offset: 0x0000C0E8
		private void simpleButton254_Click(object sender, EventArgs e)
		{
			float value = float.Parse(textEdit103.Text);
			Console.WriteFloat(2182565596U, value);
		}

		 //0x06000189 RID: 393 RVA: 0x0000DF1C File Offset: 0x0000C11C
		private void simpleButton253_Click(object sender, EventArgs e)
		{
			float value = float.Parse(textEdit104.Text);
			Console.WriteFloat(2184156672U, value);
		}

		 //0x0600018A RID: 394 RVA: 0x0000DF50 File Offset: 0x0000C150
		private void simpleButton252_Click(object sender, EventArgs e)
		{
			float value = float.Parse(textEdit105.Text);
			Console.WriteFloat(2181484816U, value);
		}

		 //0x0600018B RID: 395 RVA: 0x0000DF81 File Offset: 0x0000C181
		private void simpleButton237_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2184153920U, -9.8f);
		}

		 //0x0600018C RID: 396 RVA: 0x0000DF9A File Offset: 0x0000C19A
		private void simpleButton229_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2184154064U, 19.6f);
		}

		 //0x0600018D RID: 397 RVA: 0x0000DFB3 File Offset: 0x0000C1B3
		private void simpleButton230_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2181812836U, 255f);
		}

		 //0x0600018E RID: 398 RVA: 0x0000DFCC File Offset: 0x0000C1CC
		private void simpleButton238_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2182565592U, 1456.35f);
		}

		 //0x0600018F RID: 399 RVA: 0x0000DFE5 File Offset: 0x0000C1E5
		private void simpleButton239_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2182565596U, 1023.5f);
		}

		 //0x06000190 RID: 400 RVA: 0x0000DFFE File Offset: 0x0000C1FE
		private void simpleButton240_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2184156672U, 512f);
		}

		 //0x06000191 RID: 401 RVA: 0x0000E017 File Offset: 0x0000C217
		private void simpleButton241_Click(object sender, EventArgs e)
		{
			Console.WriteFloat(2181484816U, 0.01745329f);
		}

		 //0x06000192 RID: 402 RVA: 0x0000E030 File Offset: 0x0000C230
		private void textEdit97_EditValueChanged(object sender, EventArgs e)
		{
			Clipboard.SetText(textEdit97.Text);
			bool flag = XtraMessageBox.Show(styleController1.LookAndFeel, "You have copied your CPU Key:\n\n" + textEdit97.Text, "Copied!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
			if (flag)
			{
			}
		}

		 //0x06000193 RID: 403 RVA: 0x0000E084 File Offset: 0x0000C284
		private void simpleButton231_Click_1(object sender, EventArgs e)
		{
			Console.CallVoid(2183285136U, new object[]
			{
				0,
				"cmd mr " + Console.ReadInt32(2187474912U) + " -1 endround"
			});
			Console.XNotify("Ending Game Module In Progress!");
		}

		 //0x06000194 RID: 404 RVA: 0x0000E0EA File Offset: 0x0000C2EA
		private void textEdit11_EditValueChanged(object sender, EventArgs e)
		{
			Encoding.UTF8.GetBytes(textEdit106.Text);
		}

		 //0x06000195 RID: 405 RVA: 0x0000E103 File Offset: 0x0000C303
		private void simpleButton242_Click(object sender, EventArgs e)
		{
			Console.CallVoid(2183285136U, new object[]
			{
				0,
				textEdit106.Text
			});
		}

		 //0x06000196 RID: 406 RVA: 0x0000E134 File Offset: 0x0000C334
		private void simpleButton8_Click_1(object sender, EventArgs e)
		{
			Console.SetMemory(2206967844U, new byte[32]);
			Console.SetMemory(2206967844U, Encoding.UTF8.GetBytes(textEdit108.Text));
		}

		 //0x06000197 RID: 407 RVA: 0x0000E180 File Offset: 0x0000C380
		private void simpleButton243_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton243.Text == "Force Host [OFF]";
			if (flag)
			{
				simpleButton243.Text = "Force Host [ON]";
				Cbuff_Addtext("party_connectToOthers 1; partyMigrate_disabled 1; sv_endGameIfISuck 0; badhost_endgameifisuck 0​; party_maxTeamDiff 8; set party_minplayers 18; set party_connectTimeout 1; party_hostmigration 0");
			}
			else
			{
				simpleButton243.Text = "Force Host [OFF]";
				Cbuff_Addtext("set party_minplayers 6; set party_gamestarttimelength 10; set party_pregamestarttimerlength 10; set party_timer 10; set party_connectTimeout 2500");
			}
		}

		 //0x06000198 RID: 408 RVA: 0x0000E1E7 File Offset: 0x0000C3E7
		private void simpleButton245_Click(object sender, EventArgs e)
		{
		}

		 //0x06000199 RID: 409 RVA: 0x0000E1EC File Offset: 0x0000C3EC
		private void simpleButton244_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton244.Text == "Radar [OFF]";
			if (flag)
			{
				simpleButton244.Text = "Radar [ON]";
				Cbuff_Addtext("g_compassShowEnemies 1");
			}
			else
			{
				simpleButton244.Text = "Radar [OFF]";
				Cbuff_Addtext("g_compassShowEnemies 0");
			}
		}

		 //0x0600019A RID: 410 RVA: 0x0000E254 File Offset: 0x0000C454
		private void simpleButton245_Click_1(object sender, EventArgs e)
		{
			bool flag = simpleButton245.Text == "Cartoon [OFF]";
			if (flag)
			{
				simpleButton245.Text = "Cartoon[ON]";
				Cbuff_Addtext("r_fullbright 1");
			}
			else
			{
				simpleButton245.Text = "Cartoon [OFF]";
				Cbuff_Addtext("r_fullbright 0");
			}
		}

		 //0x0600019B RID: 411 RVA: 0x0000E2BC File Offset: 0x0000C4BC
		private void simpleButton246_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton246.Text == "Red Boxs [OFF]";
			if (flag)
			{
				simpleButton246.Text = "Red Boxs [ON]";
				Console.SetMemory(2182038067U, new byte[]
				{
					1
				});
			}
			else
			{
				simpleButton246.Text = "Red Boxs [OFF]";
				Console.SetMemory(2182038067U, new byte[1]);
			}
		}

		 //0x0600019C RID: 412 RVA: 0x0000E340 File Offset: 0x0000C540
		private void simpleButton247_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton247.Text == "Thermal [OFF]";
			if (flag)
			{
				simpleButton247.Text = "Thermal [ON]";
				Console.SetMemory(2182249727U, new byte[1]);
			}
			else
			{
				simpleButton247.Text = "Thermal [OFF]";
				Console.SetMemory(2182249727U, new byte[]
				{
					1
				});
			}
		}

		 //0x0600019D RID: 413 RVA: 0x0000E3C4 File Offset: 0x0000C5C4
		private void simpleButton248_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton248.Text == "No Recoil [OFF]";
			if (flag)
			{
				simpleButton248.Text = "No Recoil [ON]";
				Console.SetMemory(2182306787U, new byte[1]);
			}
			else
			{
				simpleButton248.Text = "No Recoil [OFF]";
				Console.SetMemory(2182306787U, new byte[]
				{
					7
				});
			}
		}

		 //0x0600019E RID: 414 RVA: 0x0000E448 File Offset: 0x0000C648
		private void simpleButton249_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton249.Text == "Third Person [OFF]";
			if (flag)
			{
				simpleButton249.Text = "Third Person [ON]";
				Cbuff_Addtext("cg_thirdperson 1");
			}
			else
			{
				simpleButton249.Text = "Third Person [OFF]";
				Cbuff_Addtext("cg_thirdperson 0");
			}
		}

		 //0x0600019F RID: 415 RVA: 0x0000E4B0 File Offset: 0x0000C6B0
		private void simpleButton250_Click(object sender, EventArgs e)
		{
			bool flag = simpleButton249.Text == "Laser [OFF]";
			if (flag)
			{
				simpleButton249.Text = "Laser [ON]";
				Console.SetMemory(2182103187U, new byte[]
				{
					1
				});
			}
			else
			{
				simpleButton249.Text = "Laser [OFF]";
				Console.SetMemory(2182103187U, new byte[1]);
			}
		}

		 //0x060001A0 RID: 416 RVA: 0x0000E531 File Offset: 0x0000C731
		private void xtraTabPage11_Paint(object sender, PaintEventArgs e)
		{
		}

		 //0x060001A1 RID: 417 RVA: 0x0000E534 File Offset: 0x0000C734
		private void simpleButton251_Click(object sender, EventArgs e)
		{
			Cbuff_Addtext("cg_fov " + textEdit107.Text);
		}

		 //0x060001A2 RID: 418 RVA: 0x0000E553 File Offset: 0x0000C753
		private void simpleButton259_Click(object sender, EventArgs e)
		{
			Console.SetMemory(0x82419D54, new byte[]
			{
				1
			});
			Console.XNotify("Anti End Game Activated, Host Only");
		}

		 //0x060001A3 RID: 419 RVA: 0x0000E582 File Offset: 0x0000C782
		private void simpleButton260_Click(object sender, EventArgs e)
		{
		}

		 //0x060001A4 RID: 420 RVA: 0x0000E585 File Offset: 0x0000C785
		private void textEdit108_EditValueChanged(object sender, EventArgs e)
		{
			Encoding.UTF8.GetBytes(textEdit108.Text);
		}

		 //0x060001A5 RID: 421 RVA: 0x0000E59E File Offset: 0x0000C79E
		private void simpleButton1_Click_1(object sender, EventArgs e)
		{
			setgamertag("^6https:missroduniverse.com/");
		}

		 //0x060001A6 RID: 422 RVA: 0x0000E5AD File Offset: 0x0000C7AD
		private void simpleButton9_Click_1(object sender, EventArgs e)
		{
		}

		 //0x060001A7 RID: 423 RVA: 0x0000E5B0 File Offset: 0x0000C7B0
		private void simpleButton226_Click_1(object sender, EventArgs e)
		{
		}

		 //0x060001A8 RID: 424 RVA: 0x0000E5B4 File Offset: 0x0000C7B4
		private void simpleButton226_Click_2(object sender, EventArgs e)
		{
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				"< \"^5Ending Game... ^6Made By Read#4363...\""
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"cmd mr " + Console.ReadInt32(0x82C15758) + " -1 endround"
			});
		}

		 //0x060001A9 RID: 425 RVA: 0x0000E63C File Offset: 0x0000C83C
		private async void simpleButton260_Click_1Async(object sender, EventArgs e)
		{
			setgamertag("^H\u007f\u007f\u0002bitchin_glint  ^H¾¼½");
			Thread.Sleep(1500);
			setgamertag(Encoding.BigEndianUnicode.GetString(Console.GetMemory(0x81AA28FC, 0x1E)).Trim().Trim(new char[1]));
		}

		 //0x060001AA RID: 426 RVA: 0x0000E688 File Offset: 0x0000C888
		private async void xtraTabPage13_PaintAsync(object sender, PaintEventArgs e)
		{
		}

		 //0x060001AB RID: 427 RVA: 0x0000E6D4 File Offset: 0x0000C8D4
		private async void simpleButton261_ClickAsync(object sender, EventArgs e)
		{
		}

		 //0x060001AC RID: 428 RVA: 0x0000E71E File Offset: 0x0000C91E
		private void simpleButton262_Click(object sender, EventArgs e)
		{
		}

		 //0x060001AD RID: 429 RVA: 0x0000E721 File Offset: 0x0000C921
		private void simpleButton269_Click(object sender, EventArgs e)
		{
		}

		 //0x060001AE RID: 430 RVA: 0x0000E724 File Offset: 0x0000C924
		private async void SimpleButton261_ClickAsync(object sender, EventArgs e)
		{
		}

		 //0x060001AF RID: 431 RVA: 0x0000E770 File Offset: 0x0000C970
		private void simpleButton261_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				"; \"" + textEdit46.Text + "\""
			});
			Console.CallVoid(0x8242FB70, new object[]
			{
				-1,
				0,
				"< \"" + textEdit42.Text + "\""
			});
		}

		 //0x060001B0 RID: 432 RVA: 0x0000E80C File Offset: 0x0000CA0C
		private void simpleButton275_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
				openFileDialog.Filter = "GSC Files (*.gsc)|*.gsc|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 1;
				openFileDialog.RestoreDirectory = true;
				bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
				bool flag2 = flag;
				if (flag2)
				{
					uint num = 0x40300000U;
					string safeFileName;
					bool flag3 = (safeFileName = openFileDialog.SafeFileName) != null;
					if (flag3)
					{
						bool flag4 = !(safeFileName == "_clientids.gsc");
						if (flag4)
						{
							bool flag5 = !(safeFileName == "_development_dvars.gsc");
							if (flag5)
							{
								bool flag6 = !(safeFileName == "_ambientpackage.gsc");
								if (flag6)
								{
									bool flag7 = !(safeFileName == "_sticky_grenade.gsc");
									if (flag7)
									{
										bool flag8 = !(safeFileName == "_rank.gsc");
										if (flag8)
										{
											bool flag9 = safeFileName == "_acousticsensor.gsc";
											if (flag9)
											{
												Console.WriteUInt32(0x831EBBB4U, num);
											}
										}
										else
										{
											Console.WriteUInt32(2199830484U, num);
										}
									}
									else
									{
										Console.WriteUInt32(2199831900U, num);
									}
								}
								else
								{
									Console.WriteUInt32(2199829440U, num);
								}
							}
							else
							{
								Console.WriteUInt32(2199829632U, num);
							}
						}
						else
						{
							Console.WriteUInt32(2199830136U, num);
						}
					}
					Console.SetMemory(num, File.ReadAllBytes(openFileDialog.FileName));
					Console.XNotify("Menu Injected\nPointer: 0x" + num.ToString("X"));
					bool flag10 = XtraMessageBox.Show(styleController1.LookAndFeel, "This was made by supitstom", "Credits!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK;
					if (flag10)
					{
					}
				}
			}
		}

		 //0x060001B1 RID: 433 RVA: 0x0000EA18 File Offset: 0x0000CC18
		private void simpleButton278_Click(object sender, EventArgs e)
		{
			setgamertag("[{+attack}]");
		}

		 //0x060001B2 RID: 434 RVA: 0x0000EA27 File Offset: 0x0000CC27
		private void simpleButton277_Click(object sender, EventArgs e)
		{
			setgamertag("[{+smoke}]");
		}

		 //0x060001B3 RID: 435 RVA: 0x0000EA36 File Offset: 0x0000CC36
		private void simpleButton276_Click(object sender, EventArgs e)
		{
			setgamertag("[{+melee}]");
		}

		 //0x060001B4 RID: 436 RVA: 0x0000EA45 File Offset: 0x0000CC45
		private void simpleButton274_Click(object sender, EventArgs e)
		{
			setgamertag("[{+breath_sprint}]");
		}

		 //0x060001B5 RID: 437 RVA: 0x0000EA54 File Offset: 0x0000CC54
		private void simpleButton283_Click(object sender, EventArgs e)
		{
			setgamertag("[{+actionslot 1}]");
		}

		 //0x060001B6 RID: 438 RVA: 0x0000EA63 File Offset: 0x0000CC63
		private void simpleButton281_Click(object sender, EventArgs e)
		{
			setgamertag("[{+actionslot 2}]");
		}

		 //0x060001B7 RID: 439 RVA: 0x0000EA72 File Offset: 0x0000CC72
		private void simpleButton280_Click(object sender, EventArgs e)
		{
			setgamertag("[{+actionslot 3}]");
		}

		 //0x060001B8 RID: 440 RVA: 0x0000EA81 File Offset: 0x0000CC81
		private void simpleButton279_Click(object sender, EventArgs e)
		{
			setgamertag("[{+actionslot 4}]");
		}

		 //0x060001B9 RID: 441 RVA: 0x0000EA90 File Offset: 0x0000CC90
		private void simpleButton284_Click(object sender, EventArgs e)
		{
			bool flag = comboBoxEdit2.Text == "Default";
			if (flag)
			{
				Console.SetMemory(2210750520U, new byte[]
				{
					63,
					128,
					0,
					0,
					63,
					128,
					0,
					0,
					63,
					128
				});
			}
			bool flag2 = comboBoxEdit2.Text == "Black";
			if (flag2)
			{
				Console.SetMemory(2210750520U, new byte[]
				{
					47,
					128,
					0,
					0,
					47,
					128,
					0,
					0,
					47,
					128
				});
			}
			bool flag3 = comboBoxEdit2.Text == "Blue";
			if (flag3)
			{
				Console.SetMemory(2210750520U, new byte[]
				{
					31,
					128,
					0,
					0,
					127,
					128,
					0,
					0,
					79,
					128
				});
			}
			bool flag4 = comboBoxEdit2.Text == "Green";
			if (flag4)
			{
				Console.SetMemory(2210750520U, new byte[]
				{
					175,
					128,
					0,
					0,
					95,
					128,
					0,
					0,
					47,
					128
				});
			}
			bool flag5 = comboBoxEdit2.Text == "White";
			if (flag5)
			{
				Console.SetMemory(2210750520U, new byte[]
				{
					79,
					128,
					0,
					0,
					111,
					128,
					0,
					0,
					79,
					128
				});
			}
			bool flag6 = comboBoxEdit2.Text == "Red";
			if (flag6)
			{
				Console.SetMemory(2210750520U, new byte[]
				{
					79,
					128,
					0,
					0,
					63,
					128,
					0,
					0,
					63,
					128
				});
			}
		}

		 //0x060001BA RID: 442 RVA: 0x0000EC0C File Offset: 0x0000CE0C
		private void simpleButton285_Click(object sender, EventArgs e)
		{
			Toast(0, "lui_loader", "[^5Water CR]", "^FClass Set Names Force Updated!^F", 5);
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updatestats"
			});
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"updategamerprofile"
			});
		}

		 //0x060001BB RID: 443 RVA: 0x0000ED74 File Offset: 0x0000CF74
		private void simpleButton286_Click(object sender, EventArgs e)
		{
			Console.CallVoid(0x824015E0, new object[]
			{
				0,
				"setStatFromLocString cacloadouts customclassname 0 " + textEdit10.Text
			});
			bool flag = (string)comboBox230.SelectedItem == "MTAR";
			bool flag2 = flag;
			if (flag2)
			{
				byte[] data = new byte[]
				{
					128
				};
				uint num;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data, out num);
			}
			bool flag3 = (string)comboBox230.SelectedItem == "Type 25";
			bool flag4 = flag3;
			if (flag4)
			{
				byte[] data2 = new byte[]
				{
					112
				};
				uint num2;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data2, out num2);
			}
			bool flag5 = (string)comboBox230.SelectedItem == "SWAT-556";
			bool flag6 = flag5;
			if (flag6)
			{
				byte[] data3 = new byte[]
				{
					108
				};
				uint num3;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data3, out num3);
			}
			bool flag7 = (string)comboBox230.SelectedItem == "FAL OSW";
			bool flag8 = flag7;
			if (flag8)
			{
				byte[] data4 = new byte[]
				{
					116
				};
				uint num4;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data4, out num4);
			}
			bool flag9 = (string)comboBox230.SelectedItem == "M27";
			bool flag10 = flag9;
			if (flag10)
			{
				byte[] data5 = new byte[]
				{
					124
				};
				uint num5;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data5, out num5);
			}
			bool flag11 = (string)comboBox230.SelectedItem == "SCAR-H";
			bool flag12 = flag11;
			if (flag12)
			{
				byte[] data6 = new byte[]
				{
					100
				};
				uint num6;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data6, out num6);
			}
			bool flag13 = (string)comboBox230.SelectedItem == "SMR";
			bool flag14 = flag13;
			if (flag14)
			{
				byte[] data7 = new byte[]
				{
					120
				};
				uint num7;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data7, out num7);
			}
			bool flag15 = (string)comboBox230.SelectedItem == "M8A1";
			bool flag16 = flag15;
			if (flag16)
			{
				byte[] data8 = new byte[]
				{
					96
				};
				uint num8;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data8, out num8);
			}
			bool flag17 = (string)comboBox230.SelectedItem == "AN-94";
			bool flag18 = flag17;
			if (flag18)
			{
				byte[] data9 = new byte[]
				{
					104
				};
				uint num9;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data9, out num9);
			}
			bool flag19 = (string)comboBox230.SelectedItem == "MP7";
			bool flag20 = flag19;
			if (flag20)
			{
				byte[] data10 = new byte[]
				{
					52
				};
				uint num10;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data10, out num10);
			}
			bool flag21 = (string)comboBox230.SelectedItem == "PDW-57";
			bool flag22 = flag21;
			if (flag22)
			{
				byte[] data11 = new byte[]
				{
					60
				};
				uint num11;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data11, out num11);
			}
			bool flag23 = (string)comboBox230.SelectedItem == "Vector K10";
			bool flag24 = flag23;
			if (flag24)
			{
				byte[] data12 = new byte[]
				{
					72
				};
				uint num12;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data12, out num12);
			}
			bool flag25 = (string)comboBox230.SelectedItem == "MSMC";
			bool flag26 = flag25;
			if (flag26)
			{
				byte[] data13 = new byte[]
				{
					68
				};
				uint num13;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data13, out num13);
			}
			bool flag27 = (string)comboBox230.SelectedItem == "Chicom CQB";
			bool flag28 = flag27;
			if (flag28)
			{
				byte[] data14 = new byte[]
				{
					64
				};
				uint num14;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data14, out num14);
			}
			bool flag29 = (string)comboBox230.SelectedItem == "Skorpion EVO";
			bool flag30 = flag29;
			if (flag30)
			{
				byte[] data15 = new byte[]
				{
					56
				};
				uint num15;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data15, out num15);
			}
			bool flag31 = (string)comboBox230.SelectedItem == "Peacekeeper";
			bool flag32 = flag31;
			if (flag32)
			{
				byte[] data16 = new byte[]
				{
					76
				};
				uint num16;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data16, out num16);
			}
			bool flag33 = (string)comboBox230.SelectedItem == "Mk 48";
			bool flag34 = flag33;
			if (flag34)
			{
				byte[] data17 = new byte[]
				{
					144
				};
				uint num17;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data17, out num17);
			}
			bool flag35 = (string)comboBox230.SelectedItem == "QBB LSW";
			bool flag36 = flag35;
			if (flag36)
			{
				byte[] data18 = new byte[]
				{
					148
				};
				uint num18;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data18, out num18);
			}
			bool flag37 = (string)comboBox230.SelectedItem == "LSAT";
			bool flag38 = flag37;
			if (flag38)
			{
				byte[] data19 = new byte[]
				{
					152
				};
				uint num19;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data19, out num19);
			}
			bool flag39 = (string)comboBox230.SelectedItem == "HAMR";
			bool flag40 = flag39;
			if (flag40)
			{
				byte[] data20 = new byte[]
				{
					156
				};
				uint num20;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data20, out num20);
			}
			bool flag41 = (string)comboBox230.SelectedItem == "R870 MCS";
			bool flag42 = flag41;
			if (flag42)
			{
				byte[] data21 = new byte[]
				{
					188
				};
				uint num21;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data21, out num21);
			}
			bool flag43 = (string)comboBox230.SelectedItem == "S12";
			bool flag44 = flag43;
			if (flag44)
			{
				byte[] data22 = new byte[]
				{
					196
				};
				uint num22;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data22, out num22);
			}
			bool flag45 = (string)comboBox230.SelectedItem == "KSG";
			bool flag46 = flag45;
			if (flag46)
			{
				byte[] data23 = new byte[]
				{
					200
				};
				uint num23;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data23, out num23);
			}
			bool flag47 = (string)comboBox230.SelectedItem == "M1216";
			bool flag48 = flag47;
			if (flag48)
			{
				byte[] data24 = new byte[]
				{
					192
				};
				uint num24;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data24, out num24);
			}
			bool flag49 = (string)comboBox230.SelectedItem == "SVU-AS";
			bool flag50 = flag49;
			if (flag50)
			{
				byte[] data25 = new byte[]
				{
					172
				};
				uint num25;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data25, out num25);
			}
			bool flag51 = (string)comboBox230.SelectedItem == "DSR 50";
			bool flag52 = flag51;
			if (flag52)
			{
				byte[] data26 = new byte[]
				{
					176
				};
				uint num26;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data26, out num26);
			}
			bool flag53 = (string)comboBox230.SelectedItem == "Ballista";
			bool flag54 = flag53;
			if (flag54)
			{
				byte[] data27 = new byte[]
				{
					168
				};
				uint num27;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data27, out num27);
			}
			bool flag55 = (string)comboBox230.SelectedItem == "XPR-50";
			bool flag56 = flag55;
			if (flag56)
			{
				byte[] data28 = new byte[]
				{
					180
				};
				uint num28;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data28, out num28);
			}
			bool flag57 = (string)comboBox230.SelectedItem == "Assault Shield";
			bool flag58 = flag57;
			if (flag58)
			{
				byte[] data29 = new byte[]
				{
					228
				};
				uint num29;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data29, out num29);
			}
			bool flag59 = (string)comboBox230.SelectedItem == "Five-seven";
			bool flag60 = flag59;
			if (flag60)
			{
				byte[] data30 = new byte[]
				{
					24
				};
				uint num30;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data30, out num30);
			}
			bool flag61 = (string)comboBox230.SelectedItem == "Tac-45";
			bool flag62 = flag61;
			if (flag62)
			{
				byte[] data31 = new byte[]
				{
					12
				};
				uint num31;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data31, out num31);
			}
			bool flag63 = (string)comboBox230.SelectedItem == "B23R";
			bool flag64 = flag63;
			if (flag64)
			{
				byte[] data32 = new byte[]
				{
					16
				};
				uint num32;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data32, out num32);
			}
			bool flag65 = (string)comboBox230.SelectedItem == "Executioner";
			bool flag66 = flag65;
			if (flag66)
			{
				byte[] data33 = new byte[]
				{
					20
				};
				uint num33;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data33, out num33);
			}
			bool flag67 = (string)comboBox230.SelectedItem == "KAP-40";
			bool flag68 = flag67;
			if (flag68)
			{
				byte[] data34 = new byte[]
				{
					8
				};
				uint num34;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data34, out num34);
			}
			bool flag69 = (string)comboBox230.SelectedItem == "SMAW";
			bool flag70 = flag69;
			if (flag70)
			{
				byte[] data35 = new byte[]
				{
					212
				};
				uint num35;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data35, out num35);
			}
			bool flag71 = (string)comboBox230.SelectedItem == "FHJ-18 AA";
			bool flag72 = flag71;
			if (flag72)
			{
				byte[] data36 = new byte[]
				{
					216
				};
				uint num36;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data36, out num36);
			}
			bool flag73 = (string)comboBox230.SelectedItem == "RPG";
			bool flag74 = flag73;
			if (flag74)
			{
				byte[] data37 = new byte[]
				{
					220
				};
				uint num37;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data37, out num37);
			}
			bool flag75 = (string)comboBox230.SelectedItem == "Crossbow";
			bool flag76 = flag75;
			if (flag76)
			{
				byte[] data38 = new byte[]
				{
					232
				};
				uint num38;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data38, out num38);
			}
			bool flag77 = (string)comboBox230.SelectedItem == "Ballistic Knife";
			bool flag78 = flag77;
			if (flag78)
			{
				byte[] data39 = new byte[]
				{
					236
				};
				uint num39;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data39, out num39);
			}
			bool flag79 = (string)comboBox230.SelectedItem == "War Machine";
			bool flag80 = flag79;
			if (flag80)
			{
				byte[] data40 = new byte[]
				{
					244
				};
				uint num40;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data40, out num40);
			}
			bool flag81 = (string)comboBox230.SelectedItem == "Grenade";
			bool flag82 = flag81;
			if (flag82)
			{
				byte[] data41 = new byte[]
				{
					252
				};
				uint num41;
				Console.DebugTarget.SetMemory(2218080842U, 1U, data41, out num41);
			}
			bool flag83 = (string)comboBox228.SelectedItem == "MTAR";
			bool flag84 = flag83;
			if (flag84)
			{
				byte[] data42 = new byte[]
				{
					64
				};
				uint num42;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data42, out num42);
			}
			bool flag85 = (string)comboBox228.SelectedItem == "Type 25";
			bool flag86 = flag85;
			if (flag86)
			{
				byte[] data43 = new byte[]
				{
					56
				};
				uint num43;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data43, out num43);
			}
			bool flag87 = (string)comboBox228.SelectedItem == "SWAT-556";
			bool flag88 = flag87;
			if (flag88)
			{
				byte[] data44 = new byte[]
				{
					54
				};
				uint num44;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data44, out num44);
			}
			bool flag89 = (string)comboBox228.SelectedItem == "FAL OSW";
			bool flag90 = flag89;
			if (flag90)
			{
				byte[] data45 = new byte[]
				{
					58
				};
				uint num45;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data45, out num45);
			}
			bool flag91 = (string)comboBox228.SelectedItem == "M27";
			bool flag92 = flag91;
			if (flag92)
			{
				byte[] data46 = new byte[]
				{
					62
				};
				uint num46;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data46, out num46);
			}
			bool flag93 = (string)comboBox228.SelectedItem == "SCAR-H";
			bool flag94 = flag93;
			if (flag94)
			{
				byte[] data47 = new byte[]
				{
					50
				};
				uint num47;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data47, out num47);
			}
			bool flag95 = (string)comboBox228.SelectedItem == "SMR";
			bool flag96 = flag95;
			if (flag96)
			{
				byte[] data48 = new byte[]
				{
					60
				};
				uint num48;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data48, out num48);
			}
			bool flag97 = (string)comboBox228.SelectedItem == "M8A1";
			bool flag98 = flag97;
			if (flag98)
			{
				byte[] data49 = new byte[]
				{
					48
				};
				uint num49;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data49, out num49);
			}
			bool flag99 = (string)comboBox228.SelectedItem == "AN-94";
			bool flag100 = flag99;
			if (flag100)
			{
				byte[] data50 = new byte[]
				{
					52
				};
				uint num50;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data50, out num50);
			}
			bool flag101 = (string)comboBox228.SelectedItem == "MP7";
			bool flag102 = flag101;
			if (flag102)
			{
				byte[] data51 = new byte[]
				{
					26
				};
				uint num51;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data51, out num51);
			}
			bool flag103 = (string)comboBox228.SelectedItem == "PDW-57";
			bool flag104 = flag103;
			if (flag104)
			{
				byte[] data52 = new byte[]
				{
					30
				};
				uint num52;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data52, out num52);
			}
			bool flag105 = (string)comboBox228.SelectedItem == "Vector K10";
			bool flag106 = flag105;
			if (flag106)
			{
				byte[] data53 = new byte[]
				{
					36
				};
				uint num53;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data53, out num53);
			}
			bool flag107 = (string)comboBox228.SelectedItem == "MSMC";
			bool flag108 = flag107;
			if (flag108)
			{
				byte[] data54 = new byte[]
				{
					34
				};
				uint num54;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data54, out num54);
			}
			bool flag109 = (string)comboBox228.SelectedItem == "Chicom CQB";
			bool flag110 = flag109;
			if (flag110)
			{
				byte[] data55 = new byte[]
				{
					32
				};
				uint num55;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data55, out num55);
			}
			bool flag111 = (string)comboBox228.SelectedItem == "Skorpion EVO";
			bool flag112 = flag111;
			if (flag112)
			{
				byte[] data56 = new byte[]
				{
					28
				};
				uint num56;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data56, out num56);
			}
			bool flag113 = (string)comboBox228.SelectedItem == "Peacekeeper";
			bool flag114 = flag113;
			if (flag114)
			{
				byte[] data57 = new byte[]
				{
					38
				};
				uint num57;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data57, out num57);
			}
			bool flag115 = (string)comboBox228.SelectedItem == "Mk 48";
			bool flag116 = flag115;
			if (flag116)
			{
				byte[] data58 = new byte[]
				{
					72
				};
				uint num58;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data58, out num58);
			}
			bool flag117 = (string)comboBox228.SelectedItem == "QBB LSW";
			bool flag118 = flag117;
			if (flag118)
			{
				byte[] data59 = new byte[]
				{
					74
				};
				uint num59;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data59, out num59);
			}
			bool flag119 = (string)comboBox228.SelectedItem == "LSAT";
			bool flag120 = flag119;
			if (flag120)
			{
				byte[] data60 = new byte[]
				{
					76
				};
				uint num60;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data60, out num60);
			}
			bool flag121 = (string)comboBox228.SelectedItem == "HAMR";
			bool flag122 = flag121;
			if (flag122)
			{
				byte[] data61 = new byte[]
				{
					78
				};
				uint num61;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data61, out num61);
			}
			bool flag123 = (string)comboBox228.SelectedItem == "R870 MCS";
			bool flag124 = flag123;
			if (flag124)
			{
				byte[] data62 = new byte[]
				{
					94
				};
				uint num62;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data62, out num62);
			}
			bool flag125 = (string)comboBox228.SelectedItem == "S12";
			bool flag126 = flag125;
			if (flag126)
			{
				byte[] data63 = new byte[]
				{
					98
				};
				uint num63;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data63, out num63);
			}
			bool flag127 = (string)comboBox228.SelectedItem == "KSG";
			bool flag128 = flag127;
			if (flag128)
			{
				byte[] data64 = new byte[]
				{
					100
				};
				uint num64;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data64, out num64);
			}
			bool flag129 = (string)comboBox228.SelectedItem == "M1216";
			bool flag130 = flag129;
			if (flag130)
			{
				byte[] data65 = new byte[]
				{
					96
				};
				uint num65;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data65, out num65);
			}
			bool flag131 = (string)comboBox228.SelectedItem == "SVU-AS";
			bool flag132 = flag131;
			if (flag132)
			{
				byte[] data66 = new byte[]
				{
					86
				};
				uint num66;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data66, out num66);
			}
			bool flag133 = (string)comboBox228.SelectedItem == "DSR 50";
			bool flag134 = flag133;
			if (flag134)
			{
				byte[] data67 = new byte[]
				{
					88
				};
				uint num67;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data67, out num67);
			}
			bool flag135 = (string)comboBox228.SelectedItem == "Ballista";
			bool flag136 = flag135;
			if (flag136)
			{
				byte[] data68 = new byte[]
				{
					84
				};
				uint num68;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data68, out num68);
			}
			bool flag137 = (string)comboBox228.SelectedItem == "XPR-50";
			bool flag138 = flag137;
			if (flag138)
			{
				byte[] data69 = new byte[]
				{
					90
				};
				uint num69;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data69, out num69);
			}
			bool flag139 = (string)comboBox228.SelectedItem == "Assault Shield";
			bool flag140 = flag139;
			if (flag140)
			{
				byte[] data70 = new byte[]
				{
					114
				};
				uint num70;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data70, out num70);
			}
			bool flag141 = (string)comboBox228.SelectedItem == "Five-seven";
			bool flag142 = flag141;
			if (flag142)
			{
				byte[] data71 = new byte[]
				{
					12
				};
				uint num71;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data71, out num71);
			}
			bool flag143 = (string)comboBox228.SelectedItem == "Tac-45";
			bool flag144 = flag143;
			if (flag144)
			{
				byte[] data72 = new byte[]
				{
					6
				};
				uint num72;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data72, out num72);
			}
			bool flag145 = (string)comboBox228.SelectedItem == "B23R";
			bool flag146 = flag145;
			if (flag146)
			{
				byte[] data73 = new byte[]
				{
					8
				};
				uint num73;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data73, out num73);
			}
			bool flag147 = (string)comboBox228.SelectedItem == "Executioner";
			bool flag148 = flag147;
			if (flag148)
			{
				byte[] data74 = new byte[]
				{
					10
				};
				uint num74;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data74, out num74);
			}
			bool flag149 = (string)comboBox228.SelectedItem == "KAP-40";
			bool flag150 = flag149;
			if (flag150)
			{
				byte[] data75 = new byte[]
				{
					4
				};
				uint num75;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data75, out num75);
			}
			bool flag151 = (string)comboBox228.SelectedItem == "SMAW";
			bool flag152 = flag151;
			if (flag152)
			{
				byte[] data76 = new byte[]
				{
					106
				};
				uint num76;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data76, out num76);
			}
			bool flag153 = (string)comboBox228.SelectedItem == "FHJ-18 AA";
			bool flag154 = flag153;
			if (flag154)
			{
				byte[] data77 = new byte[]
				{
					108
				};
				uint num77;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data77, out num77);
			}
			bool flag155 = (string)comboBox228.SelectedItem == "RPG";
			bool flag156 = flag155;
			if (flag156)
			{
				byte[] data78 = new byte[]
				{
					110
				};
				uint num78;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data78, out num78);
			}
			bool flag157 = (string)comboBox228.SelectedItem == "Crossbow";
			bool flag158 = flag157;
			if (flag158)
			{
				byte[] data79 = new byte[]
				{
					116
				};
				uint num79;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data79, out num79);
			}
			bool flag159 = (string)comboBox228.SelectedItem == "Ballistic Knife";
			bool flag160 = flag159;
			if (flag160)
			{
				byte[] data80 = new byte[]
				{
					118
				};
				uint num80;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data80, out num80);
			}
			bool flag161 = (string)comboBox228.SelectedItem == "Combat Axe";
			bool flag162 = flag161;
			if (flag162)
			{
				byte[] data81 = new byte[]
				{
					128
				};
				uint num81;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data81, out num81);
			}
			bool flag163 = (string)comboBox228.SelectedItem == "Grenade";
			bool flag164 = flag163;
			if (flag164)
			{
				byte[] data82 = new byte[]
				{
					132
				};
				uint num82;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data82, out num82);
			}
			bool flag165 = (string)comboBox228.SelectedItem == "Death Machine";
			bool flag166 = flag165;
			if (flag166)
			{
				byte[] data83 = new byte[]
				{
					164
				};
				uint num83;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data83, out num83);
			}
			bool flag167 = (string)comboBox228.SelectedItem == "Knife";
			bool flag168 = flag167;
			if (flag168)
			{
				byte[] data84 = new byte[]
				{
					168
				};
				uint num84;
				Console.DebugTarget.SetMemory(2218080856U, 1U, data84, out num84);
			}
			bool flag169 = (string)comboBox226.SelectedItem == "Lightweight";
			bool flag170 = flag169;
			if (flag170)
			{
				byte[] data85 = new byte[]
				{
					148
				};
				uint num85;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data85, out num85);
			}
			bool flag171 = (string)comboBox226.SelectedItem == "Hardline";
			bool flag172 = flag171;
			if (flag172)
			{
				byte[] data86 = new byte[]
				{
					151
				};
				uint num86;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data86, out num86);
			}
			bool flag173 = (string)comboBox226.SelectedItem == "Blind Eye";
			bool flag174 = flag173;
			if (flag174)
			{
				byte[] data87 = new byte[]
				{
					150
				};
				uint num87;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data87, out num87);
			}
			bool flag175 = (string)comboBox226.SelectedItem == "Flak Jacket";
			bool flag176 = flag175;
			if (flag176)
			{
				byte[] data88 = new byte[]
				{
					149
				};
				uint num88;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data88, out num88);
			}
			bool flag177 = (string)comboBox226.SelectedItem == "Ghost";
			bool flag178 = flag177;
			if (flag178)
			{
				byte[] data89 = new byte[]
				{
					152
				};
				uint num89;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data89, out num89);
			}
			bool flag179 = (string)comboBox226.SelectedItem == "Toughness";
			bool flag180 = flag179;
			if (flag180)
			{
				byte[] data90 = new byte[]
				{
					157
				};
				uint num90;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data90, out num90);
			}
			bool flag181 = (string)comboBox226.SelectedItem == "Cold Blooded";
			bool flag182 = flag181;
			if (flag182)
			{
				byte[] data91 = new byte[]
				{
					155
				};
				uint num91;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data91, out num91);
			}
			bool flag183 = (string)comboBox226.SelectedItem == "Fast Hands";
			bool flag184 = flag183;
			if (flag184)
			{
				byte[] data92 = new byte[]
				{
					156
				};
				uint num92;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data92, out num92);
			}
			bool flag185 = (string)comboBox226.SelectedItem == "Hard Wired";
			bool flag186 = flag185;
			if (flag186)
			{
				byte[] data93 = new byte[]
				{
					153
				};
				uint num93;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data93, out num93);
			}
			bool flag187 = (string)comboBox226.SelectedItem == "Scavenger";
			bool flag188 = flag187;
			if (flag188)
			{
				byte[] data94 = new byte[]
				{
					154
				};
				uint num94;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data94, out num94);
			}
			bool flag189 = (string)comboBox226.SelectedItem == "Dexterity";
			bool flag190 = flag189;
			if (flag190)
			{
				byte[] data95 = new byte[]
				{
					158
				};
				uint num95;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data95, out num95);
			}
			bool flag191 = (string)comboBox226.SelectedItem == "Extreme Conditioning";
			bool flag192 = flag191;
			if (flag192)
			{
				byte[] data96 = new byte[]
				{
					161
				};
				uint num96;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data96, out num96);
			}
			bool flag193 = (string)comboBox226.SelectedItem == "Engineer";
			bool flag194 = flag193;
			if (flag194)
			{
				byte[] data97 = new byte[]
				{
					159
				};
				uint num97;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data97, out num97);
			}
			bool flag195 = (string)comboBox226.SelectedItem == "Tactical Mask";
			bool flag196 = flag195;
			if (flag196)
			{
				byte[] data98 = new byte[]
				{
					162
				};
				uint num98;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data98, out num98);
			}
			bool flag197 = (string)comboBox226.SelectedItem == "Dead Silence";
			bool flag198 = flag197;
			if (flag198)
			{
				byte[] data99 = new byte[]
				{
					160
				};
				uint num99;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data99, out num99);
			}
			bool flag199 = (string)comboBox226.SelectedItem == "Awareness";
			bool flag200 = flag199;
			if (flag200)
			{
				byte[] data100 = new byte[]
				{
					163
				};
				uint num100;
				Console.DebugTarget.SetMemory(2218080870U, 1U, data100, out num100);
			}
			bool flag201 = (string)comboBox225.SelectedItem == "Lightweight";
			bool flag202 = flag201;
			if (flag202)
			{
				byte[] data101 = new byte[]
				{
					148
				};
				uint num101;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data101, out num101);
			}
			bool flag203 = (string)comboBox225.SelectedItem == "Hardline";
			bool flag204 = flag203;
			if (flag204)
			{
				byte[] data102 = new byte[]
				{
					151
				};
				uint num102;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data102, out num102);
			}
			bool flag205 = (string)comboBox225.SelectedItem == "Blind Eye";
			bool flag206 = flag205;
			if (flag206)
			{
				byte[] data103 = new byte[]
				{
					150
				};
				uint num103;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data103, out num103);
			}
			bool flag207 = (string)comboBox225.SelectedItem == "Flak Jacket";
			bool flag208 = flag207;
			if (flag208)
			{
				byte[] data104 = new byte[]
				{
					149
				};
				uint num104;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data104, out num104);
			}
			bool flag209 = (string)comboBox225.SelectedItem == "Ghost";
			bool flag210 = flag209;
			if (flag210)
			{
				byte[] data105 = new byte[]
				{
					152
				};
				uint num105;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data105, out num105);
			}
			bool flag211 = (string)comboBox225.SelectedItem == "Toughness";
			bool flag212 = flag211;
			if (flag212)
			{
				byte[] data106 = new byte[]
				{
					157
				};
				uint num106;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data106, out num106);
			}
			bool flag213 = (string)comboBox225.SelectedItem == "Cold Blooded";
			bool flag214 = flag213;
			if (flag214)
			{
				byte[] data107 = new byte[]
				{
					155
				};
				uint num107;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data107, out num107);
			}
			bool flag215 = (string)comboBox225.SelectedItem == "Fast Hands";
			bool flag216 = flag215;
			if (flag216)
			{
				byte[] data108 = new byte[]
				{
					156
				};
				uint num108;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data108, out num108);
			}
			bool flag217 = (string)comboBox225.SelectedItem == "Hard Wired";
			bool flag218 = flag217;
			if (flag218)
			{
				byte[] data109 = new byte[]
				{
					153
				};
				uint num109;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data109, out num109);
			}
			bool flag219 = (string)comboBox225.SelectedItem == "Scavenger";
			bool flag220 = flag219;
			if (flag220)
			{
				byte[] data110 = new byte[]
				{
					154
				};
				uint num110;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data110, out num110);
			}
			bool flag221 = (string)comboBox225.SelectedItem == "Dexterity";
			bool flag222 = flag221;
			if (flag222)
			{
				byte[] data111 = new byte[]
				{
					158
				};
				uint num111;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data111, out num111);
			}
			bool flag223 = (string)comboBox225.SelectedItem == "Extreme Conditioning";
			bool flag224 = flag223;
			if (flag224)
			{
				byte[] data112 = new byte[]
				{
					161
				};
				uint num112;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data112, out num112);
			}
			bool flag225 = (string)comboBox225.SelectedItem == "Engineer";
			bool flag226 = flag225;
			if (flag226)
			{
				byte[] data113 = new byte[]
				{
					159
				};
				uint num113;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data113, out num113);
			}
			bool flag227 = (string)comboBox225.SelectedItem == "Tactical Mask";
			bool flag228 = flag227;
			if (flag228)
			{
				byte[] data114 = new byte[]
				{
					162
				};
				uint num114;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data114, out num114);
			}
			bool flag229 = (string)comboBox225.SelectedItem == "Dead Silence";
			bool flag230 = flag229;
			if (flag230)
			{
				byte[] data115 = new byte[]
				{
					160
				};
				uint num115;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data115, out num115);
			}
			bool flag231 = (string)comboBox225.SelectedItem == "Awareness";
			bool flag232 = flag231;
			if (flag232)
			{
				byte[] data116 = new byte[]
				{
					163
				};
				uint num116;
				Console.DebugTarget.SetMemory(2218080873U, 1U, data116, out num116);
			}
			bool flag233 = (string)comboBox224.SelectedItem == "Lightweight";
			bool flag234 = flag233;
			if (flag234)
			{
				byte[] data117 = new byte[]
				{
					148
				};
				uint num117;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data117, out num117);
			}
			bool flag235 = (string)comboBox224.SelectedItem == "Hardline";
			bool flag236 = flag235;
			if (flag236)
			{
				byte[] data118 = new byte[]
				{
					151
				};
				uint num118;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data118, out num118);
			}
			bool flag237 = (string)comboBox224.SelectedItem == "Blind Eye";
			bool flag238 = flag237;
			if (flag238)
			{
				byte[] data119 = new byte[]
				{
					150
				};
				uint num119;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data119, out num119);
			}
			bool flag239 = (string)comboBox224.SelectedItem == "Flak Jacket";
			bool flag240 = flag239;
			if (flag240)
			{
				byte[] data120 = new byte[]
				{
					149
				};
				uint num120;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data120, out num120);
			}
			bool flag241 = (string)comboBox224.SelectedItem == "Ghost";
			bool flag242 = flag241;
			if (flag242)
			{
				byte[] data121 = new byte[]
				{
					152
				};
				uint num121;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data121, out num121);
			}
			bool flag243 = (string)comboBox224.SelectedItem == "Toughness";
			bool flag244 = flag243;
			if (flag244)
			{
				byte[] data122 = new byte[]
				{
					157
				};
				uint num122;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data122, out num122);
			}
			bool flag245 = (string)comboBox224.SelectedItem == "Cold Blooded";
			bool flag246 = flag245;
			if (flag246)
			{
				byte[] data123 = new byte[]
				{
					155
				};
				uint num123;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data123, out num123);
			}
			bool flag247 = (string)comboBox224.SelectedItem == "Fast Hands";
			bool flag248 = flag247;
			if (flag248)
			{
				byte[] data124 = new byte[]
				{
					156
				};
				uint num124;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data124, out num124);
			}
			bool flag249 = (string)comboBox224.SelectedItem == "Hard Wired";
			bool flag250 = flag249;
			if (flag250)
			{
				byte[] data125 = new byte[]
				{
					153
				};
				uint num125;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data125, out num125);
			}
			bool flag251 = (string)comboBox224.SelectedItem == "Scavenger";
			bool flag252 = flag251;
			if (flag252)
			{
				byte[] data126 = new byte[]
				{
					154
				};
				uint num126;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data126, out num126);
			}
			bool flag253 = (string)comboBox224.SelectedItem == "Dexterity";
			bool flag254 = flag253;
			if (flag254)
			{
				byte[] data127 = new byte[]
				{
					158
				};
				uint num127;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data127, out num127);
			}
			bool flag255 = (string)comboBox224.SelectedItem == "Extreme Conditioning";
			bool flag256 = flag255;
			if (flag256)
			{
				byte[] data128 = new byte[]
				{
					161
				};
				uint num128;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data128, out num128);
			}
			bool flag257 = (string)comboBox224.SelectedItem == "Engineer";
			bool flag258 = flag257;
			if (flag258)
			{
				byte[] data129 = new byte[]
				{
					159
				};
				uint num129;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data129, out num129);
			}
			bool flag259 = (string)comboBox224.SelectedItem == "Tactical Mask";
			bool flag260 = flag259;
			if (flag260)
			{
				byte[] data130 = new byte[]
				{
					162
				};
				uint num130;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data130, out num130);
			}
			bool flag261 = (string)comboBox224.SelectedItem == "Dead Silence";
			bool flag262 = flag261;
			if (flag262)
			{
				byte[] data131 = new byte[]
				{
					160
				};
				uint num131;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data131, out num131);
			}
			bool flag263 = (string)comboBox224.SelectedItem == "Awareness";
			bool flag264 = flag263;
			if (flag264)
			{
				byte[] data132 = new byte[]
				{
					163
				};
				uint num132;
				Console.DebugTarget.SetMemory(2218080871U, 1U, data132, out num132);
			}
			bool flag265 = (string)comboBox223.SelectedItem == "Lightweight";
			bool flag266 = flag265;
			if (flag266)
			{
				byte[] data133 = new byte[]
				{
					148
				};
				uint num133;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data133, out num133);
			}
			bool flag267 = (string)comboBox223.SelectedItem == "Hardline";
			bool flag268 = flag267;
			if (flag268)
			{
				byte[] data134 = new byte[]
				{
					151
				};
				uint num134;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data134, out num134);
			}
			bool flag269 = (string)comboBox223.SelectedItem == "Blind Eye";
			bool flag270 = flag269;
			if (flag270)
			{
				byte[] data135 = new byte[]
				{
					150
				};
				uint num135;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data135, out num135);
			}
			bool flag271 = (string)comboBox223.SelectedItem == "Flak Jacket";
			bool flag272 = flag271;
			if (flag272)
			{
				byte[] data136 = new byte[]
				{
					149
				};
				uint num136;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data136, out num136);
			}
			bool flag273 = (string)comboBox223.SelectedItem == "Ghost";
			bool flag274 = flag273;
			if (flag274)
			{
				byte[] data137 = new byte[]
				{
					152
				};
				uint num137;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data137, out num137);
			}
			bool flag275 = (string)comboBox223.SelectedItem == "Toughness";
			bool flag276 = flag275;
			if (flag276)
			{
				byte[] data138 = new byte[]
				{
					157
				};
				uint num138;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data138, out num138);
			}
			bool flag277 = (string)comboBox223.SelectedItem == "Cold Blooded";
			bool flag278 = flag277;
			if (flag278)
			{
				byte[] data139 = new byte[]
				{
					155
				};
				uint num139;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data139, out num139);
			}
			bool flag279 = (string)comboBox223.SelectedItem == "Fast Hands";
			bool flag280 = flag279;
			if (flag280)
			{
				byte[] data140 = new byte[]
				{
					156
				};
				uint num140;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data140, out num140);
			}
			bool flag281 = (string)comboBox223.SelectedItem == "Hard Wired";
			bool flag282 = flag281;
			if (flag282)
			{
				byte[] data141 = new byte[]
				{
					153
				};
				uint num141;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data141, out num141);
			}
			bool flag283 = (string)comboBox223.SelectedItem == "Scavenger";
			bool flag284 = flag283;
			if (flag284)
			{
				byte[] data142 = new byte[]
				{
					154
				};
				uint num142;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data142, out num142);
			}
			bool flag285 = (string)comboBox223.SelectedItem == "Dexterity";
			bool flag286 = flag285;
			if (flag286)
			{
				byte[] data143 = new byte[]
				{
					158
				};
				uint num143;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data143, out num143);
			}
			bool flag287 = (string)comboBox223.SelectedItem == "Extreme Conditioning";
			bool flag288 = flag287;
			if (flag288)
			{
				byte[] data144 = new byte[]
				{
					161
				};
				uint num144;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data144, out num144);
			}
			bool flag289 = (string)comboBox223.SelectedItem == "Engineer";
			bool flag290 = flag289;
			if (flag290)
			{
				byte[] data145 = new byte[]
				{
					159
				};
				uint num145;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data145, out num145);
			}
			bool flag291 = (string)comboBox223.SelectedItem == "Tactical Mask";
			bool flag292 = flag291;
			if (flag292)
			{
				byte[] data146 = new byte[]
				{
					162
				};
				uint num146;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data146, out num146);
			}
			bool flag293 = (string)comboBox223.SelectedItem == "Dead Silence";
			bool flag294 = flag293;
			if (flag294)
			{
				byte[] data147 = new byte[]
				{
					160
				};
				uint num147;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data147, out num147);
			}
			bool flag295 = (string)comboBox223.SelectedItem == "Awareness";
			bool flag296 = flag295;
			if (flag296)
			{
				byte[] data148 = new byte[]
				{
					163
				};
				uint num148;
				Console.DebugTarget.SetMemory(2218080874U, 1U, data148, out num148);
			}
			bool flag297 = (string)comboBox222.SelectedItem == "Lightweight";
			bool flag298 = flag297;
			if (flag298)
			{
				byte[] data149 = new byte[]
				{
					148
				};
				uint num149;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data149, out num149);
			}
			bool flag299 = (string)comboBox222.SelectedItem == "Hardline";
			bool flag300 = flag299;
			if (flag300)
			{
				byte[] data150 = new byte[]
				{
					151
				};
				uint num150;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data150, out num150);
			}
			bool flag301 = (string)comboBox222.SelectedItem == "Blind Eye";
			bool flag302 = flag301;
			if (flag302)
			{
				byte[] data151 = new byte[]
				{
					150
				};
				uint num151;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data151, out num151);
			}
			bool flag303 = (string)comboBox222.SelectedItem == "Flak Jacket";
			bool flag304 = flag303;
			if (flag304)
			{
				byte[] data152 = new byte[]
				{
					149
				};
				uint num152;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data152, out num152);
			}
			bool flag305 = (string)comboBox222.SelectedItem == "Ghost";
			bool flag306 = flag305;
			if (flag306)
			{
				byte[] data153 = new byte[]
				{
					152
				};
				uint num153;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data153, out num153);
			}
			bool flag307 = (string)comboBox222.SelectedItem == "Toughness";
			bool flag308 = flag307;
			if (flag308)
			{
				byte[] data154 = new byte[]
				{
					157
				};
				uint num154;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data154, out num154);
			}
			bool flag309 = (string)comboBox222.SelectedItem == "Cold Blooded";
			bool flag310 = flag309;
			if (flag310)
			{
				byte[] data155 = new byte[]
				{
					155
				};
				uint num155;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data155, out num155);
			}
			bool flag311 = (string)comboBox222.SelectedItem == "Fast Hands";
			bool flag312 = flag311;
			if (flag312)
			{
				byte[] data156 = new byte[]
				{
					156
				};
				uint num156;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data156, out num156);
			}
			bool flag313 = (string)comboBox222.SelectedItem == "Hard Wired";
			bool flag314 = flag313;
			if (flag314)
			{
				byte[] data157 = new byte[]
				{
					153
				};
				uint num157;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data157, out num157);
			}
			bool flag315 = (string)comboBox222.SelectedItem == "Scavenger";
			bool flag316 = flag315;
			if (flag316)
			{
				byte[] data158 = new byte[]
				{
					154
				};
				uint num158;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data158, out num158);
			}
			bool flag317 = (string)comboBox222.SelectedItem == "Dexterity";
			bool flag318 = flag317;
			if (flag318)
			{
				byte[] data159 = new byte[]
				{
					158
				};
				uint num159;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data159, out num159);
			}
			bool flag319 = (string)comboBox222.SelectedItem == "Extreme Conditioning";
			bool flag320 = flag319;
			if (flag320)
			{
				byte[] data160 = new byte[]
				{
					161
				};
				uint num160;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data160, out num160);
			}
			bool flag321 = (string)comboBox222.SelectedItem == "Engineer";
			bool flag322 = flag321;
			if (flag322)
			{
				byte[] data161 = new byte[]
				{
					159
				};
				uint num161;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data161, out num161);
			}
			bool flag323 = (string)comboBox222.SelectedItem == "Tactical Mask";
			bool flag324 = flag323;
			if (flag324)
			{
				byte[] data162 = new byte[]
				{
					162
				};
				uint num162;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data162, out num162);
			}
			bool flag325 = (string)comboBox222.SelectedItem == "Dead Silence";
			bool flag326 = flag325;
			if (flag326)
			{
				byte[] data163 = new byte[]
				{
					160
				};
				uint num163;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data163, out num163);
			}
			bool flag327 = (string)comboBox222.SelectedItem == "Awareness";
			bool flag328 = flag327;
			if (flag328)
			{
				byte[] data164 = new byte[]
				{
					163
				};
				uint num164;
				Console.DebugTarget.SetMemory(2218080872U, 1U, data164, out num164);
			}
			bool flag329 = (string)comboBox215.SelectedItem == "Lightweight";
			bool flag330 = flag329;
			if (flag330)
			{
				byte[] data165 = new byte[]
				{
					148
				};
				uint num165;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data165, out num165);
			}
			bool flag331 = (string)comboBox215.SelectedItem == "Hardline";
			bool flag332 = flag331;
			if (flag332)
			{
				byte[] data166 = new byte[]
				{
					151
				};
				uint num166;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data166, out num166);
			}
			bool flag333 = (string)comboBox215.SelectedItem == "Blind Eye";
			bool flag334 = flag333;
			if (flag334)
			{
				byte[] data167 = new byte[]
				{
					150
				};
				uint num167;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data167, out num167);
			}
			bool flag335 = (string)comboBox215.SelectedItem == "Flak Jacket";
			bool flag336 = flag335;
			if (flag336)
			{
				byte[] data168 = new byte[]
				{
					149
				};
				uint num168;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data168, out num168);
			}
			bool flag337 = (string)comboBox215.SelectedItem == "Ghost";
			bool flag338 = flag337;
			if (flag338)
			{
				byte[] data169 = new byte[]
				{
					152
				};
				uint num169;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data169, out num169);
			}
			bool flag339 = (string)comboBox215.SelectedItem == "Toughness";
			bool flag340 = flag339;
			if (flag340)
			{
				byte[] data170 = new byte[]
				{
					157
				};
				uint num170;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data170, out num170);
			}
			bool flag341 = (string)comboBox215.SelectedItem == "Cold Blooded";
			bool flag342 = flag341;
			if (flag342)
			{
				byte[] data171 = new byte[]
				{
					155
				};
				uint num171;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data171, out num171);
			}
			bool flag343 = (string)comboBox215.SelectedItem == "Fast Hands";
			bool flag344 = flag343;
			if (flag344)
			{
				byte[] data172 = new byte[]
				{
					156
				};
				uint num172;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data172, out num172);
			}
			bool flag345 = (string)comboBox215.SelectedItem == "Hard Wired";
			bool flag346 = flag345;
			if (flag346)
			{
				byte[] data173 = new byte[]
				{
					153
				};
				uint num173;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data173, out num173);
			}
			bool flag347 = (string)comboBox215.SelectedItem == "Scavenger";
			bool flag348 = flag347;
			if (flag348)
			{
				byte[] data174 = new byte[]
				{
					154
				};
				uint num174;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data174, out num174);
			}
			bool flag349 = (string)comboBox215.SelectedItem == "Dexterity";
			bool flag350 = flag349;
			if (flag350)
			{
				byte[] data175 = new byte[]
				{
					158
				};
				uint num175;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data175, out num175);
			}
			bool flag351 = (string)comboBox215.SelectedItem == "Extreme Conditioning";
			bool flag352 = flag351;
			if (flag352)
			{
				byte[] data176 = new byte[]
				{
					161
				};
				uint num176;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data176, out num176);
			}
			bool flag353 = (string)comboBox215.SelectedItem == "Engineer";
			bool flag354 = flag353;
			if (flag354)
			{
				byte[] data177 = new byte[]
				{
					159
				};
				uint num177;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data177, out num177);
			}
			bool flag355 = (string)comboBox215.SelectedItem == "Tactical Mask";
			bool flag356 = flag355;
			if (flag356)
			{
				byte[] data178 = new byte[]
				{
					162
				};
				uint num178;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data178, out num178);
			}
			bool flag357 = (string)comboBox215.SelectedItem == "Dead Silence";
			bool flag358 = flag357;
			if (flag358)
			{
				byte[] data179 = new byte[]
				{
					160
				};
				uint num179;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data179, out num179);
			}
			bool flag359 = (string)comboBox215.SelectedItem == "Awareness";
			bool flag360 = flag359;
			if (flag360)
			{
				byte[] data180 = new byte[]
				{
					163
				};
				uint num180;
				Console.DebugTarget.SetMemory(2218080875U, 1U, data180, out num180);
			}
			bool flag361 = (string)comboBox213.SelectedItem == "Grenade";
			bool flag362 = flag361;
			if (flag362)
			{
				byte[] data181 = new byte[]
				{
					63,
					1
				};
				uint num181;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data181, out num181);
			}
			bool flag363 = (string)comboBox213.SelectedItem == "Semtex";
			bool flag364 = flag363;
			if (flag364)
			{
				byte[] data182 = new byte[]
				{
					65,
					1
				};
				uint num182;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data182, out num182);
			}
			bool flag365 = (string)comboBox213.SelectedItem == "Combat Axe";
			bool flag366 = flag365;
			if (flag366)
			{
				byte[] data183 = new byte[]
				{
					64,
					1
				};
				uint num183;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data183, out num183);
			}
			bool flag367 = (string)comboBox213.SelectedItem == "Bouncing Betty";
			bool flag368 = flag367;
			if (flag368)
			{
				byte[] data184 = new byte[]
				{
					67,
					1
				};
				uint num184;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data184, out num184);
			}
			bool flag369 = (string)comboBox213.SelectedItem == "C4";
			bool flag370 = flag369;
			if (flag370)
			{
				byte[] data185 = new byte[]
				{
					66,
					1
				};
				uint num185;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data185, out num185);
			}
			bool flag371 = (string)comboBox213.SelectedItem == "Claymore";
			bool flag372 = flag371;
			if (flag372)
			{
				byte[] data186 = new byte[]
				{
					65,
					1
				};
				uint num186;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data186, out num186);
			}
			bool flag373 = (string)comboBox213.SelectedItem == "Concussion";
			bool flag374 = flag373;
			if (flag374)
			{
				byte[] data187 = new byte[]
				{
					57,
					10
				};
				uint num187;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data187, out num187);
			}
			bool flag375 = (string)comboBox213.SelectedItem == "Smoke Grenade";
			bool flag376 = flag375;
			if (flag376)
			{
				byte[] data188 = new byte[]
				{
					49,
					10
				};
				uint num188;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data188, out num188);
			}
			bool flag377 = (string)comboBox213.SelectedItem == "Sensor Grenade";
			bool flag378 = flag377;
			if (flag378)
			{
				byte[] data189 = new byte[]
				{
					73,
					10
				};
				uint num189;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data189, out num189);
			}
			bool flag379 = (string)comboBox213.SelectedItem == "EMP Grenade";
			bool flag380 = flag379;
			if (flag380)
			{
				byte[] data190 = new byte[]
				{
					65,
					10
				};
				uint num190;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data190, out num190);
			}
			bool flag381 = (string)comboBox213.SelectedItem == "Shock Charge";
			bool flag382 = flag381;
			if (flag382)
			{
				byte[] data191 = new byte[]
				{
					89,
					10
				};
				uint num191;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data191, out num191);
			}
			bool flag383 = (string)comboBox213.SelectedItem == "Black Hat";
			bool flag384 = flag383;
			if (flag384)
			{
				byte[] data192 = new byte[]
				{
					97,
					10
				};
				uint num192;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data192, out num192);
			}
			bool flag385 = (string)comboBox213.SelectedItem == "Flashbang";
			bool flag386 = flag385;
			if (flag386)
			{
				byte[] data193 = new byte[]
				{
					81,
					10
				};
				uint num193;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data193, out num193);
			}
			bool flag387 = (string)comboBox213.SelectedItem == "Trophy System";
			bool flag388 = flag387;
			if (flag388)
			{
				byte[] data194 = new byte[]
				{
					113,
					10
				};
				uint num194;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data194, out num194);
			}
			bool flag389 = (string)comboBox213.SelectedItem == "Tactical Insertion";
			bool flag390 = flag389;
			if (flag390)
			{
				byte[] data195 = new byte[]
				{
					105,
					10
				};
				uint num195;
				Console.DebugTarget.SetMemory(2218080876U, 2U, data195, out num195);
			}
			bool flag391 = (string)comboBox211.SelectedItem == "Grenade";
			bool flag392 = flag391;
			if (flag392)
			{
				byte[] data196 = new byte[]
				{
					63,
					1
				};
				uint num196;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data196, out num196);
			}
			bool flag393 = (string)comboBox211.SelectedItem == "Semtex";
			bool flag394 = flag393;
			if (flag394)
			{
				byte[] data197 = new byte[]
				{
					65,
					1
				};
				uint num197;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data197, out num197);
			}
			bool flag395 = (string)comboBox211.SelectedItem == "Combat Axe";
			bool flag396 = flag395;
			if (flag396)
			{
				byte[] data198 = new byte[]
				{
					64,
					1
				};
				uint num198;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data198, out num198);
			}
			bool flag397 = (string)comboBox211.SelectedItem == "Bouncing Betty";
			bool flag398 = flag397;
			if (flag398)
			{
				byte[] data199 = new byte[]
				{
					67,
					1
				};
				uint num199;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data199, out num199);
			}
			bool flag399 = (string)comboBox211.SelectedItem == "C4";
			bool flag400 = flag399;
			if (flag400)
			{
				byte[] data200 = new byte[]
				{
					66,
					1
				};
				uint num200;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data200, out num200);
			}
			bool flag401 = (string)comboBox211.SelectedItem == "Claymore";
			bool flag402 = flag401;
			if (flag402)
			{
				byte[] data201 = new byte[]
				{
					65,
					1
				};
				uint num201;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data201, out num201);
			}
			bool flag403 = (string)comboBox211.SelectedItem == "Concussion";
			bool flag404 = flag403;
			if (flag404)
			{
				byte[] data202 = new byte[]
				{
					57,
					10
				};
				uint num202;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data202, out num202);
			}
			bool flag405 = (string)comboBox211.SelectedItem == "Smoke Grenade";
			bool flag406 = flag405;
			if (flag406)
			{
				byte[] data203 = new byte[]
				{
					49,
					10
				};
				uint num203;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data203, out num203);
			}
			bool flag407 = (string)comboBox211.SelectedItem == "Sensor Grenade";
			bool flag408 = flag407;
			if (flag408)
			{
				byte[] data204 = new byte[]
				{
					73,
					10
				};
				uint num204;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data204, out num204);
			}
			bool flag409 = (string)comboBox211.SelectedItem == "EMP Grenade";
			bool flag410 = flag409;
			if (flag410)
			{
				byte[] data205 = new byte[]
				{
					65,
					10
				};
				uint num205;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data205, out num205);
			}
			bool flag411 = (string)comboBox211.SelectedItem == "Shock Charge";
			bool flag412 = flag411;
			if (flag412)
			{
				byte[] data206 = new byte[]
				{
					89,
					10
				};
				uint num206;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data206, out num206);
			}
			bool flag413 = (string)comboBox211.SelectedItem == "Black Hat";
			bool flag414 = flag413;
			if (flag414)
			{
				byte[] data207 = new byte[]
				{
					97,
					10
				};
				uint num207;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data207, out num207);
			}
			bool flag415 = (string)comboBox211.SelectedItem == "Flashbang";
			bool flag416 = flag415;
			if (flag416)
			{
				byte[] data208 = new byte[]
				{
					81,
					10
				};
				uint num208;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data208, out num208);
			}
			bool flag417 = (string)comboBox211.SelectedItem == "Trophy System";
			bool flag418 = flag417;
			if (flag418)
			{
				byte[] data209 = new byte[]
				{
					113,
					10
				};
				uint num209;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data209, out num209);
			}
			bool flag419 = (string)comboBox211.SelectedItem == "Tactical Insertion";
			bool flag420 = flag419;
			if (flag420)
			{
				byte[] data210 = new byte[]
				{
					105,
					10
				};
				uint num210;
				Console.DebugTarget.SetMemory(2218080878U, 2U, data210, out num210);
			}
			bool flag421 = (string)comboBox229.SelectedItem == "DEVGRU";
			bool flag422 = flag421;
			if (flag422)
			{
				byte[] data211 = new byte[]
				{
					4,
					4
				};
				uint num211;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data211, out num211);
			}
			bool flag423 = (string)comboBox229.SelectedItem == "A-TACS AU";
			bool flag424 = flag423;
			if (flag424)
			{
				byte[] data212 = new byte[]
				{
					8,
					4
				};
				uint num212;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data212, out num212);
			}
			bool flag425 = (string)comboBox229.SelectedItem == "EROL";
			bool flag426 = flag425;
			if (flag426)
			{
				byte[] data213 = new byte[]
				{
					12,
					4
				};
				uint num213;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data213, out num213);
			}
			bool flag427 = (string)comboBox229.SelectedItem == "Siberia";
			bool flag428 = flag427;
			if (flag428)
			{
				byte[] data214 = new byte[]
				{
					16,
					4
				};
				uint num214;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data214, out num214);
			}
			bool flag429 = (string)comboBox229.SelectedItem == "Choco";
			bool flag430 = flag429;
			if (flag430)
			{
				byte[] data215 = new byte[]
				{
					20,
					4
				};
				uint num215;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data215, out num215);
			}
			bool flag431 = (string)comboBox229.SelectedItem == "Blue Tiger";
			bool flag432 = flag431;
			if (flag432)
			{
				byte[] data216 = new byte[]
				{
					24,
					4
				};
				uint num216;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data216, out num216);
			}
			bool flag433 = (string)comboBox229.SelectedItem == "Bloodshot";
			bool flag434 = flag433;
			if (flag434)
			{
				byte[] data217 = new byte[]
				{
					28,
					4
				};
				uint num217;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data217, out num217);
			}
			bool flag435 = (string)comboBox229.SelectedItem == "Ghostex: Delta 6";
			bool flag436 = flag435;
			if (flag436)
			{
				byte[] data218 = new byte[]
				{
					32,
					4
				};
				uint num218;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data218, out num218);
			}
			bool flag437 = (string)comboBox229.SelectedItem == "Kryptek: Typhon";
			bool flag438 = flag437;
			if (flag438)
			{
				byte[] data219 = new byte[]
				{
					36,
					4
				};
				uint num219;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data219, out num219);
			}
			bool flag439 = (string)comboBox229.SelectedItem == "Carbon Fiber";
			bool flag440 = flag439;
			if (flag440)
			{
				byte[] data220 = new byte[]
				{
					40,
					4
				};
				uint num220;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data220, out num220);
			}
			bool flag441 = (string)comboBox229.SelectedItem == "Cherry Blossom";
			bool flag442 = flag441;
			if (flag442)
			{
				byte[] data221 = new byte[]
				{
					44,
					4
				};
				uint num221;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data221, out num221);
			}
			bool flag443 = (string)comboBox229.SelectedItem == "Art of War";
			bool flag444 = flag443;
			if (flag444)
			{
				byte[] data222 = new byte[]
				{
					48,
					4
				};
				uint num222;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data222, out num222);
			}
			bool flag445 = (string)comboBox229.SelectedItem == "Ronin";
			bool flag446 = flag445;
			if (flag446)
			{
				byte[] data223 = new byte[]
				{
					52,
					4
				};
				uint num223;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data223, out num223);
			}
			bool flag447 = (string)comboBox229.SelectedItem == "Skulls";
			bool flag448 = flag447;
			if (flag448)
			{
				byte[] data224 = new byte[]
				{
					56,
					4
				};
				uint num224;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data224, out num224);
			}
			bool flag449 = (string)comboBox229.SelectedItem == "Gold";
			bool flag450 = flag449;
			if (flag450)
			{
				byte[] data225 = new byte[]
				{
					60,
					4
				};
				uint num225;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data225, out num225);
			}
			bool flag451 = (string)comboBox229.SelectedItem == "Diamond";
			bool flag452 = flag451;
			if (flag452)
			{
				byte[] data226 = new byte[]
				{
					64,
					4
				};
				uint num226;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data226, out num226);
			}
			bool flag453 = (string)comboBox229.SelectedItem == "Elite Member";
			bool flag454 = flag453;
			if (flag454)
			{
				byte[] data227 = new byte[]
				{
					68,
					4
				};
				uint num227;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data227, out num227);
			}
			bool flag455 = (string)comboBox229.SelectedItem == "CE Digital";
			bool flag456 = flag455;
			if (flag456)
			{
				byte[] data228 = new byte[]
				{
					72,
					4
				};
				uint num228;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data228, out num228);
			}
			bool flag457 = (string)comboBox229.SelectedItem == "Jungle Warfare";
			bool flag458 = flag457;
			if (flag458)
			{
				byte[] data229 = new byte[]
				{
					180,
					4
				};
				uint num229;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data229, out num229);
			}
			bool flag459 = (string)comboBox229.SelectedItem == "UK Punk";
			bool flag460 = flag459;
			if (flag460)
			{
				byte[] data230 = new byte[]
				{
					184,
					4
				};
				uint num230;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data230, out num230);
			}
			bool flag461 = (string)comboBox229.SelectedItem == "Benjamins";
			bool flag462 = flag461;
			if (flag462)
			{
				byte[] data231 = new byte[]
				{
					188,
					4
				};
				uint num231;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data231, out num231);
			}
			bool flag463 = (string)comboBox229.SelectedItem == "Dia De Muertos";
			bool flag464 = flag463;
			if (flag464)
			{
				byte[] data232 = new byte[]
				{
					192,
					4
				};
				uint num232;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data232, out num232);
			}
			bool flag465 = (string)comboBox229.SelectedItem == "Grafitti";
			bool flag466 = flag465;
			if (flag466)
			{
				byte[] data233 = new byte[]
				{
					196,
					4
				};
				uint num233;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data233, out num233);
			}
			bool flag467 = (string)comboBox229.SelectedItem == "Kawaii";
			bool flag468 = flag467;
			if (flag468)
			{
				byte[] data234 = new byte[]
				{
					200,
					4
				};
				uint num234;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data234, out num234);
			}
			bool flag469 = (string)comboBox229.SelectedItem == "Party Rock";
			bool flag470 = flag469;
			if (flag470)
			{
				byte[] data235 = new byte[]
				{
					204,
					4
				};
				uint num235;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data235, out num235);
			}
			bool flag471 = (string)comboBox229.SelectedItem == "Zombies";
			bool flag472 = flag471;
			if (flag472)
			{
				byte[] data236 = new byte[]
				{
					208,
					4
				};
				uint num236;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data236, out num236);
			}
			bool flag473 = (string)comboBox229.SelectedItem == "Viper";
			bool flag474 = flag473;
			if (flag474)
			{
				byte[] data237 = new byte[]
				{
					212,
					4
				};
				uint num237;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data237, out num237);
			}
			bool flag475 = (string)comboBox229.SelectedItem == "Bacon";
			bool flag476 = flag475;
			if (flag476)
			{
				byte[] data238 = new byte[]
				{
					216,
					4
				};
				uint num238;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data238, out num238);
			}
			bool flag477 = (string)comboBox229.SelectedItem == "Ghost";
			bool flag478 = flag477;
			if (flag478)
			{
				byte[] data239 = new byte[]
				{
					4,
					5
				};
				uint num239;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data239, out num239);
			}
			bool flag479 = (string)comboBox229.SelectedItem == "Paladin";
			bool flag480 = flag479;
			if (flag480)
			{
				byte[] data240 = new byte[]
				{
					8,
					5
				};
				uint num240;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data240, out num240);
			}
			bool flag481 = (string)comboBox229.SelectedItem == "Cyborg";
			bool flag482 = flag481;
			if (flag482)
			{
				byte[] data241 = new byte[]
				{
					12,
					5
				};
				uint num241;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data241, out num241);
			}
			bool flag483 = (string)comboBox229.SelectedItem == "Dragon";
			bool flag484 = flag483;
			if (flag484)
			{
				byte[] data242 = new byte[]
				{
					16,
					5
				};
				uint num242;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data242, out num242);
			}
			bool flag485 = (string)comboBox229.SelectedItem == "Comics";
			bool flag486 = flag485;
			if (flag486)
			{
				byte[] data243 = new byte[]
				{
					20,
					5
				};
				uint num243;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data243, out num243);
			}
			bool flag487 = (string)comboBox229.SelectedItem == "Aqua";
			bool flag488 = flag487;
			if (flag488)
			{
				byte[] data244 = new byte[]
				{
					40,
					5
				};
				uint num244;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data244, out num244);
			}
			bool flag489 = (string)comboBox229.SelectedItem == "Breach";
			bool flag490 = flag489;
			if (flag490)
			{
				byte[] data245 = new byte[]
				{
					44,
					5
				};
				uint num245;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data245, out num245);
			}
			bool flag491 = (string)comboBox229.SelectedItem == "Coyote";
			bool flag492 = flag491;
			if (flag492)
			{
				byte[] data246 = new byte[]
				{
					48,
					5
				};
				uint num246;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data246, out num246);
			}
			bool flag493 = (string)comboBox229.SelectedItem == "Glam";
			bool flag494 = flag493;
			if (flag494)
			{
				byte[] data247 = new byte[]
				{
					52,
					5
				};
				uint num247;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data247, out num247);
			}
			bool flag495 = (string)comboBox229.SelectedItem == "Rogue";
			bool flag496 = flag495;
			if (flag496)
			{
				byte[] data248 = new byte[]
				{
					56,
					5
				};
				uint num248;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data248, out num248);
			}
			bool flag497 = (string)comboBox229.SelectedItem == "Pack-a-Punch";
			bool flag498 = flag497;
			if (flag498)
			{
				byte[] data249 = new byte[]
				{
					60,
					5
				};
				uint num249;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data249, out num249);
			}
			bool flag499 = (string)comboBox229.SelectedItem == "Dead Man's Hand";
			bool flag500 = flag499;
			if (flag500)
			{
				byte[] data250 = new byte[]
				{
					108,
					5
				};
				uint num250;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data250, out num250);
			}
			bool flag501 = (string)comboBox229.SelectedItem == "Beast";
			bool flag502 = flag501;
			if (flag502)
			{
				byte[] data251 = new byte[]
				{
					112,
					5
				};
				uint num251;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data251, out num251);
			}
			bool flag503 = (string)comboBox229.SelectedItem == "Octane";
			bool flag504 = flag503;
			if (flag504)
			{
				byte[] data252 = new byte[]
				{
					116,
					5
				};
				uint num252;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data252, out num252);
			}
			bool flag505 = (string)comboBox229.SelectedItem == "Weaponized 115";
			bool flag506 = flag505;
			if (flag506)
			{
				byte[] data253 = new byte[]
				{
					120,
					5
				};
				uint num253;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data253, out num253);
			}
			bool flag507 = (string)comboBox229.SelectedItem == "Afterlife";
			bool flag508 = flag507;
			if (flag508)
			{
				byte[] data254 = new byte[]
				{
					128,
					5
				};
				uint num254;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data254, out num254);
			}
			bool flag509 = (string)comboBox229.SelectedItem == "AW";
			bool flag510 = flag509;
			if (flag510)
			{
				byte[] data255 = new byte[]
				{
					132,
					5
				};
				uint num255;
				Console.DebugTarget.SetMemory(2218080848U, 2U, data255, out num255);
			}
		}

		 //0x060001BC RID: 444 RVA: 0x00015218 File Offset: 0x00013418
		private void simpleButton264_Click(object sender, EventArgs e)
		{
			Console.SetMemory(2199523748U, new byte[19]);
			string s = "Custom Class 1";
			Console.SetMemory(2199523748U, Encoding.ASCII.GetBytes(s));
			Console.SetMemory(2199523812U, new byte[19]);
			string s2 = "Custom Class 2";
			Console.SetMemory(2199523812U, Encoding.ASCII.GetBytes(s2));
			Console.SetMemory(2199523876U, new byte[19]);
			string s3 = "Custom Class 3";
			Console.SetMemory(2199523876U, Encoding.ASCII.GetBytes(s3));
			Console.SetMemory(2199523940U, new byte[19]);
			string s4 = "Custom Class 4";
			Console.SetMemory(2199523940U, Encoding.ASCII.GetBytes(s4));
			Console.SetMemory(2199524004U, new byte[19]);
			string s5 = "Custom Class 5";
			Console.SetMemory(2199524004U, Encoding.ASCII.GetBytes(s5));
			Console.SetMemory(2199524068U, new byte[19]);
			string s6 = "Custom Class 6";
			Console.SetMemory(2199524068U, Encoding.ASCII.GetBytes(s6));
			Console.SetMemory(2199524132U, new byte[19]);
			string s7 = "Custom Class 7";
			Console.SetMemory(2199524132U, Encoding.ASCII.GetBytes(s7));
			Console.SetMemory(2199524196U, new byte[19]);
			string s8 = "Custom Class 8";
			Console.SetMemory(2199524196U, Encoding.ASCII.GetBytes(s8));
			Console.SetMemory(2199524260U, new byte[19]);
			string s9 = "Custom Class 9";
			Console.SetMemory(2199524260U, Encoding.ASCII.GetBytes(s9));
			Console.SetMemory(2199524324U, new byte[19]);
			string s10 = "Custom Class 10";
			Console.SetMemory(2199524324U, Encoding.ASCII.GetBytes(s10));
		}

		 //0x060001BD RID: 445 RVA: 0x00015476 File Offset: 0x00013676
		private void simpleButton271_Click(object sender, EventArgs e)
		{
			Console.SetMemory(2199524352U, new byte[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				5,
				4,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				9,
				9,
				2,
				2,
				2,
				2,
				2,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				9,
				6,
				9,
				6,
				9,
				9,
				9,
				9,
				9,
				7,
				9,
				7,
				9,
				9,
				9,
				9,
				9,
				9,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				7,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				2,
				2,
				2,
				2,
				2,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				5,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				4,
				2,
				2,
				2,
				2,
				4,
				3,
				3,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				4,
				4,
				4,
				4,
				4,
				4,
				2,
				2,
				4,
				4,
				4,
				2,
				2,
				2,
				2,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				2,
				2,
				2,
				3,
				3,
				2,
				3,
				2,
				2,
				2,
				2,
				2,
				2,
				4,
				2,
				2,
				4,
				4,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				2,
				4,
				2,
				4,
				4,
				4,
				2,
				4,
				4,
				2,
				2,
				3,
				3,
				3,
				2,
				3,
				5,
				5,
				5,
				5,
				5,
				2,
				2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				196,
				9,
				0,
				0,
				232,
				3,
				0,
				0,
				136,
				19,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				20,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				30,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				30,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				30,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				30,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				30,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				15,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				15,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				15,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				15,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				15,
				0,
				0,
				0,
				60,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				9,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				196,
				9,
				0,
				0,
				244,
				1,
				0,
				0,
				196,
				9,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				232,
				3,
				0,
				0,
				244,
				1,
				0,
				0,
				196,
				9,
				0,
				0,
				244,
				1,
				0,
				0,
				196,
				9,
				0,
				0,
				244,
				1,
				0,
				0,
				176,
				4,
				0,
				0,
				176,
				4,
				0,
				0,
				176,
				4,
				0,
				0,
				176,
				4,
				0,
				0,
				250,
				0,
				0,
				0,
				0,
				97,
				8,
				0,
				244,
				1,
				0,
				0,
				250,
				0,
				0,
				0,
				250,
				0,
				0,
				0,
				238,
				2,
				0,
				0,
				132,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				250,
				0,
				0,
				0,
				238,
				2,
				0,
				0,
				250,
				0,
				0,
				0,
				100,
				0,
				0,
				0,
				244,
				1,
				0,
				0,
				100,
				0,
				0,
				0,
				238,
				2,
				0,
				0,
				64,
				36,
				20,
				0,
				244,
				1,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				50,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				232,
				3,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				200,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				80,
				195,
				0,
				0,
				80,
				195,
				0,
				0,
				100,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				25,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				20,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				200,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				30,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				10,
				0,
				0,
				0,
				250,
				0,
				0,
				0,
				100,
				0,
				0,
				0,
				232,
				3,
				0,
				0,
				44,
				1,
				0,
				0,
				44,
				1,
				0,
				0,
				1,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				16,
				0,
				23,
				0,
				8,
				0,
				0,
				0,
				130,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				254,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				191,
				byte.MaxValue,
				219,
				24,
				byte.MaxValue,
				40,
				203,
				223,
				203,
				125,
				126,
				252,
				30,
				103,
				0,
				254,
				231,
				202,
				49,
				113,
				byte.MaxValue,
				191,
				246,
				60,
				239,
				17,
				15,
				128,
				237,
				59,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				46,
				byte.MaxValue,
				223,
				108,
				119,
				254,
				254,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				239,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				127,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				239,
				238,
				254,
				31,
				238,
				87,
				165,
				10,
				0,
				0,
				0,
				254,
				125,
				byte.MaxValue,
				221,
				223,
				byte.MaxValue,
				127,
				byte.MaxValue,
				251,
				byte.MaxValue,
				237,
				191,
				223,
				byte.MaxValue,
				byte.MaxValue,
				223,
				byte.MaxValue,
				249,
				byte.MaxValue,
				223,
				237,
				byte.MaxValue,
				253,
				119,
				1,
				192,
				byte.MaxValue,
				223,
				byte.MaxValue,
				190,
				byte.MaxValue,
				63,
				240,
				byte.MaxValue,
				111,
				235,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				15,
				250,
				byte.MaxValue,
				127,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				254,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				191,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				122,
				77,
				153,
				3,
				0
			});
			Console.XNotify("Successfully unlocked all");
		}

		 //0x060001BE RID: 446 RVA: 0x000154B0 File Offset: 0x000136B0
		private void simpleButton282_Click(object sender, EventArgs e)
		{
			accolades = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				126
			};
			Console.SetMemory(2199520720U, accolades);
		}

		 //0x060001BF RID: 447 RVA: 0x000154E8 File Offset: 0x000136E8
		private void simpleButton263_Click(object sender, EventArgs e)
		{
			numericUpDown174.Text = BitConverter.ToInt32(Console.GetMemory(2199522772U, 4U), 0).ToString();
			numericUpDown179.Text = BitConverter.ToInt32(Console.GetMemory(2199522764U, 4U), 0).ToString();
			numericUpDown180.Text = BitConverter.ToInt32(Console.GetMemory(2199522836U, 4U), 0).ToString();
			numericUpDown177.Text = BitConverter.ToInt32(Console.GetMemory(2199522840U, 4U), 0).ToString();
			numericUpDown175.Text = BitConverter.ToInt32(Console.GetMemory(2199522844U, 4U), 0).ToString();
			numericUpDown171.Text = BitConverter.ToInt32(Console.GetMemory(2199522848U, 4U), 0).ToString();
			numericUpDown161.Text = BitConverter.ToInt32(Console.GetMemory(2199522780U, 4U), 0).ToString();
			numericUpDown159.Text = BitConverter.ToInt32(Console.GetMemory(2199522784U, 4U), 0).ToString();
			numericUpDown157.Text = BitConverter.ToInt32(Console.GetMemory(2199522792U, 4U), 0).ToString();
			numericUpDown158.Text = BitConverter.ToInt32(Console.GetMemory(2199522800U, 4U), 0).ToString();
			numericUpDown160.Text = BitConverter.ToInt32(Console.GetMemory(2199522804U, 4U), 0).ToString();
			numericUpDown163.Text = BitConverter.ToInt32(Console.GetMemory(2199522788U, 4U), 0).ToString();
			numericUpDown165.Text = BitConverter.ToInt32(Console.GetMemory(2199522860U, 4U), 0).ToString();
			numericUpDown167.Text = BitConverter.ToInt32(Console.GetMemory(2199522864U, 4U), 0).ToString();
			int num = BitConverter.ToInt32(Console.GetMemory(2199522816U, 4U), 0);
			int num2 = num / 86400;
			int num3 = (num - num2 * 86400) / 3600;
			int num4 = (num - num2 * 86400 - num3 * 3600) / 60;
			numericUpDown168.Text = num2.ToString();
			numericUpDown170.Text = num3.ToString();
			numericUpDown173.Text = num4.ToString();
			int num5 = BitConverter.ToInt32(Console.GetMemory(2199522820U, 4U), 0);
			int num6 = num5 / 86400;
			int num7 = (num5 - num6 * 86400) / 3600;
			int num8 = (num5 - num6 * 86400 - num7 * 3600) / 60;
			numericUpDown178.Text = num6.ToString();
			numericUpDown172.Text = num7.ToString();
			numericUpDown169.Text = num8.ToString();
			int num9 = BitConverter.ToInt32(Console.GetMemory(2199522824U, 4U), 0);
			int num10 = num9 / 86400;
			int num11 = (num9 - num10 * 86400) / 3600;
			int num12 = (num9 - num10 * 86400 - num11 * 3600) / 60;
			numericUpDown166.Text = num10.ToString();
			numericUpDown164.Text = num11.ToString();
			numericUpDown162.Text = num12.ToString();
			numericUpDown174.Enabled = true;
			numericUpDown179.Enabled = true;
			numericUpDown180.Enabled = true;
			numericUpDown177.Enabled = true;
			numericUpDown175.Enabled = true;
			numericUpDown171.Enabled = true;
			numericUpDown161.Enabled = true;
			numericUpDown159.Enabled = true;
			numericUpDown157.Enabled = true;
			numericUpDown158.Enabled = true;
			numericUpDown160.Enabled = true;
			numericUpDown163.Enabled = true;
			numericUpDown165.Enabled = true;
			numericUpDown167.Enabled = true;
			numericUpDown168.Enabled = true;
			numericUpDown170.Enabled = true;
			numericUpDown173.Enabled = true;
			numericUpDown178.Enabled = true;
			numericUpDown172.Enabled = true;
			numericUpDown169.Enabled = true;
			numericUpDown166.Enabled = true;
			numericUpDown164.Enabled = true;
			numericUpDown162.Enabled = true;
			simpleButton262.Enabled = true;
			simpleButton263.Enabled = false;
			simpleButton271.Enabled = true;
		}

		 //0x060001C0 RID: 448 RVA: 0x00015A40 File Offset: 0x00013C40
		private void simpleButton262_Click_1(object sender, EventArgs e)
		{
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(numericUpDown174.Text));
			Console.SetMemory(2199522772U, bytes);
			byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown179.Text));
			Console.SetMemory(2199522764U, bytes2);
			byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown180.Text));
			Console.SetMemory(2199522836U, bytes3);
			byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown177.Text));
			Console.SetMemory(2199522840U, bytes4);
			byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown175.Text));
			Console.SetMemory(2199522844U, bytes5);
			byte[] bytes6 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown171.Text));
			Console.SetMemory(2199522848U, bytes6);
			byte[] bytes7 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown161.Text));
			Console.SetMemory(2199522780U, bytes7);
			byte[] bytes8 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown159.Text));
			Console.SetMemory(2199522784U, bytes8);
			byte[] bytes9 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown157.Text));
			Console.SetMemory(2199522792U, bytes9);
			byte[] bytes10 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown158.Text));
			Console.SetMemory(2199522800U, bytes10);
			byte[] bytes11 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown160.Text));
			Console.SetMemory(2199522804U, bytes11);
			byte[] bytes12 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown163.Text));
			Console.SetMemory(2199522788U, bytes12);
			byte[] bytes13 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown165.Text));
			Console.SetMemory(2199522860U, bytes13);
			byte[] bytes14 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown167.Text));
			Console.SetMemory(2199522864U, bytes14);
			int num = Convert.ToInt32(numericUpDown168.Text);
			int num2 = Convert.ToInt32(numericUpDown170.Text);
			int num3 = Convert.ToInt32(numericUpDown173.Text);
			int value = num * 86400 + num2 * 3600 + num3 * 60;
			byte[] bytes15 = BitConverter.GetBytes(value);
			Console.SetMemory(2199522816U, bytes15);
			int num4 = Convert.ToInt32(numericUpDown178.Text);
			int num5 = Convert.ToInt32(numericUpDown172.Text);
			int num6 = Convert.ToInt32(numericUpDown169.Text);
			int value2 = num4 * 86400 + num5 * 3600 + num6 * 60;
			byte[] bytes16 = BitConverter.GetBytes(value2);
			Console.SetMemory(2199522820U, bytes16);
			int num7 = Convert.ToInt32(numericUpDown166.Text);
			int num8 = Convert.ToInt32(numericUpDown164.Text);
			int num9 = Convert.ToInt32(numericUpDown162.Text);
			int value3 = num7 * 86400 + num8 * 3600 + num9 * 60;
			byte[] bytes17 = BitConverter.GetBytes(value3);
			Console.SetMemory(2199522824U, bytes17);
			numericUpDown174.Enabled = false;
			numericUpDown179.Enabled = false;
			numericUpDown180.Enabled = false;
			numericUpDown177.Enabled = false;
			numericUpDown175.Enabled = false;
			numericUpDown171.Enabled = false;
			numericUpDown161.Enabled = false;
			numericUpDown159.Enabled = false;
			numericUpDown157.Enabled = false;
			numericUpDown158.Enabled = false;
			numericUpDown160.Enabled = false;
			numericUpDown163.Enabled = false;
			numericUpDown165.Enabled = false;
			numericUpDown167.Enabled = false;
			numericUpDown168.Enabled = false;
			numericUpDown170.Enabled = false;
			numericUpDown173.Enabled = false;
			numericUpDown178.Enabled = false;
			numericUpDown172.Enabled = false;
			numericUpDown169.Enabled = false;
			numericUpDown166.Enabled = false;
			numericUpDown164.Enabled = false;
			numericUpDown162.Enabled = false;
			simpleButton262.Enabled = false;
			simpleButton263.Enabled = true;
			simpleButton271.Enabled = false;
			MessageBox.Show("Stats set.");
		}

		 //0x060001C1 RID: 449 RVA: 0x00015F30 File Offset: 0x00014130
		private void simpleButton267_Click(object sender, EventArgs e)
		{
			UnlockAllCOD4();
			Console.XNotify("Successfully unlocked all");
		}

		 //0x060001C2 RID: 450 RVA: 0x00015F4C File Offset: 0x0001414C
		private void UnlockAllCOD4()
		{
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3000 9"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3001 9"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3002 9"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3003 1"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3004 1"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3010 7951"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3011 7951"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3012 16143"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3013 7951"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3014 7951"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3020 16175"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3021 7983"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3022 7937"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3023 7983"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3024 7983"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3025 7983"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3026 7983"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3060 16131"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3061 7939"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3062 7939"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3064 7939"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3065 7939"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3070 16149"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3071 7957"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3080 7959"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3081 7959"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 3082 16151"
			});
		}

		 //0x060001C3 RID: 451 RVA: 0x00016394 File Offset: 0x00014594
		private void simpleButton266_Click(object sender, EventArgs e)
		{
			int value = BitConverter.ToInt32(Console.GetMemory(2227564324U, 4U), 0);
			byte[] bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes, 0, 4);
			value = BitConverter.ToInt32(bytes, 0);
			numericUpDown208.Text = value.ToString();
			int value2 = BitConverter.ToInt32(Console.GetMemory(2227564224U, 4U), 0);
			byte[] bytes2 = BitConverter.GetBytes(value2);
			Array.Reverse(bytes2, 0, 4);
			value2 = BitConverter.ToInt32(bytes2, 0);
			numericUpDown211.Text = value2.ToString();
			int value3 = BitConverter.ToInt32(Console.GetMemory(2227564284U, 4U), 0);
			byte[] bytes3 = BitConverter.GetBytes(value3);
			Array.Reverse(bytes3, 0, 4);
			value3 = BitConverter.ToInt32(bytes3, 0);
			numericUpDown212.Text = value3.ToString();
			int value4 = BitConverter.ToInt32(Console.GetMemory(2227564288U, 4U), 0);
			byte[] bytes4 = BitConverter.GetBytes(value4);
			Array.Reverse(bytes4, 0, 4);
			value4 = BitConverter.ToInt32(bytes4, 0);
			numericUpDown210.Text = value4.ToString();
			int value5 = BitConverter.ToInt32(Console.GetMemory(2227564292U, 4U), 0);
			byte[] bytes5 = BitConverter.GetBytes(value5);
			Array.Reverse(bytes5, 0, 4);
			value5 = BitConverter.ToInt32(bytes5, 0);
			numericUpDown209.Text = value5.ToString();
			int value6 = BitConverter.ToInt32(Console.GetMemory(2227564296U, 4U), 0);
			byte[] bytes6 = BitConverter.GetBytes(value6);
			Array.Reverse(bytes6, 0, 4);
			value6 = BitConverter.ToInt32(bytes6, 0);
			numericUpDown207.Text = value6.ToString();
			int value7 = BitConverter.ToInt32(Console.GetMemory(2227564228U, 4U), 0);
			byte[] bytes7 = BitConverter.GetBytes(value7);
			Array.Reverse(bytes7, 0, 4);
			value7 = BitConverter.ToInt32(bytes7, 0);
			numericUpDown205.Text = value7.ToString();
			int value8 = BitConverter.ToInt32(Console.GetMemory(2227564232U, 4U), 0);
			byte[] bytes8 = BitConverter.GetBytes(value8);
			Array.Reverse(bytes8, 0, 4);
			value8 = BitConverter.ToInt32(bytes8, 0);
			numericUpDown203.Text = value8.ToString();
			int value9 = BitConverter.ToInt32(Console.GetMemory(2227564240U, 4U), 0);
			byte[] bytes9 = BitConverter.GetBytes(value9);
			Array.Reverse(bytes9, 0, 4);
			value9 = BitConverter.ToInt32(bytes9, 0);
			numericUpDown201.Text = value9.ToString();
			int value10 = BitConverter.ToInt32(Console.GetMemory(2227564248U, 4U), 0);
			byte[] bytes10 = BitConverter.GetBytes(value10);
			Array.Reverse(bytes10, 0, 4);
			value10 = BitConverter.ToInt32(bytes10, 0);
			numericUpDown202.Text = value10.ToString();
			int value11 = BitConverter.ToInt32(Console.GetMemory(2227564252U, 4U), 0);
			byte[] bytes11 = BitConverter.GetBytes(value11);
			Array.Reverse(bytes11, 0, 4);
			value11 = BitConverter.ToInt32(bytes11, 0);
			numericUpDown204.Text = value11.ToString();
			int value12 = BitConverter.ToInt32(Console.GetMemory(2227564236U, 4U), 0);
			byte[] bytes12 = BitConverter.GetBytes(value12);
			Array.Reverse(bytes12, 0, 4);
			value12 = BitConverter.ToInt32(bytes12, 0);
			numericUpDown206.Text = value12.ToString();
			int value13 = BitConverter.ToInt32(Console.GetMemory(2227564308U, 4U), 0);
			byte[] bytes13 = BitConverter.GetBytes(value13);
			Array.Reverse(bytes13, 0, 4);
			value13 = BitConverter.ToInt32(bytes13, 0);
			numericUpDown213.Text = value13.ToString();
			int value14 = BitConverter.ToInt32(Console.GetMemory(2227564312U, 4U), 0);
			byte[] bytes14 = BitConverter.GetBytes(value14);
			Array.Reverse(bytes14, 0, 4);
			value14 = BitConverter.ToInt32(bytes14, 0);
			numericUpDown214.Text = value14.ToString();
			int num = BitConverter.ToInt32(Console.GetMemory(2227564276U, 4U), 0);
			byte[] bytes15 = BitConverter.GetBytes(num);
			Array.Reverse(bytes15, 0, 4);
			num = BitConverter.ToInt32(bytes15, 0);
			int num2 = num / 86400;
			int num3 = (num - num2 * 86400) / 3600;
			int num4 = (num - num2 * 86400 - num3 * 3600) / 60;
			numericUpDown198.Text = num2.ToString();
			numericUpDown199.Text = num3.ToString();
			numericUpDown200.Text = num4.ToString();
			numericUpDown198.Enabled = true;
			numericUpDown199.Enabled = true;
			numericUpDown200.Enabled = true;
			numericUpDown201.Enabled = true;
			numericUpDown202.Enabled = true;
			numericUpDown203.Enabled = true;
			numericUpDown204.Enabled = true;
			numericUpDown205.Enabled = true;
			numericUpDown206.Enabled = true;
			numericUpDown207.Enabled = true;
			numericUpDown208.Enabled = true;
			numericUpDown209.Enabled = true;
			numericUpDown210.Enabled = true;
			numericUpDown211.Enabled = true;
			numericUpDown212.Enabled = true;
			numericUpDown213.Enabled = true;
			numericUpDown214.Enabled = true;
			simpleButton266.Enabled = false;
			simpleButton267.Enabled = true;
			simpleButton265.Enabled = true;
		}

		 //0x060001C4 RID: 452 RVA: 0x00016940 File Offset: 0x00014B40
		private void simpleButton265_Click(object sender, EventArgs e)
		{
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2326 \"" + numericUpDown208.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2301 \"" + numericUpDown211.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2316 \"" + numericUpDown212.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2317 \"" + numericUpDown210.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2318 \"" + numericUpDown209.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2319 \"" + numericUpDown207.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2302 \"" + numericUpDown205.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2303 \"" + numericUpDown203.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2305 \"" + numericUpDown201.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2307 \"" + numericUpDown202.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2308 \"" + numericUpDown204.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2304 \"" + numericUpDown206.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2322 \"" + numericUpDown213.Text + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2323 \"" + numericUpDown214.Text + "\""
			});
			int num = int.Parse(numericUpDown198.Text);
			int num2 = int.Parse(numericUpDown199.Text);
			int num3 = int.Parse(numericUpDown200.Text);
			int num4 = num * 86400 + num2 * 3600 + num3 * 60;
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"statSet 2314 \"" + num4.ToString() + "\""
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"updategamerprofile"
			});
			Console.CallVoid(2183372752U, new object[]
			{
				0,
				"uploadstats"
			});
			numericUpDown198.Enabled = false;
			numericUpDown199.Enabled = false;
			numericUpDown200.Enabled = false;
			numericUpDown201.Enabled = false;
			numericUpDown202.Enabled = false;
			numericUpDown203.Enabled = false;
			numericUpDown204.Enabled = false;
			numericUpDown205.Enabled = false;
			numericUpDown206.Enabled = false;
			numericUpDown207.Enabled = false;
			numericUpDown208.Enabled = false;
			numericUpDown209.Enabled = false;
			numericUpDown210.Enabled = false;
			numericUpDown211.Enabled = false;
			numericUpDown212.Enabled = false;
			numericUpDown213.Enabled = false;
			numericUpDown214.Enabled = false;
			simpleButton266.Enabled = true;
			simpleButton266.Enabled = true;
			simpleButton267.Enabled = false;
			simpleButton265.Enabled = false;
			Console.XNotify("Stats set");
		}

		 //0x060001C5 RID: 453 RVA: 0x00016E98 File Offset: 0x00015098
		private void simpleButton269_Click_1(object sender, EventArgs e)
		{
			Array.Clear(SMCMessage, 0, SMCMessage.Length);
			Array.Clear(SMCReturn, 0, SMCReturn.Length);
			SMCMessage[0] = 154;
			SMCMessage[1] = 82;
			SMCMessage[2] = byte.MaxValue;
			SMCMessage[3] = byte.MaxValue;
			object[] array = new object[2];
			array[0] = SMCMessage;
			Console.CallVoid("xboxkrnl.exe", 41, array);
		}

		 //0x060001C6 RID: 454 RVA: 0x00016F28 File Offset: 0x00015128
		private void simpleButton273_Click(object sender, EventArgs e)
		{
			int value = (int)(numericUpDown271.Value / 0.5m);
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(value));
			Console.SetMemory(2215147952U, bytes);
			int value2 = (int)(numericUpDown272.Value / 128m);
			byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(value2));
			Console.SetMemory(2215147957U, bytes2);
			int value3 = (int)(numericUpDown273.Value / 1m);
			byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(value3));
			Console.SetMemory(2215174160U, bytes3);
			int value4 = (int)(numericUpDown274.Value / 1m);
			byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(value4));
			Console.SetMemory(2215175673U, bytes4);
			int value5 = (int)(numericUpDown275.Value / 1m);
			byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(value5));
			Console.SetMemory(2215175669U, bytes5);
		}

		 //0x060001C7 RID: 455 RVA: 0x0001706C File Offset: 0x0001526C
		private void simpleButton287_Click(object sender, EventArgs e)
		{
			int value = (int)numericUpDown315.Value;
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(value));
			Console.SetMemory(2215175157U, bytes);
			int value2 = (int)(numericUpDown315.Value + numericUpDown321.Value);
			byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(value2));
			Console.SetMemory(2215175169U, bytes2);
			int value3 = (int)numericUpDown228.Value;
			byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(value3));
			Console.SetMemory(2215175165U, bytes3);
			int value4 = (int)numericUpDown305.Value;
			byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(value4));
			Console.SetMemory(2215175161U, bytes4);
			int value5 = (int)numericUpDown227.Value;
			byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(value5));
			Console.SetMemory(2215175173U, bytes5);
		}

		 //0x060001C8 RID: 456 RVA: 0x00017184 File Offset: 0x00015384
		private void simpleButton298_Click(object sender, EventArgs e)
		{
			numericUpDown147.Text = BitConverter.ToInt32(Console.GetMemory(2215176189U, 4U), 0).ToString();
			numericUpDown149.Text = BitConverter.ToInt32(Console.GetMemory(2215176197U, 4U), 0).ToString();
			numericUpDown152.Text = BitConverter.ToInt32(Console.GetMemory(2215175153U, 4U), 0).ToString();
			numericUpDown153.Text = BitConverter.ToInt32(Console.GetMemory(2215176217U, 4U), 0).ToString();
			numericUpDown150.Text = BitConverter.ToInt32(Console.GetMemory(2215175497U, 4U), 0).ToString();
			numericUpDown134.Text = BitConverter.ToInt32(Console.GetMemory(2215175189U, 4U), 0).ToString();
			numericUpDown128.Text = BitConverter.ToInt32(Console.GetMemory(2215176317U, 4U), 0).ToString();
			numericUpDown118.Text = BitConverter.ToInt32(Console.GetMemory(2215175677U, 4U), 0).ToString();
			numericUpDown127.Text = BitConverter.ToInt32(Console.GetMemory(2215175089U, 4U), 0).ToString();
			numericUpDown133.Text = BitConverter.ToInt32(Console.GetMemory(2215175469U, 4U), 0).ToString();
			numericUpDown138.Text = BitConverter.ToInt32(Console.GetMemory(2215175489U, 4U), 0).ToString();
			numericUpDown140.Text = BitConverter.ToInt32(Console.GetMemory(2215175993U, 4U), 0).ToString();
			int num = BitConverter.ToInt32(Console.GetMemory(2215176261U, 4U), 0);
			int num2 = num / 86400;
			int num3 = (num - num2 * 86400) / 3600;
			int num4 = (num - num2 * 86400 - num3 * 3600) / 60;
			numericUpDown156.Text = num2.ToString();
			numericUpDown155.Text = num3.ToString();
			numericUpDown154.Text = num4.ToString();
			int num5 = BitConverter.ToInt32(Console.GetMemory(2215176265U, 4U), 0);
			int num6 = num5 / 86400;
			int num7 = (num5 - num6 * 86400) / 3600;
			int num8 = (num5 - num6 * 86400 - num7 * 3600) / 60;
			numericUpDown141.Text = num6.ToString();
			numericUpDown143.Text = num7.ToString();
			numericUpDown146.Text = num8.ToString();
			int num9 = BitConverter.ToInt32(Console.GetMemory(2215176269U, 4U), 0);
			int num10 = num9 / 86400;
			int num11 = (num9 - num10 * 86400) / 3600;
			int num12 = (num9 - num10 * 86400 - num11 * 3600) / 60;
			numericUpDown151.Text = num10.ToString();
			numericUpDown145.Text = num11.ToString();
			numericUpDown142.Text = num12.ToString();
			int num13 = BitConverter.ToInt32(Console.GetMemory(2215176273U, 4U), 0);
			int num14 = num13 / 86400;
			int num15 = (num13 - num14 * 86400) / 3600;
			int num16 = (num13 - num14 * 86400 - num15 * 3600) / 60;
			numericUpDown139.Text = num14.ToString();
			numericUpDown137.Text = num15.ToString();
			numericUpDown135.Text = num16.ToString();
			numericUpDown147.Enabled = true;
			numericUpDown149.Enabled = true;
			numericUpDown152.Enabled = true;
			numericUpDown153.Enabled = true;
			numericUpDown150.Enabled = true;
			numericUpDown134.Enabled = true;
			numericUpDown128.Enabled = true;
			numericUpDown118.Enabled = true;
			numericUpDown127.Enabled = true;
			numericUpDown133.Enabled = true;
			numericUpDown156.Enabled = true;
			numericUpDown155.Enabled = true;
			numericUpDown154.Enabled = true;
			numericUpDown141.Enabled = true;
			numericUpDown143.Enabled = true;
			numericUpDown146.Enabled = true;
			numericUpDown151.Enabled = true;
			numericUpDown145.Enabled = true;
			numericUpDown142.Enabled = true;
			numericUpDown139.Enabled = true;
			numericUpDown137.Enabled = true;
			numericUpDown135.Enabled = true;
			numericUpDown138.Enabled = true;
			numericUpDown140.Enabled = true;
			simpleButton272.Enabled = true;
			simpleButton298.Enabled = false;
			simpleButton270.Enabled = true;
		}

		 //0x060001C9 RID: 457 RVA: 0x00017718 File Offset: 0x00015918
		private void simpleButton272_Click(object sender, EventArgs e)
		{
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(numericUpDown147.Text));
			Console.SetMemory(2215176189U, bytes);
			byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown149.Text));
			Console.SetMemory(2215176197U, bytes2);
			byte[] bytes3 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown152.Text));
			Console.SetMemory(2215175153U, bytes3);
			byte[] bytes4 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown153.Text));
			Console.SetMemory(2215176217U, bytes4);
			byte[] bytes5 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown150.Text));
			Console.SetMemory(2215175497U, bytes5);
			byte[] bytes6 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown134.Text));
			Console.SetMemory(2215175189U, bytes6);
			byte[] bytes7 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown128.Text));
			Console.SetMemory(2215176317U, bytes7);
			byte[] bytes8 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown118.Text));
			Console.SetMemory(2215175677U, bytes8);
			byte[] bytes9 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown127.Text));
			Console.SetMemory(2215175089U, bytes9);
			byte[] bytes10 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown133.Text));
			Console.SetMemory(2215175469U, bytes10);
			byte[] bytes11 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown138.Text));
			Console.SetMemory(2215175489U, bytes11);
			byte[] bytes12 = BitConverter.GetBytes(Convert.ToInt32(numericUpDown140.Text));
			Console.SetMemory(2215175993U, bytes12);
			int num = Convert.ToInt32(numericUpDown156.Text);
			int num2 = Convert.ToInt32(numericUpDown155.Text);
			int num3 = Convert.ToInt32(numericUpDown154.Text);
			int value = num * 86400 + num2 * 3600 + num3 * 60;
			byte[] bytes13 = BitConverter.GetBytes(value);
			Console.SetMemory(2215176261U, bytes13);
			int num4 = Convert.ToInt32(numericUpDown141.Text);
			int num5 = Convert.ToInt32(numericUpDown143.Text);
			int num6 = Convert.ToInt32(numericUpDown146.Text);
			int value2 = num4 * 86400 + num5 * 3600 + num6 * 60;
			byte[] bytes14 = BitConverter.GetBytes(value2);
			Console.SetMemory(2215176265U, bytes14);
			int num7 = Convert.ToInt32(numericUpDown151.Text);
			int num8 = Convert.ToInt32(numericUpDown145.Text);
			int num9 = Convert.ToInt32(numericUpDown142.Text);
			int value3 = num7 * 86400 + num8 * 3600 + num9 * 60;
			byte[] bytes15 = BitConverter.GetBytes(value3);
			Console.SetMemory(2215176269U, bytes15);
			int num10 = Convert.ToInt32(numericUpDown139.Text);
			int num11 = Convert.ToInt32(numericUpDown137.Text);
			int num12 = Convert.ToInt32(numericUpDown135.Text);
			int value4 = num10 * 86400 + num11 * 3600 + num12 * 60;
			byte[] bytes16 = BitConverter.GetBytes(value4);
			Console.SetMemory(2215176273U, bytes16);
			numericUpDown147.Enabled = false;
			numericUpDown149.Enabled = false;
			numericUpDown152.Enabled = false;
			numericUpDown153.Enabled = false;
			numericUpDown150.Enabled = false;
			numericUpDown134.Enabled = false;
			numericUpDown128.Enabled = false;
			numericUpDown118.Enabled = false;
			numericUpDown127.Enabled = false;
			numericUpDown133.Enabled = false;
			numericUpDown156.Enabled = false;
			numericUpDown155.Enabled = false;
			numericUpDown154.Enabled = false;
			numericUpDown141.Enabled = false;
			numericUpDown143.Enabled = false;
			numericUpDown146.Enabled = false;
			numericUpDown151.Enabled = false;
			numericUpDown145.Enabled = false;
			numericUpDown142.Enabled = false;
			numericUpDown139.Enabled = false;
			numericUpDown137.Enabled = false;
			numericUpDown135.Enabled = false;
			numericUpDown138.Enabled = false;
			numericUpDown140.Enabled = false;
			simpleButton272.Enabled = false;
			simpleButton298.Enabled = true;
			simpleButton70.Enabled = false;
			Console.XNotify("Stats saved");
		}

		 //0x060001CA RID: 458 RVA: 0x00017C34 File Offset: 0x00015E34
		private void simpleButton270_Click(object sender, EventArgs e)
		{
			Console.WriteUInt32(2215141031U, 4294967055U);
			Console.SetMemory(2215145697U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			Console.SetMemory(2215145793U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data = new byte[]
			{
				192
			};
			Console.SetMemory(2215146178U, data);
			byte[] data2 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215148128U, data2);
			byte[] data3 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215148380U, data3);
			byte[] data4 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215148967U, data4);
			byte[] data5 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215149051U, data5);
			byte[] data6 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215149303U, data6);
			byte[] data7 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215149135U, data7);
			byte[] data8 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215149386U, data8);
			byte[] data9 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215149470U, data9);
			byte[] data10 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215149554U, data10);
			byte[] data11 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215149638U, data11);
			byte[] data12 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215149647U, data12);
			byte[] data13 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215148128U, data13);
			byte[] data14 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150141U, data14);
			byte[] data15 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150225U, data15);
			byte[] data16 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150309U, data16);
			byte[] data17 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150393U, data17);
			byte[] data18 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150477U, data18);
			byte[] data19 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150561U, data19);
			byte[] data20 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150645U, data20);
			byte[] data21 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150728U, data21);
			byte[] data22 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215150812U, data22);
			byte[] data23 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215151148U, data23);
			byte[] data24 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215151232U, data24);
			byte[] data25 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215151316U, data25);
			byte[] data26 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215151567U, data26);
			byte[] data27 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215151651U, data27);
			byte[] data28 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215151735U, data28);
			byte[] data29 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215151987U, data29);
			byte[] data30 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215151903U, data30);
			byte[] data31 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215152154U, data31);
			byte[] data32 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215152490U, data32);
			byte[] data33 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215152574U, data33);
			byte[] data34 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215152658U, data34);
			byte[] data35 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215152741U, data35);
			byte[] data36 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215153161U, data36);
			byte[] data37 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215153329U, data37);
			byte[] data38 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215153412U, data38);
			byte[] data39 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215153664U, data39);
			byte[] data40 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215153748U, data40);
			byte[] data41 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215153832U, data41);
			byte[] data42 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215153916U, data42);
			byte[] data43 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215154083U, data43);
			byte[] data44 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215154167U, data44);
			byte[] data45 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215154251U, data45);
			byte[] data46 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215154335U, data46);
			byte[] data47 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215154419U, data47);
			byte[] data48 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215154503U, data48);
			Console.SetMemory(2215156935U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data49 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215160541U, data49);
			Console.SetMemory(2215160621U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data50 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215160709U, data50);
			byte[] data51 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215160793U, data51);
			byte[] data52 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215160877U, data52);
			byte[] data53 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215160961U, data53);
			byte[] data54 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161045U, data54);
			byte[] data55 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161129U, data55);
			byte[] data56 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215161212U, data56);
			byte[] data57 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161297U, data57);
			byte[] data58 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215161380U, data58);
			byte[] data59 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161464U, data59);
			byte[] data60 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161548U, data60);
			byte[] data61 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161632U, data61);
			byte[] data62 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161716U, data62);
			byte[] data63 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161800U, data63);
			byte[] data64 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215161883U, data64);
			byte[] data65 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215161968U, data65);
			byte[] data66 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215162051U, data66);
			byte[] data67 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215162135U, data67);
			byte[] data68 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215162218U, data68);
			byte[] data69 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215162303U, data69);
			byte[] data70 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215162386U, data70);
			byte[] data71 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215162471U, data71);
			byte[] data72 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215162554U, data72);
			byte[] data73 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215162639U, data73);
			byte[] data74 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215162722U, data74);
			byte[] data75 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215162806U, data75);
			byte[] data76 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215162890U, data76);
			byte[] data77 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215164316U, data77);
			byte[] data78 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215164400U, data78);
			byte[] data79 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215164568U, data79);
			byte[] data80 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215164736U, data80);
			byte[] data81 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215164819U, data81);
			byte[] data82 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215164899U, data82);
			byte[] data83 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215164903U, data83);
			byte[] data84 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215165155U, data84);
			byte[] data85 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215165239U, data85);
			byte[] data86 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215165323U, data86);
			byte[] data87 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215165407U, data87);
			byte[] data88 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215165490U, data88);
			byte[] data89 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215165658U, data89);
			byte[] data90 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215176914U, data90);
			byte[] data91 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215176932U, data91);
			byte[] data92 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215176949U, data92);
			byte[] data93 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215176967U, data93);
			byte[] data94 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215176985U, data94);
			byte[] data95 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177110U, data95);
			Console.SetMemory(2215177115U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data96 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177128U, data96);
			Console.SetMemory(2215177133U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data97 = new byte[]
			{
				byte.MaxValue,
				15
			};
			Console.SetMemory(2215177146U, data97);
			Console.SetMemory(2215177151U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data98 = new byte[]
			{
				byte.MaxValue,
				1
			};
			Console.SetMemory(2215177170U, data98);
			Console.SetMemory(2215177168U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data99 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177182U, data99);
			byte[] data100 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177200U, data100);
			Console.SetMemory(2215177204U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data101 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177212U, data101);
			byte[] data102 = new byte[]
			{
				byte.MaxValue,
				1
			};
			Console.SetMemory(2215177218U, data102);
			Console.SetMemory(2215177222U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data103 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177230U, data103);
			byte[] data104 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177235U, data104);
			Console.SetMemory(2215177240U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data105 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177253U, data105);
			Console.SetMemory(2215177258U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data106 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177361U, data106);
			Console.SetMemory(2215177365U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			Console.SetMemory(2215177378U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			Console.SetMemory(2215177383U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data107 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177396U, data107);
			Console.SetMemory(2215177401U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data108 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177414U, data108);
			Console.SetMemory(2215177419U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data109 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177432U, data109);
			Console.SetMemory(2215177437U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data110 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177450U, data110);
			Console.SetMemory(2215177454U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data111 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177468U, data111);
			Console.SetMemory(2215177472U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data112 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177480U, data112);
			byte[] data113 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177486U, data113);
			byte[] data114 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177480U, data114);
			Console.SetMemory(2215177490U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data115 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177504U, data115);
			Console.SetMemory(2215177508U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			Console.SetMemory(2215177521U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			Console.SetMemory(2215177526U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data116 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177557U, data116);
			Console.SetMemory(2215177562U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data117 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177575U, data117);
			Console.SetMemory(2215177580U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data118 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177593U, data118);
			Console.SetMemory(2215177597U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data119 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177611U, data119);
			Console.SetMemory(2215177615U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data120 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177647U, data120);
			Console.SetMemory(2215177651U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data121 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177659U, data121);
			byte[] data122 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177664U, data122);
			Console.SetMemory(2215177669U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data123 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177677U, data123);
			byte[] data124 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177682U, data124);
			Console.SetMemory(2215177687U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data125 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177694U, data125);
			byte[] data126 = new byte[]
			{
				byte.MaxValue,
				byte.MaxValue
			};
			Console.SetMemory(2215177700U, data126);
			Console.SetMemory(2215177704U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data127 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177712U, data127);
			byte[] data128 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177736U, data128);
			Console.SetMemory(2215177740U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data129 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177748U, data129);
			byte[] data130 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177754U, data130);
			Console.SetMemory(2215177758U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data131 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177766U, data131);
			Console.SetMemory(2215177776U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data132 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177784U, data132);
			byte[] data133 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177790U, data133);
			Console.SetMemory(2215177794U, new byte[]
			{
				byte.MaxValue,
				byte.MaxValue,
				byte.MaxValue
			});
			byte[] data134 = new byte[]
			{
				byte.MaxValue
			};
			Console.SetMemory(2215177802U, data134);
			Console.XNotify("Successfully unlocked all.");
		}

		 //0x060001CB RID: 459 RVA: 0x000194BC File Offset: 0x000176BC
		private void simpleButton288_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[1];
			uint num;
			Console.DebugTarget.SetMemory(2215139962U, 1U, data, out num);
		}

		 //0x060001CC RID: 460 RVA: 0x000194EC File Offset: 0x000176EC
		private void simpleButton268_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[1];
			uint num;
			Console.DebugTarget.SetMemory(2215139962U, 1U, data, out num);
			byte[] data2 = new byte[]
			{
				0,
				13,
				0,
				0,
				64,
				0,
				240,
				0,
				240,
				3,
				0,
				0,
				0,
				0,
				15
			};
			uint num2;
			Console.DebugTarget.SetMemory(2215139968U, 15U, data2, out num2);
		}

		 //0x060001CD RID: 461 RVA: 0x0001954C File Offset: 0x0001774C
		private void simpleButton290_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[1];
			uint num;
			Console.DebugTarget.SetMemory(2215139962U, 1U, data, out num);
			byte[] data2 = new byte[]
			{
				3,
				18,
				124,
				68,
				52,
				230
			};
			uint num2;
			Console.DebugTarget.SetMemory(2215139994U, 6U, data2, out num2);
		}

		 //0x060001CE RID: 462 RVA: 0x000195A8 File Offset: 0x000177A8
		private void simpleButton289_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[1];
			uint num;
			Console.DebugTarget.SetMemory(2215139962U, 1U, data, out num);
			byte[] data2 = new byte[]
			{
				198,
				1,
				0,
				0,
				144,
				0,
				240,
				0,
				240,
				3,
				0,
				0,
				0,
				182,
				2,
				0,
				0,
				0,
				16
			};
			uint num2;
			Console.DebugTarget.SetMemory(2215139968U, 19U, data2, out num2);
		}

		 //0x060001CF RID: 463 RVA: 0x00019608 File Offset: 0x00017808
		private void simpleButton291_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[1];
			uint num;
			Console.DebugTarget.SetMemory(2215139962U, 1U, data, out num);
			byte[] data2 = new byte[]
			{
				22,
				2,
				0,
				16,
				86,
				2,
				0,
				0,
				144,
				0,
				240,
				0,
				198,
				0,
				0,
				0,
				0,
				118,
				2,
				0,
				0,
				0,
				16
			};
			uint num2;
			Console.DebugTarget.SetMemory(2215139964U, 23U, data2, out num2);
		}

		 //0x060001D0 RID: 464 RVA: 0x00019668 File Offset: 0x00017868
		private void simpleButton296_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				22,
				2,
				0,
				16,
				166,
				1,
				0,
				0,
				0,
				16,
				240,
				3,
				54,
				2,
				0,
				0,
				0,
				198,
				1
			};
			uint num;
			Console.DebugTarget.SetMemory(2215139999U, 19U, data, out num);
		}

		 //0x060001D1 RID: 465 RVA: 0x000196A4 File Offset: 0x000178A4
		private void simpleButton295_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				246,
				0,
				0,
				16,
				54,
				1,
				0,
				0,
				0,
				16,
				240,
				3,
				198,
				0,
				0,
				0,
				0,
				70,
				1
			};
			uint num;
			Console.DebugTarget.SetMemory(2215139999U, 19U, data, out num);
		}

		 //0x060001D2 RID: 466 RVA: 0x000196E0 File Offset: 0x000178E0
		private void simpleButton293_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				86,
				2,
				0,
				16,
				118,
				2,
				0,
				0,
				0,
				16,
				240,
				3,
				102,
				2,
				0,
				0,
				0,
				134,
				2
			};
			uint num;
			Console.DebugTarget.SetMemory(2215139999U, 19U, data, out num);
		}

		 //0x060001D3 RID: 467 RVA: 0x0001971C File Offset: 0x0001791C
		private void simpleButton294_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				22,
				3,
				0,
				16,
				6,
				3,
				0,
				0,
				0,
				16,
				240,
				3,
				38,
				3,
				0,
				0,
				0,
				246,
				2
			};
			uint num;
			Console.DebugTarget.SetMemory(2215139999U, 19U, data, out num);
		}

		 //0x060001D4 RID: 468 RVA: 0x00019758 File Offset: 0x00017958
		private void simpleButton292_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				166,
				2,
				0,
				16,
				214,
				2,
				0,
				0,
				0,
				16,
				240,
				3,
				182,
				2,
				0,
				0,
				0,
				198,
				2
			};
			uint num;
			Console.DebugTarget.SetMemory(2215139999U, 19U, data, out num);
		}

		 //0x060001D5 RID: 469 RVA: 0x00019794 File Offset: 0x00017994
		private void simpleButton297_Click(object sender, EventArgs e)
		{
			byte[] data = new byte[]
			{
				134,
				2,
				0,
				16,
				38,
				3,
				0,
				0,
				0,
				16,
				240,
				3,
				182,
				2,
				0,
				0,
				0,
				166,
				1
			};
			uint num;
			Console.DebugTarget.SetMemory(2215139999U, 19U, data, out num);
		}

		 //0x060001D6 RID: 470 RVA: 0x000197D0 File Offset: 0x000179D0
		private void simpleButton304_Click(object sender, EventArgs e)
		{
			Random random = new Random();
			byte[] array = new byte[2];
			random.NextBytes(array);
			uint num;
			Console.DebugTarget.SetMemory(2215140042U, 2U, array, out num);
			Random random2 = new Random();
			byte[] array2 = new byte[2];
			random2.NextBytes(array2);
			uint num2;
			Console.DebugTarget.SetMemory(2215140055U, 2U, array2, out num2);
		}

		 //0x060001D7 RID: 471 RVA: 0x00019840 File Offset: 0x00017A40
		private void simpleButton303_Click(object sender, EventArgs e)
		{
			Random random = new Random();
			byte[] array = new byte[4];
			random.NextBytes(array);
			uint num;
			Console.DebugTarget.SetMemory(2215140069U, 4U, array, out num);
		}

		 //0x060001D8 RID: 472 RVA: 0x00019880 File Offset: 0x00017A80
		private void simpleButton301_Click(object sender, EventArgs e)
		{
			Random random = new Random();
			byte[] array = new byte[2];
			random.NextBytes(array);
			uint num;
			Console.DebugTarget.SetMemory(2215140038U, 2U, array, out num);
			Random random2 = new Random();
			byte[] array2 = new byte[2];
			random2.NextBytes(array2);
			uint num2;
			Console.DebugTarget.SetMemory(2215140050U, 2U, array2, out num2);
			Random random3 = new Random();
			byte[] array3 = new byte[1];
			random3.NextBytes(array3);
			uint num3;
			Console.DebugTarget.SetMemory(2215140067U, 1U, array3, out num3);
		}

		 //0x060001D9 RID: 473 RVA: 0x00019924 File Offset: 0x00017B24
		private void simpleButton302_Click(object sender, EventArgs e)
		{
			Random random = new Random();
			byte[] array = new byte[1];
			random.NextBytes(array);
			uint num;
			Console.DebugTarget.SetMemory(2215140036U, 1U, array, out num);
			Random random2 = new Random();
			byte[] array2 = new byte[1];
			random2.NextBytes(array2);
			uint num2;
			Console.DebugTarget.SetMemory(2215140040U, 1U, array2, out num2);
		}

		 //0x060001DA RID: 474 RVA: 0x00019994 File Offset: 0x00017B94
		private void simpleButton300_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = XtraMessageBox.Show(styleController1.LookAndFeel, "This is VERY LIKELY to crash your Xbox. Would you like to continue regardless?", "Warning", MessageBoxButtons.YesNo);
			bool flag = dialogResult == DialogResult.Yes;
			bool flag2 = flag;
			if (flag2)
			{
				Random random = new Random();
				byte[] array = new byte[26];
				random.NextBytes(array);
				uint num;
				Console.DebugTarget.SetMemory(2215140038U, 26U, array, out num);
			}
			else
			{
				bool flag3 = dialogResult == DialogResult.No;
				bool flag4 = flag3;
				if (flag4)
				{
				}
			}
		}

		 //0x060001DB RID: 475 RVA: 0x00019A12 File Offset: 0x00017C12
		private void textEdit33_EditValueChanged(object sender, EventArgs e)
		{
		}

		 //0x0400002C RID: 44
		private IXboxConsole Console;

		 //0x0400002D RID: 45
		private Point lastPoint;

		 //0x0400002E RID: 46
		private byte[] SMCMessage = new byte[16];

		 //0x0400002F RID: 47
		private string MyIP = "";

		 //0x04000030 RID: 48
		private uint pre11 = 11U;

		 //0x04000031 RID: 49
		public uint BO2CMD = 0x824015E0;

		 //0x04000032 RID: 50
		public uint BO2SV = 0x8242FB70;

		 //0x04000033 RID: 51
		private static readonly DiscordRpcClient _rpcClient = new DiscordRpcClient("1033592857455493160");

		 //0x04000035 RID: 53
		public static List<Client> GrabbedClients = new List<Client>();

		 //0x04000036 RID: 54
		private uint uint_10;

		 //0x04000037 RID: 55
		private byte[] byte_0;

		 //0x04000038 RID: 56
		private object selectedIndex;

		 //0x04000039 RID: 57
		public static uint addr = 3259175904U;

		 //0x0400003C RID: 60
		private byte[] unlocktitles = new byte[]
		{
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue
		};

		 //0x0400003D RID: 61
		private byte[] unlocks1 = new byte[]
		{
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue
		};

		 //0x0400003E RID: 62
		private byte[] unlock2 = new byte[]
		{
			140,
			20,
			5,
			0,
			0,
			0,
			128,
			17,
			1,
			0,
			0,
			0,
			128,
			252,
			1,
			0,
			0,
			0,
			128,
			156,
			62,
			0,
			0,
			0,
			0,
			190,
			13,
			0,
			0,
			0,
			0,
			109,
			0,
			0,
			0,
			50,
			128,
			215,
			83,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			57,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			128,
			161,
			0,
			0,
			0,
			15,
			128,
			207,
			1,
			0,
			0,
			75,
			128,
			108,
			0,
			0,
			0,
			75,
			0,
			165,
			0,
			0,
			0,
			10,
			128,
			70,
			0,
			0,
			0,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			29,
			1,
			36,
			53,
			162,
			55,
			32,
			131,
			53,
			1,
			0,
			0,
			0,
			128,
			34,
			0,
			0,
			0,
			0,
			0,
			94,
			0,
			0,
			0,
			0,
			96,
			135,
			9,
			0,
			0,
			0,
			0,
			157,
			2,
			0,
			0,
			0,
			192,
			21,
			0,
			0,
			128,
			12,
			0,
			204,
			16,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			9,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			32,
			36,
			0,
			0,
			192,
			3,
			32,
			41,
			0,
			0,
			192,
			18,
			64,
			30,
			0,
			0,
			192,
			18,
			32,
			39,
			0,
			0,
			128,
			2,
			0,
			18,
			0,
			0,
			64,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			64,
			71,
			0,
			73,
			101,
			210,
			15,
			200,
			216,
			70,
			0,
			0,
			0,
			0,
			240,
			19,
			0,
			0,
			0,
			0,
			168,
			21,
			0,
			0,
			0,
			0,
			232,
			95,
			3,
			0,
			0,
			0,
			8,
			194,
			0,
			0,
			0,
			0,
			168,
			5,
			0,
			0,
			32,
			3,
			0,
			175,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			80,
			2,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			0,
			0,
			0,
			120,
			0,
			104,
			8,
			0,
			0,
			240,
			0,
			144,
			13,
			0,
			0,
			176,
			4,
			128,
			8,
			0,
			0,
			176,
			4,
			96,
			8,
			0,
			0,
			160,
			0,
			136,
			3,
			0,
			0,
			80,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			208,
			17,
			64,
			82,
			145,
			212,
			3,
			50,
			252,
			14,
			0,
			0,
			0,
			0,
			248,
			0,
			0,
			0,
			0,
			0,
			68,
			6,
			0,
			0,
			0,
			0,
			178,
			61,
			0,
			0,
			0,
			0,
			58,
			6,
			0,
			0,
			0,
			0,
			138,
			1,
			0,
			0,
			200,
			0,
			218,
			250,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			188,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			174,
			1,
			0,
			0,
			60,
			0,
			108,
			1,
			0,
			0,
			44,
			1,
			80,
			2,
			0,
			0,
			44,
			1,
			114,
			1,
			0,
			0,
			40,
			0,
			198,
			0,
			0,
			0,
			20,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			52,
			4,
			144,
			212,
			56,
			202,
			128,
			136,
			164,
			4,
			0,
			0,
			0,
			0,
			116,
			0,
			0,
			0,
			0,
			0,
			94,
			1,
			0,
			0,
			0,
			0,
			223,
			48,
			0,
			0,
			0,
			128,
			187,
			11,
			0,
			0,
			0,
			128,
			91,
			0,
			0,
			0,
			50,
			0,
			80,
			56,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			42,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			128,
			139,
			0,
			0,
			0,
			15,
			0,
			157,
			0,
			0,
			0,
			75,
			0,
			133,
			0,
			0,
			0,
			75,
			0,
			158,
			0,
			0,
			0,
			10,
			128,
			66,
			0,
			0,
			0,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			29,
			1,
			36,
			165,
			43,
			62,
			32,
			192,
			8,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			0,
			0,
			128,
			2,
			0,
			0,
			0,
			0,
			224,
			128,
			0,
			0,
			0,
			0,
			0,
			27,
			0,
			0,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			1,
			64,
			120,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			32,
			0,
			0,
			0,
			32,
			0,
			192,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			3,
			0,
			0,
			0,
			0,
			32,
			1,
			0,
			0,
			0,
			0,
			160,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			80,
			145,
			0,
			0,
			248,
			1,
			0,
			0,
			0,
			0,
			32,
			0,
			0,
			0,
			0,
			0,
			200,
			0,
			0,
			0,
			0,
			0,
			96,
			21,
			0,
			0,
			0,
			0,
			72,
			4,
			0,
			0,
			0,
			0,
			40,
			0,
			0,
			0,
			40,
			0,
			120,
			26,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			8,
			0,
			0,
			0,
			8,
			0,
			64,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			112,
			0,
			0,
			0,
			0,
			0,
			72,
			0,
			0,
			0,
			0,
			0,
			32,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			228,
			37,
			0,
			0,
			122,
			0,
			0,
			0,
			0,
			0,
			6,
			0,
			0,
			0,
			0,
			0,
			36,
			0,
			0,
			0,
			0,
			0,
			18,
			6,
			0,
			0,
			0,
			0,
			34,
			1,
			0,
			0,
			0,
			0,
			14,
			0,
			0,
			0,
			14,
			0,
			242,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			2,
			0,
			16,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			6,
			0,
			0,
			0,
			0,
			0,
			12,
			0,
			0,
			0,
			0,
			0,
			10,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			246,
			9,
			0,
			128,
			7,
			0,
			0,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			0,
			128,
			1,
			0,
			0,
			0,
			0,
			128,
			35,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			1,
			128,
			146,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			125,
			0,
			0,
			128,
			4,
			0,
			0,
			0,
			0,
			160,
			0,
			0,
			0,
			0,
			0,
			96,
			1,
			0,
			0,
			0,
			0,
			96,
			79,
			0,
			0,
			0,
			0,
			0,
			15,
			0,
			0,
			0,
			0,
			64,
			0,
			0,
			0,
			64,
			0,
			160,
			49,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			96,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			192,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			0,
			0,
			0,
			0,
			0,
			128,
			0,
			0,
			0,
			0,
			0,
			64,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			64,
			106,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			32,
			82,
			22,
			0,
			0,
			0,
			0,
			190,
			19,
			0,
			0,
			0,
			0,
			100,
			7,
			0,
			0,
			0,
			0,
			110,
			202,
			1,
			0,
			0,
			0,
			246,
			97,
			0,
			0,
			0,
			0,
			192,
			1,
			0,
			0,
			200,
			0,
			38,
			96,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			142,
			2,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			246,
			1,
			0,
			0,
			60,
			0,
			122,
			2,
			0,
			0,
			44,
			1,
			234,
			1,
			0,
			0,
			44,
			1,
			88,
			3,
			0,
			0,
			40,
			0,
			160,
			1,
			0,
			0,
			20,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			100,
			53,
			252,
			134,
			158,
			246,
			128,
			12,
			102,
			5,
			0,
			0,
			0,
			128,
			108,
			2,
			0,
			0,
			0,
			128,
			13,
			2,
			0,
			0,
			0,
			0,
			197,
			111,
			0,
			0,
			0,
			0,
			77,
			26,
			0,
			0,
			0,
			128,
			112,
			0,
			0,
			0,
			50,
			128,
			140,
			90,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			135,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			0,
			147,
			0,
			0,
			0,
			15,
			0,
			110,
			0,
			0,
			0,
			75,
			0,
			117,
			0,
			0,
			0,
			75,
			0,
			171,
			0,
			0,
			0,
			10,
			128,
			80,
			0,
			0,
			0,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			89,
			13,
			191,
			1,
			213,
			52,
			32,
			67,
			99,
			1,
			0,
			0,
			0,
			160,
			117,
			1,
			0,
			0,
			0,
			160,
			139,
			0,
			0,
			0,
			0,
			64,
			136,
			27,
			0,
			0,
			0,
			128,
			66,
			5,
			0,
			0,
			0,
			96,
			27,
			0,
			0,
			128,
			12,
			224,
			205,
			22,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			96,
			42,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			32,
			35,
			0,
			0,
			192,
			3,
			224,
			25,
			0,
			0,
			192,
			18,
			64,
			24,
			0,
			0,
			192,
			18,
			96,
			55,
			0,
			0,
			128,
			2,
			224,
			21,
			0,
			0,
			64,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			64,
			86,
			195,
			111,
			100,
			79,
			16,
			200,
			0,
			98,
			0,
			0,
			0,
			0,
			144,
			15,
			0,
			0,
			0,
			0,
			40,
			32,
			0,
			0,
			0,
			0,
			8,
			172,
			7,
			0,
			0,
			0,
			168,
			209,
			1,
			0,
			0,
			0,
			40,
			8,
			0,
			0,
			32,
			3,
			224,
			62,
			6,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			16,
			9,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			0,
			0,
			0,
			120,
			0,
			232,
			10,
			0,
			0,
			240,
			0,
			168,
			7,
			0,
			0,
			176,
			4,
			176,
			7,
			0,
			0,
			176,
			4,
			88,
			12,
			0,
			0,
			160,
			0,
			96,
			6,
			0,
			0,
			80,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			144,
			213,
			240,
			27,
			242,
			225,
			3,
			50,
			102,
			37,
			0,
			0,
			0,
			0,
			16,
			29,
			0,
			0,
			0,
			0,
			8,
			25,
			0,
			0,
			0,
			0,
			114,
			218,
			2,
			0,
			0,
			0,
			252,
			133,
			0,
			0,
			0,
			0,
			128,
			2,
			0,
			0,
			200,
			0,
			88,
			67,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			124,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			84,
			5,
			0,
			0,
			60,
			0,
			78,
			2,
			0,
			0,
			44,
			1,
			16,
			2,
			0,
			0,
			44,
			1,
			184,
			4,
			0,
			0,
			40,
			0,
			52,
			1,
			0,
			0,
			20,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			100,
			53,
			252,
			70,
			123,
			218,
			128,
			140,
			178,
			7,
			0,
			0,
			0,
			128,
			71,
			2,
			0,
			0,
			0,
			0,
			152,
			3,
			0,
			0,
			0,
			0,
			112,
			170,
			0,
			0,
			0,
			128,
			136,
			36,
			0,
			0,
			0,
			128,
			174,
			0,
			0,
			0,
			50,
			128,
			128,
			154,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			229,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			0,
			207,
			0,
			0,
			0,
			15,
			0,
			118,
			0,
			0,
			0,
			75,
			0,
			91,
			0,
			0,
			0,
			75,
			0,
			byte.MaxValue,
			0,
			0,
			0,
			10,
			128,
			121,
			0,
			0,
			0,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			89,
			13,
			191,
			49,
			3,
			119,
			32,
			98,
			164,
			1,
			0,
			0,
			0,
			0,
			96,
			0,
			0,
			0,
			0,
			128,
			100,
			0,
			0,
			0,
			0,
			160,
			62,
			28,
			0,
			0,
			0,
			160,
			250,
			6,
			0,
			0,
			0,
			128,
			50,
			0,
			0,
			128,
			12,
			0,
			117,
			22,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			32,
			49,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			192,
			36,
			0,
			0,
			192,
			3,
			192,
			28,
			0,
			0,
			192,
			18,
			96,
			20,
			0,
			0,
			192,
			18,
			64,
			65,
			0,
			0,
			128,
			2,
			160,
			33,
			0,
			0,
			64,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			64,
			86,
			195,
			111,
			172,
			208,
			30,
			8,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			192,
			40,
			66,
			0,
			0,
			0,
			0,
			136,
			17,
			0,
			0,
			0,
			0,
			96,
			17,
			0,
			0,
			0,
			0,
			240,
			248,
			3,
			0,
			0,
			0,
			112,
			43,
			1,
			0,
			0,
			0,
			168,
			5,
			0,
			0,
			32,
			3,
			40,
			45,
			4,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			152,
			6,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			0,
			0,
			0,
			120,
			0,
			56,
			3,
			0,
			0,
			80,
			0,
			128,
			5,
			0,
			0,
			176,
			4,
			136,
			6,
			0,
			0,
			176,
			4,
			224,
			9,
			0,
			0,
			160,
			0,
			96,
			5,
			0,
			0,
			80,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			56,
			245,
			112,
			27,
			162,
			61,
			2,
			50,
			80,
			21,
			0,
			0,
			0,
			0,
			138,
			5,
			0,
			0,
			0,
			0,
			80,
			6,
			0,
			0,
			0,
			0,
			230,
			64,
			1,
			0,
			0,
			0,
			90,
			67,
			0,
			0,
			0,
			0,
			160,
			2,
			0,
			0,
			200,
			0,
			254,
			79,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			28,
			2,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			78,
			0,
			0,
			0,
			20,
			0,
			144,
			1,
			0,
			0,
			44,
			1,
			98,
			1,
			0,
			0,
			44,
			1,
			4,
			3,
			0,
			0,
			40,
			0,
			196,
			1,
			0,
			0,
			20,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			78,
			61,
			220,
			70,
			203,
			238,
			128,
			136,
			246,
			7,
			0,
			0,
			0,
			0,
			131,
			3,
			0,
			0,
			0,
			0,
			182,
			3,
			0,
			0,
			0,
			128,
			118,
			136,
			0,
			0,
			0,
			0,
			107,
			27,
			0,
			0,
			0,
			128,
			197,
			0,
			0,
			0,
			50,
			0,
			62,
			137,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			245,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			0,
			50,
			0,
			0,
			0,
			5,
			128,
			99,
			0,
			0,
			0,
			75,
			128,
			113,
			0,
			0,
			0,
			75,
			128,
			14,
			1,
			0,
			0,
			10,
			128,
			97,
			0,
			0,
			0,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			83,
			15,
			183,
			225,
			48,
			58,
			32,
			67,
			23,
			1,
			0,
			0,
			0,
			160,
			48,
			0,
			0,
			0,
			0,
			64,
			69,
			0,
			0,
			0,
			0,
			224,
			155,
			14,
			0,
			0,
			0,
			64,
			216,
			3,
			0,
			0,
			0,
			96,
			29,
			0,
			0,
			128,
			12,
			32,
			36,
			17,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			160,
			26,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			64,
			17,
			0,
			0,
			64,
			1,
			224,
			24,
			0,
			0,
			192,
			18,
			32,
			23,
			0,
			0,
			192,
			18,
			192,
			42,
			0,
			0,
			128,
			2,
			64,
			22,
			0,
			0,
			64,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			212,
			195,
			109,
			240,
			250,
			10,
			200,
			40,
			90,
			0,
			0,
			0,
			0,
			32,
			35,
			0,
			0,
			0,
			0,
			160,
			30,
			0,
			0,
			0,
			0,
			240,
			byte.MaxValue,
			6,
			0,
			0,
			0,
			24,
			139,
			1,
			0,
			0,
			0,
			168,
			6,
			0,
			0,
			32,
			3,
			168,
			239,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			144,
			9,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			0,
			0,
			0,
			120,
			0,
			48,
			1,
			0,
			0,
			80,
			0,
			168,
			6,
			0,
			0,
			176,
			4,
			240,
			5,
			0,
			0,
			176,
			4,
			152,
			11,
			0,
			0,
			160,
			0,
			24,
			6,
			0,
			0,
			80,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			56,
			245,
			112,
			27,
			105,
			71,
			4,
			50,
			32,
			14,
			0,
			0,
			0,
			0,
			80,
			7,
			0,
			0,
			0,
			0,
			12,
			3,
			0,
			0,
			0,
			0,
			240,
			139,
			0,
			0,
			0,
			0,
			64,
			38,
			0,
			0,
			0,
			0,
			74,
			1,
			0,
			0,
			200,
			0,
			150,
			219,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			40,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			14,
			1,
			0,
			0,
			20,
			0,
			64,
			1,
			0,
			0,
			44,
			1,
			122,
			1,
			0,
			0,
			44,
			1,
			30,
			2,
			0,
			0,
			40,
			0,
			40,
			1,
			0,
			0,
			20,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			78,
			61,
			220,
			70,
			68,
			123,
			128,
			12,
			172,
			4,
			0,
			0,
			0,
			128,
			120,
			0,
			0,
			0,
			0,
			0,
			218,
			0,
			0,
			0,
			0,
			128,
			42,
			40,
			0,
			0,
			0,
			0,
			222,
			10,
			0,
			0,
			0,
			128,
			129,
			0,
			0,
			0,
			50,
			0,
			237,
			77,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			85,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			0,
			65,
			0,
			0,
			0,
			5,
			0,
			77,
			0,
			0,
			0,
			75,
			0,
			99,
			0,
			0,
			0,
			75,
			128,
			175,
			0,
			0,
			0,
			10,
			0,
			87,
			0,
			0,
			0,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			83,
			15,
			183,
			97,
			176,
			43,
			32,
			163,
			109,
			1,
			0,
			0,
			0,
			96,
			146,
			0,
			0,
			0,
			0,
			160,
			117,
			0,
			0,
			0,
			0,
			96,
			251,
			26,
			0,
			0,
			0,
			192,
			49,
			6,
			0,
			0,
			0,
			96,
			30,
			0,
			0,
			128,
			12,
			160,
			28,
			23,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			160,
			44,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			192,
			7,
			0,
			0,
			64,
			1,
			32,
			30,
			0,
			0,
			192,
			18,
			160,
			31,
			0,
			0,
			192,
			18,
			224,
			51,
			0,
			0,
			128,
			2,
			64,
			23,
			0,
			0,
			64,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			212,
			195,
			109,
			64,
			116,
			15,
			136,
			232,
			87,
			0,
			0,
			0,
			0,
			232,
			37,
			0,
			0,
			0,
			0,
			64,
			26,
			0,
			0,
			0,
			0,
			248,
			24,
			6,
			0,
			0,
			0,
			248,
			80,
			1,
			0,
			0,
			0,
			136,
			7,
			0,
			0,
			32,
			3,
			96,
			128,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			200,
			8,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			0,
			0,
			0,
			120,
			0,
			72,
			1,
			0,
			0,
			80,
			0,
			0,
			8,
			0,
			0,
			176,
			4,
			56,
			6,
			0,
			0,
			176,
			4,
			240,
			11,
			0,
			0,
			160,
			0,
			16,
			7,
			0,
			0,
			80,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			56,
			245,
			112,
			27,
			153,
			238,
			3,
			2,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			136,
			66,
			0,
			0,
			0,
			0,
			48,
			14,
			0,
			0,
			0,
			0,
			120,
			16,
			0,
			0,
			0,
			0,
			48,
			120,
			4,
			0,
			0,
			0,
			160,
			213,
			0,
			0,
			0,
			0,
			224,
			7,
			0,
			0,
			32,
			3,
			200,
			136,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			112,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			0,
			0,
			0,
			120,
			0,
			168,
			5,
			0,
			0,
			80,
			0,
			96,
			6,
			0,
			0,
			176,
			4,
			232,
			7,
			0,
			0,
			176,
			4,
			24,
			11,
			0,
			0,
			160,
			0,
			240,
			4,
			0,
			0,
			80,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			40,
			213,
			225,
			154,
			45,
			168,
			2,
			50,
			8,
			14,
			0,
			0,
			0,
			0,
			134,
			1,
			0,
			0,
			0,
			0,
			128,
			3,
			0,
			0,
			0,
			0,
			218,
			33,
			1,
			0,
			0,
			0,
			226,
			60,
			0,
			0,
			0,
			0,
			62,
			1,
			0,
			0,
			200,
			0,
			102,
			196,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			108,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			128,
			0,
			0,
			0,
			20,
			0,
			98,
			1,
			0,
			0,
			44,
			1,
			148,
			1,
			0,
			0,
			44,
			1,
			70,
			2,
			0,
			0,
			40,
			0,
			48,
			1,
			0,
			0,
			20,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			74,
			117,
			184,
			102,
			112,
			149,
			128,
			12,
			224,
			3,
			0,
			0,
			0,
			128,
			244,
			0,
			0,
			0,
			0,
			128,
			233,
			0,
			0,
			0,
			0,
			0,
			165,
			75,
			0,
			0,
			0,
			128,
			121,
			13,
			0,
			0,
			0,
			0,
			87,
			0,
			0,
			0,
			50,
			128,
			223,
			50,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			88,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			0,
			62,
			0,
			0,
			0,
			5,
			0,
			86,
			0,
			0,
			0,
			75,
			0,
			102,
			0,
			0,
			0,
			75,
			0,
			186,
			0,
			0,
			0,
			10,
			128,
			77,
			0,
			0,
			0,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			82,
			29,
			174,
			233,
			218,
			38,
			32,
			131,
			226,
			0,
			0,
			0,
			0,
			192,
			33,
			0,
			0,
			0,
			0,
			64,
			67,
			0,
			0,
			0,
			0,
			96,
			22,
			17,
			0,
			0,
			0,
			0,
			47,
			3,
			0,
			0,
			0,
			160,
			24,
			0,
			0,
			128,
			12,
			192,
			201,
			13,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			22,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			0,
			11,
			0,
			0,
			64,
			1,
			160,
			22,
			0,
			0,
			192,
			18,
			32,
			22,
			0,
			0,
			192,
			18,
			128,
			33,
			0,
			0,
			128,
			2,
			96,
			16,
			0,
			0,
			64,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			160,
			84,
			135,
			107,
			130,
			133,
			9,
			8,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			140,
			209,
			5,
			0,
			0,
			0,
			0,
			165,
			0,
			0,
			0,
			0,
			128,
			175,
			1,
			0,
			0,
			0,
			128,
			160,
			11,
			0,
			0,
			0,
			128,
			219,
			6,
			0,
			0,
			0,
			0,
			222,
			0,
			0,
			0,
			0,
			128,
			88,
			110,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			55,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			128,
			4,
			5,
			0,
			0,
			125,
			128,
			177,
			0,
			0,
			0,
			5,
			0,
			130,
			0,
			0,
			0,
			25,
			0,
			39,
			0,
			0,
			0,
			25,
			128,
			172,
			0,
			0,
			128,
			2,
			0,
			97,
			0,
			0,
			0,
			5,
			128,
			17,
			49,
			32,
			11,
			249,
			71,
			32,
			2,
			216,
			0,
			0,
			0,
			0,
			160,
			37,
			0,
			0,
			0,
			0,
			64,
			53,
			0,
			0,
			0,
			0,
			128,
			192,
			3,
			0,
			0,
			0,
			224,
			140,
			1,
			0,
			0,
			0,
			160,
			35,
			0,
			0,
			0,
			0,
			128,
			57,
			14,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			11,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			192,
			59,
			0,
			0,
			64,
			31,
			160,
			19,
			0,
			0,
			64,
			1,
			128,
			12,
			0,
			0,
			64,
			6,
			192,
			18,
			0,
			0,
			64,
			6,
			160,
			30,
			0,
			0,
			160,
			0,
			64,
			15,
			0,
			0,
			64,
			1,
			96,
			68,
			4,
			200,
			246,
			41,
			10,
			200,
			192,
			107,
			0,
			0,
			0,
			0,
			168,
			32,
			0,
			0,
			0,
			0,
			16,
			27,
			0,
			0,
			0,
			0,
			40,
			192,
			0,
			0,
			0,
			0,
			24,
			113,
			0,
			0,
			0,
			0,
			248,
			12,
			0,
			0,
			0,
			0,
			64,
			117,
			7,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			0,
			0,
			0,
			120,
			0,
			24,
			97,
			0,
			0,
			208,
			7,
			248,
			14,
			0,
			0,
			80,
			0,
			184,
			13,
			0,
			0,
			144,
			1,
			112,
			3,
			0,
			0,
			144,
			1,
			128,
			13,
			0,
			0,
			40,
			0,
			16,
			7,
			0,
			0,
			80,
			0,
			24,
			17,
			1,
			178,
			170,
			175,
			5,
			34,
			136,
			16,
			0,
			0,
			0,
			0,
			42,
			1,
			0,
			0,
			0,
			0,
			102,
			3,
			0,
			0,
			0,
			0,
			216,
			39,
			0,
			0,
			0,
			0,
			30,
			20,
			0,
			0,
			0,
			0,
			234,
			2,
			0,
			0,
			0,
			0,
			174,
			19,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			104,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			170,
			12,
			0,
			0,
			244,
			1,
			30,
			2,
			0,
			0,
			20,
			0,
			142,
			0,
			0,
			0,
			100,
			0,
			146,
			0,
			0,
			0,
			100,
			0,
			58,
			2,
			0,
			0,
			10,
			0,
			50,
			1,
			0,
			0,
			20,
			0,
			70,
			68,
			128,
			172,
			96,
			211,
			128,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			34,
			117,
			1,
			0,
			0,
			0,
			64,
			173,
			0,
			0,
			0,
			0,
			32,
			118,
			0,
			0,
			0,
			0,
			128,
			63,
			2,
			0,
			0,
			0,
			192,
			202,
			1,
			0,
			0,
			0,
			192,
			20,
			0,
			0,
			0,
			0,
			0,
			164,
			20,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			96,
			11,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			224,
			29,
			1,
			0,
			64,
			31,
			0,
			34,
			0,
			0,
			192,
			3,
			96,
			14,
			0,
			0,
			64,
			6,
			96,
			18,
			0,
			0,
			64,
			6,
			128,
			60,
			0,
			0,
			160,
			0,
			64,
			26,
			0,
			0,
			64,
			1,
			64,
			22,
			64,
			105,
			104,
			220,
			16,
			136,
			184,
			100,
			0,
			0,
			0,
			0,
			128,
			4,
			0,
			0,
			0,
			0,
			40,
			36,
			0,
			0,
			0,
			0,
			56,
			8,
			2,
			0,
			0,
			0,
			224,
			227,
			0,
			0,
			0,
			0,
			120,
			7,
			0,
			0,
			0,
			0,
			168,
			156,
			6,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			192,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			120,
			0,
			0,
			0,
			120,
			0,
			8,
			30,
			0,
			0,
			208,
			7,
			224,
			9,
			0,
			0,
			240,
			0,
			32,
			2,
			0,
			0,
			144,
			1,
			24,
			2,
			0,
			0,
			144,
			1,
			192,
			12,
			0,
			0,
			40,
			0,
			80,
			7,
			0,
			0,
			80,
			0,
			144,
			5,
			80,
			26,
			228,
			7,
			5,
			50,
			40,
			27,
			0,
			0,
			0,
			0,
			92,
			2,
			0,
			0,
			0,
			0,
			60,
			9,
			0,
			0,
			0,
			0,
			20,
			119,
			0,
			0,
			0,
			0,
			190,
			59,
			0,
			0,
			0,
			0,
			228,
			1,
			0,
			0,
			0,
			0,
			26,
			164,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			156,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			222,
			8,
			0,
			0,
			244,
			1,
			210,
			2,
			0,
			0,
			60,
			0,
			242,
			0,
			0,
			0,
			100,
			0,
			190,
			0,
			0,
			0,
			100,
			0,
			238,
			3,
			0,
			0,
			10,
			0,
			2,
			2,
			0,
			0,
			20,
			0,
			100,
			1,
			148,
			198,
			207,
			74,
			129,
			140,
			4,
			6,
			0,
			0,
			0,
			0,
			178,
			0,
			0,
			0,
			0,
			0,
			250,
			1,
			0,
			0,
			0,
			128,
			54,
			11,
			0,
			0,
			0,
			0,
			211,
			6,
			0,
			0,
			0,
			128,
			86,
			0,
			0,
			0,
			0,
			128,
			37,
			89,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			34,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			128,
			205,
			4,
			0,
			0,
			125,
			128,
			156,
			0,
			0,
			0,
			15,
			0,
			67,
			0,
			0,
			0,
			25,
			0,
			36,
			0,
			0,
			0,
			25,
			0,
			234,
			0,
			0,
			128,
			2,
			128,
			113,
			0,
			0,
			0,
			5,
			0,
			89,
			0,
			165,
			113,
			123,
			75,
			32,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			32,
			208,
			2,
			0,
			0,
			0,
			0,
			236,
			0,
			0,
			0,
			0,
			0,
			252,
			0,
			0,
			0,
			0,
			0,
			148,
			6,
			0,
			0,
			0,
			0,
			60,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			150,
			37,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			10,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			48,
			1,
			0,
			0,
			200,
			0,
			110,
			0,
			0,
			0,
			20,
			0,
			18,
			0,
			0,
			0,
			2,
			0,
			6,
			0,
			0,
			0,
			2,
			0,
			106,
			0,
			0,
			0,
			10,
			0,
			6,
			0,
			0,
			0,
			2,
			0,
			0,
			0,
			0,
			192,
			140,
			38,
			128,
			12,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			35,
			0,
			0,
			0,
			0,
			128,
			221,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			136,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			6,
			0,
			0,
			128,
			6,
			0,
			184,
			0,
			0,
			0,
			50,
			0,
			163,
			0,
			0,
			0,
			5,
			128,
			8,
			0,
			0,
			128,
			0,
			0,
			7,
			0,
			0,
			128,
			0,
			128,
			1,
			0,
			0,
			0,
			1,
			128,
			1,
			0,
			0,
			128,
			0,
			0,
			0,
			0,
			0,
			32,
			23,
			5,
			32,
			227,
			34,
			0,
			0,
			128,
			12,
			96,
			10,
			0,
			0,
			0,
			0,
			64,
			12,
			0,
			0,
			0,
			0,
			160,
			76,
			0,
			0,
			0,
			0,
			192,
			44,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			160,
			154,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			64,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			96,
			6,
			0,
			0,
			64,
			1,
			32,
			0,
			0,
			0,
			32,
			0,
			0,
			1,
			0,
			0,
			32,
			0,
			0,
			4,
			0,
			0,
			160,
			0,
			32,
			1,
			0,
			0,
			32,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			88,
			177,
			0,
			8,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			32,
			118,
			2,
			0,
			0,
			200,
			0,
			30,
			0,
			0,
			0,
			0,
			0,
			24,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			34,
			164,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			26,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			146,
			69,
			0,
			0,
			248,
			7,
			154,
			1,
			0,
			0,
			50,
			0,
			180,
			1,
			0,
			0,
			50,
			0,
			160,
			0,
			0,
			0,
			50,
			0,
			52,
			0,
			0,
			0,
			50,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			64,
			115,
			11,
			128,
			12,
			237,
			1,
			0,
			0,
			150,
			128,
			55,
			0,
			0,
			0,
			0,
			0,
			211,
			0,
			0,
			0,
			0,
			128,
			113,
			8,
			0,
			0,
			0,
			0,
			166,
			5,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			43,
			30,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			23,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			7,
			0,
			0,
			128,
			7,
			128,
			33,
			0,
			0,
			128,
			0,
			128,
			56,
			0,
			0,
			128,
			2,
			0,
			6,
			0,
			0,
			128,
			0,
			128,
			4,
			0,
			0,
			128,
			0,
			128,
			21,
			0,
			0,
			128,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			0,
			16,
			68,
			184,
			153,
			21,
			32,
			163,
			106,
			0,
			0,
			0,
			0,
			64,
			19,
			0,
			0,
			0,
			0,
			64,
			55,
			0,
			0,
			0,
			0,
			32,
			151,
			0,
			0,
			0,
			0,
			0,
			38,
			0,
			0,
			0,
			0,
			0,
			3,
			0,
			0,
			0,
			0,
			192,
			176,
			7,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			1,
			0,
			0,
			224,
			1,
			160,
			106,
			0,
			0,
			128,
			37,
			128,
			12,
			0,
			0,
			160,
			0,
			160,
			17,
			0,
			0,
			32,
			3,
			64,
			63,
			0,
			0,
			32,
			3,
			128,
			12,
			0,
			0,
			32,
			0,
			0,
			5,
			0,
			0,
			64,
			0,
			0,
			0,
			0,
			0,
			176,
			55,
			4,
			8,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			86,
			0,
			0,
			0,
			0,
			0,
			6,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			220,
			0,
			0,
			0,
			0,
			0,
			144,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			188,
			25,
			0,
			0,
			0,
			0,
			16,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			2,
			51,
			0,
			0,
			128,
			37,
			224,
			30,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			192,
			109,
			1,
			0,
			0,
			0,
			128,
			114,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			32,
			23,
			245,
			0,
			0,
			0,
			128,
			103,
			1,
			0,
			0,
			0,
			96,
			11,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			144,
			164,
			2,
			128,
			24,
			21,
			0,
			0,
			96,
			9,
			168,
			2,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			240,
			80,
			0,
			0,
			0,
			0,
			80,
			21,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			248,
			17,
			5,
			0,
			0,
			0,
			248,
			76,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			16,
			8,
			1,
			32,
			92,
			3,
			0,
			0,
			88,
			2,
			196,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			94,
			26,
			0,
			0,
			0,
			0,
			164,
			8,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			72,
			6,
			5,
			0,
			0,
			0,
			98,
			25,
			0,
			0,
			0,
			0,
			194,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			155,
			47,
			0,
			136,
			17,
			3,
			0,
			0,
			150,
			128,
			48,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			70,
			9,
			0,
			0,
			0,
			128,
			159,
			4,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			215,
			103,
			1,
			0,
			0,
			0,
			19,
			9,
			0,
			0,
			0,
			128,
			43,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			96,
			33,
			46,
			0,
			34,
			165,
			0,
			0,
			128,
			37,
			160,
			18,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			32,
			117,
			2,
			0,
			0,
			0,
			96,
			235,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			83,
			110,
			0,
			0,
			0,
			192,
			238,
			2,
			0,
			0,
			0,
			160,
			7,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			84,
			113,
			8,
			128,
			88,
			51,
			0,
			0,
			96,
			9,
			56,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			136,
			244,
			0,
			0,
			0,
			0,
			48,
			72,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			160,
			122,
			57,
			0,
			0,
			0,
			176,
			244,
			0,
			0,
			0,
			0,
			80,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			45,
			193,
			2,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			8,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			133,
			0,
			0,
			0,
			0,
			0,
			6,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			74,
			56,
			0,
			0,
			0,
			0,
			133,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			66,
			1,
			0,
			0,
			0,
			0,
			128,
			2,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			96,
			251,
			0,
			0,
			0,
			0,
			64,
			138,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			192,
			0,
			37,
			0,
			0,
			0,
			64,
			138,
			0,
			0,
			0,
			0,
			0,
			11,
			0,
			0,
			0,
			0,
			224,
			78,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			160,
			15,
			0,
			192,
			120,
			0,
			0,
			0,
			0,
			0,
			16,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			88,
			79,
			0,
			0,
			0,
			0,
			224,
			63,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			172,
			15,
			0,
			0,
			0,
			64,
			78,
			0,
			0,
			0,
			0,
			88,
			18,
			0,
			0,
			0,
			0,
			152,
			19,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			124,
			21,
			0,
			48,
			6,
			0,
			0,
			0,
			0,
			0,
			4,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			82,
			7,
			0,
			0,
			0,
			0,
			68,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			12,
			123,
			1,
			0,
			0,
			0,
			66,
			7,
			0,
			0,
			0,
			0,
			42,
			0,
			0,
			0,
			0,
			0,
			222,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			175,
			0,
			0,
			12,
			2,
			0,
			0,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			12,
			3,
			0,
			0,
			0,
			0,
			38,
			3,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			79,
			238,
			0,
			0,
			0,
			0,
			121,
			1,
			0,
			0,
			0,
			0,
			63,
			0,
			0,
			0,
			0,
			0,
			75,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			25,
			0,
			0,
			195,
			1,
			0,
			0,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			96,
			184,
			1,
			0,
			0,
			0,
			192,
			115,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			192,
			114,
			116,
			0,
			0,
			0,
			224,
			222,
			1,
			0,
			0,
			0,
			64,
			34,
			0,
			0,
			0,
			0,
			224,
			67,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			80,
			20,
			0,
			128,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			248,
			112,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			192,
			247,
			30,
			0,
			0,
			0,
			64,
			85,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			224,
			49,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			22,
			113,
			0,
			48,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			66,
			16,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			154,
			0,
			0,
			0,
			0,
			0,
			32,
			74,
			5,
			0,
			0,
			0,
			190,
			9,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			118,
			4,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			136,
			2,
			0,
			0,
			0,
			0,
			128,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			96,
			2,
			0,
			0,
			0,
			128,
			30,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			31,
			146,
			0,
			0,
			0,
			128,
			79,
			2,
			0,
			0,
			0,
			0,
			1,
			0,
			0,
			0,
			0,
			0,
			82,
			1,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			128,
			37,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			108,
			4,
			0,
			0,
			144,
			1,
			38,
			2,
			0,
			0,
			0,
			0,
			228,
			4,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			88,
			162,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			30,
			0,
			0,
			0,
			30,
			0,
			240,
			0,
			0,
			0,
			20,
			0,
			66,
			0,
			0,
			0,
			10,
			0,
			142,
			0,
			0,
			0,
			10,
			0,
			66,
			0,
			0,
			0,
			10,
			0,
			26,
			0,
			0,
			0,
			10,
			0,
			0
		};

		 //0x0400003F RID: 63
		private object index;

		 //0x04000040 RID: 64
		private string text;

		 //0x04000041 RID: 65
		private byte[] accolades;

		 //0x04000042 RID: 66
		private byte[] SMCReturn = new byte[16];

		 //0x0200001A RID: 26
		public class Client
		{
			 //0x1700002C RID: 44

			public int Index { get; set; }

			 //0x1700002D RID: 45

			public string Gamertag { get; set; }

			 //0x1700002E RID: 46

			public string XUID { get; set; }

			 //0x1700002F RID: 47
			
			public string InternalIP { get; set; }

			 //0x17000030 RID: 48
			public string ExternalIP { get; set; }

			 //0x17000031 RID: 49
			public string Port { get; set; }

			 //0x17000032 RID: 50
			public string Mac { get; set; }
		}

		 //0x0200001B RID: 27
		private enum AV_PACK
		{
			 //0x0400036C RID: 876
			AV_HDMI = 31,
			 //0x0400036D RID: 877
			AV_COMPONENT = 15,
			 //0x0400036E RID: 878
			AV_VGA = 91,
			 //0x0400036F RID: 879
			AV_COMPOSITETV = 67,
			 //0x04000370 RID: 880
			AV_COMPOSITEHD = 79,
			 //0x04000371 RID: 881
			AV_HDMIAUDIO = 19
		}
    }
}
