using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringParser
{
	class Program
	{
		static async Task Main()
		{
			var listOfErrors = new List<string>();
			var apiResponse = System.IO.File.ReadAllText(@"C:\Users\uizdg\The University of Nottingham\Official RIS Team - Documents\Dan Giddins RIS Work\project_response_with_errors.json");
			var errorMarker = Regex.Escape("notificationMessages\":{\"_objectMessages\":[{\"code\":3010,\"message\":\"");
			var s = new StringContent(JsonConvert.SerializeObject(
				Regex.Matches(apiResponse, errorMarker).Select(x =>
					apiResponse.Substring(x.Index + errorMarker.Length - 3).Split('"').First())));
			Console.WriteLine(await s.ReadAsStringAsync());
		}
	}
}
