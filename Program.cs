using System;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace Curl_c_
{
    class Program
    {
        static void Main(string[] args){
			
			//Input Info-Data
			Console.Write("user:");
				string user = Console.ReadLine();
			Console.Write("token:");
				string token = Console.ReadLine();
			Console.Write("repo_name:");
				string repo_name = Console.ReadLine();
			Console.Write("visibility public or private:");
				string visibility = Console.ReadLine();
			
			//Display Report
			Console.WriteLine(GitHubNewRepository(user,token,repo_name,visibility));
		}
		
		static string GitHubNewRepository(string user, string token, string repo_name, string visibility)
		{
			switch(visibility.ToLower())
			{
				case "public":
					visibility = "false";
				break;
				
				case "private":
					visibility = "true";
				break;
			}
			
			string argument = "-u \""+user+"\":\""+token+"\" https://api.github.com/user/repos -d \"{\\\"name\\\":\\\""+repo_name+"\\\",\\\"private\\\":"+visibility.ToLower()+"}\"";
			Process curl = new Process();
			curl.StartInfo.RedirectStandardOutput = true;
			curl.StartInfo.FileName = "curl.exe";
			curl.StartInfo.Arguments = argument;
			curl.Start();
			StreamReader reader = curl.StandardOutput;
           		return "\n"+reader.ReadToEnd();
		}
    }
}
