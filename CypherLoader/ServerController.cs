using System;
using System.Collections.Generic;
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
			Dictionary<string, string> SendData = null;
            string pathToDll = Assembly.GetExecutingAssembly().CodeBase;
            AppDomainSetup domainSetup = new AppDomainSetup { PrivateBinPath = pathToDll };
            var newDomain = AppDomain.CreateDomain("CypherEngineDomainMonoohSoPublic1234hvl.gg", null, domainSetup);
            ProxyClass c = (ProxyClass)(newDomain.CreateInstanceFromAndUnwrap(pathToDll, typeof(ProxyClass).FullName));
            
		
            Assembly assembly = null;
			if (File.Exists(Utils.GetCheatFolder() + "\\Core.dll") && Utils.GetCommandLine().Contains("--loadlocal"))
			{
				Utils.Log("Loading Local Core");
				try
				{
					Utils.GetKey();
					assembly = appDomain.Load(File.ReadAllBytes(Utils.GetCheatFolder() + "\\Core.dll"), null);
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
					if (SendData == null)
						SendData = new Dictionary<string, string>();

					SendData.Add("Key", Utils.GetKey());
					SendData.Add("HWID", Utils.GetHWID());
					SendData.Add("CTC", Utils.GetRandomNumber().ToString());
					SendData.Add("GameName", Utils.GetGameName().ToLower());

					Task<HttpResponseMessage> task = httpClient.PostAsync(requestUri, new FormUrlEncodedContent(SendData));
					task.Wait();
					HttpResponseMessage result = task.Result;
					if (result.StatusCode == HttpStatusCode.OK)
					{
						Task<byte[]> task2 = result.Content.ReadAsByteArrayAsync();
						task2.Wait();
						assembly = appDomain.Load(task2.Result);
						httpClient.Dispose();
					}
					else
					{
						//ServerResponce serverResponce = JsonConvert.DeserializeObject<ServerResponce>(result.Content.ReadAsStringAsync().Result);
						object serverResponce = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
						serverResponce.ToString();

						Utils.Log("Failed Downloading Core (Error: " + serverResponce.ToString() + ")", ConsoleColor.Red);
						if (InternalConfig.Verbose)
						{
							Utils.Debug("Status Code: (" + serverResponce.ToString() + ")");
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
			if (assembly != null) { 
				MelonLogger.Log("Attempting to Load Core");
			InternalConfig.IsLoaded = true;
			InternalConfig.ModType = assembly.GetType("Cypher.CoreMain");
			Core.OnApplicationStart();
		}
            return assembly;
        }
        public class ProxyClass : MarshalByRefObject { }
    }

 



    }

