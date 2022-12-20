using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Newtonsoft.Json;

namespace CypherLoader
{
	// Token: 0x02000009 RID: 9
	internal class ServerController
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00002704 File Offset: 0x00000904
		internal static Assembly GetCoreFromHost()
		{
			Assembly assembly = null;
			if (File.Exists(Utils.GetCheatFolder() + "\\Core.dll") && Utils.GetCommandLine().Contains("--loadlocal"))
			{
				Utils.Log("Loading Local Core");
				try
				{
					Utils.GetKey();
					assembly = Assembly.Load(File.ReadAllBytes(Utils.GetCheatFolder() + "\\Core.dll"), null);
					if (assembly != null)
					{
						InternalConfig.IsLoaded = true;
						InternalConfig.ModType = assembly.GetType("Cypher.CoreMain");
						Core.OnApplicationStart();
						return assembly;
					}
				}
				catch (Exception ex)
				{
					Utils.Log("Failed To Load Local Core", ConsoleColor.Red);
				 Utils.Exception("FetchLocalCore", ex);
				}
			}
			using (HttpClient httpClient = new HttpClient())
			{
				Utils.Debug("Fetching Core");
				httpClient.DefaultRequestHeaders.Add("User-Agent", "CypherLoaderMelonloaderAuthPublic");
				try
				{
					Uri requestUri = new Uri("https://hvl.gg/api/cheats/GetCore");
					StringContent content = new StringContent(JsonConvert.SerializeObject(new Post
					{
						Key = Utils.GetKey(),
						HWID = Utils.GetHWID(),
						BETA = InternalConfig.BETA,
						CTC = Utils.GetCurrentTimeInEpoch().ToString(),
						LoaderVersion = InternalConfig.LoaderVersion,
						GameName = Utils.GetGameName().ToLower().Replace(" ", "")
					}), Encoding.UTF8, "application/json");
					Task<HttpResponseMessage> task = httpClient.PostAsync(requestUri, content);
					task.Wait();
					HttpResponseMessage result = task.Result;
					if (result.StatusCode == HttpStatusCode.OK)
					{
						Task<byte[]> task2 = result.Content.ReadAsByteArrayAsync();
						task2.Wait();
						assembly = Assembly.Load(task2.Result);
						httpClient.Dispose();
					}
					else
					{
						ServerResponce serverResponce = JsonConvert.DeserializeObject<ServerResponce>(result.Content.ReadAsStringAsync().Result);
						Utils.Log("Failed Downloading Core (Error: " + serverResponce.message + ")", ConsoleColor.Red);
						if (InternalConfig.Verbose)
						{
							Utils.Debug("Status Code: (" + serverResponce.code + ")");
						}
						httpClient.Dispose();
					}
				}
				catch (Exception message)
				{
					Utils.Log("--------------------------------{Error}------------------------------", ConsoleColor.Red);
					Utils.Log("Error Loading", ConsoleColor.Red);
					Utils.Exception("GetCore", message);
					Utils.Log("--------------------------------{Error}------------------------------", ConsoleColor.Red);
				}
			}
			if (assembly != null)
			{
				InternalConfig.IsLoaded = true;
				InternalConfig.ModType = assembly.GetType("Cypher.CoreMain");
				Core.OnApplicationStart();
			}
			return assembly;
		}
	}
}
