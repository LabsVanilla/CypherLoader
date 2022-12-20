using System;

namespace CypherLoader
{
	// Token: 0x02000006 RID: 6
	internal class GameController
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000211A File Offset: 0x0000031A
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002122 File Offset: 0x00000322
		internal string motd { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000212B File Offset: 0x0000032B
		// (set) Token: 0x0600001D RID: 29 RVA: 0x00002133 File Offset: 0x00000333
		internal int ID { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000213C File Offset: 0x0000033C
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002144 File Offset: 0x00000344
		internal int version { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000214D File Offset: 0x0000034D
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002155 File Offset: 0x00000355
		internal int status { get; set; }
	}
}
