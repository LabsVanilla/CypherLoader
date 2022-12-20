using System;
using System.Net;
using MelonLoader;
using Newtonsoft.Json;

namespace CypherLoader
{
	// Token: 0x02000008 RID: 8
	internal class LoaderMain
    {
		// Token: 0x0600002F RID: 47 RVA: 0x0000252C File Offset: 0x0000072C
		[Obsolete]
		public static void OnApplicationStart()
		{ HandleAppStart();  }
            internal static void HandleAppStart()
		{
            try
            {
                if (!Utils.GetCommandLine().Contains("--melonloader.debug"))
                {
                    if (Utils.GetCommandLine().Contains("--loadlocal"))
                    {
                        Utils.Log("WARNING LOCAL LOAD ENABLED", ConsoleColor.Yellow);
                    }
                    if (Utils.GetCommandLine().Contains("--betamode"))
                    {
                        InternalConfig.BETA = "1";
                    }
                    if (Utils.GetCommandLine().Contains("--Debug"))
                    {
                        InternalConfig.Verbose = true;
                    }
                    Utils.Log("By Using This Loader You Agree To HyperVoid Labs TOS");
                    Utils.Log("TOS available at https://hvl.gg/tos");
                    WebClient webClient = new WebClient();
                    try
                    {
                        string text = webClient.DownloadString("https://hvl.gg/api/cheats/fetchgame?game=" + Utils.GetGameName());
                        Utils.Debug(text);
                        if (text == null && !Utils.GetCommandLine().Contains("--loadlocal"))
                        {
                            Utils.Log("Game Not Suppprted... Skiping Load", ConsoleColor.Red);
                            webClient.Dispose();
                            return;
                        }
                        LoaderMain.GameData = JsonConvert.DeserializeObject<GameController>(text);
                        if (LoaderMain.GameData.status == 1)
                        {
                            Utils.Log("Cheat Offline Skipping Load...", ConsoleColor.Red);
                            return;
                        }
                        Utils.Log("Loading Cypher Engine For " + Utils.GetGameName());
                        if (LoaderMain.GameData.motd != null)
                        {
                            Utils.Log("[motd] " + LoaderMain.GameData.motd);
                        }
                    }
                    catch (Exception message)
                    {
                        Utils.Debug(message);
                        Utils.Log("Failed Fetching Game List Server Down Maybe?");
                        Utils.Print("Skiping Load...");
                        if (!Utils.GetCommandLine().Contains("--loadlocal"))
                        {
                            return;
                        }
                    }
                    webClient.Dispose();
                    Utils.Debug("Loading Core For " + Utils.GetGameName());
                    Utils.Debug("Config Folder Location \n" + Utils.GetCheatFolder());
                    ServerController.GetCoreFromHost();
                }
            }
            catch (Exception message2)
            {
                Utils.Exception("OnApplication Start", message2);
            }
        }

		// Token: 0x06000030 RID: 48 RVA: 0x000022AC File Offset: 0x000004AC
		[Obsolete]
		public static void OnApplicationLateStart()
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnApplicationLateStart();
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000022BA File Offset: 0x000004BA
		public static void OnLateUpdate()
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnLateUpdate();
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000022C8 File Offset: 0x000004C8
		public static void OnSceneWasLoaded(int level, string name)
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnSceneWasLoaded(level, name);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000022D8 File Offset: 0x000004D8
		public static void OnGUI()
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnGUI();
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000022E6 File Offset: 0x000004E6
		public static void OnPreferencesSaved()
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnPreferencesSaved();
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000022F4 File Offset: 0x000004F4
		public static void OnFixedUpdate()
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnFixedUpdate();
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002302 File Offset: 0x00000502
		public static void OnUpdate()
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnUpdate();
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002310 File Offset: 0x00000510
		public static void OnApplicationQuit()
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnApplicationQuit();
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000231E File Offset: 0x0000051E
		public static void OnSceneWasUnloaded(int level, string name)
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnSceneWasUnloaded(level, name);
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000232E File Offset: 0x0000052E
		public static void OnSceneWasInitialized(int level, string name)
		{
			if (InternalConfig.IsLoaded)
			{
				Core.OnSceneWasInitialized(level, name);
			}
		}

		// Token: 0x0400001E RID: 30
		internal static GameController GameData;
	}
}
