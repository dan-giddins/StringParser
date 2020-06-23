using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringParser
{
	class Program
	{
		static void Main(string[] args)
		{
			var listOfErrors = new List<string>();
			var apiResponse = System.IO.File.ReadAllText(@"C:\Users\uizdg\The University of Nottingham\Official RIS Team - Documents\Dan Giddins RIS Work\project_response_with_errors.json");
			var errorMarker = Regex.Escape("notificationMessages\":{\"_objectMessages\":[{\"code\":3010,\"message\":\"");
			foreach (var match in Regex.Matches(apiResponse, errorMarker).Cast<Match>().Select(m => m.Index))
			{
				var error = apiResponse.Substring(match + errorMarker.Length - 3).Split('"').First();
				Console.WriteLine(error);
				listOfErrors.Add(error);
			}
		}
	}
}
