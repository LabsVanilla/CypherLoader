using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CypherLoader
{
	// Token: 0x02000007 RID: 7
	internal static class Core
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000023D0 File Offset: 0x000005D0
		private static void GetMethods()
		{ 
			Type modType = InternalConfig.ModType; 
			Core._onApplicationStart = ((modType != null) ? modType.GetMethod("OnApplicationStart") : null);
			Core._onApplicationQuit = ((modType != null) ? modType.GetMethod("OnApplicationQuit") : null);
			Core._onSceneWasLoaded = ((modType != null) ? modType.GetMethod("OnSceneWasLoaded") : null);
			Core._onSceneWasUnloaded = ((modType != null) ? modType.GetMethod("OnSceneWasUnloaded") : null);
			Core._onSceneWasInitialized = ((modType != null) ? modType.GetMethod("OnSceneWasInitialized") : null);
			Core._onUpdate = ((modType != null) ? modType.GetMethod("OnUpdate") : null);
			Core._OnLateUpdate = ((modType != null) ? modType.GetMethod("OnLateUpdate") : null);
			Core._OnApplicationLateStart = ((modType != null) ? modType.GetMethod("OnApplicationLateStart") : null);
			Core._OnGUI = modType.GetMethod("OnGUI");
			Core._OnPreferencesSaved = modType.GetMethod("OnPreferencesSaved");
			Core._OnFixedUpdate = modType.GetMethod("OnFixedUpdate");
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000024CC File Offset: 0x000006CC
		internal static void OnApplicationStart()
		{
			Core.GetMethods();
			if (Core._onApplicationStart != null)
			{
				Core._onApplicationStart.Invoke(null, new object[]
				{
					((GuidAttribute)typeof(LoaderMain).Assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value
				});
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000215E File Offset: 0x0000035E
		internal static void OnApplicationQuit()
		{
			if (Core._onApplicationQuit != null)
			{
				Core._onApplicationQuit.Invoke(null, null);
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000217A File Offset: 0x0000037A
		internal static void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
			if (Core._onSceneWasInitialized != null)
			{
				Core._onSceneWasInitialized.Invoke(null, new object[]
				{
					buildIndex,
					sceneName
				});
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000021A8 File Offset: 0x000003A8
		internal static void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			if (Core._onSceneWasLoaded != null)
			{
				Core._onSceneWasLoaded.Invoke(null, new object[]
				{
					buildIndex,
					sceneName
				});
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000021D6 File Offset: 0x000003D6
		internal static void OnSceneWasUnloaded(int buildIndex, string sceneName)
		{
			if (Core._onSceneWasUnloaded != null)
			{
				Core._onSceneWasUnloaded.Invoke(null, new object[]
				{
					buildIndex,
					sceneName
				});
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002204 File Offset: 0x00000404
		internal static void OnUpdate()
		{
			if (Core._onUpdate != null)
			{
				Core._onUpdate.Invoke(null, null);
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002220 File Offset: 0x00000420
		internal static void OnLateUpdate()
		{
			if (Core._OnLateUpdate != null)
			{
				Core._OnLateUpdate.Invoke(null, null);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000223C File Offset: 0x0000043C
		internal static void OnApplicationLateStart()
		{
			if (Core._OnApplicationLateStart != null)
			{
				Core._OnApplicationLateStart.Invoke(null, null);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002258 File Offset: 0x00000458
		internal static void OnGUI()
		{
			if (Core._OnGUI != null)
			{
				Core._OnGUI.Invoke(null, null);
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002274 File Offset: 0x00000474
		internal static void OnPreferencesSaved()
		{
			if (Core._OnPreferencesSaved != null)
			{
				Core._OnPreferencesSaved.Invoke(null, null);
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002290 File Offset: 0x00000490
		internal static void OnFixedUpdate()
		{
			if (Core._OnFixedUpdate != null)
			{
				Core._OnFixedUpdate.Invoke(null, null);
			}
		}

		// Token: 0x04000013 RID: 19
		private static MethodInfo _onApplicationStart;

		// Token: 0x04000014 RID: 20
		private static MethodInfo _onApplicationQuit;

		// Token: 0x04000015 RID: 21
		private static MethodInfo _onSceneWasLoaded;

		// Token: 0x04000016 RID: 22
		private static MethodInfo _onSceneWasUnloaded;

		// Token: 0x04000017 RID: 23
		private static MethodInfo _onSceneWasInitialized;

		// Token: 0x04000018 RID: 24
		private static MethodInfo _onUpdate;

		// Token: 0x04000019 RID: 25
		private static MethodInfo _OnLateUpdate;

		// Token: 0x0400001A RID: 26
		private static MethodInfo _OnApplicationLateStart;

		// Token: 0x0400001B RID: 27
		private static MethodInfo _OnGUI;

		// Token: 0x0400001C RID: 28
		private static MethodInfo _OnPreferencesSaved;

		// Token: 0x0400001D RID: 29
		private static MethodInfo _OnFixedUpdate;
	}
}
