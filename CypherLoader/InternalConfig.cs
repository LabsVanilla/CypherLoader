using System;

namespace CypherLoader
{
	internal class InternalConfig
	{
		internal static Type ModType { get; set; }

		internal static bool IsLoaded { get; set; }

		internal static string BETA = "0";

		internal static bool Verbose = false;

		internal static string LoaderVersion = "1";
	}
}
