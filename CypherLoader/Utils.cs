using System;
using System.IO;
using MelonLoader;
using MelonLoader.InternalUtils;
using Microsoft.Win32;

namespace CypherLoader
{
	// Token: 0x0200000A RID: 10
	internal class Utils
	{
        private static readonly MelonLogger.Instance loggerInstance = new MelonLogger.Instance("CypherLoader");
        // Token: 0x0600003D RID: 61 RVA: 0x00002346 File Offset: 0x00000546
        internal static void Log(object message, ConsoleColor color = ConsoleColor.White, string caller = null)
        {
            loggerInstance.Msg(color, message);
        }

        internal static string GetCommandLine()
		{
			return Environment.CommandLine.ToLower();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000029A0 File Offset: 0x00000BA0
		internal static string GetKey()
		{
			if (!File.Exists(Utils.GetMainFolder() + "\\Vanilla.Auth"))
			{
				File.Create(Utils.GetMainFolder() + "\\Vanilla.Auth").Close();
			}
			if (new FileInfo(Utils.GetMainFolder() + "\\Vanilla.Auth").Length <= 0L)
			{
				Utils.Log("Please Enter Your AuthKey");
				string text = Console.ReadLine();
				File.WriteAllText(Utils.GetMainFolder() + "\\Vanilla.Auth", text.Trim());
			}
			return File.ReadAllText(Utils.GetMainFolder() + "\\Vanilla.Auth").Trim();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002A3C File Offset: 0x00000C3C
		internal static string GetHWID()
		{
			string text = "";
			string name = "SOFTWARE\\Microsoft\\Cryptography";
			string name2 = "MachineGuid";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(name))
				{
					if (registryKey2 != null)
					{
						object value = registryKey2.GetValue(name2);
						if (value != null)
						{
							text = value.ToString();
						}
					}
				}
				result = text;
				if (text == null)
				{ MelonLogger.Error("FAILED TO GET HWID"); }
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002352 File Offset: 0x00000552
		internal static void Print(object Message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			loggerInstance.Msg(Message);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002367 File Offset: 0x00000567
		internal static void Debug(object Message)
		{
			if (Config.isDebug)
			{
				Utils.Print("[DEBUG] " + ((Message != null) ? Message.ToString() : null));
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000238B File Offset: 0x0000058B
		internal static void Exception(string Loction, Exception Message)
		{
			Utils.Log("[Exception Handler] Report To Cypher", ConsoleColor.Red);
			Utils.Log("[Exception Handler] Caught An Exception at " + Loction, ConsoleColor.Red);
			Utils.Log("[Exception Handler] [" + Loction + "] " + ((Message != null) ? Message.ToString() : null), ConsoleColor.Red);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002ACC File Offset: 0x00000CCC
		internal static string GetMainFolder()
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Vanilla");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002AFC File Offset: 0x00000CFC
		internal static string GetCheatFolder()
		{
			if (!Directory.Exists(Utils.GetMainFolder() + "\\Cheats\\" + Utils.GetGameName()))
			{
				Directory.CreateDirectory(Utils.GetMainFolder() + "\\Cheats\\" + Utils.GetGameName());
			}
			return Utils.GetMainFolder() + "\\Cheats\\" + Utils.GetGameName();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000023C9 File Offset: 0x000005C9
		internal static string GetGameName()
		{
			return UnityInformationHandler.GameName;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002B54 File Offset: 0x00000D54
		internal static long GetRandomNumber()
		{
			return Convert.ToInt64((DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
		}
	}
}
