using System;

namespace CypherLoader
{
	// Token: 0x02000002 RID: 2
	internal class InternalConfig
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002057 File Offset: 0x00000257
		internal static Type ModType { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x0000205F File Offset: 0x0000025F
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002066 File Offset: 0x00000266
		internal static bool IsLoaded { get; set; }

		// Token: 0x04000003 RID: 3
		internal static string BETA = "0";

		// Token: 0x04000004 RID: 4
		internal static bool Verbose = false;

		// Token: 0x04000005 RID: 5
		internal static string LoaderVersion = "1";
	}
}
